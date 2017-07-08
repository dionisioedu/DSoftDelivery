namespace DSoftForms
{
	partial class NovoUsuario
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
			this.components = new System.ComponentModel.Container();
			this.confirmButton1 = new DSoftCore.Controls.ConfirmButton();
			this.cancelButton1 = new DSoftCore.Controls.CancelButton();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.tbSenha = new System.Windows.Forms.TextBox();
			this.tbConfirmacao = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.lbErroUsuario = new System.Windows.Forms.Label();
			this.lbErroNome = new System.Windows.Forms.Label();
			this.lbErroSenha = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// confirmButton1
			// 
			this.confirmButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.confirmButton1.Location = new System.Drawing.Point(159, 240);
			this.confirmButton1.Name = "confirmButton1";
			this.confirmButton1.Size = new System.Drawing.Size(140, 60);
			this.confirmButton1.TabIndex = 0;
			this.confirmButton1.Click += new System.EventHandler(this.confirmButton1_Click);
			// 
			// cancelButton1
			// 
			this.cancelButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cancelButton1.Location = new System.Drawing.Point(305, 240);
			this.cancelButton1.Name = "cancelButton1";
			this.cancelButton1.Size = new System.Drawing.Size(140, 60);
			this.cancelButton1.TabIndex = 1;
			this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
			// 
			// tbCodigo
			// 
			this.tbCodigo.Location = new System.Drawing.Point(27, 38);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.ReadOnly = true;
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 2;
			this.toolTip1.SetToolTip(this.tbCodigo, "Código que poderá ser usado para acessar o sistema");
			// 
			// tbUsuario
			// 
			this.tbUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbUsuario.Location = new System.Drawing.Point(27, 77);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 3;
			this.toolTip1.SetToolTip(this.tbUsuario, "O usuário que poderá ser usado para acessar o sistema");
			this.tbUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUsuario_KeyDown);
			this.tbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUsuario_KeyPress);
			// 
			// tbNome
			// 
			this.tbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNome.Location = new System.Drawing.Point(27, 116);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(100, 20);
			this.tbNome.TabIndex = 4;
			this.tbNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNome_KeyDown);
			this.tbNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNome_KeyPress);
			// 
			// tbSenha
			// 
			this.tbSenha.Location = new System.Drawing.Point(27, 155);
			this.tbSenha.Name = "tbSenha";
			this.tbSenha.PasswordChar = '*';
			this.tbSenha.Size = new System.Drawing.Size(100, 20);
			this.tbSenha.TabIndex = 5;
			this.tbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyDown);
			this.tbSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSenha_KeyPress);
			// 
			// tbConfirmacao
			// 
			this.tbConfirmacao.Location = new System.Drawing.Point(27, 194);
			this.tbConfirmacao.Name = "tbConfirmacao";
			this.tbConfirmacao.PasswordChar = '*';
			this.tbConfirmacao.Size = new System.Drawing.Size(100, 20);
			this.tbConfirmacao.TabIndex = 6;
			this.tbConfirmacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbConfirmacao_KeyDown);
			this.tbConfirmacao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbConfirmacao_KeyPress);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DSoftForms.Properties.Resources.novo_usuario;
			this.pictureBox1.Location = new System.Drawing.Point(364, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(81, 81);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Usuário";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Nome";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 11;
			this.label4.Text = "Senha";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 178);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(113, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Confirmação de senha";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(159, 194);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(286, 43);
			this.label6.TabIndex = 13;
			this.label6.Text = "Este usuário será criado como administrador do sistema e poderá criar novos usuár" +
    "ios a qualquer momento através do menu Recursos \\ Cadastro de Usuários";
			// 
			// toolTip1
			// 
			this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
			// 
			// lbErroUsuario
			// 
			this.lbErroUsuario.AutoSize = true;
			this.lbErroUsuario.ForeColor = System.Drawing.Color.DarkRed;
			this.lbErroUsuario.Location = new System.Drawing.Point(133, 80);
			this.lbErroUsuario.Name = "lbErroUsuario";
			this.lbErroUsuario.Size = new System.Drawing.Size(0, 13);
			this.lbErroUsuario.TabIndex = 14;
			// 
			// lbErroNome
			// 
			this.lbErroNome.AutoSize = true;
			this.lbErroNome.ForeColor = System.Drawing.Color.DarkRed;
			this.lbErroNome.Location = new System.Drawing.Point(133, 119);
			this.lbErroNome.Name = "lbErroNome";
			this.lbErroNome.Size = new System.Drawing.Size(0, 13);
			this.lbErroNome.TabIndex = 15;
			// 
			// lbErroSenha
			// 
			this.lbErroSenha.AutoSize = true;
			this.lbErroSenha.ForeColor = System.Drawing.Color.DarkRed;
			this.lbErroSenha.Location = new System.Drawing.Point(133, 158);
			this.lbErroSenha.Name = "lbErroSenha";
			this.lbErroSenha.Size = new System.Drawing.Size(0, 13);
			this.lbErroSenha.TabIndex = 16;
			// 
			// NovoUsuario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(457, 312);
			this.Controls.Add(this.lbErroSenha);
			this.Controls.Add(this.lbErroNome);
			this.Controls.Add(this.lbErroUsuario);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.tbConfirmacao);
			this.Controls.Add(this.tbSenha);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.cancelButton1);
			this.Controls.Add(this.confirmButton1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NovoUsuario";
			this.ShowInTaskbar = false;
			this.Text = "Novo usuário";
			this.Load += new System.EventHandler(this.NovoUsuario_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DSoftCore.Controls.ConfirmButton confirmButton1;
		private DSoftCore.Controls.CancelButton cancelButton1;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.TextBox tbSenha;
		private System.Windows.Forms.TextBox tbConfirmacao;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lbErroUsuario;
		private System.Windows.Forms.Label lbErroNome;
		private System.Windows.Forms.Label lbErroSenha;
	}
}