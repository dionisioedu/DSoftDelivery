namespace DSoft_Delivery
{
	partial class frmCadUsuarios
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadUsuarios));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listaDeUsuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.acessosPorUsuáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbRecurso = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbNivel = new System.Windows.Forms.ComboBox();
			this.lbAviso = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.mbConfirma = new System.Windows.Forms.MaskedTextBox();
			this.mbSenha = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(564, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incluirToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
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
			this.incluirToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.incluirToolStripMenuItem.Text = "&Incluir";
			this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.cancelarToolStripMenuItem.Text = "&Cancelar";
			this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(166, 6);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 22);
			this.toolStripMenuItem3.Text = "&Níveis de usuários";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(166, 6);
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeUsuáriosToolStripMenuItem,
            this.acessosPorUsuáriosToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// listaDeUsuáriosToolStripMenuItem
			// 
			this.listaDeUsuáriosToolStripMenuItem.Name = "listaDeUsuáriosToolStripMenuItem";
			this.listaDeUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.listaDeUsuáriosToolStripMenuItem.Text = "Lista de usuários";
			this.listaDeUsuáriosToolStripMenuItem.Click += new System.EventHandler(this.listaDeUsuáriosToolStripMenuItem_Click);
			// 
			// acessosPorUsuáriosToolStripMenuItem
			// 
			this.acessosPorUsuáriosToolStripMenuItem.Enabled = false;
			this.acessosPorUsuáriosToolStripMenuItem.Name = "acessosPorUsuáriosToolStripMenuItem";
			this.acessosPorUsuáriosToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.acessosPorUsuáriosToolStripMenuItem.Text = "Acessos por usuários";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 185);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(540, 104);
			this.dataGridView1.TabIndex = 10;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbRecurso);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cbNivel);
			this.groupBox1.Controls.Add(this.lbAviso);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.mbConfirma);
			this.groupBox1.Controls.Add(this.mbSenha);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbNome);
			this.groupBox1.Controls.Add(this.tbCodigo);
			this.groupBox1.Enabled = false;
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(541, 102);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// cbRecurso
			// 
			this.cbRecurso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbRecurso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRecurso.FormattingEnabled = true;
			this.cbRecurso.Location = new System.Drawing.Point(6, 71);
			this.cbRecurso.Name = "cbRecurso";
			this.cbRecurso.Size = new System.Drawing.Size(246, 21);
			this.cbRecurso.Sorted = true;
			this.cbRecurso.TabIndex = 2;
			this.cbRecurso.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbRecurso_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Recurso";
			// 
			// cbNivel
			// 
			this.cbNivel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbNivel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNivel.FormattingEnabled = true;
			this.cbNivel.Location = new System.Drawing.Point(258, 71);
			this.cbNivel.Name = "cbNivel";
			this.cbNivel.Size = new System.Drawing.Size(170, 21);
			this.cbNivel.Sorted = true;
			this.cbNivel.TabIndex = 3;
			this.cbNivel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNivel_KeyDown);
			// 
			// lbAviso
			// 
			this.lbAviso.AutoSize = true;
			this.lbAviso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAviso.ForeColor = System.Drawing.Color.Red;
			this.lbAviso.Location = new System.Drawing.Point(11, 71);
			this.lbAviso.Name = "lbAviso";
			this.lbAviso.Size = new System.Drawing.Size(0, 13);
			this.lbAviso.TabIndex = 11;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(255, 55);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Nível do usuário";
			// 
			// mbConfirma
			// 
			this.mbConfirma.Location = new System.Drawing.Point(434, 71);
			this.mbConfirma.Name = "mbConfirma";
			this.mbConfirma.PasswordChar = '*';
			this.mbConfirma.Size = new System.Drawing.Size(100, 20);
			this.mbConfirma.TabIndex = 5;
			this.mbConfirma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbConfirma_KeyDown);
			// 
			// mbSenha
			// 
			this.mbSenha.Location = new System.Drawing.Point(434, 32);
			this.mbSenha.Name = "mbSenha";
			this.mbSenha.PasswordChar = '*';
			this.mbSenha.Size = new System.Drawing.Size(100, 20);
			this.mbSenha.TabIndex = 4;
			this.mbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbSenha_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(431, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Confirma senha";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(431, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Senha";
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
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(112, 32);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(316, 20);
			this.tbNome.TabIndex = 1;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// tbCodigo
			// 
			this.tbCodigo.Location = new System.Drawing.Point(6, 32);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Location = new System.Drawing.Point(433, 135);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 44);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Ordenar por:";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(66, 19);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(53, 17);
			this.radioButton2.TabIndex = 11;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Nome";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 19);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(58, 17);
			this.radioButton1.TabIndex = 10;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Código";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// btConfirmar
			// 
			this.btConfirmar.AutoSize = true;
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(12, 156);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 6;
			this.btConfirmar.Text = "&Incluir - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.AutoSize = true;
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(93, 156);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(80, 23);
			this.btCancelar.TabIndex = 7;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.button4_Click);
			// 
			// btSair
			// 
			this.btSair.AutoSize = true;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(265, 156);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 9;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button5_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.AutoSize = true;
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(179, 156);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(80, 23);
			this.btLimpar.TabIndex = 8;
			this.btLimpar.Text = "&Limpar dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.button6_Click);
			// 
			// frmCadUsuarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(564, 301);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(570, 330);
			this.Name = "frmCadUsuarios";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Usuários";
			this.Load += new System.EventHandler(this.frmCadUsuarios_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem incluirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listaDeUsuáriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem acessosPorUsuáriosToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.MaskedTextBox mbConfirma;
		private System.Windows.Forms.MaskedTextBox mbSenha;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label lbAviso;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.ComboBox cbNivel;
		private System.Windows.Forms.ComboBox cbRecurso;
		private System.Windows.Forms.Label label6;
	}
}