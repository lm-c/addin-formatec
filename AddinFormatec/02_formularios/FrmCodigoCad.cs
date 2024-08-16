using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Controls;
using LmCorbieUI.Metodos;
using System.IO;

namespace AddinFormatec {
  public partial class FrmCodigoCad : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string _montagemPrincipal = string.Empty;
    int _posAtualItemCorte = 0;
    Componente _componente = new Componente();
    SortableBindingList<W_Componente> _componentes = new SortableBindingList<W_Componente>();

    public FrmCodigoCad() {
      InitializeComponent();

      _componentes = new SortableBindingList<W_Componente>();

      dgv.MontarGrid<W_Componente>();
    }

    private void FrmCodigoCad_Loaded(object sender, EventArgs e) {
      Invoke(new MethodInvoker(delegate () {
        InfoSetting.Carregar();
        txtSigla.Text = InfoSetting.UltimaSiglaUsada;
      }));
    }
    
    private void BtnCarrProcess_Click(object sender, EventArgs e) {
      MsgBox.ShowWaitMessage("Lendo componentes da montagem...");
      try {
        if (swApp.ActiveDoc == null) { Toast.Warning("Sem documentos abertos");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel.GetType() != (int)swDocumentTypes_e.swDocDRAWING) {
          _componentes = new SortableBindingList<W_Componente>();
          dgv.Grid.DataSource = _componentes;

          _montagemPrincipal = swModel.GetPathName().ToLower();

          _componentes = W_Componente.GetComponents();
          dgv.CarregarGrid(_componentes);
        } else {
          Toast.Warning("Comando apenas para Peças e Montagens.");
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Carregar Componentes..\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos.");
          return;
        }

        if (_componentes.Count == 0)
          swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          Toast.Warning("Comando apenas para Peças e Montagens.");
          return;
        }

        if (string.IsNullOrEmpty(txtSigla.Text)) {
          Toast.Warning("Favor informar sigla para gerar novo código.");
          return;
        }

        MsgBox.ShowWaitMessage("Gerando Código. Aguarde...");

        // Salvar Como
        SalvarComo();

        _componente.denominacao = txtDescricao.Text;
        AdicionarDescricaoTodasConfiguracoes();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao salvar..\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnVoltar_Click(object sender, EventArgs e) {
      try {
        if (_componentes.Count == 0) {
          Toast.Warning("Favor Carregar Componentes primeiro.");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (dgv.Grid.CurrentRow.Index > 0)
          dgv.Grid.Rows[dgv.Grid.CurrentRow.Index - 1].Cells[1].Selected = true;
        else
          dgv.Grid.Rows[dgv.Grid.RowCount - 1].Cells[1].Selected = true;
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao voltar peça\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnProximo_Click(object sender, EventArgs e) {
      try {
        if (_componentes.Count == 0) {
          Toast.Warning("Favor Carregar Componentes primeiro.");
          return;
        }

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (dgv.Grid.CurrentRow.Index + 1 < dgv.Grid.RowCount)
          dgv.Grid.Rows[dgv.Grid.CurrentRow.Index + 1].Cells[1].Selected = true;
        else
          dgv.Grid.Rows[0].Cells[1].Selected = true;
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao avançar peça\n\n{ex.Message}", "Addin LM Projetos",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void Dgv_RowIndexChanged(object sender, EventArgs e) {
      try {
        if (sender == null) return;

        lblPecasProc.Text = $"Item {dgv.Grid.CurrentRow.Index + 1} de {dgv.Grid.RowCount} - {(((dgv.Grid.CurrentRow.Index + 1) * 100) / dgv.Grid.RowCount)}%";

        swModel = (ModelDoc2)swApp.ActiveDoc;

        if (swModel != null && swModel.GetPathName().ToLower() != _montagemPrincipal) {
          swModel.ShowNamedView("*Isométrica");
          swModel.ViewZoomtofit();

          swModel.Save();
          swApp.CloseDoc(swModel.GetPathName());
        }

        AtualizarComponente();
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao atualizar dados Componente");
      }
    }

    private void SalvarComo() {
      try {
        string PartAtual;
        string DrawingAtual;
        MsgBox.CloseWaitMessage();

        PartAtual = swModel.GetPathName().ToUpper();

        var novoCodigo = CodigoMaquina.GerarCodigo(txtSigla.Text.Trim(), txtDescricao.Text.Trim(), (swDocumentTypes_e)swModel.GetType());

        if (string.IsNullOrEmpty(novoCodigo))
          return;

        SaveFileDialog sfd = new SaveFileDialog {
          AddExtension = true,
          InitialDirectory = Path.GetDirectoryName(PartAtual),
          Title = "Salvar Como",
          FileName = novoCodigo
        };

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART) {
          sfd.Filter = "Peça (*.sldprt) | *.sldprt";
          DrawingAtual = PartAtual.Replace(".SLDPRT", ".SLDDRW");
        } else {
          sfd.Filter = "Montagem (*.sldasm) | *.sldasm";
          DrawingAtual = PartAtual.Replace(".SLDASM", ".SLDDRW");
        }

        if (sfd.ShowDialog() == DialogResult.OK) {
          MsgBox.ShowWaitMessage("Salvando Aguarde..");

          if (!string.IsNullOrEmpty(sfd.FileName)) {
            string drawingNew;
            string partNew = sfd.FileName.ToUpper();

            if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART)
              drawingNew = partNew.Replace(".SLDPRT", ".SLDDRW");
            else
              drawingNew = partNew.Replace(".SLDASM", ".SLDDRW");

            int status = 0;
            int warnings = 0;

            if (File.Exists(DrawingAtual)) {
              swApp.OpenDoc6(DrawingAtual, (int)swDocumentTypes_e.swDocDRAWING,
                  (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref status, ref warnings);

              swApp.ActivateDoc2(DrawingAtual, false, 0);

              swApp.ActivateDoc2(PartAtual, false, 0);
              swModel = (ModelDoc2)swApp.ActiveDoc;
              swModel.SaveAs(partNew);

              swApp.ActivateDoc2(DrawingAtual, false, 0);
              swModel = (ModelDoc2)swApp.ActiveDoc;
              swModel.SaveAs(drawingNew);

              swApp.CloseDoc(drawingNew);
            } else swModel.SaveAs(partNew);

            _componente.long_name = partNew;
            _componente.short_name = Path.GetFileNameWithoutExtension(partNew);
            _componente.denominacao = txtDescricao.Text;

            var w_componente = dgv.Grid.CurrentRow.DataBoundItem as W_Componente;
            w_componente.PathName = _componente.long_name;
            w_componente.NomeComponente = _componente.short_name;
            w_componente.Denominacao = _componente.denominacao;

            dgv.Refresh();

            if (MsgBox.Show("Deseja Eliminar Antigo e Manter Somente Novo?", "Excluir",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
              File.Delete(PartAtual);
              if (File.Exists(DrawingAtual))
                File.Delete(DrawingAtual);
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao salvar cópia do componente\n\n{ex.Message}", "Addin LM Projetos",
              MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void AtualizarComponente() {
      try {
        var w_componente = dgv.Grid.CurrentRow.DataBoundItem as W_Componente;
        _componente = new Componente();
        _posAtualItemCorte = 0;

        if (w_componente.PathName.ToUpper().EndsWith(".SLDPRT"))
          swApp.OpenDoc6(w_componente.PathName, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
        else
          swApp.OpenDoc6(w_componente.PathName, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);

        swModel = (ModelDoc2)swApp.ActivateDoc2(Name: w_componente.PathName, Silent: false, Errors: 0);
        if (swModel == null)
          return;

        swModel.ClearSelection2(true);

        _componente = Componente.GetComponente(swModel);
        txtDescricao.Text = _componente.denominacao;
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Atualizar Dados\n\n{ex.Message}", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TxtDenominacao_Leave(object sender, EventArgs e) {
    }

    private void CkbAddDenom_CheckedChanged(object sender, EventArgs e) {
      try {
        InfoSetting.AddDenominacaoTodasConfig = ckbAddDenom.Checked;
        InfoSetting.Salvar();
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro");
      }
    }

    private void TxtSigla_Leave(object sender, EventArgs e) {
      try {
        InfoSetting.UltimaSiglaUsada = txtSigla.Text;
        InfoSetting.Salvar();
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro");
      }
    }

    private void AdicionarDescricaoTodasConfiguracoes() {
      try {
        Configuration swConfig = default(Configuration);
        ConfigurationManager swConfMgr = default(ConfigurationManager);

        object[] configNameArr = null;
        string configName = null;
        bool status = false;
        int i = 0;
        int h = 0;

        swModel = (ModelDoc2)swApp.ActiveDoc;
        swConfMgr = swModel.ConfigurationManager;
        swModelDocExt = swModel.Extension;
        configNameArr = (object[])swModel.GetConfigurationNames();

        string filename = swModel.GetPathName();

        configName = swConfMgr.ActiveConfiguration.Name;
        string defConfig = configName;

        if (ckbAddDenom.Checked) {
          for (i = 0; i <= configNameArr.GetUpperBound(0); i++) {
            configName = (string)configNameArr[i];
            swConfig = (Configuration)swModel.GetConfigurationByName(configName);
            status = swModel.ShowConfiguration2(configName);

            swModelDocExt = swModel.Extension;
            swCustPropMngr = swModelDocExt.get_CustomPropertyManager(configName);

            swCustPropMngr.Add3("sgl_DescricaoEspecifica", (int)swCustomInfoType_e.swCustomInfoText, _componente.denominacao, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

          }
        } else {
          swModelDocExt = swModel.Extension;
          swCustPropMngr = swModelDocExt.get_CustomPropertyManager(defConfig);

          swCustPropMngr.Add3("sgl_DescricaoEspecifica", (int)swCustomInfoType_e.swCustomInfoText, _componente.denominacao, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        }
        status = swModel.ShowConfiguration2(defConfig);
      } catch (Exception ex) {
        MessageBox.Show("Falha ao Atualizar Denominação: \n" + ex.Message);
      }
    }

  }
}
