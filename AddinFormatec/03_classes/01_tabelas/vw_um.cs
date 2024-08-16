using LmCorbieUI;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinFormatec {
  internal class vw_um {
    [DataObjectField(true, false)]
    public int id { get; set; }

    [DataObjectField(false, true)]
    public string um { get; set; }

    public string descricao { get; set; }

    public static List<vw_um> SelecionarUnidMed() {
      var _return = new List<vw_um>();
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM vw_um";
            using (var dr = cmd.ExecuteReader()) {
              int id = 1;
              while (dr.Read()) {
                var um = dr.GetString(dr.GetOrdinal("um")).Trim();
                var descricao = dr.GetString(dr.GetOrdinal("descricao")).Trim();
                _return.Add(new vw_um {
                  id = id,
                  um = um,
                  descricao = descricao,
                });
                id++;
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
