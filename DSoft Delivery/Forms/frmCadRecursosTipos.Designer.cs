namespace DSoft_Delivery
{
	partial class frmCadRecursosTipos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadRecursosTipos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listagemDeTiposDeRecursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.tbDiaria = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbValorEntrega = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbFixoMensal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbFixoSemanal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbComNom = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbComDia = new System.Windows.Forms.TextBox();
			this.cbProducao = new System.Windows.Forms.CheckBox();
			this.cbEntrega = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(594, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem2.Text = "&Confirmar";
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
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listagemDeTiposDeRecursosToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// listagemDeTiposDeRecursosToolStripMenuItem
			// 
			this.listagemDeTiposDeRecursosToolStripMenuItem.Name = "listagemDeTiposDeRecursosToolStripMenuItem";
			this.listagemDeTiposDeRecursosToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
			this.listagemDeTiposDeRecursosToolStripMenuItem.Text = "Listagem de tipos de recursos";
			this.listagemDeTiposDeRecursosToolStripMenuItem.Click += new System.EventHandler(this.listagemDeTiposDeRecursosToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 241);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(570, 122);
			this.dataGridView1.TabIndex = 13;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Código";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(9, 32);
			this.tbCodigo.MaxLength = 1;
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.tbDiaria);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.label12);
			this.groupBox1.Controls.Add(this.tbValorEntrega);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tbFixoMensal);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.tbFixoSemanal);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.tbComNom);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbComDia);
			this.groupBox1.Controls.Add(this.cbProducao);
			this.groupBox1.Controls.Add(this.cbEntrega);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbDescricao);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tbCodigo);
			this.groupBox1.Location = new System.Drawing.Point(12, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(570, 157);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 134);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(21, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "R$";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(30, 115);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(34, 13);
			this.label14.TabIndex = 24;
			this.label14.Text = "Diária";
			// 
			// tbDiaria
			// 
			this.tbDiaria.Location = new System.Drawing.Point(33, 131);
			this.tbDiaria.Name = "tbDiaria";
			this.tbDiaria.Size = new System.Drawing.Size(100, 20);
			this.tbDiaria.TabIndex = 6;
			this.tbDiaria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDiaria_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(415, 134);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(21, 13);
			this.label11.TabIndex = 22;
			this.label11.Text = "R$";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(439, 115);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(88, 13);
			this.label12.TabIndex = 20;
			this.label12.Text = "Valor por entrega";
			// 
			// tbValorEntrega
			// 
			this.tbValorEntrega.Location = new System.Drawing.Point(442, 131);
			this.tbValorEntrega.Name = "tbValorEntrega";
			this.tbValorEntrega.Size = new System.Drawing.Size(100, 20);
			this.tbValorEntrega.TabIndex = 9;
			this.tbValorEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox7_KeyPress);
			this.tbValorEntrega.Leave += new System.EventHandler(this.textBox7_Leave);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(278, 134);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(21, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "R$";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(302, 115);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Fixo Mensal";
			// 
			// tbFixoMensal
			// 
			this.tbFixoMensal.Location = new System.Drawing.Point(305, 131);
			this.tbFixoMensal.Name = "tbFixoMensal";
			this.tbFixoMensal.Size = new System.Drawing.Size(100, 20);
			this.tbFixoMensal.TabIndex = 8;
			this.tbFixoMensal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
			this.tbFixoMensal.Leave += new System.EventHandler(this.textBox6_Leave);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(144, 134);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(21, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "R$";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(168, 115);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(70, 13);
			this.label8.TabIndex = 14;
			this.label8.Text = "Fixo Semanal";
			// 
			// tbFixoSemanal
			// 
			this.tbFixoSemanal.Location = new System.Drawing.Point(171, 131);
			this.tbFixoSemanal.Name = "tbFixoSemanal";
			this.tbFixoSemanal.Size = new System.Drawing.Size(100, 20);
			this.tbFixoSemanal.TabIndex = 7;
			this.tbFixoSemanal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
			this.tbFixoSemanal.Leave += new System.EventHandler(this.textBox5_Leave);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(498, 86);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "%";
			this.label5.Visible = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(439, 67);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(93, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "Comissão Nominal";
			this.label6.Visible = false;
			// 
			// tbComNom
			// 
			this.tbComNom.Location = new System.Drawing.Point(442, 83);
			this.tbComNom.Name = "tbComNom";
			this.tbComNom.Size = new System.Drawing.Size(50, 20);
			this.tbComNom.TabIndex = 5;
			this.tbComNom.Visible = false;
			this.tbComNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
			this.tbComNom.Leave += new System.EventHandler(this.textBox4_Leave);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(392, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(15, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "%";
			this.label4.Visible = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(333, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(82, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Comissão Diária";
			this.label3.Visible = false;
			// 
			// tbComDia
			// 
			this.tbComDia.Location = new System.Drawing.Point(336, 83);
			this.tbComDia.Name = "tbComDia";
			this.tbComDia.Size = new System.Drawing.Size(50, 20);
			this.tbComDia.TabIndex = 4;
			this.tbComDia.Visible = false;
			this.tbComDia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
			this.tbComDia.Leave += new System.EventHandler(this.textBox3_Leave);
			// 
			// cbProducao
			// 
			this.cbProducao.AutoSize = true;
			this.cbProducao.Location = new System.Drawing.Point(418, 34);
			this.cbProducao.Name = "cbProducao";
			this.cbProducao.Size = new System.Drawing.Size(72, 17);
			this.cbProducao.TabIndex = 3;
			this.cbProducao.Text = "Produção";
			this.cbProducao.UseVisualStyleBackColor = true;
			this.cbProducao.Enter += new System.EventHandler(this.checkBox2_Enter);
			this.cbProducao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkBox2_KeyPress);
			this.cbProducao.Leave += new System.EventHandler(this.checkBox2_Leave);
			// 
			// cbEntrega
			// 
			this.cbEntrega.AutoSize = true;
			this.cbEntrega.Location = new System.Drawing.Point(336, 34);
			this.cbEntrega.Name = "cbEntrega";
			this.cbEntrega.Size = new System.Drawing.Size(63, 17);
			this.cbEntrega.TabIndex = 2;
			this.cbEntrega.Text = "Entrega";
			this.cbEntrega.UseVisualStyleBackColor = true;
			this.cbEntrega.Enter += new System.EventHandler(this.checkBox1_Enter);
			this.cbEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkBox1_KeyPress);
			this.cbEntrega.Leave += new System.EventHandler(this.checkBox1_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Descrição";
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(115, 32);
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.Size = new System.Drawing.Size(197, 20);
			this.tbDescricao.TabIndex = 1;
			this.tbDescricao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(201, 190);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 10;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btLimpar.Location = new System.Drawing.Point(330, 190);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(123, 45);
			this.btLimpar.TabIndex = 11;
			this.btLimpar.Text = "&Limpar Dados";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.button2_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(459, 190);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 12;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button3_Click);
			// 
			// frmCadRecursosTipos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 375);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCadRecursosTipos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de tipos de funcionários";
			this.Load += new System.EventHandler(this.frmCadRecursosTipos_Load);
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
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbComDia;
		private System.Windows.Forms.CheckBox cbProducao;
		private System.Windows.Forms.CheckBox cbEntrega;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbFixoSemanal;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbComNom;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbValorEntrega;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbFixoMensal;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemDeTiposDeRecursosToolStripMenuItem;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbDiaria;
	}
}