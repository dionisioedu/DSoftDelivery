namespace DSoftForms
{
	partial class ContactsLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactsLog));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.dgvContactsLog = new System.Windows.Forms.DataGridView();
			this.tsbNovoContato = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContactsLog)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovoContato});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(956, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// dgvContactsLog
			// 
			this.dgvContactsLog.AllowUserToAddRows = false;
			this.dgvContactsLog.AllowUserToDeleteRows = false;
			this.dgvContactsLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvContactsLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvContactsLog.Location = new System.Drawing.Point(0, 25);
			this.dgvContactsLog.Name = "dgvContactsLog";
			this.dgvContactsLog.ReadOnly = true;
			this.dgvContactsLog.Size = new System.Drawing.Size(956, 452);
			this.dgvContactsLog.TabIndex = 1;
			// 
			// tsbNovoContato
			// 
			this.tsbNovoContato.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbNovoContato.Image = ((System.Drawing.Image)(resources.GetObject("tsbNovoContato.Image")));
			this.tsbNovoContato.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbNovoContato.Name = "tsbNovoContato";
			this.tsbNovoContato.Size = new System.Drawing.Size(23, 22);
			this.tsbNovoContato.Text = "toolStripButton1";
			this.tsbNovoContato.Click += new System.EventHandler(this.tsbNovoContato_Click);
			// 
			// ContactsLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(956, 477);
			this.Controls.Add(this.dgvContactsLog);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ContactsLog";
			this.Text = "ContactLogs";
			this.Load += new System.EventHandler(this.ContactLogs_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvContactsLog)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.DataGridView dgvContactsLog;
		private System.Windows.Forms.ToolStripButton tsbNovoContato;
	}
}