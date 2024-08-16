namespace AddinFormatec
{
    partial class FrmProcesso
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcesso));
      this.lblOperacoes = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtMateriaPrima = new LmCorbieUI.Controls.LmTextBox();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.ckbAddDenom = new LmCorbieUI.Controls.LmCheckBox();
      this.cmxLabel8 = new LmCorbieUI.Controls.LmLabel();
      this.pnlControl = new LmCorbieUI.Controls.LmPanel();
      this.lblPecasProc = new LmCorbieUI.Controls.LmLabel();
      this.lblListaCorte = new LmCorbieUI.Controls.LmLabel();
      this.btnUpDes = new LmCorbieUI.Controls.LmButton();
      this.btnDownDes = new LmCorbieUI.Controls.LmButton();
      this.btnProximo = new LmCorbieUI.Controls.LmButton();
      this.btnVoltar = new LmCorbieUI.Controls.LmButton();
      this.btnClose = new LmCorbieUI.Controls.LmButton();
      this.btnSalvar = new LmCorbieUI.Controls.LmButton();
      this.btnCarrProcess = new LmCorbieUI.Controls.LmButton();
      this.cmxToolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.tbcOperacoes = new LmCorbieUI.Controls.LmTabControl();
      this.tbpOperacoes = new LmCorbieUI.Controls.LmTabPage();
      this.flpOperacoes = new LmCorbieUI.Controls.LmPanelFlow();
      this.txtProcurar = new LmCorbieUI.Controls.LmTextBox();
      this.tbpLista = new LmCorbieUI.Controls.LmTabPage();
      this.dgv = new LmCorbieUI.Controls.LmDataGridView();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.tmrInicioLocalizar = new System.Windows.Forms.Timer(this.components);
      this.lblMaterial = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.lblPeso = new LmCorbieUI.Controls.LmLabel();
      this.lmLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.lblDescMatPrima = new LmCorbieUI.Controls.LmLabel();
      this.lblEspess = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.pnlDados = new LmCorbieUI.Controls.LmPanel();
      this.pnlControl.SuspendLayout();
      this.tbcOperacoes.SuspendLayout();
      this.tbpOperacoes.SuspendLayout();
      this.tbpLista.SuspendLayout();
      this.pnlDados.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblOperacoes
      // 
      this.lblOperacoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblOperacoes.BackColor = System.Drawing.Color.Transparent;
      this.lblOperacoes.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblOperacoes.ForeColor = System.Drawing.Color.Red;
      this.lblOperacoes.Location = new System.Drawing.Point(118, 87);
      this.lblOperacoes.Margin = new System.Windows.Forms.Padding(3);
      this.lblOperacoes.Name = "lblOperacoes";
      this.lblOperacoes.Size = new System.Drawing.Size(180, 15);
      this.lblOperacoes.TabIndex = 27;
      this.lblOperacoes.Text = "---";
      this.lblOperacoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel2
      // 
      this.lmLabel2.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel2.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel2.Location = new System.Drawing.Point(3, 87);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(113, 15);
      this.lmLabel2.TabIndex = 26;
      this.lmLabel2.Text = "Operações:";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtMateriaPrima
      // 
      this.txtMateriaPrima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtMateriaPrima.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtMateriaPrima.BorderRadius = 15;
      this.txtMateriaPrima.BorderSize = 2;
      this.txtMateriaPrima.F7ToolTipText = "Selecionar Material Chapa Metálica";
      this.txtMateriaPrima.F8ToolTipText = null;
      this.txtMateriaPrima.F9ToolTipText = null;
      this.txtMateriaPrima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtMateriaPrima.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtMateriaPrima.IconF7")));
      this.txtMateriaPrima.IconToolTipText = null;
      this.txtMateriaPrima.Lines = new string[0];
      this.txtMateriaPrima.Location = new System.Drawing.Point(0, 108);
      this.txtMateriaPrima.MaxLength = 50;
      this.txtMateriaPrima.Name = "txtMateriaPrima";
      this.txtMateriaPrima.PasswordChar = '\0';
      this.txtMateriaPrima.Propriedade = null;
      this.txtMateriaPrima.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtMateriaPrima.SelectedText = "";
      this.txtMateriaPrima.SelectionLength = 0;
      this.txtMateriaPrima.SelectionStart = 0;
      this.txtMateriaPrima.ShortcutsEnabled = true;
      this.txtMateriaPrima.ShowButtonF7 = true;
      this.txtMateriaPrima.Size = new System.Drawing.Size(301, 31);
      this.txtMateriaPrima.TabIndex = 0;
      this.txtMateriaPrima.UnderlinedStyle = false;
      this.txtMateriaPrima.UseSelectable = true;
      this.txtMateriaPrima.Valor = LmCorbieUI.Design.LmValueType.ComboBox;
      this.txtMateriaPrima.Valor_Decimais = ((short)(0));
      this.txtMateriaPrima.WaterMark = "Selecionar Material";
      this.txtMateriaPrima.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtMateriaPrima.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtMateriaPrima.SelectedValueChanched += new LmCorbieUI.Controls.LmTextBox.ValChange(this.TxtMateriaPrima_SelectedValueChanched);
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
      this.txtDescricao.Location = new System.Drawing.Point(0, 161);
      this.txtDescricao.MaxLength = 50;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = null;
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.Size = new System.Drawing.Size(301, 31);
      this.txtDescricao.TabIndex = 5;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtDescricao.Leave += new System.EventHandler(this.TxtDenominacao_Leave);
      // 
      // ckbAddDenom
      // 
      this.ckbAddDenom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ckbAddDenom.AutoSize = true;
      this.ckbAddDenom.BackColor = System.Drawing.Color.Transparent;
      this.ckbAddDenom.Checked = true;
      this.ckbAddDenom.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckbAddDenom.Location = new System.Drawing.Point(145, 144);
      this.ckbAddDenom.Name = "ckbAddDenom";
      this.ckbAddDenom.Propriedade = null;
      this.ckbAddDenom.Size = new System.Drawing.Size(156, 19);
      this.ckbAddDenom.TabIndex = 25;
      this.ckbAddDenom.Text = "Add em Todas Config";
      this.ckbAddDenom.UseSelectable = true;
      this.ckbAddDenom.CheckedChanged += new System.EventHandler(this.CkbAddDenom_CheckedChanged);
      // 
      // cmxLabel8
      // 
      this.cmxLabel8.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel8.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel8.Location = new System.Drawing.Point(0, 145);
      this.cmxLabel8.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel8.Name = "cmxLabel8";
      this.cmxLabel8.Size = new System.Drawing.Size(107, 15);
      this.cmxLabel8.TabIndex = 24;
      this.cmxLabel8.Text = "Descrição";
      this.cmxLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pnlControl
      // 
      this.pnlControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.pnlControl.Controls.Add(this.lblPecasProc);
      this.pnlControl.Controls.Add(this.lblListaCorte);
      this.pnlControl.Controls.Add(this.btnUpDes);
      this.pnlControl.Controls.Add(this.btnDownDes);
      this.pnlControl.Controls.Add(this.btnProximo);
      this.pnlControl.Controls.Add(this.btnVoltar);
      this.pnlControl.Controls.Add(this.btnClose);
      this.pnlControl.Controls.Add(this.btnSalvar);
      this.pnlControl.Controls.Add(this.btnCarrProcess);
      this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlControl.IsPanelMenu = false;
      this.pnlControl.Location = new System.Drawing.Point(0, 225);
      this.pnlControl.Name = "pnlControl";
      this.pnlControl.Size = new System.Drawing.Size(308, 59);
      this.pnlControl.TabIndex = 3;
      // 
      // lblPecasProc
      // 
      this.lblPecasProc.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblPecasProc.Location = new System.Drawing.Point(3, 38);
      this.lblPecasProc.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
      this.lblPecasProc.Name = "lblPecasProc";
      this.lblPecasProc.Size = new System.Drawing.Size(142, 15);
      this.lblPecasProc.TabIndex = 12;
      this.lblPecasProc.Text = "Item 0 de 0 - 0%";
      this.lblPecasProc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblListaCorte
      // 
      this.lblListaCorte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblListaCorte.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblListaCorte.Location = new System.Drawing.Point(95, 38);
      this.lblListaCorte.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
      this.lblListaCorte.Name = "lblListaCorte";
      this.lblListaCorte.Size = new System.Drawing.Size(209, 15);
      this.lblListaCorte.TabIndex = 14;
      this.lblListaCorte.Text = "Nome Lista Corte - 0 de 0";
      this.lblListaCorte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnUpDes
      // 
      this.btnUpDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
      this.btnUpDes.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnUpDes.BorderRadius = 15;
      this.btnUpDes.BorderSize = 0;
      this.btnUpDes.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnUpDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUpDes.Image = ((System.Drawing.Image)(resources.GetObject("btnUpDes.Image")));
      this.btnUpDes.Location = new System.Drawing.Point(174, 3);
      this.btnUpDes.Margin = new System.Windows.Forms.Padding(1);
      this.btnUpDes.Name = "btnUpDes";
      this.btnUpDes.Size = new System.Drawing.Size(31, 31);
      this.btnUpDes.TabIndex = 8;
      this.btnUpDes.Tag = "Up";
      this.btnUpDes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnUpDes, "Lista de corte\r\nPróxima");
      this.btnUpDes.UseVisualStyleBackColor = false;
      this.btnUpDes.Click += new System.EventHandler(this.BtnUpDown_Click);
      // 
      // btnDownDes
      // 
      this.btnDownDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnDownDes.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnDownDes.BorderRadius = 15;
      this.btnDownDes.BorderSize = 0;
      this.btnDownDes.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnDownDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDownDes.Image = ((System.Drawing.Image)(resources.GetObject("btnDownDes.Image")));
      this.btnDownDes.Location = new System.Drawing.Point(141, 3);
      this.btnDownDes.Margin = new System.Windows.Forms.Padding(1);
      this.btnDownDes.Name = "btnDownDes";
      this.btnDownDes.Size = new System.Drawing.Size(31, 31);
      this.btnDownDes.TabIndex = 7;
      this.btnDownDes.Tag = "Down";
      this.btnDownDes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.cmxToolTip1.SetToolTip(this.btnDownDes, "Lista de corte\r\nAnterior");
      this.btnDownDes.UseVisualStyleBackColor = false;
      this.btnDownDes.Click += new System.EventHandler(this.BtnUpDown_Click);
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
      this.btnProximo.TabIndex = 6;
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
      this.btnVoltar.TabIndex = 5;
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
      this.btnClose.Location = new System.Drawing.Point(270, 3);
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
      this.btnSalvar.Location = new System.Drawing.Point(36, 3);
      this.btnSalvar.Margin = new System.Windows.Forms.Padding(1);
      this.btnSalvar.Name = "btnSalvar";
      this.btnSalvar.Size = new System.Drawing.Size(31, 31);
      this.btnSalvar.TabIndex = 4;
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
      // tbcOperacoes
      // 
      this.tbcOperacoes.Controls.Add(this.tbpOperacoes);
      this.tbcOperacoes.Controls.Add(this.tbpLista);
      this.tbcOperacoes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbcOperacoes.Location = new System.Drawing.Point(0, 284);
      this.tbcOperacoes.Name = "tbcOperacoes";
      this.tbcOperacoes.SelectedIndex = 0;
      this.tbcOperacoes.Size = new System.Drawing.Size(308, 176);
      this.tbcOperacoes.TabIndex = 2;
      this.tbcOperacoes.UseSelectable = true;
      // 
      // tbpOperacoes
      // 
      this.tbpOperacoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbpOperacoes.Controls.Add(this.flpOperacoes);
      this.tbpOperacoes.Controls.Add(this.txtProcurar);
      this.tbpOperacoes.Location = new System.Drawing.Point(4, 38);
      this.tbpOperacoes.Name = "tbpOperacoes";
      this.tbpOperacoes.Padding = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.tbpOperacoes.Size = new System.Drawing.Size(300, 134);
      this.tbpOperacoes.TabIndex = 0;
      this.tbpOperacoes.Text = "Operações";
      // 
      // flpOperacoes
      // 
      this.flpOperacoes.AutoScroll = true;
      this.flpOperacoes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.flpOperacoes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flpOperacoes.Location = new System.Drawing.Point(3, 39);
      this.flpOperacoes.Name = "flpOperacoes";
      this.flpOperacoes.Padding = new System.Windows.Forms.Padding(0, 5, 0, 9);
      this.flpOperacoes.Size = new System.Drawing.Size(292, 90);
      this.flpOperacoes.TabIndex = 6;
      this.flpOperacoes.SizeChanged += new System.EventHandler(this.FlpProcess_SizeChanged);
      // 
      // txtProcurar
      // 
      this.txtProcurar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtProcurar.BorderRadius = 15;
      this.txtProcurar.BorderSize = 2;
      this.txtProcurar.Dock = System.Windows.Forms.DockStyle.Top;
      this.txtProcurar.F7ToolTipText = null;
      this.txtProcurar.F8ToolTipText = null;
      this.txtProcurar.F9ToolTipText = null;
      this.txtProcurar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtProcurar.Icon = ((System.Drawing.Image)(resources.GetObject("txtProcurar.Icon")));
      this.txtProcurar.IconF7 = null;
      this.txtProcurar.IconToolTipText = null;
      this.txtProcurar.Lines = new string[0];
      this.txtProcurar.Location = new System.Drawing.Point(3, 9);
      this.txtProcurar.MaxLength = 30;
      this.txtProcurar.Name = "txtProcurar";
      this.txtProcurar.PasswordChar = '\0';
      this.txtProcurar.Propriedade = null;
      this.txtProcurar.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtProcurar.SelectedText = "";
      this.txtProcurar.SelectionLength = 0;
      this.txtProcurar.SelectionStart = 0;
      this.txtProcurar.ShortcutsEnabled = true;
      this.txtProcurar.ShowClearButton = true;
      this.txtProcurar.ShowIcon = true;
      this.txtProcurar.Size = new System.Drawing.Size(292, 30);
      this.txtProcurar.TabIndex = 5;
      this.txtProcurar.UnderlinedStyle = false;
      this.txtProcurar.UseSelectable = true;
      this.txtProcurar.Valor_Decimais = ((short)(4));
      this.txtProcurar.WaterMark = "Procurar Por...";
      this.txtProcurar.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtProcurar.WaterMarkFont = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtProcurar.TextChanged += new System.EventHandler(this.TxtProcurar_TextChanged);
      // 
      // tbpLista
      // 
      this.tbpLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbpLista.Controls.Add(this.dgv);
      this.tbpLista.Location = new System.Drawing.Point(4, 38);
      this.tbpLista.Name = "tbpLista";
      this.tbpLista.Padding = new System.Windows.Forms.Padding(3, 9, 3, 3);
      this.tbpLista.Size = new System.Drawing.Size(300, 134);
      this.tbpLista.TabIndex = 1;
      this.tbpLista.Text = "Lista Componentes";
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
      this.dgv.Location = new System.Drawing.Point(3, 9);
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
      this.dgv.Size = new System.Drawing.Size(292, 120);
      this.dgv.TabIndex = 98;
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
      this.cmxLabel6.Size = new System.Drawing.Size(308, 24);
      this.cmxLabel6.TabIndex = 97;
      this.cmxLabel6.Text = "Aplicação de Processos";
      // 
      // tmrInicioLocalizar
      // 
      this.tmrInicioLocalizar.Tag = "0";
      this.tmrInicioLocalizar.Tick += new System.EventHandler(this.TmrInicioLocalizar_Tick);
      // 
      // lblMaterial
      // 
      this.lblMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMaterial.BackColor = System.Drawing.Color.Transparent;
      this.lblMaterial.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblMaterial.ForeColor = System.Drawing.Color.Red;
      this.lblMaterial.Location = new System.Drawing.Point(118, 24);
      this.lblMaterial.Margin = new System.Windows.Forms.Padding(3);
      this.lblMaterial.Name = "lblMaterial";
      this.lblMaterial.Size = new System.Drawing.Size(180, 15);
      this.lblMaterial.TabIndex = 74;
      this.lblMaterial.Text = "---";
      this.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel4
      // 
      this.lmLabel4.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel4.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel4.ForeColor = System.Drawing.Color.Red;
      this.lmLabel4.Location = new System.Drawing.Point(3, 24);
      this.lmLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel4.Name = "lmLabel4";
      this.lmLabel4.Size = new System.Drawing.Size(113, 15);
      this.lmLabel4.TabIndex = 73;
      this.lmLabel4.Text = "Material:";
      this.lmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblPeso
      // 
      this.lblPeso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPeso.BackColor = System.Drawing.Color.Transparent;
      this.lblPeso.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblPeso.ForeColor = System.Drawing.Color.Red;
      this.lblPeso.Location = new System.Drawing.Point(118, 66);
      this.lblPeso.Margin = new System.Windows.Forms.Padding(3);
      this.lblPeso.Name = "lblPeso";
      this.lblPeso.Size = new System.Drawing.Size(180, 15);
      this.lblPeso.TabIndex = 72;
      this.lblPeso.Text = "---";
      this.lblPeso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmLabel3
      // 
      this.lmLabel3.BackColor = System.Drawing.Color.Transparent;
      this.lmLabel3.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lmLabel3.ForeColor = System.Drawing.Color.Red;
      this.lmLabel3.Location = new System.Drawing.Point(3, 66);
      this.lmLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel3.Name = "lmLabel3";
      this.lmLabel3.Size = new System.Drawing.Size(113, 15);
      this.lmLabel3.TabIndex = 71;
      this.lmLabel3.Text = "Peso:";
      this.lmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblDescMatPrima
      // 
      this.lblDescMatPrima.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDescMatPrima.BackColor = System.Drawing.Color.Transparent;
      this.lblDescMatPrima.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblDescMatPrima.ForeColor = System.Drawing.Color.Red;
      this.lblDescMatPrima.Location = new System.Drawing.Point(118, 45);
      this.lblDescMatPrima.Margin = new System.Windows.Forms.Padding(3);
      this.lblDescMatPrima.Name = "lblDescMatPrima";
      this.lblDescMatPrima.Size = new System.Drawing.Size(180, 15);
      this.lblDescMatPrima.TabIndex = 70;
      this.lblDescMatPrima.Text = "---";
      this.lblDescMatPrima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblEspess
      // 
      this.lblEspess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblEspess.BackColor = System.Drawing.Color.Transparent;
      this.lblEspess.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.lblEspess.ForeColor = System.Drawing.Color.Red;
      this.lblEspess.Location = new System.Drawing.Point(118, 3);
      this.lblEspess.Margin = new System.Windows.Forms.Padding(3);
      this.lblEspess.Name = "lblEspess";
      this.lblEspess.Size = new System.Drawing.Size(180, 15);
      this.lblEspess.TabIndex = 68;
      this.lblEspess.Text = "---";
      this.lblEspess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel3
      // 
      this.cmxLabel3.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel3.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel3.ForeColor = System.Drawing.Color.Red;
      this.cmxLabel3.Location = new System.Drawing.Point(3, 45);
      this.cmxLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel3.Name = "cmxLabel3";
      this.cmxLabel3.Size = new System.Drawing.Size(113, 15);
      this.cmxLabel3.TabIndex = 67;
      this.cmxLabel3.Text = "Descrição Material:";
      this.cmxLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cmxLabel1
      // 
      this.cmxLabel1.BackColor = System.Drawing.Color.Transparent;
      this.cmxLabel1.FontSize = LmCorbieUI.Design.LmLabelSize.Small;
      this.cmxLabel1.ForeColor = System.Drawing.Color.Red;
      this.cmxLabel1.Location = new System.Drawing.Point(3, 3);
      this.cmxLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel1.Name = "cmxLabel1";
      this.cmxLabel1.Size = new System.Drawing.Size(113, 15);
      this.cmxLabel1.TabIndex = 65;
      this.cmxLabel1.Text = "Esp.xLarg.xComp.:";
      this.cmxLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // pnlDados
      // 
      this.pnlDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.pnlDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlDados.Controls.Add(this.cmxLabel1);
      this.pnlDados.Controls.Add(this.lblMaterial);
      this.pnlDados.Controls.Add(this.cmxLabel8);
      this.pnlDados.Controls.Add(this.lmLabel4);
      this.pnlDados.Controls.Add(this.txtDescricao);
      this.pnlDados.Controls.Add(this.lblPeso);
      this.pnlDados.Controls.Add(this.txtMateriaPrima);
      this.pnlDados.Controls.Add(this.lmLabel3);
      this.pnlDados.Controls.Add(this.lmLabel2);
      this.pnlDados.Controls.Add(this.lblDescMatPrima);
      this.pnlDados.Controls.Add(this.lblOperacoes);
      this.pnlDados.Controls.Add(this.lblEspess);
      this.pnlDados.Controls.Add(this.cmxLabel3);
      this.pnlDados.Controls.Add(this.ckbAddDenom);
      this.pnlDados.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlDados.IsPanelMenu = false;
      this.pnlDados.Location = new System.Drawing.Point(0, 24);
      this.pnlDados.Name = "pnlDados";
      this.pnlDados.Size = new System.Drawing.Size(308, 201);
      this.pnlDados.TabIndex = 98;
      // 
      // FrmProcesso
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(308, 460);
      this.Controls.Add(this.tbcOperacoes);
      this.Controls.Add(this.pnlControl);
      this.Controls.Add(this.pnlDados);
      this.Controls.Add(this.cmxLabel6);
      this.Name = "FrmProcesso";
      this.Padding = new System.Windows.Forms.Padding(0);
      this.Loaded += new LmCorbieUI.LmForms.LmChildForm.FormLoad(this.FrmProcesso_Loaded);
      this.pnlControl.ResumeLayout(false);
      this.tbcOperacoes.ResumeLayout(false);
      this.tbpOperacoes.ResumeLayout(false);
      this.tbpLista.ResumeLayout(false);
      this.pnlDados.ResumeLayout(false);
      this.pnlDados.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion
        private LmCorbieUI.Controls.LmTextBox txtMateriaPrima;
        private LmCorbieUI.Controls.LmTextBox txtDescricao;
        private LmCorbieUI.Controls.LmCheckBox ckbAddDenom;
        private LmCorbieUI.Controls.LmLabel cmxLabel8;
        private LmCorbieUI.Controls.LmPanel pnlControl;
        private LmCorbieUI.Controls.LmLabel lblPecasProc;
        private LmCorbieUI.Controls.LmButton btnUpDes;
        private LmCorbieUI.Controls.LmButton btnDownDes;
        private LmCorbieUI.Controls.LmButton btnProximo;
        private LmCorbieUI.Controls.LmButton btnVoltar;
        private LmCorbieUI.Controls.LmButton btnClose;
        private LmCorbieUI.Controls.LmButton btnSalvar;
        private LmCorbieUI.Controls.LmButton btnCarrProcess;
        private LmCorbieUI.Controls.LmLabel lblListaCorte;
        private System.Windows.Forms.ToolTip cmxToolTip1;
    private LmCorbieUI.Controls.LmLabel lblOperacoes;
    private LmCorbieUI.Controls.LmLabel lmLabel2;
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private LmCorbieUI.Controls.LmTabControl tbcOperacoes;
    private LmCorbieUI.Controls.LmTabPage tbpOperacoes;
    private LmCorbieUI.Controls.LmTabPage tbpLista;
    private LmCorbieUI.Controls.LmDataGridView dgv;
    private LmCorbieUI.Controls.LmTextBox txtProcurar;
    private System.Windows.Forms.Timer tmrInicioLocalizar;
    private LmCorbieUI.Controls.LmPanelFlow flpOperacoes;
    private LmCorbieUI.Controls.LmLabel lblMaterial;
    private LmCorbieUI.Controls.LmLabel lmLabel4;
    private LmCorbieUI.Controls.LmLabel lblPeso;
    private LmCorbieUI.Controls.LmLabel lmLabel3;
    private LmCorbieUI.Controls.LmLabel lblDescMatPrima;
    private LmCorbieUI.Controls.LmLabel lblEspess;
    private LmCorbieUI.Controls.LmLabel cmxLabel3;
    private LmCorbieUI.Controls.LmLabel cmxLabel1;
    private LmCorbieUI.Controls.LmPanel pnlDados;
  }
}