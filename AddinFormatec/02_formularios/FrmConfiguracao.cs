using LmCorbieUI;
using LmCorbieUI.LmForms;
using LmCorbieUI.Metodos;
using System;
using System.IO;
using System.Windows.Forms;

namespace AddinFormatec {
  public partial class FrmConfiguracao : LmSingleForm {

    public FrmConfiguracao() {
      InitializeComponent();

      tbcConfig.SelectedIndex = 0;

      btnSalvar.Tag = btnSalvar.BackColor;
    }

    private void FrmConfiguracao_Load(object sender, EventArgs e) {
      try {
        Config_db.Carregar();

        txtBaseDados.Text = Config_db.LocalBaseDados;

        if (!string.IsNullOrEmpty(Config_db.LocalBaseDados))
          CarregarCampos();
      } catch (Exception ex) {
        MsgBox.Show($"Erro ao Carregar Dados\n\n{ex.Message}", "Addin LM Projetos",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void CarregarCampos() {
      SemearBase.CriarTabelas();

      Config.Carregar();
      PostgresAccess.Carregar();
      FormatoFolha.Carregar();
      MateriaPrima.Carregar();

      txtA4R.Text = FormatoFolha.model.FormatoA4R;
      txtA4P.Text = FormatoFolha.model.FormatoA4P;
      txtA3.Text = FormatoFolha.model.FormatoA3;
      txtA2.Text = FormatoFolha.model.FormatoA2;
      txtA1.Text = FormatoFolha.model.FormatoA1;
      txtA0.Text = FormatoFolha.model.FormatoA0;
      lblA4R.Text = FormatoFolha.model.TemplateA4R;
      lblA4P.Text = FormatoFolha.model.TemplateA4P;
      lblA3.Text = FormatoFolha.model.TemplateA3;
      lblA2.Text = FormatoFolha.model.TemplateA2;
      lblA1.Text = FormatoFolha.model.TemplateA1;
      lblA0.Text = FormatoFolha.model.TemplateA0;

      txtListaMotagem.Text = Config.model.ListaMontagem;
      txtListaSoldagem.Text = Config.model.ListaPeca;
      txtBaseDadosMat.Text = Config.model.LocalBaseDadosMat;
      txtPastaPcp.Text = Config.model.LocalDesenhosPCP;

      txtDatabsePost.Text = PostgresAccess.model.Database;
      txtPortaPost.Text = PostgresAccess.model.Port;
      txtServerPost.Text = PostgresAccess.model.Server;
      txtUserPost.Text = PostgresAccess.model.User;
      txtPassPost.Text = PostgresAccess.model.Pass;

      if (!string.IsNullOrEmpty(Config_db.LocalBaseDados))
        tbcConfig.Enabled = pnlButton.Enabled = true;
    }

    private void BtnSalvar_Click(object sender, EventArgs e) {
      if (Controles.PossuiCamposInvalidos(this)) {
        Toast.Warning("Preencha Todos os Campos Obrigatórios!.");
        return;
      }

      FormatoFolha.model.FormatoA4R = txtA4R.Text;
      FormatoFolha.model.FormatoA4P = txtA4P.Text;
      FormatoFolha.model.FormatoA3 = txtA3.Text;
      FormatoFolha.model.FormatoA2 = txtA2.Text;
      FormatoFolha.model.FormatoA1 = txtA1.Text;
      FormatoFolha.model.FormatoA0 = txtA0.Text;
      FormatoFolha.model.TemplateA4R = lblA4R.Text;
      FormatoFolha.model.TemplateA4P = lblA4P.Text;
      FormatoFolha.model.TemplateA3 = lblA3.Text;
      FormatoFolha.model.TemplateA2 = lblA2.Text;
      FormatoFolha.model.TemplateA1 = lblA1.Text;
      FormatoFolha.model.TemplateA0 = lblA0.Text;
      FormatoFolha.Salvar();

      Config.model.ListaPeca = txtListaSoldagem.Text;
      Config.model.ListaMontagem = txtListaMotagem.Text;
      Config.model.LocalBaseDadosMat = txtBaseDadosMat.Text;
      Config.model.LocalDesenhosPCP = txtPastaPcp.Text;
      Config.Salvar();

      PostgresAccess.model.Database = txtDatabsePost.Text;
      PostgresAccess.model.Port = txtPortaPost.Text;
      PostgresAccess.model.Server = txtServerPost.Text;
      PostgresAccess.model.User = txtUserPost.Text;
      PostgresAccess.model.Pass = txtPassPost.Text;
      PostgresAccess.Salvar();

      Toast.Info("Salvo com Sucesso!");
      this.Close();
    }

    private void TxtBaseDados_ButtonClickF7(object sender, EventArgs e) {
      Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog {
        IsFolderPicker = true,

        Title = "Selecionar Diretório para Salvar Base de Dados"
      };

      if (dialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
        txtBaseDados.Text = dialog.FileName;
        Config_db.LocalBaseDados = txtBaseDados.Text;
        Config_db.Salvar();
        CarregarCampos();
      }
    }

    private void BtnA4R_Click(object sender, EventArgs e) {
      txtA4R.Text = SelecionarFormato("A4 Retrato");
      if (!string.IsNullOrEmpty(txtA4R.Text))
        lblA4R.Text = Path.GetFileNameWithoutExtension(txtA4R.Text) + ".slddrt";
    }

    private void BtnA4P_Click(object sender, EventArgs e) {
      txtA4P.Text = SelecionarFormato("A4 Paisagem");
      if (!string.IsNullOrEmpty(txtA4P.Text))
        lblA4P.Text = Path.GetFileNameWithoutExtension(txtA4P.Text) + ".slddrt";
    }

    private void BtnA3_Click(object sender, EventArgs e) {
      txtA3.Text = SelecionarFormato("A3");
      if (!string.IsNullOrEmpty(txtA3.Text))
        lblA3.Text = Path.GetFileNameWithoutExtension(txtA3.Text) + ".slddrt";
    }

    private void BtnA2_Click(object sender, EventArgs e) {
      txtA2.Text = SelecionarFormato("A2");
      if (!string.IsNullOrEmpty(txtA2.Text))
        lblA2.Text = Path.GetFileNameWithoutExtension(txtA2.Text) + ".slddrt";
    }

    private void BtnA1_Click(object sender, EventArgs e) {
      txtA1.Text = SelecionarFormato("A1");
      if (!string.IsNullOrEmpty(txtA1.Text))
        lblA1.Text = Path.GetFileNameWithoutExtension(txtA1.Text) + ".slddrt";
    }

    private void BtnA0_Click(object sender, EventArgs e) {
      txtA0.Text = SelecionarFormato("A0");
      if (!string.IsNullOrEmpty(txtA0.Text))
        lblA0.Text = Path.GetFileNameWithoutExtension(txtA0.Text) + ".slddrt";
    }

    private void BtnPcp_Click(object sender, EventArgs e) {
      Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog dialog = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog {
        IsFolderPicker = true,

        Title = "Selecionar Diretório para Salvar Desenhos PCP"
      };

      if (dialog.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok) {
        txtPastaPcp.Text = dialog.FileName;
      }
    }

    private void TxtListaMotagem_ButtonClickF7(object sender, EventArgs e) {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.RestoreDirectory = true;
      ofd.Title = "Selecionar Lista de Montagem";
      ofd.Filter = "Lista Montagem|*.sldbomtbt|All files|*.*";
      ofd.DefaultExt = "sldbomtbt";

      if (ofd.ShowDialog() == DialogResult.OK)
        txtListaMotagem.Text = ofd.FileName;
    }

    private void TxtListaSoldagem_ButtonClickF7(object sender, EventArgs e) {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.RestoreDirectory = true;
      ofd.Title = "Selecionar Lista de Corte/Soldagem";
      ofd.Filter = "Lista Corte/Soldagem|*.sldwldtbt|All files|*.*";
      ofd.DefaultExt = "sldwldtbt";

      if (ofd.ShowDialog() == DialogResult.OK)
        txtListaSoldagem.Text = ofd.FileName;
    }

    private void TxtBaseDadosMat_ButtonClickF7(object sender, EventArgs e) {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.RestoreDirectory = true;
      ofd.Title = $"Selecionar Base Dados Material";
      ofd.Filter = "Materiais Solidworks|*.sldmat";
      ofd.DefaultExt = "sldmat";

      if (ofd.ShowDialog() == DialogResult.OK)
        txtBaseDadosMat.Text = ofd.FileName;
    }

    private string SelecionarFormato(string formato) {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.RestoreDirectory = true;
      ofd.Title = $"Selecionar Formato de Folha {formato}";
      ofd.Filter = "Templates Desenho|*.drwdot|All files|*.*";
      ofd.DefaultExt = "drwdot";

      if (ofd.ShowDialog() == DialogResult.OK)
        return ofd.FileName;
      else
        return string.Empty;
    }

    private void BtnTesteConexao_Click(object sender, EventArgs e) {
      try {
        MsgBox.ShowWaitMessage("Testando Conexão. Aguarde...");

        PostgresAccess.model.Database = txtDatabsePost.Text;
        PostgresAccess.model.Port = txtPortaPost.Text;
        PostgresAccess.model.Server = txtServerPost.Text;
        PostgresAccess.model.User = txtUserPost.Text;
        PostgresAccess.model.Pass = txtPassPost.Text;
        PostgresAccess.Salvar();

        using (var connection = ConexaoPgSql.GetConexao()) {
          connection.Open();

          Toast.Success("Conectado com Sucesso!"); 

          connection.Close();
        }
      } catch (Exception ex) {
        LmException.ShowException(ex, "Erro ao Testar Conexão PostgreSQL");
      } finally {
        MsgBox.CloseWaitMessage();
      }
    }
  }
}
