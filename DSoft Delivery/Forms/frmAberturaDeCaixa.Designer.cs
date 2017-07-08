namespace DSoft_Delivery.Forms
{
	partial class frmAberturaDeCaixa
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAberturaDeCaixa));
			this.tbEntrada = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmButton1 = new DSoftCore.Controls.ConfirmButton();
			this.cancelButton1 = new DSoftCore.Controls.CancelButton();
			this.label4 = new System.Windows.Forms.Label();
			this.tbSaldoAnterior = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbMensagem = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbEntrada
			// 
			this.tbEntrada.Location = new System.Drawing.Point(242, 84);
			this.tbEntrada.Name = "tbEntrada";
			this.tbEntrada.Size = new System.Drawing.Size(100, 20);
			this.tbEntrada.TabIndex = 0;
			this.tbEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbEntrada.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSaldo_KeyDown);
			this.tbEntrada.Leave += new System.EventHandler(this.tbSaldo_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(175, 87);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Entrada R$";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caixaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(394, 24);
			this.menuStrip1.TabIndex = 5;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// caixaToolStripMenuItem
			// 
			this.caixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
			this.caixaToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.caixaToolStripMenuItem.Text = "Caixa";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// confirmButton1
			// 
			this.confirmButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.confirmButton1.Location = new System.Drawing.Point(96, 199);
			this.confirmButton1.Name = "confirmButton1";
			this.confirmButton1.Size = new System.Drawing.Size(140, 60);
			this.confirmButton1.TabIndex = 6;
			// 
			// cancelButton1
			// 
			this.cancelButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cancelButton1.Location = new System.Drawing.Point(242, 199);
			this.cancelButton1.Name = "cancelButton1";
			this.cancelButton1.Size = new System.Drawing.Size(140, 60);
			this.cancelButton1.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(147, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Saldo anterior R$";
			// 
			// tbSaldoAnterior
			// 
			this.tbSaldoAnterior.Location = new System.Drawing.Point(242, 58);
			this.tbSaldoAnterior.Name = "tbSaldoAnterior";
			this.tbSaldoAnterior.ReadOnly = true;
			this.tbSaldoAnterior.Size = new System.Drawing.Size(100, 20);
			this.tbSaldoAnterior.TabIndex = 8;
			this.tbSaldoAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(172, 113);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Abertura R$";
			// 
			// tbTotal
			// 
			this.tbTotal.Location = new System.Drawing.Point(242, 110);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(100, 20);
			this.tbTotal.TabIndex = 10;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DSoft_Delivery.Properties.Resources._1440629671_banknotes;
			this.pictureBox1.Location = new System.Drawing.Point(12, 28);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(129, 118);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 12;
			this.pictureBox1.TabStop = false;
			// 
			// lbMensagem
			// 
			this.lbMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbMensagem.Location = new System.Drawing.Point(161, 156);
			this.lbMensagem.Name = "lbMensagem";
			this.lbMensagem.Size = new System.Drawing.Size(198, 40);
			this.lbMensagem.TabIndex = 13;
			this.lbMensagem.Text = "Caixa já foi aberto!";
			this.lbMensagem.Visible = false;
			// 
			// frmAberturaDeCaixa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 271);
			this.ControlBox = false;
			this.Controls.Add(this.lbMensagem);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbSaldoAnterior);
			this.Controls.Add(this.cancelButton1);
			this.Controls.Add(this.confirmButton1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbEntrada);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmAberturaDeCaixa";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Abertura de caixa";
			this.Load += new System.EventHandler(this.frmAberturaDeCaixa_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbEntrada;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private DSoftCore.Controls.ConfirmButton confirmButton1;
		private DSoftCore.Controls.CancelButton cancelButton1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbSaldoAnterior;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lbMensagem;
	}
}