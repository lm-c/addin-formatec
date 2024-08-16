using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using LmCorbieUI;
using System.Windows.Forms;
using System;
using System.Linq;
using SolidWorks.Interop.swconst;

namespace AddinFormatec {
  internal class CodigoMaquina {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DataObjectField(true, false)]
    public int Id { get; set; }

    [StringLength(20)]
    public string Sigla { get; set; } = string.Empty;

    public long Codigo { get; set; }

    public swDocumentTypes_e swDocType { get; set; } 

    [StringLength(250)]
    public string Descricao { get; set; }

    public static string GerarCodigo(string sigla, string descricao, swDocumentTypes_e swDocType) {
      string _return = string.Empty;

      try {
        using (SQLiteContexto db = new SQLiteContexto()) {

          var ultRegistro = db.CodigoMaquina.Where(x => x.Sigla == sigla && x.swDocType == swDocType).OrderByDescending(x => x.Codigo).FirstOrDefault();
          var model = new CodigoMaquina();

          if (ultRegistro == null) {
            MsgBox.CloseWaitMessage();
            var primeiroCod = MsgBox.ImputBox($"Informar primeiro código para sigla '{sigla}'",
              lmValueType: LmCorbieUI.Design.LmValueType.Num_Real);

            if (!string.IsNullOrEmpty(primeiroCod)) {
              model = new CodigoMaquina {
                Codigo = Convert.ToInt64(primeiroCod),
                Sigla = sigla,
                swDocType = swDocType,
                Descricao = descricao,
              };
              db.CodigoMaquina.Add(model);
              db.SaveChanges();
            } else
              return string.Empty;
          } else {
            model = new CodigoMaquina {
              Codigo = ultRegistro.Codigo + 1,
              Sigla = sigla,
              swDocType = swDocType,
              Descricao = descricao,
            };
            db.CodigoMaquina.Add(model);
            db.SaveChanges();
          }

          _return = $"{sigla}-{model.Codigo}";
        }
      } catch (Exception ex) {
        Toast.Warning("Erro ao gerar código novo.\n" +
            "-------------------------------------\n" +
            "" + ex.Message);
        _return = string.Empty;
      }

      return _return;
    }
  }
}
