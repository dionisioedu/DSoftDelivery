namespace DSoft_Delivery
{
	partial class CadClientesGrupos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadClientesGrupos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listagemDosGruposDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dgGrupos = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.tbTaxa = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbCidade = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbEstado = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbServico = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgGrupos)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(494, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incluirToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			// 
			// incluirToolStripMenuItem
			// 
			this.incluirToolStripMenuItem.Name = "incluirToolStripMenuItem";
			this.incluirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.incluirToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.incluirToolStripMenuItem.Text = "&Confirmar";
			this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.cancelarToolStripMenuItem.Text = "Cancelar";
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
            this.listagemDosGruposDeClientesToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// listagemDosGruposDeClientesToolStripMenuItem
			// 
			this.listagemDosGruposDeClientesToolStripMenuItem.Name = "listagemDosGruposDeClientesToolStripMenuItem";
			this.listagemDosGruposDeClientesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
			this.listagemDosGruposDeClientesToolStripMenuItem.Text = "Listagem dos grupos de clientes";
			this.listagemDosGruposDeClientesToolStripMenuItem.Click += new System.EventHandler(this.listagemDosGruposDeClientesToolStripMenuItem_Click);
			// 
			// dgGrupos
			// 
			this.dgGrupos.AllowUserToAddRows = false;
			this.dgGrupos.AllowUserToDeleteRows = false;
			this.dgGrupos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			this.dgGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgGrupos.Location = new System.Drawing.Point(12, 164);
			this.dgGrupos.Name = "dgGrupos";
			this.dgGrupos.ReadOnly = true;
			this.dgGrupos.RowHeadersWidth = 18;
			this.dgGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgGrupos.Size = new System.Drawing.Size(470, 260);
			this.dgGrupos.TabIndex = 20;
			this.dgGrupos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgGrupos_CellDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Código";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(12, 48);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(60, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(78, 48);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(180, 20);
			this.tbNome.TabIndex = 1;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(75, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nome";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(12, 113);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 10;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(141, 113);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 11;
			this.btCancelar.Text = "Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(359, 113);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 12;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button3_Click);
			// 
			// tbTaxa
			// 
			this.tbTaxa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTaxa.Location = new System.Drawing.Point(294, 48);
			this.tbTaxa.Name = "tbTaxa";
			this.tbTaxa.Size = new System.Drawing.Size(60, 20);
			this.tbTaxa.TabIndex = 2;
			this.tbTaxa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTaxa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTaxa_KeyDown);
			this.tbTaxa.Leave += new System.EventHandler(this.tbTaxa_Leave);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(291, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Entrega";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(267, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "R$";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(215, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Estado";
			// 
			// tbCidade
			// 
			this.tbCidade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCidade.Location = new System.Drawing.Point(12, 87);
			this.tbCidade.Name = "tbCidade";
			this.tbCidade.Size = new System.Drawing.Size(200, 20);
			this.tbCidade.TabIndex = 4;
			this.tbCidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCidade_KeyDown);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(9, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Cidade";
			// 
			// cbEstado
			// 
			this.cbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbEstado.FormattingEnabled = true;
			this.cbEstado.Location = new System.Drawing.Point(218, 87);
			this.cbEstado.Name = "cbEstado";
			this.cbEstado.Size = new System.Drawing.Size(200, 21);
			this.cbEstado.TabIndex = 5;
			this.cbEstado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbEstado_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(426, 51);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(15, 13);
			this.label7.TabIndex = 18;
			this.label7.Text = "%";
			// 
			// tbServico
			// 
			this.tbServico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbServico.Location = new System.Drawing.Point(360, 48);
			this.tbServico.Name = "tbServico";
			this.tbServico.Size = new System.Drawing.Size(60, 20);
			this.tbServico.TabIndex = 3;
			this.tbServico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbServico.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbServico_KeyDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(357, 32);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(43, 13);
			this.label8.TabIndex = 17;
			this.label8.Text = "Serviço";
			// 
			// frmCadClientesGrupos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 436);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbServico);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cbEstado);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbCidade);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbTaxa);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgGrupos);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCadClientesGrupos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Grupos de Clientes";
			this.Load += new System.EventHandler(this.frmCadClientesGrupos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgGrupos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem incluirToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dgGrupos;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listagemDosGruposDeClientesToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTaxa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbCidade;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbEstado;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbServico;
		private System.Windows.Forms.Label label8;
	}
}