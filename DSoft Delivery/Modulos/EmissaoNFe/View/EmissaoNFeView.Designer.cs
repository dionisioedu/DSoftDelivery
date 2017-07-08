namespace DSoft_Delivery.Modulos.EmissaoNFe.View
{
	partial class EmissaoNFeView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmissaoNFeView));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.emissãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbEmitente = new System.Windows.Forms.ComboBox();
			this.dtPedidos = new System.Windows.Forms.DataGridView();
			this.dtItens = new System.Windows.Forms.DataGridView();
			this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dtNFe = new System.Windows.Forms.DataGridView();
			this.btGerarNFe = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPedido = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbData = new System.Windows.Forms.TextBox();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.lbAvisoEmitente = new System.Windows.Forms.Label();
			this.cbIndPag = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btImprimirNFe = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtPedidos)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtItens)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtNFe)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emissãoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(784, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// emissãoToolStripMenuItem
			// 
			this.emissãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.emissãoToolStripMenuItem.Name = "emissãoToolStripMenuItem";
			this.emissãoToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
			this.emissãoToolStripMenuItem.Text = "Emissão";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			// 
			// cbEmitente
			// 
			this.cbEmitente.FormattingEnabled = true;
			this.cbEmitente.Location = new System.Drawing.Point(12, 12);
			this.cbEmitente.Name = "cbEmitente";
			this.cbEmitente.Size = new System.Drawing.Size(300, 21);
			this.cbEmitente.TabIndex = 1;
			// 
			// dtPedidos
			// 
			this.dtPedidos.AllowUserToAddRows = false;
			this.dtPedidos.AllowUserToDeleteRows = false;
			this.dtPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.dtPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtPedidos.Location = new System.Drawing.Point(12, 71);
			this.dtPedidos.MultiSelect = false;
			this.dtPedidos.Name = "dtPedidos";
			this.dtPedidos.ReadOnly = true;
			this.dtPedidos.RowHeadersWidth = 18;
			this.dtPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtPedidos.Size = new System.Drawing.Size(381, 252);
			this.dtPedidos.TabIndex = 2;
			this.dtPedidos.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dtPedidos_RowPrePaint);
			this.dtPedidos.DoubleClick += new System.EventHandler(this.dtPedidos_DoubleClick);
			// 
			// dtItens
			// 
			this.dtItens.AllowUserToAddRows = false;
			this.dtItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Codigo,
            this.Produto,
            this.Quantidade,
            this.Unitario,
            this.Total});
			this.dtItens.Location = new System.Drawing.Point(430, 136);
			this.dtItens.Name = "dtItens";
			this.dtItens.RowHeadersWidth = 18;
			this.dtItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtItens.Size = new System.Drawing.Size(338, 161);
			this.dtItens.TabIndex = 3;
			this.dtItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtItens_CellFormatting);
			this.dtItens.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtItens_CellValueChanged);
			// 
			// Item
			// 
			this.Item.HeaderText = "Item";
			this.Item.Name = "Item";
			this.Item.ReadOnly = true;
			this.Item.Width = 40;
			// 
			// Codigo
			// 
			this.Codigo.HeaderText = "Código";
			this.Codigo.Name = "Codigo";
			// 
			// Produto
			// 
			this.Produto.HeaderText = "Produto";
			this.Produto.Name = "Produto";
			this.Produto.ReadOnly = true;
			// 
			// Quantidade
			// 
			this.Quantidade.HeaderText = "Quantidade";
			this.Quantidade.Name = "Quantidade";
			// 
			// Unitario
			// 
			this.Unitario.HeaderText = "Unitário";
			this.Unitario.Name = "Unitario";
			// 
			// Total
			// 
			this.Total.HeaderText = "Total";
			this.Total.Name = "Total";
			this.Total.ReadOnly = true;
			// 
			// dtNFe
			// 
			this.dtNFe.AllowUserToAddRows = false;
			this.dtNFe.AllowUserToDeleteRows = false;
			this.dtNFe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dtNFe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dtNFe.Location = new System.Drawing.Point(12, 358);
			this.dtNFe.Name = "dtNFe";
			this.dtNFe.ReadOnly = true;
			this.dtNFe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dtNFe.Size = new System.Drawing.Size(756, 142);
			this.dtNFe.TabIndex = 4;
			// 
			// btGerarNFe
			// 
			this.btGerarNFe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btGerarNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btGerarNFe.Location = new System.Drawing.Point(12, 329);
			this.btGerarNFe.Name = "btGerarNFe";
			this.btGerarNFe.Size = new System.Drawing.Size(75, 23);
			this.btGerarNFe.TabIndex = 5;
			this.btGerarNFe.Text = "Gerar NFe";
			this.btGerarNFe.UseVisualStyleBackColor = true;
			this.btGerarNFe.Click += new System.EventHandler(this.btGerarNFe_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "Pedidos";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(645, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(123, 45);
			this.button1.TabIndex = 7;
			this.button1.Text = "&Sair - F10";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbCodigo
			// 
			this.tbCodigo.Location = new System.Drawing.Point(430, 71);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.ReadOnly = true;
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 8;
			this.tbCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbCliente
			// 
			this.tbCliente.Location = new System.Drawing.Point(537, 71);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.ReadOnly = true;
			this.tbCliente.Size = new System.Drawing.Size(235, 20);
			this.tbCliente.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(427, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Código";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(537, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Cliente";
			// 
			// tbPedido
			// 
			this.tbPedido.Location = new System.Drawing.Point(430, 110);
			this.tbPedido.Name = "tbPedido";
			this.tbPedido.ReadOnly = true;
			this.tbPedido.Size = new System.Drawing.Size(100, 20);
			this.tbPedido.TabIndex = 12;
			this.tbPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(427, 94);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "Pedido";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(533, 94);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(30, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Data";
			// 
			// tbData
			// 
			this.tbData.Location = new System.Drawing.Point(536, 110);
			this.tbData.Name = "tbData";
			this.tbData.ReadOnly = true;
			this.tbData.Size = new System.Drawing.Size(100, 20);
			this.tbData.TabIndex = 14;
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbQuantidade.Location = new System.Drawing.Point(459, 303);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(50, 20);
			this.tbQuantidade.TabIndex = 16;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(423, 306);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Itens";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(614, 306);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Valor R$";
			// 
			// tbValor
			// 
			this.tbValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tbValor.Location = new System.Drawing.Point(668, 303);
			this.tbValor.Name = "tbValor";
			this.tbValor.ReadOnly = true;
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 19;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbAvisoEmitente
			// 
			this.lbAvisoEmitente.AutoSize = true;
			this.lbAvisoEmitente.ForeColor = System.Drawing.Color.Red;
			this.lbAvisoEmitente.Location = new System.Drawing.Point(318, 15);
			this.lbAvisoEmitente.Name = "lbAvisoEmitente";
			this.lbAvisoEmitente.Size = new System.Drawing.Size(119, 13);
			this.lbAvisoEmitente.TabIndex = 20;
			this.lbAvisoEmitente.Text = "*Selecione um Emitente";
			this.lbAvisoEmitente.Visible = false;
			// 
			// cbIndPag
			// 
			this.cbIndPag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbIndPag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbIndPag.FormattingEnabled = true;
			this.cbIndPag.Items.AddRange(new object[] {
            "0 - À Vista",
            "1 - À Prazo",
            "2 - Outros"});
			this.cbIndPag.Location = new System.Drawing.Point(642, 110);
			this.cbIndPag.Name = "cbIndPag";
			this.cbIndPag.Size = new System.Drawing.Size(121, 21);
			this.cbIndPag.TabIndex = 21;
			this.cbIndPag.Text = "0 - À Vista";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(643, 94);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(123, 13);
			this.label8.TabIndex = 22;
			this.label8.Text = "Indicador de Pagamento";
			// 
			// btImprimirNFe
			// 
			this.btImprimirNFe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btImprimirNFe.AutoSize = true;
			this.btImprimirNFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btImprimirNFe.Location = new System.Drawing.Point(93, 329);
			this.btImprimirNFe.Name = "btImprimirNFe";
			this.btImprimirNFe.Size = new System.Drawing.Size(92, 23);
			this.btImprimirNFe.TabIndex = 23;
			this.btImprimirNFe.Text = "Imprimir NFe";
			this.btImprimirNFe.UseVisualStyleBackColor = true;
			// 
			// EmissaoNFeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(780, 512);
			this.Controls.Add(this.btImprimirNFe);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cbIndPag);
			this.Controls.Add(this.lbAvisoEmitente);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbData);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbPedido);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btGerarNFe);
			this.Controls.Add(this.dtNFe);
			this.Controls.Add(this.dtItens);
			this.Controls.Add(this.dtPedidos);
			this.Controls.Add(this.cbEmitente);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimizeBox = false;
			this.Name = "EmissaoNFeView";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Emissão NFe";
			this.Load += new System.EventHandler(this.EmissaoNFeView_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtPedidos)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtItens)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtNFe)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem emissãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbEmitente;
		private System.Windows.Forms.DataGridView dtPedidos;
		private System.Windows.Forms.DataGridView dtItens;
		private System.Windows.Forms.DataGridView dtNFe;
		private System.Windows.Forms.Button btGerarNFe;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Item;
		private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
		private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
		private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
		private System.Windows.Forms.DataGridViewTextBoxColumn Unitario;
		private System.Windows.Forms.DataGridViewTextBoxColumn Total;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPedido;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbData;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Label lbAvisoEmitente;
		private System.Windows.Forms.ComboBox cbIndPag;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btImprimirNFe;
	}
}