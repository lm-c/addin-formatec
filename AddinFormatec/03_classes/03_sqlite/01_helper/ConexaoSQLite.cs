using System;
using System.Data.SQLite;

namespace AddinFormatec {
  internal class ConexaoSQLite {
    public static readonly string Database = Config_db.LocalBaseDados + "base_dados_addin.db";

    public static SQLiteConnection GetConexao() {
      return new SQLiteConnection() {
        ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = Database, ForeignKeys = true }.ConnectionString
      };
    }

    public static string ConnectionString { get; } = @"Data Source=" + Database + ";";

    public void Dispose() {
      GC.Collect();
    }
  }
}
