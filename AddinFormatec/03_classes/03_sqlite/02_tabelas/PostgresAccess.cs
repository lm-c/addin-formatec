using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LmCorbieUI;
using System.Windows.Forms;
using System;
using System.Linq;

namespace AddinFormatec {
  internal class PostgresAccess {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [DataObjectField(true, false)]
    public int Id { get; set; }

    [StringLength(50)]
    public string Database { get; set; } = "formatec";

    [StringLength(50)]
    public string Port { get; set; } = "5432";

    [StringLength(50)]
    public string Server { get; set; } = "10.1.1.4";

    [StringLength(50)]
    public string User { get; set; } = "postgres";

    [StringLength(50)]
    public string Pass { get; set; } = "postgres";


    public static PostgresAccess model = new PostgresAccess();

    public static void Salvar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          var valPredef = db.PostgresAccess.FirstOrDefault();

          if (valPredef == null) {
            model = new PostgresAccess();
            model.Id = 1;
            db.PostgresAccess.Add(model);
            db.SaveChanges();
          } else {
            valPredef.Id = model.Id;
            valPredef.Database = model.Database;
            valPredef.Port = model.Port;
            valPredef.Server = model.Server;
            valPredef.User = model.User;
            valPredef.Pass = model.Pass;
          }

          db.SaveChanges();
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Salvar Configurações do Postgress, algumas predefinições de usuário podem não ter sidas salvas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }

    public static void Carregar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          model = db.PostgresAccess.FirstOrDefault();

          if (model == null) {
            model = new PostgresAccess();
            model.Id = 1;
            db.PostgresAccess.Add(model);
            db.SaveChanges();
          }
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Retornar Configurações do Postgress, algumas predefinições de usuário podem não ter sidas carregadas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }
  }
}
