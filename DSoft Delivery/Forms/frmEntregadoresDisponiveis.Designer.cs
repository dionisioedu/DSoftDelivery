namespace DSoft_Delivery.Forms
{
	partial class frmEntregadoresDisponiveis
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregadoresDisponiveis));
			this.dgEntregadores = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgEntregadores)).BeginInit();
			this.SuspendLayout();
			// 
			// dgEntregadores
			// 
			this.dgEntregadores.AllowUserToAddRows = false;
			this.dgEntregadores.AllowUserToDeleteRows = false;
			this.dgEntregadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgEntregadores.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgEntregadores.Location = new System.Drawing.Point(0, 0);
			this.dgEntregadores.Name = "dgEntregadores";
			this.dgEntregadores.ReadOnly = true;
			this.dgEntregadores.RowHeadersWidth = 18;
			this.dgEntregadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgEntregadores.Size = new System.Drawing.Size(351, 450);
			this.dgEntregadores.TabIndex = 0;
			this.dgEntregadores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEntregadores_CellClick);
			// 
			// frmEntregadoresDisponiveis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 450);
			this.Controls.Add(this.dgEntregadores);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEntregadoresDisponiveis";
			this.ShowInTaskbar = false;
			this.Text = "Entregadores Disponíveis";
			this.Load += new System.EventHandler(this.frmEntregadoresDisponiveis_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgEntregadores)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgEntregadores;

	}
}