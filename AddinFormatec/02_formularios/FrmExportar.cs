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
using LmCorbieUI.LmForms;
using LmCorbieUI;
using LmCorbieUI.Metodos;

namespace AddinFormatec {
  public partial class FrmExportar : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    List<DrawExport> _dadosDraw = new List<DrawExport>();
    List<DrawExport> _listaPecas = new List<DrawExport>();

    string _pastaPdf = "";
    string _pastaProjeto = "";

    bool _imprimindo = false;

    public FrmExportar() {
      InitializeComponent();

      _dadosDraw = new List<DrawExport>();

      dgv.Grid.DataSource = _dadosDraw;

      FormatarGrid();
    }

    private void BtnLista_Click(object sender, EventArgs e) {
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;
        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        //_pastaProjeto = Path.GetDirectoryName(swModel.GetPathName());

        CarregarPastaPDFs();

        string nomeListaPecas = $@"{_pastaPdf}LISTA DE PECAS.PDF";

        if (swApp.ActiveDoc == null) {
          MsgBox.Show("Sem Documentos Abertos.");
          return;
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART || swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          MsgBox.Show("Comando Apenas para Montagem.");
          return;
        }

        _listaPecas = DrawExport.GeListPart(_listaPecas, swModel, swModelDocExt, swCustPropMngr);

        List<BindingSource> lista = new List<BindingSource>()
            {
              new BindingSource{DataSource = _listaPecas },
            };

        List<string> nomeDS = new List<string>()
            {
              "ListaPecasDS"
            };

        List<ReportParameter> parameters = new List<ReportParameter>();

        var agora = DateTime.Now;
        ReportParameter prtRodape =
            new ReportParameter("parDescricaoRodape", $"Relatório gerado em " +
            $"{agora.ToShortDateString()} as {agora.ToShortTimeString()}", true);

        parameters.Add(prtRodape);

        string reportListaMateriais = "AddinFormatec.Relatorios.rptListaMateriais.rdlc";

        FrmRelatorio frmCapa = new FrmRelatorio(lista, nomeDS, reportListaMateriais, parameters, true);

        if (!Controles.ArquivoEstaAberto(nomeListaPecas)) {
          File.WriteAllBytes(nomeListaPecas, frmCapa.bytesPDF);
        } else {
          Toast.Warning("\"Arquivo PDF já está aberto.\\n\\n\\\"{nomeListaPecas}\\\"\"");
        }

        if (MsgBox.Show("Lista de Peças criada com sucesso!\r\nDeseja Abri-la?",
            "Sucesso", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {

          Process.Start(nomeListaPecas);
        }
      } catch (Exception ex) {
        MsgBox.Show("Erro ao gerar Lista Materiais.\n" + ex.Message, "Erro ao Gerar Lista de Peças", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnRefresh_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        MsgBox.ShowWaitMessage("Lendo componentes da montagem...");

        swModel = (ModelDoc2)swApp.ActiveDoc;

        _pastaProjeto = Path.GetDirectoryName(swModel.GetPathName());

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          Toast.Warning("Comando Apenas para Montagem");
          return;
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          _dadosDraw = DrawExport.GetDrawing();

          dgv.Grid.DataSource = _dadosDraw;

          FormatarGrid();

          string pathName = swModel.GetPathName();
          string shortName = Path.GetFileNameWithoutExtension(pathName);

          CarregarPastaPDFs();

          if (!Directory.Exists(_pastaPdf))
            Directory.CreateDirectory(_pastaPdf);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar desenhos\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      if (_dadosDraw.Count == 0) return;
      try {
        if (!Directory.Exists(_pastaPdf)) {
          Directory.CreateDirectory(_pastaPdf);
        } else {
          //string[] files = Directory.GetFiles(_pastaPdf);
          //ExcluirObsoleto(files);
        }

        _imprimindo = true;
        btnCancelar.Enabled = true;

        btnLista.Enabled =
        btnRefresh.Enabled =
        btnSalvar.Enabled =
        btnSair.Enabled = false;

        tmrExportar.Enabled = true;
        //}
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao exportar arquivos\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnCancelar_Click(object sender, EventArgs e) {
      btnCancelar.Enabled = false;

      btnLista.Enabled =
      btnRefresh.Enabled =
      btnSalvar.Enabled =
      btnSair.Enabled = true;

      _imprimindo = false;
    }

    private void BtnSair_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Dgv_CellEnter(object sender, DataGridViewCellEventArgs e) {
      try {
        if (sender != null && _dadosDraw.Count > 0) {
          lblPercDesenho.Text = $"{(dgv.Grid.CurrentRow.Index + 1)} de {dgv.Grid.RowCount} - " +
              $"{(((dgv.Grid.CurrentRow.Index + 1) * 100) / dgv.Grid.RowCount)}%";
        }
      } catch (Exception) {

      }
    }

    private void FormatarGrid() {      
      dgv.Grid.Columns["IndexTree"].Visible = false;
      dgv.Grid.Columns["Exportar"].Width = 30;
      dgv.Grid.Columns["Denominacao"].Width = 250;

      dgv.Grid.Columns["Exportar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["Exportar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

      dgv.Grid.ReadOnly = false;
      dgv.Grid.Columns["Denominacao"].ReadOnly = true;
      dgv.Grid.Columns["NomeComponente"].ReadOnly = true;
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

        if (_imprimindo == false) {
          Toast.Info("Impressão Cancelada!");
        } else if (index == _dadosDraw.Count() - 1) {
          _imprimindo = false;
          btnCancelar.Enabled = false;

          btnLista.Enabled =
          btnRefresh.Enabled =
          btnSalvar.Enabled =
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

    /*
    private void NewDrawing(string nomeDesenho, double X, double Y)
    {
        try
        {
            int numViews;
            object[] viewNames;
            object[] AtiveConfiguration = null;
            string viewPaletteName;
            int i;
            bool boolstatus;

            DrawingDoc swDrawing;
            SolidWorks.Interop.sldworks.View swView;

            string fileName = swModel.GetPathName();
            AtiveConfiguration = (object[])swModel.GetConfigurationNames();
            string activeConfig = (string)AtiveConfiguration[0];

            // se desenho existir abra
            int comp = fileName.Length;

            if (File.Exists(nomeDesenho))
            {
                int status = 0;
                int warnings = 0;
                //int errors = 0;
                swApp.OpenDoc6(nomeDesenho, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
                // swApp.ActivateDoc2(nomeDesenho, false, (int)errors);
                return;
            }

            swDrawing = (DrawingDoc)swApp.NewDocument(Configuracao.FormatoA3, 5, 0, 0);
            //swApp.ActivateDoc2("Pe123-000 - Folha1", false, ref longstatus);

            swModel = (ModelDoc2)swApp.ActiveDoc;
            swDrawing = (DrawingDoc)swModel;
            var swModelDocExt = swModel.Extension;

            swModel.SaveAs(nomeDesenho);

            swDrawing.GenerateViewPaletteViews(fileName);
            numViews = 0;
            viewNames = (object[])swDrawing.GetDrawingPaletteViewNames();

            if (!(viewNames == null))
            {
                numViews = (viewNames.GetUpperBound(0) - viewNames.GetLowerBound(0));
                for (i = 0; i <= numViews; i++)
                {
                    viewPaletteName = (string)viewNames[i];

                    if ((viewPaletteName == "*Isométrica"))
                    {
                        int BomType;
                        int AnchorType;

                        swModel = (ModelDoc2)swApp.ActiveDoc;
                        swDrawing = (DrawingDoc)swModel;
                        swDrawing = (DrawingDoc)swApp.ActiveDoc;


                        swView = swDrawing.DropDrawingViewFromPalette2(viewPaletteName, X, Y, 0.0);

                        boolstatus = swDrawing.ActivateSheet("Folha1");
                        boolstatus = swDrawing.ActivateView("Vista de desenho1");

                        break;
                    }
                }

            }

        }
        catch (Exception ex)
        {
            MsgBox.Show($"Erro ao criar novo desenho\n\n{ex.Message}", "Addin LM Projetos",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    */

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
        else
          Toast.Warning($"Arquivo: \"{fileName}\"\nEstá em Uso.\nNão Será Atualizado.");
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
  }
}
