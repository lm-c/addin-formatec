using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddinFormatec {
  public partial class FrmProdutoCad : LmChildForm {
    public FrmProdutoCad() {
      InitializeComponent();

    }

    private void FrmProdutoCad_Loaded(object sender, EventArgs e) {
      Invoke(new MethodInvoker(() => {
        txtGrupo.CarregarComboBox(pw_grupo_produto.SelecionarGrupos());
        txtUnidadeMedida.CarregarComboBox(vw_um.SelecionarUnidMed());
      }));
    }

    private void BtnCarrProcess_Click(object sender, EventArgs e) {

    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      try {
        if (Controles.PossuiCamposInvalidos(this)) return;

        var id_grupo = (int)txtGrupo.SelectedValue;
        var id_subgrupo = (int)txtSubGrupo.SelectedValue;
        var descr = txtDescricao.Text; 
        var um = txtUnidadeMedida.Text; 
        var codigo_novo = $"{id_grupo:00}{id_subgrupo:000}";    
        var cod_seq = 1.ToString("000000000");    

        using (var conn = ConexaoPgSql.GetConexao()) {
          conn.Open();
          using (var cmd = conn.CreateCommand()) {
            cmd.CommandText =
                "SELECT codigo_produto FROM vw_produto " +
                "WHERE grupo_produto = @grupo_produto " +
                "AND subgrupo_produto = @subcodigo_grupo " +
                "AND codigo_produto LIKE @iniciaCom " +
                "ORDER BY codigo_produto DESC";
            cmd.Parameters.AddWithValue("@grupo_produto", id_grupo);
            cmd.Parameters.AddWithValue("@subcodigo_grupo", id_subgrupo);
            cmd.Parameters.AddWithValue("@iniciaCom", codigo_novo + "%");
            using (var dr = cmd.ExecuteReader()) {
              if (dr.Read()) {
                var cod_grupo = dr.GetString(dr.GetOrdinal("codigo_produto")).Trim();
                var spl = cod_grupo.Split('-');
                cod_seq = (Convert.ToInt32(spl[1]) + 1).ToString("000000000");
              } 
            }

            cmd.Parameters.Clear();

            cmd.CommandText =
               "INSERT INTO vw_produto " +
               "(codigo_produto, descricao_produto, grupo_produto, subgrupo_produto, um_produto, origem_produto, status_produto, fase_padrao_consumo) " +
               "VALUES " +
               "(@codigo_produto, @descricao_produto, @grupo_produto, @subgrupo_produto, @um_produto, @origem_produto, @status_produto, @fase_padrao_consumo)";

            cmd.Parameters.AddWithValue("@codigo_produto", $"{codigo_novo}-{cod_seq}");
            cmd.Parameters.AddWithValue("@descricao_produto", $"{descr}");
            cmd.Parameters.AddWithValue("@grupo_produto", id_grupo);
            cmd.Parameters.AddWithValue("@subgrupo_produto", id_subgrupo);
            cmd.Parameters.AddWithValue("@um_produto", um);
            cmd.Parameters.AddWithValue("@origem_produto", "C");
            cmd.Parameters.AddWithValue("@status_produto", "A");
            cmd.Parameters.AddWithValue("@fase_padrao_consumo", 0);

            cmd.ExecuteNonQuery();

            Toast.Success("Produto cadastrado com sucesso!");

            txtDescricao.Text = string.Empty;
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Salvar Produto Novo");
      }
    }

    private void BtnClose_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void TxtGrupo_SelectedValueChanched(object sender, EventArgs e) {
      if (txtGrupo.SelectedValue != null) {
        var idGrupo = (int)txtGrupo.SelectedValue;
        txtSubGrupo.CarregarComboBox(vw_grupo_subgrupo.SelecionarSubGrupos(idGrupo));
      } else {
        txtSubGrupo.CarregarComboBox(null);
        txtSubGrupo.Text = string.Empty;
      }
    }

    private void TxtSubGrupo_SelectedValueChanched(object sender, EventArgs e) {

    }
  }
}
