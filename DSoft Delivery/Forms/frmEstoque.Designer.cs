namespace DSoft_Delivery
{
	partial class frmEstoque
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoque));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.estoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btPesquisar = new System.Windows.Forms.Button();
			this.cbFornecedor = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.btMover = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.udQuantidade = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbMaximo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cbPara = new System.Windows.Forms.ComboBox();
			this.cbDe = new System.Windows.Forms.ComboBox();
			this.tbMinimo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button16 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbFiltro = new System.Windows.Forms.TextBox();
			this.tbPesquisa = new System.Windows.Forms.TextBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.udQuantidade)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estoqueToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(792, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// estoqueToolStripMenuItem
			// 
			this.estoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.estoqueToolStripMenuItem.Name = "estoqueToolStripMenuItem";
			this.estoqueToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.estoqueToolStripMenuItem.Text = "&Estoque";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(173, 22);
			this.toolStripMenuItem2.Text = "Cadastro de &Locais";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(170, 6);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
			this.toolStripMenuItem4.Text = "&Exportar";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "&Relatórios";
			// 
			// listaToolStripMenuItem
			// 
			this.listaToolStripMenuItem.Name = "listaToolStripMenuItem";
			this.listaToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.listaToolStripMenuItem.Text = "&Listar estoque";
			this.listaToolStripMenuItem.Click += new System.EventHandler(this.listaToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 27);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(417, 534);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			this.dataGridView1.Enter += new System.EventHandler(this.dataGridView1_Enter);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btPesquisar);
			this.groupBox1.Controls.Add(this.cbFornecedor);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.dataGridView2);
			this.groupBox1.Controls.Add(this.btMover);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbQuantidade);
			this.groupBox1.Controls.Add(this.udQuantidade);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbMaximo);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cbPara);
			this.groupBox1.Controls.Add(this.cbDe);
			this.groupBox1.Controls.Add(this.tbMinimo);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbNome);
			this.groupBox1.Controls.Add(this.tbCodigo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(435, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(345, 344);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados do Produto";
			// 
			// btPesquisar
			// 
			this.btPesquisar.Location = new System.Drawing.Point(218, 69);
			this.btPesquisar.Name = "btPesquisar";
			this.btPesquisar.Size = new System.Drawing.Size(121, 23);
			this.btPesquisar.TabIndex = 24;
			this.btPesquisar.Text = "&Pesquisar";
			this.btPesquisar.UseVisualStyleBackColor = true;
			this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
			// 
			// cbFornecedor
			// 
			this.cbFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFornecedor.FormattingEnabled = true;
			this.cbFornecedor.Location = new System.Drawing.Point(6, 71);
			this.cbFornecedor.Name = "cbFornecedor";
			this.cbFornecedor.Size = new System.Drawing.Size(206, 21);
			this.cbFornecedor.TabIndex = 23;
			this.cbFornecedor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFornecedor_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(6, 55);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(61, 13);
			this.label9.TabIndex = 22;
			this.label9.Text = "Fornecedor";
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(6, 215);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.RowHeadersWidth = 18;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(333, 123);
			this.dataGridView2.TabIndex = 15;
			// 
			// btMover
			// 
			this.btMover.Location = new System.Drawing.Point(264, 186);
			this.btMover.Name = "btMover";
			this.btMover.Size = new System.Drawing.Size(75, 23);
			this.btMover.TabIndex = 19;
			this.btMover.Text = "&Mover";
			this.btMover.UseVisualStyleBackColor = true;
			this.btMover.Click += new System.EventHandler(this.btMover_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 143);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Quantidade";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(213, 143);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 21;
			this.label8.Text = "Destino";
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.BackColor = System.Drawing.Color.White;
			this.tbQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbQuantidade.Location = new System.Drawing.Point(239, 120);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(100, 20);
			this.tbQuantidade.TabIndex = 9;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbQuantidade.DoubleClick += new System.EventHandler(this.tbQuantidade_DoubleClick);
			this.tbQuantidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQuantidade_KeyDown);
			// 
			// udQuantidade
			// 
			this.udQuantidade.Location = new System.Drawing.Point(6, 160);
			this.udQuantidade.Name = "udQuantidade";
			this.udQuantidade.Size = new System.Drawing.Size(79, 20);
			this.udQuantidade.TabIndex = 16;
			this.udQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(88, 143);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 20;
			this.label7.Text = "Origem";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(239, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Quantidade Atual";
			// 
			// tbMaximo
			// 
			this.tbMaximo.BackColor = System.Drawing.Color.White;
			this.tbMaximo.Location = new System.Drawing.Point(112, 120);
			this.tbMaximo.Name = "tbMaximo";
			this.tbMaximo.Size = new System.Drawing.Size(100, 20);
			this.tbMaximo.TabIndex = 7;
			this.tbMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbMaximo.Enter += new System.EventHandler(this.textBox4_Enter);
			this.tbMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
			this.tbMaximo.Leave += new System.EventHandler(this.textBox4_Leave);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(112, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Máximo";
			// 
			// cbPara
			// 
			this.cbPara.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbPara.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbPara.FormattingEnabled = true;
			this.cbPara.Location = new System.Drawing.Point(218, 159);
			this.cbPara.Name = "cbPara";
			this.cbPara.Size = new System.Drawing.Size(121, 21);
			this.cbPara.TabIndex = 18;
			// 
			// cbDe
			// 
			this.cbDe.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDe.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDe.FormattingEnabled = true;
			this.cbDe.Location = new System.Drawing.Point(91, 159);
			this.cbDe.Name = "cbDe";
			this.cbDe.Size = new System.Drawing.Size(121, 21);
			this.cbDe.TabIndex = 17;
			// 
			// tbMinimo
			// 
			this.tbMinimo.BackColor = System.Drawing.Color.White;
			this.tbMinimo.Location = new System.Drawing.Point(6, 120);
			this.tbMinimo.Name = "tbMinimo";
			this.tbMinimo.Size = new System.Drawing.Size(100, 20);
			this.tbMinimo.TabIndex = 5;
			this.tbMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbMinimo.Enter += new System.EventHandler(this.textBox3_Enter);
			this.tbMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			this.tbMinimo.Leave += new System.EventHandler(this.textBox3_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Mínimo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Nome";
			// 
			// tbNome
			// 
			this.tbNome.BackColor = System.Drawing.Color.White;
			this.tbNome.Location = new System.Drawing.Point(112, 32);
			this.tbNome.Name = "tbNome";
			this.tbNome.ReadOnly = true;
			this.tbNome.Size = new System.Drawing.Size(226, 20);
			this.tbNome.TabIndex = 2;
			// 
			// tbCodigo
			// 
			this.tbCodigo.BackColor = System.Drawing.Color.White;
			this.tbCodigo.Location = new System.Drawing.Point(6, 32);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Código";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(528, 377);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 3;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(657, 377);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.button16);
			this.groupBox3.Controls.Add(this.button15);
			this.groupBox3.Controls.Add(this.button14);
			this.groupBox3.Controls.Add(this.button13);
			this.groupBox3.Location = new System.Drawing.Point(633, 428);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(147, 124);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Legenda";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(32, 101);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(92, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "Estoque completo";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(32, 23);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(90, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Dentro dos limites";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(91, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Abaixo do mínimo";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(32, 75);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(74, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Estoque vazio";
			// 
			// button16
			// 
			this.button16.BackColor = System.Drawing.Color.Green;
			this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button16.Location = new System.Drawing.Point(6, 97);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(20, 20);
			this.button16.TabIndex = 3;
			this.button16.UseVisualStyleBackColor = false;
			// 
			// button15
			// 
			this.button15.BackColor = System.Drawing.Color.White;
			this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button15.Location = new System.Drawing.Point(6, 19);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(20, 20);
			this.button15.TabIndex = 2;
			this.button15.UseVisualStyleBackColor = false;
			// 
			// button14
			// 
			this.button14.BackColor = System.Drawing.Color.Yellow;
			this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button14.Location = new System.Drawing.Point(6, 45);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(20, 20);
			this.button14.TabIndex = 1;
			this.button14.UseVisualStyleBackColor = false;
			// 
			// button13
			// 
			this.button13.BackColor = System.Drawing.Color.Red;
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button13.Location = new System.Drawing.Point(6, 71);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(20, 20);
			this.button13.TabIndex = 0;
			this.button13.UseVisualStyleBackColor = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbFiltro);
			this.groupBox2.Controls.Add(this.tbPesquisa);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(435, 428);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(192, 133);
			this.groupBox2.TabIndex = 15;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Pesquisa";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(3, 91);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(29, 13);
			this.label10.TabIndex = 12;
			this.label10.Text = "Filtro";
			// 
			// tbFiltro
			// 
			this.tbFiltro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbFiltro.Location = new System.Drawing.Point(6, 107);
			this.tbFiltro.Name = "tbFiltro";
			this.tbFiltro.Size = new System.Drawing.Size(180, 20);
			this.tbFiltro.TabIndex = 3;
			this.tbFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFiltro_KeyPress);
			// 
			// tbPesquisa
			// 
			this.tbPesquisa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPesquisa.Location = new System.Drawing.Point(6, 65);
			this.tbPesquisa.Name = "tbPesquisa";
			this.tbPesquisa.Size = new System.Drawing.Size(180, 20);
			this.tbPesquisa.TabIndex = 2;
			this.tbPesquisa.TextChanged += new System.EventHandler(this.tbPesquisa_TextChanged);
			this.tbPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPesquisa_KeyDown);
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 42);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(53, 17);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.Text = "Nome";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(58, 17);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Código";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// frmEstoque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmEstoque";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Controle de Estoque";
			this.Load += new System.EventHandler(this.frmEstoque_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.udQuantidade)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem estoqueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbMaximo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbMinimo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.NumericUpDown udQuantidade;
		private System.Windows.Forms.ComboBox cbDe;
		private System.Windows.Forms.ComboBox cbPara;
		private System.Windows.Forms.Button btMover;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbFornecedor;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btPesquisar;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox tbPesquisa;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbFiltro;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listaToolStripMenuItem;
	}
}