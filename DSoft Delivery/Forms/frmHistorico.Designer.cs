namespace DSoft_Delivery.Forms
{
	partial class frmHistorico
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorico));
			this.tbHistorico = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbHistorico
			// 
			this.tbHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbHistorico.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbHistorico.Location = new System.Drawing.Point(0, 0);
			this.tbHistorico.Multiline = true;
			this.tbHistorico.Name = "tbHistorico";
			this.tbHistorico.ReadOnly = true;
			this.tbHistorico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbHistorico.Size = new System.Drawing.Size(466, 501);
			this.tbHistorico.TabIndex = 0;
			// 
			// frmHistorico
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(466, 501);
			this.Controls.Add(this.tbHistorico);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmHistorico";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Histórico de versões";
			this.Load += new System.EventHandler(this.frmHistorico_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbHistorico;

	}
}