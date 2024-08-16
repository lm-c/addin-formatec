using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using LmCorbieUI.LmForms;
using LmCorbieUI;
using LmCorbieUI.Metodos;

namespace AddinFormatec {
  public partial class FrmPastaProcessos : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    List<ProcessoFabricacao> _processos = new List<ProcessoFabricacao>();
    List<Z_Padrao> _descProcessos = new List<Z_Padrao>();

    string _pastaPdf = "";

    public FrmPastaProcessos() {
      InitializeComponent();

      _processos = new List<ProcessoFabricacao>();

      dgv.Grid.DataSource = _processos;

      FormatarGrid();
    }

    private void BtnRefresh_Click(object sender, EventArgs e) {
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

          CarregarPastaPDFs();

          _processos = ProcessoFabricacao.GetProcessoFabricacao();
          dgv.Grid.DataSource = _processos;

          _descProcessos = ProcessoFabricacao.GetDescricaoProcesso(_processos);

          FormatarGrid();

          if (_processos.Count == 0) {
            Toast.Warning("Nenhum Processo encontrado.");
          }
        } else {
          Toast.Warning("Comando apenas para Montagens.");
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componentes\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnGerarPasta_Click(object sender, EventArgs e) {
      if (_processos.Count == 0) return;
      try {
        MsgBox.ShowWaitMessage("Gerando Pastas Processos...");

        if (!Directory.Exists(_pastaPdf)) {
          Toast.Warning("Os PDF's devem ser gerados antes de criar os processos de fabricação!");
          return;
        }

        FormatoFolha.Carregar();

        var pastaPDF = DrawExport.GetFolder("_PDF", swModel);
        string pastaProcesso = DrawExport.GetFolder("_PROCESSOS", swModel);
       
        if (!Directory.Exists(pastaProcesso))
          Directory.CreateDirectory(pastaProcesso);

        foreach (var item in _descProcessos) {
          if (string.IsNullOrEmpty(item.Descricao))
            continue;

          string desenhoPDF = $"{pastaProcesso}{item.Descricao}.PDF";

          List<ProcessoFabricacao> listasNova = _processos.Where(x => Convert.ToInt32(x.IdProcesso) == item.Codigo).ToList();

          //GERAR PDF VOLUMES
          GerarPdfVolumesDesenhos(desenhoPDF, listasNova, pastaPDF);
        }

        Process.Start("explorer.exe", pastaProcesso);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mesclar PDF da montagem\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnSair_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e) {
      try {
        if (sender != null && _processos.Count > 0) {
          lblPercDesenho.Text = $"{(dgv.Grid.CurrentRow.Index + 1)} de {dgv.Grid.RowCount} - " +
              $"{(((dgv.Grid.CurrentRow.Index + 1) * 100) / dgv.Grid.RowCount)}%";
        }
      } catch (Exception) {

      }
    }

    private void FormatarGrid() {
      dgv.Grid.Columns["IdProcesso"].Width = 80;
      dgv.Grid.Columns["DescricaoProcesso"].Width = 150;
      dgv.Grid.Columns["DescricaoItem"].Width = 200;
      dgv.Grid.Columns["QtdItem"].Width = 40;

      dgv.Grid.Columns["IdProcesso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["IdProcesso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["QtdItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["QtdItem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }

    private void CarregarPastaPDFs() {
      _pastaPdf = DrawExport.GetFolder("_PDF", swModel);

      if (!Directory.Exists(_pastaPdf))
        Directory.CreateDirectory(_pastaPdf);
    }

    private void TmrExportar_Tick(object sender, EventArgs e) {
      tmrExportar.Enabled = false;

      try {
        int status = 0;
        int warnings = 0;
        if (dgv.Grid.CurrentRow == null)
          return;

        var item = (DrawExport)dgv.Grid.CurrentRow.DataBoundItem;
        if (item.Exportar == true) {
          swApp.OpenDoc6(item.PathName, (int)swDocumentTypes_e.swDocDRAWING,
          (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);

          swModel = (ModelDoc2)swApp.ActiveDoc;
          swModel.ForceRebuild3(true);

          Exportar();

          swApp.CloseDoc(item.PathName);
          GC.Collect();

          swModel = default(ModelDoc2);
        }

        var index = dgv.Grid.CurrentRow.Index;

        if (index == _processos.Count() - 1) {
          btnRefresh.Enabled =
          btnGerarPasta.Enabled =
          btnSair.Enabled = true;

          Toast.Info("Desenhos exportados com sucesso!");
        } else {
          dgv.Grid.Rows[dgv.Grid.CurrentRow.Index + 1].Cells[1].Selected = true;
          tmrExportar.Enabled = true;
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Exportar\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void NewDrawing(string nomeDesenho, double X, double Y) {
      try {
        int numViews;
        object[] viewNames;
        object[] AtiveConfiguration = null;
        string viewPaletteName;
        swDocumentTypes_e tipoArquivo = swDocumentTypes_e.swDocNONE;
        int i;
        bool boolstatus;

        DrawingDoc swDrawing;
        SolidWorks.Interop.sldworks.View swView;

        WeldmentCutListAnnotation WMTable = default(WeldmentCutListAnnotation);
        BomTableAnnotation swBOMAnnotation = default(BomTableAnnotation);

        tipoArquivo = (swDocumentTypes_e)swModel.GetType();

        string fileName = swModel.GetPathName();
        AtiveConfiguration = (object[])swModel.GetConfigurationNames();
        string activeConfig = (string)AtiveConfiguration[0];

        // se desenho existir abra
        int comp = fileName.Length;

        if (File.Exists(nomeDesenho)) {
          int status = 0;
          int warnings = 0;
          //int errors = 0;
          swApp.OpenDoc6(nomeDesenho, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          // swApp.ActivateDoc2(nomeDesenho, false, (int)errors);
          return;
        }

        swDrawing = (DrawingDoc)swApp.NewDocument(FormatoFolha.model.FormatoA3, 5, 0, 0);
        //swApp.ActivateDoc2("Pe123-000 - Folha1", false, ref longstatus);

        swModel = (ModelDoc2)swApp.ActiveDoc;
        swDrawing = (DrawingDoc)swModel;
        var swModelDocExt = swModel.Extension;

        swModel.SaveAs(nomeDesenho);

        swDrawing.GenerateViewPaletteViews(fileName);
        numViews = 0;
        viewNames = (object[])swDrawing.GetDrawingPaletteViewNames();

        if (!(viewNames == null)) {
          numViews = (viewNames.GetUpperBound(0) - viewNames.GetLowerBound(0));
          for (i = 0; i <= numViews; i++) {
            viewPaletteName = (string)viewNames[i];

            if (tipoArquivo == swDocumentTypes_e.swDocASSEMBLY) {
              if ((viewPaletteName == "*Isométrica")) {
                int BomType;
                int AnchorType;

                swModel = (ModelDoc2)swApp.ActiveDoc;
                swDrawing = (DrawingDoc)swModel;
                swDrawing = (DrawingDoc)swApp.ActiveDoc;


                swView = swDrawing.DropDrawingViewFromPalette2(viewPaletteName, X, Y, 0.0);

                boolstatus = swDrawing.ActivateSheet("Folha1");
                boolstatus = swDrawing.ActivateView("Vista de desenho1");

                // InserirListasMateriais(tipoArquivo, template);
                break;
              }
            }

          }

        }

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao criar novo desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void Exportar() {
      try {
        string fileName = "";

        fileName = $"{_pastaPdf}{((DrawExport)dgv.Grid.CurrentRow.DataBoundItem).NomeComponente}.PDF";
        SalvarComo(fileName);

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao exportar\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void SalvarComo(string fileName) {
      try {
        bool bRet;
        int version = 0, errors = 0, options = 0, warnings = 0;
        if (!Controles.ArquivoEstaAberto(fileName))
          bRet = swModel.SaveAs4(fileName, version, options, ref errors, ref warnings);
        else Toast.Warning($"Arquivo: \"{fileName}\"\nEstá em Uso.\nNão Será Atualizado.");
      } catch (Exception) {
        throw;
      }
    }

    private void TsmSelectAll_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow row in dgv.Grid.Rows)
        row.Cells[0].Value = true;
    }

    private void TsmUnselectAll_Click(object sender, EventArgs e) {
      foreach (DataGridViewRow row in dgv.Grid.Rows)
        row.Cells[0].Value = false;
    }

    private void TsmOpen3D_Click(object sender, EventArgs e) {
      try {
        string fileName = "", openFileNamePart = "", openFileNameAssembly = "";
        int status = 0;
        int warnings = 0;
        fileName = ((DrawExport)dgv.Grid.CurrentRow.DataBoundItem).PathName;

        openFileNamePart = fileName.Replace("SLDDRW", "SLDPRT");
        openFileNameAssembly = fileName.Replace("SLDDRW", "SLDASM");


        if (File.Exists(openFileNamePart)) {
          swApp.OpenDoc6(openFileNamePart, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileNamePart, false, (int)errors);
        } else if (File.Exists(openFileNameAssembly)) {
          swApp.OpenDoc6(openFileNameAssembly, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileNameAssembly, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir arquivo 3D\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TsmOpen2D_Click(object sender, EventArgs e) {
      try {
        string fileName = "";
        int status = 0;
        int warnings = 0;
        fileName = ((DrawExport)dgv.Grid.CurrentRow.DataBoundItem).PathName;


        if (File.Exists(fileName)) {
          swApp.OpenDoc6(fileName, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(fileName, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir arquivo 2D\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    //private static void BubbleSort(List<ProcessoFabricacao> lista)
    //{
    //    try
    //    {
    //        for (int i = 0; i < lista.Count; i++)
    //        {
    //            for (int h = i + 1; h < lista.Count; h++)
    //            {
    //                if (lista[i].EspessuraMaterial > lista[h].EspessuraMaterial)
    //                {
    //                    var CompChange = lista[i];
    //                    lista[i] = lista[h];
    //                    lista[h] = CompChange;
    //                }
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MsgBox.Show($"Erro ao ordenar\n\n{ex.Message}", "Addin LM Projetos",
    //            MessageBoxButtons.OK, MessageBoxIcon.Error);
    //    }
    //}

    private void GerarPdfVolumesDesenhos(string targetPDF, List<ProcessoFabricacao> processos, string pastaPDF) {
      try {
        List<PdfReader> readers = new List<PdfReader>();

        var files = Directory.GetFiles(pastaPDF);
        foreach (ProcessoFabricacao processo in processos) {
          var file = files.FirstOrDefault(x => Path.GetFileNameWithoutExtension(x) == processo.NomeComponente);

          if (file != null) {
            var reader = new PdfReader(file);
            int numOfPage = reader.NumberOfPages;
            readers.Add(reader);
          }
        }

        if (readers.Count > 0) {
          using (FileStream stream = new FileStream(targetPDF, FileMode.Create)) {
            Document pdfDoc = new Document(PageSize.A4);
            PdfCopy pdf = new PdfCopy(pdfDoc, stream);
            pdfDoc.Open();

            foreach (var read in readers) {
              pdf.AddDocument(read);
              read.Dispose();
              read.Close();
            }

            pdfDoc.Close();
            pdfDoc.Dispose();
            pdf.Close();
            pdf.Dispose();

            InserirNotaVolume(targetPDF, processos);
          }
        }

        GC.SuppressFinalize(readers);
        GC.Collect();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mesclar PDF\n\n{ex.Message}", "Addin LM Projetos",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void InserirNotaVolume(string targetPDF, List<ProcessoFabricacao> processos) {
      try {
        int largPDF = 0;
        int altPDF = 0;

        int f = Convert.ToInt32(Font.Italic);
        byte[] bytes = File.ReadAllBytes(targetPDF);
        iTextSharp.text.Font font;
        using (MemoryStream stream = new MemoryStream()) {
          PdfReader reader = new PdfReader(bytes);
          using (PdfStamper stamper = new PdfStamper(reader, stream)) {
            string codigoProc = "0";
            int qtd = 0;
            string descricaoProc = "", codigoItem = "", descricaoTemp = "";

            int pages = reader.NumberOfPages;
            for (int i = 1; i <= pages; i++) {
              //if (pdfProcessoFabricacao[i - 1].IdProcesso == 0)
              //    continue;

              iTextSharp.text.Rectangle mediabox = reader.GetPageSize(i);
              largPDF = Convert.ToInt16(mediabox.Height);
              altPDF = Convert.ToInt16(mediabox.Width);

              // default
              float x = 10f;
              float y = 7f;
              float ang = 0;
              font = FontFactory.GetFont("Arial", 10, f, BaseColor.BLUE);

              if ((largPDF > 835 && largPDF < 845) && (altPDF > 590 && altPDF < 600))//formato A4 Retrato
              {
                x = 300f;
                y = 830f;
                ang = 0;
                font = FontFactory.GetFont("Arial", 10, f, BaseColor.BLUE);
              } else if ((largPDF > 590 && largPDF < 600) && (altPDF > 835 && altPDF < 845))//formato A4
                {
                x = 120f;
                y = 5f;
                ang = 0;
                font = FontFactory.GetFont("Arial", 10, f, BaseColor.BLUE);
              } else if ((largPDF > 835 && largPDF < 845) && (altPDF > 1185 && altPDF < 1195))//formato A3
                {
                x = 450f;
                y = 5f;
                ang = 0;
                font = FontFactory.GetFont("Arial", 12, f, BaseColor.BLUE);
              } else if ((largPDF > 1185 && largPDF < 1195) && (altPDF > 1680 && altPDF < 1690))//formato A2
                {
                x = 900f;
                y = 7f;
                ang = 0;
                font = FontFactory.GetFont("Arial", 14, f, BaseColor.BLUE);
              } else if ((largPDF > 1680 && largPDF < 1690) && (altPDF > 2380 && altPDF < 2390))//formato A1
                {
                x = 1520f;
                y = 7f;
                ang = 0;
                font = FontFactory.GetFont("Arial", 20, f, BaseColor.BLUE);
              }

              if (processos.Count() >= i) {
                codigoProc = processos[i - 1].IdProcesso;
                qtd = processos[i - 1].QtdItem;
                descricaoProc = processos[i - 1].DescricaoProcesso;
                codigoItem = processos[i - 1].NomeComponente;
                descricaoTemp = processos[i - 1].DescricaoItem;

                ColumnText.ShowTextAligned(stamper.GetOverContent(i),
                    Element.ALIGN_LEFT, new Phrase($"{codigoProc} - {descricaoProc} ({qtd}X)", font), x, y, ang);
              }
            }
          }
          bytes = stream.ToArray();
        }
        File.WriteAllBytes(targetPDF, bytes);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao inserir número de página\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

  }
}
