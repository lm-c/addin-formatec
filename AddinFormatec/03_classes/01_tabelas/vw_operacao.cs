using LmCorbieUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AddinFormatec {
  public class vw_operacao {
    public string codigo_operacao { get; set; }
    public string descricao_oepracao { get; set; }
    public double tempo_operacao { get; set; }
    public string maquina_operacao { get; set; }
    public int fase_operacao { get; set; }

    public static List<vw_operacao> GetProcessos() {
      var _return = new List<vw_operacao>();

      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM vw_operacao ORDER BY codigo_operacao ASC";
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                var cod = dr.GetString(dr.GetOrdinal("codigo_operacao")).Trim();
                _return.Add(new vw_operacao {
                  codigo_operacao = cod,
                  descricao_oepracao = dr.GetString(dr.GetOrdinal("descricao_oepracao")).Trim(),
                  tempo_operacao = dr.GetDouble(dr.GetOrdinal("tempo_operacao")),
                  maquina_operacao = dr.GetString(dr.GetOrdinal("maquina_operacao")).Trim(),
                  fase_operacao = dr.GetInt32(dr.GetOrdinal("fase_operacao")),
                });
              }
            }
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Retornar Processos");
      }

      return _return;
    }

    public static string GetProcessosDescricoes(string codigos) {
      var _return = string.Empty;

      var idSpl = codigos.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            for (int i = 0; i < idSpl.Length; i++) {
              string id = idSpl[i];
              cmd.CommandText = $"SELECT descricao_oepracao FROM vw_operacao WHERE codigo_operacao = '{id}'";
              using (var dr = cmd.ExecuteReader()) {
                if (dr.Read()) {
                  var descr = (i + 1) + " - " + dr.GetString(dr.GetOrdinal("descricao_oepracao")).Trim();
                  _return += descr + ", ";
                }
              }
            }
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Retornar Descrição Processos");
      }

      if (_return != string.Empty)
        _return = _return.Substring(0, _return.Length - 2);

      return _return;
    }

    public static string GetProcessoDescricao(string codigo) {
      var _return = string.Empty;

      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
              cmd.CommandText = $"SELECT descricao_oepracao FROM vw_operacao WHERE codigo_operacao = '{codigo}'";
              using (var dr = cmd.ExecuteReader()) {
                if (dr.Read()) {
                  var descr = dr.GetString(dr.GetOrdinal("descricao_oepracao")).Trim();
                  _return = descr;
                }
              }
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Retornar Descrição Processo");
      }

      return _return;
    }
  }
}
