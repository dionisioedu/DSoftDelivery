namespace DSoft_Delivery.Forms
{
	partial class frmRecebimentoDeProdutos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecebimentoDeProdutos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.recebimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbProdutos = new System.Windows.Forms.ComboBox();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.lbEquipamentos = new System.Windows.Forms.ListBox();
			this.btExcluir = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recebimentoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(614, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// recebimentoToolStripMenuItem
			// 
			this.recebimentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.recebimentoToolStripMenuItem.Name = "recebimentoToolStripMenuItem";
			this.recebimentoToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.recebimentoToolStripMenuItem.Text = "&Recebimento";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbProdutos
			// 
			this.cbProdutos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProdutos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProdutos.FormattingEnabled = true;
			this.cbProdutos.Location = new System.Drawing.Point(12, 66);
			this.cbProdutos.Name = "cbProdutos";
			this.cbProdutos.Size = new System.Drawing.Size(200, 21);
			this.cbProdutos.TabIndex = 1;
			this.cbProdutos.SelectedIndexChanged += new System.EventHandler(this.cbProdutos_SelectedIndexChanged);
			this.cbProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProdutos_KeyDown);
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Location = new System.Drawing.Point(218, 67);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.Size = new System.Drawing.Size(60, 20);
			this.tbQuantidade.TabIndex = 2;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQuantidade_KeyDown);
			this.tbQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuantidade_KeyPress);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(447, 64);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 3;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(528, 64);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Produto";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(215, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Quantidade";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(281, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Código";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(284, 66);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(157, 20);
			this.tbCodigo.TabIndex = 7;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			// 
			// lbEquipamentos
			// 
			this.lbEquipamentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbEquipamentos.FormattingEnabled = true;
			this.lbEquipamentos.Location = new System.Drawing.Point(12, 93);
			this.lbEquipamentos.Name = "lbEquipamentos";
			this.lbEquipamentos.Size = new System.Drawing.Size(429, 251);
			this.lbEquipamentos.TabIndex = 9;
			// 
			// btExcluir
			// 
			this.btExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExcluir.ForeColor = System.Drawing.Color.Red;
			this.btExcluir.Location = new System.Drawing.Point(447, 321);
			this.btExcluir.Name = "btExcluir";
			this.btExcluir.Size = new System.Drawing.Size(75, 23);
			this.btExcluir.TabIndex = 10;
			this.btExcluir.Text = "Excluir";
			this.btExcluir.UseVisualStyleBackColor = true;
			this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
			// 
			// frmRecebimentoDeProdutos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 356);
			this.Controls.Add(this.btExcluir);
			this.Controls.Add(this.lbEquipamentos);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.cbProdutos);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmRecebimentoDeProdutos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Recebimento de produtos";
			this.Load += new System.EventHandler(this.frmRecebimentoDeProdutos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem recebimentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbProdutos;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.ListBox lbEquipamentos;
		private System.Windows.Forms.Button btExcluir;
	}
}