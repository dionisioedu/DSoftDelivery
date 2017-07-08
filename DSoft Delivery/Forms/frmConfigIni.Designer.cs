namespace DSoft_Delivery.Forms
{
	partial class frmConfigIni
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigIni));
			this.tbIp = new System.Windows.Forms.TextBox();
			this.tbPorta = new System.Windows.Forms.TextBox();
			this.tbNome = new System.Windows.Forms.TextBox();
			this.lbIp = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cancelButton1 = new DSoftCore.Controls.CancelButton();
			this.confirmButton1 = new DSoftCore.Controls.ConfirmButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbIp
			// 
			this.tbIp.Location = new System.Drawing.Point(12, 53);
			this.tbIp.Name = "tbIp";
			this.tbIp.Size = new System.Drawing.Size(140, 20);
			this.tbIp.TabIndex = 0;
			// 
			// tbPorta
			// 
			this.tbPorta.Location = new System.Drawing.Point(158, 53);
			this.tbPorta.Name = "tbPorta";
			this.tbPorta.Size = new System.Drawing.Size(72, 20);
			this.tbPorta.TabIndex = 1;
			// 
			// tbNome
			// 
			this.tbNome.Location = new System.Drawing.Point(236, 53);
			this.tbNome.Name = "tbNome";
			this.tbNome.Size = new System.Drawing.Size(127, 20);
			this.tbNome.TabIndex = 2;
			// 
			// lbIp
			// 
			this.lbIp.AutoSize = true;
			this.lbIp.Location = new System.Drawing.Point(12, 37);
			this.lbIp.Name = "lbIp";
			this.lbIp.Size = new System.Drawing.Size(72, 13);
			this.lbIp.TabIndex = 5;
			this.lbIp.Text = "IP do servidor";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(155, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Porta";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(233, 37);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(130, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Nome do banco-de-dados";
			// 
			// cancelButton1
			// 
			this.cancelButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cancelButton1.Location = new System.Drawing.Point(355, 104);
			this.cancelButton1.Name = "cancelButton1";
			this.cancelButton1.Size = new System.Drawing.Size(140, 60);
			this.cancelButton1.TabIndex = 8;
			this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
			// 
			// confirmButton1
			// 
			this.confirmButton1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.confirmButton1.Location = new System.Drawing.Point(209, 104);
			this.confirmButton1.Name = "confirmButton1";
			this.confirmButton1.Size = new System.Drawing.Size(140, 60);
			this.confirmButton1.TabIndex = 9;
			this.confirmButton1.Click += new System.EventHandler(this.confirmButton1_Click);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.Color.DarkRed;
			this.label1.Location = new System.Drawing.Point(12, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(191, 60);
			this.label1.TabIndex = 10;
			this.label1.Text = "*Verifique as configurações de acesso ao servidor. Em caso de dúvidas, entre em c" +
    "ontato com o suporte.";
			// 
			// frmConfigIni
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(507, 176);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.confirmButton1);
			this.Controls.Add(this.cancelButton1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbIp);
			this.Controls.Add(this.tbNome);
			this.Controls.Add(this.tbPorta);
			this.Controls.Add(this.tbIp);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfigIni";
			this.ShowInTaskbar = false;
			this.Text = "Configuração do servidor";
			this.Load += new System.EventHandler(this.frmConfigIni_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbIp;
		private System.Windows.Forms.TextBox tbPorta;
		private System.Windows.Forms.TextBox tbNome;
		private System.Windows.Forms.Label lbIp;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DSoftCore.Controls.CancelButton cancelButton1;
		private DSoftCore.Controls.ConfirmButton confirmButton1;
		private System.Windows.Forms.Label label1;
	}
}