namespace AddinFormatec
{
    partial class FrmPastaFormas
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPastaFormas));
      this.cmsOpenFile = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.tsmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmUnselectAll = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.tsmOpen3D = new System.Windows.Forms.ToolStripMenuItem();
      this.tsmOpen2D = new System.Windows.Forms.ToolStripMenuItem();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.cmxLabel6 = new LmCorbieUI.Controls.LmLabel();
      this.lblPercDesenho = new LmCorbieUI.Controls.LmLabel();
      this.lmPanel1 = new LmCorbieUI.Controls.LmPanel();
      this.btnRefresh = new LmCorbieUI.Controls.LmButton();
      this.btnGerarPasta = new LmCorbieUI.Controls.LmButton();
      this.btnSair = new LmCorbieUI.Controls.LmButton();
      this.dgv = new LmCorbieUI.Controls.LmDataGridView();
      this.cmsOpenFile.SuspendLayout();
      this.lmPanel1.SuspendLayout();
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
      // cmxLabel6
      // 
      this.cmxLabel6.Dock = System.Windows.Forms.DockStyle.Top;
      this.cmxLabel6.FontWeight = LmCorbieUI.Design.LmLabelWeight.Bold;
      this.cmxLabel6.Location = new System.Drawing.Point(3, 3);
      this.cmxLabel6.Margin = new System.Windows.Forms.Padding(3);
      this.cmxLabel6.Name = "cmxLabel6";
      this.cmxLabel6.Size = new System.Drawing.Size(247, 26);
      this.cmxLabel6.TabIndex = 89;
      this.cmxLabel6.Text = "Gerar Pasta Formas";
      // 
      // lblPercDesenho
      // 
      this.lblPercDesenho.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblPercDesenho.Location = new System.Drawing.Point(3, 425);
      this.lblPercDesenho.Margin = new System.Windows.Forms.Padding(3);
      this.lblPercDesenho.Name = "lblPercDesenho";
      this.lblPercDesenho.Size = new System.Drawing.Size(247, 22);
      this.lblPercDesenho.TabIndex = 90;
      this.lblPercDesenho.Text = "Peça 0 de 0";
      this.lblPercDesenho.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lmPanel1
      // 
      this.lmPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(215)))), ((int)(((byte)(242)))));
      this.lmPanel1.Controls.Add(this.btnRefresh);
      this.lmPanel1.Controls.Add(this.btnGerarPasta);
      this.lmPanel1.Controls.Add(this.btnSair);
      this.lmPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.lmPanel1.IsPanelMenu = false;
      this.lmPanel1.Location = new System.Drawing.Point(3, 29);
      this.lmPanel1.Name = "lmPanel1";
      this.lmPanel1.Size = new System.Drawing.Size(247, 40);
      this.lmPanel1.TabIndex = 91;
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
      this.btnRefresh.Location = new System.Drawing.Point(3, 2);
      this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.Size = new System.Drawing.Size(31, 31);
      this.btnRefresh.TabIndex = 0;
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
      this.btnGerarPasta.Location = new System.Drawing.Point(40, 2);
      this.btnGerarPasta.Margin = new System.Windows.Forms.Padding(2);
      this.btnGerarPasta.Name = "btnGerarPasta";
      this.btnGerarPasta.Size = new System.Drawing.Size(142, 31);
      this.btnGerarPasta.TabIndex = 1;
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
      this.btnSair.Location = new System.Drawing.Point(213, 2);
      this.btnSair.Margin = new System.Windows.Forms.Padding(2);
      this.btnSair.Name = "btnSair";
      this.btnSair.Size = new System.Drawing.Size(31, 31);
      this.btnSair.TabIndex = 2;
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
      this.dgv.Location = new System.Drawing.Point(3, 69);
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
      this.dgv.Size = new System.Drawing.Size(247, 356);
      this.dgv.TabIndex = 92;
      this.dgv.Texto = "";
      this.dgv.TituloRelatorio = "";
      this.dgv.UseSelectable = true;
      this.dgv.CellEnter += new LmCorbieUI.Controls.LmDataGridView.CellEvent(this.Dgv_CellEnter);
      // 
      // FrmPastaFormas
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(253, 450);
      this.Controls.Add(this.dgv);
      this.Controls.Add(this.lmPanel1);
      this.Controls.Add(this.cmxLabel6);
      this.Controls.Add(this.lblPercDesenho);
      this.Name = "FrmPastaFormas";
      this.Text = "FrmMenu";
      this.cmsOpenFile.ResumeLayout(false);
      this.lmPanel1.ResumeLayout(false);
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
    private LmCorbieUI.Controls.LmLabel cmxLabel6;
    private LmCorbieUI.Controls.LmLabel lblPercDesenho;
    private LmCorbieUI.Controls.LmPanel lmPanel1;
    private LmCorbieUI.Controls.LmButton btnRefresh;
    private LmCorbieUI.Controls.LmButton btnGerarPasta;
    private LmCorbieUI.Controls.LmButton btnSair;
    private LmCorbieUI.Controls.LmDataGridView dgv;
  }
}