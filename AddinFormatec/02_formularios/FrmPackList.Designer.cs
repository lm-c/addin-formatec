namespace AddinFormatec
{
    partial class FrmPackList
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPackList));
      this.cmsOpenFile = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsmOpen3D = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmOpen2D = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.lblPercDesenho = new LmCorbieUI.Controls.LmLabel();
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.lmControls = new LmCorbieUI.Controls.LmPanel();
      this.txtQtd = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel1 = new LmCorbieUI.Controls.LmLabel();
      this.txtData = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel3 = new LmCorbieUI.Controls.LmLabel();
      this.txtPedido = new LmCorbieUI.Controls.LmTextBox();
      this.lmLabel2 = new LmCorbieUI.Controls.LmLabel();
      this.txtDescricao = new LmCorbieUI.Controls.LmTextBox();
      this.cmxLabel4 = new LmCorbieUI.Controls.LmLabel();
      this.btnRefresh = new LmCorbieUI.Controls.LmButton();
      this.btnGerarPasta = new LmCorbieUI.Controls.LmButton();
      this.btnSair = new LmCorbieUI.Controls.LmButton();
      this.dgv = new LmCorbieUI.Controls.LmDataGridView();
      this.cmsOpenFile.SuspendLayout();
      this.lmControls.SuspendLayout();
      this.SuspendLayout();
      // 
      // cmsOpenFile
      // 
      this.cmsOpenFile.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.cmsOpenFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSelectAll,
            this.tsmUnselectAll,
            this.toolStripMenuItem2,
            this.tsmOpen3D,
            this.tsmOpen2D});
      this.cmsOpenFile.Name = "cmsOpenFile";
      this.cmsOpenFile.Size = new System.Drawing.Size(245, 114);
      // 
      // tsmSelectAll
      // 
      this.tsmSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmSelectAll.Image")));
      this.tsmSelectAll.Name = "tsmSelectAll";
      this.tsmSelectAll.Size = new System.Drawing.Size(244, 26);
      this.tsmSelectAll.Text = "Selecionar Todos";
      this.tsmSelectAll.Click += new System.EventHandler(this.TsmSelectAll_Click);
      // 
      // tsmUnselectAll
      // 
      this.tsmUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmUnselectAll.Image")));
      this.tsmUnselectAll.Name = "tsmUnselectAll";
      this.tsmUnselectAll.Size = new System.Drawing.Size(244, 26);
      this.tsmUnselectAll.Text = "Remover Seleção Todos";
      this.tsmUnselectAll.Click += new System.EventHandler(this.TsmUnselectAll_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(241, 6);
      // 
      // tsmOpen3D
      // 
      this.tsmOpen3D.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen3D.Image")));
      this.tsmOpen3D.Name = "tsmOpen3D";
      this.tsmOpen3D.Size = new System.Drawing.Size(244, 26);
      this.tsmOpen3D.Text = "Abrir 3D";
      this.tsmOpen3D.Click += new System.EventHandler(this.TsmOpen3D_Click);
      // 
      // tsmOpen2D
      // 
      this.tsmOpen2D.Image = ((System.Drawing.Image)(resources.GetObject("tsmOpen2D.Image")));
      this.tsmOpen2D.Name = "tsmOpen2D";
      this.tsmOpen2D.Size = new System.Drawing.Size(244, 26);
      this.tsmOpen2D.Text = "Abrir 2D";
      this.tsmOpen2D.Click += new System.EventHandler(this.TsmOpen2D_Click);
      // 
      // lblPercDesenho
      // 
      this.lblPercDesenho.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblPercDesenho.Location = new System.Drawing.Point(3, 479);
      this.lblPercDesenho.Margin = new System.Windows.Forms.Padding(3);
      this.lblPercDesenho.Name = "lblPercDesenho";
      this.lblPercDesenho.Size = new System.Drawing.Size(299, 22);
      this.lblPercDesenho.TabIndex = 91;
      this.lblPercDesenho.Text = "Peça 0 de 0";
      this.lblPercDesenho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // cmxLabel6
      // 
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(3, 3);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(299, 26);
      this.cmxLabel6.TabIndex = 92;
      this.cmxLabel6.Text = "Pack List";
      // 
      // lmControls
      // 
      this.lmControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
      this.lmControls.Controls.Add(this.txtQtd);
      this.lmControls.Controls.Add(this.lmLabel1);
      this.lmControls.Controls.Add(this.txtData);
      this.lmControls.Controls.Add(this.lmLabel3);
      this.lmControls.Controls.Add(this.txtPedido);
      this.lmControls.Controls.Add(this.lmLabel2);
      this.lmControls.Controls.Add(this.txtDescricao);
      this.lmControls.Controls.Add(this.cmxLabel4);
      this.lmControls.Controls.Add(this.btnRefresh);
      this.lmControls.Controls.Add(this.btnGerarPasta);
      this.lmControls.Controls.Add(this.btnSair);
      this.lmControls.Dock = System.Windows.Forms.DockStyle.Top;
      this.lmControls.IsPanelMenu = false;
      this.lmControls.Location = new System.Drawing.Point(3, 29);
      this.lmControls.Name = "lmControls";
      this.lmControls.Size = new System.Drawing.Size(299, 158);
      this.lmControls.TabIndex = 0;
      // 
      // txtQtd
      // 
      this.txtQtd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtQtd.BorderRadius = 15;
      this.txtQtd.BorderSize = 2;
      this.txtQtd.CampoObrigatorio = true;
      this.txtQtd.F7ToolTipText = null;
      this.txtQtd.F8ToolTipText = null;
      this.txtQtd.F9ToolTipText = null;
      this.txtQtd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtQtd.IconF7 = null;
      this.txtQtd.IconToolTipText = null;
      this.txtQtd.Lines = new string[0];
      this.txtQtd.Location = new System.Drawing.Point(93, 23);
      this.txtQtd.MaxLength = 32767;
      this.txtQtd.Name = "txtQtd";
      this.txtQtd.PasswordChar = '\0';
      this.txtQtd.Propriedade = null;
      this.txtQtd.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtQtd.SelectedText = "";
      this.txtQtd.SelectionLength = 0;
      this.txtQtd.SelectionStart = 0;
      this.txtQtd.ShortcutsEnabled = true;
      this.txtQtd.Size = new System.Drawing.Size(62, 31);
      this.txtQtd.TabIndex = 1;
      this.txtQtd.UnderlinedStyle = false;
      this.txtQtd.UseSelectable = true;
      this.txtQtd.Valor = LmCorbieUI.Design.LmValueType.Num_Inteiro;
      this.txtQtd.Valor_Decimais = ((short)(0));
      this.txtQtd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtQtd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // lmLabel1
      // 
      this.lmLabel1.AutoSize = true;
      this.lmLabel1.Location = new System.Drawing.Point(93, 4);
      this.lmLabel1.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel1.Name = "lmLabel1";
      this.lmLabel1.Size = new System.Drawing.Size(43, 19);
      this.lmLabel1.TabIndex = 98;
      this.lmLabel1.Text = "Qtd *";
      this.lmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtData
      // 
      this.txtData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtData.BorderRadius = 15;
      this.txtData.BorderSize = 2;
      this.txtData.CampoObrigatorio = true;
      this.txtData.F7ToolTipText = null;
      this.txtData.F8ToolTipText = null;
      this.txtData.F9ToolTipText = null;
      this.txtData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtData.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtData.IconF7")));
      this.txtData.IconToolTipText = null;
      this.txtData.Lines = new string[0];
      this.txtData.Location = new System.Drawing.Point(161, 23);
      this.txtData.MaxLength = 32767;
      this.txtData.Name = "txtData";
      this.txtData.PasswordChar = '\0';
      this.txtData.Propriedade = null;
      this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtData.SelectedText = "";
      this.txtData.SelectionLength = 0;
      this.txtData.SelectionStart = 0;
      this.txtData.ShortcutsEnabled = true;
      this.txtData.ShowButtonF7 = true;
      this.txtData.Size = new System.Drawing.Size(122, 31);
      this.txtData.TabIndex = 2;
      this.txtData.UnderlinedStyle = false;
      this.txtData.UseSelectable = true;
      this.txtData.Valor = LmCorbieUI.Design.LmValueType.Data;
      this.txtData.Valor_Decimais = ((short)(0));
      this.txtData.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtData.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // lmLabel3
      // 
      this.lmLabel3.AutoSize = true;
      this.lmLabel3.Location = new System.Drawing.Point(161, 4);
      this.lmLabel3.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel3.Name = "lmLabel3";
      this.lmLabel3.Size = new System.Drawing.Size(48, 19);
      this.lmLabel3.TabIndex = 96;
      this.lmLabel3.Text = "Data *";
      this.lmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtPedido
      // 
      this.txtPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtPedido.BorderRadius = 15;
      this.txtPedido.BorderSize = 2;
      this.txtPedido.CampoObrigatorio = true;
      this.txtPedido.F7ToolTipText = null;
      this.txtPedido.F8ToolTipText = null;
      this.txtPedido.F9ToolTipText = null;
      this.txtPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtPedido.IconF7 = null;
      this.txtPedido.IconToolTipText = null;
      this.txtPedido.Lines = new string[0];
      this.txtPedido.Location = new System.Drawing.Point(3, 23);
      this.txtPedido.MaxLength = 32767;
      this.txtPedido.Name = "txtPedido";
      this.txtPedido.PasswordChar = '\0';
      this.txtPedido.Propriedade = null;
      this.txtPedido.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtPedido.SelectedText = "";
      this.txtPedido.SelectionLength = 0;
      this.txtPedido.SelectionStart = 0;
      this.txtPedido.ShortcutsEnabled = true;
      this.txtPedido.Size = new System.Drawing.Size(84, 31);
      this.txtPedido.TabIndex = 0;
      this.txtPedido.UnderlinedStyle = false;
      this.txtPedido.UseSelectable = true;
      this.txtPedido.Valor_Decimais = ((short)(0));
      this.txtPedido.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtPedido.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      // 
      // lmLabel2
      // 
      this.lmLabel2.AutoSize = true;
      this.lmLabel2.Location = new System.Drawing.Point(3, 4);
      this.lmLabel2.Margin = new System.Windows.Forms.Padding(3);
      this.lmLabel2.Name = "lmLabel2";
      this.lmLabel2.Size = new System.Drawing.Size(60, 19);
      this.lmLabel2.TabIndex = 95;
      this.lmLabel2.Text = "Pedido *";
      this.lmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtDescricao
      // 
      this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
      this.txtDescricao.BorderRadius = 15;
      this.txtDescricao.BorderSize = 2;
      this.txtDescricao.CampoObrigatorio = true;
      this.txtDescricao.F7ToolTipText = null;
      this.txtDescricao.F8ToolTipText = null;
      this.txtDescricao.F9ToolTipText = null;
      this.txtDescricao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.txtDescricao.IconF7 = ((System.Drawing.Image)(resources.GetObject("txtDescricao.IconF7")));
      this.txtDescricao.IconToolTipText = null;
      this.txtDescricao.Lines = new string[0];
      this.txtDescricao.Location = new System.Drawing.Point(3, 76);
      this.txtDescricao.MaxLength = 32767;
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.PasswordChar = '\0';
      this.txtDescricao.Propriedade = null;
      this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.txtDescricao.SelectedText = "";
      this.txtDescricao.SelectionLength = 0;
      this.txtDescricao.SelectionStart = 0;
      this.txtDescricao.ShortcutsEnabled = true;
      this.txtDescricao.ShowButtonF7 = true;
      this.txtDescricao.Size = new System.Drawing.Size(293, 31);
      this.txtDescricao.TabIndex = 3;
      this.txtDescricao.UnderlinedStyle = false;
      this.txtDescricao.UseSelectable = true;
      this.txtDescricao.Valor_Decimais = ((short)(0));
      this.txtDescricao.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
      this.txtDescricao.WaterMarkFont = new System.Drawing.Font("Segoe UI", 8.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel);
      this.txtDescricao.ButtonClickF7 += new LmCorbieUI.Controls.LmTextBox.ButClick(this.BtnDescricao_Click);
      // 
      // cmxLabel4
      // 
      this.cmxLabel4.AutoSize = true;
      this.cmxLabel4.Location = new System.Drawing.Point(3, 57);
      this.cmxLabel4.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel4.Name = "cmxLabel4";
      this.cmxLabel4.Size = new System.Drawing.Size(77, 19);
      this.cmxLabel4.TabIndex = 93;
      this.cmxLabel4.Text = "Descrição *";
      this.cmxLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnRefresh
      // 
      this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnRefresh.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnRefresh.BorderRadius = 15;
      this.btnRefresh.BorderSize = 0;
      this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
      this.btnRefresh.Location = new System.Drawing.Point(3, 114);
      this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(31, 31);
      this.btnRefresh.TabIndex = 4;
      this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnRefresh.UseVisualStyleBackColor = false;
      this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
      // 
      // btnGerarPasta
      // 
      this.btnGerarPasta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnGerarPasta.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnGerarPasta.BorderRadius = 15;
      this.btnGerarPasta.BorderSize = 0;
      this.btnGerarPasta.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnGerarPasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnGerarPasta.Image = ((System.Drawing.Image)(resources.GetObject("btnGerarPasta.Image")));
      this.btnGerarPasta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.btnGerarPasta.Location = new System.Drawing.Point(40, 114);
      this.btnGerarPasta.Margin = new System.Windows.Forms.Padding(2);
      this.btnGerarPasta.Name = "btnGerarPasta";
      this.btnGerarPasta.Size = new System.Drawing.Size(142, 31);
      this.btnGerarPasta.TabIndex = 5;
      this.btnGerarPasta.Tag = "Avançar";
      this.btnGerarPasta.Text = " Gerar Pasta";
      this.btnGerarPasta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnGerarPasta.UseVisualStyleBackColor = false;
      this.btnGerarPasta.Click += new System.EventHandler(this.BtnGerarPasta_Click);
      // 
      // btnSair
      // 
      this.btnSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
      this.btnSair.BorderColor = System.Drawing.Color.PaleVioletRed;
      this.btnSair.BorderRadius = 15;
      this.btnSair.BorderSize = 0;
      this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
      this.btnSair.Location = new System.Drawing.Point(265, 114);
      this.btnSair.Margin = new System.Windows.Forms.Padding(2);
      this.btnSair.Name = "btnSair";
      this.btnSair.Size = new System.Drawing.Size(31, 31);
      this.btnSair.TabIndex = 6;
      this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnSair.UseVisualStyleBackColor = false;
      this.btnSair.Click += new System.EventHandler(this.BtnSair_Click);
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
      this.dgv.ContextMenuStrip = this.cmsOpenFile;
      this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgv.EnabledCsvButton = true;
      this.dgv.EnabledFind = true;
      this.dgv.EnabledHideColumnsButton = true;
      this.dgv.EnabledPdfButton = true;
      this.dgv.EnabledRefreshButton = true;
      this.dgv.LimparSelecaoAposCarregar = false;
      this.dgv.Location = new System.Drawing.Point(3, 187);
      this.dgv.Margin = new System.Windows.Forms.Padding(0);
      this.dgv.MostrarRodapeBotoes = false;
      this.dgv.MostrarTotalizador = false;
      this.dgv.Name = "dgv";
      this.dgv.PermiteAutoDimensionarLinha = false;
      this.dgv.PermiteDimensionarColuna = true;
      this.dgv.PermiteOrdenarColunas = true;
      this.dgv.PermiteOrdenarLinhas = true;
      this.dgv.PermiteQuebrarLinhaCabecalho = false;
      this.dgv.PermiteSelecaoMultipla = false;
      this.dgv.PosColunasGrid = "";
      this.dgv.Size = new System.Drawing.Size(299, 292);
      this.dgv.TabIndex = 93;
      this.dgv.Texto = "";
      this.dgv.TituloRelatorio = "";
      this.dgv.UseSelectable = true;
      this.dgv.CellEnter += new LmCorbieUI.Controls.LmDataGridView.CellEvent(this.Dgv_CellEnter);
      // 
      // FrmPackList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(305, 504);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.lmControls);
      this.Controls.Add(this.lblPercDesenho);
      this.Controls.Add(this.cmxLabel6);
      this.Name = "FrmPackList";
      this.Text = "FrmMenu";
      this.cmsOpenFile.ResumeLayout(false);
      this.lmControls.ResumeLayout(false);
      this.lmControls.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmsOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmUnselectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen3D;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen2D;
    private LmCorbieUI.Controls.LmLabel lblPercDesenho;
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private LmCorbieUI.Controls.LmPanel lmControls;
    private LmCorbieUI.Controls.LmTextBox txtData;
    private LmCorbieUI.Controls.LmLabel lmLabel3;
    private LmCorbieUI.Controls.LmTextBox txtPedido;
    private LmCorbieUI.Controls.LmLabel lmLabel2;
    private LmCorbieUI.Controls.LmTextBox txtDescricao;
    private LmCorbieUI.Controls.LmLabel cmxLabel4;
    private LmCorbieUI.Controls.LmButton btnRefresh;
    private LmCorbieUI.Controls.LmButton btnGerarPasta;
    private LmCorbieUI.Controls.LmButton btnSair;
    private LmCorbieUI.Controls.LmTextBox txtQtd;
    private LmCorbieUI.Controls.LmLabel lmLabel1;
    private LmCorbieUI.Controls.LmDataGridView dgv;
  }
}