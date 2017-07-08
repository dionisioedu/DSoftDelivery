namespace DSoft_Delivery.Forms
{
	partial class frmLancamentoOS
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLancamentoOS));
			this.tbNumero = new System.Windows.Forms.TextBox();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.cbStatus = new System.Windows.Forms.ComboBox();
			this.cbPeriodo = new System.Windows.Forms.ComboBox();
			this.cbServico = new System.Windows.Forms.ComboBox();
			this.btLancar = new System.Windows.Forms.Button();
			this.btBaixar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.lançamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serviçosExecutadosPorPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serviçosEmAbertoPorFuncionárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.serviçosReagendadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dtLancamento = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.btReagendar = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button19 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.cbFuncionario = new System.Windows.Forms.ComboBox();
			this.mbCep = new System.Windows.Forms.MaskedTextBox();
			this.tbTelefone = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.tbNumeroEnd = new System.Windows.Forms.TextBox();
			this.tbObservacoes = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbNome = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbNumero
			// 
			this.tbNumero.Location = new System.Drawing.Point(12, 62);
			this.tbNumero.Name = "tbNumero";
			this.tbNumero.Size = new System.Drawing.Size(100, 20);
			this.tbNumero.TabIndex = 0;
			this.tbNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumero_KeyDown);
			this.tbNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumero_KeyPress);
			// 
			// tbCliente
			// 
			this.tbCliente.Location = new System.Drawing.Point(12, 101);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.Size = new System.Drawing.Size(100, 20);
			this.tbCliente.TabIndex = 1;
			this.tbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCliente_KeyDown);
			this.tbCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCliente_KeyPress);
			this.tbCliente.Leave += new System.EventHandler(this.tbCliente_Leave);
			// 
			// cbStatus
			// 
			this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatus.FormattingEnabled = true;
			this.cbStatus.Items.AddRange(new object[] {
            "AGENDADO",
            "CANCELADO",
            "EXECUTADO",
            "REAGENDADO"});
			this.cbStatus.Location = new System.Drawing.Point(334, 62);
			this.cbStatus.Name = "cbStatus";
			this.cbStatus.Size = new System.Drawing.Size(121, 21);
			this.cbStatus.TabIndex = 3;
			this.cbStatus.Visible = false;
			this.cbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbStatus_KeyDown);
			// 
			// cbPeriodo
			// 
			this.cbPeriodo.FormattingEnabled = true;
			this.cbPeriodo.Location = new System.Drawing.Point(461, 62);
			this.cbPeriodo.Name = "cbPeriodo";
			this.cbPeriodo.Size = new System.Drawing.Size(121, 21);
			this.cbPeriodo.TabIndex = 4;
			this.cbPeriodo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPeriodo_KeyDown);
			// 
			// cbServico
			// 
			this.cbServico.FormattingEnabled = true;
			this.cbServico.Location = new System.Drawing.Point(588, 62);
			this.cbServico.Name = "cbServico";
			this.cbServico.Size = new System.Drawing.Size(121, 21);
			this.cbServico.TabIndex = 5;
			this.cbServico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbServico_KeyDown);
			// 
			// btLancar
			// 
			this.btLancar.Location = new System.Drawing.Point(12, 166);
			this.btLancar.Name = "btLancar";
			this.btLancar.Size = new System.Drawing.Size(75, 23);
			this.btLancar.TabIndex = 7;
			this.btLancar.Text = "&Lançar F2";
			this.btLancar.UseVisualStyleBackColor = true;
			this.btLancar.Click += new System.EventHandler(this.btLancar_Click);
			// 
			// btBaixar
			// 
			this.btBaixar.Location = new System.Drawing.Point(93, 166);
			this.btBaixar.Name = "btBaixar";
			this.btBaixar.Size = new System.Drawing.Size(75, 23);
			this.btBaixar.TabIndex = 8;
			this.btBaixar.Text = "&Baixar F3";
			this.btBaixar.UseVisualStyleBackColor = true;
			this.btBaixar.Click += new System.EventHandler(this.btBaixar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Location = new System.Drawing.Point(255, 166);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(75, 23);
			this.btCancelar.TabIndex = 9;
			this.btCancelar.Text = "&Cancelar F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Location = new System.Drawing.Point(336, 166);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(75, 23);
			this.btLimpar.TabIndex = 10;
			this.btLimpar.Text = "Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(417, 166);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 11;
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
			this.dataGridView1.Location = new System.Drawing.Point(12, 195);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(968, 179);
			this.dataGridView1.TabIndex = 12;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Número OS";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Cliente";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(115, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(62, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Funcionário";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(331, 46);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Status";
			this.label4.Visible = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(458, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Período";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(585, 46);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Serviço";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lançamentoToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(992, 24);
			this.menuStrip1.TabIndex = 18;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// lançamentoToolStripMenuItem
			// 
			this.lançamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.lançamentoToolStripMenuItem.Name = "lançamentoToolStripMenuItem";
			this.lançamentoToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
			this.lançamentoToolStripMenuItem.Text = "&Lançamento";
			// 
			// novoToolStripMenuItem
			// 
			this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
			this.novoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.novoToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.novoToolStripMenuItem.Text = "&Lancar";
			this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(139, 22);
			this.toolStripMenuItem2.Text = "&Baixar";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.toolStripMenuItem3.Size = new System.Drawing.Size(139, 22);
			this.toolStripMenuItem3.Text = "&Cancelar";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviçosExecutadosPorPeríodoToolStripMenuItem,
            this.serviçosEmAbertoPorFuncionárioToolStripMenuItem,
            this.serviçosReagendadosToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// serviçosExecutadosPorPeríodoToolStripMenuItem
			// 
			this.serviçosExecutadosPorPeríodoToolStripMenuItem.Name = "serviçosExecutadosPorPeríodoToolStripMenuItem";
			this.serviçosExecutadosPorPeríodoToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
			this.serviçosExecutadosPorPeríodoToolStripMenuItem.Text = "Serviços executados por período";
			// 
			// serviçosEmAbertoPorFuncionárioToolStripMenuItem
			// 
			this.serviçosEmAbertoPorFuncionárioToolStripMenuItem.Name = "serviçosEmAbertoPorFuncionárioToolStripMenuItem";
			this.serviçosEmAbertoPorFuncionárioToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
			this.serviçosEmAbertoPorFuncionárioToolStripMenuItem.Text = "Serviços em aberto por funcionário";
			// 
			// serviçosReagendadosToolStripMenuItem
			// 
			this.serviçosReagendadosToolStripMenuItem.Name = "serviçosReagendadosToolStripMenuItem";
			this.serviçosReagendadosToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
			this.serviçosReagendadosToolStripMenuItem.Text = "Serviços reagendados";
			// 
			// dtLancamento
			// 
			this.dtLancamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtLancamento.Location = new System.Drawing.Point(715, 63);
			this.dtLancamento.Name = "dtLancamento";
			this.dtLancamento.Size = new System.Drawing.Size(100, 20);
			this.dtLancamento.TabIndex = 6;
			this.dtLancamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtLancamento_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(712, 47);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(30, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Data";
			// 
			// btReagendar
			// 
			this.btReagendar.Location = new System.Drawing.Point(174, 166);
			this.btReagendar.Name = "btReagendar";
			this.btReagendar.Size = new System.Drawing.Size(75, 23);
			this.btReagendar.TabIndex = 21;
			this.btReagendar.Text = "&Reagendar";
			this.btReagendar.UseVisualStyleBackColor = true;
			this.btReagendar.Click += new System.EventHandler(this.btReagendar_Click);
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(317, 384);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(58, 13);
			this.label22.TabIndex = 14;
			this.label22.Text = "Executado";
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(227, 384);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(58, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Cancelado";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(126, 384);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(69, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Reagendado";
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(38, 384);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(56, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Agendado";
			// 
			// button19
			// 
			this.button19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button19.BackColor = System.Drawing.Color.Green;
			this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button19.Location = new System.Drawing.Point(291, 380);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(20, 20);
			this.button19.TabIndex = 96;
			this.button19.UseVisualStyleBackColor = false;
			// 
			// button15
			// 
			this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button15.BackColor = System.Drawing.Color.Red;
			this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button15.Location = new System.Drawing.Point(201, 380);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(20, 20);
			this.button15.TabIndex = 97;
			this.button15.UseVisualStyleBackColor = false;
			// 
			// button14
			// 
			this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button14.BackColor = System.Drawing.Color.Yellow;
			this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button14.Location = new System.Drawing.Point(100, 380);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(20, 20);
			this.button14.TabIndex = 98;
			this.button14.UseVisualStyleBackColor = false;
			// 
			// button13
			// 
			this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.button13.BackColor = System.Drawing.Color.White;
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button13.Location = new System.Drawing.Point(12, 380);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(20, 20);
			this.button13.TabIndex = 99;
			this.button13.UseVisualStyleBackColor = false;
			// 
			// cbFuncionario
			// 
			this.cbFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFuncionario.FormattingEnabled = true;
			this.cbFuncionario.Location = new System.Drawing.Point(118, 62);
			this.cbFuncionario.Name = "cbFuncionario";
			this.cbFuncionario.Size = new System.Drawing.Size(210, 21);
			this.cbFuncionario.TabIndex = 100;
			this.cbFuncionario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFuncionario_KeyDown);
			// 
			// mbCep
			// 
			this.mbCep.Location = new System.Drawing.Point(499, 101);
			this.mbCep.Mask = "99999-999";
			this.mbCep.Name = "mbCep";
			this.mbCep.Size = new System.Drawing.Size(80, 20);
			this.mbCep.TabIndex = 101;
			this.mbCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbCep_KeyDown);
			// 
			// tbTelefone
			// 
			this.tbTelefone.Location = new System.Drawing.Point(393, 101);
			this.tbTelefone.Name = "tbTelefone";
			this.tbTelefone.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone.TabIndex = 102;
			this.tbTelefone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTelefone_KeyDown);
			this.tbTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTelefone_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(496, 85);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(26, 13);
			this.label8.TabIndex = 103;
			this.label8.Text = "Cep";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(390, 85);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 13);
			this.label9.TabIndex = 104;
			this.label9.Text = "Telefone";
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(585, 101);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.ReadOnly = true;
			this.tbEndereco.Size = new System.Drawing.Size(180, 20);
			this.tbEndereco.TabIndex = 105;
			// 
			// tbNumeroEnd
			// 
			this.tbNumeroEnd.Location = new System.Drawing.Point(771, 101);
			this.tbNumeroEnd.Name = "tbNumeroEnd";
			this.tbNumeroEnd.Size = new System.Drawing.Size(44, 20);
			this.tbNumeroEnd.TabIndex = 106;
			this.tbNumeroEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
			this.tbNumeroEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			// 
			// tbObservacoes
			// 
			this.tbObservacoes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacoes.Location = new System.Drawing.Point(12, 140);
			this.tbObservacoes.Name = "tbObservacoes";
			this.tbObservacoes.Size = new System.Drawing.Size(803, 20);
			this.tbObservacoes.TabIndex = 107;
			this.tbObservacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbObservacoes_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(582, 85);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 13);
			this.label10.TabIndex = 108;
			this.label10.Text = "Endereço";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(768, 85);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 109;
			this.label11.Text = "Número";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(9, 124);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(70, 13);
			this.label12.TabIndex = 110;
			this.label12.Text = "Observações";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(115, 85);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(35, 13);
			this.label13.TabIndex = 112;
			this.label13.Text = "Nome";
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(118, 101);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(269, 20);
			this.tbNome.TabIndex = 111;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// frmLancamentoOS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(992, 412);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbObservacoes);
			this.Controls.Add(this.tbNumeroEnd);
			this.Controls.Add(this.tbEndereco);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbTelefone);
			this.Controls.Add(this.mbCep);
			this.Controls.Add(this.cbFuncionario);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.btReagendar);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtLancamento);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.button19);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button15);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.button14);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btBaixar);
			this.Controls.Add(this.button13);
			this.Controls.Add(this.btLancar);
			this.Controls.Add(this.cbServico);
			this.Controls.Add(this.cbPeriodo);
			this.Controls.Add(this.cbStatus);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.tbNumero);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(1008, 451);
			this.Name = "frmLancamentoOS";
			this.ShowInTaskbar = false;
			this.Text = "Lançamento de OS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmLancamentoOS_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbNumero;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.ComboBox cbStatus;
		private System.Windows.Forms.ComboBox cbPeriodo;
		private System.Windows.Forms.ComboBox cbServico;
		private System.Windows.Forms.Button btLancar;
		private System.Windows.Forms.Button btBaixar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem lançamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.DateTimePicker dtLancamento;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btReagendar;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serviçosExecutadosPorPeríodoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serviçosEmAbertoPorFuncionárioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem serviçosReagendadosToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbFuncionario;
		private System.Windows.Forms.MaskedTextBox mbCep;
		private System.Windows.Forms.TextBox tbTelefone;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.TextBox tbNumeroEnd;
		private System.Windows.Forms.TextBox tbObservacoes;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbNome;
	}
}