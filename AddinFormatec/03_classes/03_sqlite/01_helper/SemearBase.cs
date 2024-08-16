using LmCorbieUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AddinFormatec {
  internal class SemearBase {
    public static void CriarTabelas() {
      string nomeTabela = string.Empty;

      try {
        if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
          return;

        if (!Directory.Exists(Config_db.LocalBaseDados))
          Directory.CreateDirectory(Config_db.LocalBaseDados);

        #region Excluir Tabelas [executado na versao 1061]

        //using (SQLiteConnection connection = ConexaoSQLite.GetConexao()) {
        //  connection.Open();

        //  List<string> tableNames = new List<string>
        //  {
        //                "SQA_DiretorioConflito_Util",
        //                "SQA_DiretorioCommit_Util"
        //            };

        //  foreach (string tableName in tableNames) {
        //    string dropTableQuery = $"DROP TABLE IF EXISTS {tableName}";

        //    using (SQLiteCommand dropTableCommand = new SQLiteCommand(dropTableQuery, connection)) {
        //      dropTableCommand.ExecuteNonQuery();
        //      Console.WriteLine($"Tabela {tableName} excluída (se existia) com sucesso.");
        //    }
        //  }

        //  connection.Close();
        //}

        #endregion

        using (var cmd = ConexaoSQLite.GetConexao().CreateCommand()) {
          cmd.Connection.Open();

          using (var db = new SQLiteContexto()) {
            foreach (var tab in db.GetType().GetProperties().ToList())
              if (
                  tab.Name.ToLower() != "database" &&
                  tab.Name.ToLower() != "changetracker" &&
                  tab.Name.ToLower() != "configuration" &&
                  tab.Name.ToLower() != "model" &&
                  tab.Name.ToLower() != "contextid" &&
                  tab.Name.ToLower() != "ehbaseteste") {
                var tabela = db.GetType().GetProperty(tab.Name);
                nomeTabela = tab.Name;
                object conteudoTabela = tabela.GetMethod.Invoke(db, null);

                cmd.CommandText = GetQuery(((IQueryable)conteudoTabela).ElementType);
                cmd.ExecuteNonQuery();
              }
          }
          cmd.Connection.Close();

        }
      } catch (Exception ex) {
        LmException.ShowException(ex, $"Erro ao Criar Tabela [{nomeTabela}] Banco de dados");
      }
    }

    private static string GetQuery(Type table) {
      try {
        string fks = string.Empty;

        string _return = $"CREATE TABLE IF NOT EXISTS {table.Name} (\n";

        foreach (PropertyInfo pro in table.GetProperties().ToList()) {
          if (pro.PropertyType == typeof(string)) {
            _return += $"   {pro.Name} ";

            var atb1 = (StringLengthAttribute)pro.GetCustomAttribute(typeof(StringLengthAttribute));
            if (atb1 != null) {
              _return += $"VARCHAR({atb1.MaximumLength}) ";
            } else
              _return += $"TEXT ";

            var atb2 = (RequiredAttribute)pro.GetCustomAttribute(typeof(RequiredAttribute));
            if (atb2 != null) {
              _return += $"NOT NULL ";
            }

            _return += ", \n";
          } else if (pro.PropertyType == typeof(short)) {
            _return += $"   {pro.Name} SHORT ";

            var atb1 = (KeyAttribute)pro.GetCustomAttribute(typeof(KeyAttribute));
            if (atb1 != null)
              _return += $"PRIMARY KEY UNIQUE, \n";
            else
              _return += $"NOT NULL, \n";
          } else if (pro.PropertyType == typeof(short?)) {
            _return += $"   {pro.Name} SHORT, \n";
          } else if (pro.PropertyType == typeof(long)) {
            _return += $"   {pro.Name} LONG NOT NULL, \n";
          } else if (pro.PropertyType == typeof(long?)) {
            _return += $"   {pro.Name} LONG, \n";
          } else if (pro.PropertyType == typeof(int)) {
            _return += $"   {pro.Name} INTEGER ";

            var atb1 = (KeyAttribute)pro.GetCustomAttribute(typeof(KeyAttribute));
            if (atb1 != null) {
              var atb2 = (DatabaseGeneratedAttribute)pro.GetCustomAttribute(typeof(DatabaseGeneratedAttribute));
              if (atb2 != null && atb2.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity)
                _return += $"PRIMARY KEY AUTOINCREMENT NOT NULL, \n";
              else
                _return += $"UNIQUE PRIMARY KEY NOT NULL, \n";
            } else
              _return += $"NOT NULL, \n";
          } else if (pro.PropertyType == typeof(int?)) {
            _return += $"   {pro.Name} INTEGER, \n";
          } else if (pro.PropertyType == typeof(double)) {
            _return += $"   {pro.Name} DOUBLE NOT NULL, \n";
          } else if (pro.PropertyType == typeof(double?)) {
            _return += $"   {pro.Name} DOUBLE, \n";
          } else if (pro.PropertyType == typeof(DateTime)) {
            _return += $"   {pro.Name} DATETIME NOT NULL, \n";
          } else if (pro.PropertyType == typeof(DateTime?)) {
            _return += $"   {pro.Name} DATETIME, \n";
          } else if (pro.PropertyType.IsEnum) {
            _return += $"   {pro.Name} INT ";

            var atb1 = (KeyAttribute)pro.GetCustomAttribute(typeof(KeyAttribute));
            if (atb1 != null)
              _return += $"PRIMARY KEY NOT NULL, \n";
            else
              _return += $"NOT NULL, \n";
          } else if (pro.PropertyType == typeof(bool)) {
            _return += $"   {pro.Name} TINYINT(1) NOT NULL, \n";
          } else if (pro.PropertyType == typeof(bool?)) {
            _return += $"   {pro.Name} TINYINT(1), \n";
          } else {
            var atb1 = (ForeignKeyAttribute)pro.GetCustomAttribute(typeof(ForeignKeyAttribute));
            if (atb1 != null) {
              fks +=
                  $"      CONSTRAINT FK_{table.Name}_{atb1.Name} FOREIGN KEY ({atb1.Name})\n" +
                  $"      REFERENCES {pro.PropertyType.Name}(ID), \n";
            }
          }
        }

        if (string.IsNullOrEmpty(fks))
          return _return = _return.Substring(0, _return.Length - 3) + " )";
        else
          return _return = _return + fks.Substring(0, fks.Length - 3) + " )";
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Criar Query para montar tabelas");
        return string.Empty;
      }
    }
  }
}
