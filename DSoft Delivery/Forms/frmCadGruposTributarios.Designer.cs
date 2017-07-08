namespace DSoft_Delivery
{
	partial class frmCadGruposTributarios
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadGruposTributarios));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.incluirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbIpi = new System.Windows.Forms.TextBox();
			this.tbIcms = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btConfimar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbCofins = new System.Windows.Forms.TextBox();
			this.tbPis = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.tbIrrf = new System.Windows.Forms.TextBox();
			this.tbCsll = new System.Windows.Forms.TextBox();
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
			this.incluirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.incluirToolStripMenuItem.Text = "&Incluir";
			this.incluirToolStripMenuItem.Click += new System.EventHandler(this.incluirToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.cancelarToolStripMenuItem.Text = "&Cancelar";
			this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(136, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 163);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(470, 300);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Enabled = false;
			this.tbCodigo.Location = new System.Drawing.Point(12, 47);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 2;
			this.tbCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCodigo_KeyPress);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Enabled = false;
			this.tbNome.Location = new System.Drawing.Point(118, 47);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(329, 20);
			this.tbNome.TabIndex = 3;
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNome_KeyPress);
			// 
			// tbIpi
			// 
			this.tbIpi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbIpi.Enabled = false;
			this.tbIpi.Location = new System.Drawing.Point(12, 86);
			this.tbIpi.Name = "tbIpi";
			this.tbIpi.Size = new System.Drawing.Size(50, 20);
			this.tbIpi.TabIndex = 4;
			this.tbIpi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIpi_KeyPress);
			// 
			// tbIcms
			// 
			this.tbIcms.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbIcms.Enabled = false;
			this.tbIcms.Location = new System.Drawing.Point(89, 86);
			this.tbIcms.Name = "tbIcms";
			this.tbIcms.Size = new System.Drawing.Size(50, 20);
			this.tbIcms.TabIndex = 5;
			this.tbIcms.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIcms_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(118, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Nome";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "IPI";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(86, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(33, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "ICMS";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(68, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(15, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "%";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(145, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(15, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "%";
			// 
			// btConfimar
			// 
			this.btConfimar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfimar.Location = new System.Drawing.Point(12, 112);
			this.btConfimar.Name = "btConfimar";
			this.btConfimar.Size = new System.Drawing.Size(123, 45);
			this.btConfimar.TabIndex = 10;
			this.btConfimar.Text = "&Incluir - F2";
			this.btConfimar.UseVisualStyleBackColor = true;
			this.btConfimar.Click += new System.EventHandler(this.btConfimar_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(141, 112);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 11;
			this.btCancelar.Text = "&Cancelar - F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(359, 112);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 12;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(299, 89);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(15, 13);
			this.label7.TabIndex = 21;
			this.label7.Text = "%";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(222, 89);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(15, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "%";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(240, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(46, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "COFINS";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(166, 70);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(24, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "PIS";
			// 
			// tbCofins
			// 
			this.tbCofins.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCofins.Enabled = false;
			this.tbCofins.Location = new System.Drawing.Point(243, 86);
			this.tbCofins.Name = "tbCofins";
			this.tbCofins.Size = new System.Drawing.Size(50, 20);
			this.tbCofins.TabIndex = 7;
			this.tbCofins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCofins_KeyPress);
			// 
			// tbPis
			// 
			this.tbPis.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPis.Enabled = false;
			this.tbPis.Location = new System.Drawing.Point(166, 86);
			this.tbPis.Name = "tbPis";
			this.tbPis.Size = new System.Drawing.Size(50, 20);
			this.tbPis.TabIndex = 6;
			this.tbPis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPis_KeyPress);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(453, 89);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(15, 13);
			this.label11.TabIndex = 27;
			this.label11.Text = "%";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(376, 89);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(15, 13);
			this.label12.TabIndex = 26;
			this.label12.Text = "%";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(394, 70);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(32, 13);
			this.label13.TabIndex = 25;
			this.label13.Text = "IRRF";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(320, 70);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(33, 13);
			this.label14.TabIndex = 24;
			this.label14.Text = "CSLL";
			// 
			// tbIrrf
			// 
			this.tbIrrf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbIrrf.Enabled = false;
			this.tbIrrf.Location = new System.Drawing.Point(397, 86);
			this.tbIrrf.Name = "tbIrrf";
			this.tbIrrf.Size = new System.Drawing.Size(50, 20);
			this.tbIrrf.TabIndex = 9;
			this.tbIrrf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIrrf_KeyPress);
			// 
			// tbCsll
			// 
			this.tbCsll.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCsll.Enabled = false;
			this.tbCsll.Location = new System.Drawing.Point(320, 86);
			this.tbCsll.Name = "tbCsll";
			this.tbCsll.Size = new System.Drawing.Size(50, 20);
			this.tbCsll.TabIndex = 8;
			this.tbCsll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCsll_KeyPress);
			// 
			// frmCadGruposTributarios
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(494, 475);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbIrrf);
			this.Controls.Add(this.tbCsll);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbCofins);
			this.Controls.Add(this.tbPis);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfimar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbIcms);
			this.Controls.Add(this.tbIpi);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCadGruposTributarios";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cadastro de Grupos Tributários";
			this.Load += new System.EventHandler(this.frmCadGruposTributarios_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbIpi;
		private System.Windows.Forms.TextBox tbIcms;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btConfimar;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbCofins;
		private System.Windows.Forms.TextBox tbPis;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbIrrf;
		private System.Windows.Forms.TextBox tbCsll;
	}
}