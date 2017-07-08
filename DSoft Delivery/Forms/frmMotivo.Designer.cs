namespace DSoft_Delivery.Forms
{
	partial class frmMotivo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotivo));
			this.tbMotivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.motivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.siarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbErro = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbMotivo
			// 
			this.tbMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbMotivo.Location = new System.Drawing.Point(12, 70);
			this.tbMotivo.Name = "tbMotivo";
			this.tbMotivo.Size = new System.Drawing.Size(479, 20);
			this.tbMotivo.TabIndex = 0;
			this.tbMotivo.TextChanged += new System.EventHandler(this.tbMotivo_TextChanged);
			this.tbMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMotivo_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 54);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Digite o motivo:";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(335, 121);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 2;
			this.btConfirmar.Text = "&Confirma F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(416, 121);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 3;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.motivoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(503, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// motivoToolStripMenuItem
			// 
			this.motivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.siarToolStripMenuItem});
			this.motivoToolStripMenuItem.Name = "motivoToolStripMenuItem";
			this.motivoToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
			this.motivoToolStripMenuItem.Text = "Motivo";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.confirmarToolStripMenuItem.Text = "Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// siarToolStripMenuItem
			// 
			this.siarToolStripMenuItem.Name = "siarToolStripMenuItem";
			this.siarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.siarToolStripMenuItem.Text = "Sair";
			this.siarToolStripMenuItem.Click += new System.EventHandler(this.siarToolStripMenuItem_Click);
			// 
			// lbErro
			// 
			this.lbErro.AutoSize = true;
			this.lbErro.ForeColor = System.Drawing.Color.Red;
			this.lbErro.Location = new System.Drawing.Point(12, 93);
			this.lbErro.Name = "lbErro";
			this.lbErro.Size = new System.Drawing.Size(0, 13);
			this.lbErro.TabIndex = 5;
			// 
			// frmMotivo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(503, 156);
			this.Controls.Add(this.lbErro);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbMotivo);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMotivo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Motivo";
			this.Load += new System.EventHandler(this.frmMotivo_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbMotivo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem motivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem siarToolStripMenuItem;
		private System.Windows.Forms.Label lbErro;
	}
}