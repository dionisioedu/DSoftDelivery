namespace DSoft_Delivery
{
	partial class frmFechamento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFechamento));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fechamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCaixa = new System.Windows.Forms.TextBox();
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.dtData = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.lbCaixa = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSenha = new System.Windows.Forms.MaskedTextBox();
			this.tbTicket = new System.Windows.Forms.TextBox();
			this.cbSaida = new System.Windows.Forms.CheckBox();
			this.cbReducaoZ = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbSaldo = new System.Windows.Forms.TextBox();
			this.lbAviso = new System.Windows.Forms.Label();
			this.cbBackup = new System.Windows.Forms.CheckBox();
			this.quitButton1 = new DSoftCore.Controls.QuitButton();
			this.confirmButton1 = new DSoftCore.Controls.ConfirmButton();
			this.printLittleButton1 = new DSoftCore.Controls.PrintLittleButton();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fechamentoToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(697, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fechamentoToolStripMenuItem
			// 
			this.fechamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.fechamentoToolStripMenuItem.Name = "fechamentoToolStripMenuItem";
			this.fechamentoToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
			this.fechamentoToolStripMenuItem.Text = "&Fechamento";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Enabled = false;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(234, 22);
			this.toolStripMenuItem2.Text = "Desfazer Fechamento de Caixa";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(234, 22);
			this.toolStripMenuItem3.Text = "Desfazer Fechamento Diário";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(231, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(29, 101);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Caixa";
			// 
			// tbCaixa
			// 
			this.tbCaixa.BackColor = System.Drawing.Color.White;
			this.tbCaixa.Location = new System.Drawing.Point(32, 117);
			this.tbCaixa.Name = "tbCaixa";
			this.tbCaixa.ReadOnly = true;
			this.tbCaixa.Size = new System.Drawing.Size(100, 20);
			this.tbCaixa.TabIndex = 4;
			// 
			// tbUsuario
			// 
			this.tbUsuario.BackColor = System.Drawing.Color.White;
			this.tbUsuario.Location = new System.Drawing.Point(32, 294);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.ReadOnly = true;
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 278);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Usuário";
			// 
			// dtData
			// 
			this.dtData.Enabled = false;
			this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtData.Location = new System.Drawing.Point(32, 59);
			this.dtData.Name = "dtData";
			this.dtData.Size = new System.Drawing.Size(100, 20);
			this.dtData.TabIndex = 5;
			this.dtData.ValueChanged += new System.EventHandler(this.dtData_ValueChanged);
			this.dtData.Leave += new System.EventHandler(this.dtData_Leave);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(29, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Data";
			// 
			// lbCaixa
			// 
			this.lbCaixa.AutoSize = true;
			this.lbCaixa.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbCaixa.Location = new System.Drawing.Point(138, 120);
			this.lbCaixa.Name = "lbCaixa";
			this.lbCaixa.Size = new System.Drawing.Size(47, 13);
			this.lbCaixa.TabIndex = 9;
			this.lbCaixa.Text = "Principal";
			// 
			// lbUsuario
			// 
			this.lbUsuario.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbUsuario.Location = new System.Drawing.Point(138, 297);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(133, 13);
			this.lbUsuario.TabIndex = 10;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(29, 317);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Senha";
			// 
			// tbSenha
			// 
			this.tbSenha.Location = new System.Drawing.Point(32, 333);
			this.tbSenha.Name = "tbSenha";
			this.tbSenha.PasswordChar = '*';
			this.tbSenha.Size = new System.Drawing.Size(100, 20);
			this.tbSenha.TabIndex = 0;
			this.tbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
			// 
			// tbTicket
			// 
			this.tbTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.tbTicket.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTicket.Location = new System.Drawing.Point(304, 59);
			this.tbTicket.Multiline = true;
			this.tbTicket.Name = "tbTicket";
			this.tbTicket.ReadOnly = true;
			this.tbTicket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbTicket.Size = new System.Drawing.Size(378, 329);
			this.tbTicket.TabIndex = 13;
			// 
			// cbSaida
			// 
			this.cbSaida.AutoSize = true;
			this.cbSaida.Checked = true;
			this.cbSaida.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSaida.Enabled = false;
			this.cbSaida.Location = new System.Drawing.Point(32, 194);
			this.cbSaida.Name = "cbSaida";
			this.cbSaida.Size = new System.Drawing.Size(89, 17);
			this.cbSaida.TabIndex = 15;
			this.cbSaida.Text = "Lançar saída";
			this.cbSaida.UseVisualStyleBackColor = true;
			// 
			// cbReducaoZ
			// 
			this.cbReducaoZ.AutoSize = true;
			this.cbReducaoZ.Enabled = false;
			this.cbReducaoZ.Location = new System.Drawing.Point(32, 217);
			this.cbReducaoZ.Name = "cbReducaoZ";
			this.cbReducaoZ.Size = new System.Drawing.Size(80, 17);
			this.cbReducaoZ.TabIndex = 16;
			this.cbReducaoZ.Text = "Redução Z";
			this.cbReducaoZ.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 159);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(21, 13);
			this.label5.TabIndex = 17;
			this.label5.Text = "R$";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(29, 140);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Saldo";
			// 
			// tbSaldo
			// 
			this.tbSaldo.Location = new System.Drawing.Point(32, 156);
			this.tbSaldo.Name = "tbSaldo";
			this.tbSaldo.Size = new System.Drawing.Size(100, 20);
			this.tbSaldo.TabIndex = 19;
			this.tbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbSaldo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSaldo_KeyDown);
			// 
			// lbAviso
			// 
			this.lbAviso.AutoSize = true;
			this.lbAviso.ForeColor = System.Drawing.Color.Red;
			this.lbAviso.Location = new System.Drawing.Point(301, 43);
			this.lbAviso.Name = "lbAviso";
			this.lbAviso.Size = new System.Drawing.Size(0, 13);
			this.lbAviso.TabIndex = 20;
			// 
			// cbBackup
			// 
			this.cbBackup.AutoSize = true;
			this.cbBackup.Enabled = false;
			this.cbBackup.Location = new System.Drawing.Point(32, 240);
			this.cbBackup.Name = "cbBackup";
			this.cbBackup.Size = new System.Drawing.Size(63, 17);
			this.cbBackup.TabIndex = 21;
			this.cbBackup.Text = "Backup";
			this.cbBackup.UseVisualStyleBackColor = true;
			this.cbBackup.CheckedChanged += new System.EventHandler(this.cbBackup_CheckedChanged);
			// 
			// quitButton1
			// 
			this.quitButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.quitButton1.Location = new System.Drawing.Point(158, 374);
			this.quitButton1.Name = "quitButton1";
			this.quitButton1.Size = new System.Drawing.Size(140, 60);
			this.quitButton1.TabIndex = 22;
			// 
			// confirmButton1
			// 
			this.confirmButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.confirmButton1.Location = new System.Drawing.Point(12, 374);
			this.confirmButton1.Name = "confirmButton1";
			this.confirmButton1.Size = new System.Drawing.Size(140, 60);
			this.confirmButton1.TabIndex = 23;
			// 
			// printLittleButton1
			// 
			this.printLittleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.printLittleButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.printLittleButton1.Location = new System.Drawing.Point(304, 394);
			this.printLittleButton1.Name = "printLittleButton1";
			this.printLittleButton1.Size = new System.Drawing.Size(140, 40);
			this.printLittleButton1.TabIndex = 24;
			// 
			// frmFechamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(697, 446);
			this.Controls.Add(this.printLittleButton1);
			this.Controls.Add(this.confirmButton1);
			this.Controls.Add(this.quitButton1);
			this.Controls.Add(this.cbBackup);
			this.Controls.Add(this.lbAviso);
			this.Controls.Add(this.tbSaldo);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cbReducaoZ);
			this.Controls.Add(this.cbSaida);
			this.Controls.Add(this.tbTicket);
			this.Controls.Add(this.tbSenha);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.lbCaixa);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtData);
			this.Controls.Add(this.tbCaixa);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(683, 485);
			this.Name = "frmFechamento";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fechamento de Caixa";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFechamento_FormClosing);
			this.Load += new System.EventHandler(this.frmFechamento_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fechamentoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCaixa;
		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dtData;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbCaixa;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox tbSenha;
		private System.Windows.Forms.TextBox tbTicket;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.CheckBox cbSaida;
		private System.Windows.Forms.CheckBox cbReducaoZ;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbSaldo;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.Label lbAviso;
		private System.Windows.Forms.CheckBox cbBackup;
		private DSoftCore.Controls.QuitButton quitButton1;
		private DSoftCore.Controls.ConfirmButton confirmButton1;
		private DSoftCore.Controls.PrintLittleButton printLittleButton1;
	}
}