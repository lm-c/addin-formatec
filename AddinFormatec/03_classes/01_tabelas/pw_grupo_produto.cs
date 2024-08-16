using LmCorbieUI;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinFormatec {
  internal class pw_grupo_produto {
    [DataObjectField(true, false)]
    public int grupoproduto_codigo_pk { get; set; }

    [DataObjectField(false, true)]
    public string grupoproduto_descricao { get; set; }

    public string grupoproduto_tipo_grupo_produto_codigo_fk { get; set; }

    public static List<pw_grupo_produto> SelecionarGrupos() {
      var _return = new List<pw_grupo_produto>();
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM pw_grupo_produto";
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                var cod = dr.GetInt32(dr.GetOrdinal("grupoproduto_codigo_pk"));
                var descricao = dr.GetString(dr.GetOrdinal("grupoproduto_descricao")).Trim();
                _return.Add(new pw_grupo_produto {
                  grupoproduto_codigo_pk = cod,
                  grupoproduto_descricao = $"{cod} - {descricao}",
                  grupoproduto_tipo_grupo_produto_codigo_fk = dr.GetString(dr.GetOrdinal("grupoproduto_tipo_grupo_produto_codigo_fk"))
                });
              }
            }
          }
        }
      } catch (Exception ex) {
        MsgBox.Show(ex.Message, "Erro ao Selecionar Grupos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
      }
      return _return;
    }

  }
}
