using LmCorbieUI;
using System;
using System.Collections.Generic;

namespace AddinFormatec {
  public class vw_processo {
    public string processo_codigo { get; set; }
    public string processo_produto { get; set; }
    public string processo_descricao { get; set; }
    public string processo_maquina{ get; set; }
    public int processo_fase { get; set; }
    public double processo_tempo { get; set; } = 0.0;
    public int processo_setup { get; set; } = 0;
    public string processo_operacao { get; set; }
    public string processo_ultima_operacao { get; set; }
    public string processo_observacao { get; set; }
    public int processo_qtd_homens { get; set; } = 0;

    public static List<vw_processo> GetProcessos(string codProd) {
      var _return = new List<vw_processo>();

      try {
        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();
          using (var cmd = connection.CreateCommand()) {
            cmd.CommandText = "SELECT * FROM vw_processo WHERE processo_produto = @processo_produto ORDER BY processo_codigo ASC";
            cmd.Parameters.AddWithValue("@processo_produto", $"{codProd}");
            using (var dr = cmd.ExecuteReader()) {
              while (dr.Read()) {
                var cod = dr.GetString(dr.GetOrdinal("processo_codigo")).Trim();
                _return.Add(new vw_processo {
                  processo_codigo = cod,
                  processo_produto = dr.GetString(dr.GetOrdinal("processo_produto")).Trim(),
                  processo_descricao = dr.GetString(dr.GetOrdinal("processo_descricao")).Trim(),
                  processo_maquina = dr.GetString(dr.GetOrdinal("processo_maquina")).Trim(),
                  processo_fase = dr.GetInt32(dr.GetOrdinal("processo_fase")),
                  processo_tempo = dr.GetDouble(dr.GetOrdinal("processo_tempo")),
                  processo_setup = dr.GetInt32(dr.GetOrdinal("processo_setup")),
                  processo_operacao = dr.GetString(dr.GetOrdinal("processo_operacao")).Trim(),
                  processo_ultima_operacao = dr.GetString(dr.GetOrdinal("processo_ultima_operacao")).Trim(),
                  processo_observacao = dr.GetString(dr.GetOrdinal("processo_observacao")).Trim(),
                  processo_qtd_homens = dr.GetInt32(dr.GetOrdinal("processo_qtd_homens")),
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

  }
}
