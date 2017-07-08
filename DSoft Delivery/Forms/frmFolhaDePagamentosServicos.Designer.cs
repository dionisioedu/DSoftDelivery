namespace DSoft_Delivery.Forms
{
	partial class frmFolhaDePagamentosServicos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFolhaDePagamentosServicos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.folhaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.btGerar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btPagar = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folhaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// folhaToolStripMenuItem
			// 
			this.folhaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.folhaToolStripMenuItem.Name = "folhaToolStripMenuItem";
			this.folhaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.folhaToolStripMenuItem.Text = "&Folha";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(123, 22);
			this.toolStripMenuItem2.Text = "&Gerar";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.toolStripMenuItem3.Size = new System.Drawing.Size(123, 22);
			this.toolStripMenuItem3.Text = "&Pagar";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(12, 54);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 1;
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(118, 54);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 2;
			// 
			// btGerar
			// 
			this.btGerar.Location = new System.Drawing.Point(224, 51);
			this.btGerar.Name = "btGerar";
			this.btGerar.Size = new System.Drawing.Size(75, 23);
			this.btGerar.TabIndex = 3;
			this.btGerar.Text = "&Gerar F2";
			this.btGerar.UseVisualStyleBackColor = true;
			this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Location = new System.Drawing.Point(697, 51);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 80);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(760, 336);
			this.dataGridView1.TabIndex = 5;
			// 
			// btPagar
			// 
			this.btPagar.Location = new System.Drawing.Point(305, 51);
			this.btPagar.Name = "btPagar";
			this.btPagar.Size = new System.Drawing.Size(75, 23);
			this.btPagar.TabIndex = 6;
			this.btPagar.Text = "&Pagar F3";
			this.btPagar.UseVisualStyleBackColor = true;
			this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// frmFolhaDePagamentosServicos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 469);
			this.Controls.Add(this.btPagar);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btGerar);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmFolhaDePagamentosServicos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Folha de pagamentos";
			this.Load += new System.EventHandler(this.frmFolhaDePagamentosServicos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem folhaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Button btGerar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.Button btPagar;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
	}
}