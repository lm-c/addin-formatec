using LmCorbieUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AddinFormatec {
  internal class vw_grupo_subgrupo {
    public int codigo_grupo { get; set; }

    public string descricao_grupo { get; set; }

    public string tipo_grupo { get; set; }

    [DataObjectField(true, false)]
    public int codigo_subgrupo { get; set; }

    [DataObjectField(false, true)]
    public string descricao_subgrupo { get; set; }

    public static List<vw_grupo_subgrupo> SelecionarSubGrupos(short idGrupo) {
      var _return = new List<vw_grupo_subgrupo>();
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM vw_grupo_subgrupo WHERE codigo_grupo = @codigo_grupo";
            cmd.Parameters.AddWithValue("@codigo_grupo", idGrupo);
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                var cod = dr.GetInt32(dr.GetOrdinal("codigo_subgrupo"));
                var descricao = dr.GetString(dr.GetOrdinal("descricao_subgrupo")).Trim();
                _return.Add(new vw_grupo_subgrupo {
                  codigo_subgrupo = cod,
                  descricao_subgrupo = $"{cod} - {descricao}",
                  codigo_grupo = dr.GetInt32(dr.GetOrdinal("codigo_grupo")),
                  descricao_grupo = dr.GetString(dr.GetOrdinal("descricao_grupo")).Trim(),
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
