namespace DSoft_Delivery.Forms
{
	partial class frmNovoItemTerco
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovoItemTerco));
			this.pbProduto = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.clItensAdicionais1 = new System.Windows.Forms.CheckedListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbObservacao1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPreco1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbProduto1 = new System.Windows.Forms.ComboBox();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.clItensAdicionais2 = new System.Windows.Forms.CheckedListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbObservacao2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbPreco2 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbProduto2 = new System.Windows.Forms.ComboBox();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.clItensAdicionais3 = new System.Windows.Forms.CheckedListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbObservacao3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbPreco3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.cbProduto3 = new System.Windows.Forms.ComboBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbPreco = new System.Windows.Forms.TextBox();
			this.btSair = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.lbModoCalculo = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.pbProduto)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pbProduto
			// 
			this.pbProduto.Image = ((System.Drawing.Image)(resources.GetObject("pbProduto.Image")));
			this.pbProduto.Location = new System.Drawing.Point(388, 12);
			this.pbProduto.Name = "pbProduto";
			this.pbProduto.Size = new System.Drawing.Size(100, 100);
			this.pbProduto.TabIndex = 0;
			this.pbProduto.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(120, 58);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(51, 13);
			this.linkLabel1.TabIndex = 66;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Adicionar";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// clItensAdicionais1
			// 
			this.clItensAdicionais1.CheckOnClick = true;
			this.clItensAdicionais1.FormattingEnabled = true;
			this.clItensAdicionais1.Location = new System.Drawing.Point(177, 61);
			this.clItensAdicionais1.Name = "clItensAdicionais1";
			this.clItensAdicionais1.ScrollAlwaysVisible = true;
			this.clItensAdicionais1.Size = new System.Drawing.Size(205, 79);
			this.clItensAdicionais1.TabIndex = 65;
			this.clItensAdicionais1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clItensAdicionais_ItemCheck);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 58);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 64;
			this.label5.Text = "Observação";
			// 
			// tbObservacao1
			// 
			this.tbObservacao1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao1.Location = new System.Drawing.Point(12, 74);
			this.tbObservacao1.Multiline = true;
			this.tbObservacao1.Name = "tbObservacao1";
			this.tbObservacao1.Size = new System.Drawing.Size(157, 55);
			this.tbObservacao1.TabIndex = 60;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(255, 38);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 63;
			this.label3.Text = "R$";
			// 
			// tbPreco1
			// 
			this.tbPreco1.Location = new System.Drawing.Point(282, 35);
			this.tbPreco1.Name = "tbPreco1";
			this.tbPreco1.ReadOnly = true;
			this.tbPreco1.Size = new System.Drawing.Size(100, 20);
			this.tbPreco1.TabIndex = 62;
			this.tbPreco1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 61;
			this.label1.Text = "Produto";
			// 
			// cbProduto1
			// 
			this.cbProduto1.FormattingEnabled = true;
			this.cbProduto1.Location = new System.Drawing.Point(12, 34);
			this.cbProduto1.Name = "cbProduto1";
			this.cbProduto1.Size = new System.Drawing.Size(210, 21);
			this.cbProduto1.TabIndex = 59;
			this.cbProduto1.SelectedIndexChanged += new System.EventHandler(this.cbProduto1_SelectedIndexChanged);
			this.cbProduto1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto1_KeyDown);
			this.cbProduto1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProduto_KeyPress);
			this.cbProduto1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbProduto_KeyUp);
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new System.Drawing.Point(372, 210);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(51, 13);
			this.linkLabel2.TabIndex = 74;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Adicionar";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// clItensAdicionais2
			// 
			this.clItensAdicionais2.CheckOnClick = true;
			this.clItensAdicionais2.FormattingEnabled = true;
			this.clItensAdicionais2.Location = new System.Drawing.Point(429, 213);
			this.clItensAdicionais2.Name = "clItensAdicionais2";
			this.clItensAdicionais2.ScrollAlwaysVisible = true;
			this.clItensAdicionais2.Size = new System.Drawing.Size(205, 79);
			this.clItensAdicionais2.TabIndex = 73;
			this.clItensAdicionais2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clItensAdicionais_ItemCheck);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(261, 210);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 72;
			this.label2.Text = "Observação";
			// 
			// tbObservacao2
			// 
			this.tbObservacao2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao2.Location = new System.Drawing.Point(264, 226);
			this.tbObservacao2.Multiline = true;
			this.tbObservacao2.Name = "tbObservacao2";
			this.tbObservacao2.Size = new System.Drawing.Size(157, 55);
			this.tbObservacao2.TabIndex = 68;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(507, 190);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 71;
			this.label4.Text = "R$";
			// 
			// tbPreco2
			// 
			this.tbPreco2.Location = new System.Drawing.Point(534, 187);
			this.tbPreco2.Name = "tbPreco2";
			this.tbPreco2.ReadOnly = true;
			this.tbPreco2.Size = new System.Drawing.Size(100, 20);
			this.tbPreco2.TabIndex = 70;
			this.tbPreco2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(264, 170);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 69;
			this.label6.Text = "Produto";
			// 
			// cbProduto2
			// 
			this.cbProduto2.FormattingEnabled = true;
			this.cbProduto2.Location = new System.Drawing.Point(264, 186);
			this.cbProduto2.Name = "cbProduto2";
			this.cbProduto2.Size = new System.Drawing.Size(210, 21);
			this.cbProduto2.TabIndex = 67;
			this.cbProduto2.SelectedIndexChanged += new System.EventHandler(this.cbProduto2_SelectedIndexChanged);
			this.cbProduto2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto2_KeyDown);
			this.cbProduto2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProduto_KeyPress);
			this.cbProduto2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbProduto_KeyUp);
			// 
			// linkLabel3
			// 
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Location = new System.Drawing.Point(602, 58);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(51, 13);
			this.linkLabel3.TabIndex = 82;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Adicionar";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
			// 
			// clItensAdicionais3
			// 
			this.clItensAdicionais3.CheckOnClick = true;
			this.clItensAdicionais3.FormattingEnabled = true;
			this.clItensAdicionais3.Location = new System.Drawing.Point(659, 61);
			this.clItensAdicionais3.Name = "clItensAdicionais3";
			this.clItensAdicionais3.ScrollAlwaysVisible = true;
			this.clItensAdicionais3.Size = new System.Drawing.Size(205, 79);
			this.clItensAdicionais3.TabIndex = 81;
			this.clItensAdicionais3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clItensAdicionais_ItemCheck);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(491, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 13);
			this.label7.TabIndex = 80;
			this.label7.Text = "Observação";
			// 
			// tbObservacao3
			// 
			this.tbObservacao3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao3.Location = new System.Drawing.Point(494, 74);
			this.tbObservacao3.Multiline = true;
			this.tbObservacao3.Name = "tbObservacao3";
			this.tbObservacao3.Size = new System.Drawing.Size(157, 55);
			this.tbObservacao3.TabIndex = 76;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(737, 38);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 79;
			this.label8.Text = "R$";
			// 
			// tbPreco3
			// 
			this.tbPreco3.Location = new System.Drawing.Point(764, 35);
			this.tbPreco3.Name = "tbPreco3";
			this.tbPreco3.ReadOnly = true;
			this.tbPreco3.Size = new System.Drawing.Size(100, 20);
			this.tbPreco3.TabIndex = 78;
			this.tbPreco3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(494, 18);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(44, 13);
			this.label9.TabIndex = 77;
			this.label9.Text = "Produto";
			// 
			// cbProduto3
			// 
			this.cbProduto3.FormattingEnabled = true;
			this.cbProduto3.Location = new System.Drawing.Point(494, 34);
			this.cbProduto3.Name = "cbProduto3";
			this.cbProduto3.Size = new System.Drawing.Size(210, 21);
			this.cbProduto3.TabIndex = 75;
			this.cbProduto3.SelectedIndexChanged += new System.EventHandler(this.cbProduto3_SelectedIndexChanged);
			this.cbProduto3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProduto3_KeyDown);
			this.cbProduto3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbProduto_KeyPress);
			this.cbProduto3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbProduto_KeyUp);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(361, 339);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 95;
			this.label14.Text = "R$";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(388, 321);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(35, 13);
			this.label13.TabIndex = 94;
			this.label13.Text = "Preço";
			// 
			// tbPreco
			// 
			this.tbPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPreco.Location = new System.Drawing.Point(388, 337);
			this.tbPreco.Name = "tbPreco";
			this.tbPreco.ReadOnly = true;
			this.tbPreco.Size = new System.Drawing.Size(100, 24);
			this.tbPreco.TabIndex = 93;
			this.tbPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPreco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPreco_KeyDown);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(741, 337);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 92;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(612, 337);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 91;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// lbModoCalculo
			// 
			this.lbModoCalculo.AutoSize = true;
			this.lbModoCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbModoCalculo.Location = new System.Drawing.Point(9, 339);
			this.lbModoCalculo.Name = "lbModoCalculo";
			this.lbModoCalculo.Size = new System.Drawing.Size(0, 15);
			this.lbModoCalculo.TabIndex = 96;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pedidoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(907, 24);
			this.menuStrip1.TabIndex = 97;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// pedidoToolStripMenuItem
			// 
			this.pedidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.pedidoToolStripMenuItem.Name = "pedidoToolStripMenuItem";
			this.pedidoToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.pedidoToolStripMenuItem.Text = "Pedido";
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
			// frmNovoItemTerco
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 394);
			this.Controls.Add(this.lbModoCalculo);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tbPreco);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.clItensAdicionais3);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbObservacao3);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbPreco3);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cbProduto3);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.clItensAdicionais2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbObservacao2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbPreco2);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cbProduto2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.clItensAdicionais1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbObservacao1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbPreco1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbProduto1);
			this.Controls.Add(this.pbProduto);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNovoItemTerco";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Novo item 3/3";
			this.Load += new System.EventHandler(this.frmNovoItemTerco_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbProduto)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbProduto;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.CheckedListBox clItensAdicionais1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbObservacao1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPreco1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbProduto1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.CheckedListBox clItensAdicionais2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbObservacao2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbPreco2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbProduto2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.CheckedListBox clItensAdicionais3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbObservacao3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbPreco3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbProduto3;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbPreco;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Label lbModoCalculo;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pedidoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
	}
}