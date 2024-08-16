using LmCorbieUI;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AddinFormatec {
  internal class vw_produto {
    [DataObjectField(true, false)]
    public string codigo_produto { get; set; }
    [DataObjectField(false, true)]
    public string descricao_produto { get; set; }
    public int grupo_produto { get; set; }
    public int subgrupo_produto { get; set; }
    public string um_produto { get; set; }
    public string origem_produto { get; set; }
    public string status_produto { get; set; }
    public int fase_padrao_consumo { get; set; }

    public string subgrupo_produto_desc { get; set; } // para material de chapa metálica

    public List<vw_processo> processos = new List<vw_processo>();

    public static vw_produto GetProduto(string codProd) {
      var _return = new vw_produto();

      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM vw_produto WHERE codigo_produto = @codigo_produto ";
            cmd.Parameters.AddWithValue("@codigo_produto", $"{codProd}");
            using (var dr = cmd.ExecuteReader()) {
              if (dr.Read()) {
                var cod = dr.GetString(dr.GetOrdinal("codigo_produto")).Trim();
                _return = new vw_produto {
                  codigo_produto = cod,
                  descricao_produto = dr.GetString(dr.GetOrdinal("descricao_produto")).Trim(),
                  grupo_produto = dr.GetInt32(dr.GetOrdinal("grupo_produto")),
                  subgrupo_produto = dr.GetInt32(dr.GetOrdinal("subgrupo_produto")),
                  um_produto = dr.GetString(dr.GetOrdinal("um_produto")).Trim(),
                  origem_produto = dr.GetString(dr.GetOrdinal("origem_produto")).Trim(),
                  status_produto = dr.GetString(dr.GetOrdinal("status_produto")).Trim(),
                  fase_padrao_consumo = dr.GetInt32(dr.GetOrdinal("fase_padrao_consumo")),
                  processos = vw_processo.GetProcessos(codProd),
                };
              }
            }
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Retornar Processos");
      }

      return _return;
    }

    public static List<vw_produto> SelecionarChapas() {
      var _return = new List<vw_produto>();
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            var clausulaWhere =
              "WHERE p.grupo_produto = 10 AND " +
              "p.status_produto = 'A' AND " +
              "(p.subgrupo_produto = 1 OR " +
              "p.subgrupo_produto = 2 OR " +
              "p.subgrupo_produto = 3 OR " +
              "p.subgrupo_produto = 4 OR " +
              "p.subgrupo_produto = 5)";

            cmd.CommandText = $"SELECT p.*, sb.descricao_subgrupo " +
                  $"FROM vw_produto p " +
                  $"LEFT JOIN vw_grupo_subgrupo sb " +
                  $"ON p.grupo_produto = sb.codigo_grupo AND p.subgrupo_produto = sb.codigo_subgrupo " +
                  $"{clausulaWhere} " +
                  $"ORDER BY p.subgrupo_produto ASC";
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                var cod = dr.GetString(dr.GetOrdinal("codigo_produto"));
                if (!cod.StartsWith("10")) continue;

                _return.Add(new vw_produto {
                  codigo_produto = cod,
                  descricao_produto = dr.GetString(dr.GetOrdinal("descricao_produto")).Trim(),
                  grupo_produto = dr.GetInt32(dr.GetOrdinal("grupo_produto")),
                  subgrupo_produto = dr.GetInt32(dr.GetOrdinal("subgrupo_produto")),
                  um_produto = dr.GetString(dr.GetOrdinal("um_produto")).Trim(),
                  origem_produto = dr.GetString(dr.GetOrdinal("origem_produto")).Trim(),
                  status_produto = dr.GetString(dr.GetOrdinal("status_produto")).Trim(),
                  fase_padrao_consumo = dr.GetInt32(dr.GetOrdinal("fase_padrao_consumo")),
                  subgrupo_produto_desc = dr.GetString(dr.GetOrdinal("descricao_subgrupo")).Trim(),
                });
              }
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show(ex.Message, "Erro ao Selecionar Chapas", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
      }
      return _return;
    }

  }
}
