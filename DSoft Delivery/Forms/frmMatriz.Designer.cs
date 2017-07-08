namespace DSoft_Delivery
{
	partial class frmMatriz
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatriz));
			this.cbMatriz = new System.Windows.Forms.CheckBox();
			this.gbParametros = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPasta = new System.Windows.Forms.TextBox();
			this.lbStatus2 = new System.Windows.Forms.Label();
			this.tbIntervalo = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.btSincronizar = new System.Windows.Forms.Button();
			this.lbStatus = new System.Windows.Forms.Label();
			this.btTestar = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPorta = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbServidor = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.gbParametros.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbMatriz
			// 
			this.cbMatriz.AutoSize = true;
			this.cbMatriz.Location = new System.Drawing.Point(12, 12);
			this.cbMatriz.Name = "cbMatriz";
			this.cbMatriz.Size = new System.Drawing.Size(54, 17);
			this.cbMatriz.TabIndex = 0;
			this.cbMatriz.Text = "Matriz";
			this.cbMatriz.UseVisualStyleBackColor = true;
			this.cbMatriz.CheckedChanged += new System.EventHandler(this.cbMatriz_CheckedChanged);
			// 
			// gbParametros
			// 
			this.gbParametros.Controls.Add(this.label3);
			this.gbParametros.Controls.Add(this.tbPasta);
			this.gbParametros.Controls.Add(this.lbStatus2);
			this.gbParametros.Controls.Add(this.tbIntervalo);
			this.gbParametros.Controls.Add(this.label4);
			this.gbParametros.Controls.Add(this.btSincronizar);
			this.gbParametros.Controls.Add(this.lbStatus);
			this.gbParametros.Controls.Add(this.btTestar);
			this.gbParametros.Controls.Add(this.label2);
			this.gbParametros.Controls.Add(this.tbPorta);
			this.gbParametros.Controls.Add(this.label1);
			this.gbParametros.Controls.Add(this.tbServidor);
			this.gbParametros.Location = new System.Drawing.Point(12, 35);
			this.gbParametros.Name = "gbParametros";
			this.gbParametros.Size = new System.Drawing.Size(270, 196);
			this.gbParametros.TabIndex = 1;
			this.gbParametros.TabStop = false;
			this.gbParametros.Text = "Parâmetros de conexão";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Pasta";
			// 
			// tbPasta
			// 
			this.tbPasta.Location = new System.Drawing.Point(6, 168);
			this.tbPasta.Name = "tbPasta";
			this.tbPasta.Size = new System.Drawing.Size(210, 20);
			this.tbPasta.TabIndex = 10;
			// 
			// lbStatus2
			// 
			this.lbStatus2.AutoSize = true;
			this.lbStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStatus2.Location = new System.Drawing.Point(87, 92);
			this.lbStatus2.Name = "lbStatus2";
			this.lbStatus2.Size = new System.Drawing.Size(0, 13);
			this.lbStatus2.TabIndex = 9;
			// 
			// tbIntervalo
			// 
			this.tbIntervalo.Location = new System.Drawing.Point(6, 129);
			this.tbIntervalo.Name = "tbIntervalo";
			this.tbIntervalo.Size = new System.Drawing.Size(100, 20);
			this.tbIntervalo.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 113);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(93, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Intervalo (minutos)";
			// 
			// btSincronizar
			// 
			this.btSincronizar.Location = new System.Drawing.Point(6, 87);
			this.btSincronizar.Name = "btSincronizar";
			this.btSincronizar.Size = new System.Drawing.Size(75, 23);
			this.btSincronizar.TabIndex = 6;
			this.btSincronizar.Text = "S&incronizar";
			this.btSincronizar.UseVisualStyleBackColor = true;
			// 
			// lbStatus
			// 
			this.lbStatus.AutoSize = true;
			this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbStatus.Location = new System.Drawing.Point(87, 63);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(0, 13);
			this.lbStatus.TabIndex = 5;
			// 
			// btTestar
			// 
			this.btTestar.Location = new System.Drawing.Point(6, 58);
			this.btTestar.Name = "btTestar";
			this.btTestar.Size = new System.Drawing.Size(75, 23);
			this.btTestar.TabIndex = 4;
			this.btTestar.Text = "&Testar";
			this.btTestar.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(219, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Porta";
			// 
			// tbPorta
			// 
			this.tbPorta.Location = new System.Drawing.Point(222, 32);
			this.tbPorta.Name = "tbPorta";
			this.tbPorta.Size = new System.Drawing.Size(42, 20);
			this.tbPorta.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Servidor";
			// 
			// tbServidor
			// 
			this.tbServidor.Location = new System.Drawing.Point(6, 32);
			this.tbServidor.Name = "tbServidor";
			this.tbServidor.Size = new System.Drawing.Size(210, 20);
			this.tbServidor.TabIndex = 0;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(126, 237);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 9;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(207, 237);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 10;
			this.btSair.Text = "&Sair";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// frmMatriz
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 272);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.gbParametros);
			this.Controls.Add(this.cbMatriz);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMatriz";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Matriz";
			this.Load += new System.EventHandler(this.frmMatriz_Load);
			this.gbParametros.ResumeLayout(false);
			this.gbParametros.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbMatriz;
		private System.Windows.Forms.GroupBox gbParametros;
		private System.Windows.Forms.Label lbStatus2;
		private System.Windows.Forms.TextBox tbIntervalo;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btSincronizar;
		private System.Windows.Forms.Label lbStatus;
		private System.Windows.Forms.Button btTestar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbPorta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbServidor;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPasta;
	}
}