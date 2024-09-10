using System;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using Npgsql;

namespace AddinFormatec {
  public partial class FrmProdutoImport : LmChildForm {
    public SldWorks swApp = new SldWorks();
    ModelDoc2 swModel = default(ModelDoc2);
    ModelDocExtension swModelDocExt;
    CustomPropertyManager swCustPropMngr = default(CustomPropertyManager);

    string _montagemPrincipal = string.Empty;
    int _posAtualItemCorte = 0;
    long novo_cadcont = 1;
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

        if (swModel.GetType() == (int)swDocumentTypes_e.swDocASSEMBLY) {
          _montagemPrincipal = swModel.GetPathName().ToLower();

          TreeComponent.GetComponents(trvProduto);
          trvProduto.TopNode = trvProduto.Nodes[0];
          TrvProduto_NodeMouseDoubleClick(null, new TreeNodeMouseClickEventArgs(trvProduto.Nodes[0], MouseButtons.Left, 1, 0, 0));
        } else {
          Toast.Warning("Comando apenas para Montagens.");
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

        var id_grupo = (short)txtGrupo.SelectedValue;
        var id_subgrupo = (short)txtSubGrupo.SelectedValue;
        var descr = txtDescricao.Text;
        var um = txtUnidadeMedida.Text;

        ((TreeComponent)trvProduto.SelectedNode.Tag).grupo = id_grupo;
        ((TreeComponent)trvProduto.SelectedNode.Tag).subGrupo = id_subgrupo;
        ((TreeComponent)trvProduto.SelectedNode.Tag).um1 = um;
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
      long priCod = 999999999;
      try {
        MsgBox.ShowWaitMessage("Verificando pendências...");
        List<TreeComponent> list = new List<TreeComponent>();
        var compSemProps = "";
        var compSemSalvar = "";
        var listaVistos = new List<string>();
        PercorrerTreeViewIgnorandoRepetido(trvProduto.Nodes, list);

        using (var conn = ConexaoPgSql.GetConexao()) {
          conn.Open();
          using (var transaction = conn.BeginTransaction()) {
            try {
              // Verificar Materia Prima
              using (var cmd = conn.CreateCommand()) {
                foreach (var item in list) {
                  if (item.tipoComponente != TipoComponente.ListaMaterial &&
                    (item.grupo == null ||
                    item.subGrupo == null ||
                    string.IsNullOrEmpty(item.um1))) {
                    compSemProps += $"{Path.GetFileName(item.pathName)} | ";
                  } else if (item.tipoComponente == TipoComponente.ListaMaterial && !compSemSalvar.Contains(item.codigo)) {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "SELECT codigo_produto FROM vw_produto WHERE codigo_produto = @codigo_produto ";
                    cmd.Parameters.AddWithValue("@codigo_produto", item.codigo);

                    using (var dr = cmd.ExecuteReader()) {
                      if (!dr.Read()) {
                        compSemSalvar += $"{Path.GetFileName(item.codigo)} | ";
                      }
                    }
                  }
                }
              }

              if (!string.IsNullOrEmpty(compSemProps)) {
                compSemProps = $"Os items abaixo, estão sem o grupo e subgrupo definido, preencha-os para prosseguir." +
                  $"<sep>" +
                  $"{compSemProps.Substring(0, compSemProps.Length - 3)}";
                MsgBox.Show(compSemProps, "Addin LM Projetos",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
              }

              if (!string.IsNullOrEmpty(compSemSalvar)) {
                compSemSalvar = $"As Materias Primas abaixo, ainda não foram salvas, salve-as no ERP para prosseguir." +
                  $"<sep>" +
                  $"{compSemSalvar.Substring(0, compSemSalvar.Length - 3)}";
                MsgBox.Show(compSemSalvar, "Addin LM Projetos",
                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
                return;
              }

              // Salvar Estrutura
              novo_cadcont = priCod = 1;
              using (var cmd = conn.CreateCommand()) {
                MsgBox.ShowWaitMessage("Importando Estrutura...");
                cmd.CommandText = "SELECT cadcont FROM cadireta ORDER BY cadcont DESC LIMIT 1;";
                using (var dr = cmd.ExecuteReader()) {
                  if (dr.Read()) {
                    novo_cadcont = priCod = dr.GetInt64(dr.GetOrdinal("cadcont")) + 1;
                  }
                }

                if (ImportacaoProjeto.ImportacaoEmAndamento(out string cod, out string desc)) {
                  MsgBox.Show($"O Projeto '{cod} - {desc}' está em sendo importado neste momento, aguarde alguns minutos e tente novamente.",
                    "Importação em Andamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  return;
                } else if (ImportacaoProjeto.ProjetoImportado(list[0].codigo)) {
                  MsgBox.Show($"Já foi feita a importação deste projeto\r\n'{list[0].codigo} - {list[0].descricao}'",
                    "Projeto já Importado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  return;
                } else {
                  ImportacaoProjeto.model = new ImportacaoProjeto {
                    Codigo = list[0].codigo,
                    Descricao = list[0].descricao,
                    ImportacaoConcluida = false,
                  };

                  ImportacaoProjeto.Salvar();
                }
                PercorrerTreeViewSalvarCadireta(cmd, trvProduto.Nodes);
              }

              ImportacaoProjeto.model.CadContIni = priCod;
              ImportacaoProjeto.model.CadContFim = novo_cadcont;
              ImportacaoProjeto.model.ImportacaoConcluida = true;
              ImportacaoProjeto.Salvar();
              transaction.Commit();
              Toast.Success("Estrutura Importada com Sucesso!!");
            } catch (Exception ex1) {
              transaction.Rollback();
              throw ex1;
            }
          }
        }

      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Importar Estrutura");

        try {
          ImportacaoProjeto.Excluir();
        } catch (Exception ex1) {
          LmException.ShowException(ex1, "Erro ao Limpar Importação parcial");
        }
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }

    private void PercorrerTreeViewIgnorandoRepetido(TreeNodeCollection nodes, List<TreeComponent> list) {
      foreach (TreeNode node in nodes) {
        TreeComponent comp = (TreeComponent)node.Tag;
        if (!list.Any(x => x.codigo.Equals(comp?.codigo))) {
          if (node.Tag != null) {
            list.Add(comp);
          }

          // Chamar recursivamente para percorrer os nós filhos
          if (node.Nodes.Count > 0) {
            PercorrerTreeViewIgnorandoRepetido(node.Nodes, list);
          }
        }
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void PercorrerTreeViewSalvarCadireta(NpgsqlCommand cmd, TreeNodeCollection nodes) {
      foreach (TreeNode node in nodes) {
        long exist_cadcont = 0;
        var fase = 10;
        var agora = DateTime.Now;

        if (node.Level != 0) {
          TreeComponent compPai = (TreeComponent)node.Parent.Tag;
          TreeComponent compFil = (TreeComponent)node.Tag;

          cmd.Parameters.Clear();

          cmd.CommandText = "SELECT fase_padrao_consumo FROM vw_produto WHERE codigo_produto = @codigo_produto ";
          cmd.Parameters.AddWithValue("@codigo_produto", compFil.codigo);

          using (var dr = cmd.ExecuteReader()) {
            if (dr.Read()) {
              fase = dr.GetInt32(dr.GetOrdinal("fase_padrao_consumo"));
            }
          }

          // Salvar CADIRETA
          cmd.Parameters.Clear();

          cmd.CommandText = $"INSERT INTO cadireta " +
            $"(cadcont, cadpai, cadfilho, cadstatus, cadsuscad, cadpainome, cadfilnome, cadpaium, cadfilum, caduso, cadcomp, cadlarg, cadespe, " +
            $"cadpeso, cadfase, cadgrav, cadhora, cadgrpai, cadsgpai, cadgrfil, cadsgfil, cadpriemb, cadplcor, cadusamed, cadborint, cadborsup, " +
            $"cadborinf, cadboresq, cadbordir, cadpaiarea, cadpembpr, cadpembpp, cadindter, cadapp, cadarqfil ) " +
            $"VALUES " +
            $"(@cadcont, @cadpai, @cadfilho, @cadstatus, @cadsuscad, @cadpainome, @cadfilnome, @cadpaium, @cadfilum, @caduso, @cadcomp, @cadlarg, @cadespe, " +
            $"@cadpeso, @cadfase, @cadgrav, @cadhora, @cadgrpai, @cadsgpai, @cadgrfil, @cadsgfil, @cadpriemb, @cadplcor, @cadusamed, @cadborint, @cadborsup, " +
            $"@cadborinf, @cadboresq, @cadbordir, @cadpaiarea, @cadpembpr, @cadpembpp, @cadindter, @cadapp, @cadarqfil )";

          cmd.Parameters.AddWithValue("@cadcont", novo_cadcont);
          cmd.Parameters.AddWithValue("@cadpai", compPai.codigo);
          cmd.Parameters.AddWithValue("@cadfilho", compFil.codigo);
          cmd.Parameters.AddWithValue("@cadstatus", "N");
          cmd.Parameters.AddWithValue("@cadsuscad", "ADDIN");
          cmd.Parameters.AddWithValue("@cadpainome", compPai.descricao);
          cmd.Parameters.AddWithValue("@cadfilnome", compFil.descricao);
          cmd.Parameters.AddWithValue("@cadpaium", compPai.um1);
          cmd.Parameters.AddWithValue("@cadfilum", compFil.um1);
          cmd.Parameters.AddWithValue("@caduso", compPai.qtd1 * compFil.qtd1);
          cmd.Parameters.AddWithValue("@cadcomp", 0.00);
          cmd.Parameters.AddWithValue("@cadlarg", 0.00);
          cmd.Parameters.AddWithValue("@cadespe", 0.00);
          cmd.Parameters.AddWithValue("@cadpeso", compFil.peso);
          cmd.Parameters.AddWithValue("@cadfase", fase);
          cmd.Parameters.AddWithValue("@cadgrav", agora);
          cmd.Parameters.AddWithValue("@cadhora", $"{agora.Hour:00}:{agora.Minute:00}:{agora.Second:00}");
          cmd.Parameters.AddWithValue("@cadgrpai", compPai.grupo);
          cmd.Parameters.AddWithValue("@cadsgpai", compPai.subGrupo);
          cmd.Parameters.AddWithValue("@cadgrfil", compFil.grupo != null ? compFil.grupo : compPai.grupo);
          cmd.Parameters.AddWithValue("@cadsgfil", compFil.subGrupo != null ? compFil.subGrupo : compPai.subGrupo);
          cmd.Parameters.AddWithValue("@cadpriemb", 0);
          cmd.Parameters.AddWithValue("@cadarquivo", compPai.pathName);
          cmd.Parameters.AddWithValue("@cadplcor", "N");
          cmd.Parameters.AddWithValue("@cadusamed", "N");
          cmd.Parameters.AddWithValue("@cadborint", "N");
          cmd.Parameters.AddWithValue("@cadborsup", "N");
          cmd.Parameters.AddWithValue("@cadborinf", "N");
          cmd.Parameters.AddWithValue("@cadboresq", "N");
          cmd.Parameters.AddWithValue("@cadbordir", "N");
          cmd.Parameters.AddWithValue("@cadpaiarea", 0.00);
          cmd.Parameters.AddWithValue("@cadpembpr", 0);
          cmd.Parameters.AddWithValue("@cadpembpp", 0);
          cmd.Parameters.AddWithValue("@cadindter", "N");
          cmd.Parameters.AddWithValue("@cadapp", "ADDIN");
          cmd.Parameters.AddWithValue("@cadarqfil", compFil.pathName);

          cmd.ExecuteNonQuery();

          // Salvar CADIREDI
          if (compFil.tipoComponente == TipoComponente.ListaMaterial) {
            cmd.Parameters.Clear();

            cmd.CommandText = $"INSERT INTO cadiredi " +
              $"(caddcont, caddpai, caddfil, caddseq, caddesp, caddlar, caddcom, caddesb, caddlab, caddcob, caddcor, " +
              $"caddbint, caddbsup, caddbinf, caddbesq, caddbdir, caddpdes, caddper , caddqtd ) " +
              $"VALUES " +
              $"(@caddcont, @caddpai, @caddfil, @caddseq, @caddesp, @caddlar , @caddcom, @caddesb, @caddlab, @caddcob, @caddcor, " +
              $"@caddbint, @caddbsup, @caddbinf, @caddbesq, @caddbdir, @caddpdes, @caddper, @caddqtd )";

            cmd.Parameters.AddWithValue("@caddcont", exist_cadcont == 0 ? novo_cadcont : exist_cadcont);
            cmd.Parameters.AddWithValue("@caddpai", compPai.codigo);
            cmd.Parameters.AddWithValue("@caddfil", compFil.codigo);
            cmd.Parameters.AddWithValue("@caddseq", 1);
            cmd.Parameters.AddWithValue("@caddesp", compFil.espe);
            cmd.Parameters.AddWithValue("@caddlar", compFil.larg);
            cmd.Parameters.AddWithValue("@caddcom", compFil.comp);
            cmd.Parameters.AddWithValue("@caddesb", compFil.espe);
            cmd.Parameters.AddWithValue("@caddlab", compFil.larg);
            cmd.Parameters.AddWithValue("@caddcob", compFil.comp);
            cmd.Parameters.AddWithValue("@caddcor", "N");
            cmd.Parameters.AddWithValue("@caddbint", "N");
            cmd.Parameters.AddWithValue("@caddbsup", "N");
            cmd.Parameters.AddWithValue("@caddbinf", "N");
            cmd.Parameters.AddWithValue("@caddbesq", "N");
            cmd.Parameters.AddWithValue("@caddbdir", "N");
            cmd.Parameters.AddWithValue("@caddpdes", compFil.descricao);
            cmd.Parameters.AddWithValue("@caddper", 0.0);
            cmd.Parameters.AddWithValue("@caddqtd", 1);

            cmd.ExecuteNonQuery();
          }

          // Salvar CADPROCE
          var operacoes = compFil.operacao.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
          if (operacoes.Length > 0) {
            for (int i = 0; i < operacoes.Length; i++) {
              var operacao = operacoes[i];
              var cadpprce = $"0{i + 1}0";
              var ww_oper = new vw_operacao();
              cmd.CommandText = "SELECT * FROM vw_operacao WHERE codigo_operacao = @codigo_operacao";
              cmd.Parameters.AddWithValue("@codigo_operacao", operacao);
              using (var dr = cmd.ExecuteReader()) {
                if (dr.Read()) {
                  var cod = dr.GetString(dr.GetOrdinal("codigo_operacao")).Trim();
                  ww_oper = (new vw_operacao {
                    codigo_operacao = cod,
                    descricao_oepracao = dr.GetString(dr.GetOrdinal("descricao_oepracao")).Trim(),
                    tempo_operacao = dr.GetDouble(dr.GetOrdinal("tempo_operacao")),
                    maquina_operacao = dr.GetString(dr.GetOrdinal("maquina_operacao")).Trim(),
                    fase_operacao = dr.GetInt32(dr.GetOrdinal("fase_operacao")),
                  });
                }
              }

              cmd.Parameters.Clear();

              cmd.CommandText = $"INSERT INTO cadproce " +
                $"(cadpcont, cadpprod, cadpoper, cadpprce, cadpmaqu, cadpfase, cadpnrep, cadphora, cadpulfa ) " +
                $"VALUES " +
                $"(@cadpcont, @cadpprod, @cadpoper, @cadpprce, @cadpmaqu, @cadpfase, @cadpnrep, @cadphora, @cadpulfa )";

              cmd.Parameters.AddWithValue("@cadpcont", exist_cadcont == 0 ? novo_cadcont : exist_cadcont);
              cmd.Parameters.AddWithValue("@cadpprod", compFil.codigo);
              cmd.Parameters.AddWithValue("@cadpprce", $"0{i + 1}0");
              cmd.Parameters.AddWithValue("@cadpoper", operacao);
              cmd.Parameters.AddWithValue("@cadpmaqu", ww_oper.maquina_operacao);
              cmd.Parameters.AddWithValue("@cadpfase", ww_oper.fase_operacao);
              cmd.Parameters.AddWithValue("@cadpnrep", 0.00);
              cmd.Parameters.AddWithValue("@cadphora", ww_oper.tempo_operacao);
              cmd.Parameters.AddWithValue("@cadpulfa", i == operacoes.Length - 1 ? "S" : "N");

              cmd.ExecuteNonQuery();
            }
          }
          novo_cadcont++;
        }

        // Chamar recursivamente para percorrer os nós filhos
        if (node.Nodes.Count > 0) {
          PercorrerTreeViewSalvarCadireta(cmd, node.Nodes);
        }
      }
    }

    private void TrvProduto_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
      TreeComponent treeComp = (TreeComponent)e.Node.Tag;

      if (treeComp != null && treeComp?.tipoComponente != TipoComponente.ListaMaterial) {
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

          if (treeComp.grupo != null && treeComp.subGrupo != null) {
            txtGrupo.SelectedValue = treeComp.grupo;
            txtSubGrupo.SelectedValue = treeComp.subGrupo;
          }
          txtUnidadeMedida.Text = treeComp.um1;
          txtDescricao.Text = treeComp.descricao;

        } catch (Exception ex) {
          LmException.ShowException(ex, "Erro ao atualizar dados Componente");
        }
      }
    }

    private void TxtGrupo_SelectedValueChanched(object sender, EventArgs e) {
      if (txtGrupo.SelectedValue != null) {
        var idGrupo = (short)txtGrupo.SelectedValue;
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
