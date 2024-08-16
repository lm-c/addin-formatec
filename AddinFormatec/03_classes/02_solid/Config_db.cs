using LmCorbieUI;
using System;
using System.IO;
using System.Windows.Forms;

namespace AddinFormatec {
  public class Config_db {
    public static string LocalBaseDados { get; set; } = "";

    private static readonly string diretorio = Environment.ExpandEnvironmentVariables("%AppData%") + "\\LM Projetos\\Addin\\";
    private static readonly string filename = diretorio + "Config_DB.frmt";

    public static void Salvar() {
      if (!System.IO.Directory.Exists(diretorio))
        System.IO.Directory.CreateDirectory(diretorio);

      try {

        if (!string.IsNullOrEmpty(LocalBaseDados) && !LocalBaseDados.EndsWith("\\"))
          LocalBaseDados += "\\";

        string texto = LocalBaseDados;
        File.WriteAllText(filename, texto);
      } catch (Exception ex) {
        MsgBox.Show("Erro ao Salvar Configurações.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static void Carregar() {
      if (System.IO.File.Exists(filename)) {
        try {
          string texto = File.ReadAllText(filename);

          LocalBaseDados = texto;

          if (!string.IsNullOrEmpty(LocalBaseDados) && !LocalBaseDados.EndsWith("\\"))
            LocalBaseDados += "\\";
        } catch (Exception ex) {
          throw ex;
          //MsgBox.Show("Erro ao Carregar Configuração.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      } else {
        Salvar();
      }
    }
  }
}

