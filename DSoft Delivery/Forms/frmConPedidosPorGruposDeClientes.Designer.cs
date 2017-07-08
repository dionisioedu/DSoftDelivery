namespace DSoft_Delivery.Forms
{
	partial class frmConPedidosPorGruposDeClientes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConPedidosPorGruposDeClientes));
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.chPedidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.refreshButton1 = new DSoftCore.Controls.RefreshButton();
			this.quitButton1 = new DSoftCore.Controls.QuitButton();
			this.nmQuantidade = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.pnLoading = new System.Windows.Forms.Panel();
			this.pbLoading = new System.Windows.Forms.ProgressBar();
			this.lbLoading = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chPedidos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nmQuantidade)).BeginInit();
			this.pnLoading.SuspendLayout();
			this.SuspendLayout();
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(12, 52);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 0;
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(118, 52);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 1;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(704, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "&Consulta";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Início";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Final";
			// 
			// chPedidos
			// 
			this.chPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea1.Name = "ChartArea1";
			this.chPedidos.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chPedidos.Legends.Add(legend1);
			this.chPedidos.Location = new System.Drawing.Point(12, 78);
			this.chPedidos.Name = "chPedidos";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chPedidos.Series.Add(series1);
			this.chPedidos.Size = new System.Drawing.Size(956, 406);
			this.chPedidos.TabIndex = 7;
			this.chPedidos.Text = "chart1";
			// 
			// refreshButton1
			// 
			this.refreshButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.refreshButton1.Location = new System.Drawing.Point(290, 12);
			this.refreshButton1.Name = "refreshButton1";
			this.refreshButton1.Size = new System.Drawing.Size(140, 60);
			this.refreshButton1.TabIndex = 8;
			// 
			// quitButton1
			// 
			this.quitButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.quitButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.quitButton1.Location = new System.Drawing.Point(828, 12);
			this.quitButton1.Name = "quitButton1";
			this.quitButton1.Size = new System.Drawing.Size(140, 60);
			this.quitButton1.TabIndex = 9;
			// 
			// nmQuantidade
			// 
			this.nmQuantidade.Location = new System.Drawing.Point(224, 52);
			this.nmQuantidade.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.nmQuantidade.Name = "nmQuantidade";
			this.nmQuantidade.Size = new System.Drawing.Size(60, 20);
			this.nmQuantidade.TabIndex = 10;
			this.nmQuantidade.ValueChanged += new System.EventHandler(this.nmQuantidade_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(221, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Quantiade";
			// 
			// pnLoading
			// 
			this.pnLoading.Controls.Add(this.lbLoading);
			this.pnLoading.Controls.Add(this.pbLoading);
			this.pnLoading.Location = new System.Drawing.Point(436, 12);
			this.pnLoading.Name = "pnLoading";
			this.pnLoading.Size = new System.Drawing.Size(386, 60);
			this.pnLoading.TabIndex = 12;
			this.pnLoading.Visible = false;
			// 
			// pbLoading
			// 
			this.pbLoading.Location = new System.Drawing.Point(3, 34);
			this.pbLoading.Name = "pbLoading";
			this.pbLoading.Size = new System.Drawing.Size(380, 23);
			this.pbLoading.TabIndex = 0;
			// 
			// lbLoading
			// 
			this.lbLoading.AutoSize = true;
			this.lbLoading.Location = new System.Drawing.Point(3, 18);
			this.lbLoading.Name = "lbLoading";
			this.lbLoading.Size = new System.Drawing.Size(103, 13);
			this.lbLoading.TabIndex = 1;
			this.lbLoading.Text = "Carregando dados...";
			// 
			// frmConPedidosPorGruposDeClientes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(980, 496);
			this.Controls.Add(this.pnLoading);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.nmQuantidade);
			this.Controls.Add(this.quitButton1);
			this.Controls.Add(this.refreshButton1);
			this.Controls.Add(this.chPedidos);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(576, 413);
			this.Name = "frmConPedidosPorGruposDeClientes";
			this.ShowInTaskbar = false;
			this.Text = "Pedidos por grupos de clientes";
			this.Load += new System.EventHandler(this.frmConPedidosPorGruposDeClientes_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chPedidos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nmQuantidade)).EndInit();
			this.pnLoading.ResumeLayout(false);
			this.pnLoading.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chPedidos;
		private DSoftCore.Controls.RefreshButton refreshButton1;
		private DSoftCore.Controls.QuitButton quitButton1;
		private System.Windows.Forms.NumericUpDown nmQuantidade;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel pnLoading;
		private System.Windows.Forms.Label lbLoading;
		private System.Windows.Forms.ProgressBar pbLoading;
	}
}