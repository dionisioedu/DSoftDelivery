namespace DSoft_Delivery.Forms
{
	partial class frmConsultaPrecos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaPrecos));
			this.tbProduto = new System.Windows.Forms.TextBox();
			this.dgProdutos = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).BeginInit();
			this.SuspendLayout();
			// 
			// tbProduto
			// 
			this.tbProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbProduto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbProduto.Location = new System.Drawing.Point(12, 12);
			this.tbProduto.Name = "tbProduto";
			this.tbProduto.Size = new System.Drawing.Size(315, 21);
			this.tbProduto.TabIndex = 0;
			this.tbProduto.TextChanged += new System.EventHandler(this.tbProduto_TextChanged);
			this.tbProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProduto_KeyDown);
			// 
			// dgProdutos
			// 
			this.dgProdutos.AllowUserToAddRows = false;
			this.dgProdutos.AllowUserToDeleteRows = false;
			this.dgProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgProdutos.Location = new System.Drawing.Point(12, 39);
			this.dgProdutos.MultiSelect = false;
			this.dgProdutos.Name = "dgProdutos";
			this.dgProdutos.ReadOnly = true;
			this.dgProdutos.RowHeadersWidth = 18;
			this.dgProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgProdutos.Size = new System.Drawing.Size(315, 389);
			this.dgProdutos.TabIndex = 1;
			this.dgProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgProdutos_KeyDown);
			// 
			// frmConsultaPrecos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 440);
			this.Controls.Add(this.dgProdutos);
			this.Controls.Add(this.tbProduto);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConsultaPrecos";
			this.ShowInTaskbar = false;
			this.Text = "Consulta de preços";
			this.Deactivate += new System.EventHandler(this.frmConsultaPrecos_Deactivate);
			((System.ComponentModel.ISupportInitialize)(this.dgProdutos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbProduto;
		private System.Windows.Forms.DataGridView dgProdutos;
	}
}