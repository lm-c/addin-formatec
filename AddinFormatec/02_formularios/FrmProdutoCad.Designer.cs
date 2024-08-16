namespace AddinFormatec {
  partial class FrmProdutoCad {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutoCad));
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.txtGrupo = new LmCorbieUI.Controls.LmTextBox();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtSubGrupo = new LmCorbieUI.Controls.LmTextBox();
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnCarrProcess = new LmCorbieUI.Controls.LmButton();
      this.lmLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.lmLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.txtUnidadeMedida = new LmCorbieUI.Controls.LmTextBox();
      this.SuspendLayout();
      // 
      // lmLabel1
      // 
      this.lmLabel1.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel1.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel1.Location = new System.Drawing.Point(6, 29);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(107, 15);
      this.lmLabel1.TabIndex = 60;
      this.lmLabel1.Text = "Grupo *";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtGrupo
      // 
      this.txtGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtGrupo.BorderRadius = 15;
      this.txtGrupo.BorderSize = 2;
      this.txtGrupo.CampoObrigatorio = true;
      this.txtGrupo.F7ToolTipText = "";
      this.txtGrupo.F8ToolTipText = null;
      this.txtGrupo.F9ToolTipText = null;
      this.txtGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtGrupo.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtGrupo.IconF7")));
      this.txtGrupo.IconToolTipText = null;
      this.txtGrupo.Lines = new string[0];
      this.txtGrupo.Location = new System.Drawing.Point(6, 45);
      this.txtGrupo.MaxLength = 80;
      this.txtGrupo.Name = "txtGrupo";
      this.txtGrupo.PasswordChar = '\0';
      this.txtGrupo.Propriedade = null;
      this.txtGrupo.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtGrupo.SelectedText = "";
      this.txtGrupo.SelectionLength = 0;
      this.txtGrupo.SelectionStart = 0;
      this.txtGrupo.ShortcutsEnabled = true;
      this.txtGrupo.ShowButtonF7 = true;
      this.txtGrupo.Size = new System.Drawing.Size(288, 31);
      this.txtGrupo.TabIndex = 0;
      this.txtGrupo.UnderlinedStyle = false;
      this.txtGrupo.UseSelectable = true;
      this.txtGrupo.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtGrupo.Valor_Decimais = ((short)(0));
      this.txtGrupo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtGrupo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtGrupo.SelectedValueChanched += new LmCorbieUI.Controls.LmTextBox.ValChange(this.TxtGrupo_SelectedValueChanched);
      // 
      // cmxLabel6
      // 
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(3, 3);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(294, 24);
      this.cmxLabel6.TabIndex = 97;
      this.cmxLabel6.Text = "Cadastro de Produto";
      // 
      // lmLabel2
      // 
      this.lmLabel2.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel2.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel2.Location = new System.Drawing.Point(6, 84);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(107, 15);
      this.lmLabel2.TabIndex = 99;
      this.lmLabel2.Text = "Subgrupo *";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtSubGrupo
      // 
      this.txtSubGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSubGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtSubGrupo.BorderRadius = 15;
      this.txtSubGrupo.BorderSize = 2;
      this.txtSubGrupo.CampoObrigatorio = true;
      this.txtSubGrupo.F7ToolTipText = "";
      this.txtSubGrupo.F8ToolTipText = null;
      this.txtSubGrupo.F9ToolTipText = null;
      this.txtSubGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtSubGrupo.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtSubGrupo.IconF7")));
      this.txtSubGrupo.IconToolTipText = null;
      this.txtSubGrupo.Lines = new string[0];
      this.txtSubGrupo.Location = new System.Drawing.Point(6, 100);
      this.txtSubGrupo.MaxLength = 80;
      this.txtSubGrupo.Name = "txtSubGrupo";
      this.txtSubGrupo.PasswordChar = '\0';
      this.txtSubGrupo.Propriedade = null;
      this.txtSubGrupo.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtSubGrupo.SelectedText = "";
      this.txtSubGrupo.SelectionLength = 0;
      this.txtSubGrupo.SelectionStart = 0;
      this.txtSubGrupo.ShortcutsEnabled = true;
      this.txtSubGrupo.ShowButtonF7 = true;
      this.txtSubGrupo.Size = new System.Drawing.Size(288, 31);
      this.txtSubGrupo.TabIndex = 1;
      this.txtSubGrupo.UnderlinedStyle = false;
      this.txtSubGrupo.UseSelectable = true;
      this.txtSubGrupo.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtSubGrupo.Valor_Decimais = ((short)(0));
      this.txtSubGrupo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtSubGrupo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtSubGrupo.SelectedValueChanched += new LmCorbieUI.Controls.LmTextBox.ValChange(this.TxtSubGrupo_SelectedValueChanched);
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
      this.btnClose.Location = new System.Drawing.Point(263, 199);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(31, 31);
      this.btnClose.TabIndex = 6;
      this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnClose, "Fechar");
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
      this.btnSalvar.Location = new System.Drawing.Point(6, 199);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 5;
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.toolTip1.SetToolTip(this.btnSalvar, "Salvar Novo Código");
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
      this.btnCarrProcess.Location = new System.Drawing.Point(6, 251);
      this.btnCarrProcess.Margin = new System.Windows.Forms.Padding(1);
      this.btnCarrProcess.Name = "btnCarrProcess";
      this.btnCarrProcess.Size = new System.Drawing.Size(31, 31);
      this.btnCarrProcess.TabIndex = 4;
      this.btnCarrProcess.UseVisualStyleBackColor = false;
      this.btnCarrProcess.Visible = false;
      this.btnCarrProcess.Click += new System.EventHandler(this.BtnCarrProcess_Click);
      // 
      // lmLabel3
      // 
      this.lmLabel3.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel3.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel3.Location = new System.Drawing.Point(6, 139);
      this.lmLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel3.Name = "lmLabel3";
      this.lmLabel3.Size = new System.Drawing.Size(107, 15);
      this.lmLabel3.TabIndex = 104;
      this.lmLabel3.Text = "Descrição *";
      this.lmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtDescricao
      // 
      this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtDescricao.BorderRadius = 15;
      this.txtDescricao.BorderSize = 2;
      this.txtDescricao.CampoObrigatorio = true;
      this.txtDescricao.F7ToolTipText = "";
      this.txtDescricao.F8ToolTipText = null;
      this.txtDescricao.F9ToolTipText = null;
      this.txtDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtDescricao.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtDescricao.IconF7")));
      this.txtDescricao.IconToolTipText = null;
      this.txtDescricao.Lines = new string[0];
      this.txtDescricao.Location = new System.Drawing.Point(6, 155);
      this.txtDescricao.MaxLength = 50;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = null;
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.Size = new System.Drawing.Size(207, 31);
      this.txtDescricao.TabIndex = 2;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // 
      // lmLabel4
      // 
      this.lmLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lmLabel4.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel4.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel4.Location = new System.Drawing.Point(219, 139);
      this.lmLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel4.Name = "lmLabel4";
      this.lmLabel4.Size = new System.Drawing.Size(60, 15);
      this.lmLabel4.TabIndex = 106;
      this.lmLabel4.Text = "Unidade *";
      this.lmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtUnidadeMedida
      // 
      this.txtUnidadeMedida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtUnidadeMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtUnidadeMedida.BorderRadius = 15;
      this.txtUnidadeMedida.BorderSize = 2;
      this.txtUnidadeMedida.CampoObrigatorio = true;
      this.txtUnidadeMedida.F7ToolTipText = "";
      this.txtUnidadeMedida.F8ToolTipText = null;
      this.txtUnidadeMedida.F9ToolTipText = null;
      this.txtUnidadeMedida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtUnidadeMedida.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtUnidadeMedida.IconF7")));
      this.txtUnidadeMedida.IconToolTipText = null;
      this.txtUnidadeMedida.Lines = new string[0];
      this.txtUnidadeMedida.Location = new System.Drawing.Point(219, 155);
      this.txtUnidadeMedida.MaxLength = 80;
      this.txtUnidadeMedida.Name = "txtUnidadeMedida";
      this.txtUnidadeMedida.PasswordChar = '\0';
      this.txtUnidadeMedida.Propriedade = null;
      this.txtUnidadeMedida.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtUnidadeMedida.SelectedText = "";
      this.txtUnidadeMedida.SelectionLength = 0;
      this.txtUnidadeMedida.SelectionStart = 0;
      this.txtUnidadeMedida.ShortcutsEnabled = true;
      this.txtUnidadeMedida.ShowButtonF7 = true;
      this.txtUnidadeMedida.Size = new System.Drawing.Size(75, 31);
      this.txtUnidadeMedida.TabIndex = 3;
      this.txtUnidadeMedida.UnderlinedStyle = false;
      this.txtUnidadeMedida.UseSelectable = true;
      this.txtUnidadeMedida.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtUnidadeMedida.Valor_Decimais = ((short)(0));
      this.txtUnidadeMedida.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtUnidadeMedida.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      // 
      // FrmProdutoCad
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(300, 504);
      this.Controls.Add(this.lmLabel4);
      this.Controls.Add(this.txtUnidadeMedida);
      this.Controls.Add(this.lmLabel3);
      this.Controls.Add(this.txtDescricao);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnSalvar);
      this.Controls.Add(this.btnCarrProcess);
      this.Controls.Add(this.lmLabel2);
      this.Controls.Add(this.txtSubGrupo);
      this.Controls.Add(this.cmxLabel6);
      this.Controls.Add(this.lmLabel1);
      this.Controls.Add(this.txtGrupo);
      this.Name = "FrmProdutoCad";
      this.Text = "FrmProdutoCad";
      this.Loaded += new LmCorbieUI.LmForms.LmChildForm.FormLoad(this.FrmProdutoCad_Loaded);
      this.ResumeLayout(false);

    }

    #endregion

    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmTextBox txtGrupo;
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private LmCorbieUI.Controls.LmLabel lmLabel2;
    private LmCorbieUI.Controls.LmTextBox txtSubGrupo;
    private LmCorbieUI.Controls.LmButton btnClose;
    private LmCorbieUI.Controls.LmButton btnSalvar;
    private LmCorbieUI.Controls.LmButton btnCarrProcess;
    private LmCorbieUI.Controls.LmLabel lmLabel3;
    private LmCorbieUI.Controls.LmTextBox txtDescricao;
    private System.Windows.Forms.ToolTip toolTip1;
    private LmCorbieUI.Controls.LmLabel lmLabel4;
    private LmCorbieUI.Controls.LmTextBox txtUnidadeMedida;
  }
}