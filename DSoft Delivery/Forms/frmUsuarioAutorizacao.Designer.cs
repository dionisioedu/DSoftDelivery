namespace DSoft_Delivery.Forms
{
	partial class frmUsuarioAutorizacao
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
			this.lbAutoriza = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.mbSenha = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbAutoriza
			// 
			this.lbAutoriza.AutoSize = true;
			this.lbAutoriza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAutoriza.Location = new System.Drawing.Point(12, 18);
			this.lbAutoriza.Name = "lbAutoriza";
			this.lbAutoriza.Size = new System.Drawing.Size(87, 18);
			this.lbAutoriza.TabIndex = 0;
			this.lbAutoriza.Text = "Autorização";
			// 
			// tbCodigo
			// 
			this.tbCodigo.Location = new System.Drawing.Point(12, 70);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// mbSenha
			// 
			this.mbSenha.Location = new System.Drawing.Point(118, 70);
			this.mbSenha.Name = "mbSenha";
			this.mbSenha.PasswordChar = '*';
			this.mbSenha.Size = new System.Drawing.Size(100, 20);
			this.mbSenha.TabIndex = 2;
			this.mbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbSenha_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Usuário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(118, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Senha";
			// 
			// btConfirmar
			// 
			this.btConfirmar.AutoSize = true;
			this.btConfirmar.Location = new System.Drawing.Point(224, 68);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(82, 23);
			this.btConfirmar.TabIndex = 5;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.AutoSize = true;
			this.btSair.Location = new System.Drawing.Point(312, 68);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 6;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(415, 24);
			this.menuStrip1.TabIndex = 7;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.menuToolStripMenuItem.Text = "Menu";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// frmUsuarioAutorizacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.ClientSize = new System.Drawing.Size(415, 118);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mbSenha);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.lbAutoriza);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmUsuarioAutorizacao";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmUsuarioAutorizacao";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbAutoriza;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.MaskedTextBox mbSenha;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
	}
}