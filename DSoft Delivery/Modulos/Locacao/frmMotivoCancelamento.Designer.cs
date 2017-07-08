namespace DSoft_Delivery.Modulos.Locacao
{
	partial class frmMotivoCancelamento
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMotivoCancelamento));
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.tbUsuario = new System.Windows.Forms.TextBox();
			this.tbSenha = new System.Windows.Forms.TextBox();
			this.tbMotivo = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btConfirmar
			// 
			this.btConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btConfirmar.Enabled = false;
			this.btConfirmar.Location = new System.Drawing.Point(12, 226);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(179, 23);
			this.btConfirmar.TabIndex = 0;
			this.btConfirmar.Text = "Confirmar cancelamento";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Location = new System.Drawing.Point(197, 226);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 1;
			this.btSair.Text = "Sair";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// tbUsuario
			// 
			this.tbUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbUsuario.Location = new System.Drawing.Point(12, 82);
			this.tbUsuario.Name = "tbUsuario";
			this.tbUsuario.Size = new System.Drawing.Size(100, 20);
			this.tbUsuario.TabIndex = 2;
			this.tbUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbUsuario_KeyDown);
			this.tbUsuario.Leave += new System.EventHandler(this.tbUsuario_Leave);
			// 
			// tbSenha
			// 
			this.tbSenha.Location = new System.Drawing.Point(12, 121);
			this.tbSenha.Name = "tbSenha";
			this.tbSenha.PasswordChar = '*';
			this.tbSenha.Size = new System.Drawing.Size(100, 20);
			this.tbSenha.TabIndex = 3;
			this.tbSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSenha_KeyDown);
			this.tbSenha.Leave += new System.EventHandler(this.tbSenha_Leave);
			// 
			// tbMotivo
			// 
			this.tbMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbMotivo.Location = new System.Drawing.Point(12, 160);
			this.tbMotivo.Multiline = true;
			this.tbMotivo.Name = "tbMotivo";
			this.tbMotivo.Size = new System.Drawing.Size(260, 60);
			this.tbMotivo.TabIndex = 4;
			this.tbMotivo.TextChanged += new System.EventHandler(this.tbMotivo_TextChanged);
			this.tbMotivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMotivo_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Usuário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 105);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Senha";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Motivo";
			// 
			// frmMotivoCancelamento
			// 
			this.AcceptButton = this.btConfirmar;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btSair;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbMotivo);
			this.Controls.Add(this.tbSenha);
			this.Controls.Add(this.tbUsuario);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMotivoCancelamento";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cancelamento";
			this.Load += new System.EventHandler(this.frmMotivoCancelamento_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbUsuario;
		private System.Windows.Forms.TextBox tbSenha;
		private System.Windows.Forms.TextBox tbMotivo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}