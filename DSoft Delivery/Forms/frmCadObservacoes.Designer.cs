namespace DSoft_Delivery.Forms
{
	partial class frmCadObservacoes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadObservacoes));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbObs1 = new System.Windows.Forms.TextBox();
			this.tbObs2 = new System.Windows.Forms.TextBox();
			this.tbObs3 = new System.Windows.Forms.TextBox();
			this.tbObs4 = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.tbObs5 = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(284, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
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
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// tbObs1
			// 
			this.tbObs1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs1.Location = new System.Drawing.Point(31, 36);
			this.tbObs1.Name = "tbObs1";
			this.tbObs1.Size = new System.Drawing.Size(160, 20);
			this.tbObs1.TabIndex = 1;
			// 
			// tbObs2
			// 
			this.tbObs2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs2.Location = new System.Drawing.Point(31, 62);
			this.tbObs2.Name = "tbObs2";
			this.tbObs2.Size = new System.Drawing.Size(160, 20);
			this.tbObs2.TabIndex = 2;
			// 
			// tbObs3
			// 
			this.tbObs3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs3.Location = new System.Drawing.Point(31, 88);
			this.tbObs3.Name = "tbObs3";
			this.tbObs3.Size = new System.Drawing.Size(160, 20);
			this.tbObs3.TabIndex = 3;
			// 
			// tbObs4
			// 
			this.tbObs4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs4.Location = new System.Drawing.Point(31, 114);
			this.tbObs4.Name = "tbObs4";
			this.tbObs4.Size = new System.Drawing.Size(160, 20);
			this.tbObs4.TabIndex = 4;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(91, 185);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(88, 23);
			this.btConfirmar.TabIndex = 5;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(185, 185);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 6;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// tbObs5
			// 
			this.tbObs5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs5.Location = new System.Drawing.Point(31, 140);
			this.tbObs5.Name = "tbObs5";
			this.tbObs5.Size = new System.Drawing.Size(160, 20);
			this.tbObs5.TabIndex = 7;
			// 
			// frmCadObservacoes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(272, 220);
			this.Controls.Add(this.tbObs5);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbObs4);
			this.Controls.Add(this.tbObs3);
			this.Controls.Add(this.tbObs2);
			this.Controls.Add(this.tbObs1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCadObservacoes";
			this.Text = "Cadastro de observações";
			this.Load += new System.EventHandler(this.frmCadObservacoes_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCadObservacoes_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbObs1;
		private System.Windows.Forms.TextBox tbObs2;
		private System.Windows.Forms.TextBox tbObs3;
		private System.Windows.Forms.TextBox tbObs4;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbObs5;
	}
}