using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LmCorbieUI;
using System.Windows.Forms;
using System;
using System.Linq;

namespace AddinFormatec {
  internal class Config {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [DataObjectField(true, false)]
    public int Id { get; set; }

    [StringLength(250)]
    public string ListaPeca { get; set; }

    [StringLength(250)]
    public string ListaMontagem { get; set; }

    [StringLength(250)]
    public string LocalBaseDadosMat { get; set; }

    [StringLength(250)]
    public string LocalDesenhosPCP { get; set; }


    public static Config model = new Config();

    public static void Salvar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          var valPredef = db.Config.FirstOrDefault();

          if (valPredef == null) {
            model = new Config();
            model.Id = 1;
            db.Config.Add(model);
            db.SaveChanges();
          } else {
            valPredef.Id = model.Id;
            valPredef.ListaMontagem = model.ListaMontagem;
            valPredef.ListaPeca = model.ListaPeca;
            valPredef.LocalDesenhosPCP = model.LocalDesenhosPCP;
            valPredef.LocalBaseDadosMat = model.LocalBaseDadosMat;
          }

          db.SaveChanges();
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Salvar Configurações do Sistema, algumas predefinições de usuário podem não ter sidas salvas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }

    public static void Carregar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          model = db.Config.FirstOrDefault();

          if (model == null) {
            model = new Config();
            model.Id = 1;
            db.Config.Add(model);
            db.SaveChanges();
          }
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Retornar Configurações do Sistema, algumas predefinições de usuário podem não ter sidas carregadas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }
  }
}
