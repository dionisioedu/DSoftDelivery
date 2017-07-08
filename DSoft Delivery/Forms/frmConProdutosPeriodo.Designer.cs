namespace DSoft_Delivery
{
	partial class frmConProdutosPeriodo
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProdutosPeriodo));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cosnultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbProdutos = new System.Windows.Forms.TextBox();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.hrFinal = new System.Windows.Forms.DateTimePicker();
			this.hrInicial = new System.Windows.Forms.DateTimePicker();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.label7 = new System.Windows.Forms.Label();
			this.nmQuantidade = new System.Windows.Forms.NumericUpDown();
			this.printLittleButton1 = new DSoftCore.Controls.PrintLittleButton();
			this.refreshButton1 = new DSoftCore.Controls.RefreshButton();
			this.quitButton = new DSoftCore.Controls.QuitButton();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmQuantidade)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cosnultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(993, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cosnultaToolStripMenuItem
			// 
			this.cosnultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cosnultaToolStripMenuItem.Name = "cosnultaToolStripMenuItem";
			this.cosnultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cosnultaToolStripMenuItem.Text = "&Consulta";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.confirmarToolStripMenuItem.Text = "&Consultar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 22);
			this.toolStripMenuItem2.Text = "&Imprimir";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(276, 51);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 3;
			this.dtInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtInicial_KeyDown);
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(382, 51);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 4;
			this.dtFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFinal_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(285, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Inicial";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(389, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Final";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 103);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(467, 347);
			this.dataGridView1.TabIndex = 10;
			// 
			// tbProdutos
			// 
			this.tbProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbProdutos.Location = new System.Drawing.Point(148, 456);
			this.tbProdutos.Name = "tbProdutos";
			this.tbProdutos.ReadOnly = true;
			this.tbProdutos.Size = new System.Drawing.Size(50, 20);
			this.tbProdutos.TabIndex = 11;
			this.tbProdutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbQuantidade.Location = new System.Drawing.Point(272, 456);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(50, 20);
			this.tbQuantidade.TabIndex = 12;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbValor
			// 
			this.tbValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbValor.Location = new System.Drawing.Point(382, 456);
			this.tbValor.Name = "tbValor";
			this.tbValor.ReadOnly = true;
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 13;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(93, 459);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Produtos";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(204, 459);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(62, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Quantidade";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(328, 459);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Valor R$";
			// 
			// hrFinal
			// 
			this.hrFinal.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.hrFinal.Location = new System.Drawing.Point(382, 77);
			this.hrFinal.Name = "hrFinal";
			this.hrFinal.Size = new System.Drawing.Size(100, 20);
			this.hrFinal.TabIndex = 6;
			// 
			// hrInicial
			// 
			this.hrInicial.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.hrInicial.Location = new System.Drawing.Point(276, 77);
			this.hrInicial.Name = "hrInicial";
			this.hrInicial.Size = new System.Drawing.Size(100, 20);
			this.hrInicial.TabIndex = 5;
			// 
			// chart1
			// 
			this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(488, 103);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(493, 373);
			this.chart1.TabIndex = 21;
			this.chart1.Text = "Produtos por período";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(488, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(32, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Exibir";
			// 
			// nmQuantidade
			// 
			this.nmQuantidade.Location = new System.Drawing.Point(526, 77);
			this.nmQuantidade.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nmQuantidade.Name = "nmQuantidade";
			this.nmQuantidade.Size = new System.Drawing.Size(60, 20);
			this.nmQuantidade.TabIndex = 23;
			this.nmQuantidade.ValueChanged += new System.EventHandler(this.nmQuantidade_ValueChanged);
			// 
			// printLittleButton1
			// 
			this.printLittleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.printLittleButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.printLittleButton1.Location = new System.Drawing.Point(549, 27);
			this.printLittleButton1.Name = "printLittleButton1";
			this.printLittleButton1.Size = new System.Drawing.Size(140, 40);
			this.printLittleButton1.TabIndex = 20;
			// 
			// refreshButton1
			// 
			this.refreshButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.refreshButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.refreshButton1.Location = new System.Drawing.Point(695, 27);
			this.refreshButton1.Name = "refreshButton1";
			this.refreshButton1.Size = new System.Drawing.Size(140, 60);
			this.refreshButton1.TabIndex = 19;
			// 
			// quitButton
			// 
			this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.quitButton.BackColor = System.Drawing.Color.WhiteSmoke;
			this.quitButton.Location = new System.Drawing.Point(841, 27);
			this.quitButton.Name = "quitButton";
			this.quitButton.Size = new System.Drawing.Size(140, 60);
			this.quitButton.TabIndex = 18;
			// 
			// cbTipo
			// 
			this.cbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(15, 76);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(251, 21);
			this.cbTipo.TabIndex = 24;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 60);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Tipos de produtos";
			// 
			// frmConProdutosPeriodo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(993, 488);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbTipo);
			this.Controls.Add(this.nmQuantidade);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.printLittleButton1);
			this.Controls.Add(this.refreshButton1);
			this.Controls.Add(this.quitButton);
			this.Controls.Add(this.hrFinal);
			this.Controls.Add(this.hrInicial);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.tbProdutos);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(786, 468);
			this.Name = "frmConProdutosPeriodo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta de Produtos por Período";
			this.Load += new System.EventHandler(this.frmConProdutosPeriodo_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmQuantidade)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cosnultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbProdutos;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker hrFinal;
		private System.Windows.Forms.DateTimePicker hrInicial;
		private DSoftCore.Controls.QuitButton quitButton;
		private DSoftCore.Controls.RefreshButton refreshButton1;
		private DSoftCore.Controls.PrintLittleButton printLittleButton1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.NumericUpDown nmQuantidade;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.Label label1;
	}
}