namespace DSoft_Delivery
{
	partial class frmCadFornecedores
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadFornecedores));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btNovo = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbEmail = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbObs = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbCep = new System.Windows.Forms.MaskedTextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbContato = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.tbPais = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbEstado = new System.Windows.Forms.ComboBox();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbBairro = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbTel2 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTel1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCNPJ = new System.Windows.Forms.MaskedTextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
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
            this.toolStripMenuItem2,
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
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem2.Text = "Cancelar";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 272);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(768, 238);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// btNovo
			// 
			this.btNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btNovo.Location = new System.Drawing.Point(270, 221);
			this.btNovo.Name = "btNovo";
			this.btNovo.Size = new System.Drawing.Size(123, 45);
			this.btNovo.TabIndex = 2;
			this.btNovo.Text = "&Novo - F2";
			this.btNovo.UseVisualStyleBackColor = true;
			this.btNovo.Click += new System.EventHandler(this.button1_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(399, 221);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 3;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.button2_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(528, 221);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(123, 45);
			this.btLimpar.TabIndex = 4;
			this.btLimpar.Text = "&Limpar Dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.button3_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(657, 221);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 5;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button4_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbEmail);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.tbObs);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.tbCep);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.tbContato);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.cbTipo);
			this.groupBox1.Controls.Add(this.tbPais);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.cbEstado);
			this.groupBox1.Controls.Add(this.tbCidade);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbBairro);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.tbEndereco);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbTel2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbTel1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbCNPJ);
			this.groupBox1.Controls.Add(this.tbNome);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbCodigo);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(768, 188);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dados Cadastrais";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// tbEmail
			// 
			this.tbEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.tbEmail.Location = new System.Drawing.Point(9, 149);
			this.tbEmail.Name = "tbEmail";
			this.tbEmail.Size = new System.Drawing.Size(306, 20);
			this.tbEmail.TabIndex = 29;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(6, 133);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(34, 13);
			this.label15.TabIndex = 28;
			this.label15.Text = "e-mail";
			// 
			// tbObs
			// 
			this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs.Location = new System.Drawing.Point(321, 109);
			this.tbObs.Multiline = true;
			this.tbObs.Name = "tbObs";
			this.tbObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbObs.Size = new System.Drawing.Size(441, 60);
			this.tbObs.TabIndex = 27;
			this.tbObs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox10_KeyPress);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(318, 93);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(65, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "Observação";
			// 
			// tbCep
			// 
			this.tbCep.Location = new System.Drawing.Point(663, 71);
			this.tbCep.Mask = "00000-000";
			this.tbCep.Name = "tbCep";
			this.tbCep.Size = new System.Drawing.Size(99, 20);
			this.tbCep.TabIndex = 25;
			this.tbCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox2_KeyPress);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(659, 54);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(26, 13);
			this.label13.TabIndex = 24;
			this.label13.Text = "Cep";
			// 
			// tbContato
			// 
			this.tbContato.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbContato.Location = new System.Drawing.Point(115, 109);
			this.tbContato.Name = "tbContato";
			this.tbContato.Size = new System.Drawing.Size(200, 20);
			this.tbContato.TabIndex = 23;
			this.tbContato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox9_KeyPress);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(112, 93);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(44, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "Contato";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 94);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(28, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "Tipo";
			// 
			// cbTipo
			// 
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(9, 109);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(100, 21);
			this.cbTipo.TabIndex = 20;
			this.cbTipo.Text = "C - COMUM";
			this.cbTipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
			// 
			// tbPais
			// 
			this.tbPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPais.Location = new System.Drawing.Point(557, 70);
			this.tbPais.Name = "tbPais";
			this.tbPais.Size = new System.Drawing.Size(100, 20);
			this.tbPais.TabIndex = 19;
			this.tbPais.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox8_KeyPress);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(554, 54);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(27, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Pais";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(424, 55);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "Estado";
			// 
			// cbEstado
			// 
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
			this.cbEstado.Location = new System.Drawing.Point(427, 70);
			this.cbEstado.Name = "cbEstado";
			this.cbEstado.Size = new System.Drawing.Size(121, 21);
			this.cbEstado.TabIndex = 16;
			this.cbEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(321, 71);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(100, 20);
			this.tbCidade.TabIndex = 15;
			this.tbCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(318, 55);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Cidade";
			// 
			// tbBairro
			// 
			this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbBairro.Location = new System.Drawing.Point(215, 71);
			this.tbBairro.Name = "tbBairro";
			this.tbBairro.Size = new System.Drawing.Size(100, 20);
			this.tbBairro.TabIndex = 13;
			this.tbBairro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(212, 55);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Bairro";
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(9, 71);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.Size = new System.Drawing.Size(200, 20);
			this.tbEndereco.TabIndex = 11;
			this.tbEndereco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Endereço";
			// 
			// tbTel2
			// 
			this.tbTel2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTel2.Location = new System.Drawing.Point(557, 32);
			this.tbTel2.Name = "tbTel2";
			this.tbTel2.Size = new System.Drawing.Size(100, 20);
			this.tbTel2.TabIndex = 9;
			this.tbTel2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(554, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Telefone 2";
			// 
			// tbTel1
			// 
			this.tbTel1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTel1.Location = new System.Drawing.Point(451, 32);
			this.tbTel1.Name = "tbTel1";
			this.tbTel1.Size = new System.Drawing.Size(100, 20);
			this.tbTel1.TabIndex = 7;
			this.tbTel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(448, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Telefone 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(318, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Cnpj";
			// 
			// tbCNPJ
			// 
			this.tbCNPJ.Location = new System.Drawing.Point(321, 32);
			this.tbCNPJ.Mask = "000.000.000/0000-00";
			this.tbCNPJ.Name = "tbCNPJ";
			this.tbCNPJ.Size = new System.Drawing.Size(124, 20);
			this.tbCNPJ.TabIndex = 4;
			this.tbCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(115, 32);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(200, 20);
			this.tbNome.TabIndex = 3;
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Nome";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(9, 32);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			this.tbCodigo.Leave += new System.EventHandler(this.textBox1_Leave);
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
			// frmCadFornecedores
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 522);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btNovo);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCadFornecedores";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Fornecedores";
			this.Load += new System.EventHandler(this.frmCadFornecedores_Load);
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
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btNovo;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbBairro;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbTel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox tbCNPJ;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbPais;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbContato;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.MaskedTextBox tbCep;
		private System.Windows.Forms.TextBox tbObs;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.TextBox tbEmail;
		private System.Windows.Forms.Label label15;
	}
}