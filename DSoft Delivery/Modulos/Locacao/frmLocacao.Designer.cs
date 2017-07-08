namespace DSoft_Delivery.Modulos.Locacao
{
	partial class frmLocacao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLocacao));
			this.dgLocacao = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.locaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.locaçõesPorUsuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgProdutos = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.dtInicioData = new System.Windows.Forms.DateTimePicker();
			this.dtInicioHora = new System.Windows.Forms.DateTimePicker();
			this.dtPrevisaoData = new System.Windows.Forms.DateTimePicker();
			this.dtPrevisaoHora = new System.Windows.Forms.DateTimePicker();
			this.dtChegadaHora = new System.Windows.Forms.DateTimePicker();
			this.dtChegadaData = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.lbCliente = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lbProduto = new System.Windows.Forms.Label();
			this.btNovoCliente = new System.Windows.Forms.Button();
			this.tbValorPrevisto = new System.Windows.Forms.TextBox();
			this.tbValorReal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbObservacao = new System.Windows.Forms.TextBox();
			this.llAtualizar = new System.Windows.Forms.LinkLabel();
			this.cbTabelas = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.btReceber = new System.Windows.Forms.Button();
			this.btTermoDeResponsabilidade = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgLocacao)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgLocacao
			// 
			this.dgLocacao.AllowUserToAddRows = false;
			this.dgLocacao.AllowUserToDeleteRows = false;
			this.dgLocacao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgLocacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgLocacao.Location = new System.Drawing.Point(12, 332);
			this.dgLocacao.Name = "dgLocacao";
			this.dgLocacao.ReadOnly = true;
			this.dgLocacao.RowHeadersWidth = 18;
			this.dgLocacao.Size = new System.Drawing.Size(872, 95);
			this.dgLocacao.TabIndex = 0;
			this.dgLocacao.DoubleClick += new System.EventHandler(this.dgLocacao_DoubleClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locaçãoToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.consultasToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(896, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// locaçãoToolStripMenuItem
			// 
			this.locaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
			this.locaçãoToolStripMenuItem.Name = "locaçãoToolStripMenuItem";
			this.locaçãoToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
			this.locaçãoToolStripMenuItem.Text = "&Locação";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F12;
			this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
			this.toolStripMenuItem1.Text = "&Confirmar";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// ajudaToolStripMenuItem
			// 
			this.ajudaToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
			this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.ajudaToolStripMenuItem.Text = "&Ajuda";
			// 
			// consultasToolStripMenuItem
			// 
			this.consultasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locaçõesPorUsuárioToolStripMenuItem});
			this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
			this.consultasToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.consultasToolStripMenuItem.Text = "Consultas";
			// 
			// locaçõesPorUsuárioToolStripMenuItem
			// 
			this.locaçõesPorUsuárioToolStripMenuItem.Name = "locaçõesPorUsuárioToolStripMenuItem";
			this.locaçõesPorUsuárioToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.locaçõesPorUsuárioToolStripMenuItem.Text = "Locações por usuário";
			this.locaçõesPorUsuárioToolStripMenuItem.Click += new System.EventHandler(this.locaçõesPorUsuárioToolStripMenuItem_Click);
			// 
			// tbCliente
			// 
			this.tbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.tbCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCliente.Location = new System.Drawing.Point(12, 46);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.Size = new System.Drawing.Size(237, 20);
			this.tbCliente.TabIndex = 2;
			this.tbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCliente_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Cliente";
			// 
			// dgProdutos
			// 
			this.dgProdutos.AllowUserToAddRows = false;
			this.dgProdutos.AllowUserToDeleteRows = false;
			this.dgProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgProdutos.Location = new System.Drawing.Point(525, 48);
			this.dgProdutos.Name = "dgProdutos";
			this.dgProdutos.ReadOnly = true;
			this.dgProdutos.RowHeadersWidth = 18;
			this.dgProdutos.Size = new System.Drawing.Size(359, 170);
			this.dgProdutos.TabIndex = 5;
			this.dgProdutos.DoubleClick += new System.EventHandler(this.dgProdutos_DoubleClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(522, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(227, 15);
			this.label2.TabIndex = 6;
			this.label2.Text = "Produtos disponíveis para locação";
			// 
			// dtInicioData
			// 
			this.dtInicioData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicioData.Location = new System.Drawing.Point(12, 266);
			this.dtInicioData.Name = "dtInicioData";
			this.dtInicioData.Size = new System.Drawing.Size(100, 20);
			this.dtInicioData.TabIndex = 7;
			this.dtInicioData.ValueChanged += new System.EventHandler(this.dtInicioData_ValueChanged);
			// 
			// dtInicioHora
			// 
			this.dtInicioHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtInicioHora.Location = new System.Drawing.Point(118, 266);
			this.dtInicioHora.Name = "dtInicioHora";
			this.dtInicioHora.Size = new System.Drawing.Size(100, 20);
			this.dtInicioHora.TabIndex = 8;
			this.dtInicioHora.ValueChanged += new System.EventHandler(this.dtInicioHora_ValueChanged);
			// 
			// dtPrevisaoData
			// 
			this.dtPrevisaoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtPrevisaoData.Location = new System.Drawing.Point(224, 266);
			this.dtPrevisaoData.Name = "dtPrevisaoData";
			this.dtPrevisaoData.Size = new System.Drawing.Size(100, 20);
			this.dtPrevisaoData.TabIndex = 9;
			this.dtPrevisaoData.ValueChanged += new System.EventHandler(this.dtPrevisaoData_ValueChanged);
			// 
			// dtPrevisaoHora
			// 
			this.dtPrevisaoHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtPrevisaoHora.Location = new System.Drawing.Point(330, 266);
			this.dtPrevisaoHora.Name = "dtPrevisaoHora";
			this.dtPrevisaoHora.Size = new System.Drawing.Size(100, 20);
			this.dtPrevisaoHora.TabIndex = 10;
			this.dtPrevisaoHora.ValueChanged += new System.EventHandler(this.dtPrevisaoHora_ValueChanged);
			// 
			// dtChegadaHora
			// 
			this.dtChegadaHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtChegadaHora.Location = new System.Drawing.Point(118, 305);
			this.dtChegadaHora.Name = "dtChegadaHora";
			this.dtChegadaHora.Size = new System.Drawing.Size(100, 20);
			this.dtChegadaHora.TabIndex = 12;
			// 
			// dtChegadaData
			// 
			this.dtChegadaData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtChegadaData.Location = new System.Drawing.Point(12, 305);
			this.dtChegadaData.Name = "dtChegadaData";
			this.dtChegadaData.Size = new System.Drawing.Size(100, 20);
			this.dtChegadaData.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 250);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Início da locação";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(221, 250);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Previsão de chegada";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 289);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Devolução";
			// 
			// btLimpar
			// 
			this.btLimpar.Location = new System.Drawing.Point(12, 224);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(75, 23);
			this.btLimpar.TabIndex = 16;
			this.btLimpar.Text = "&Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Location = new System.Drawing.Point(442, 303);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(75, 23);
			this.btCancelar.TabIndex = 17;
			this.btCancelar.Text = "C&ancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.AutoSize = true;
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(578, 261);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(154, 25);
			this.btConfirmar.TabIndex = 18;
			this.btConfirmar.Text = "&Confirmar locação F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(780, 433);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(104, 34);
			this.btSair.TabIndex = 19;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// lbCliente
			// 
			this.lbCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCliente.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbCliente.Location = new System.Drawing.Point(12, 69);
			this.lbCliente.Name = "lbCliente";
			this.lbCliente.Size = new System.Drawing.Size(507, 66);
			this.lbCliente.TabIndex = 20;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Produto";
			// 
			// lbProduto
			// 
			this.lbProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbProduto.Location = new System.Drawing.Point(12, 148);
			this.lbProduto.Name = "lbProduto";
			this.lbProduto.Size = new System.Drawing.Size(507, 29);
			this.lbProduto.TabIndex = 22;
			// 
			// btNovoCliente
			// 
			this.btNovoCliente.Location = new System.Drawing.Point(255, 43);
			this.btNovoCliente.Name = "btNovoCliente";
			this.btNovoCliente.Size = new System.Drawing.Size(75, 23);
			this.btNovoCliente.TabIndex = 23;
			this.btNovoCliente.Text = "Novo cliente";
			this.btNovoCliente.UseVisualStyleBackColor = true;
			this.btNovoCliente.Click += new System.EventHandler(this.btNovoCliente_Click);
			// 
			// tbValorPrevisto
			// 
			this.tbValorPrevisto.Location = new System.Drawing.Point(472, 266);
			this.tbValorPrevisto.Name = "tbValorPrevisto";
			this.tbValorPrevisto.ReadOnly = true;
			this.tbValorPrevisto.Size = new System.Drawing.Size(100, 20);
			this.tbValorPrevisto.TabIndex = 24;
			this.tbValorPrevisto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbValorReal
			// 
			this.tbValorReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbValorReal.Location = new System.Drawing.Point(255, 305);
			this.tbValorReal.Name = "tbValorReal";
			this.tbValorReal.ReadOnly = true;
			this.tbValorReal.Size = new System.Drawing.Size(100, 21);
			this.tbValorReal.TabIndex = 25;
			this.tbValorReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(445, 269);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 13);
			this.label7.TabIndex = 26;
			this.label7.Text = "R$";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(469, 250);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(71, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "Valor previsto";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(228, 308);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(21, 13);
			this.label9.TabIndex = 28;
			this.label9.Text = "R$";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(252, 289);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(51, 13);
			this.label10.TabIndex = 29;
			this.label10.Text = "Valor real";
			// 
			// tbObservacao
			// 
			this.tbObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao.Location = new System.Drawing.Point(12, 180);
			this.tbObservacao.Multiline = true;
			this.tbObservacao.Name = "tbObservacao";
			this.tbObservacao.Size = new System.Drawing.Size(507, 38);
			this.tbObservacao.TabIndex = 30;
			// 
			// llAtualizar
			// 
			this.llAtualizar.AutoSize = true;
			this.llAtualizar.Location = new System.Drawing.Point(115, 250);
			this.llAtualizar.Name = "llAtualizar";
			this.llAtualizar.Size = new System.Drawing.Size(47, 13);
			this.llAtualizar.TabIndex = 31;
			this.llAtualizar.TabStop = true;
			this.llAtualizar.Text = "Atualizar";
			this.llAtualizar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llAtualizar_LinkClicked);
			// 
			// cbTabelas
			// 
			this.cbTabelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTabelas.FormattingEnabled = true;
			this.cbTabelas.Location = new System.Drawing.Point(336, 45);
			this.cbTabelas.Name = "cbTabelas";
			this.cbTabelas.Size = new System.Drawing.Size(183, 21);
			this.cbTabelas.TabIndex = 32;
			this.cbTabelas.SelectedIndexChanged += new System.EventHandler(this.cbTabelas_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(333, 29);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(91, 13);
			this.label11.TabIndex = 33;
			this.label11.Text = "Tabela de Preços";
			// 
			// btReceber
			// 
			this.btReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btReceber.Location = new System.Drawing.Point(361, 303);
			this.btReceber.Name = "btReceber";
			this.btReceber.Size = new System.Drawing.Size(75, 23);
			this.btReceber.TabIndex = 34;
			this.btReceber.Text = "&Receber";
			this.btReceber.UseVisualStyleBackColor = true;
			this.btReceber.Click += new System.EventHandler(this.btReceber_Click);
			// 
			// btTermoDeResponsabilidade
			// 
			this.btTermoDeResponsabilidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btTermoDeResponsabilidade.AutoSize = true;
			this.btTermoDeResponsabilidade.Location = new System.Drawing.Point(12, 444);
			this.btTermoDeResponsabilidade.Name = "btTermoDeResponsabilidade";
			this.btTermoDeResponsabilidade.Size = new System.Drawing.Size(187, 23);
			this.btTermoDeResponsabilidade.TabIndex = 35;
			this.btTermoDeResponsabilidade.Text = "Imprimir Termo de Responsabilidade";
			this.btTermoDeResponsabilidade.UseVisualStyleBackColor = true;
			this.btTermoDeResponsabilidade.Click += new System.EventHandler(this.btTermoDeResponsabilidade_Click);
			// 
			// frmLocacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(896, 479);
			this.Controls.Add(this.btTermoDeResponsabilidade);
			this.Controls.Add(this.btReceber);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.cbTabelas);
			this.Controls.Add(this.llAtualizar);
			this.Controls.Add(this.tbObservacao);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbValorReal);
			this.Controls.Add(this.tbValorPrevisto);
			this.Controls.Add(this.btNovoCliente);
			this.Controls.Add(this.lbProduto);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lbCliente);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtChegadaHora);
			this.Controls.Add(this.dtChegadaData);
			this.Controls.Add(this.dtPrevisaoHora);
			this.Controls.Add(this.dtPrevisaoData);
			this.Controls.Add(this.dtInicioHora);
			this.Controls.Add(this.dtInicioData);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgProdutos);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgLocacao);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(912, 508);
			this.Name = "frmLocacao";
			this.Text = "Locação";
			this.Load += new System.EventHandler(this.frmLocacao_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgLocacao)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgLocacao;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem locaçãoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgProdutos;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dtInicioData;
		private System.Windows.Forms.DateTimePicker dtInicioHora;
		private System.Windows.Forms.DateTimePicker dtPrevisaoData;
		private System.Windows.Forms.DateTimePicker dtPrevisaoHora;
		private System.Windows.Forms.DateTimePicker dtChegadaHora;
		private System.Windows.Forms.DateTimePicker dtChegadaData;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label lbCliente;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbProduto;
		private System.Windows.Forms.Button btNovoCliente;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.TextBox tbValorPrevisto;
		private System.Windows.Forms.TextBox tbValorReal;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbObservacao;
		private System.Windows.Forms.LinkLabel llAtualizar;
		private System.Windows.Forms.ComboBox cbTabelas;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btReceber;
		private System.Windows.Forms.Button btTermoDeResponsabilidade;
		private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem locaçõesPorUsuárioToolStripMenuItem;
	}
}