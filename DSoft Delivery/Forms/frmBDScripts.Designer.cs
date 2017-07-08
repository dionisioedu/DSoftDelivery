namespace DSoft_Delivery.Forms
{
	partial class frmBDScripts
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBDScripts));
			this.tbScript = new System.Windows.Forms.TextBox();
			this.tbMessages = new System.Windows.Forms.TextBox();
			this.btExecute = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.interfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.executarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btExit = new System.Windows.Forms.Button();
			this.tabResult = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.dgResult = new System.Windows.Forms.DataGridView();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.menuStrip1.SuspendLayout();
			this.tabResult.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgResult)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbScript
			// 
			this.tbScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbScript.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbScript.Location = new System.Drawing.Point(3, 3);
			this.tbScript.Multiline = true;
			this.tbScript.Name = "tbScript";
			this.tbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbScript.Size = new System.Drawing.Size(723, 254);
			this.tbScript.TabIndex = 0;
			// 
			// tbMessages
			// 
			this.tbMessages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbMessages.Location = new System.Drawing.Point(3, 3);
			this.tbMessages.Multiline = true;
			this.tbMessages.Name = "tbMessages";
			this.tbMessages.ReadOnly = true;
			this.tbMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbMessages.Size = new System.Drawing.Size(715, 105);
			this.tbMessages.TabIndex = 1;
			// 
			// btExecute
			// 
			this.btExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExecute.AutoSize = true;
			this.btExecute.Location = new System.Drawing.Point(3, 262);
			this.btExecute.Name = "btExecute";
			this.btExecute.Size = new System.Drawing.Size(80, 23);
			this.btExecute.TabIndex = 2;
			this.btExecute.Text = "&Executar - F5";
			this.btExecute.UseVisualStyleBackColor = true;
			this.btExecute.Click += new System.EventHandler(this.btExecute_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.interfaceToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(729, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// interfaceToolStripMenuItem
			// 
			this.interfaceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.interfaceToolStripMenuItem.Name = "interfaceToolStripMenuItem";
			this.interfaceToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.interfaceToolStripMenuItem.Text = "Interface";
			this.interfaceToolStripMenuItem.Visible = false;
			// 
			// executarToolStripMenuItem
			// 
			this.executarToolStripMenuItem.Name = "executarToolStripMenuItem";
			this.executarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.executarToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.executarToolStripMenuItem.Text = "&Executar";
			this.executarToolStripMenuItem.Click += new System.EventHandler(this.executarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(134, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// btExit
			// 
			this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExit.AutoSize = true;
			this.btExit.Location = new System.Drawing.Point(89, 263);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(80, 23);
			this.btExit.TabIndex = 4;
			this.btExit.Text = "&Sair - F10";
			this.btExit.UseVisualStyleBackColor = true;
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// tabResult
			// 
			this.tabResult.Controls.Add(this.tabPage1);
			this.tabResult.Controls.Add(this.tabPage2);
			this.tabResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabResult.Location = new System.Drawing.Point(0, 0);
			this.tabResult.Name = "tabResult";
			this.tabResult.SelectedIndex = 0;
			this.tabResult.Size = new System.Drawing.Size(729, 137);
			this.tabResult.TabIndex = 5;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tbMessages);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(721, 111);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Mensagem";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.dgResult);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(721, 111);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Resultados";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// dgResult
			// 
			this.dgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgResult.Location = new System.Drawing.Point(3, 3);
			this.dgResult.Name = "dgResult";
			this.dgResult.Size = new System.Drawing.Size(715, 105);
			this.dgResult.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tbScript);
			this.splitContainer1.Panel1.Controls.Add(this.btExecute);
			this.splitContainer1.Panel1.Controls.Add(this.btExit);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabResult);
			this.splitContainer1.Size = new System.Drawing.Size(729, 429);
			this.splitContainer1.SplitterDistance = 288;
			this.splitContainer1.TabIndex = 6;
			// 
			// frmBDScripts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(729, 430);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmBDScripts";
			this.ShowInTaskbar = false;
			this.Text = "Interface com banco-de-dados";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabResult.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgResult)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbScript;
		private System.Windows.Forms.TextBox tbMessages;
		private System.Windows.Forms.Button btExecute;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem interfaceToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Button btExit;
		private System.Windows.Forms.TabControl tabResult;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView dgResult;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}