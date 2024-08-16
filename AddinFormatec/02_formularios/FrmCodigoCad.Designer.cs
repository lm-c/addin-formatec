namespace AddinFormatec
{
    partial class FrmCodigoCad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodigoCad));
      this.txtSigla = new LmCorbieUI.Controls.LmTextBox();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.cmxLabel8 = new LmCorbieUI.Controls.LmLabel();
      this.pnlControl = new LmCorbieUI.Controls.LmPanel();
      this.lblPecasProc = new LmCorbieUI.Controls.LmLabel();
      this.btnProximo = new LmCorbieUI.Controls.LmButton();
      this.btnVoltar = new LmCorbieUI.Controls.LmButton();
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnCarrProcess = new LmCorbieUI.Controls.LmButton();
      this.cmxToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.dgv = new LmCorbieUI.Controls.LmDataGridView();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.pnlDados = new LmCorbieUI.Controls.LmPanel();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.ckbAddDenom = new LmCorbieUI.Controls.LmCheckBox();
      this.pnlControl.SuspendLayout();
      this.pnlDados.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtSigla
      // 
      this.txtSigla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtSigla.BorderRadius = 15;
      this.txtSigla.BorderSize = 2;
      this.txtSigla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
      this.txtSigla.F7ToolTipText = "";
      this.txtSigla.F8ToolTipText = null;
      this.txtSigla.F9ToolTipText = null;
      this.txtSigla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtSigla.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtSigla.IconF7")));
      this.txtSigla.IconToolTipText = null;
      this.txtSigla.Lines = new string[0];
      this.txtSigla.Location = new System.Drawing.Point(2, 25);
      this.txtSigla.MaxLength = 20;
      this.txtSigla.Name = "txtSigla";
      this.txtSigla.PasswordChar = '\0';
      this.txtSigla.Propriedade = null;
      this.txtSigla.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtSigla.SelectedText = "";
      this.txtSigla.SelectionLength = 0;
      this.txtSigla.SelectionStart = 0;
      this.txtSigla.ShortcutsEnabled = true;
      this.txtSigla.Size = new System.Drawing.Size(133, 31);
      this.txtSigla.TabIndex = 0;
      this.txtSigla.UnderlinedStyle = false;
      this.txtSigla.UseSelectable = true;
      this.txtSigla.Valor_Decimais = ((short)(0));
      this.txtSigla.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtSigla.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtSigla.Leave += new System.EventHandler(this.TxtSigla_Leave);
      // 
      // txtDescricao
      // 
      this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtDescricao.BorderRadius = 15;
      this.txtDescricao.BorderSize = 2;
      this.txtDescricao.F7ToolTipText = null;
      this.txtDescricao.F8ToolTipText = null;
      this.txtDescricao.F9ToolTipText = null;
      this.txtDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtDescricao.IconF7 = null;
      this.txtDescricao.IconToolTipText = null;
      this.txtDescricao.Lines = new string[0];
      this.txtDescricao.Location = new System.Drawing.Point(2, 78);
      this.txtDescricao.MaxLength = 50;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = null;
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.Size = new System.Drawing.Size(278, 31);
      this.txtDescricao.TabIndex = 1;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtDescricao.Leave += new System.EventHandler(this.TxtDenominacao_Leave);
      // 
      // cmxLabel8
      // 
      this.cmxLabel8.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel8.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel8.Location = new System.Drawing.Point(2, 62);
      this.cmxLabel8.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel8.Name = "cmxLabel8";
      this.cmxLabel8.Size = new System.Drawing.Size(62, 15);
      this.cmxLabel8.TabIndex = 24;
      this.cmxLabel8.Text = "Descrição";
      this.cmxLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pnlControl
      // 
      this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.pnlControl.Controls.Add(this.lblPecasProc);
      this.pnlControl.Controls.Add(this.btnProximo);
      this.pnlControl.Controls.Add(this.btnVoltar);
      this.pnlControl.Controls.Add(this.btnClose);
      this.pnlControl.Controls.Add(this.btnSalvar);
      this.pnlControl.Controls.Add(this.btnCarrProcess);
      this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlControl.IsPanelMenu = false;
      this.pnlControl.Location = new System.Drawing.Point(0, 145);
      this.pnlControl.Name = "pnlControl";
      this.pnlControl.Size = new System.Drawing.Size(288, 59);
      this.pnlControl.TabIndex = 1;
      // 
      // lblPecasProc
      // 
      this.lblPecasProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPecasProc.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblPecasProc.Location = new System.Drawing.Point(3, 38);
      this.lblPecasProc.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
      this.lblPecasProc.Name = "lblPecasProc";
      this.lblPecasProc.Size = new System.Drawing.Size(278, 15);
      this.lblPecasProc.TabIndex = 12;
      this.lblPecasProc.Text = "Item 0 de 0 - 0%";
      this.lblPecasProc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnProximo
      // 
      this.btnProximo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnProximo.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnProximo.BorderRadius = 15;
      this.btnProximo.BorderSize = 0;
      this.btnProximo.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnProximo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
      this.btnProximo.Location = new System.Drawing.Point(105, 3);
      this.btnProximo.Margin = new System.Windows.Forms.Padding(1);
      this.btnProximo.Name = "btnProximo";
      this.btnProximo.Size = new System.Drawing.Size(31, 31);
      this.btnProximo.TabIndex = 3;
      this.btnProximo.Tag = "Avançar";
      this.btnProximo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnProximo, "Próxima peça");
      this.btnProximo.UseVisualStyleBackColor = false;
      this.btnProximo.Click += new System.EventHandler(this.BtnProximo_Click);
      // 
      // btnVoltar
      // 
      this.btnVoltar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnVoltar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnVoltar.BorderRadius = 15;
      this.btnVoltar.BorderSize = 0;
      this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
      this.btnVoltar.Location = new System.Drawing.Point(72, 3);
      this.btnVoltar.Margin = new System.Windows.Forms.Padding(1);
      this.btnVoltar.Name = "btnVoltar";
      this.btnVoltar.Size = new System.Drawing.Size(31, 31);
      this.btnVoltar.TabIndex = 2;
      this.btnVoltar.Tag = "Voltar";
      this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnVoltar, "Peça anterior");
      this.btnVoltar.UseVisualStyleBackColor = false;
      this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
      // 
      // btnClose
      // 
      this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnClose.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnClose.BorderRadius = 15;
      this.btnClose.BorderSize = 0;
      this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
      this.btnClose.Location = new System.Drawing.Point(250, 3);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(31, 31);
      this.btnClose.TabIndex = 4;
      this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnClose, "Fechar Janela");
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
      // 
      // btnSalvar
      // 
      this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnSalvar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnSalvar.BorderRadius = 15;
      this.btnSalvar.BorderSize = 0;
      this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
      this.btnSalvar.Location = new System.Drawing.Point(36, 3);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 1;
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnSalvar, "Salvar Processos");
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // btnCarrProcess
      // 
      this.btnCarrProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnCarrProcess.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnCarrProcess.BorderRadius = 15;
      this.btnCarrProcess.BorderSize = 0;
      this.btnCarrProcess.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCarrProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCarrProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrProcess.Image")));
      this.btnCarrProcess.Location = new System.Drawing.Point(3, 3);
      this.btnCarrProcess.Margin = new System.Windows.Forms.Padding(1);
      this.btnCarrProcess.Name = "btnCarrProcess";
      this.btnCarrProcess.Size = new System.Drawing.Size(31, 31);
      this.btnCarrProcess.TabIndex = 0;
      this.cmxToolTip1.SetToolTip(this.btnCarrProcess, "Carregar componentes\r\npara inserir processos");
      this.btnCarrProcess.UseVisualStyleBackColor = false;
      this.btnCarrProcess.Click += new System.EventHandler(this.BtnCarrProcess_Click);
      // 
      // dgv
      // 
      this.dgv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
      this.dgv.Botao1Largura = 100;
      this.dgv.Botao1Texto = "";
      this.dgv.Botao2Largura = 100;
      this.dgv.Botao2Texto = "";
      this.dgv.ColunaOrdenacaoGrid = "";
      this.dgv.ColunasBloqueadasGrid = "";
      this.dgv.ColunasOcultasGrid = "";
      this.dgv.ColunasOcultasImpressGrid = "";
      this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgv.EnabledCsvButton = true;
      this.dgv.EnabledFind = true;
      this.dgv.EnabledHideColumnsButton = true;
      this.dgv.EnabledPdfButton = true;
      this.dgv.EnabledRefreshButton = true;
      this.dgv.LimparSelecaoAposCarregar = false;
      this.dgv.Location = new System.Drawing.Point(0, 204);
      this.dgv.Margin = new System.Windows.Forms.Padding(0);
      this.dgv.MostrarRodapeBotoes = false;
      this.dgv.MostrarTotalizador = false;
      this.dgv.Name = "dgv";
      this.dgv.PermiteAutoDimensionarLinha = false;
      this.dgv.PermiteDimensionarColuna = false;
      this.dgv.PermiteOrdenarColunas = false;
      this.dgv.PermiteOrdenarLinhas = false;
      this.dgv.PermiteQuebrarLinhaCabecalho = false;
      this.dgv.PermiteSelecaoMultipla = false;
      this.dgv.PosColunasGrid = "";
      this.dgv.Size = new System.Drawing.Size(288, 256);
      this.dgv.TabIndex = 2;
      this.dgv.Texto = "";
      this.dgv.TituloRelatorio = "";
      this.dgv.UseSelectable = true;
      this.dgv.RowIndexChanged += new LmCorbieUI.Controls.LmDataGridView.RowEvent(this.Dgv_RowIndexChanged);
      // 
      // cmxLabel6
      // 
      this.cmxLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(0, 0);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(288, 24);
      this.cmxLabel6.TabIndex = 97;
      this.cmxLabel6.Text = "Cadastro de Código";
      // 
      // pnlDados
      // 
      this.pnlDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.pnlDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDados.Controls.Add(this.lmLabel1);
      this.pnlDados.Controls.Add(this.cmxLabel8);
      this.pnlDados.Controls.Add(this.txtDescricao);
      this.pnlDados.Controls.Add(this.txtSigla);
      this.pnlDados.Controls.Add(this.ckbAddDenom);
      this.pnlDados.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlDados.IsPanelMenu = false;
      this.pnlDados.Location = new System.Drawing.Point(0, 24);
      this.pnlDados.Name = "pnlDados";
      this.pnlDados.Size = new System.Drawing.Size(288, 121);
      this.pnlDados.TabIndex = 0;
      // 
      // lmLabel1
      // 
      this.lmLabel1.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel1.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel1.Location = new System.Drawing.Point(2, 9);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(51, 15);
      this.lmLabel1.TabIndex = 25;
      this.lmLabel1.Text = "Sigla";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // ckbAddDenom
      // 
      this.ckbAddDenom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ckbAddDenom.AutoSize = true;
      this.ckbAddDenom.BackColor = System.Drawing.Color.Transparent;
      this.ckbAddDenom.Checked = true;
      this.ckbAddDenom.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbAddDenom.Location = new System.Drawing.Point(124, 61);
      this.ckbAddDenom.Name = "ckbAddDenom";
      this.ckbAddDenom.Propriedade = null;
      this.ckbAddDenom.Size = new System.Drawing.Size(156, 19);
      this.ckbAddDenom.TabIndex = 26;
      this.ckbAddDenom.Text = "Add em Todas Config";
      this.ckbAddDenom.UseSelectable = true;
      this.ckbAddDenom.CheckedChanged += new System.EventHandler(this.CkbAddDenom_CheckedChanged);
      // 
      // FrmCodigoCad
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(288, 460);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.pnlControl);
      this.Controls.Add(this.pnlDados);
      this.Controls.Add(this.cmxLabel6);
      this.MinimumSize = new System.Drawing.Size(288, 300);
      this.Name = "FrmCodigoCad";
      this.Padding = new System.Windows.Forms.Padding(0);
      this.Loaded += new LmCorbieUI.LmForms.LmChildForm.FormLoad(this.FrmCodigoCad_Loaded);
      this.pnlControl.ResumeLayout(false);
      this.pnlDados.ResumeLayout(false);
      this.pnlDados.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion
        private LmCorbieUI.Controls.LmTextBox txtSigla;
        private LmCorbieUI.Controls.LmTextBox txtDescricao;
        private LmCorbieUI.Controls.LmLabel cmxLabel8;
        private LmCorbieUI.Controls.LmPanel pnlControl;
        private LmCorbieUI.Controls.LmLabel lblPecasProc;
        private LmCorbieUI.Controls.LmButton btnProximo;
        private LmCorbieUI.Controls.LmButton btnVoltar;
        private LmCorbieUI.Controls.LmButton btnClose;
        private LmCorbieUI.Controls.LmButton btnSalvar;
        private LmCorbieUI.Controls.LmButton btnCarrProcess;
        private System.Windows.Forms.ToolTip cmxToolTip1;
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private LmCorbieUI.Controls.LmDataGridView dgv;
    private LmCorbieUI.Controls.LmPanel pnlDados;
    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmCheckBox ckbAddDenom;
  }
}