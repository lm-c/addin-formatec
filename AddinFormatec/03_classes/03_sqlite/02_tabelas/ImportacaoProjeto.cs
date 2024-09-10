using LmCorbieUI;
using LmCorbieUI.Metodos.AtributosCustomizados;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Forms;

namespace AddinFormatec {
  public class ImportacaoProjeto {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [DataObjectField(true, false)]
    public int ID { get; set; }

    [StringLength(16)]
    public string Codigo { get; set; }

    [DataObjectField(false, true)]
    [StringLength(50)]
    public string Descricao { get; set; }

    public bool ImportacaoConcluida { get; set; }
    
    public long CadContIni { get; set; }
    
    public long CadContFim { get; set; }

    public static ImportacaoProjeto model = new ImportacaoProjeto();

    public static void Salvar() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          if (model.ID == 0) {
            model = new ImportacaoProjeto {
              Codigo = model.Codigo,
              Descricao = model.Descricao,
              ImportacaoConcluida = false,
            };
            db.ImportacaoProjeto.Add(model);
            db.SaveChanges();
          } else {
            var modelAlt = db.ImportacaoProjeto.FirstOrDefault(x => x.ID == model.ID);
            modelAlt.CadContIni = model.CadContIni;
            modelAlt.CadContFim = model.CadContFim;
            modelAlt.ImportacaoConcluida = model.ImportacaoConcluida;

            db.SaveChanges();
          }
        }
      } catch (Exception ex) {
        MsgBox.Show("Erro ao Salvar.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static bool ImportacaoEmAndamento(out string codigo, out string descricao) {
      var _return = false;
      codigo = string.Empty;
      descricao = string.Empty;
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          var imp = db.ImportacaoProjeto.FirstOrDefault(x => !x.ImportacaoConcluida);

          if (imp != null) {
            _return = true;
            codigo = imp.Codigo;
            descricao = imp.Descricao;
          }
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao verificar andamento importação");
      }
      return _return;
    }

    public static bool ProjetoImportado(string codigo) {
      var _return = false;
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          _return = db.ImportacaoProjeto.Any(x => x.Codigo == codigo);
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao verificar se projeto já foi importado");
      }
      return _return;
    }

    public static void Excluir() {
      try {
        using (SQLiteContexto db = new SQLiteContexto()) {
          db.ImportacaoProjeto.Remove(db.ImportacaoProjeto.FirstOrDefault(x => x.ID == model.ID));
          db.SaveChanges();
          model = new ImportacaoProjeto();
        }
      } catch (Exception ex) {
        MsgBox.Show("Erro ao excluir dados importação.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

  }
}
