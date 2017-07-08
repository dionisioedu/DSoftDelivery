namespace DSoftForms
{
	partial class LancarSaida
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbCaixa = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbObs = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSenha = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.lbMensagem = new System.Windows.Forms.Label();
			this.lbMensagemObs = new System.Windows.Forms.Label();
			this.confirmButton1 = new DSoftCore.Controls.ConfirmButton();
			this.cancelButton1 = new DSoftCore.Controls.CancelButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DSoftForms.Properties.Resources._1440629671_banknotes;
			this.pictureBox1.Location = new System.Drawing.Point(12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(127, 129);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(501, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
			this.confirmarToolStripMenuItem.Text = "Confirmar";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem1.Text = "Confirmar";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbCaixa
			// 
			this.cbCaixa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCaixa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCaixa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCaixa.FormattingEnabled = true;
			this.cbCaixa.Location = new System.Drawing.Point(145, 38);
			this.cbCaixa.Name = "cbCaixa";
			this.cbCaixa.Size = new System.Drawing.Size(121, 21);
			this.cbCaixa.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(145, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Caixa";
			// 
			// tbValor
			// 
			this.tbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbValor.Location = new System.Drawing.Point(389, 34);
			this.tbValor.Name = "tbValor";
			this.tbValor.Size = new System.Drawing.Size(100, 24);
			this.tbValor.TabIndex = 0;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(362, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "R$";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(386, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Valor";
			// 
			// tbObs
			// 
			this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs.Location = new System.Drawing.Point(145, 85);
			this.tbObs.Multiline = true;
			this.tbObs.Name = "tbObs";
			this.tbObs.Size = new System.Drawing.Size(344, 56);
			this.tbObs.TabIndex = 1;
			this.tbObs.TextChanged += new System.EventHandler(this.tbObs_TextChanged);
			this.tbObs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbObs_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(145, 69);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Observação";
			// 
			// tbSenha
			// 
			this.tbSenha.Location = new System.Drawing.Point(145, 228);
			this.tbSenha.Name = "tbSenha";
			this.tbSenha.PasswordChar = '*';
			this.tbSenha.Size = new System.Drawing.Size(100, 20);
			this.tbSenha.TabIndex = 3;
			this.tbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(142, 212);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 16;
			this.label5.Text = "Senha";
			// 
			// tbUsuario
			// 
			this.tbUsuario.BackColor = System.Drawing.Color.White;
			this.tbUsuario.Location = new System.Drawing.Point(145, 189);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 2;
			this.tbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUsuario_KeyPress);
			this.tbUsuario.Leave += new System.EventHandler(this.tbUsuario_Leave);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(142, 173);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(43, 13);
			this.label6.TabIndex = 13;
			this.label6.Text = "Usuário";
			// 
			// lbUsuario
			// 
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbUsuario.Location = new System.Drawing.Point(251, 192);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(43, 13);
			this.lbUsuario.TabIndex = 17;
			this.lbUsuario.Text = "Usuário";
			// 
			// lbMensagem
			// 
			this.lbMensagem.AutoSize = true;
			this.lbMensagem.ForeColor = System.Drawing.Color.Red;
			this.lbMensagem.Location = new System.Drawing.Point(251, 231);
			this.lbMensagem.Name = "lbMensagem";
			this.lbMensagem.Size = new System.Drawing.Size(0, 13);
			this.lbMensagem.TabIndex = 18;
			// 
			// lbMensagemObs
			// 
			this.lbMensagemObs.AutoSize = true;
			this.lbMensagemObs.ForeColor = System.Drawing.Color.Red;
			this.lbMensagemObs.Location = new System.Drawing.Point(216, 69);
			this.lbMensagemObs.Name = "lbMensagemObs";
			this.lbMensagemObs.Size = new System.Drawing.Size(0, 13);
			this.lbMensagemObs.TabIndex = 19;
			// 
			// confirmButton1
			// 
			this.confirmButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.confirmButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.confirmButton1.Location = new System.Drawing.Point(203, 292);
			this.confirmButton1.Name = "confirmButton1";
			this.confirmButton1.Size = new System.Drawing.Size(140, 60);
			this.confirmButton1.TabIndex = 4;
			// 
			// cancelButton1
			// 
			this.cancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cancelButton1.Location = new System.Drawing.Point(349, 292);
			this.cancelButton1.Name = "cancelButton1";
			this.cancelButton1.Size = new System.Drawing.Size(140, 60);
			this.cancelButton1.TabIndex = 5;
			// 
			// LancarSaida
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 364);
			this.ControlBox = false;
			this.Controls.Add(this.lbMensagemObs);
			this.Controls.Add(this.lbMensagem);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.tbSenha);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbObs);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbCaixa);
			this.Controls.Add(this.confirmButton1);
			this.Controls.Add(this.cancelButton1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "LancarSaida";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Lançamento de saída";
			this.Load += new System.EventHandler(this.LancarSaida_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private DSoftCore.Controls.CancelButton cancelButton1;
		private DSoftCore.Controls.ConfirmButton confirmButton1;
		private System.Windows.Forms.ComboBox cbCaixa;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbObs;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox tbSenha;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label lbMensagem;
		private System.Windows.Forms.Label lbMensagemObs;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
	}
}