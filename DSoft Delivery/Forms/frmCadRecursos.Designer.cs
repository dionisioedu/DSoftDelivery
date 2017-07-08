namespace DSoft_Delivery
{
	partial class frmCadRecursos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadRecursos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.alterarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listagemDeRecursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbCategoria = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.cbEstado = new System.Windows.Forms.ComboBox();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbHabilitacao = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbCPF = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbRG = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.tbCelular = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTelefone2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTelefone1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.dtNascimento = new System.Windows.Forms.DateTimePicker();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btIncluir = new System.Windows.Forms.Button();
			this.btAlterar = new System.Windows.Forms.Button();
			this.btBloquear = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
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
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// incluirToolStripMenuItem
			// 
			this.incluirToolStripMenuItem.Name = "incluirToolStripMenuItem";
			this.incluirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.incluirToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.incluirToolStripMenuItem.Text = "&Incluir";
			this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
			// 
			// alterarToolStripMenuItem
			// 
			this.alterarToolStripMenuItem.Name = "alterarToolStripMenuItem";
			this.alterarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.alterarToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.alterarToolStripMenuItem.Text = "&Alterar";
			this.alterarToolStripMenuItem.Click += new System.EventHandler(this.alterarToolStripMenuItem_Click);
			// 
			// bloquearToolStripMenuItem
			// 
			this.bloquearToolStripMenuItem.Name = "bloquearToolStripMenuItem";
			this.bloquearToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.bloquearToolStripMenuItem.Text = "&Bloquear";
			this.bloquearToolStripMenuItem.Click += new System.EventHandler(this.bloquearToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.cancelarToolStripMenuItem.Text = "&Cancelar";
			this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(196, 6);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 22);
			this.toolStripMenuItem2.Text = "&Tipos de Funcionários";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Enabled = false;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(199, 22);
			this.toolStripMenuItem4.Text = "&Grupos de Funcionários";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listagemDeRecursosToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// listagemDeRecursosToolStripMenuItem
			// 
			this.listagemDeRecursosToolStripMenuItem.Name = "listagemDeRecursosToolStripMenuItem";
			this.listagemDeRecursosToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.listagemDeRecursosToolStripMenuItem.Text = "Listar recursos";
			this.listagemDeRecursosToolStripMenuItem.Click += new System.EventHandler(this.listagemDeRecursosToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 232);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(770, 280);
			this.dataGridView1.TabIndex = 21;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbEmail);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.tbCategoria);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.cbEstado);
			this.groupBox1.Controls.Add(this.tbCidade);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.tbEndereco);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.tbHabilitacao);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbCPF);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tbRG);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.cbTipo);
			this.groupBox1.Controls.Add(this.tbCelular);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbTelefone2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbTelefone1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.dtNascimento);
			this.groupBox1.Controls.Add(this.tbNome);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbCodigo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(770, 148);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados Cadastrais";
			// 
			// tbEmail
			// 
			this.tbEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.tbEmail.Location = new System.Drawing.Point(516, 110);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(248, 20);
			this.tbEmail.TabIndex = 14;
			this.tbEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmail_KeyDown);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(513, 94);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(34, 13);
			this.label15.TabIndex = 31;
			this.label15.Text = "e-mail";
			// 
			// tbCategoria
			// 
			this.tbCategoria.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCategoria.Location = new System.Drawing.Point(324, 110);
			this.tbCategoria.Name = "tbCategoria";
			this.tbCategoria.Size = new System.Drawing.Size(52, 20);
			this.tbCategoria.TabIndex = 13;
			this.tbCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCategoria_KeyDown);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(324, 94);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(52, 13);
			this.label14.TabIndex = 29;
			this.label14.Text = "Categoria";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(661, 55);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 13);
			this.label13.TabIndex = 27;
			this.label13.Text = "Estado";
			// 
			// cbEstado
			// 
			this.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbEstado.FormattingEnabled = true;
			this.cbEstado.Items.AddRange(new object[] {
            "AC - ACRE",
            "AL - ALAGOAS",
            "AM - AMAZONAS",
            "AP - AMAPA",
            "BA - BAHIA",
            "CE - CEARA",
            "DF - DISTRITO FEDERAL",
            "ES - ESPIRITO SANTO",
            "GO - GOIAS",
            "MA - MARANHAO",
            "MG - MINAS GERAIS",
            "MS - MATO GROSSO DO SUL",
            "MT - MATO GROSSO",
            "PA - PARA",
            "PB - PARAIBA",
            "PE - PERNAMBUCO",
            "PI - PIAUI",
            "PR - PARANA",
            "RJ - RIO DE JANEIRO",
            "RN - RIO GRANDE DO NORTE",
            "RO - RONDONIA",
            "RR - RORAIMA",
            "RS - RIO GRANDE DO SUL",
            "SC - SANTA CATARINA",
            "SE - SERGIPE",
            "SP - SAO PAULO",
            "TO - TOCANTINS"});
			this.cbEstado.Location = new System.Drawing.Point(664, 71);
			this.cbEstado.Name = "cbEstado";
			this.cbEstado.Size = new System.Drawing.Size(100, 21);
			this.cbEstado.TabIndex = 9;
			this.cbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEstado_KeyDown);
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(558, 71);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(100, 20);
			this.tbCidade.TabIndex = 8;
			this.tbCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCidade_KeyDown);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(555, 55);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(40, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Cidade";
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(324, 71);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.Size = new System.Drawing.Size(228, 20);
			this.tbEndereco.TabIndex = 7;
			this.tbEndereco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEndereco_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(321, 55);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 13);
			this.label11.TabIndex = 19;
			this.label11.Text = "Endereço";
			// 
			// tbHabilitacao
			// 
			this.tbHabilitacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbHabilitacao.Location = new System.Drawing.Point(218, 110);
			this.tbHabilitacao.Name = "tbHabilitacao";
			this.tbHabilitacao.Size = new System.Drawing.Size(100, 20);
			this.tbHabilitacao.TabIndex = 12;
			this.tbHabilitacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbHabilitacao_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(218, 94);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 13);
			this.label8.TabIndex = 18;
			this.label8.Text = "Habilitação";
			// 
			// tbCPF
			// 
			this.tbCPF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCPF.Location = new System.Drawing.Point(112, 110);
			this.tbCPF.Name = "tbCPF";
			this.tbCPF.Size = new System.Drawing.Size(100, 20);
			this.tbCPF.TabIndex = 11;
			this.tbCPF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCPF_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(109, 94);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(27, 13);
			this.label9.TabIndex = 16;
			this.label9.Text = "CPF";
			// 
			// tbRG
			// 
			this.tbRG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbRG.Location = new System.Drawing.Point(6, 110);
			this.tbRG.Name = "tbRG";
			this.tbRG.Size = new System.Drawing.Size(100, 20);
			this.tbRG.TabIndex = 10;
			this.tbRG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbRG_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 94);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(23, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "RG";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(555, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(28, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Tipo";
			// 
			// cbTipo
			// 
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(558, 30);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(100, 21);
			this.cbTipo.TabIndex = 2;
			this.cbTipo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTipo_KeyDown);
			// 
			// tbCelular
			// 
			this.tbCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCelular.Location = new System.Drawing.Point(218, 71);
			this.tbCelular.Name = "tbCelular";
			this.tbCelular.Size = new System.Drawing.Size(100, 20);
			this.tbCelular.TabIndex = 6;
			this.tbCelular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCelular_KeyDown);
			this.tbCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCelular_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(215, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Celular";
			// 
			// tbTelefone2
			// 
			this.tbTelefone2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTelefone2.Location = new System.Drawing.Point(112, 71);
			this.tbTelefone2.Name = "tbTelefone2";
			this.tbTelefone2.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone2.TabIndex = 5;
			this.tbTelefone2.TextChanged += new System.EventHandler(this.tbTelefone2_TextChanged);
			this.tbTelefone2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTelefone2_KeyDown);
			this.tbTelefone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTelefone2_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(109, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Telefone 2";
			// 
			// tbTelefone1
			// 
			this.tbTelefone1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTelefone1.Location = new System.Drawing.Point(6, 71);
			this.tbTelefone1.Name = "tbTelefone1";
			this.tbTelefone1.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone1.TabIndex = 4;
			this.tbTelefone1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTelefone1_KeyDown);
			this.tbTelefone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTelefone1_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Telefone 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(661, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Nascimento";
			// 
			// dtNascimento
			// 
			this.dtNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtNascimento.Location = new System.Drawing.Point(664, 31);
			this.dtNascimento.Name = "dtNascimento";
			this.dtNascimento.Size = new System.Drawing.Size(100, 20);
			this.dtNascimento.TabIndex = 3;
			this.dtNascimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtNascimento_KeyDown);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(112, 32);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(210, 20);
			this.tbNome.TabIndex = 1;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(109, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nome";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(6, 32);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código";
			// 
			// btIncluir
			// 
			this.btIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btIncluir.Location = new System.Drawing.Point(12, 181);
			this.btIncluir.Name = "btIncluir";
			this.btIncluir.Size = new System.Drawing.Size(123, 45);
			this.btIncluir.TabIndex = 15;
			this.btIncluir.Text = "&Incluir - F2";
			this.btIncluir.UseVisualStyleBackColor = true;
			this.btIncluir.Click += new System.EventHandler(this.button1_Click);
			// 
			// btAlterar
			// 
			this.btAlterar.Enabled = false;
			this.btAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btAlterar.Location = new System.Drawing.Point(141, 181);
			this.btAlterar.Name = "btAlterar";
			this.btAlterar.Size = new System.Drawing.Size(123, 45);
			this.btAlterar.TabIndex = 16;
			this.btAlterar.Text = "&Alterar - F3";
			this.btAlterar.UseVisualStyleBackColor = true;
			this.btAlterar.Click += new System.EventHandler(this.button2_Click);
			// 
			// btBloquear
			// 
			this.btBloquear.Enabled = false;
			this.btBloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBloquear.Location = new System.Drawing.Point(270, 181);
			this.btBloquear.Name = "btBloquear";
			this.btBloquear.Size = new System.Drawing.Size(123, 45);
			this.btBloquear.TabIndex = 17;
			this.btBloquear.Text = "&Bloquear";
			this.btBloquear.UseVisualStyleBackColor = true;
			this.btBloquear.Click += new System.EventHandler(this.button3_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(399, 181);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 18;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.button4_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Enabled = false;
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(528, 181);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(123, 45);
			this.btLimpar.TabIndex = 19;
			this.btLimpar.Text = "Limpar Dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.button5_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 181);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 20;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button6_Click);
			// 
			// frmCadRecursos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 524);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btBloquear);
			this.Controls.Add(this.btAlterar);
			this.Controls.Add(this.btIncluir);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCadRecursos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Funcionários";
			this.Load += new System.EventHandler(this.frmCadRecursos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btIncluir;
		private System.Windows.Forms.Button btAlterar;
		private System.Windows.Forms.Button btBloquear;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbTelefone2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTelefone1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtNascimento;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.TextBox tbCelular;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemDeRecursosToolStripMenuItem;
		private System.Windows.Forms.TextBox tbHabilitacao;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbCPF;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbRG;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.TextBox tbCategoria;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label15;
	}
}