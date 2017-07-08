namespace DSoft_Delivery
{
	partial class frmFiltroPedidosCliente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroPedidosCliente));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbCliente = new System.Windows.Forms.Label();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btSair = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.relatórioToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(394, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// relatórioToolStripMenuItem
			// 
			this.relatórioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
			this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.relatórioToolStripMenuItem.Text = "&Relatório";
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
			// lbCliente
			// 
			this.lbCliente.AutoSize = true;
			this.lbCliente.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbCliente.Location = new System.Drawing.Point(168, 134);
			this.lbCliente.Name = "lbCliente";
			this.lbCliente.Size = new System.Drawing.Size(0, 13);
			this.lbCliente.TabIndex = 24;
			// 
			// tbCliente
			// 
			this.tbCliente.Location = new System.Drawing.Point(62, 131);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.Size = new System.Drawing.Size(100, 20);
			this.tbCliente.TabIndex = 2;
			this.tbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCliente_KeyDown);
			this.tbCliente.Leave += new System.EventHandler(this.tbCliente_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(59, 115);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 22;
			this.label3.Text = "Cliente";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(232, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Data Final";
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(235, 64);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 1;
			this.dtFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtFinal_KeyDown);
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(62, 64);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 0;
			this.dtInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtInicial_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(59, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(60, 13);
			this.label1.TabIndex = 18;
			this.label1.Text = "Data Inicial";
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(259, 217);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(130, 217);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 3;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// frmFiltroPedidosCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 274);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.lbCliente);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmFiltroPedidosCliente";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pedidos por Cliente";
			this.Load += new System.EventHandler(this.frmFiltroPedidosCliente_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label lbCliente;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btConfirmar;

	}
}