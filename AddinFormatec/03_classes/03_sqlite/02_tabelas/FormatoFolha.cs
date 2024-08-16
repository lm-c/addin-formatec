using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LmCorbieUI;
using System.Windows.Forms;
using System;
using System.Linq;

namespace AddinFormatec {
  internal class FormatoFolha {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [DataObjectField(true, false)]
    public int Id { get; set; }

    [StringLength(250)]
    public string FormatoA4R { get; set; } = "";

    [StringLength(250)]
    public string FormatoA4P { get; set; } = "";

    [StringLength(250)]
    public string FormatoA3 { get; set; } = "";

    [StringLength(250)]
    public string FormatoA2 { get; set; } = "";

    [StringLength(250)]
    public string FormatoA1 { get; set; } = "";

    [StringLength(50)]
    public string FormatoA0 { get; set; } = "";

    [StringLength(50)]
    public string TemplateA4R { get; set; } = "";

    [StringLength(50)]
    public string TemplateA4P { get; set; } = "";

    [StringLength(50)]
    public string TemplateA3 { get; set; } = "";

    [StringLength(50)]
    public string TemplateA2 { get; set; } = "";

    [StringLength(50)]
    public string TemplateA1 { get; set; } = "";

    [StringLength(50)]
    public string TemplateA0 { get; set; } = "";


    public static FormatoFolha model = new FormatoFolha();

    public static void Salvar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          var valPredef = db.FormatoFolha.FirstOrDefault();

          if (valPredef == null) {
            model = new FormatoFolha();
            model.Id = 1;
            db.FormatoFolha.Add(model);
            db.SaveChanges();
          } else {
            valPredef.Id = model.Id;
            valPredef.FormatoA4R = model.FormatoA4R;
            valPredef.FormatoA4P = model.FormatoA4P;
            valPredef.FormatoA3 = model.FormatoA3;
            valPredef.FormatoA2 = model.FormatoA2;
            valPredef.FormatoA1 = model.FormatoA1;
            valPredef.FormatoA0 = model.FormatoA0;
            valPredef.TemplateA4R = model.TemplateA4R;
            valPredef.TemplateA4P = model.TemplateA4P;
            valPredef.TemplateA3 = model.TemplateA3;
            valPredef.TemplateA2 = model.TemplateA2;
            valPredef.TemplateA1 = model.TemplateA1;
            valPredef.TemplateA0 = model.TemplateA0;
          }

          db.SaveChanges();
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Salvar Formatos de Folha, algumas predefinições de usuário podem não ter sidas salvas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }

    public static void Carregar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          model = db.FormatoFolha.FirstOrDefault();

          if (model == null) {
            model = new FormatoFolha();
            model.Id = 1;
            db.FormatoFolha.Add(model);
            db.SaveChanges();
          }
        }
      } catch (Exception ex) {
        Toast.Warning("Aconteceu um Erro ao Retornar Formatos de Folha, algumas predefinições de usuário podem não ter sidas carregadas.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
      }
    }

  }
}
