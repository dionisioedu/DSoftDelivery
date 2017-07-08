namespace DSoft_Delivery.Forms
{
	partial class frmEntregaRapida
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaRapida));
			this.tbPedido = new System.Windows.Forms.TextBox();
			this.tbDetalhes = new System.Windows.Forms.TextBox();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.tbTroco = new System.Windows.Forms.TextBox();
			this.cbEntregadores = new System.Windows.Forms.ComboBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.entregaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTaxaEntregador = new System.Windows.Forms.TextBox();
			this.pnlTaxaPagaPorEntrega = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.pnlTaxaPagaPorEntrega.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbPedido
			// 
			this.tbPedido.Location = new System.Drawing.Point(39, 51);
			this.tbPedido.Name = "tbPedido";
			this.tbPedido.ReadOnly = true;
			this.tbPedido.Size = new System.Drawing.Size(100, 20);
			this.tbPedido.TabIndex = 1;
			this.tbPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbDetalhes
			// 
			this.tbDetalhes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDetalhes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDetalhes.Location = new System.Drawing.Point(39, 77);
			this.tbDetalhes.Multiline = true;
			this.tbDetalhes.Name = "tbDetalhes";
			this.tbDetalhes.ReadOnly = true;
			this.tbDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDetalhes.Size = new System.Drawing.Size(480, 124);
			this.tbDetalhes.TabIndex = 2;
			// 
			// tbTotal
			// 
			this.tbTotal.Location = new System.Drawing.Point(419, 207);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(100, 20);
			this.tbTotal.TabIndex = 3;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbTroco
			// 
			this.tbTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTroco.Location = new System.Drawing.Point(419, 233);
			this.tbTroco.Name = "tbTroco";
			this.tbTroco.ReadOnly = true;
			this.tbTroco.Size = new System.Drawing.Size(100, 20);
			this.tbTroco.TabIndex = 4;
			this.tbTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cbEntregadores
			// 
			this.cbEntregadores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbEntregadores.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbEntregadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEntregadores.FormattingEnabled = true;
			this.cbEntregadores.Location = new System.Drawing.Point(283, 277);
			this.cbEntregadores.Name = "cbEntregadores";
			this.cbEntregadores.Size = new System.Drawing.Size(236, 21);
			this.cbEntregadores.TabIndex = 0;
			this.cbEntregadores.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEntregadores_KeyDown);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(330, 349);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(108, 40);
			this.btConfirmar.TabIndex = 5;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Location = new System.Drawing.Point(444, 366);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 6;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 92;
			this.label1.Text = "Pedido";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(315, 210);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 93;
			this.label2.Text = "Total do pedido R$";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(361, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 94;
			this.label3.Text = "Troco R$";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(280, 261);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 95;
			this.label4.Text = "Entregadores";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entregaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(506, 24);
			this.menuStrip1.TabIndex = 96;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// entregaToolStripMenuItem
			// 
			this.entregaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.entregaToolStripMenuItem.Name = "entregaToolStripMenuItem";
			this.entregaToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.entregaToolStripMenuItem.Text = "&Entrega";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(12, 376);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(86, 13);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Versão completa";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(54, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 98;
			this.label5.Text = "Entregador R$";
			// 
			// tbTaxaEntregador
			// 
			this.tbTaxaEntregador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTaxaEntregador.Location = new System.Drawing.Point(136, 5);
			this.tbTaxaEntregador.Name = "tbTaxaEntregador";
			this.tbTaxaEntregador.Size = new System.Drawing.Size(100, 21);
			this.tbTaxaEntregador.TabIndex = 97;
			this.tbTaxaEntregador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTaxaEntregador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTaxaEntregador_KeyPress);
			// 
			// pnlTaxaPagaPorEntrega
			// 
			this.pnlTaxaPagaPorEntrega.Controls.Add(this.tbTaxaEntregador);
			this.pnlTaxaPagaPorEntrega.Controls.Add(this.label5);
			this.pnlTaxaPagaPorEntrega.Location = new System.Drawing.Point(283, 299);
			this.pnlTaxaPagaPorEntrega.Name = "pnlTaxaPagaPorEntrega";
			this.pnlTaxaPagaPorEntrega.Size = new System.Drawing.Size(243, 44);
			this.pnlTaxaPagaPorEntrega.TabIndex = 99;
			this.pnlTaxaPagaPorEntrega.Visible = false;
			// 
			// frmEntregaRapida
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(561, 401);
			this.Controls.Add(this.pnlTaxaPagaPorEntrega);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.cbEntregadores);
			this.Controls.Add(this.tbTroco);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.tbDetalhes);
			this.Controls.Add(this.tbPedido);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEntregaRapida";
			this.ShowInTaskbar = false;
			this.Text = "Entrega Rápida";
			this.Load += new System.EventHandler(this.frmEntregaRapida_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntregaRapida_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.pnlTaxaPagaPorEntrega.ResumeLayout(false);
			this.pnlTaxaPagaPorEntrega.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbPedido;
		private System.Windows.Forms.TextBox tbDetalhes;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.TextBox tbTroco;
		private System.Windows.Forms.ComboBox cbEntregadores;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem entregaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTaxaEntregador;
		private System.Windows.Forms.Panel pnlTaxaPagaPorEntrega;
	}
}