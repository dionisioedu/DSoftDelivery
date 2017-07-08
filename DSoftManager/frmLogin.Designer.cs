namespace DSoftManager
{
	partial class frmLogin
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.mbSenha = new System.Windows.Forms.MaskedTextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.pbFundo = new System.Windows.Forms.PictureBox();
			this.lbDemo = new System.Windows.Forms.Label();
			this.mbNovaSenha = new System.Windows.Forms.MaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.llAlterarSenha = new System.Windows.Forms.LinkLabel();
			this.llCancelar = new System.Windows.Forms.LinkLabel();
			this.lbUsuarioInvalido = new System.Windows.Forms.Label();
			this.lbSenhaInvalida = new System.Windows.Forms.Label();
			this.lbSenhasNaoConferem = new System.Windows.Forms.Label();
			this.mbConfirmacao = new System.Windows.Forms.MaskedTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.lbVersao = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbFundo)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(394, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// loginToolStripMenuItem
			// 
			this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
			this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
			this.loginToolStripMenuItem.Text = "&Login";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(31, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Usuário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(31, 133);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Senha";
			// 
			// tbUsuario
			// 
			this.tbUsuario.Location = new System.Drawing.Point(34, 110);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 0;
			this.tbUsuario.Enter += new System.EventHandler(this.textBox1_Enter);
			this.tbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// mbSenha
			// 
			this.mbSenha.Location = new System.Drawing.Point(34, 149);
			this.mbSenha.Name = "mbSenha";
			this.mbSenha.PasswordChar = '*';
			this.mbSenha.Size = new System.Drawing.Size(100, 20);
			this.mbSenha.TabIndex = 1;
			this.mbSenha.Enter += new System.EventHandler(this.maskedTextBox1_Enter);
			this.mbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(130, 234);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 4;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(259, 234);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 5;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button2_Click);
			// 
			// pbFundo
			// 
			this.pbFundo.Image = ((System.Drawing.Image)(resources.GetObject("pbFundo.Image")));
			this.pbFundo.InitialImage = null;
			this.pbFundo.Location = new System.Drawing.Point(0, 1);
			this.pbFundo.Name = "pbFundo";
			this.pbFundo.Size = new System.Drawing.Size(394, 290);
			this.pbFundo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbFundo.TabIndex = 7;
			this.pbFundo.TabStop = false;
			// 
			// lbDemo
			// 
			this.lbDemo.AutoSize = true;
			this.lbDemo.Location = new System.Drawing.Point(61, 19);
			this.lbDemo.Name = "lbDemo";
			this.lbDemo.Size = new System.Drawing.Size(269, 13);
			this.lbDemo.TabIndex = 8;
			this.lbDemo.Text = "*Software não licenciado. Liberado para demonstração.";
			this.lbDemo.Visible = false;
			// 
			// mbNovaSenha
			// 
			this.mbNovaSenha.Location = new System.Drawing.Point(34, 188);
			this.mbNovaSenha.Name = "mbNovaSenha";
			this.mbNovaSenha.PasswordChar = '*';
			this.mbNovaSenha.Size = new System.Drawing.Size(100, 20);
			this.mbNovaSenha.TabIndex = 2;
			this.mbNovaSenha.Visible = false;
			this.mbNovaSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbNovaSenha_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Location = new System.Drawing.Point(31, 172);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Nova senha";
			this.label3.Visible = false;
			// 
			// llAlterarSenha
			// 
			this.llAlterarSenha.AutoSize = true;
			this.llAlterarSenha.Location = new System.Drawing.Point(31, 172);
			this.llAlterarSenha.Name = "llAlterarSenha";
			this.llAlterarSenha.Size = new System.Drawing.Size(69, 13);
			this.llAlterarSenha.TabIndex = 11;
			this.llAlterarSenha.TabStop = true;
			this.llAlterarSenha.Text = "Alterar senha";
			this.llAlterarSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// llCancelar
			// 
			this.llCancelar.AutoSize = true;
			this.llCancelar.Location = new System.Drawing.Point(31, 211);
			this.llCancelar.Name = "llCancelar";
			this.llCancelar.Size = new System.Drawing.Size(49, 13);
			this.llCancelar.TabIndex = 12;
			this.llCancelar.TabStop = true;
			this.llCancelar.Text = "Cancelar";
			this.llCancelar.Visible = false;
			this.llCancelar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// lbUsuarioInvalido
			// 
			this.lbUsuarioInvalido.AutoSize = true;
			this.lbUsuarioInvalido.ForeColor = System.Drawing.Color.Red;
			this.lbUsuarioInvalido.Location = new System.Drawing.Point(140, 113);
			this.lbUsuarioInvalido.Name = "lbUsuarioInvalido";
			this.lbUsuarioInvalido.Size = new System.Drawing.Size(218, 13);
			this.lbUsuarioInvalido.TabIndex = 13;
			this.lbUsuarioInvalido.Text = "*Usuário inválido! Código deve ser numérico.";
			this.lbUsuarioInvalido.Visible = false;
			// 
			// lbSenhaInvalida
			// 
			this.lbSenhaInvalida.AutoSize = true;
			this.lbSenhaInvalida.ForeColor = System.Drawing.Color.Red;
			this.lbSenhaInvalida.Location = new System.Drawing.Point(140, 152);
			this.lbSenhaInvalida.Name = "lbSenhaInvalida";
			this.lbSenhaInvalida.Size = new System.Drawing.Size(84, 13);
			this.lbSenhaInvalida.TabIndex = 14;
			this.lbSenhaInvalida.Text = "*Senha inválida!";
			this.lbSenhaInvalida.Visible = false;
			// 
			// lbSenhasNaoConferem
			// 
			this.lbSenhasNaoConferem.AutoSize = true;
			this.lbSenhasNaoConferem.ForeColor = System.Drawing.Color.Red;
			this.lbSenhasNaoConferem.Location = new System.Drawing.Point(246, 191);
			this.lbSenhasNaoConferem.Name = "lbSenhasNaoConferem";
			this.lbSenhasNaoConferem.Size = new System.Drawing.Size(118, 13);
			this.lbSenhasNaoConferem.TabIndex = 15;
			this.lbSenhasNaoConferem.Text = "*Senhas não conferem!";
			this.lbSenhasNaoConferem.Visible = false;
			// 
			// mbConfirmacao
			// 
			this.mbConfirmacao.Location = new System.Drawing.Point(140, 188);
			this.mbConfirmacao.Name = "mbConfirmacao";
			this.mbConfirmacao.PasswordChar = '*';
			this.mbConfirmacao.Size = new System.Drawing.Size(100, 20);
			this.mbConfirmacao.TabIndex = 3;
			this.mbConfirmacao.Visible = false;
			this.mbConfirmacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mbConfirmacao_KeyDown);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(137, 172);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 13);
			this.label7.TabIndex = 16;
			this.label7.Text = "Confirmação";
			this.label7.Visible = false;
			// 
			// lbVersao
			// 
			this.lbVersao.AutoSize = true;
			this.lbVersao.Font = new System.Drawing.Font("Agency FB", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbVersao.Location = new System.Drawing.Point(12, 234);
			this.lbVersao.Name = "lbVersao";
			this.lbVersao.Size = new System.Drawing.Size(31, 14);
			this.lbVersao.TabIndex = 17;
			this.lbVersao.Text = "Versão";
			// 
			// frmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 291);
			this.Controls.Add(this.lbVersao);
			this.Controls.Add(this.mbConfirmacao);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.lbSenhasNaoConferem);
			this.Controls.Add(this.lbSenhaInvalida);
			this.Controls.Add(this.lbUsuarioInvalido);
			this.Controls.Add(this.llCancelar);
			this.Controls.Add(this.llAlterarSenha);
			this.Controls.Add(this.mbNovaSenha);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbDemo);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.mbSenha);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pbFundo);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmLogin";
			this.Opacity = 0.9D;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DSoft Manager";
			this.Load += new System.EventHandler(this.frmLogin_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbFundo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.MaskedTextBox mbSenha;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.PictureBox pbFundo;
		private System.Windows.Forms.Label lbDemo;
		private System.Windows.Forms.MaskedTextBox mbNovaSenha;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.LinkLabel llAlterarSenha;
		private System.Windows.Forms.LinkLabel llCancelar;
		private System.Windows.Forms.Label lbUsuarioInvalido;
		private System.Windows.Forms.Label lbSenhaInvalida;
		private System.Windows.Forms.Label lbSenhasNaoConferem;
		private System.Windows.Forms.MaskedTextBox mbConfirmacao;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbVersao;
	}
}