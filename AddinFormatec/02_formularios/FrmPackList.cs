using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using LmCorbieUI.LmForms;
using LmCorbieUI;
using LmCorbieUI.Metodos;

namespace AddinFormatec {
  public partial class FrmPackList : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    List<PackList> _dadosPackList = new List<PackList>();
    List<Z_Padrao> descVolumes = new List<Z_Padrao>();

    string _pastaPdf = "";

    public FrmPackList() {
      InitializeComponent();

      _dadosPackList = new List<PackList>();

      dgv.Grid.DataSource = _dadosPackList;

      FormatarGrid();
    }

    private void Btn_MouseEnter(object sender, EventArgs e) {
      int qtdPontos = 33;

      var cor = (Color)((Label)sender).Tag;

      int red = ((cor.R - qtdPontos > 0) ? (cor.R - qtdPontos) : 0);
      int green = ((cor.G - qtdPontos > 0) ? (cor.G - qtdPontos) : 0);
      int blue = ((cor.B - qtdPontos > 0) ? (cor.B - qtdPontos) : 0);

      cor = Color.FromArgb(red, green, blue);

      ((Label)sender).BackColor = cor;
    }

    private void Btn_MouseLeave(object sender, EventArgs e) {
      var cor = (Color)((Label)sender).Tag;
      ((Label)sender).BackColor = cor;
    }

