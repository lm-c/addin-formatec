namespace AddinFormatec
{
    partial class FrmFileProperties
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileProperties));
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.cmxToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btnCarregar = new LmCorbieUI.Controls.LmButton();
      this.dtpDataDesenho = new LmCorbieUI.Controls.LmTextBox();
      this.txtProjetista = new LmCorbieUI.Controls.LmTextBox();
      this.cmxGroupBox1 = new LmCorbieUI.Controls.LmGroupBox();
      this.rdbPasta = new LmCorbieUI.Controls.LmRadioButton();
      this.txtNome = new LmCorbieUI.Controls.LmTextBox();
      this.rdbNome = new LmCorbieUI.Controls.LmRadioButton();
      this.cmxLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtConjunto = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.cmxGroupBox1.SuspendLayout();
      this.SuspendLayout();
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
      this.btnClose.Location = new System.Drawing.Point(313, 35);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(31, 31);
      this.btnClose.TabIndex = 2;
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
      this.btnSalvar.Location = new System.Drawing.Point(42, 35);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 1;
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnSalvar, "Aplicar Propriedades");
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // btnCarregar
      // 
      this.btnCarregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnCarregar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnCarregar.BorderRadius = 15;
      this.btnCarregar.BorderSize = 0;
      this.btnCarregar.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCarregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCarregar.Image = ((System.Drawing.Image)(resources.GetObject("btnCarregar.Image")));
      this.btnCarregar.Location = new System.Drawing.Point(9, 35);
      this.btnCarregar.Margin = new System.Windows.Forms.Padding(1);
      this.btnCarregar.Name = "btnCarregar";
      this.btnCarregar.Size = new System.Drawing.Size(31, 31);
      this.btnCarregar.TabIndex = 0;
      this.cmxToolTip1.SetToolTip(this.btnCarregar, "Carregar Dados Padrão");
      this.btnCarregar.UseVisualStyleBackColor = false;
      this.btnCarregar.Click += new System.EventHandler(this.BtnCarregar_Click);
      // 
      // dtpDataDesenho
      // 
      this.dtpDataDesenho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.dtpDataDesenho.BorderRadius = 15;
      this.dtpDataDesenho.BorderSize = 2;
      this.dtpDataDesenho.F7ToolTipText = null;
      this.dtpDataDesenho.F8ToolTipText = null;
      this.dtpDataDesenho.F9ToolTipText = null;
      this.dtpDataDesenho.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.dtpDataDesenho.IconF7 = ((System.Drawing.Image)(resources.GetObject("dtpDataDesenho.IconF7")));
      this.dtpDataDesenho.IconToolTipText = null;
      this.dtpDataDesenho.Lines = new string[0];
      this.dtpDataDesenho.Location = new System.Drawing.Point(9, 372);
      this.dtpDataDesenho.MaxLength = 32767;
      this.dtpDataDesenho.Name = "dtpDataDesenho";
      this.dtpDataDesenho.PasswordChar = '\0';
      this.dtpDataDesenho.Propriedade = null;
      this.dtpDataDesenho.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.dtpDataDesenho.SelectedText = "";
      this.dtpDataDesenho.SelectionLength = 0;
      this.dtpDataDesenho.SelectionStart = 0;
      this.dtpDataDesenho.ShortcutsEnabled = true;
      this.dtpDataDesenho.ShowButtonF7 = true;
      this.dtpDataDesenho.Size = new System.Drawing.Size(130, 31);
      this.dtpDataDesenho.TabIndex = 6;
      this.dtpDataDesenho.UnderlinedStyle = false;
      this.dtpDataDesenho.UseSelectable = true;
      this.dtpDataDesenho.Valor = LmCorbieUI.Design.LmValueType.Data;
      this.dtpDataDesenho.Valor_Decimais = ((short)(0));
      this.dtpDataDesenho.Visible = false;
      this.dtpDataDesenho.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.dtpDataDesenho.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // txtProjetista
      // 
      this.txtProjetista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtProjetista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtProjetista.BorderRadius = 15;
      this.txtProjetista.BorderSize = 2;
      this.txtProjetista.F7ToolTipText = null;
      this.txtProjetista.F8ToolTipText = null;
      this.txtProjetista.F9ToolTipText = null;
      this.txtProjetista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtProjetista.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtProjetista.IconF7")));
      this.txtProjetista.IconToolTipText = null;
      this.txtProjetista.Lines = new string[0];
      this.txtProjetista.Location = new System.Drawing.Point(6, 210);
      this.txtProjetista.MaxLength = 32767;
      this.txtProjetista.Name = "txtProjetista";
      this.txtProjetista.PasswordChar = '\0';
      this.txtProjetista.Propriedade = null;
      this.txtProjetista.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtProjetista.SelectedText = "";
      this.txtProjetista.SelectionLength = 0;
      this.txtProjetista.SelectionStart = 0;
      this.txtProjetista.ShortcutsEnabled = true;
      this.txtProjetista.Size = new System.Drawing.Size(338, 31);
      this.txtProjetista.TabIndex = 5;
      this.txtProjetista.UnderlinedStyle = false;
      this.txtProjetista.UseSelectable = true;
      this.txtProjetista.Valor_Decimais = ((short)(0));
      this.txtProjetista.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtProjetista.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // cmxGroupBox1
      // 
      this.cmxGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cmxGroupBox1.Controls.Add(this.rdbPasta);
      this.cmxGroupBox1.Controls.Add(this.txtNome);
      this.cmxGroupBox1.Controls.Add(this.rdbNome);
      this.cmxGroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(41)))), ((int)(((byte)(38)))));
      this.cmxGroupBox1.Location = new System.Drawing.Point(3, 249);
      this.cmxGroupBox1.Name = "cmxGroupBox1";
      this.cmxGroupBox1.Size = new System.Drawing.Size(344, 90);
      this.cmxGroupBox1.TabIndex = 7;
      this.cmxGroupBox1.TabStop = false;
      this.cmxGroupBox1.Text = "Atualizar Somente";
      // 
      // rdbPasta
      // 
      this.rdbPasta.AutoSize = true;
      this.rdbPasta.Checked = true;
      this.rdbPasta.Location = new System.Drawing.Point(6, 25);
      this.rdbPasta.Name = "rdbPasta";
      this.rdbPasta.Size = new System.Drawing.Size(189, 15);
      this.rdbPasta.TabIndex = 0;
      this.rdbPasta.TabStop = true;
      this.rdbPasta.Text = "Na Mesma Pasta da Montagem";
      this.rdbPasta.UseSelectable = true;
      // 
      // txtNome
      // 
      this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtNome.BorderRadius = 15;
      this.txtNome.BorderSize = 2;
      this.txtNome.F7ToolTipText = null;
      this.txtNome.F8ToolTipText = null;
      this.txtNome.F9ToolTipText = null;
      this.txtNome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtNome.IconF7 = null;
      this.txtNome.IconToolTipText = null;
      this.txtNome.Lines = new string[0];
      this.txtNome.Location = new System.Drawing.Point(144, 49);
      this.txtNome.MaxLength = 32767;
      this.txtNome.Name = "txtNome";
      this.txtNome.PasswordChar = '\0';
      this.txtNome.Propriedade = null;
      this.txtNome.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtNome.SelectedText = "";
      this.txtNome.SelectionLength = 0;
      this.txtNome.SelectionStart = 0;
      this.txtNome.ShortcutsEnabled = true;
      this.txtNome.Size = new System.Drawing.Size(197, 31);
      this.txtNome.TabIndex = 0;
      this.txtNome.UnderlinedStyle = false;
      this.txtNome.UseSelectable = true;
      this.txtNome.Valor_Decimais = ((short)(0));
      this.txtNome.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtNome.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // rdbNome
      // 
      this.rdbNome.AutoSize = true;
      this.rdbNome.Location = new System.Drawing.Point(6, 57);
      this.rdbNome.Name = "rdbNome";
      this.rdbNome.Size = new System.Drawing.Size(132, 15);
      this.rdbNome.TabIndex = 1;
      this.rdbNome.Text = "Nome Começa Com";
      this.rdbNome.UseSelectable = true;
      // 
      // cmxLabel4
      // 
      this.cmxLabel4.AutoSize = true;
      this.cmxLabel4.Location = new System.Drawing.Point(6, 191);
      this.cmxLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel4.Name = "cmxLabel4";
      this.cmxLabel4.Size = new System.Drawing.Size(66, 19);
      this.cmxLabel4.TabIndex = 77;
      this.cmxLabel4.Text = "Projetista";
      this.cmxLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel2
      // 
      this.cmxLabel2.AutoSize = true;
      this.cmxLabel2.Location = new System.Drawing.Point(9, 353);
      this.cmxLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel2.Name = "cmxLabel2";
      this.cmxLabel2.Size = new System.Drawing.Size(96, 19);
      this.cmxLabel2.TabIndex = 80;
      this.cmxLabel2.Text = "Data Desenho";
      this.cmxLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.cmxLabel2.Visible = false;
      // 
      // txtConjunto
      // 
      this.txtConjunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtConjunto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtConjunto.BorderRadius = 15;
      this.txtConjunto.BorderSize = 2;
      this.txtConjunto.F7ToolTipText = null;
      this.txtConjunto.F8ToolTipText = null;
      this.txtConjunto.F9ToolTipText = null;
      this.txtConjunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtConjunto.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtConjunto.IconF7")));
      this.txtConjunto.IconToolTipText = null;
      this.txtConjunto.Lines = new string[0];
      this.txtConjunto.Location = new System.Drawing.Point(6, 98);
      this.txtConjunto.MaxLength = 50;
      this.txtConjunto.Name = "txtConjunto";
      this.txtConjunto.PasswordChar = '\0';
      this.txtConjunto.Propriedade = null;
      this.txtConjunto.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtConjunto.SelectedText = "";
      this.txtConjunto.SelectionLength = 0;
      this.txtConjunto.SelectionStart = 0;
      this.txtConjunto.ShortcutsEnabled = true;
      this.txtConjunto.Size = new System.Drawing.Size(338, 31);
      this.txtConjunto.TabIndex = 3;
      this.txtConjunto.UnderlinedStyle = false;
      this.txtConjunto.UseSelectable = true;
      this.txtConjunto.Valor_Decimais = ((short)(0));
      this.txtConjunto.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtConjunto.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtConjunto.TextChanged += new System.EventHandler(this.TxtConjunto_TextChanged);
      // 
      // lmLabel2
      // 
      this.lmLabel2.AutoSize = true;
      this.lmLabel2.Location = new System.Drawing.Point(6, 79);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(119, 19);
      this.lmLabel2.TabIndex = 85;
      this.lmLabel2.Text = "Nome do Conjuto";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel3
      // 
      this.lmLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.lmLabel3.Dock = System.Windows.Forms.DockStyle.Top;
      this.lmLabel3.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.lmLabel3.Location = new System.Drawing.Point(0, 0);
      this.lmLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel3.Name = "lmLabel3";
      this.lmLabel3.Size = new System.Drawing.Size(350, 24);
      this.lmLabel3.TabIndex = 98;
      this.lmLabel3.Text = "Propriedades Personalizadas";
      // 
      // lmLabel1
      // 
      this.lmLabel1.AutoSize = true;
      this.lmLabel1.Location = new System.Drawing.Point(6, 135);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(140, 19);
      this.lmLabel1.TabIndex = 100;
      this.lmLabel1.Text = "Descrição do Conjuto";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
      this.txtDescricao.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtDescricao.IconF7")));
      this.txtDescricao.IconToolTipText = null;
      this.txtDescricao.Lines = new string[0];
      this.txtDescricao.Location = new System.Drawing.Point(6, 154);
      this.txtDescricao.MaxLength = 50;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = null;
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.Size = new System.Drawing.Size(338, 31);
      this.txtDescricao.TabIndex = 4;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // FrmFileProperties
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(350, 450);
      this.Controls.Add(this.lmLabel1);
      this.Controls.Add(this.txtDescricao);
      this.Controls.Add(this.lmLabel3);
      this.Controls.Add(this.btnCarregar);
      this.Controls.Add(this.lmLabel2);
      this.Controls.Add(this.txtConjunto);
      this.Controls.Add(this.dtpDataDesenho);
      this.Controls.Add(this.txtProjetista);
      this.Controls.Add(this.cmxGroupBox1);
      this.Controls.Add(this.cmxLabel4);
      this.Controls.Add(this.cmxLabel2);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnSalvar);
      this.Name = "FrmFileProperties";
      this.Padding = new System.Windows.Forms.Padding(0);
      this.Text = "FrmFileProperties";
      this.Loaded += new LmCorbieUI.LmForms.LmChildForm.FormLoad(this.FrmFileProperties_Loaded);
      this.Load += new System.EventHandler(this.FrmFileProperties_Load);
      this.cmxGroupBox1.ResumeLayout(false);
      this.cmxGroupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private LmCorbieUI.Controls.LmButton btnClose;
        private LmCorbieUI.Controls.LmButton btnSalvar;
        private System.Windows.Forms.ToolTip cmxToolTip1;
        private LmCorbieUI.Controls.LmTextBox dtpDataDesenho;
        private LmCorbieUI.Controls.LmTextBox txtProjetista;
        private LmCorbieUI.Controls.LmGroupBox cmxGroupBox1;
        private LmCorbieUI.Controls.LmRadioButton rdbPasta;
        private LmCorbieUI.Controls.LmTextBox txtNome;
        private LmCorbieUI.Controls.LmRadioButton rdbNome;
        private LmCorbieUI.Controls.LmLabel cmxLabel4;
        private LmCorbieUI.Controls.LmLabel cmxLabel2;
        private LmCorbieUI.Controls.LmTextBox txtConjunto;
        private LmCorbieUI.Controls.LmLabel lmLabel2;
        private LmCorbieUI.Controls.LmButton btnCarregar;
    private LmCorbieUI.Controls.LmLabel lmLabel3;
    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmTextBox txtDescricao;
  }
}