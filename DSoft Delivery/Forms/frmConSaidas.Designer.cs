namespace DSoft_Delivery.Forms
{
	partial class frmConSaidas
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConSaidas));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dtInicio = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.cbCaixa = new System.Windows.Forms.ComboBox();
			this.cbUsuario = new System.Windows.Forms.ComboBox();
			this.refreshButton1 = new DSoftCore.Controls.RefreshButton();
			this.quitButton1 = new DSoftCore.Controls.QuitButton();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.lbQuantidade = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(894, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "&Consulta";
			// 
			// consultarToolStripMenuItem
			// 
			this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
			this.consultarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.consultarToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.consultarToolStripMenuItem.Text = "&Consultar";
			this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dtInicio
			// 
			this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicio.Location = new System.Drawing.Point(12, 69);
			this.dtInicio.Name = "dtInicio";
			this.dtInicio.Size = new System.Drawing.Size(100, 20);
			this.dtInicio.TabIndex = 1;
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(118, 69);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 2;
			// 
			// cbCaixa
			// 
			this.cbCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCaixa.FormattingEnabled = true;
			this.cbCaixa.Location = new System.Drawing.Point(224, 68);
			this.cbCaixa.Name = "cbCaixa";
			this.cbCaixa.Size = new System.Drawing.Size(160, 21);
			this.cbCaixa.TabIndex = 3;
			// 
			// cbUsuario
			// 
			this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUsuario.FormattingEnabled = true;
			this.cbUsuario.Location = new System.Drawing.Point(390, 68);
			this.cbUsuario.Name = "cbUsuario";
			this.cbUsuario.Size = new System.Drawing.Size(160, 21);
			this.cbUsuario.TabIndex = 4;
			// 
			// refreshButton1
			// 
			this.refreshButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.refreshButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.refreshButton1.Location = new System.Drawing.Point(596, 29);
			this.refreshButton1.Name = "refreshButton1";
			this.refreshButton1.Size = new System.Drawing.Size(140, 60);
			this.refreshButton1.TabIndex = 5;
			// 
			// quitButton1
			// 
			this.quitButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.quitButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.quitButton1.Location = new System.Drawing.Point(742, 29);
			this.quitButton1.Name = "quitButton1";
			this.quitButton1.Size = new System.Drawing.Size(140, 60);
			this.quitButton1.TabIndex = 6;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 95);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(870, 284);
			this.dataGridView1.TabIndex = 7;
			// 
			// tbTotal
			// 
			this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbTotal.Location = new System.Drawing.Point(782, 385);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(100, 20);
			this.tbTotal.TabIndex = 8;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbQuantidade
			// 
			this.lbQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbQuantidade.AutoSize = true;
			this.lbQuantidade.Location = new System.Drawing.Point(12, 388);
			this.lbQuantidade.Name = "lbQuantidade";
			this.lbQuantidade.Size = new System.Drawing.Size(68, 13);
			this.lbQuantidade.TabIndex = 9;
			this.lbQuantidade.Text = "Quantidade: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(728, 388);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Total R$";
			// 
			// frmConSaidas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(894, 417);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbQuantidade);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.quitButton1);
			this.Controls.Add(this.refreshButton1);
			this.Controls.Add(this.cbUsuario);
			this.Controls.Add(this.cbCaixa);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicio);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmConSaidas";
			this.ShowInTaskbar = false;
			this.Text = "Consulta de Retiradas";
			this.Load += new System.EventHandler(this.fmConsultaSaidas_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DateTimePicker dtInicio;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.ComboBox cbCaixa;
		private System.Windows.Forms.ComboBox cbUsuario;
		private DSoftCore.Controls.RefreshButton refreshButton1;
		private DSoftCore.Controls.QuitButton quitButton1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.Label lbQuantidade;
		private System.Windows.Forms.Label label2;
	}
}