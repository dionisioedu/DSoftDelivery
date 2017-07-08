namespace DSoft_Delivery
{
	partial class frmCadEmitentes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadEmitentes));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbRazaoSocial = new System.Windows.Forms.TextBox();
			this.tbNomeFantasia = new System.Windows.Forms.TextBox();
			this.mbCnpj = new System.Windows.Forms.MaskedTextBox();
			this.tbInscricaoEstadual = new System.Windows.Forms.TextBox();
			this.tbCnaeFiscal = new System.Windows.Forms.TextBox();
			this.tbInscricaoMunicipal = new System.Windows.Forms.TextBox();
			this.tbLogradouro = new System.Windows.Forms.TextBox();
			this.tbNumero = new System.Windows.Forms.TextBox();
			this.tbComplemento = new System.Windows.Forms.TextBox();
			this.tbBairro = new System.Windows.Forms.TextBox();
			this.mbCep = new System.Windows.Forms.MaskedTextBox();
			this.tbPais = new System.Windows.Forms.TextBox();
			this.cbUf = new System.Windows.Forms.ComboBox();
			this.tbTelefone = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.btSair = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btBloquear = new System.Windows.Forms.Button();
			this.btIncluir = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label16 = new System.Windows.Forms.Label();
			this.tbRNTRC = new System.Windows.Forms.TextBox();
			this.cbMunicipio = new System.Windows.Forms.ComboBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.confirmarToolStripMenuItem.Text = "&Incluir";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(123, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// tbRazaoSocial
			// 
			this.tbRazaoSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbRazaoSocial.Location = new System.Drawing.Point(12, 60);
			this.tbRazaoSocial.Name = "tbRazaoSocial";
			this.tbRazaoSocial.Size = new System.Drawing.Size(200, 20);
			this.tbRazaoSocial.TabIndex = 1;
			// 
			// tbNomeFantasia
			// 
			this.tbNomeFantasia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNomeFantasia.Location = new System.Drawing.Point(218, 60);
			this.tbNomeFantasia.Name = "tbNomeFantasia";
			this.tbNomeFantasia.Size = new System.Drawing.Size(200, 20);
			this.tbNomeFantasia.TabIndex = 2;
			// 
			// mbCnpj
			// 
			this.mbCnpj.Location = new System.Drawing.Point(12, 99);
			this.mbCnpj.Mask = "99.999.999/9999-99";
			this.mbCnpj.Name = "mbCnpj";
			this.mbCnpj.Size = new System.Drawing.Size(120, 20);
			this.mbCnpj.TabIndex = 3;
			// 
			// tbInscricaoEstadual
			// 
			this.tbInscricaoEstadual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbInscricaoEstadual.Location = new System.Drawing.Point(138, 99);
			this.tbInscricaoEstadual.Name = "tbInscricaoEstadual";
			this.tbInscricaoEstadual.Size = new System.Drawing.Size(100, 20);
			this.tbInscricaoEstadual.TabIndex = 4;
			// 
			// tbCnaeFiscal
			// 
			this.tbCnaeFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCnaeFiscal.Location = new System.Drawing.Point(244, 99);
			this.tbCnaeFiscal.Name = "tbCnaeFiscal";
			this.tbCnaeFiscal.Size = new System.Drawing.Size(100, 20);
			this.tbCnaeFiscal.TabIndex = 5;
			// 
			// tbInscricaoMunicipal
			// 
			this.tbInscricaoMunicipal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbInscricaoMunicipal.Location = new System.Drawing.Point(350, 99);
			this.tbInscricaoMunicipal.Name = "tbInscricaoMunicipal";
			this.tbInscricaoMunicipal.Size = new System.Drawing.Size(100, 20);
			this.tbInscricaoMunicipal.TabIndex = 6;
			// 
			// tbLogradouro
			// 
			this.tbLogradouro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbLogradouro.Location = new System.Drawing.Point(12, 138);
			this.tbLogradouro.Name = "tbLogradouro";
			this.tbLogradouro.Size = new System.Drawing.Size(200, 20);
			this.tbLogradouro.TabIndex = 7;
			// 
			// tbNumero
			// 
			this.tbNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNumero.Location = new System.Drawing.Point(218, 138);
			this.tbNumero.Name = "tbNumero";
			this.tbNumero.Size = new System.Drawing.Size(50, 20);
			this.tbNumero.TabIndex = 8;
			// 
			// tbComplemento
			// 
			this.tbComplemento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbComplemento.Location = new System.Drawing.Point(274, 138);
			this.tbComplemento.Name = "tbComplemento";
			this.tbComplemento.Size = new System.Drawing.Size(100, 20);
			this.tbComplemento.TabIndex = 9;
			// 
			// tbBairro
			// 
			this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbBairro.Location = new System.Drawing.Point(380, 138);
			this.tbBairro.Name = "tbBairro";
			this.tbBairro.Size = new System.Drawing.Size(100, 20);
			this.tbBairro.TabIndex = 10;
			// 
			// mbCep
			// 
			this.mbCep.Location = new System.Drawing.Point(486, 138);
			this.mbCep.Mask = "99999-999";
			this.mbCep.Name = "mbCep";
			this.mbCep.Size = new System.Drawing.Size(100, 20);
			this.mbCep.TabIndex = 11;
			// 
			// tbPais
			// 
			this.tbPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPais.Location = new System.Drawing.Point(12, 177);
			this.tbPais.Name = "tbPais";
			this.tbPais.Size = new System.Drawing.Size(100, 20);
			this.tbPais.TabIndex = 12;
			// 
			// cbUf
			// 
			this.cbUf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbUf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbUf.FormattingEnabled = true;
			this.cbUf.Items.AddRange(new object[] {
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
			this.cbUf.Location = new System.Drawing.Point(118, 176);
			this.cbUf.Name = "cbUf";
			this.cbUf.Size = new System.Drawing.Size(100, 21);
			this.cbUf.TabIndex = 13;
			this.cbUf.SelectedIndexChanged += new System.EventHandler(this.cbUf_SelectedIndexChanged);
			// 
			// tbTelefone
			// 
			this.tbTelefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTelefone.Location = new System.Drawing.Point(430, 177);
			this.tbTelefone.Name = "tbTelefone";
			this.tbTelefone.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Razão Social";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(215, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Nome Fantasia";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 83);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Cnpj";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(135, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(94, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Inscrição Estadual";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(241, 83);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 20;
			this.label5.Text = "CNAE Fiscal";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(350, 83);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(98, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Inscrição Municipal";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 122);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(61, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Logradouro";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(215, 122);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(44, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Número";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(274, 122);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 13);
			this.label9.TabIndex = 24;
			this.label9.Text = "Complemento";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(377, 122);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 13);
			this.label10.TabIndex = 25;
			this.label10.Text = "Bairro";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(483, 122);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(26, 13);
			this.label11.TabIndex = 26;
			this.label11.Text = "Cep";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(12, 161);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(29, 13);
			this.label12.TabIndex = 27;
			this.label12.Text = "País";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(115, 161);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(21, 13);
			this.label13.TabIndex = 28;
			this.label13.Text = "UF";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(221, 161);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(54, 13);
			this.label14.TabIndex = 29;
			this.label14.Text = "Município";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(427, 161);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(49, 13);
			this.label15.TabIndex = 30;
			this.label15.Text = "Telefone";
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 222);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 35;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Enabled = false;
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(528, 222);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(123, 45);
			this.btLimpar.TabIndex = 34;
			this.btLimpar.Text = "&Limpar Dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(399, 222);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 33;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btBloquear
			// 
			this.btBloquear.Enabled = false;
			this.btBloquear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btBloquear.Location = new System.Drawing.Point(270, 222);
			this.btBloquear.Name = "btBloquear";
			this.btBloquear.Size = new System.Drawing.Size(123, 45);
			this.btBloquear.TabIndex = 32;
			this.btBloquear.Text = "&Bloquear";
			this.btBloquear.UseVisualStyleBackColor = true;
			// 
			// btIncluir
			// 
			this.btIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btIncluir.Location = new System.Drawing.Point(12, 222);
			this.btIncluir.Name = "btIncluir";
			this.btIncluir.Size = new System.Drawing.Size(123, 45);
			this.btIncluir.TabIndex = 31;
			this.btIncluir.Text = "&Incluir - F2";
			this.btIncluir.UseVisualStyleBackColor = true;
			this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 296);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(770, 216);
			this.dataGridView1.TabIndex = 36;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(533, 161);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(45, 13);
			this.label16.TabIndex = 38;
			this.label16.Text = "RNTRC";
			// 
			// tbRNTRC
			// 
			this.tbRNTRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbRNTRC.Location = new System.Drawing.Point(536, 177);
			this.tbRNTRC.Name = "tbRNTRC";
			this.tbRNTRC.Size = new System.Drawing.Size(100, 20);
			this.tbRNTRC.TabIndex = 37;
			// 
			// cbMunicipio
			// 
			this.cbMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbMunicipio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbMunicipio.FormattingEnabled = true;
			this.cbMunicipio.Items.AddRange(new object[] {
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
			this.cbMunicipio.Location = new System.Drawing.Point(224, 176);
			this.cbMunicipio.Name = "cbMunicipio";
			this.cbMunicipio.Size = new System.Drawing.Size(200, 21);
			this.cbMunicipio.TabIndex = 14;
			// 
			// frmCadEmitentes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 524);
			this.Controls.Add(this.cbMunicipio);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbRNTRC);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btBloquear);
			this.Controls.Add(this.btIncluir);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbTelefone);
			this.Controls.Add(this.cbUf);
			this.Controls.Add(this.tbPais);
			this.Controls.Add(this.mbCep);
			this.Controls.Add(this.tbBairro);
			this.Controls.Add(this.tbComplemento);
			this.Controls.Add(this.tbNumero);
			this.Controls.Add(this.tbLogradouro);
			this.Controls.Add(this.tbInscricaoMunicipal);
			this.Controls.Add(this.tbCnaeFiscal);
			this.Controls.Add(this.tbInscricaoEstadual);
			this.Controls.Add(this.mbCnpj);
			this.Controls.Add(this.tbNomeFantasia);
			this.Controls.Add(this.tbRazaoSocial);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCadEmitentes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Emitentes";
			this.Load += new System.EventHandler(this.frmCadEmitentes_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbRazaoSocial;
		private System.Windows.Forms.TextBox tbNomeFantasia;
		private System.Windows.Forms.MaskedTextBox mbCnpj;
		private System.Windows.Forms.TextBox tbInscricaoEstadual;
		private System.Windows.Forms.TextBox tbCnaeFiscal;
		private System.Windows.Forms.TextBox tbInscricaoMunicipal;
		private System.Windows.Forms.TextBox tbLogradouro;
		private System.Windows.Forms.TextBox tbNumero;
		private System.Windows.Forms.TextBox tbComplemento;
		private System.Windows.Forms.TextBox tbBairro;
		private System.Windows.Forms.MaskedTextBox mbCep;
		private System.Windows.Forms.TextBox tbPais;
		private System.Windows.Forms.ComboBox cbUf;
		private System.Windows.Forms.TextBox tbTelefone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btBloquear;
		private System.Windows.Forms.Button btIncluir;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbRNTRC;
		private System.Windows.Forms.ComboBox cbMunicipio;
	}
}