using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace AddinFormatec {
  public partial class FrmProdutoImport : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string _montagemPrincipal = string.Empty;
    int _posAtualItemCorte = 0;

    //// sem net
    //List<vw_grupo_subgrupo> subGrupos = new List<vw_grupo_subgrupo> {
    //  new vw_grupo_subgrupo{codigo_grupo = 1, codigo_subgrupo = 1, descricao_subgrupo = "Sub Grupo 1.1"},
    //  new vw_grupo_subgrupo{codigo_grupo = 1, codigo_subgrupo = 2, descricao_subgrupo = "Sub Grupo 1.2"},
    //  new vw_grupo_subgrupo{codigo_grupo = 1, codigo_subgrupo = 3, descricao_subgrupo = "Sub Grupo 1.3"},
    //  new vw_grupo_subgrupo{codigo_grupo = 2, codigo_subgrupo = 4, descricao_subgrupo = "Sub Grupo 2.1"},
    //  new vw_grupo_subgrupo{codigo_grupo = 2, codigo_subgrupo = 5, descricao_subgrupo = "Sub Grupo 2.2"},
    //  new vw_grupo_subgrupo{codigo_grupo = 3, codigo_subgrupo = 6,  descricao_subgrupo = "Sub Grupo 3.1"},
    //  new vw_grupo_subgrupo{codigo_grupo = 3, codigo_subgrupo = 7,  descricao_subgrupo = "Sub Grupo 3.2"},
    //  new vw_grupo_subgrupo{codigo_grupo = 3, codigo_subgrupo = 8,  descricao_subgrupo = "Sub Grupo 3.3"},
    //  new vw_grupo_subgrupo{codigo_grupo = 3, codigo_subgrupo = 9,  descricao_subgrupo = "Sub Grupo 3.4"},
    //  new vw_grupo_subgrupo{codigo_grupo = 3, codigo_subgrupo = 10, descricao_subgrupo = "Sub Grupo 3.5"},
    //};

    public FrmProdutoImport() {
      InitializeComponent();
    }

    private void FrmProdutoImport_Loaded(object sender, EventArgs e) {
      Invoke(new MethodInvoker(() => {
        txtGrupo.CarregarComboBox(pw_grupo_produto.SelecionarGrupos());
        txtUnidadeMedida.CarregarComboBox(vw_um.SelecionarUnidMed());
        //var grupos = new List<pw_grupo_produto> {
        //new pw_grupo_produto{grupoproduto_codigo_pk= 1, grupoproduto_descricao= "Grupo 1" },
        //new pw_grupo_produto{grupoproduto_codigo_pk= 2, grupoproduto_descricao= "Grupo 2" },
        //new pw_grupo_produto{grupoproduto_codigo_pk= 3, grupoproduto_descricao= "Grupo 3" },
        //};
        //txtGrupo.CarregarComboBox(grupos);

        //var ums = new List<vw_um> {
        //  new vw_um { id = 1, descricao = "metro", um = "m" },
        //  new vw_um { id = 2, descricao = "quilograma", um = "kg" },
        //  new vw_um { id = 3, descricao = "unidade", um = "un" },
        //  new vw_um { id = 4, descricao = "peça", um = "pç" },
        //  new vw_um { id = 5, descricao = "conjunto", um = "conj" }
        //};
        //txtUnidadeMedida.CarregarComboBox(ums);
      }));
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
          _montagemPrincipal = swModel.GetPathName().ToLower();

          TreeComponent.GetComponents(trvProduto);
          trvProduto.TopNode = trvProduto.Nodes[0];
          TrvProduto_NodeMouseDoubleClick(null, new TreeNodeMouseClickEventArgs(trvProduto.Nodes[0], MouseButtons.Left, 1, 0, 0));
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

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocDRAWING) {
          Toast.Warning("Comando apenas para Peças e Montagens.");
          return;
        }

        if (Controles.PossuiCamposInvalidos(pnlDados))
          return;

        var id_grupo = (int)txtGrupo.SelectedValue;
        var id_subgrupo = (int)txtSubGrupo.SelectedValue;
        var descr = txtDescricao.Text;
        var um = txtUnidadeMedida.Text;

        ((TreeComponent)trvProduto.SelectedNode.Tag).grupo = id_grupo.ToString();
        ((TreeComponent)trvProduto.SelectedNode.Tag).subGrupo = id_subgrupo.ToString();
        ((TreeComponent)trvProduto.SelectedNode.Tag).um = um;
        ((TreeComponent)trvProduto.SelectedNode.Tag).descricao = descr;

        swModelDocExt = swModel.Extension;
        swCustPropMngr = swModelDocExt.get_CustomPropertyManager("");
        swCustPropMngr.Add3("sgl_GrupoProduto", (int)swCustomInfoType_e.swCustomInfoText, id_grupo.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("sgl_SubgrupoProduto", (int)swCustomInfoType_e.swCustomInfoText, id_subgrupo.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);
        swCustPropMngr.Add3("sgl_UM", (int)swCustomInfoType_e.swCustomInfoText, um, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        var swConfMgr = swModel.ConfigurationManager;
        var configName = swConfMgr.ActiveConfiguration.Name;
        string defConfig = configName;

        swCustPropMngr = swModelDocExt.get_CustomPropertyManager(defConfig);
        swCustPropMngr.Add3("sgl_DescricaoEspecifica", (int)swCustomInfoType_e.swCustomInfoText, descr, (int)swCustomPropertyAddOption_e.swCustomPropertyDeleteAndAdd);

        if (trvProduto.SelectedNode != null) {
          trvProduto.SelectedNode.ForeColor = Color.Black;
        }

        Toast.Success("Sucesso!");
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao salvar..\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void BtnImportar_Click(object sender, EventArgs e) {
      try {
        MsgBox.ShowWaitMessage("Verificando pendências...");
        List<TreeComponent> list = new List<TreeComponent>();
        var compSemProps = "";
        PercorrerTreeViewRecursivamente(trvProduto.Nodes, list);
        foreach (var item in list) {
          if (item.tipoComponente != TipoComponente.ListaMaterial &&
            (string.IsNullOrEmpty(item.grupo) ||
            string.IsNullOrEmpty(item.subGrupo) ||
            string.IsNullOrEmpty(item.um))) {
            compSemProps += $"{Path.GetFileName(item.pathName)} | ";
          }
        }
        if (!string.IsNullOrEmpty(compSemProps)) {

          compSemProps = $"Os items abaixo, estão sem o grupo e subgrupo definido, preencha-os para prosseguir." +
            $"<sep>" +
            $"{compSemProps.Substring(0, compSemProps.Length - 3)}";
          MsgBox.Show(compSemProps, "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
          return;
        }

        MsgBox.ShowWaitMessage("Importando Produtos...");
        using (var conn = ConexaoPgSql.GetConexao()) {
          conn.Open();
          using (var cmd = conn.CreateCommand()) {
            foreach (var item in list) {
              cmd.Parameters.Clear();
              cmd.CommandText =
                "INSERT INTO vw_produto " +
                "(codigo_produto, descricao_produto, grupo_produto, subgrupo_produto, um_produto, origem_produto, status_produto, fase_padrao_consumo) " +
                "VALUES " +
                "(@codigo_produto, @descricao_produto, @grupo_produto, @subgrupo_produto, @um_produto, @origem_produto, @status_produto, @fase_padrao_consumo)";

              cmd.Parameters.AddWithValue("@codigo_produto", $"{item.codigo}");
              cmd.Parameters.AddWithValue("@descricao_produto", $"{item.descricao}");
              cmd.Parameters.AddWithValue("@grupo_produto", int.Parse(item.grupo));
              cmd.Parameters.AddWithValue("@subgrupo_produto", int.Parse(item.subGrupo));
              cmd.Parameters.AddWithValue("@um_produto", item.um);
              cmd.Parameters.AddWithValue("@origem_produto", "C");
              cmd.Parameters.AddWithValue("@status_produto", "A");
              cmd.Parameters.AddWithValue("@fase_padrao_consumo", 0);

              cmd.ExecuteNonQuery();
            }
          }
        }

        Toast.Success("Estrutura Importada com Sucesso!!");
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Importar Estrutura");
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void PercorrerTreeViewRecursivamente(TreeNodeCollection nodes, List<TreeComponent> list) {
      foreach (TreeNode node in nodes) {
        TreeComponent comp = (TreeComponent)node.Tag;
        if (!list.Any(x => x.codigo.Equals(comp?.codigo))) {
          if (node.Tag != null) {
            list.Add(comp);
          }

          // Chamar recursivamente para percorrer os nós filhos
          if (node.Nodes.Count > 0) {
            PercorrerTreeViewRecursivamente(node.Nodes, list);
          } 
        }
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void TrvProduto_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
      TreeComponent treeComp = (TreeComponent)e.Node.Tag;

      if (treeComp.tipoComponente != TipoComponente.ListaMaterial) {
        try {
          var pathName = treeComp.pathName;
          var confgName = treeComp.configName;
          swModel = (ModelDoc2)swApp.ActiveDoc;

          if (swModel != null && swModel.GetPathName().ToLower() != _montagemPrincipal) {
            swModel.ShowNamedView("*Isométrica");
            swModel.ViewZoomtofit();

            swModel.Save();
            swApp.CloseDoc(swModel.GetPathName());
          }

          if (treeComp.tipoComponente == TipoComponente.Peca)
            swApp.OpenDoc6(treeComp.pathName, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);
          else
            swApp.OpenDoc6(treeComp.pathName, (int)swDocumentTypes_e.swDocASSEMBLY, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", 0, 0);

          swModel = (ModelDoc2)swApp.ActivateDoc2(Name: treeComp.pathName, Silent: false, Errors: 0);

          if (!string.IsNullOrEmpty(treeComp.grupo) && !string.IsNullOrEmpty(treeComp.grupo)) {
            txtGrupo.SelectedValue = int.Parse(treeComp.grupo);
            txtSubGrupo.SelectedValue = int.Parse(treeComp.subGrupo);
          }
          txtUnidadeMedida.Text = treeComp.um;
          txtDescricao.Text = treeComp.descricao;

        } catch (Exception ex) {
          LmException.ShowException(ex, "Erro ao atualizar dados Componente");
        }
      }
    }

    private void TxtGrupo_SelectedValueChanched(object sender, EventArgs e) {
      if (txtGrupo.SelectedValue != null) {
        var idGrupo = (int)txtGrupo.SelectedValue;
        txtSubGrupo.CarregarComboBox(vw_grupo_subgrupo.SelecionarSubGrupos(idGrupo));
        //txtSubGrupo.CarregarComboBox(subGrupos.Where(x => x.codigo_grupo == idGrupo).ToList());
      } else {
        txtSubGrupo.CarregarComboBox(null);
        txtSubGrupo.Text = string.Empty;
      }
    }

    private void TrvProduto_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
      try {
        trvProduto.SelectedNode.BackColor = trvProduto.BackColor;
        //trvProduto.SelectedNode.ForeColor = trvProduto.ForeColor; 
      } catch (Exception ex) {
        // LmException.ShowException(ex, "Erro eventos Antes de Selecionar");
      }
    }

    private void TrvProduto_AfterSelect(object sender, TreeViewEventArgs e) {
      try {
        e.Node.BackColor = Color.FromArgb(0, 120, 215);
        //e.Node.ForeColor = Color.White; 
      } catch (Exception ex) {
        // LmException.ShowException(ex, "Erro eventos Após de Selecionar");
      }
    }
  }
}
