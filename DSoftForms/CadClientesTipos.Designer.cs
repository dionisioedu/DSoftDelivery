namespace DSoft_Delivery
{
	partial class CadClientesTipos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadClientesTipos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listagemDeTiposDeClietnesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btSair = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgTipos = new System.Windows.Forms.DataGridView();
			this.cbInterno = new System.Windows.Forms.CheckBox();
			this.cbMensalidade = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTipos)).BeginInit();
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
            this.confirmarToolStripMenuItem,
            this.cancelarToolStripMenuItem,
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
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.cancelarToolStripMenuItem.Text = "C&ancelar";
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
            this.listagemDeTiposDeClietnesToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// listagemDeTiposDeClietnesToolStripMenuItem
			// 
			this.listagemDeTiposDeClietnesToolStripMenuItem.Name = "listagemDeTiposDeClietnesToolStripMenuItem";
			this.listagemDeTiposDeClietnesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.listagemDeTiposDeClietnesToolStripMenuItem.Text = "Listagem de tipos de clientes";
			this.listagemDeTiposDeClietnesToolStripMenuItem.Click += new System.EventHandler(this.listagemDeTiposDeClietnesToolStripMenuItem_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.AutoSize = true;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(407, 74);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 6;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button3_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.AutoSize = true;
			this.btCancelar.Enabled = false;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(100, 74);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(80, 23);
			this.btCancelar.TabIndex = 5;
			this.btCancelar.Text = "Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			// 
			// btConfirmar
			// 
			this.btConfirmar.AutoSize = true;
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(12, 74);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(82, 23);
			this.btConfirmar.TabIndex = 4;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(68, 48);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(200, 20);
			this.tbNome.TabIndex = 1;
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNome_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(65, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Nome";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(12, 48);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(50, 20);
			this.tbCodigo.TabIndex = 0;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Código";
			// 
			// dgTipos
			// 
			this.dgTipos.AllowUserToAddRows = false;
			this.dgTipos.AllowUserToDeleteRows = false;
			this.dgTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgTipos.Location = new System.Drawing.Point(12, 103);
			this.dgTipos.Name = "dgTipos";
			this.dgTipos.ReadOnly = true;
			this.dgTipos.RowHeadersWidth = 18;
			this.dgTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgTipos.Size = new System.Drawing.Size(470, 200);
			this.dgTipos.TabIndex = 7;
			this.dgTipos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// cbInterno
			// 
			this.cbInterno.AutoSize = true;
			this.cbInterno.Location = new System.Drawing.Point(274, 50);
			this.cbInterno.Name = "cbInterno";
			this.cbInterno.Size = new System.Drawing.Size(93, 17);
			this.cbInterno.TabIndex = 2;
			this.cbInterno.Text = "Cliente interno";
			this.cbInterno.UseVisualStyleBackColor = true;
			this.cbInterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbInterno_KeyDown);
			// 
			// cbMensalidade
			// 
			this.cbMensalidade.AutoSize = true;
			this.cbMensalidade.Location = new System.Drawing.Point(373, 50);
			this.cbMensalidade.Name = "cbMensalidade";
			this.cbMensalidade.Size = new System.Drawing.Size(110, 17);
			this.cbMensalidade.TabIndex = 3;
			this.cbMensalidade.Text = "Cliente mensalista";
			this.cbMensalidade.UseVisualStyleBackColor = true;
			this.cbMensalidade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMensalidade_KeyDown);
			// 
			// frmCadClientesTipos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 315);
			this.Controls.Add(this.cbMensalidade);
			this.Controls.Add(this.cbInterno);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgTipos);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmCadClientesTipos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Tipos de Clientes";
			this.Load += new System.EventHandler(this.frmCadClientesTipos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgTipos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgTipos;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listagemDeTiposDeClietnesToolStripMenuItem;
		private System.Windows.Forms.CheckBox cbInterno;
		private System.Windows.Forms.CheckBox cbMensalidade;
	}
}