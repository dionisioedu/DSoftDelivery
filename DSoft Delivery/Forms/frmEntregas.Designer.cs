namespace DSoft_Delivery
{
	partial class frmEntregas
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregas));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.entregasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.entregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entregasPorPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.entregasPorClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dgEntregas = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbDetalhes = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbHoraEntrega = new System.Windows.Forms.TextBox();
			this.tbHoraSaida = new System.Windows.Forms.TextBox();
			this.tbHoraPedido = new System.Windows.Forms.TextBox();
			this.lbEndereco = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lbRecurso = new System.Windows.Forms.Label();
			this.tbEntregador = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lbCliente = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPedido = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btSaida = new System.Windows.Forms.Button();
			this.btEntrega = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button20 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.llAtualizar = new System.Windows.Forms.LinkLabel();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btPagar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.wbMap = new System.Windows.Forms.WebBrowser();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgEntregas)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entregasToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(959, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// entregasToolStripMenuItem
			// 
			this.entregasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.entregarToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.entregasToolStripMenuItem.Name = "entregasToolStripMenuItem";
			this.entregasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
			this.entregasToolStripMenuItem.Text = "&Entregas";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(190, 22);
			this.toolStripMenuItem2.Text = "Lançar Saída";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// entregarToolStripMenuItem
			// 
			this.entregarToolStripMenuItem.Name = "entregarToolStripMenuItem";
			this.entregarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.entregarToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.entregarToolStripMenuItem.Text = "Confirmar Entrega";
			this.entregarToolStripMenuItem.Click += new System.EventHandler(this.entregarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.toolStripMenuItem3.Size = new System.Drawing.Size(190, 22);
			this.toolStripMenuItem3.Text = "Cancelar";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.toolStripMenuItem4.Size = new System.Drawing.Size(190, 22);
			this.toolStripMenuItem4.Text = "Pagar";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entregasPorPeríodoToolStripMenuItem,
            this.entregasPorClienteToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// entregasPorPeríodoToolStripMenuItem
			// 
			this.entregasPorPeríodoToolStripMenuItem.Name = "entregasPorPeríodoToolStripMenuItem";
			this.entregasPorPeríodoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.entregasPorPeríodoToolStripMenuItem.Text = "Entregas por Período";
			this.entregasPorPeríodoToolStripMenuItem.Click += new System.EventHandler(this.entregasPorPeríodoToolStripMenuItem_Click);
			// 
			// entregasPorClienteToolStripMenuItem
			// 
			this.entregasPorClienteToolStripMenuItem.Name = "entregasPorClienteToolStripMenuItem";
			this.entregasPorClienteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.entregasPorClienteToolStripMenuItem.Text = "Entregas por Cliente";
			this.entregasPorClienteToolStripMenuItem.Click += new System.EventHandler(this.entregasPorClienteToolStripMenuItem_Click);
			// 
			// dgEntregas
			// 
			this.dgEntregas.AllowUserToAddRows = false;
			this.dgEntregas.AllowUserToDeleteRows = false;
			this.dgEntregas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgEntregas.Location = new System.Drawing.Point(12, 27);
			this.dgEntregas.Name = "dgEntregas";
			this.dgEntregas.ReadOnly = true;
			this.dgEntregas.RowHeadersWidth = 18;
			this.dgEntregas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgEntregas.Size = new System.Drawing.Size(522, 526);
			this.dgEntregas.TabIndex = 1;
			this.dgEntregas.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView1_Scroll);
			this.dgEntregas.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			this.dgEntregas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tbDetalhes);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.tbHoraEntrega);
			this.groupBox1.Controls.Add(this.tbHoraSaida);
			this.groupBox1.Controls.Add(this.tbHoraPedido);
			this.groupBox1.Controls.Add(this.lbEndereco);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.lbRecurso);
			this.groupBox1.Controls.Add(this.tbEntregador);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.textBox3);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.lbCliente);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbPedido);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(540, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(407, 375);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados do Pedido";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// tbDetalhes
			// 
			this.tbDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbDetalhes.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDetalhes.Location = new System.Drawing.Point(6, 226);
			this.tbDetalhes.Multiline = true;
			this.tbDetalhes.Name = "tbDetalhes";
			this.tbDetalhes.ReadOnly = true;
			this.tbDetalhes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDetalhes.Size = new System.Drawing.Size(398, 143);
			this.tbDetalhes.TabIndex = 31;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(274, 74);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(21, 13);
			this.label12.TabIndex = 30;
			this.label12.Text = "R$";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(301, 71);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(100, 20);
			this.textBox6.TabIndex = 29;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(301, 55);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(86, 13);
			this.label13.TabIndex = 28;
			this.label13.Text = "Taxa de Entrega";
			// 
			// tbHoraEntrega
			// 
			this.tbHoraEntrega.Location = new System.Drawing.Point(304, 177);
			this.tbHoraEntrega.Name = "tbHoraEntrega";
			this.tbHoraEntrega.ReadOnly = true;
			this.tbHoraEntrega.Size = new System.Drawing.Size(100, 20);
			this.tbHoraEntrega.TabIndex = 27;
			this.tbHoraEntrega.Visible = false;
			// 
			// tbHoraSaida
			// 
			this.tbHoraSaida.Location = new System.Drawing.Point(304, 151);
			this.tbHoraSaida.Name = "tbHoraSaida";
			this.tbHoraSaida.ReadOnly = true;
			this.tbHoraSaida.Size = new System.Drawing.Size(100, 20);
			this.tbHoraSaida.TabIndex = 26;
			this.tbHoraSaida.Visible = false;
			// 
			// tbHoraPedido
			// 
			this.tbHoraPedido.Location = new System.Drawing.Point(304, 125);
			this.tbHoraPedido.Name = "tbHoraPedido";
			this.tbHoraPedido.ReadOnly = true;
			this.tbHoraPedido.Size = new System.Drawing.Size(100, 20);
			this.tbHoraPedido.TabIndex = 25;
			this.tbHoraPedido.Visible = false;
			// 
			// lbEndereco
			// 
			this.lbEndereco.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbEndereco.Location = new System.Drawing.Point(6, 147);
			this.lbEndereco.Name = "lbEndereco";
			this.lbEndereco.Size = new System.Drawing.Size(243, 37);
			this.lbEndereco.TabIndex = 24;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(254, 180);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 23;
			this.label11.Text = "Entrega";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(262, 154);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(36, 13);
			this.label10.TabIndex = 22;
			this.label10.Text = "Saída";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(258, 128);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 21;
			this.label9.Text = "Pedido";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(301, 108);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(46, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Horários";
			// 
			// lbRecurso
			// 
			this.lbRecurso.AutoSize = true;
			this.lbRecurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbRecurso.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbRecurso.Location = new System.Drawing.Point(112, 203);
			this.lbRecurso.Name = "lbRecurso";
			this.lbRecurso.Size = new System.Drawing.Size(0, 13);
			this.lbRecurso.TabIndex = 16;
			// 
			// tbEntregador
			// 
			this.tbEntregador.Location = new System.Drawing.Point(6, 200);
			this.tbEntregador.Name = "tbEntregador";
			this.tbEntregador.ReadOnly = true;
			this.tbEntregador.Size = new System.Drawing.Size(100, 20);
			this.tbEntregador.TabIndex = 15;
			this.tbEntregador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 184);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Entregador";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(30, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Data";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Enabled = false;
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(6, 71);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(100, 20);
			this.dateTimePicker1.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(274, 35);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "R$";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(301, 32);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(301, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Valor";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(172, 32);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(50, 20);
			this.textBox3.TabIndex = 9;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(172, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Itens";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// lbCliente
			// 
			this.lbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCliente.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbCliente.Location = new System.Drawing.Point(6, 147);
			this.lbCliente.Name = "lbCliente";
			this.lbCliente.Size = new System.Drawing.Size(246, 13);
			this.lbCliente.TabIndex = 7;
			this.lbCliente.Click += new System.EventHandler(this.lbCliente_Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(6, 124);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 6;
			this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Cliente";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// tbPedido
			// 
			this.tbPedido.Location = new System.Drawing.Point(6, 32);
			this.tbPedido.Name = "tbPedido";
			this.tbPedido.Size = new System.Drawing.Size(100, 20);
			this.tbPedido.TabIndex = 4;
			this.tbPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Número";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// btSaida
			// 
			this.btSaida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSaida.Enabled = false;
			this.btSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSaida.Location = new System.Drawing.Point(540, 408);
			this.btSaida.Name = "btSaida";
			this.btSaida.Size = new System.Drawing.Size(106, 28);
			this.btSaida.TabIndex = 3;
			this.btSaida.Text = "&Saída - F2";
			this.btSaida.UseVisualStyleBackColor = true;
			this.btSaida.Click += new System.EventHandler(this.button1_Click);
			// 
			// btEntrega
			// 
			this.btEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btEntrega.Enabled = false;
			this.btEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btEntrega.Location = new System.Drawing.Point(652, 408);
			this.btEntrega.Name = "btEntrega";
			this.btEntrega.Size = new System.Drawing.Size(107, 28);
			this.btEntrega.TabIndex = 4;
			this.btEntrega.Text = "&Entregue - F3";
			this.btEntrega.UseVisualStyleBackColor = true;
			this.btEntrega.Click += new System.EventHandler(this.button2_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(765, 441);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(107, 28);
			this.btSair.TabIndex = 5;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.button20);
			this.groupBox3.Controls.Add(this.button19);
			this.groupBox3.Controls.Add(this.button18);
			this.groupBox3.Controls.Add(this.button17);
			this.groupBox3.Controls.Add(this.button16);
			this.groupBox3.Controls.Add(this.button15);
			this.groupBox3.Controls.Add(this.button14);
			this.groupBox3.Controls.Add(this.button13);
			this.groupBox3.Location = new System.Drawing.Point(540, 488);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(407, 75);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Legenda";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(325, 49);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(36, 13);
			this.label23.TabIndex = 15;
			this.label23.Text = "Saída";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(325, 23);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 13);
			this.label22.TabIndex = 14;
			this.label22.Text = "Pago/Entregue";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(129, 49);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(66, 13);
			this.label21.TabIndex = 13;
			this.label21.Text = "Pago/Saída";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(129, 23);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(32, 13);
			this.label20.TabIndex = 12;
			this.label20.Text = "Pago";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(228, 49);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(50, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "Entregue";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(228, 23);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(58, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Cancelado";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Bloqueado";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(32, 23);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(38, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Aberto";
			// 
			// button20
			// 
			this.button20.BackColor = System.Drawing.Color.LightBlue;
			this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button20.Location = new System.Drawing.Point(299, 45);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(20, 20);
			this.button20.TabIndex = 7;
			this.button20.UseVisualStyleBackColor = false;
			// 
			// button19
			// 
			this.button19.BackColor = System.Drawing.Color.Green;
			this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button19.Location = new System.Drawing.Point(299, 19);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(20, 20);
			this.button19.TabIndex = 6;
			this.button19.UseVisualStyleBackColor = false;
			// 
			// button18
			// 
			this.button18.BackColor = System.Drawing.Color.Violet;
			this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button18.Location = new System.Drawing.Point(103, 45);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(20, 20);
			this.button18.TabIndex = 5;
			this.button18.UseVisualStyleBackColor = false;
			// 
			// button17
			// 
			this.button17.BackColor = System.Drawing.Color.LightGreen;
			this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button17.Location = new System.Drawing.Point(103, 19);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(20, 20);
			this.button17.TabIndex = 4;
			this.button17.UseVisualStyleBackColor = false;
			// 
			// button16
			// 
			this.button16.BackColor = System.Drawing.Color.Blue;
			this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button16.Location = new System.Drawing.Point(202, 45);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(20, 20);
			this.button16.TabIndex = 3;
			this.button16.UseVisualStyleBackColor = false;
			// 
			// button15
			// 
			this.button15.BackColor = System.Drawing.Color.Red;
			this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button15.Location = new System.Drawing.Point(202, 19);
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
			this.button13.BackColor = System.Drawing.Color.White;
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button13.Location = new System.Drawing.Point(6, 19);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(20, 20);
			this.button13.TabIndex = 0;
			this.button13.UseVisualStyleBackColor = false;
			// 
			// llAtualizar
			// 
			this.llAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.llAtualizar.AutoSize = true;
			this.llAtualizar.Location = new System.Drawing.Point(9, 553);
			this.llAtualizar.Name = "llAtualizar";
			this.llAtualizar.Size = new System.Drawing.Size(47, 13);
			this.llAtualizar.TabIndex = 14;
			this.llAtualizar.TabStop = true;
			this.llAtualizar.Text = "Atualizar";
			this.llAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAtualizar_LinkClicked);
			// 
			// btCancelar
			// 
			this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.ForeColor = System.Drawing.Color.Red;
			this.btCancelar.Location = new System.Drawing.Point(540, 442);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(107, 28);
			this.btCancelar.TabIndex = 15;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btPagar
			// 
			this.btPagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btPagar.Enabled = false;
			this.btPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btPagar.ForeColor = System.Drawing.Color.Green;
			this.btPagar.Location = new System.Drawing.Point(765, 408);
			this.btPagar.Name = "btPagar";
			this.btPagar.Size = new System.Drawing.Size(107, 28);
			this.btPagar.TabIndex = 16;
			this.btPagar.Text = "&Pagar - F6";
			this.btPagar.UseVisualStyleBackColor = true;
			this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(652, 446);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 17;
			this.button1.Text = "Reimprimir pedido";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// wbMap
			// 
			this.wbMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wbMap.Location = new System.Drawing.Point(118, 27);
			this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbMap.Name = "wbMap";
			this.wbMap.Size = new System.Drawing.Size(416, 526);
			this.wbMap.TabIndex = 18;
			// 
			// frmEntregas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(959, 575);
			this.Controls.Add(this.wbMap);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btPagar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.llAtualizar);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btEntrega);
			this.Controls.Add(this.btSaida);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.dgEntregas);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(810, 614);
			this.Name = "frmEntregas";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Controle de Entregas";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmEntregas_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgEntregas)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem entregasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entregarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dgEntregas;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbPedido;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbCliente;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbRecurso;
		private System.Windows.Forms.TextBox tbEntregador;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.Button btSaida;
		private System.Windows.Forms.Button btEntrega;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button20;
		private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Label lbEndereco;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entregasPorPeríodoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem entregasPorClienteToolStripMenuItem;
		private System.Windows.Forms.TextBox tbHoraEntrega;
		private System.Windows.Forms.TextBox tbHoraSaida;
		private System.Windows.Forms.TextBox tbHoraPedido;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.LinkLabel llAtualizar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btPagar;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.TextBox tbDetalhes;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.WebBrowser wbMap;
	}
}