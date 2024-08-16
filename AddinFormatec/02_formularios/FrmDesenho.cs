using System;
using System.Drawing;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.IO;
using LmCorbieUI;
using LmCorbieUI.LmForms;

namespace AddinFormatec {
  public partial class FrmDesenho : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    DrawingDoc swDraw = default(DrawingDoc);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);
    Feature swFeature;

    BindingSource dadosDesenho = new BindingSource();
    Desenho desenho = new Desenho();
    string montagemGeral = "";

    public FrmDesenho() {
      InitializeComponent();

      dadosDesenho.CurrentChanged += DadosDesenho_CurrentChanged;
    }

    private void DadosDesenho_CurrentChanged(object sender, EventArgs e) {
      try {
        if (dadosDesenho.Count > 0) {
          lblPercDesenho.Text =
              $"{(dadosDesenho.IndexOf(dadosDesenho.Current) + 1)} " +
              $"de {dadosDesenho.Count} - {(((dadosDesenho.IndexOf(dadosDesenho.Current) + 1) * 100) / dadosDesenho.Count)}%";
        }
      } catch (Exception) {
      }
    }

    private void FrmDesenho_Loaded(object sender, EventArgs e) {

    }

    private void BtnLoadDesenho_Click(object sender, EventArgs e) {
      MsgBox.ShowWaitMessage("Lendo componentes da montagem...");
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          Toast.Warning("Comando Apenas para Peça e Montagem");
          return;
        }

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          dadosDesenho.DataSource = Desenho.GetDesenhos(swApp);
          dgv.Grid.DataSource = dadosDesenho;
          dadosDesenho.MoveFirst();

          FormatarGrid();

          montagemGeral = swModel.GetPathName();

          Color clr = Color.FromArgb(192, 192, 255);

          foreach (Desenho des in dadosDesenho) {
            if (des.TemDesenho == "Não") {
              dgv.Grid.Rows[dadosDesenho.IndexOf(des)].Cells[1].Style.BackColor = clr;
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componentes\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void FormatarGrid() {
      dgv.Grid.Columns["Tipo3D"].Width = 30;
      dgv.Grid.Columns["TemDesenho"].Width = 30;
      dgv.Grid.Columns["ShortName"].Width = 80;
      dgv.Grid.Columns["Denominacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

      dgv.Grid.Columns["Tipo3D"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["Tipo3D"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["TemDesenho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["TemDesenho"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["ShortName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
      dgv.Grid.Columns["ShortName"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void BtnFFdesenho_Click(object sender, EventArgs e) {
      string fileNameDesenho = "";
      try {
        if (dadosDesenho.Count == 0) {
          Toast.Warning("Favor Carregar Componentes primeiro.");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        CloseDocs();

        if (((Desenho)dadosDesenho.Current).Tipo3D == "P")
          fileNameDesenho = ((Desenho)dadosDesenho.Current).PathName.ToUpper().Replace("SLDPRT", "SLDDRW");
        else if (((Desenho)dadosDesenho.Current).Tipo3D == "M")
          fileNameDesenho = ((Desenho)dadosDesenho.Current).PathName.ToUpper().Replace("SLDASM", "SLDDRW");

        int status = 0;
        int warnings = 0;
        swApp.OpenDoc6(((Desenho)dadosDesenho.Current).PathName,
            (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
        int errors = 0;
        swApp.ActivateDoc2(((Desenho)dadosDesenho.Current).PathName, false, (int)errors);

        if (File.Exists(fileNameDesenho)) {
          swApp.OpenDoc6(fileNameDesenho, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          errors = 0;
          swApp.ActivateDoc2(fileNameDesenho, false, (int)errors);
          swModel = (ModelDoc2)swApp.ActiveDoc;
          // atualizaListanoDesenho();
          AttachEventHandlers();
        } else {
          swModel = (ModelDoc2)swApp.ActiveDoc;

          swModel.ShowNamedView("*Isométrica");
          swModel.ViewZoomtofit();
        }
        dadosDesenho.MoveNext();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao avançar peça para desenho\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnA4R_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }

      swModel = (ModelDoc2)swApp.ActiveDoc;

      if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
        string sheet = FormatoFolha.model.TemplateA4P;
        double largura = 0.115;
        double altura = 0.14;
        AltFormato(sheet, largura, altura);

        sheet = FormatoFolha.model.TemplateA4R;
        largura = 0.21;
        altura = 0.297;
        AltFormato(sheet, largura, altura);
      } else {
        string formato = FormatoFolha.model.FormatoA4R;
        double X = 0.115;
        double Y = 0.14;
        NewDrawing(formato, X, Y);
      }
    }

    private void BtnA4_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }

      swModel = (ModelDoc2)swApp.ActiveDoc;

      if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
        string sheet = FormatoFolha.model.TemplateA3;
        double largura = 0.42;
        double altura = 0.297;
        AltFormato(sheet, largura, altura);

        sheet = FormatoFolha.model.TemplateA4P;
        largura = 0.115;
        altura = 0.14;
        AltFormato(sheet, largura, altura);
      } else {
        string formato = FormatoFolha.model.FormatoA4P;
        double X = 0.115;
        double Y = 0.14;
        NewDrawing(formato, X, Y);
      }
    }

    private void BtnA3_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }

      swModel = (ModelDoc2)swApp.ActiveDoc;

      if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
        string sheet = FormatoFolha.model.TemplateA2;
        double largura = 0.594;
        double altura = 0.42;
        AltFormato(sheet, largura, altura);

        sheet = FormatoFolha.model.TemplateA3;
        largura = 0.42;
        altura = 0.297;
        AltFormato(sheet, largura, altura);
      } else {
        string formato = FormatoFolha.model.FormatoA3;
        double X = 0.16;
        double Y = 0.15;
        NewDrawing(formato, X, Y);
      }
    }

    private void BtnA2_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }

      swModel = (ModelDoc2)swApp.ActiveDoc;

      if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
        string sheet = FormatoFolha.model.TemplateA1;
        double largura = 0.841;
        double altura = 0.594;
        AltFormato(sheet, largura, altura);

        sheet = FormatoFolha.model.TemplateA2;
        largura = 0.594;
        altura = 0.42;
        AltFormato(sheet, largura, altura);
      } else {
        string formato = FormatoFolha.model.FormatoA2;
        double X = 0.24;
        double Y = 0.21;
        NewDrawing(formato, X, Y);
      }
    }

    private void BtnA1_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }

      swModel = (ModelDoc2)swApp.ActiveDoc;

      if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
        string sheet = FormatoFolha.model.TemplateA2;
        double largura = 0.594;
        double altura = 0.42;
        AltFormato(sheet, largura, altura);

        sheet = FormatoFolha.model.TemplateA1;
        largura = 0.841;
        altura = 0.594;
        AltFormato(sheet, largura, altura);
      } else {
        string formato = FormatoFolha.model.FormatoA1;
        double X = 0.35;
        double Y = 0.3;
        NewDrawing(formato, X, Y);
      }
    }

    private void BtnInserirListaSoldagem_Click(object sender, EventArgs e) {
      if (swApp.ActiveDoc == null) {
        Toast.Warning("Sem documentos abertos");
        return;
      }
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;
        swModel.ClearSelection2(true);

        var str = swModel.GetPathName();

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          swFeature = (Feature)swModel.FirstFeature();

          while ((swFeature != null)) {
            string nm = swFeature.Name;
            if (swFeature.GetTypeName() == "WeldmentTableFeat" || swFeature.GetTypeName() == "BomFeat") {
              swFeature.Select(true);

              swModel.EditDelete();
            }
            swFeature = (Feature)swFeature.GetNextFeature();
          }

          if (File.Exists(swModel.GetPathName().ToLower().Replace("slddrw", "sldprt")))
            InserirListasMateriais(swDocumentTypes_e.swDocPART);
          else
            InserirListasMateriais(swDocumentTypes_e.swDocASSEMBLY);

          //bool boolstatus = swModel.Extension.SelectByID2("Tabela de revisão1", "DRAWINGVIEW", 0, 0, 0.0, false, 0, null, 0);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao inserir lista de soldagem\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void InserirListasMateriais(swDocumentTypes_e swDocumentTypes_E) {
      try {
        DrawingDoc swDraw = default(DrawingDoc);
        swDraw = (DrawingDoc)swApp.ActiveDoc;

        BomTableAnnotation swBOMAnnotation = default(BomTableAnnotation);
        WeldmentCutListAnnotation WMTable = default(WeldmentCutListAnnotation);

        SolidWorks.Interop.sldworks.View swView = (SolidWorks.Interop.sldworks.View)swDraw.GetFirstView();
        swView = (SolidWorks.Interop.sldworks.View)swView.GetNextView();
        swDraw.ActivateView(swView.GetName2());

        // Obtém a configuração ativa
        ModelDoc2 swModel = (ModelDoc2)swView.ReferencedDocument;
        string activeConfiguration = swModel.GetActiveConfiguration().Name;

        int AnchorType = (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomLeft;
        int BomType = (int)swBomType_e.swBomType_TopLevelOnly;

        if (swDocumentTypes_E == swDocumentTypes_e.swDocPART) {
          WMTable = swView.InsertWeldmentTable(true, 0, 0, AnchorType, activeConfiguration, Config.model.ListaPeca);
        } else {
          if (ckbPromov.Checked) {
            BomType = (int)swBomType_e.swBomType_Indented;
            int NumberingType = (int)swNumberingType_e.swNumberingType_Detailed;

            swBOMAnnotation = swView.InsertBomTable4(true, 0, 0, AnchorType, BomType, activeConfiguration, Config.model.ListaMontagem, false, NumberingType, true);

            object Names = swBOMAnnotation.BomFeature.GetConfigurations(false, Visible),
            boolstatus = swBOMAnnotation.BomFeature.SetConfigurations(true, true, Names);
            var swTableAnnotation = (TableAnnotation)swBOMAnnotation;

            int lStartRow = 1;

            if (!(swTableAnnotation.TitleVisible == false)) {
              lStartRow = 2;
            }

            var swBOMFeature = swBOMAnnotation.BomFeature;
            System.Collections.Generic.List<int> indiceExcluir = new System.Collections.Generic.List<int>();

            for (int i = lStartRow; i < swTableAnnotation.TotalRowCount; i++) {
              var componente = swTableAnnotation.get_Text(i, 2);

              if (string.IsNullOrEmpty(componente))
                indiceExcluir.Add(i);
            }

            foreach (var indx in indiceExcluir)
              swTableAnnotation.DeleteRow(Index: indx);
          } else {
            swBOMAnnotation = swView.InsertBomTable3(true, 0, 0, AnchorType, BomType, activeConfiguration, Config.model.ListaMontagem, false);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao inserir Lista\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CloseDocs() {
      try {
        int cont = 0;
        while (swModel != null && swModel.GetPathName() != montagemGeral && cont <= 10) {
          if (swModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING)
            swModel.ViewZoomtofit2();

          if (!swModel.IsOpenedReadOnly())
            swModel.Save();

          swApp.CloseDoc(swModel.GetPathName());
          swModel = (ModelDoc2)swApp.ActiveDoc;
          cont++;
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao fechar documentos\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void AltFormato(string formato, double largura, double altura) {
      bool boolstatus;

      DrawingDoc swDraw;
      swDraw = (DrawingDoc)swModel;
      swDraw = (DrawingDoc)swApp.ActiveDoc;
      Sheet swSheet = swDraw.GetCurrentSheet();
      double[] vSheetProps = swSheet.GetProperties();

      boolstatus = swDraw.SetupSheet5(swSheet.GetName(), 12, 12, vSheetProps[2], vSheetProps[3], true, formato, largura, altura, "'", true);

      BtnInserirListaSoldagem_Click(btnInserirListaSoldagem, new EventArgs());
    }

    private void NewDrawing(string DrawingName, double X, double Y) {
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
        //SolidWorks.Interop.sldworks.View swViewAlignWith;
        //ModelDocExtension swModelDocExtension;
        //SelectionMgr swSelectionMgr;

        WeldmentCutListAnnotation WMTable = default(WeldmentCutListAnnotation);
        BomTableAnnotation swBOMAnnotation = default(BomTableAnnotation);

        tipoArquivo = (swDocumentTypes_e)swModel.GetType();

        string fileName = swModel.GetPathName();
        AtiveConfiguration = (object[])swModel.GetConfigurationNames();
        string activeConfig = (string)AtiveConfiguration[0];

        // se desenho existir abra
        int comp = fileName.Length;
        string nomeDesenho = swModel.GetPathName().Substring(0, comp - 6) + "SLDDRW";
        if (File.Exists(nomeDesenho)) {
          int status = 0;
          int warnings = 0;
          //int errors = 0;
          swApp.OpenDoc6(nomeDesenho, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          // swApp.ActivateDoc2(nomeDesenho, false, (int)errors);
          return;
        }

        swDrawing = (DrawingDoc)swApp.NewDocument(DrawingName, 5, 0, 0);
        //swApp.ActivateDoc2("Pe123-000 - Folha1", false, ref longstatus);

        swModel = (ModelDoc2)swApp.ActiveDoc;
        swDrawing = (DrawingDoc)swModel;
        swModelDocExt = swModel.Extension;

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

                //swView = (SolidWorks.Interop.sldworks.View)swDrawing.ActiveDrawingView;

                //AnchorType = (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight;
                //BomType = (int)swBomType_e.swBomType_PartsOnly;

                //swBOMAnnotation = swView.InsertBomTable3(true, 0, 0, AnchorType, BomType, activeConfig, Configuracao.ListaMontagem, false);
                InserirListasMateriais(tipoArquivo);
                break;
              }
            }

            if (tipoArquivo == swDocumentTypes_e.swDocPART) {
              if ((viewPaletteName == "Padrão plano")) {
                // cria vista 1
                swView = swDrawing.DropDrawingViewFromPalette2(viewPaletteName, X, Y, 0.0);

                //// cria vista 2
                //boolstatus = swModel.Extension.SelectByID2("Tabela de revisão1", "DRAWINGVIEW", X, Y, 0.0, false, 0, null, 0);
                //swView = swDrawing.CreateUnfoldedViewAt3(X, Y + 0.11, 0, false);

                //// Alinha vista 2 verticalcentro com vista 1
                //boolstatus = swDrawing.ActivateView("Vista de desenho2");
                //swView = (SolidWorks.Interop.sldworks.View)swDrawing.ActiveDrawingView;
                //swModelDocExtension = swModel.Extension;

                //boolstatus = swModelDocExtension.SelectByID2("Vista de desenho1", "DRAWINGVIEW", X, Y, 0, false, 0, null, 0);
                //swSelectionMgr = (SelectionMgr)swModel.SelectionManager;
                //swViewAlignWith = (SolidWorks.Interop.sldworks.View)swSelectionMgr.GetSelectedObject6(1, -1);
                //boolstatus = swView.AlignWithView((int)swAlignViewTypes_e.swAlignViewVerticalCenter, swViewAlignWith);

                //// cria vista 3
                //boolstatus = swModel.Extension.SelectByID2("Vista de desenho1", "DRAWINGVIEW", X, Y, 0.0, false, 0, null, 0);
                //swView = swDrawing.CreateUnfoldedViewAt3(X + 0.11, Y, 0, false);

                //// Alinha vista 3 horizontalcentro com vista 1
                //boolstatus = swDrawing.ActivateView("Vista de desenho3");
                //swView = (SolidWorks.Interop.sldworks.View)swDrawing.ActiveDrawingView;
                //swModelDocExtension = swModel.Extension;

                //boolstatus = swModelDocExtension.SelectByID2("Vista de desenho1", "DRAWINGVIEW", X, Y, 0, false, 0, null, 0);
                //swSelectionMgr = (SelectionMgr)swModel.SelectionManager;
                //swViewAlignWith = (SolidWorks.Interop.sldworks.View)swSelectionMgr.GetSelectedObject6(1, -1);
                //boolstatus = swView.AlignWithView((int)swAlignViewTypes_e.swAlignViewHorizontalCenter, swViewAlignWith);

              }
              if ((viewPaletteName == "*Isométrica")) {
                // cria vista 4
                swView = swDrawing.DropDrawingViewFromPalette2(viewPaletteName, X + 0.06, Y - 0.05, 0.0);
                boolstatus = swModel.Extension.SelectByID2("Vista de desenho4", "DRAWINGVIEW", X + 0.06, Y - 0.05, 0.0, false, 0, null, 0);
                //WMTable = swView.InsertWeldmentTable(true, 0, 0, (int)swBOMConfigurationAnchorType_e.swBOMConfigurationAnchor_BottomRight, activeConfig, Configuracao.ListaSoldagem);

                // addCotasBlank();
                InserirListasMateriais(tipoArquivo);
                break;
              }
            }
          }

        }

        if (dadosDesenho.Count > 0) {
          ((Desenho)dadosDesenho[dadosDesenho.IndexOf((Desenho)dadosDesenho.Current) - 1]).TemDesenho = "Sim";
          dgv.Grid.Rows[dadosDesenho.IndexOf((Desenho)dadosDesenho.Current) - 1].Cells[1].Style.BackColor = Color.White;
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao criar novo desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void Open3D() {
      try {
        string openFileName = "";
        int status = 0;
        int warnings = 0;
        openFileName = ((Desenho)dadosDesenho.Current).PathName;

        if (((Desenho)dadosDesenho.Current).Tipo3D == "P") {
          swApp.OpenDoc6(openFileName, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileName, false, (int)errors);
        } else {
          swApp.OpenDoc6(openFileName, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileName, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir arquivo\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TsmOpen3D_Click(object sender, EventArgs e) {
      Open3D();
    }

    private void TsmOpen2D_Click(object sender, EventArgs e) {
      try {
        string openFileName = "";
        int status = 0;
        int warnings = 0;

        if (((Desenho)dadosDesenho.Current).Tipo3D == "P") {
          openFileName = ((Desenho)dadosDesenho.Current).PathName.Replace("SLDPRT", "SLDDRW");
          swApp.OpenDoc6(openFileName, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileName, false, (int)errors);
        } else {
          openFileName = ((Desenho)dadosDesenho.Current).PathName.Replace("SLDASM", "SLDDRW");
          swApp.OpenDoc6(openFileName, (int)swDocumentTypes_e.swDocDRAWING, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);
          int errors = 0;
          swApp.ActivateDoc2(openFileName, false, (int)errors);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao abrir desenho\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TsmAttCodigo_Click(object sender, EventArgs e) {
      Open3D();

      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING)
          return;

        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        swCustPropMngr.Add3("CÓDIGO PROJETO", (int)swCustomInfoType_e.swCustomInfoText, ((Desenho)dadosDesenho.Current).ShortName,
            (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        swModel.Save();
        swApp.CloseDoc(swModel.GetPathName());

        Color clr = Color.White;

        dgv.Grid.CurrentRow.Cells[0].Style.BackColor = clr;
        dgv.Grid.CurrentRow.Cells[1].Style.BackColor = clr;
        dgv.Grid.CurrentRow.Cells[2].Style.BackColor = clr;
        dgv.Grid.CurrentRow.Cells[3].Style.BackColor = clr;
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao atualizar código\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnDownDes_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;
        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          swDraw = (DrawingDoc)swModel;
          swDraw = (DrawingDoc)swApp.ActiveDoc;
          swDraw.SheetPrevious();
          AttachEventHandlers();
        }

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mudar Folha para anterior\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnUpDes_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;
        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          swDraw = (DrawingDoc)swModel;
          swDraw = (DrawingDoc)swApp.ActiveDoc;
          swDraw.SheetNext();
          AttachEventHandlers();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao mudar folha para posterior\n\n{ex.Message}",
            "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnRename_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;
        DrawingDoc swDraw;
        swDraw = (DrawingDoc)swModel;
        swDraw = (DrawingDoc)swApp.ActiveDoc;
        Sheet swSheet = swDraw.GetCurrentSheet();
        if (!string.IsNullOrEmpty(txtName.Text))
          swSheet.SetName(txtName.Text);

        swModel.Rebuild(0);
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Renomear Folha\n\n{ex.Message}",
            "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public void AttachEventHandlers() {
      swModel = (ModelDoc2)swApp.ActiveDoc;
      swDraw = (DrawingDoc)swModel;
      Sheet swSheet = swDraw.GetCurrentSheet();
      AttachSWEvents();
      bool status = swDraw.ActivateSheet(swSheet.GetName());
      txtName.Text = swSheet.GetName();
    }

    public void AttachSWEvents() {
      swDraw.ActivateSheetPostNotify += this.SwDraw_ActivateSheetPostNotify;
    }

    private int SwDraw_ActivateSheetPostNotify(string SheetName) {
      GetSheetName();
      return 1;
    }

    private void GetSheetName() {
      try {
        swDraw = (DrawingDoc)swModel;
        swDraw = (DrawingDoc)swApp.ActiveDoc;
        Sheet swSheet = swDraw.GetCurrentSheet();
        txtName.Text = string.Empty;
        txtName.Text = swSheet.GetName();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Retornar Nome Folha\n\n{ex.Message}",
            "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

  }
}
