namespace DSoft_Delivery
{
	partial class frmDemonstraPedido
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemonstraPedido));
			this.tbPedido = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbPedido
			// 
			this.tbPedido.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbPedido.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPedido.Location = new System.Drawing.Point(0, 0);
			this.tbPedido.Multiline = true;
			this.tbPedido.Name = "tbPedido";
			this.tbPedido.ReadOnly = true;
			this.tbPedido.Size = new System.Drawing.Size(344, 482);
			this.tbPedido.TabIndex = 0;
			this.tbPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPedido_KeyDown);
			// 
			// frmDemonstraPedido
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 482);
			this.Controls.Add(this.tbPedido);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDemonstraPedido";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Demonstrativo de pedido";
			this.Load += new System.EventHandler(this.frmDemonstraPedido_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDemonstraPedido_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbPedido;
	}
}