namespace DSoft_Delivery
{
	partial class frmCapturaPonto2
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapturaPonto2));
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.tbSenha = new System.Windows.Forms.TextBox();
			this.dtData = new System.Windows.Forms.DateTimePicker();
			this.dtHora = new System.Windows.Forms.DateTimePicker();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.pontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbUsuario
			// 
			this.tbUsuario.Location = new System.Drawing.Point(30, 55);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 0;
			this.tbUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUsuario_KeyDown);
			this.tbUsuario.Leave += new System.EventHandler(this.tbUsuario_Leave);
			// 
			// tbSenha
			// 
			this.tbSenha.Location = new System.Drawing.Point(30, 94);
			this.tbSenha.Name = "tbSenha";
			this.tbSenha.PasswordChar = '*';
			this.tbSenha.Size = new System.Drawing.Size(100, 20);
			this.tbSenha.TabIndex = 1;
			this.tbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyDown);
			this.tbSenha.Leave += new System.EventHandler(this.tbSenha_Leave);
			// 
			// dtData
			// 
			this.dtData.Enabled = false;
			this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtData.Location = new System.Drawing.Point(226, 91);
			this.dtData.Name = "dtData";
			this.dtData.Size = new System.Drawing.Size(100, 20);
			this.dtData.TabIndex = 2;
			// 
			// dtHora
			// 
			this.dtHora.Enabled = false;
			this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtHora.Location = new System.Drawing.Point(332, 91);
			this.dtHora.Name = "dtHora";
			this.dtHora.Size = new System.Drawing.Size(100, 20);
			this.dtHora.TabIndex = 3;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(276, 141);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 4;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(357, 141);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 5;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Usuário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Senha";
			// 
			// cbTipo
			// 
			this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Items.AddRange(new object[] {
            "ENTRADA",
            "SAÍDA"});
			this.cbTipo.Location = new System.Drawing.Point(226, 54);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(100, 21);
			this.cbTipo.TabIndex = 8;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pontoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(444, 24);
			this.menuStrip1.TabIndex = 9;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// pontoToolStripMenuItem
			// 
			this.pontoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.pontoToolStripMenuItem.Name = "pontoToolStripMenuItem";
			this.pontoToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.pontoToolStripMenuItem.Text = "Ponto";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// frmCapturaPonto2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 176);
			this.Controls.Add(this.cbTipo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.dtHora);
			this.Controls.Add(this.dtData);
			this.Controls.Add(this.tbSenha);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCapturaPonto2";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Captura ponto";
			this.Load += new System.EventHandler(this.frmCapturaPonto2_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.TextBox tbSenha;
		private System.Windows.Forms.DateTimePicker dtData;
		private System.Windows.Forms.DateTimePicker dtHora;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem pontoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
	}
}