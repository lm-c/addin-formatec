using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.IO;
using LmCorbieUI;
using LmCorbieUI.LmForms;

namespace AddinFormatec {
  public partial class FrmFileProperties : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string pastaProjeto = "";
    string nameShort = "";
    List<string> lista = new List<string>();

    public FrmFileProperties() {
      InitializeComponent();
    }

    private void FrmFileProperties_Load(object sender, EventArgs e) {
    }

    private void FrmFileProperties_Loaded(object sender, EventArgs e) {

    }

    private void BtnCarregar_Click(object sender, EventArgs e) {
      //  MsgBox.ShowWaitMessage("Inserindo Propriedades Personalizadas...");
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        BomTableAnnotation swBOMAnnotation = default(BomTableAnnotation);

        swModel = (ModelDoc2)swApp.ActiveDoc;
        object[] AtiveConfiguration = null;
        string valOut;
        string resolvedValOut;
        double[] massProp;

        swModelDocExt = swModel.Extension;

        swModel.Rebuild((int)swRebuildOptions_e.swRebuildAll);
        //swModel.Rebuild((int)swRebuildOptions_e.swForceRebuildAll);

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        ConfigurationManager swConfMgr;
        Configuration swConf;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        AtiveConfiguration = (object[])swModel.GetConfigurationNames();


        swCustPropMngr.Get2("sgl_NomeConjuto", out valOut, out resolvedValOut);
        txtConjunto.Text = resolvedValOut;

        swCustPropMngr.Get2("slg_DescricaoConjunto", out valOut, out resolvedValOut);
        txtDescricao.Text = resolvedValOut;

        swCustPropMngr.Get2("sgl_Projetista", out valOut, out resolvedValOut);
        txtProjetista.Text = resolvedValOut;

        dtpDataDesenho.Text = DateTime.Now.ToShortDateString();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao atualizar componentes\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      MsgBox.ShowWaitMessage("Inserindo Propriedades Personalizadas...");
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        string pathName = swModel.GetPathName();

        pastaProjeto = Path.GetDirectoryName(pathName);

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          AddPropriedades(true);

          AtualizarPropriedades();
          lista.Clear();

          if (rdbPasta.Checked) Toast.Info($"Os componentes que estão na pasta\n\n{pastaProjeto}\n\nForam Atualizados com Sucesso.");
          else if (rdbNome.Checked)
            Toast.Success($"Os componentes que o nome começa com\n\n{txtNome.Text}\n\nForam Atualizados com Sucesso.");
        } else if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART) {
          AddPropriedades();
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao atualizar componentes\n\n{ex.Message}", "Addin LM Projetos",
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void AtualizarPropriedades() {
      try {
        swModel = (ModelDoc2)swApp.ActiveDoc;

        ConfigurationManager swConfMgr;
        Configuration swConf;
        Component2 swRootComp;

        swConfMgr = swModel.ConfigurationManager;
        swConf = swConfMgr.ActiveConfiguration;
        swRootComp = swConf.GetRootComponent3(true);

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          TraverseComponent(swRootComp, 1);
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao atualizar propriedades\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TraverseComponent(Component2 swComp, long nLevel) {
      try {
        object[] vChildComp;

        Component2 swChildComp;

        vChildComp = (object[])swComp.GetChildren();

        for (int i = 0; i < vChildComp.Length; i++) {
          swChildComp = (Component2)vChildComp[i];
          bool supress = swChildComp.IsSuppressed();
          bool exclude = swChildComp.ExcludeFromBOM;
          string refConfig = swChildComp.ReferencedConfiguration;

          swModel = swChildComp.GetModelDoc2();
          if (swModel == null) continue;

          string pathName = swModel.GetPathName();

          nameShort = Path.GetFileNameWithoutExtension(pathName);

          bool readOnly = swModel.IsOpenedReadOnly();

          if (supress == false && exclude == false /*&& !pathName.Contains(@"PROJETOS\COMPRADOS\ELEMENTOS DE FIXACAO")*/) {
            bool canAdd = true;

            foreach (string s in lista) {
              if (s == nameShort) {
                canAdd = false;
                break;
              }
            }

            if (canAdd == true) {
              //pathName = DadosArtama.ChangePathName(pathName);

              if (rdbPasta.Checked && pathName.Contains(pastaProjeto)) {
                AddPropriedades();
                lista.Add(nameShort);
              } else if (rdbNome.Checked && nameShort.StartsWith(txtNome.Text.Trim())) {
                AddPropriedades();
                lista.Add(nameShort);
              }
            }

            TraverseComponent(swChildComp, nLevel + 1);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao carregar componente [{nameShort}]\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void AddPropriedades(bool ehMontagemPrincipal = false) {
      try {
        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");

        swCustPropMngr.Add3("sgl_NomeConjuto", (int)swCustomInfoType_e.swCustomInfoText, txtConjunto.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("slg_DescricaoConjunto", (int)swCustomInfoType_e.swCustomInfoText, txtDescricao.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("sgl_Projetista", (int)swCustomInfoType_e.swCustomInfoText, txtProjetista.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        //swCustPropMngr.Add3("Data", (int)swCustomInfoType_e.swCustomInfoDate, dtpDataDesenho.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        //if (ehMontagemPrincipal)
        //    swCustPropMngr.Add3("CÓDIGO PROJETO", (int)swCustomInfoType_e.swCustomInfoText, txtCodigo.Text, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        swModel.Save();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao adicionar propriedade\n\n{ex.Message}", "Addin LM Projetos",
           MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TxtConjunto_TextChanged(object sender, EventArgs e) {
    }
  }
}
