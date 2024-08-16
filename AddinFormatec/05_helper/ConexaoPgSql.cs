using Npgsql;
using System;

namespace AddinFormatec {
  internal class ConexaoPgSql : IDisposable {
    //private static readonly string Database = PostgresAccess.model.Database;
    //private static readonly string Port = PostgresAccess.model.Port;

    //private static readonly string Server = PostgresAccess.model.Server;
    //private static readonly string User = PostgresAccess.model.User;
    //private static readonly string Pass = PostgresAccess.model.Pass;

    public static NpgsqlConnection GetConexao() {
      try {
        return new NpgsqlConnection($"" +
          $"Host={PostgresAccess.model.Server};" +
          $"Username={PostgresAccess.model.User};" +
          $"Password={PostgresAccess.model.Pass};" +
          $"Database={PostgresAccess.model.Database}");
      } catch (Exception ex) {
        throw ex;
      }
    }

    public void Dispose() {
      GC.Collect();
    }
  }
}
