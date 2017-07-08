namespace DSoftManager
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbLicenca = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbConfig = new System.Windows.Forms.ToolStripButton();
			this.tsbCadLeads = new System.Windows.Forms.ToolStripButton();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tsbContactsLog = new System.Windows.Forms.ToolStripButton();
			this.tsbSair = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.lbLicenca});
			this.statusStrip1.Location = new System.Drawing.Point(0, 406);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(937, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.AutoSize = false;
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(120, 17);
			this.toolStripStatusLabel2.Text = "usuario";
			// 
			// toolStripStatusLabel3
			// 
			this.toolStripStatusLabel3.AutoSize = false;
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new System.Drawing.Size(150, 17);
			this.toolStripStatusLabel3.Text = "                                                        ";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
			this.toolStripStatusLabel1.Text = "hora";
			// 
			// lbLicenca
			// 
			this.lbLicenca.Name = "lbLicenca";
			this.lbLicenca.Size = new System.Drawing.Size(12, 17);
			this.lbLicenca.Text = "-";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConfig,
            this.tsbCadLeads,
            this.tsbContactsLog,
            this.tsbSair});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(937, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbConfig
			// 
			this.tsbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfig.Image")));
			this.tsbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbConfig.Name = "tsbConfig";
			this.tsbConfig.Size = new System.Drawing.Size(23, 22);
			this.tsbConfig.Text = "toolStripButton1";
			this.tsbConfig.ToolTipText = "Configurações";
			this.tsbConfig.Click += new System.EventHandler(this.tsbConfig_Click);
			// 
			// tsbCadLeads
			// 
			this.tsbCadLeads.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCadLeads.Image = ((System.Drawing.Image)(resources.GetObject("tsbCadLeads.Image")));
			this.tsbCadLeads.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCadLeads.Name = "tsbCadLeads";
			this.tsbCadLeads.Size = new System.Drawing.Size(23, 22);
			this.tsbCadLeads.Text = "toolStripButton1";
			this.tsbCadLeads.ToolTipText = "Cadastro de Leads";
			this.tsbCadLeads.Click += new System.EventHandler(this.tsbCadLeads_Click);
			// 
			// tsbContactsLog
			// 
			this.tsbContactsLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbContactsLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbContactsLog.Image")));
			this.tsbContactsLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbContactsLog.Name = "tsbContactsLog";
			this.tsbContactsLog.Size = new System.Drawing.Size(23, 22);
			this.tsbContactsLog.Text = "Registro de contatos";
			this.tsbContactsLog.Click += new System.EventHandler(this.tsbContactsLog_Click);
			// 
			// tsbSair
			// 
			this.tsbSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSair.Image = ((System.Drawing.Image)(resources.GetObject("tsbSair.Image")));
			this.tsbSair.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSair.Name = "tsbSair";
			this.tsbSair.Size = new System.Drawing.Size(23, 22);
			this.tsbSair.Text = "Sair";
			this.tsbSair.Click += new System.EventHandler(this.tsbSair_Click);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(937, 428);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.Text = "DSoft Manager";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripStatusLabel lbLicenca;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbCadLeads;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ToolStripButton tsbConfig;
		private System.Windows.Forms.ToolStripButton tsbContactsLog;
		private System.Windows.Forms.ToolStripButton tsbSair;
	}
}

