namespace AddinFormatec {
  partial class FrmMateriaPrimaCad {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMateriaPrimaCad));
      this.ckbSituacao = new LmCorbieUI.Controls.LmCheckBox();
      this.lblSituacao = new LmCorbieUI.Controls.LmLabel();
      this.lblEspessura = new LmCorbieUI.Controls.LmLabel();
      this.txtEspessura = new LmCorbieUI.Controls.LmTextBox();
      this.txtID = new LmCorbieUI.Controls.LmTextBox();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnLimpar = new LmCorbieUI.Controls.LmButton();
      this.btnExcluir = new LmCorbieUI.Controls.LmButton();
      this.lblID = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.txtMaterial = new LmCorbieUI.Controls.LmTextBox();
      this.SuspendLayout();
      // 
      // ckbSituacao
      // 
      this.ckbSituacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.ckbSituacao.AutoSize = true;
      this.ckbSituacao.BackColor = System.Drawing.Color.Transparent;
      this.ckbSituacao.Checked = true;
      this.ckbSituacao.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbSituacao.Location = new System.Drawing.Point(150, 168);
      this.ckbSituacao.Name = "ckbSituacao";
      this.ckbSituacao.Propriedade = "Ativo";
      this.ckbSituacao.Size = new System.Drawing.Size(57, 19);
      this.ckbSituacao.TabIndex = 3;
      this.ckbSituacao.Text = "Ativo";
      this.ckbSituacao.UseSelectable = true;
      // 
      // lblSituacao
      // 
      this.lblSituacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblSituacao.BackColor = System.Drawing.Color.Transparent;
      this.lblSituacao.Location = new System.Drawing.Point(60, 168);
      this.lblSituacao.Margin = new System.Windows.Forms.Padding(3);
      this.lblSituacao.Name = "lblSituacao";
      this.lblSituacao.Size = new System.Drawing.Size(84, 19);
      this.lblSituacao.TabIndex = 350;
      this.lblSituacao.Text = "Situação";
      this.lblSituacao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblEspessura
      // 
      this.lblEspessura.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblEspessura.BackColor = System.Drawing.Color.Transparent;
      this.lblEspessura.Location = new System.Drawing.Point(60, 102);
      this.lblEspessura.Margin = new System.Windows.Forms.Padding(3);
      this.lblEspessura.Name = "lblEspessura";
      this.lblEspessura.Size = new System.Drawing.Size(84, 19);
      this.lblEspessura.TabIndex = 349;
      this.lblEspessura.Text = "Espessura *";
      this.lblEspessura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtEspessura
      // 
      this.txtEspessura.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txtEspessura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtEspessura.BorderRadius = 15;
      this.txtEspessura.BorderSize = 2;
      this.txtEspessura.CampoObrigatorio = true;
      this.txtEspessura.F7ToolTipText = null;
      this.txtEspessura.F8ToolTipText = null;
      this.txtEspessura.F9ToolTipText = null;
      this.txtEspessura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtEspessura.IconF7 = null;
      this.txtEspessura.IconToolTipText = null;
      this.txtEspessura.Lines = new string[0];
      this.txtEspessura.Location = new System.Drawing.Point(150, 96);
      this.txtEspessura.MaxLength = 15;
      this.txtEspessura.Name = "txtEspessura";
      this.txtEspessura.PasswordChar = '\0';
      this.txtEspessura.Propriedade = null;
      this.txtEspessura.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtEspessura.SelectedText = "";
      this.txtEspessura.SelectionLength = 0;
      this.txtEspessura.SelectionStart = 0;
      this.txtEspessura.ShortcutsEnabled = true;
      this.txtEspessura.Size = new System.Drawing.Size(185, 30);
      this.txtEspessura.TabIndex = 1;
      this.txtEspessura.UnderlinedStyle = false;
      this.txtEspessura.UseSelectable = true;
      this.txtEspessura.Valor = LmCorbieUI.Design.LmValueType.Num_Real;
      this.txtEspessura.Valor_Decimais = ((short)(4));
      this.txtEspessura.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtEspessura.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // txtID
      // 
      this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txtID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtID.BorderRadius = 15;
      this.txtID.BorderSize = 2;
      this.txtID.F7ToolTipText = "Pesquisar [F7]";
      this.txtID.F8ToolTipText = "Item Anterior [F8]";
      this.txtID.F9ToolTipText = "Próximo Item [F9]";
      this.txtID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtID.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF7")));
      this.txtID.IconF8 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF8")));
      this.txtID.IconF9 = ((System.Drawing.Image)(resources.GetObject("txtID.IconF9")));
      this.txtID.IconToolTipText = null;
      this.txtID.Lines = new string[0];
      this.txtID.Location = new System.Drawing.Point(150, 60);
      this.txtID.MaxLength = 32767;
      this.txtID.Name = "txtID";
      this.txtID.PasswordChar = '\0';
      this.txtID.Propriedade = "ID";
      this.txtID.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtID.SelectedText = "";
      this.txtID.SelectionLength = 0;
      this.txtID.SelectionStart = 0;
      this.txtID.ShortcutsEnabled = true;
      this.txtID.ShowButtonF7 = true;
      this.txtID.Size = new System.Drawing.Size(185, 30);
      this.txtID.TabIndex = 0;
      this.txtID.UnderlinedStyle = false;
      this.txtID.UseSelectable = true;
      this.txtID.Valor = LmCorbieUI.Design.LmValueType.Num_Inteiro;
      this.txtID.Valor_Decimais = ((short)(0));
      this.txtID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtID.ButtonClickF7 += new LmCorbieUI.Controls.LmTextBox.ButClick(this.TxtID_ButtonClickF7);
      this.txtID.Leave += new System.EventHandler(this.TxtID_Leave);
      // 
      // btnSalvar
      // 
      this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnSalvar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnSalvar.BorderRadius = 13;
      this.btnSalvar.BorderSize = 0;
      this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
      this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnSalvar.Location = new System.Drawing.Point(150, 198);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(100, 26);
      this.btnSalvar.TabIndex = 4;
      this.btnSalvar.Text = " &Salvar";
      this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnSalvar.UseVisualStyleBackColor = false;
      this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
      // 
      // btnLimpar
      // 
      this.btnLimpar.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnLimpar.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnLimpar.BorderRadius = 13;
      this.btnLimpar.BorderSize = 0;
      this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLimpar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpar.Image")));
      this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnLimpar.Location = new System.Drawing.Point(362, 198);
      this.btnLimpar.Name = "btnLimpar";
      this.btnLimpar.Size = new System.Drawing.Size(100, 26);
      this.btnLimpar.TabIndex = 6;
      this.btnLimpar.Text = " &Limpar";
      this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnLimpar.UseVisualStyleBackColor = false;
      this.btnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
      // 
      // btnExcluir
      // 
      this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnExcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.btnExcluir.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnExcluir.BorderRadius = 13;
      this.btnExcluir.BorderSize = 0;
      this.btnExcluir.Enabled = false;
      this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluir.Image")));
      this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnExcluir.Location = new System.Drawing.Point(256, 198);
      this.btnExcluir.Name = "btnExcluir";
      this.btnExcluir.Size = new System.Drawing.Size(100, 26);
      this.btnExcluir.TabIndex = 5;
      this.btnExcluir.Text = " E&xcluir";
      this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnExcluir.UseVisualStyleBackColor = false;
      this.btnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
      // 
      // lblID
      // 
      this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lblID.BackColor = System.Drawing.Color.Transparent;
      this.lblID.Location = new System.Drawing.Point(60, 66);
      this.lblID.Margin = new System.Windows.Forms.Padding(3);
      this.lblID.Name = "lblID";
      this.lblID.Size = new System.Drawing.Size(84, 19);
      this.lblID.TabIndex = 345;
      this.lblID.Text = "Código";
      this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lmLabel1
      // 
      this.lmLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lmLabel1.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel1.Location = new System.Drawing.Point(60, 138);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(84, 19);
      this.lmLabel1.TabIndex = 348;
      this.lmLabel1.Text = "Material *";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtMaterial
      // 
      this.txtMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.txtMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtMaterial.BorderRadius = 15;
      this.txtMaterial.BorderSize = 2;
      this.txtMaterial.CampoObrigatorio = true;
      this.txtMaterial.F7ToolTipText = null;
      this.txtMaterial.F8ToolTipText = null;
      this.txtMaterial.F9ToolTipText = null;
      this.txtMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtMaterial.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtMaterial.IconF7")));
      this.txtMaterial.IconF8 = ((System.Drawing.Image)(resources.GetObject("txtMaterial.IconF8")));
      this.txtMaterial.IconToolTipText = null;
      this.txtMaterial.Lines = new string[0];
      this.txtMaterial.Location = new System.Drawing.Point(150, 132);
      this.txtMaterial.MaxLength = 250;
      this.txtMaterial.Name = "txtMaterial";
      this.txtMaterial.PasswordChar = '\0';
      this.txtMaterial.Propriedade = null;
      this.txtMaterial.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtMaterial.SelectedText = "";
      this.txtMaterial.SelectionLength = 0;
      this.txtMaterial.SelectionStart = 0;
      this.txtMaterial.ShortcutsEnabled = true;
      this.txtMaterial.ShowButtonF7 = true;
      this.txtMaterial.Size = new System.Drawing.Size(450, 30);
      this.txtMaterial.TabIndex = 2;
      this.txtMaterial.UnderlinedStyle = false;
      this.txtMaterial.UseSelectable = true;
      this.txtMaterial.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtMaterial.Valor_Decimais = ((short)(0));
      this.txtMaterial.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtMaterial.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // FrmMateriaPrimaCad
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ChavePrimaria = this.txtID;
      this.ClientSize = new System.Drawing.Size(656, 268);
      this.Controls.Add(this.ckbSituacao);
      this.Controls.Add(this.lblSituacao);
      this.Controls.Add(this.lblEspessura);
      this.Controls.Add(this.txtEspessura);
      this.Controls.Add(this.txtMaterial);
      this.Controls.Add(this.lmLabel1);
      this.Controls.Add(this.txtID);
      this.Controls.Add(this.btnSalvar);
      this.Controls.Add(this.btnLimpar);
      this.Controls.Add(this.btnExcluir);
      this.Controls.Add(this.lblID);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Location = new System.Drawing.Point(0, 0);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmMateriaPrimaCad";
      this.Resizable = false;
      this.Text = "Cadastro de Matéria Prima";
      this.Load += new System.EventHandler(this.FrmMateriaPrimaCad_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private LmCorbieUI.Controls.LmCheckBox ckbSituacao;
    private LmCorbieUI.Controls.LmLabel lblSituacao;
    private LmCorbieUI.Controls.LmLabel lblEspessura;
    private LmCorbieUI.Controls.LmTextBox txtEspessura;
    private LmCorbieUI.Controls.LmTextBox txtID;
    private LmCorbieUI.Controls.LmButton btnSalvar;
    private LmCorbieUI.Controls.LmButton btnLimpar;
    private LmCorbieUI.Controls.LmButton btnExcluir;
    private LmCorbieUI.Controls.LmLabel lblID;
    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmTextBox txtMaterial;
  }
}