using LmCorbieUI;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AddinFormatec {
  public class InfoSetting {

    public static bool AddDenominacaoTodasConfig = false;
    public static string UltimaSiglaUsada = "";

    private static readonly string diretorio = Environment.ExpandEnvironmentVariables("%AppData%") + "\\LM Projetos\\Addin\\";
    private static readonly string filename = diretorio + "InfoSetting.frmt";

    public static void Salvar() {
      if (!System.IO.Directory.Exists(diretorio))
        System.IO.Directory.CreateDirectory(diretorio);

      try {
        string texto =
            $"{AddDenominacaoTodasConfig}^" +
            $"{UltimaSiglaUsada}" ;

        File.WriteAllText(filename, texto);
      } catch (Exception ex) {
        // MsgBox.Show("Erro ao Salvar Configurações.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    public static void Carregar() {
      if (System.IO.File.Exists(filename)) {
        try {
          string texto = File.ReadAllText(filename);

          var spl = texto.Split('^').ToList();

          AddDenominacaoTodasConfig = Convert.ToBoolean(spl[0].Trim());
          UltimaSiglaUsada = spl[1].Trim();
        } catch (Exception ex) {
          // MsgBox.Show("Erro ao Carregar Configuração 2.", "Addin LM Projetos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      } else {
        Salvar();
      }
    }

  }
}
