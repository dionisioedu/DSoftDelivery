namespace DSoft_Delivery.Forms
{
	partial class frmCadTiposDeServicos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadTiposDeServicos));
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.tbCusto = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btExcluir = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbProdutos = new System.Windows.Forms.ComboBox();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btAdicionar = new System.Windows.Forms.Button();
			this.btExcluirItem = new System.Windows.Forms.Button();
			this.btLimparLista = new System.Windows.Forms.Button();
			this.lbEquipamentos = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(12, 53);
			this.tbCodigo.MaxLength = 1;
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(39, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(57, 53);
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.Size = new System.Drawing.Size(100, 20);
			this.tbDescricao.TabIndex = 1;
			this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
			// 
			// tbValor
			// 
			this.tbValor.Location = new System.Drawing.Point(190, 53);
			this.tbValor.Name = "tbValor";
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 2;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
			// 
			// tbCusto
			// 
			this.tbCusto.Location = new System.Drawing.Point(323, 53);
			this.tbCusto.Name = "tbCusto";
			this.tbCusto.Size = new System.Drawing.Size(100, 20);
			this.tbCusto.TabIndex = 3;
			this.tbCusto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbCusto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCusto_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(54, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Descrição";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(163, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "R$";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(187, 36);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Valor";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(296, 56);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "R$";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(320, 37);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Custo";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btConfirmar.Location = new System.Drawing.Point(12, 429);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 10;
			this.btConfirmar.Text = "&Confirmar F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btExcluir
			// 
			this.btExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExcluir.Enabled = false;
			this.btExcluir.Location = new System.Drawing.Point(93, 429);
			this.btExcluir.Name = "btExcluir";
			this.btExcluir.Size = new System.Drawing.Size(75, 23);
			this.btExcluir.TabIndex = 11;
			this.btExcluir.Text = "&Excluir";
			this.btExcluir.UseVisualStyleBackColor = true;
			this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btLimpar.Location = new System.Drawing.Point(174, 429);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(75, 23);
			this.btLimpar.TabIndex = 12;
			this.btLimpar.Text = "Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btSair.Location = new System.Drawing.Point(255, 429);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 13;
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
			this.dataGridView1.Location = new System.Drawing.Point(429, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(416, 440);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(468, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// novoToolStripMenuItem
			// 
			this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
			this.novoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.novoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.novoToolStripMenuItem.Text = "&Novo";
			this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbProdutos
			// 
			this.cbProdutos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbProdutos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbProdutos.FormattingEnabled = true;
			this.cbProdutos.Location = new System.Drawing.Point(12, 122);
			this.cbProdutos.Name = "cbProdutos";
			this.cbProdutos.Size = new System.Drawing.Size(305, 21);
			this.cbProdutos.TabIndex = 16;
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbQuantidade.Location = new System.Drawing.Point(323, 122);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.Size = new System.Drawing.Size(100, 20);
			this.tbQuantidade.TabIndex = 17;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 106);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Produto";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(320, 106);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(62, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Quantidade";
			// 
			// btAdicionar
			// 
			this.btAdicionar.Location = new System.Drawing.Point(12, 149);
			this.btAdicionar.Name = "btAdicionar";
			this.btAdicionar.Size = new System.Drawing.Size(75, 23);
			this.btAdicionar.TabIndex = 20;
			this.btAdicionar.Text = "Adicionar";
			this.btAdicionar.UseVisualStyleBackColor = true;
			this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
			// 
			// btExcluirItem
			// 
			this.btExcluirItem.Location = new System.Drawing.Point(93, 149);
			this.btExcluirItem.Name = "btExcluirItem";
			this.btExcluirItem.Size = new System.Drawing.Size(75, 23);
			this.btExcluirItem.TabIndex = 21;
			this.btExcluirItem.Text = "Excluir item";
			this.btExcluirItem.UseVisualStyleBackColor = true;
			this.btExcluirItem.Click += new System.EventHandler(this.btExcluirItem_Click);
			// 
			// btLimparLista
			// 
			this.btLimparLista.Location = new System.Drawing.Point(174, 149);
			this.btLimparLista.Name = "btLimparLista";
			this.btLimparLista.Size = new System.Drawing.Size(75, 23);
			this.btLimparLista.TabIndex = 22;
			this.btLimparLista.Text = "Limpar lista";
			this.btLimparLista.UseVisualStyleBackColor = true;
			this.btLimparLista.Click += new System.EventHandler(this.btLimparLista_Click);
			// 
			// lbEquipamentos
			// 
			this.lbEquipamentos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbEquipamentos.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEquipamentos.FormattingEnabled = true;
			this.lbEquipamentos.ItemHeight = 15;
			this.lbEquipamentos.Location = new System.Drawing.Point(12, 178);
			this.lbEquipamentos.Name = "lbEquipamentos";
			this.lbEquipamentos.Size = new System.Drawing.Size(411, 229);
			this.lbEquipamentos.TabIndex = 23;
			// 
			// frmCadTiposDeServicos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(857, 464);
			this.Controls.Add(this.lbEquipamentos);
			this.Controls.Add(this.btLimparLista);
			this.Controls.Add(this.btExcluirItem);
			this.Controls.Add(this.btAdicionar);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.cbProdutos);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btExcluir);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCusto);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.tbDescricao);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(624, 333);
			this.Name = "frmCadTiposDeServicos";
			this.ShowInTaskbar = false;
			this.Text = "Cadastro de Tipos de Serviços";
			this.Load += new System.EventHandler(this.frmCadTiposDeServicos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.TextBox tbCusto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btExcluir;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbProdutos;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btAdicionar;
		private System.Windows.Forms.Button btExcluirItem;
		private System.Windows.Forms.Button btLimparLista;
		private System.Windows.Forms.ListBox lbEquipamentos;
	}
}