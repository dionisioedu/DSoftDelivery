namespace DSoft_Delivery
{
	partial class frmCadTabelas
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadTabelas));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alterarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.tiposDeTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gruposDeTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaDeTabelasDePreçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaPreçosDosProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaProdutosPorTabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbAviso = new System.Windows.Forms.Label();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbTabela = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dgTabelas = new System.Windows.Forms.DataGridView();
			this.dgPrecos = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbLocacao = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbPreco = new System.Windows.Forms.TextBox();
			this.tbTributavel = new System.Windows.Forms.TextBox();
			this.tbProdutoDescricao = new System.Windows.Forms.TextBox();
			this.tbProdutoNome = new System.Windows.Forms.TextBox();
			this.tbProduto = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btDescarta = new System.Windows.Forms.Button();
			this.btConfirma = new System.Windows.Forms.Button();
			this.cbBase = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tcPrecos = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dgLocacao = new System.Windows.Forms.DataGridView();
			this.indice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabela = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btGerarLocacao = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTabelas)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPrecos)).BeginInit();
			this.tcPrecos.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgLocacao)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(981, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incluirToolStripMenuItem,
            this.alterarToolStripMenuItem,
            this.bloquearToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tiposDeTabelasToolStripMenuItem,
            this.gruposDeTabelasToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// incluirToolStripMenuItem
			// 
			this.incluirToolStripMenuItem.Name = "incluirToolStripMenuItem";
			this.incluirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.incluirToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.incluirToolStripMenuItem.Text = "&Incluir";
			this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
			// 
			// alterarToolStripMenuItem
			// 
			this.alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
			this.alterarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.alterarToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.alterarToolStripMenuItem.Text = "&Alterar";
			this.alterarToolStripMenuItem.Click += new System.EventHandler(this.alterarToolStripMenuItem_Click);
			// 
			// bloquearToolStripMenuItem
			// 
			this.bloquearToolStripMenuItem.Name = "bloquearToolStripMenuItem";
			this.bloquearToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.bloquearToolStripMenuItem.Text = "&Bloquear";
			this.bloquearToolStripMenuItem.Click += new System.EventHandler(this.bloquearToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.cancelarToolStripMenuItem.Text = "&Cancelar";
			this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
			// 
			// tiposDeTabelasToolStripMenuItem
			// 
			this.tiposDeTabelasToolStripMenuItem.Name = "tiposDeTabelasToolStripMenuItem";
			this.tiposDeTabelasToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.tiposDeTabelasToolStripMenuItem.Text = "Tipos de Tabelas";
			// 
			// gruposDeTabelasToolStripMenuItem
			// 
			this.gruposDeTabelasToolStripMenuItem.Name = "gruposDeTabelasToolStripMenuItem";
			this.gruposDeTabelasToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.gruposDeTabelasToolStripMenuItem.Text = "Grupos de Tabelas";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeTabelasDePreçosToolStripMenuItem,
            this.listaPreçosDosProdutosToolStripMenuItem,
            this.listaProdutosPorTabelasToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "&Relatórios";
			// 
			// listaDeTabelasDePreçosToolStripMenuItem
			// 
			this.listaDeTabelasDePreçosToolStripMenuItem.Name = "listaDeTabelasDePreçosToolStripMenuItem";
			this.listaDeTabelasDePreçosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.listaDeTabelasDePreçosToolStripMenuItem.Text = "Lista de Tabelas de Preços";
			// 
			// listaPreçosDosProdutosToolStripMenuItem
			// 
			this.listaPreçosDosProdutosToolStripMenuItem.Name = "listaPreçosDosProdutosToolStripMenuItem";
			this.listaPreçosDosProdutosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.listaPreçosDosProdutosToolStripMenuItem.Text = "Lista Preços dos Produtos";
			// 
			// listaProdutosPorTabelasToolStripMenuItem
			// 
			this.listaProdutosPorTabelasToolStripMenuItem.Name = "listaProdutosPorTabelasToolStripMenuItem";
			this.listaProdutosPorTabelasToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
			this.listaProdutosPorTabelasToolStripMenuItem.Text = "Lista Produtos por Tabelas";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbAviso);
			this.groupBox1.Controls.Add(this.tbDescricao);
			this.groupBox1.Controls.Add(this.tbNome);
			this.groupBox1.Controls.Add(this.tbTabela);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(337, 150);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// lbAviso
			// 
			this.lbAviso.AutoSize = true;
			this.lbAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAviso.ForeColor = System.Drawing.Color.Red;
			this.lbAviso.Location = new System.Drawing.Point(150, 16);
			this.lbAviso.Name = "lbAviso";
			this.lbAviso.Size = new System.Drawing.Size(0, 13);
			this.lbAviso.TabIndex = 10;
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(6, 71);
			this.tbDescricao.Multiline = true;
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDescricao.Size = new System.Drawing.Size(325, 73);
			this.tbDescricao.TabIndex = 9;
			this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(112, 32);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(200, 20);
			this.tbNome.TabIndex = 8;
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// tbTabela
			// 
			this.tbTabela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTabela.Location = new System.Drawing.Point(6, 32);
			this.tbTabela.Name = "tbTabela";
			this.tbTabela.Size = new System.Drawing.Size(100, 20);
			this.tbTabela.TabIndex = 7;
			this.tbTabela.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
			this.tbTabela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			this.tbTabela.Leave += new System.EventHandler(this.textBox1_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Descrição";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(109, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nome";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Código";
			// 
			// dgTabelas
			// 
			this.dgTabelas.AllowUserToAddRows = false;
			this.dgTabelas.AllowUserToDeleteRows = false;
			this.dgTabelas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgTabelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgTabelas.Location = new System.Drawing.Point(355, 27);
			this.dgTabelas.Name = "dgTabelas";
			this.dgTabelas.ReadOnly = true;
			this.dgTabelas.RowHeadersWidth = 18;
			this.dgTabelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgTabelas.Size = new System.Drawing.Size(614, 150);
			this.dgTabelas.TabIndex = 2;
			this.dgTabelas.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// dgPrecos
			// 
			this.dgPrecos.AllowUserToAddRows = false;
			this.dgPrecos.AllowUserToDeleteRows = false;
			this.dgPrecos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgPrecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgPrecos.Location = new System.Drawing.Point(12, 283);
			this.dgPrecos.Name = "dgPrecos";
			this.dgPrecos.ReadOnly = true;
			this.dgPrecos.RowHeadersWidth = 18;
			this.dgPrecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgPrecos.Size = new System.Drawing.Size(676, 295);
			this.dgPrecos.TabIndex = 3;
			this.dgPrecos.DoubleClick += new System.EventHandler(this.dataGridView2_DoubleClick);
			this.dgPrecos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPrecos_KeyDown);
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(12, 183);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "&Incluir - F2";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.Enabled = false;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(93, 183);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "&Alterar - F3";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.AutoSize = true;
			this.button3.Enabled = false;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(174, 183);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 6;
			this.button3.Text = "&Bloquear";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.AutoSize = true;
			this.button4.Enabled = false;
			this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button4.Location = new System.Drawing.Point(255, 183);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(80, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "&Cancelar - F4";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.AutoSize = true;
			this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button5.Location = new System.Drawing.Point(341, 183);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(82, 23);
			this.button5.TabIndex = 8;
			this.button5.Text = "Limpar Dados";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button6.AutoSize = true;
			this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button6.Location = new System.Drawing.Point(894, 183);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 9;
			this.button6.Text = "&Sair - F10";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(294, 262);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(140, 18);
			this.label4.TabIndex = 10;
			this.label4.Text = "Tabela de Preços";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 146);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 15);
			this.label5.TabIndex = 23;
			this.label5.Text = "Locação R$";
			// 
			// tbLocacao
			// 
			this.tbLocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbLocacao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.tbLocacao.Location = new System.Drawing.Point(101, 140);
			this.tbLocacao.Name = "tbLocacao";
			this.tbLocacao.Size = new System.Drawing.Size(145, 26);
			this.tbLocacao.TabIndex = 22;
			this.tbLocacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbLocacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLocacao_KeyPress);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(37, 178);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(58, 15);
			this.label11.TabIndex = 21;
			this.label11.Text = "Trib. R$";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(29, 114);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 15);
			this.label9.TabIndex = 19;
			this.label9.Text = "Preço R$";
			this.label9.Click += new System.EventHandler(this.label9_Click);
			// 
			// tbPreco
			// 
			this.tbPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPreco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.tbPreco.Location = new System.Drawing.Point(101, 108);
			this.tbPreco.Name = "tbPreco";
			this.tbPreco.Size = new System.Drawing.Size(145, 26);
			this.tbPreco.TabIndex = 18;
			this.tbPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPreco.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
			this.tbPreco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
			// 
			// tbTributavel
			// 
			this.tbTributavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTributavel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.tbTributavel.Location = new System.Drawing.Point(101, 172);
			this.tbTributavel.Name = "tbTributavel";
			this.tbTributavel.Size = new System.Drawing.Size(145, 26);
			this.tbTributavel.TabIndex = 20;
			this.tbTributavel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTributavel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTributavel_KeyPress);
			// 
			// tbProdutoDescricao
			// 
			this.tbProdutoDescricao.Location = new System.Drawing.Point(6, 58);
			this.tbProdutoDescricao.Multiline = true;
			this.tbProdutoDescricao.Name = "tbProdutoDescricao";
			this.tbProdutoDescricao.ReadOnly = true;
			this.tbProdutoDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbProdutoDescricao.Size = new System.Drawing.Size(240, 44);
			this.tbProdutoDescricao.TabIndex = 16;
			this.tbProdutoDescricao.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// tbProdutoNome
			// 
			this.tbProdutoNome.Location = new System.Drawing.Point(112, 19);
			this.tbProdutoNome.Name = "tbProdutoNome";
			this.tbProdutoNome.ReadOnly = true;
			this.tbProdutoNome.Size = new System.Drawing.Size(134, 20);
			this.tbProdutoNome.TabIndex = 15;
			this.tbProdutoNome.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
			// 
			// tbProduto
			// 
			this.tbProduto.Location = new System.Drawing.Point(6, 19);
			this.tbProduto.Name = "tbProduto";
			this.tbProduto.ReadOnly = true;
			this.tbProduto.Size = new System.Drawing.Size(100, 20);
			this.tbProduto.TabIndex = 14;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 42);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(55, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Descrição";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(109, 3);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Nome";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 3);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Código";
			// 
			// btDescarta
			// 
			this.btDescarta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btDescarta.Enabled = false;
			this.btDescarta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btDescarta.Location = new System.Drawing.Point(138, 212);
			this.btDescarta.Name = "btDescarta";
			this.btDescarta.Size = new System.Drawing.Size(123, 45);
			this.btDescarta.TabIndex = 12;
			this.btDescarta.Text = "Descarta";
			this.btDescarta.UseVisualStyleBackColor = true;
			this.btDescarta.Click += new System.EventHandler(this.button7_Click);
			// 
			// btConfirma
			// 
			this.btConfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btConfirma.Enabled = false;
			this.btConfirma.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirma.Location = new System.Drawing.Point(9, 212);
			this.btConfirma.Name = "btConfirma";
			this.btConfirma.Size = new System.Drawing.Size(123, 45);
			this.btConfirma.TabIndex = 13;
			this.btConfirma.Text = "Confirma";
			this.btConfirma.UseVisualStyleBackColor = true;
			this.btConfirma.Click += new System.EventHandler(this.button8_Click);
			// 
			// cbBase
			// 
			this.cbBase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbBase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBase.FormattingEnabled = true;
			this.cbBase.Location = new System.Drawing.Point(12, 256);
			this.cbBase.Name = "cbBase";
			this.cbBase.Size = new System.Drawing.Size(200, 21);
			this.cbBase.TabIndex = 14;
			this.cbBase.SelectedIndexChanged += new System.EventHandler(this.cbBase_SelectedIndexChanged);
			this.cbBase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBase_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 240);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(67, 13);
			this.label10.TabIndex = 11;
			this.label10.Text = "Tabela Base";
			// 
			// tcPrecos
			// 
			this.tcPrecos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tcPrecos.Controls.Add(this.tabPage1);
			this.tcPrecos.Controls.Add(this.tabPage2);
			this.tcPrecos.Location = new System.Drawing.Point(694, 289);
			this.tcPrecos.Name = "tcPrecos";
			this.tcPrecos.SelectedIndex = 0;
			this.tcPrecos.Size = new System.Drawing.Size(275, 289);
			this.tcPrecos.TabIndex = 15;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.tbLocacao);
			this.tabPage1.Controls.Add(this.btConfirma);
			this.tabPage1.Controls.Add(this.btDescarta);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.tbProduto);
			this.tabPage1.Controls.Add(this.tbPreco);
			this.tabPage1.Controls.Add(this.tbProdutoNome);
			this.tabPage1.Controls.Add(this.tbTributavel);
			this.tabPage1.Controls.Add(this.tbProdutoDescricao);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(267, 263);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Produto";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dgLocacao);
			this.tabPage2.Controls.Add(this.btGerarLocacao);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(267, 263);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Locação";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dgLocacao
			// 
			this.dgLocacao.AllowUserToAddRows = false;
			this.dgLocacao.AllowUserToDeleteRows = false;
			this.dgLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgLocacao.ColumnHeadersVisible = false;
			this.dgLocacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.indice,
            this.tabela,
            this.produto,
            this.descricao,
            this.preco});
			this.dgLocacao.Location = new System.Drawing.Point(6, 35);
			this.dgLocacao.Name = "dgLocacao";
			this.dgLocacao.RowHeadersWidth = 18;
			this.dgLocacao.Size = new System.Drawing.Size(255, 222);
			this.dgLocacao.TabIndex = 1;
			this.dgLocacao.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgLocacao_CellValidating);
			// 
			// indice
			// 
			this.indice.HeaderText = "Índice";
			this.indice.Name = "indice";
			this.indice.Visible = false;
			// 
			// tabela
			// 
			this.tabela.HeaderText = "Tabela";
			this.tabela.Name = "tabela";
			this.tabela.Visible = false;
			// 
			// produto
			// 
			this.produto.HeaderText = "Produto";
			this.produto.Name = "produto";
			this.produto.Visible = false;
			// 
			// descricao
			// 
			this.descricao.HeaderText = "Descrição";
			this.descricao.Name = "descricao";
			this.descricao.ReadOnly = true;
			// 
			// preco
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.Format = "##,###,##0.00";
			this.preco.DefaultCellStyle = dataGridViewCellStyle1;
			this.preco.HeaderText = "Preço";
			this.preco.Name = "preco";
			// 
			// btGerarLocacao
			// 
			this.btGerarLocacao.Location = new System.Drawing.Point(6, 6);
			this.btGerarLocacao.Name = "btGerarLocacao";
			this.btGerarLocacao.Size = new System.Drawing.Size(75, 23);
			this.btGerarLocacao.TabIndex = 0;
			this.btGerarLocacao.Text = "Gerar itens";
			this.btGerarLocacao.UseVisualStyleBackColor = true;
			this.btGerarLocacao.Click += new System.EventHandler(this.btGerarLocacao_Click);
			// 
			// frmCadTabelas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(981, 590);
			this.Controls.Add(this.tcPrecos);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.cbBase);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgPrecos);
			this.Controls.Add(this.dgTabelas);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(746, 561);
			this.Name = "frmCadTabelas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tabelas de preços";
			this.Load += new System.EventHandler(this.frmCadTabelas_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTabelas)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPrecos)).EndInit();
			this.tcPrecos.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgLocacao)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem incluirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem alterarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bloquearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem tiposDeTabelasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gruposDeTabelasToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listaDeTabelasDePreçosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listaPreçosDosProdutosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listaProdutosPorTabelasToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridView dgTabelas;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgPrecos;
		private System.Windows.Forms.TextBox tbTabela;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label lbAviso;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbProdutoDescricao;
		private System.Windows.Forms.TextBox tbProdutoNome;
		private System.Windows.Forms.TextBox tbProduto;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btDescarta;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbPreco;
		private System.Windows.Forms.Button btConfirma;
		private System.Windows.Forms.ComboBox cbBase;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbTributavel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbLocacao;
		private System.Windows.Forms.TabControl tcPrecos;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView dgLocacao;
		private System.Windows.Forms.Button btGerarLocacao;
		private System.Windows.Forms.DataGridViewTextBoxColumn indice;
		private System.Windows.Forms.DataGridViewTextBoxColumn tabela;
		private System.Windows.Forms.DataGridViewTextBoxColumn produto;
		private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
		private System.Windows.Forms.DataGridViewTextBoxColumn preco;
	}
}