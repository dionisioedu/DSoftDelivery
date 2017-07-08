namespace DSoft_Delivery
{
	partial class frmCadVeiculos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadVeiculos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mbPlaca = new System.Windows.Forms.MaskedTextBox();
			this.tbModelo = new System.Windows.Forms.TextBox();
			this.tbAno = new System.Windows.Forms.TextBox();
			this.tbCor = new System.Windows.Forms.TextBox();
			this.tbMarca = new System.Windows.Forms.TextBox();
			this.tbProprietario = new System.Windows.Forms.TextBox();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.cbEstado = new System.Windows.Forms.ComboBox();
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
			this.btSair = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btIncluir = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.mbCpf = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.tbRenavam = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbTara = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbCapKg = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbCapM3 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbRNTRC = new System.Windows.Forms.TextBox();
			this.tbIE = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
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
			this.menuStrip1.Size = new System.Drawing.Size(594, 24);
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
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem2.Text = "C&ancelar";
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
			// mbPlaca
			// 
			this.mbPlaca.Location = new System.Drawing.Point(12, 49);
			this.mbPlaca.Mask = "AAA-9999";
			this.mbPlaca.Name = "mbPlaca";
			this.mbPlaca.Size = new System.Drawing.Size(100, 20);
			this.mbPlaca.TabIndex = 1;
			// 
			// tbModelo
			// 
			this.tbModelo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbModelo.Location = new System.Drawing.Point(118, 49);
			this.tbModelo.Name = "tbModelo";
			this.tbModelo.Size = new System.Drawing.Size(200, 20);
			this.tbModelo.TabIndex = 2;
			// 
			// tbAno
			// 
			this.tbAno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbAno.Location = new System.Drawing.Point(324, 49);
			this.tbAno.Name = "tbAno";
			this.tbAno.Size = new System.Drawing.Size(60, 20);
			this.tbAno.TabIndex = 3;
			this.tbAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbCor
			// 
			this.tbCor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCor.Location = new System.Drawing.Point(12, 88);
			this.tbCor.Name = "tbCor";
			this.tbCor.Size = new System.Drawing.Size(100, 20);
			this.tbCor.TabIndex = 4;
			// 
			// tbMarca
			// 
			this.tbMarca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbMarca.Location = new System.Drawing.Point(118, 88);
			this.tbMarca.Name = "tbMarca";
			this.tbMarca.Size = new System.Drawing.Size(200, 20);
			this.tbMarca.TabIndex = 5;
			this.tbMarca.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// tbProprietario
			// 
			this.tbProprietario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbProprietario.Location = new System.Drawing.Point(12, 127);
			this.tbProprietario.Name = "tbProprietario";
			this.tbProprietario.Size = new System.Drawing.Size(200, 20);
			this.tbProprietario.TabIndex = 6;
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(218, 127);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.Size = new System.Drawing.Size(200, 20);
			this.tbEndereco.TabIndex = 7;
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(424, 127);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(100, 20);
			this.tbCidade.TabIndex = 8;
			// 
			// cbEstado
			// 
			this.cbEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbEstado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbEstado.FormattingEnabled = true;
			this.cbEstado.Items.AddRange(new object[] {
            "AC - Acre",
            "AL - Alagoas",
            "AM - Amazonas",
            "AP - Amapá",
            "BA - Bahia",
            "CE - Ceará",
            "DF - Distrito Federal",
            "ES - Espírito Santo",
            "GO - Goiás",
            "MA - Maranhão",
            "MG - Minas Gerais",
            "MS - Mato Grosso do Sul",
            "MT - Mato Grosso",
            "PA - Pará",
            "PB - Paraíba",
            "PE - Pernambuco",
            "PI - Piauí",
            "PR - Paraná",
            "RJ - Rio de Janeiro",
            "RN - Rio Grande do Norte",
            "RO - Rondônia",
            "RR - Roraima",
            "RS - Rio Grande do Sul",
            "SC - Santa Catarina",
            "SE - Sergipe",
            "SP - São Paulo",
            "TO - Tocantins"});
			this.cbEstado.Location = new System.Drawing.Point(530, 127);
			this.cbEstado.Name = "cbEstado";
			this.cbEstado.Size = new System.Drawing.Size(52, 21);
			this.cbEstado.TabIndex = 9;
			// 
			// tbTelefone
			// 
			this.tbTelefone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTelefone.Location = new System.Drawing.Point(12, 166);
			this.tbTelefone.Name = "tbTelefone";
			this.tbTelefone.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone.TabIndex = 10;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Placa";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(42, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Modelo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(321, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(26, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Ano";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(23, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Cor";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(115, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(37, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Marca";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 111);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Proprietário";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(215, 111);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Endereço";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(424, 111);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Cidade";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(527, 111);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(40, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "Estado";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(9, 150);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(49, 13);
			this.label10.TabIndex = 21;
			this.label10.Text = "Telefone";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(115, 150);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(65, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "CPF / CNPJ";
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(459, 193);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 40;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Enabled = false;
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(330, 192);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(123, 45);
			this.btLimpar.TabIndex = 39;
			this.btLimpar.Text = "&Limpar Dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(201, 193);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 38;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btIncluir
			// 
			this.btIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btIncluir.Location = new System.Drawing.Point(12, 193);
			this.btIncluir.Name = "btIncluir";
			this.btIncluir.Size = new System.Drawing.Size(123, 45);
			this.btIncluir.TabIndex = 36;
			this.btIncluir.Text = "&Incluir - F2";
			this.btIncluir.UseVisualStyleBackColor = true;
			this.btIncluir.Click += new System.EventHandler(this.btIncluir_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 244);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(570, 187);
			this.dataGridView1.TabIndex = 41;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// mbCpf
			// 
			this.mbCpf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.mbCpf.Location = new System.Drawing.Point(118, 166);
			this.mbCpf.Name = "mbCpf";
			this.mbCpf.Size = new System.Drawing.Size(141, 20);
			this.mbCpf.TabIndex = 11;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(321, 72);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 13);
			this.label12.TabIndex = 43;
			this.label12.Text = "RENAVAM";
			// 
			// tbRenavam
			// 
			this.tbRenavam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbRenavam.Location = new System.Drawing.Point(324, 88);
			this.tbRenavam.Name = "tbRenavam";
			this.tbRenavam.Size = new System.Drawing.Size(60, 20);
			this.tbRenavam.TabIndex = 42;
			this.tbRenavam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(387, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(29, 13);
			this.label13.TabIndex = 45;
			this.label13.Text = "Tara";
			// 
			// tbTara
			// 
			this.tbTara.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTara.Location = new System.Drawing.Point(390, 88);
			this.tbTara.Name = "tbTara";
			this.tbTara.Size = new System.Drawing.Size(60, 20);
			this.tbTara.TabIndex = 44;
			this.tbTara.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(453, 72);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(42, 13);
			this.label14.TabIndex = 47;
			this.label14.Text = "Cap Kg";
			// 
			// tbCapKg
			// 
			this.tbCapKg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCapKg.Location = new System.Drawing.Point(456, 88);
			this.tbCapKg.Name = "tbCapKg";
			this.tbCapKg.Size = new System.Drawing.Size(60, 20);
			this.tbCapKg.TabIndex = 46;
			this.tbCapKg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(519, 72);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(44, 13);
			this.label15.TabIndex = 49;
			this.label15.Text = "Cap M3";
			// 
			// tbCapM3
			// 
			this.tbCapM3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCapM3.Location = new System.Drawing.Point(522, 88);
			this.tbCapM3.Name = "tbCapM3";
			this.tbCapM3.Size = new System.Drawing.Size(60, 20);
			this.tbCapM3.TabIndex = 48;
			this.tbCapM3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(262, 150);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(45, 13);
			this.label16.TabIndex = 51;
			this.label16.Text = "RNTRC";
			// 
			// tbRNTRC
			// 
			this.tbRNTRC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbRNTRC.Location = new System.Drawing.Point(265, 166);
			this.tbRNTRC.Name = "tbRNTRC";
			this.tbRNTRC.Size = new System.Drawing.Size(60, 20);
			this.tbRNTRC.TabIndex = 12;
			// 
			// tbIE
			// 
			this.tbIE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbIE.Location = new System.Drawing.Point(331, 166);
			this.tbIE.Name = "tbIE";
			this.tbIE.Size = new System.Drawing.Size(100, 20);
			this.tbIE.TabIndex = 13;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(328, 150);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(94, 13);
			this.label17.TabIndex = 53;
			this.label17.Text = "Inscrição Estadual";
			// 
			// frmCadVeiculos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 443);
			this.Controls.Add(this.tbIE);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbRNTRC);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.tbCapM3);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbCapKg);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tbTara);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbRenavam);
			this.Controls.Add(this.mbCpf);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btIncluir);
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
			this.Controls.Add(this.cbEstado);
			this.Controls.Add(this.tbCidade);
			this.Controls.Add(this.tbEndereco);
			this.Controls.Add(this.tbProprietario);
			this.Controls.Add(this.tbMarca);
			this.Controls.Add(this.tbCor);
			this.Controls.Add(this.tbAno);
			this.Controls.Add(this.tbModelo);
			this.Controls.Add(this.mbPlaca);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCadVeiculos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Veículos";
			this.Load += new System.EventHandler(this.frmCadVeiculos_Load);
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
		private System.Windows.Forms.MaskedTextBox mbPlaca;
		private System.Windows.Forms.TextBox tbModelo;
		private System.Windows.Forms.TextBox tbAno;
		private System.Windows.Forms.TextBox tbCor;
		private System.Windows.Forms.TextBox tbMarca;
		private System.Windows.Forms.TextBox tbProprietario;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.ComboBox cbEstado;
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
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btIncluir;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.TextBox mbCpf;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbRenavam;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbTara;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbCapKg;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbCapM3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbRNTRC;
		private System.Windows.Forms.TextBox tbIE;
		private System.Windows.Forms.Label label17;
	}
}