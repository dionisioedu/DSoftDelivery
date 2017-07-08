namespace DSoft_Delivery.Forms
{
	partial class frmCadFiliais
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadFiliais));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbCnpj = new System.Windows.Forms.TextBox();
			this.tbTelefone = new System.Windows.Forms.TextBox();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.tbBairro = new System.Windows.Forms.TextBox();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.tbEstado = new System.Windows.Forms.TextBox();
			this.tbPais = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(713, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// tbCodigo
			// 
			this.tbCodigo.Location = new System.Drawing.Point(12, 49);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(118, 49);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(200, 20);
			this.tbNome.TabIndex = 2;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// tbCnpj
			// 
			this.tbCnpj.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCnpj.Location = new System.Drawing.Point(324, 49);
			this.tbCnpj.Name = "tbCnpj";
			this.tbCnpj.Size = new System.Drawing.Size(120, 20);
			this.tbCnpj.TabIndex = 3;
			this.tbCnpj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCnpj_KeyDown);
			// 
			// tbTelefone
			// 
			this.tbTelefone.Location = new System.Drawing.Point(450, 49);
			this.tbTelefone.Name = "tbTelefone";
			this.tbTelefone.Size = new System.Drawing.Size(100, 20);
			this.tbTelefone.TabIndex = 4;
			this.tbTelefone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTelefone_KeyDown);
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(12, 88);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.Size = new System.Drawing.Size(200, 20);
			this.tbEndereco.TabIndex = 5;
			this.tbEndereco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEndereco_KeyDown);
			// 
			// tbBairro
			// 
			this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbBairro.Location = new System.Drawing.Point(218, 88);
			this.tbBairro.Name = "tbBairro";
			this.tbBairro.Size = new System.Drawing.Size(100, 20);
			this.tbBairro.TabIndex = 6;
			this.tbBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBairro_KeyDown);
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(324, 88);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(100, 20);
			this.tbCidade.TabIndex = 7;
			this.tbCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCidade_KeyDown);
			// 
			// tbEstado
			// 
			this.tbEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEstado.Location = new System.Drawing.Point(430, 88);
			this.tbEstado.Name = "tbEstado";
			this.tbEstado.Size = new System.Drawing.Size(100, 20);
			this.tbEstado.TabIndex = 8;
			this.tbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEstado_KeyDown);
			// 
			// tbPais
			// 
			this.tbPais.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPais.Location = new System.Drawing.Point(536, 88);
			this.tbPais.Name = "tbPais";
			this.tbPais.Size = new System.Drawing.Size(100, 20);
			this.tbPais.TabIndex = 9;
			this.tbPais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPais_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 13;
			this.label2.Text = "Nome";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(321, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Cnpj";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(447, 33);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 13);
			this.label4.TabIndex = 15;
			this.label4.Text = "Telefone";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 72);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Endereço";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(215, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Bairro";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(321, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "Cidade";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(427, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Estado";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(533, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(29, 13);
			this.label9.TabIndex = 20;
			this.label9.Text = "País";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(12, 114);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 21;
			this.btConfirmar.Text = "&Confirmar F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Location = new System.Drawing.Point(93, 114);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(75, 23);
			this.btCancelar.TabIndex = 22;
			this.btCancelar.Text = "&Cancelar F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Location = new System.Drawing.Point(174, 114);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(75, 23);
			this.btLimpar.TabIndex = 23;
			this.btLimpar.Text = "&Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(255, 114);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 24;
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
			this.dataGridView1.Location = new System.Drawing.Point(12, 143);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(689, 267);
			this.dataGridView1.TabIndex = 25;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// frmCadFiliais
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(713, 422);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbPais);
			this.Controls.Add(this.tbEstado);
			this.Controls.Add(this.tbCidade);
			this.Controls.Add(this.tbBairro);
			this.Controls.Add(this.tbEndereco);
			this.Controls.Add(this.tbTelefone);
			this.Controls.Add(this.tbCnpj);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmCadFiliais";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Filiais";
			this.Load += new System.EventHandler(this.frmCadFiliais_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbCnpj;
		private System.Windows.Forms.TextBox tbTelefone;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.TextBox tbBairro;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.TextBox tbEstado;
		private System.Windows.Forms.TextBox tbPais;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}