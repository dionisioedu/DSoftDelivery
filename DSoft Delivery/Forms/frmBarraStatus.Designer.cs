namespace DSoft_Delivery
{
	partial class frmBarraStatus
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
			this.pbBarra = new System.Windows.Forms.ProgressBar();
			this.btCancelar = new System.Windows.Forms.Button();
			this.lbDetalhes = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// pbBarra
			// 
			this.pbBarra.Location = new System.Drawing.Point(12, 25);
			this.pbBarra.Name = "pbBarra";
			this.pbBarra.Size = new System.Drawing.Size(376, 23);
			this.pbBarra.TabIndex = 0;
			// 
			// btCancelar
			// 
			this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancelar.Location = new System.Drawing.Point(313, 85);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(75, 23);
			this.btCancelar.TabIndex = 2;
			this.btCancelar.Text = "&Cancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// lbDetalhes
			// 
			this.lbDetalhes.AutoSize = true;
			this.lbDetalhes.Location = new System.Drawing.Point(9, 9);
			this.lbDetalhes.Name = "lbDetalhes";
			this.lbDetalhes.Size = new System.Drawing.Size(0, 13);
			this.lbDetalhes.TabIndex = 3;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmBarraStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 120);
			this.Controls.Add(this.lbDetalhes);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.pbBarra);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBarraStatus";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Importação";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		public System.Windows.Forms.ProgressBar pbBarra;
		private System.Windows.Forms.Button btCancelar;
		public System.Windows.Forms.Label lbDetalhes;
		private System.Windows.Forms.Timer timer1;

	}
}