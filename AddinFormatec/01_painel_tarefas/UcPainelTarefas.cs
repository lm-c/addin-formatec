using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using LmCorbieUI.Controls;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LmCorbieUI;
using AddinFormatec;
using System.IO;
using System.Drawing;

namespace AddinFormatec {
  [ComVisible(true)]
  [ProgId(SWTASKPANE_PROGID)]
  public partial class UcPainelTarefas : UserControl {
    public const string SWTASKPANE_PROGID = "AddinFormatec.SWTaskPanel_SwAddin_Formatec";

    static UcPainelTarefas instancia;

    public static UcPainelTarefas Instancia {
      get {
        if (instancia == null)
          instancia = new UcPainelTarefas();

        return instancia;
      }
    }

    public UcPainelTarefas() {
      InitializeComponent();

      string imagePath = @"C:\Program Files\SOLIDWORKS Corp\SOLIDWORKS\01 - Addin Formatec\LOGO_FORMATEC_FUNDO.png";

      if (File.Exists(imagePath)) {
        pnlMain.BackgroundImage = Image.FromFile(imagePath);
      }
    }

    private void UcPainelTarefas_Load(object sender, EventArgs e) {
      instancia = this;

      string nomeSistem = "Addin Formatec";
      string pastaRaiz = "LM Projetos Data";
      string cliente = "Formatec";
      string mail = "michalakleo@gmail.com";

      ValPadrao.DefinirPadrao(pastaRaiz, nomeSistem, cliente, mail);

      Config_db.Carregar();
      InfoSetting.Carregar();

      if (!string.IsNullOrEmpty(Config_db.LocalBaseDados)) {
        SemearBase.CriarTabelas();
        Config.Carregar();
        PostgresAccess.Carregar();
        FormatoFolha.Carregar();
        MateriaPrima.Carregar();
      }
    }

    private void AbrirFormFilho(Form frm) {
      if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
        MsConfig_Click(null, null);

      if (!pnlMain.Controls.ContainsKey(frm.Name)) {
        frm.Dock = System.Windows.Forms.DockStyle.Fill;
        frm.TopLevel = false;
        frm.Parent = pnlMain;
        frm.Show();
        pnlMain.Controls.Add(frm);
        frm.BringToFront();
      } else {
        pnlMain.Controls[frm.Name].BringToFront();
      }
    }

    private void MsOperacao_Click(object sender, EventArgs e) {
      FrmProcesso frm = new FrmProcesso();
      AbrirFormFilho(frm);
    }

    private void MsProperties_Click(object sender, EventArgs e) {
      FrmFileProperties frm = new FrmFileProperties();
      AbrirFormFilho(frm);
    }

    private void MsDesenho_Click(object sender, EventArgs e) {
      msMenuDesenho.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsCriarDesenho_Click(object sender, EventArgs e) {
      var frm = new FrmDesenho();
      AbrirFormFilho(frm);
    }

    private void MsAtualizarDesenho_Click(object sender, EventArgs e) {
      var frm = new FrmFormatosAtualizar();
      AbrirFormFilho(frm);
    }

    private void MsImprimir_Click(object sender, EventArgs e) {
      FrmExportar frm = new FrmExportar();
      AbrirFormFilho(frm);
    }

    private void MsCadastros_Click(object sender, EventArgs e) {
      msMenuCadastro.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsCodigoCad_Click(object sender, EventArgs e) {
      FrmCodigoCad frm = new FrmCodigoCad();
      AbrirFormFilho(frm);
    }

    private void MsMateriaPrimaCad_Click(object sender, EventArgs e) {
      if (string.IsNullOrEmpty(Config_db.LocalBaseDados))
        MsConfig_Click(null, null);

      FrmMateriaPrimaCad frm = new FrmMateriaPrimaCad();
      frm.ShowDialog();

    }

    private void MsImportarFabril_Click(object sender, EventArgs e) {
      msMenuFabril.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsCadastroProduto_Click(object sender, EventArgs e) {
      FrmProdutoImport frm = new FrmProdutoImport();
      AbrirFormFilho(frm);
    }

    private void MsCadastroEstruturaProduto_Click(object sender, EventArgs e) {
      Toast.Warning("Em Desenvolvimento");

    }

    private void MsProduto_Click(object sender, EventArgs e) {
      FrmProdutoCad frm = new FrmProdutoCad();
      AbrirFormFilho(frm);
    }

    private void MsRelatorios_Click(object sender, EventArgs e) {
      msMenuRelatorio.Show((LmMenuItem)sender, ((LmMenuItem)sender).Width, ((LmMenuItem)sender).Height);
    }

    private void MsPastaFormas_Click(object sender, EventArgs e) {
      FrmPastaFormas frm = new FrmPastaFormas();
      AbrirFormFilho(frm);
    }

    private void MsPastaMaquinas_Click(object sender, EventArgs e) {
      FrmPastaMaquinas frm = new FrmPastaMaquinas();
      AbrirFormFilho(frm);
    }

    private void MsProcessoFabricacao_Click(object sender, EventArgs e) {
      FrmPastaProcessos frm = new FrmPastaProcessos();
      AbrirFormFilho(frm);
    }

    private void MsPackList_Click(object sender, EventArgs e) {
      FrmPackList frm = new FrmPackList();
      AbrirFormFilho(frm);
    }

    private void MsConfig_Click(object sender, EventArgs e) {
      FrmConfiguracao frm = new FrmConfiguracao();
      frm.ShowDialog();
    }
  }
}
