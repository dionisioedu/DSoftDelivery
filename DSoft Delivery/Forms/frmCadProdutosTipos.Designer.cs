namespace DSoft_Delivery
{
	partial class frmCadProdutosTipos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadProdutosTipos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dgProdutosTipos = new System.Windows.Forms.DataGridView();
			this.cbFracionado = new System.Windows.Forms.CheckBox();
			this.cbMeioAMeio = new System.Windows.Forms.CheckBox();
			this.cbAdicionais = new System.Windows.Forms.CheckBox();
			this.cbImpressora = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.cbSoma = new System.Windows.Forms.CheckBox();
			this.cbEstoque = new System.Windows.Forms.CheckBox();
			this.cbProducao = new System.Windows.Forms.CheckBox();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cbImprimeTotal = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btAdicionar = new System.Windows.Forms.Button();
			this.tbPeriodoEspecial = new System.Windows.Forms.TextBox();
			this.tbLocacaoEspecial = new System.Windows.Forms.TextBox();
			this.lbLocacaoEspecial = new System.Windows.Forms.ListBox();
			this.tbPeriodo = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbLocacaoPeriodo = new System.Windows.Forms.ComboBox();
			this.cbPermiteLocacao = new System.Windows.Forms.CheckBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.pnAdicional = new System.Windows.Forms.Panel();
			this.btAdicionalExcluir = new System.Windows.Forms.Button();
			this.dgAdicionais = new System.Windows.Forms.DataGridView();
			this.label8 = new System.Windows.Forms.Label();
			this.btAdicionalConfirmar = new System.Windows.Forms.Button();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tbAdicionalValor = new System.Windows.Forms.TextBox();
			this.tbAdicionalDescricao = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgProdutosTipos)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.pnAdicional.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAdicionais)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(597, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
			this.toolStripMenuItem1.Text = "&Novo";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dgProdutosTipos
			// 
			this.dgProdutosTipos.AllowUserToAddRows = false;
			this.dgProdutosTipos.AllowUserToDeleteRows = false;
			this.dgProdutosTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgProdutosTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgProdutosTipos.Location = new System.Drawing.Point(12, 287);
			this.dgProdutosTipos.Name = "dgProdutosTipos";
			this.dgProdutosTipos.ReadOnly = true;
			this.dgProdutosTipos.RowHeadersWidth = 18;
			this.dgProdutosTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgProdutosTipos.Size = new System.Drawing.Size(573, 170);
			this.dgProdutosTipos.TabIndex = 1;
			this.dgProdutosTipos.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// cbFracionado
			// 
			this.cbFracionado.AutoSize = true;
			this.cbFracionado.Location = new System.Drawing.Point(433, 65);
			this.cbFracionado.Name = "cbFracionado";
			this.cbFracionado.Size = new System.Drawing.Size(114, 17);
			this.cbFracionado.TabIndex = 26;
			this.cbFracionado.Text = "Permite fracionado";
			this.cbFracionado.UseVisualStyleBackColor = true;
			// 
			// cbMeioAMeio
			// 
			this.cbMeioAMeio.AutoSize = true;
			this.cbMeioAMeio.Location = new System.Drawing.Point(433, 42);
			this.cbMeioAMeio.Name = "cbMeioAMeio";
			this.cbMeioAMeio.Size = new System.Drawing.Size(120, 17);
			this.cbMeioAMeio.TabIndex = 25;
			this.cbMeioAMeio.Text = "Permite meio à meio";
			this.cbMeioAMeio.UseVisualStyleBackColor = true;
			// 
			// cbAdicionais
			// 
			this.cbAdicionais.AutoSize = true;
			this.cbAdicionais.Location = new System.Drawing.Point(433, 19);
			this.cbAdicionais.Name = "cbAdicionais";
			this.cbAdicionais.Size = new System.Drawing.Size(131, 17);
			this.cbAdicionais.TabIndex = 24;
			this.cbAdicionais.Text = "Aceita itens adicionais";
			this.cbAdicionais.UseVisualStyleBackColor = true;
			// 
			// cbImpressora
			// 
			this.cbImpressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbImpressora.FormattingEnabled = true;
			this.cbImpressora.Items.AddRange(new object[] {
            "",
            "Impressora Externa 1",
            "Impressora Externa 2"});
			this.cbImpressora.Location = new System.Drawing.Point(315, 137);
			this.cbImpressora.Name = "cbImpressora";
			this.cbImpressora.Size = new System.Drawing.Size(146, 21);
			this.cbImpressora.TabIndex = 23;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(312, 121);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(58, 13);
			this.label15.TabIndex = 22;
			this.label15.Text = "Impressora";
			// 
			// cbSoma
			// 
			this.cbSoma.AutoSize = true;
			this.cbSoma.Location = new System.Drawing.Point(315, 65);
			this.cbSoma.Name = "cbSoma";
			this.cbSoma.Size = new System.Drawing.Size(112, 17);
			this.cbSoma.TabIndex = 8;
			this.cbSoma.Text = "Soma fechamento";
			this.cbSoma.UseVisualStyleBackColor = true;
			this.cbSoma.Enter += new System.EventHandler(this.cbSoma_Enter);
			this.cbSoma.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSoma_KeyPress);
			this.cbSoma.Leave += new System.EventHandler(this.cbSoma_Leave);
			// 
			// cbEstoque
			// 
			this.cbEstoque.AutoSize = true;
			this.cbEstoque.Location = new System.Drawing.Point(315, 42);
			this.cbEstoque.Name = "cbEstoque";
			this.cbEstoque.Size = new System.Drawing.Size(65, 17);
			this.cbEstoque.TabIndex = 7;
			this.cbEstoque.Text = "Estoque";
			this.cbEstoque.UseVisualStyleBackColor = true;
			this.cbEstoque.Enter += new System.EventHandler(this.checkBox2_Enter);
			this.cbEstoque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkBox2_KeyPress);
			this.cbEstoque.Leave += new System.EventHandler(this.checkBox2_Leave);
			// 
			// cbProducao
			// 
			this.cbProducao.AutoSize = true;
			this.cbProducao.Location = new System.Drawing.Point(315, 19);
			this.cbProducao.Name = "cbProducao";
			this.cbProducao.Size = new System.Drawing.Size(72, 17);
			this.cbProducao.TabIndex = 6;
			this.cbProducao.Text = "Produção";
			this.cbProducao.UseVisualStyleBackColor = true;
			this.cbProducao.Enter += new System.EventHandler(this.checkBox1_Enter);
			this.cbProducao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkBox1_KeyPress);
			this.cbProducao.Leave += new System.EventHandler(this.checkBox1_Leave);
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(3, 58);
			this.tbDescricao.Multiline = true;
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.Size = new System.Drawing.Size(306, 47);
			this.tbDescricao.TabIndex = 5;
			this.tbDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Descrição";
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(109, 19);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(200, 20);
			this.tbNome.TabIndex = 3;
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(109, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nome";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(3, 19);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código";
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(12, 258);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "&Novo - F2";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.AutoSize = true;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(93, 258);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(82, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "&Limpar Dados";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.AutoSize = true;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button3.Location = new System.Drawing.Point(181, 258);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 5;
			this.button3.Text = "&Sair - F10";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(573, 225);
			this.tabControl1.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cbImprimeTotal);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.tbCodigo);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.tbNome);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.tbDescricao);
			this.tabPage1.Controls.Add(this.cbProducao);
			this.tabPage1.Controls.Add(this.cbEstoque);
			this.tabPage1.Controls.Add(this.cbSoma);
			this.tabPage1.Controls.Add(this.label15);
			this.tabPage1.Controls.Add(this.cbImpressora);
			this.tabPage1.Controls.Add(this.cbFracionado);
			this.tabPage1.Controls.Add(this.cbAdicionais);
			this.tabPage1.Controls.Add(this.cbMeioAMeio);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(565, 199);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Geral";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cbImprimeTotal
			// 
			this.cbImprimeTotal.AutoSize = true;
			this.cbImprimeTotal.Location = new System.Drawing.Point(315, 88);
			this.cbImprimeTotal.Name = "cbImprimeTotal";
			this.cbImprimeTotal.Size = new System.Drawing.Size(85, 17);
			this.cbImprimeTotal.TabIndex = 27;
			this.cbImprimeTotal.Text = "Imprime total";
			this.cbImprimeTotal.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.btAdicionar);
			this.tabPage2.Controls.Add(this.tbPeriodoEspecial);
			this.tabPage2.Controls.Add(this.tbLocacaoEspecial);
			this.tabPage2.Controls.Add(this.lbLocacaoEspecial);
			this.tabPage2.Controls.Add(this.tbPeriodo);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.cbLocacaoPeriodo);
			this.tabPage2.Controls.Add(this.cbPermiteLocacao);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(565, 199);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Locação";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 62);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(87, 13);
			this.label7.TabIndex = 48;
			this.label7.Text = "Período especial";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(102, 109);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(45, 13);
			this.label6.TabIndex = 47;
			this.label6.Text = "Período";
			// 
			// btAdicionar
			// 
			this.btAdicionar.Location = new System.Drawing.Point(214, 104);
			this.btAdicionar.Name = "btAdicionar";
			this.btAdicionar.Size = new System.Drawing.Size(34, 23);
			this.btAdicionar.TabIndex = 46;
			this.btAdicionar.Text = ">>";
			this.btAdicionar.UseVisualStyleBackColor = true;
			// 
			// tbPeriodoEspecial
			// 
			this.tbPeriodoEspecial.Location = new System.Drawing.Point(153, 106);
			this.tbPeriodoEspecial.Name = "tbPeriodoEspecial";
			this.tbPeriodoEspecial.Size = new System.Drawing.Size(55, 20);
			this.tbPeriodoEspecial.TabIndex = 45;
			// 
			// tbLocacaoEspecial
			// 
			this.tbLocacaoEspecial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbLocacaoEspecial.Location = new System.Drawing.Point(13, 78);
			this.tbLocacaoEspecial.Name = "tbLocacaoEspecial";
			this.tbLocacaoEspecial.Size = new System.Drawing.Size(235, 20);
			this.tbLocacaoEspecial.TabIndex = 44;
			// 
			// lbLocacaoEspecial
			// 
			this.lbLocacaoEspecial.FormattingEnabled = true;
			this.lbLocacaoEspecial.Location = new System.Drawing.Point(254, 60);
			this.lbLocacaoEspecial.Name = "lbLocacaoEspecial";
			this.lbLocacaoEspecial.Size = new System.Drawing.Size(305, 121);
			this.lbLocacaoEspecial.TabIndex = 43;
			// 
			// tbPeriodo
			// 
			this.tbPeriodo.Enabled = false;
			this.tbPeriodo.Location = new System.Drawing.Point(318, 25);
			this.tbPeriodo.Name = "tbPeriodo";
			this.tbPeriodo.Size = new System.Drawing.Size(55, 20);
			this.tbPeriodo.TabIndex = 42;
			this.tbPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(315, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 41;
			this.label5.Text = "Período";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(137, 25);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 40;
			this.label4.Text = "Intervalo";
			// 
			// cbLocacaoPeriodo
			// 
			this.cbLocacaoPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLocacaoPeriodo.Enabled = false;
			this.cbLocacaoPeriodo.FormattingEnabled = true;
			this.cbLocacaoPeriodo.Location = new System.Drawing.Point(191, 24);
			this.cbLocacaoPeriodo.Name = "cbLocacaoPeriodo";
			this.cbLocacaoPeriodo.Size = new System.Drawing.Size(121, 21);
			this.cbLocacaoPeriodo.TabIndex = 39;
			// 
			// cbPermiteLocacao
			// 
			this.cbPermiteLocacao.AutoSize = true;
			this.cbPermiteLocacao.Location = new System.Drawing.Point(6, 24);
			this.cbPermiteLocacao.Name = "cbPermiteLocacao";
			this.cbPermiteLocacao.Size = new System.Drawing.Size(106, 17);
			this.cbPermiteLocacao.TabIndex = 38;
			this.cbPermiteLocacao.Text = "Permite Locação";
			this.cbPermiteLocacao.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.pnAdicional);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(565, 199);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Itens adicionais";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// pnAdicional
			// 
			this.pnAdicional.Controls.Add(this.btAdicionalExcluir);
			this.pnAdicional.Controls.Add(this.dgAdicionais);
			this.pnAdicional.Controls.Add(this.label8);
			this.pnAdicional.Controls.Add(this.btAdicionalConfirmar);
			this.pnAdicional.Controls.Add(this.label16);
			this.pnAdicional.Controls.Add(this.label17);
			this.pnAdicional.Controls.Add(this.tbAdicionalValor);
			this.pnAdicional.Controls.Add(this.tbAdicionalDescricao);
			this.pnAdicional.Location = new System.Drawing.Point(3, 5);
			this.pnAdicional.Name = "pnAdicional";
			this.pnAdicional.Size = new System.Drawing.Size(317, 194);
			this.pnAdicional.TabIndex = 1;
			// 
			// btAdicionalExcluir
			// 
			this.btAdicionalExcluir.Location = new System.Drawing.Point(100, 42);
			this.btAdicionalExcluir.Name = "btAdicionalExcluir";
			this.btAdicionalExcluir.Size = new System.Drawing.Size(88, 23);
			this.btAdicionalExcluir.TabIndex = 18;
			this.btAdicionalExcluir.Text = "&Excluir";
			this.btAdicionalExcluir.UseVisualStyleBackColor = true;
			this.btAdicionalExcluir.Click += new System.EventHandler(this.btAdicionalExcluir_Click);
			// 
			// dgAdicionais
			// 
			this.dgAdicionais.AllowUserToAddRows = false;
			this.dgAdicionais.AllowUserToDeleteRows = false;
			this.dgAdicionais.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgAdicionais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgAdicionais.Location = new System.Drawing.Point(6, 84);
			this.dgAdicionais.MultiSelect = false;
			this.dgAdicionais.Name = "dgAdicionais";
			this.dgAdicionais.ReadOnly = true;
			this.dgAdicionais.RowHeadersWidth = 18;
			this.dgAdicionais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgAdicionais.Size = new System.Drawing.Size(308, 107);
			this.dgAdicionais.TabIndex = 17;
			this.dgAdicionais.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAdicionais_CellDoubleClick);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(185, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "R$";
			// 
			// btAdicionalConfirmar
			// 
			this.btAdicionalConfirmar.Location = new System.Drawing.Point(6, 42);
			this.btAdicionalConfirmar.Name = "btAdicionalConfirmar";
			this.btAdicionalConfirmar.Size = new System.Drawing.Size(88, 23);
			this.btAdicionalConfirmar.TabIndex = 14;
			this.btAdicionalConfirmar.Text = "&Confirmar";
			this.btAdicionalConfirmar.UseVisualStyleBackColor = true;
			this.btAdicionalConfirmar.Click += new System.EventHandler(this.btAdicionalConfirmar_Click);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(209, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(76, 13);
			this.label16.TabIndex = 13;
			this.label16.Text = "Valor adicional";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(3, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(55, 13);
			this.label17.TabIndex = 12;
			this.label17.Text = "Descrição";
			// 
			// tbAdicionalValor
			// 
			this.tbAdicionalValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbAdicionalValor.Location = new System.Drawing.Point(212, 16);
			this.tbAdicionalValor.Name = "tbAdicionalValor";
			this.tbAdicionalValor.Size = new System.Drawing.Size(100, 20);
			this.tbAdicionalValor.TabIndex = 11;
			this.tbAdicionalValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbAdicionalDescricao
			// 
			this.tbAdicionalDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbAdicionalDescricao.Location = new System.Drawing.Point(6, 16);
			this.tbAdicionalDescricao.Name = "tbAdicionalDescricao";
			this.tbAdicionalDescricao.Size = new System.Drawing.Size(170, 20);
			this.tbAdicionalDescricao.TabIndex = 10;
			// 
			// frmCadProdutosTipos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(597, 469);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dgProdutosTipos);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(610, 370);
			this.Name = "frmCadProdutosTipos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Tipos de Produtos";
			this.Load += new System.EventHandler(this.frmCadTiposProdutos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgProdutosTipos)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.pnAdicional.ResumeLayout(false);
			this.pnAdicional.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgAdicionais)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dgProdutosTipos;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.CheckBox cbEstoque;
		private System.Windows.Forms.CheckBox cbProducao;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbSoma;
		private System.Windows.Forms.ComboBox cbImpressora;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox cbAdicionais;
		private System.Windows.Forms.CheckBox cbFracionado;
		private System.Windows.Forms.CheckBox cbMeioAMeio;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.CheckBox cbImprimeTotal;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btAdicionar;
		private System.Windows.Forms.TextBox tbPeriodoEspecial;
		private System.Windows.Forms.TextBox tbLocacaoEspecial;
		private System.Windows.Forms.ListBox lbLocacaoEspecial;
		private System.Windows.Forms.TextBox tbPeriodo;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbLocacaoPeriodo;
		private System.Windows.Forms.CheckBox cbPermiteLocacao;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Panel pnAdicional;
		private System.Windows.Forms.Button btAdicionalExcluir;
		private System.Windows.Forms.DataGridView dgAdicionais;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btAdicionalConfirmar;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbAdicionalValor;
		private System.Windows.Forms.TextBox tbAdicionalDescricao;
	}
}