    private void BtnRefresh_Click(object sender, EventArgs e) {
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          _dadosPackList = PackList.GetPackLit(out descVolumes);
          dgv.Grid.DataSource = _dadosPackList;

          FormatarGrid();
        } else {
          Toast.Warning("Comando apenas para Montagens");
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componentes\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnGerarPasta_Click(object sender, EventArgs e) {
      int qtda = 0;

      if (Controles.PossuiCamposInvalidos(lmControls))
        return;

      if (_dadosPackList.Count == 0) {
        Toast.Warning("Lista não Contem Elementos, verificar se as propridades 'CHECK' foram preenchidas corretamente");
        return;
      } 

      try {
        MsgBox.ShowWaitMessage("Gerando PackList...");

        string pastaPackList = DrawExport.GetFolder("_PACKING_LIST", swModel);
        if (!Directory.Exists(pastaPackList))
          Directory.CreateDirectory(pastaPackList);

        string pastaPackListPDF = $"{pastaPackList}Ped.{txtPedido.Text}_PDF\\";
        if (!Directory.Exists(pastaPackListPDF))
          Directory.CreateDirectory(pastaPackListPDF);

        string pastaPdfTemp = $"{pastaPackList}_PDFTEMP\\";
        if (!Directory.Exists(pastaPdfTemp))
          Directory.CreateDirectory(pastaPdfTemp);

        string packListPDFCompleto = $"{pastaPackListPDF}Ped.{txtPedido.Text} - PACKLIST COMPLETO.PDF";
        string packListPDFCapa = $"{pastaPackListPDF}Ped.{txtPedido.Text} - PACKLIST CAPA.PDF";

        List<PackList> PackListCapa = new List<PackList>();
        foreach (var item in _dadosPackList) {
          if (!PackListCapa.Any(x => x.DescricaoVolume == item.DescricaoVolume)) {
            PackListCapa.Add(new PackList {
              NomeConfiguracao = item.NomeConfiguracao,
              DescricaoItem = item.DescricaoItem,
              DescricaoVolume = item.DescricaoVolume,
              IdVolume = item.IdVolume,
              QtdItem = item.QtdItem * qtda,
            });
          }
        }
        List<BindingSource> listaCapa = new List<BindingSource>()
        {
                    new BindingSource{DataSource = PackListCapa },
                };

        List<string> nomeDSCapa = new List<string>()
        {
                    "PackListDS"
                };

        List<ReportParameter> parametersCapa = new List<ReportParameter>();

        ReportParameter prtEquipamento = new ReportParameter("rppEquipamento", txtDescricao.Text, true);
        ReportParameter prtPedido = new ReportParameter("rppPedido", txtPedido.Text, true);

        parametersCapa.Add(prtEquipamento);
        parametersCapa.Add(prtPedido);

        string reportCapa = "AddinFormatec.Relatorios.rptCapaPackList.rdlc";

        if (!Directory.Exists(pastaPackListPDF))
          Directory.CreateDirectory(pastaPackListPDF);

        FrmRelatorio frmCapa = new FrmRelatorio(listaCapa, nomeDSCapa, reportCapa, parametersCapa, true);

        if (!Controles.ArquivoEstaAberto(packListPDFCapa)) {
          File.WriteAllBytes(packListPDFCapa, frmCapa.bytesPDF);
        } else {
          Toast.Warning($"Arquivo PDF já está aberto.\n\n\"{packListPDFCapa}\"");
        }

        List<string> pdfMesclar = new List<string>();
        pdfMesclar.Add(packListPDFCapa);

        for (int i = 0; i < descVolumes.Count(); i++) {
          int idVol = i + 1;

          string volume = descVolumes[i].Descricao;
          if (string.IsNullOrEmpty(volume))
            break;

          List<PackList> listasNova = new List<PackList>();

          string packListPDF = $"{pastaPackListPDF}Ped.{txtPedido.Text} - {descVolumes[i].Descricao} PACKLIST.PDF";
          string desenhosPDF = $"{pastaPackListPDF}Ped.{txtPedido.Text} - {descVolumes[i].Descricao} DESENHOS.PDF";

          foreach (PackList item in _dadosPackList.Where(x => x.IdVolume == idVol)) {
            listasNova.Add(new PackList {
              DescricaoItem = item.DescricaoItem,
              NomeConfiguracao = item.NomeConfiguracao,
              DescricaoVolume = item.DescricaoVolume,
              IdVolume = item.IdVolume,
              QtdItem = item.QtdItem * qtda
            });
          }

          List<BindingSource> listas = new List<BindingSource>()
          {
            new BindingSource{DataSource = listasNova },
          };

          List<string> nomeDS = new List<string>()
          {
            "PackListDS"
          };

          string logoCustomax = $"{Application.StartupPath}\\01 - Addin Formatec\\LogoFormatecRelatorio.png";

          List<ReportParameter> parameters = new List<ReportParameter>();

          ReportParameter prtLogo = new ReportParameter("rppLogo", "File://" + logoCustomax, true);
          ReportParameter prtVolumeCod = new ReportParameter("rppVolumeCodigo", idVol.ToString("00"), true);
          ReportParameter prtVolumeDesc = new ReportParameter("rppVolumeDescricao", descVolumes[i].Descricao, true);
          ReportParameter prtRevisao = new ReportParameter("rppRevisao", "", true);
          ReportParameter prtData = new ReportParameter("rppData", txtData.Text, true);

          parameters.Add(prtLogo);
          parameters.Add(prtEquipamento);
          parameters.Add(prtPedido);
          parameters.Add(prtVolumeCod);
          parameters.Add(prtVolumeDesc);
          parameters.Add(prtRevisao);
          parameters.Add(prtData);

          string report = "AddinFormatec.Relatorios.rptPackList.rdlc";

          if (!Directory.Exists(pastaPackListPDF))
            Directory.CreateDirectory(pastaPackListPDF);

          FrmRelatorio frm = new FrmRelatorio(listas, nomeDS, report, parameters, true);

          if (!Controles.ArquivoEstaAberto(packListPDF)) {
            File.WriteAllBytes(packListPDF, frm.bytesPDF);
          } else {
            Toast.Warning($"Arquivo PDF já está aberto.\n\n\"{packListPDF}\"");
          }

          //GERAR PDF VOLUMES
          GerarPdfVolumesDesenhos(desenhosPDF, pastaPdfTemp, qtda, idVol);

          pdfMesclar.Add(packListPDF);
          pdfMesclar.Add(desenhosPDF);
        }

        Controles.MesclarPDFs(pdfMesclar, packListPDFCompleto);

        foreach (var file in pdfMesclar) {
          File.Delete(file);
        }

        Process.Start("explorer.exe", pastaPackList);

        Directory.Delete(pastaPdfTemp, recursive: true);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Salvar PackList\n\n{ex.Message}", "Addin LM Projetos",
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
        if (sender != null && _dadosPackList.Count > 0) {
          lblPercDesenho.Text = $"{(dgv.Grid.CurrentRow.Index + 1)} de {dgv.Grid.RowCount} - " +
              $"{(((dgv.Grid.CurrentRow.Index + 1) * 100) / dgv.Grid.RowCount)}%";
        }
      } catch (Exception) {

      }
    }

    private void FormatarGrid() {
      dgv.Grid.Columns["IdVolume"].Width = 40;
      dgv.Grid.Columns["NomeComponente"].Width = 120;
      dgv.Grid.Columns["DescricaoItem"].Width = 350;
      dgv.Grid.Columns["DescricaoVolume"].Width = 250;
      dgv.Grid.Columns["QtdItem"].Width = 50;

      dgv.Grid.Columns["IdVolume"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["IdVolume"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["QtdItem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["QtdItem"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }

    private void CarregarPastaPDFs() {
      _pastaPdf = DrawExport.GetFolder("-" + DateTime.Now.Year.ToString().Substring(2, 2) + "_PDF", swModel);

      if (!Directory.Exists(_pastaPdf))
        Directory.CreateDirectory(_pastaPdf);
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

    private void GerarPdfVolumesDesenhos(string targetPDF, string pastaPdfTemp, int qtda, int idVol) {
      try {
        List<PackList> pdfPackList = new List<PackList>();

        CarregarPastaPDFs();

        bool pdfHasPages = false;

        int errors = 0;
        int version = 0;
        int options = 0;
        int warnings = 0;
        int status = 0;

        List<PdfReader> readers = new List<PdfReader>();
        var paksVolume = _dadosPackList.Where(x => x.IdVolume == idVol).ToList();

        foreach (PackList packList in paksVolume) {
          var name = packList.PathName;

          if (string.IsNullOrEmpty(name))
            continue;

          int tipo = name.ToUpper().EndsWith("SLDASM") ? (int)swDocumentTypes_e.swDocASSEMBLY : (int)swDocumentTypes_e.swDocPART;

          if (File.Exists(name) && File.Exists(name.ToUpper().Replace("SLDASM", "SLDDRW").Replace("SLDPRT", "SLDDRW"))) {
            swApp.OpenDoc6(name, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
            swApp.ActivateDoc2(name, false, (int)errors);

            swModel = (ModelDoc2)swApp.ActiveDoc;

            swModel.ShowNamedView("*Isométrica");
            swModel.ViewZoomtofit();

            // Salvar PDF
            var fileNamePDF = $"{pastaPdfTemp}{Path.GetFileNameWithoutExtension(name)}.PDF";
            swModel.SaveAs4(fileNamePDF, version, options, ref errors, ref warnings);

            swApp.CloseDoc(name);

            if (File.Exists(fileNamePDF)) {
              var reader = new PdfReader(fileNamePDF);
              int numOfPage = reader.NumberOfPages;
              readers.Add(reader);
            }
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

            InserirNotaVolume(targetPDF, paksVolume, qtda);
          }
        }

        GC.SuppressFinalize(readers);
        GC.Collect();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mesclar PDF\n\n{ex.Message}", "Addin LM Projetos",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void InserirNotaVolume(string targetPDF, List<PackList> paksVolume, int qtda) {
      try {
        int largPDF = 0;
        int altPDF = 0;

        int f = Convert.ToInt32(Font.Italic);
        byte[] bytes = File.ReadAllBytes(targetPDF);
        iTextSharp.text.Font font;
        using (MemoryStream stream = new MemoryStream()) {
          PdfReader reader = new PdfReader(bytes);
          using (PdfStamper stamper = new PdfStamper(reader, stream)) {
            int volume = 0, qtd = 0;
            string descricaoVolume = "";
            int pages = reader.NumberOfPages;
            for (int i = 1; i <= pages; i++) {
              iTextSharp.text.Rectangle mediabox = reader.GetPageSize(i);
              largPDF = Convert.ToInt16(mediabox.Height);
              altPDF = Convert.ToInt16(mediabox.Width);

              // default
              float x = 15;
              float y = 573;
              float ang = 0;
              font = FontFactory.GetFont("Arial", 16, f, BaseColor.BLUE);

              ColumnText.ShowTextAligned(stamper.GetOverContent(i),
                  Element.ALIGN_LEFT, new Phrase($"Código Produto: {paksVolume[i - 1].NomeComponente}", font), x, y, ang);

              y -= 21;
              ang = 0;
              font = FontFactory.GetFont("Arial", 14, f, BaseColor.BLUE);

              volume = paksVolume[i - 1].IdVolume;
              qtd = paksVolume[i - 1].QtdItem * qtda;
              descricaoVolume = paksVolume[i - 1].DescricaoVolume ;

              ColumnText.ShowTextAligned(stamper.GetOverContent(i),
                  Element.ALIGN_LEFT, new Phrase($"Ped. {txtPedido.Text} - Vol.{volume} - {descricaoVolume} ({qtd}X)", font), x, y, ang);
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

    private void BtnData_Click(object sender, EventArgs e) {
      txtData.Text = DateTime.Now.ToShortDateString();
    }

    private void BtnDescricao_Click(object sender, EventArgs e) {
      try {
        txtDescricao.Text = PackList.GetDenominacao();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar descrição\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
