namespace DSoftForms
{
	partial class CadLeads
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadLeads));
			this.dgvLeads = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvLeads
			// 
			this.dgvLeads.AllowUserToDeleteRows = false;
			this.dgvLeads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLeads.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvLeads.Location = new System.Drawing.Point(0, 0);
			this.dgvLeads.Name = "dgvLeads";
			this.dgvLeads.Size = new System.Drawing.Size(890, 440);
			this.dgvLeads.TabIndex = 0;
			this.dgvLeads.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeads_CellDoubleClick);
			this.dgvLeads.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLeads_CellEndEdit);
			this.dgvLeads.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			this.dgvLeads.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
			// 
			// CadLeads
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(890, 440);
			this.Controls.Add(this.dgvLeads);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CadLeads";
			this.Text = "Cadastro de Leads";
			this.Load += new System.EventHandler(this.CadLeads_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvLeads)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvLeads;
	}
}

