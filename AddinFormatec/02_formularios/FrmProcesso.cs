using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System.IO;
using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Controls;
using LmCorbieUI.Metodos;
using System.Diagnostics;

namespace AddinFormatec {
  public partial class FrmProcesso : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string _montagemPrincipal = string.Empty;
    int _posAtualItemCorte = 0;
    Componente _componente = new Componente();
    SortableBindingList<W_Componente> _componentes = new SortableBindingList<W_Componente>();

    public FrmProcesso() {
      InitializeComponent();

      tbcOperacoes.SelectedIndex = 0;

      lblListaCorte.Text = "Nome Lista Corte - 0 de 0";
      lblPeso.Text = "0,000Kg";
      lblEspess.Text = "";
      lblDescMatPrima.Text = "";
      lblMaterial.Text = "";
      lblOperacoes.Text = "";

      _componentes = new SortableBindingList<W_Componente>();

      dgv.MontarGrid<W_Componente>();

      CarregarControlesProcessos();
    }

    private void FrmProcesso_Loaded(object sender, EventArgs e) {
      Invoke(new MethodInvoker(delegate () {
        InfoSetting.Carregar();
        ckbAddDenom.Checked = InfoSetting.AddDenominacaoTodasConfig;
      }));
    }

    private void CarregarControlesProcessos() {
      try {
        var _processos = vw_operacao.GetProcessos();

        foreach (var proc in _processos) {
          LmCheckBox ckb = new LmCheckBox {
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.Transparent,
            Size = new Size(flpOperacoes.Width - 30, 19),
            Margin = new Padding(6, 1, 6, 1),
            Name = $"ckb{proc.codigo_operacao}",
            Tag = $"{proc.codigo_operacao}",
            Text = $"{proc.codigo_operacao} - {proc.descricao_oepracao}",
            FontSize = LmCorbieUI.Design.LmCheckBoxSize.Small,
            UseCustomBackColor = true,
          };

          ckb.CheckedChanged += Ckb_CheckedChanged;

          flpOperacoes.Controls.Add(ckb);
        }

      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Carregar Controles Processos..\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnCarrProcess_Click(object sender, EventArgs e) {
      MsgBox.ShowWaitMessage("Lendo componentes da montagem...");
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
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
          Toast.Warning("Comando apenas para Peças e Montagens");
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
          Toast.Warning("Sem documentos abertos");
          return;
        }

        MsgBox.ShowWaitMessage("Salvando. Aguarde...");

        _componente.denominacao = txtDescricao.Text;

        AdicionarDescricaoTodasConfiguracoes();

        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        var descOp = vw_operacao.GetProcessosDescricoes(lblOperacoes.Text);
        swCustPropMngr.Add3("sgl_DescricaoProcessos", (int)swCustomInfoType_e.swCustomInfoText, descOp, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        swCustPropMngr.Add3("Massa", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Mass\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocPART) {
          swCustPropMngr.Add3("Material", (int)swCustomInfoType_e.swCustomInfoText, "\"SW-Material\"", (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        } else
          swCustPropMngr.Delete("Material");

        if (_componente.itens_corte.Count > 0) {
          if (txtMateriaPrima.SelectedValue != null) {
            PartDoc swPart = default;
            swPart = (PartDoc)swModel;
            var idMat = (int)txtMateriaPrima.SelectedValue;

            var mat = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == idMat);
            swPart.SetMaterialPropertyName2(_componente.config_name, Config.model.LocalBaseDadosMat, mat.MaterialDesc);
          }

          if (!string.IsNullOrEmpty(txtMateriaPrima.Text)) {
            _componente.itens_corte[_posAtualItemCorte].descricao_material = txtMateriaPrima.Text;
            _componente.itens_corte[_posAtualItemCorte].codigo_material = ((MateriaPrima)txtMateriaPrima.SelectedItem).ChapaID;

            lblDescMatPrima.Text = _componente.itens_corte[_posAtualItemCorte].descricao_material;
          }

          _componente.itens_corte[_posAtualItemCorte].operacao = lblOperacoes.Text;
          ListaCorte.UpdateCutList(swModel, _componente.itens_corte[_posAtualItemCorte]);
        } else {
          _componente.operacao = lblOperacoes.Text;
          swCustPropMngr.Add3("sgl_operacao", (int)swCustomInfoType_e.swCustomInfoText, _componente.operacao, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        }

        swModel.Save();

        lblMaterial.UseCustomColor =
        lblDescMatPrima.UseCustomColor =
        lblOperacoes.UseCustomColor = false;
        pnlDados.Refresh();
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

    private void AtualizarComponente() {
      try {
        lblListaCorte.Text = "Nome Lista Corte - 0 de 0";
        lblPeso.Text = "0,000Kg";
        lblEspess.Text = "";
        lblDescMatPrima.Text = "";
        lblMaterial.Text = "";
        lblOperacoes.Text = "";

        txtMateriaPrima.CarregarComboBox(new List<MateriaPrima>());
        txtMateriaPrima.Text = string.Empty;
        ClearCheckBox();
        txtMateriaPrima.Text = string.Empty;
        lblDescMatPrima.UseCustomColor =
        lblMaterial.UseCustomColor = false;
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

        AtualizarInformacoes();
        GetProcess();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Atualizar Dados\n\n{ex.Message}", "Addin LM Projetos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void BtnUpDown_Click(object sender, EventArgs e) {
      try {
        if (swApp.ActiveDoc == null) {
          Toast.Warning("Sem documentos abertos");
          return;
        }

        if (swModel.GetType() != (int)swDocumentTypes_e.swDocPART || _componente.itens_corte.Count == 0)
          return;

        if (_componente.itens_corte.Count > 0) {
          if (((Button)sender).Tag.ToString() == "Up")
            _posAtualItemCorte = _posAtualItemCorte < _componente.itens_corte.Count - 1 ? _posAtualItemCorte + 1 : 0;
          if (((Button)sender).Tag.ToString() == "Down")
            _posAtualItemCorte = _posAtualItemCorte > 0 ? _posAtualItemCorte - 1 : _componente.itens_corte.Count - 1;
        }

        AtualizarInformacoes();
        GetProcess();
      } catch (Exception ex) {
        MsgBox.Show($"Erro \n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void AtualizarInformacoes() {
      if (_componente.itens_corte?.Count > 0) {
        var espess = _componente.itens_corte[_posAtualItemCorte].cxd_espess;
        var descricMaterial = _componente.itens_corte[_posAtualItemCorte].descricao_material;
        var tipo = _componente.itens_corte[_posAtualItemCorte].tipo;

        lblListaCorte.Text = $"{_componente.itens_corte[_posAtualItemCorte].nome_lista} - {(_posAtualItemCorte + 1) + " de " + _componente.itens_corte.Count}";
        lblPeso.Text = _componente.itens_corte[_posAtualItemCorte].massa + " kg";
        lblEspess.Text = espess + "x" +
            _componente.itens_corte[_posAtualItemCorte].cxd_larg + "x" +
            _componente.itens_corte[_posAtualItemCorte].cxd_compr;
        lblDescMatPrima.Text = descricMaterial;
        lblMaterial.Text = _componente.itens_corte[_posAtualItemCorte].material;

        txtDescricao.Text = _componente.denominacao;

        if (tipo == TipoListaMaterial.Chapa) {
          var list = MateriaPrima.SelecionarParaComboBox(espess);
          txtMateriaPrima.CarregarComboBox(list);

          if (list.Count > 0) {
            var mat = list.FirstOrDefault(x => x.MaterialDesc == _componente.itens_corte[_posAtualItemCorte].material);
            if (mat != null) {
              txtMateriaPrima.SelectedValue = mat.ID;
              txtMateriaPrima.Text = mat.ChapaDesc;
            } else {
              mat = list.FirstOrDefault(x => x.ChapaDesc == descricMaterial);
              if (mat != null) {
                txtMateriaPrima.SelectedValue = mat.ID;
                txtMateriaPrima.Text = mat.ChapaDesc;
              }
            }
          } else if (list.Count == 1) {
            txtMateriaPrima.SelectedValue = list[0].ID;
            txtMateriaPrima.Text = list[0].ChapaDesc;
          }

          var id = (int?)txtMateriaPrima.SelectedValue;
          var mat2 = list.FirstOrDefault(x => x.ChapaDesc == descricMaterial);
          if (mat2 != null && mat2.ID != (int?)txtMateriaPrima.SelectedValue) {
            lblDescMatPrima.UseCustomColor = true;
          }
        }
      } else {
        txtDescricao.Text = _componente.denominacao;
        lblPeso.Text = _componente.massa + " kg";
      }
    }

    private void GetProcess() {
      try {
        ClearCheckBox();
        string[] procs;

        if (_componente.itens_corte.Count > 0) {
          bool boolstatus = swModel.Extension.SelectByID2(_componente.itens_corte[_posAtualItemCorte].nome_lista, "SUBWELDFOLDER", 0, 0, 0, false, 0, null, 0);

          procs = _componente.itens_corte[_posAtualItemCorte].operacao?.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        } else
          procs = _componente.operacao?.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

        if (procs != null) {
          foreach (string prc in procs) {
            flpOperacoes.Controls.OfType<LmCheckBox>().Where(x => x.Tag.ToString() == prc).ToList().ForEach(x => x.Checked = true);
          }
        }
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao retornar Processos\n\n{ex.Message}", "Addin LM Projetos",
             MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void TxtDenominacao_Leave(object sender, EventArgs e) {
      //if (componentes.Current != null)
      //  componentes[posAtualComponente].Denominacao = txtDenominacao.Text;
    }

    private void ClearCheckBox() {
      flpOperacoes.Controls.OfType<LmCheckBox>().Where(x => x.Checked).ToList().ForEach(x => x.Checked = false);
    }

    private void Ckb_CheckedChanged(object sender, EventArgs e) {
      if (_componentes.Count == 0) return;

      string p = ((LmCheckBox)sender).Tag.ToString();

      if (((LmCheckBox)sender).Checked == true) {
        lblOperacoes.Text += !string.IsNullOrEmpty(lblOperacoes.Text) ? $"/{p}" : p;

        ((LmCheckBox)sender).BackColor = Color.SpringGreen;
      } else {
        lblOperacoes.Text = lblOperacoes.Text.Replace(p, "").Replace("//", "/");

        if (lblOperacoes.Text.StartsWith("/"))
          lblOperacoes.Text = lblOperacoes.Text.Substring(1, lblOperacoes.Text.Length - 1);
        if (lblOperacoes.Text.EndsWith("/"))
          lblOperacoes.Text = lblOperacoes.Text.Substring(0, lblOperacoes.Text.Length - 1);

        ((LmCheckBox)sender).BackColor = Color.Transparent;
      }

      if (_componente.itens_corte?.Count > 0) {
        lblOperacoes.UseCustomColor = _componente.itens_corte[_posAtualItemCorte].operacao != lblOperacoes.Text;
      } else
        lblOperacoes.UseCustomColor = _componente.operacao != lblOperacoes.Text;
    }

    private void CkbAddDenom_CheckedChanged(object sender, EventArgs e) {
      InfoSetting.AddDenominacaoTodasConfig = ckbAddDenom.Checked;
      InfoSetting.Salvar();
    }

    private void TmrInicioLocalizar_Tick(object sender, EventArgs e) {
      ((System.Windows.Forms.Timer)sender).Tag = Convert.ToInt32(((System.Windows.Forms.Timer)sender).Tag) + 1;
      if (Convert.ToInt32(((System.Windows.Forms.Timer)sender).Tag) > 5)
        IniciarLocalizar();
    }

    private void TxtProcurar_TextChanged(object sender, EventArgs e) {
      if (tmrInicioLocalizar.Enabled == false)
        tmrInicioLocalizar.Enabled = true;
      else
        tmrInicioLocalizar.Tag = 0;
    }

    private void IniciarLocalizar() {
      tmrInicioLocalizar.Tag = 0;
      tmrInicioLocalizar.Enabled = false;

      try {
        flpOperacoes.Controls.OfType<LmCheckBox>().ToList()
        .ForEach(x => {
          x.Visible = x.Checked || x.Text.ToLower().RemoverCaracteresEspeciais().Contains(txtProcurar.Text.ToLower().RemoverCaracteresEspeciais());
        });

      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Filtrar Operações");
      }
    }

    private void FlpProcess_SizeChanged(object sender, EventArgs e) {
      try {
        flpOperacoes.Controls.OfType<LmCheckBox>().ToList()
        .ForEach(x => {
          x.Size = new Size(flpOperacoes.Width - 30, 19);
        });
      } catch (Exception ex) {

      }
    }

    private void TxtMateriaPrima_SelectedValueChanched(object sender, EventArgs e) {
      try {
        if (txtMateriaPrima.SelectedValue != null) {
          var id = (int)txtMateriaPrima.SelectedValue;
          var mat = MateriaPrima.ListaMateriaPrima.FirstOrDefault(x => x.ID == id);
          if (mat != null && _componente.itens_corte[_posAtualItemCorte] != null) {
            if (mat.ChapaDesc != _componente.itens_corte[_posAtualItemCorte].descricao_material) {
              lblDescMatPrima.UseCustomColor = true;
            } else {
              lblDescMatPrima.UseCustomColor = false;
            }
            if (mat.MaterialDesc != _componente.itens_corte[_posAtualItemCorte].material) {
              lblMaterial.UseCustomColor = true;
            } else {
              lblMaterial.UseCustomColor = false;
            }
          }
        } else {
          lblDescMatPrima.UseCustomColor = false;
          lblMaterial.UseCustomColor = false;
        }
        pnlDados.Refresh();
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ");
      }
    }

    private void AdicionarDescricaoTodasConfiguracoes() {
      try {
        object[] configNameArr = null;
        string configName = null;
        bool status = false;
        int i = 0;
        int h = 0;

        swModel = (ModelDoc2)swApp.ActiveDoc;
       ConfigurationManager swConfMgr = swModel.ConfigurationManager;
        swModelDocExt = swModel.Extension;
        configNameArr = (object[])swModel.GetConfigurationNames();

        string filename = swModel.GetPathName();

        configName = swConfMgr.ActiveConfiguration.Name;
        string defConfig = configName;

        if (ckbAddDenom.Checked) {
          for (i = 0; i <= configNameArr.GetUpperBound(0); i++) {
            configName = (string)configNameArr[i];
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
