namespace DSoft_Delivery
{
	partial class frmEntregasCompras
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregasCompras));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.entregasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbFornecedor = new System.Windows.Forms.TextBox();
			this.tbProduto = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.tbIndice = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entregasToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// entregasToolStripMenuItem
			// 
			this.entregasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.entregasToolStripMenuItem.Name = "entregasToolStripMenuItem";
			this.entregasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.entregasToolStripMenuItem.Text = "&Entregas";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 110);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(770, 402);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// tbFornecedor
			// 
			this.tbFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbFornecedor.Location = new System.Drawing.Point(118, 84);
			this.tbFornecedor.Name = "tbFornecedor";
			this.tbFornecedor.ReadOnly = true;
			this.tbFornecedor.Size = new System.Drawing.Size(200, 20);
			this.tbFornecedor.TabIndex = 2;
			// 
			// tbProduto
			// 
			this.tbProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbProduto.Location = new System.Drawing.Point(324, 84);
			this.tbProduto.Name = "tbProduto";
			this.tbProduto.ReadOnly = true;
			this.tbProduto.Size = new System.Drawing.Size(200, 20);
			this.tbProduto.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(118, 68);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Fornecedor";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(321, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Produto";
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbQuantidade.Location = new System.Drawing.Point(530, 84);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(50, 20);
			this.tbQuantidade.TabIndex = 6;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(527, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Quantidade";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(682, 81);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(100, 23);
			this.btConfirmar.TabIndex = 8;
			this.btConfirmar.Text = "Confirmar Entrega";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 68);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Índice";
			// 
			// tbIndice
			// 
			this.tbIndice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbIndice.Location = new System.Drawing.Point(12, 84);
			this.tbIndice.Name = "tbIndice";
			this.tbIndice.ReadOnly = true;
			this.tbIndice.Size = new System.Drawing.Size(100, 20);
			this.tbIndice.TabIndex = 9;
			this.tbIndice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// frmEntregasCompras
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 524);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbIndice);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbProduto);
			this.Controls.Add(this.tbFornecedor);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmEntregasCompras";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Controle de Entregas de Compras";
			this.Load += new System.EventHandler(this.frmEntregasCompras_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem entregasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbFornecedor;
		private System.Windows.Forms.TextBox tbProduto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbIndice;
	}
}