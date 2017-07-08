namespace DSoft_Delivery
{
	partial class frmPedido2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedido2));
			this.cbProduto1 = new System.Windows.Forms.ComboBox();
			this.cbProduto2 = new System.Windows.Forms.ComboBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPreco1 = new System.Windows.Forms.TextBox();
			this.tbPreco2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbObservacao = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.tbDesconto = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbPreco = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbObservacao2 = new System.Windows.Forms.TextBox();
			this.clItensAdicionais1 = new System.Windows.Forms.CheckedListBox();
			this.clItensAdicionais2 = new System.Windows.Forms.CheckedListBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbProduto1
			// 
			this.cbProduto1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProduto1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProduto1.FormattingEnabled = true;
			this.cbProduto1.Location = new System.Drawing.Point(12, 68);
			this.cbProduto1.Name = "cbProduto1";
			this.cbProduto1.Size = new System.Drawing.Size(210, 21);
			this.cbProduto1.TabIndex = 0;
			this.cbProduto1.SelectedIndexChanged += new System.EventHandler(this.cbProduto1_SelectedIndexChanged);
			this.cbProduto1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto1_KeyDown);
			this.cbProduto1.Leave += new System.EventHandler(this.cbProduto1_Leave);
			// 
			// cbProduto2
			// 
			this.cbProduto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProduto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProduto2.FormattingEnabled = true;
			this.cbProduto2.Location = new System.Drawing.Point(12, 182);
			this.cbProduto2.Name = "cbProduto2";
			this.cbProduto2.Size = new System.Drawing.Size(210, 21);
			this.cbProduto2.TabIndex = 2;
			this.cbProduto2.SelectedIndexChanged += new System.EventHandler(this.cbProduto2_SelectedIndexChanged);
			this.cbProduto2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto2_KeyDown);
			this.cbProduto2.Leave += new System.EventHandler(this.cbProduto2_Leave);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(132, 386);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 6;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(261, 386);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 7;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(396, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// pedidoToolStripMenuItem
			// 
			this.pedidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
			this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.pedidoToolStripMenuItem.Text = "&Pedido";
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
			this.label1.Location = new System.Drawing.Point(12, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Produto";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 166);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Produto";
			// 
			// tbPreco1
			// 
			this.tbPreco1.Location = new System.Drawing.Point(282, 69);
			this.tbPreco1.Name = "tbPreco1";
			this.tbPreco1.ReadOnly = true;
			this.tbPreco1.Size = new System.Drawing.Size(100, 20);
			this.tbPreco1.TabIndex = 7;
			this.tbPreco1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbPreco2
			// 
			this.tbPreco2.Location = new System.Drawing.Point(282, 182);
			this.tbPreco2.Name = "tbPreco2";
			this.tbPreco2.ReadOnly = true;
			this.tbPreco2.Size = new System.Drawing.Size(100, 20);
			this.tbPreco2.TabIndex = 8;
			this.tbPreco2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(255, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "R$";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(255, 185);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "R$";
			// 
			// tbObservacao
			// 
			this.tbObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao.Location = new System.Drawing.Point(12, 108);
			this.tbObservacao.Multiline = true;
			this.tbObservacao.Name = "tbObservacao";
			this.tbObservacao.Size = new System.Drawing.Size(157, 55);
			this.tbObservacao.TabIndex = 1;
			this.tbObservacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbObservacao_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 92);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Observação";
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(233, 343);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(15, 13);
			this.label25.TabIndex = 53;
			this.label25.Text = "%";
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(174, 325);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(53, 13);
			this.label24.TabIndex = 52;
			this.label24.Text = "Desconto";
			// 
			// tbDesconto
			// 
			this.tbDesconto.Location = new System.Drawing.Point(177, 341);
			this.tbDesconto.Name = "tbDesconto";
			this.tbDesconto.Size = new System.Drawing.Size(50, 20);
			this.tbDesconto.TabIndex = 5;
			this.tbDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbDesconto.Enter += new System.EventHandler(this.tbDesconto_Enter);
			this.tbDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDesconto_KeyDown);
			this.tbDesconto.Leave += new System.EventHandler(this.tbDesconto_Leave);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(257, 343);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 50;
			this.label14.Text = "R$";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(284, 325);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(35, 13);
			this.label12.TabIndex = 49;
			this.label12.Text = "Preço";
			// 
			// tbPreco
			// 
			this.tbPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPreco.Location = new System.Drawing.Point(284, 341);
			this.tbPreco.Name = "tbPreco";
			this.tbPreco.ReadOnly = true;
			this.tbPreco.Size = new System.Drawing.Size(100, 21);
			this.tbPreco.TabIndex = 48;
			this.tbPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(93, 325);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(62, 13);
			this.label11.TabIndex = 47;
			this.label11.Text = "Quantidade";
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Location = new System.Drawing.Point(96, 341);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.Size = new System.Drawing.Size(50, 20);
			this.tbQuantidade.TabIndex = 4;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbQuantidade.Enter += new System.EventHandler(this.tbQuantidade_Enter);
			this.tbQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQuantidade_KeyDown);
			this.tbQuantidade.Leave += new System.EventHandler(this.tbQuantidade_Leave);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 206);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 13);
			this.label6.TabIndex = 55;
			this.label6.Text = "Observação";
			// 
			// tbObservacao2
			// 
			this.tbObservacao2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao2.Location = new System.Drawing.Point(12, 222);
			this.tbObservacao2.Multiline = true;
			this.tbObservacao2.Name = "tbObservacao2";
			this.tbObservacao2.Size = new System.Drawing.Size(157, 53);
			this.tbObservacao2.TabIndex = 3;
			// 
			// clItensAdicionais1
			// 
			this.clItensAdicionais1.CheckOnClick = true;
			this.clItensAdicionais1.FormattingEnabled = true;
			this.clItensAdicionais1.Location = new System.Drawing.Point(177, 95);
			this.clItensAdicionais1.Name = "clItensAdicionais1";
			this.clItensAdicionais1.ScrollAlwaysVisible = true;
			this.clItensAdicionais1.Size = new System.Drawing.Size(205, 79);
			this.clItensAdicionais1.TabIndex = 56;
			this.clItensAdicionais1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clItensAdicionais1_ItemCheck);
			// 
			// clItensAdicionais2
			// 
			this.clItensAdicionais2.CheckOnClick = true;
			this.clItensAdicionais2.FormattingEnabled = true;
			this.clItensAdicionais2.Location = new System.Drawing.Point(177, 209);
			this.clItensAdicionais2.Name = "clItensAdicionais2";
			this.clItensAdicionais2.ScrollAlwaysVisible = true;
			this.clItensAdicionais2.Size = new System.Drawing.Size(205, 79);
			this.clItensAdicionais2.TabIndex = 57;
			this.clItensAdicionais2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clItensAdicionais2_ItemCheck);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(120, 92);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(51, 13);
			this.linkLabel1.TabIndex = 58;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Adicionar";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(120, 206);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(51, 13);
			this.linkLabel2.TabIndex = 59;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Adicionar";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// frmPedido2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 443);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.clItensAdicionais2);
			this.Controls.Add(this.clItensAdicionais1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbObservacao2);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.tbDesconto);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbPreco);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbObservacao);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbPreco2);
			this.Controls.Add(this.tbPreco1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.cbProduto2);
			this.Controls.Add(this.cbProduto1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPedido2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pedido";
			this.Load += new System.EventHandler(this.frmPedido2_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbProduto1;
		private System.Windows.Forms.ComboBox cbProduto2;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPreco1;
		private System.Windows.Forms.TextBox tbPreco2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbObservacao;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tbDesconto;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbPreco;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbObservacao2;
		private System.Windows.Forms.CheckedListBox clItensAdicionais1;
		private System.Windows.Forms.CheckedListBox clItensAdicionais2;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
	}
}