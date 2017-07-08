namespace DSoft_Delivery.Forms
{
	partial class frmCadRapido
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadRapido));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbEndereco = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbCel = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbTel2 = new System.Windows.Forms.TextBox();
			this.tbTel1 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbReferencia = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbBairro = new System.Windows.Forms.Label();
			this.tbBairro = new System.Windows.Forms.TextBox();
			this.llCompleta = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.tbCpf = new System.Windows.Forms.MaskedTextBox();
			this.cbBairro = new System.Windows.Forms.ComboBox();
			this.mbCep = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbEstado = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pnTaxaDeEntrega = new System.Windows.Forms.Panel();
			this.tbTaxaDeEntrega = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.llCadastroGrupos = new System.Windows.Forms.LinkLabel();
			this.menuStrip1.SuspendLayout();
			this.pnTaxaDeEntrega.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(584, 24);
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
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "Cadastro";
			this.cadastroToolStripMenuItem.Visible = false;
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(320, 289);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 15;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(449, 289);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 16;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button2_Click);
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(12, 59);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			this.tbCodigo.Leave += new System.EventHandler(this.tbCodigo_Leave);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(118, 59);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(206, 20);
			this.tbNome.TabIndex = 1;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// tbEndereco
			// 
			this.tbEndereco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEndereco.Location = new System.Drawing.Point(118, 137);
			this.tbEndereco.Name = "tbEndereco";
			this.tbEndereco.Size = new System.Drawing.Size(242, 20);
			this.tbEndereco.TabIndex = 8;
			this.tbEndereco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEndereco_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(118, 121);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 13);
			this.label10.TabIndex = 26;
			this.label10.Text = "Endereço";
			// 
			// tbCel
			// 
			this.tbCel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCel.Location = new System.Drawing.Point(224, 98);
			this.tbCel.Name = "tbCel";
			this.tbCel.Size = new System.Drawing.Size(100, 20);
			this.tbCel.TabIndex = 6;
			this.tbCel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCel_KeyDown);
			this.tbCel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCel_KeyPress);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(224, 82);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 13);
			this.label9.TabIndex = 25;
			this.label9.Text = "Celular";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 82);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Telefone 1";
			// 
			// tbTel2
			// 
			this.tbTel2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTel2.Location = new System.Drawing.Point(118, 98);
			this.tbTel2.Name = "tbTel2";
			this.tbTel2.Size = new System.Drawing.Size(100, 20);
			this.tbTel2.TabIndex = 5;
			this.tbTel2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTel2_KeyDown);
			this.tbTel2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel2_KeyPress);
			// 
			// tbTel1
			// 
			this.tbTel1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTel1.Location = new System.Drawing.Point(12, 98);
			this.tbTel1.Name = "tbTel1";
			this.tbTel1.Size = new System.Drawing.Size(100, 20);
			this.tbTel1.TabIndex = 4;
			this.tbTel1.Enter += new System.EventHandler(this.tbTel1_Enter);
			this.tbTel1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTel1_KeyDown);
			this.tbTel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTel1_KeyPress);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(118, 82);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 13);
			this.label8.TabIndex = 23;
			this.label8.Text = "Telefone 2";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(13, 201);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(59, 13);
			this.label16.TabIndex = 32;
			this.label16.Text = "Referência";
			// 
			// tbReferencia
			// 
			this.tbReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbReferencia.Location = new System.Drawing.Point(13, 217);
			this.tbReferencia.Multiline = true;
			this.tbReferencia.Name = "tbReferencia";
			this.tbReferencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbReferencia.Size = new System.Drawing.Size(362, 47);
			this.tbReferencia.TabIndex = 14;
			this.tbReferencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbReferencia_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Nome";
			// 
			// lbBairro
			// 
			this.lbBairro.AutoSize = true;
			this.lbBairro.Location = new System.Drawing.Point(368, 121);
			this.lbBairro.Name = "lbBairro";
			this.lbBairro.Size = new System.Drawing.Size(34, 13);
			this.lbBairro.TabIndex = 36;
			this.lbBairro.Text = "Bairro";
			// 
			// tbBairro
			// 
			this.tbBairro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbBairro.Location = new System.Drawing.Point(368, 137);
			this.tbBairro.Name = "tbBairro";
			this.tbBairro.Size = new System.Drawing.Size(192, 20);
			this.tbBairro.TabIndex = 9;
			this.tbBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBairro_KeyDown);
			// 
			// llCompleta
			// 
			this.llCompleta.AutoSize = true;
			this.llCompleta.Location = new System.Drawing.Point(12, 324);
			this.llCompleta.Name = "llCompleta";
			this.llCompleta.Size = new System.Drawing.Size(87, 13);
			this.llCompleta.TabIndex = 14;
			this.llCompleta.TabStop = true;
			this.llCompleta.Text = "Versão Completa";
			this.llCompleta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCompleta_LinkClicked);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(330, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 13);
			this.label3.TabIndex = 39;
			this.label3.Text = "CPF";
			// 
			// tbCpf
			// 
			this.tbCpf.Location = new System.Drawing.Point(330, 59);
			this.tbCpf.Mask = "999.999.999-99";
			this.tbCpf.Name = "tbCpf";
			this.tbCpf.Size = new System.Drawing.Size(100, 20);
			this.tbCpf.TabIndex = 3;
			// 
			// cbBairro
			// 
			this.cbBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBairro.FormattingEnabled = true;
			this.cbBairro.Location = new System.Drawing.Point(368, 163);
			this.cbBairro.Name = "cbBairro";
			this.cbBairro.Size = new System.Drawing.Size(192, 21);
			this.cbBairro.TabIndex = 10;
			this.cbBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBairro_KeyDown);
			// 
			// mbCep
			// 
			this.mbCep.Location = new System.Drawing.Point(13, 137);
			this.mbCep.Mask = "99999-999";
			this.mbCep.Name = "mbCep";
			this.mbCep.Size = new System.Drawing.Size(100, 20);
			this.mbCep.TabIndex = 7;
			this.mbCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbCep_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 121);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 42;
			this.label4.Text = "CEP";
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(12, 176);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(200, 20);
			this.tbCidade.TabIndex = 11;
			this.tbCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCidade_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 44;
			this.label5.Text = "Cidade";
			// 
			// cbEstado
			// 
			this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEstado.FormattingEnabled = true;
			this.cbEstado.Location = new System.Drawing.Point(218, 176);
			this.cbEstado.Name = "cbEstado";
			this.cbEstado.Size = new System.Drawing.Size(200, 21);
			this.cbEstado.TabIndex = 12;
			this.cbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEstado_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(215, 160);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 46;
			this.label6.Text = "Estado";
			// 
			// pnTaxaDeEntrega
			// 
			this.pnTaxaDeEntrega.Controls.Add(this.tbTaxaDeEntrega);
			this.pnTaxaDeEntrega.Controls.Add(this.label13);
			this.pnTaxaDeEntrega.Controls.Add(this.label12);
			this.pnTaxaDeEntrega.Location = new System.Drawing.Point(429, 163);
			this.pnTaxaDeEntrega.Name = "pnTaxaDeEntrega";
			this.pnTaxaDeEntrega.Size = new System.Drawing.Size(143, 51);
			this.pnTaxaDeEntrega.TabIndex = 13;
			this.pnTaxaDeEntrega.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// tbTaxaDeEntrega
			// 
			this.tbTaxaDeEntrega.Location = new System.Drawing.Point(29, 16);
			this.tbTaxaDeEntrega.Name = "tbTaxaDeEntrega";
			this.tbTaxaDeEntrega.Size = new System.Drawing.Size(100, 20);
			this.tbTaxaDeEntrega.TabIndex = 0;
			this.tbTaxaDeEntrega.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTaxaDeEntrega.Enter += new System.EventHandler(this.tbTaxaDeEntrega_Enter);
			this.tbTaxaDeEntrega.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTaxaDeEntrega_KeyDown);
			this.tbTaxaDeEntrega.Leave += new System.EventHandler(this.tbTaxaDeEntrega_Leave);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(2, 19);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(21, 13);
			this.label13.TabIndex = 1;
			this.label13.Text = "R$";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(26, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(85, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "Taxa de entrega";
			// 
			// llCadastroGrupos
			// 
			this.llCadastroGrupos.AutoSize = true;
			this.llCadastroGrupos.Location = new System.Drawing.Point(408, 121);
			this.llCadastroGrupos.Name = "llCadastroGrupos";
			this.llCadastroGrupos.Size = new System.Drawing.Size(33, 13);
			this.llCadastroGrupos.TabIndex = 47;
			this.llCadastroGrupos.TabStop = true;
			this.llCadastroGrupos.Text = "Novo";
			this.llCadastroGrupos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCadastroGrupos_LinkClicked);
			// 
			// frmCadRapido
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 346);
			this.Controls.Add(this.llCadastroGrupos);
			this.Controls.Add(this.pnTaxaDeEntrega);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cbEstado);
			this.Controls.Add(this.tbCidade);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.mbCep);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cbBairro);
			this.Controls.Add(this.tbCpf);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.llCompleta);
			this.Controls.Add(this.lbBairro);
			this.Controls.Add(this.tbBairro);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbReferencia);
			this.Controls.Add(this.tbEndereco);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbCel);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbTel2);
			this.Controls.Add(this.tbTel1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCadRapido";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Clientes";
			this.Load += new System.EventHandler(this.frmCadRapido_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.pnTaxaDeEntrega.ResumeLayout(false);
			this.pnTaxaDeEntrega.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbEndereco;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbCel;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbTel2;
		private System.Windows.Forms.TextBox tbTel1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbReferencia;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbBairro;
		private System.Windows.Forms.TextBox tbBairro;
		private System.Windows.Forms.LinkLabel llCompleta;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox tbCpf;
		private System.Windows.Forms.ComboBox cbBairro;
		private System.Windows.Forms.MaskedTextBox mbCep;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel pnTaxaDeEntrega;
		private System.Windows.Forms.TextBox tbTaxaDeEntrega;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.LinkLabel llCadastroGrupos;
	}
}