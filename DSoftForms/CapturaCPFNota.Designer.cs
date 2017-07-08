namespace DSoftForms
{
	partial class CapturaCPFNota
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturaCPFNota));
			this.mtCpf = new System.Windows.Forms.MaskedTextBox();
			this.btEmitir = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cupomFiscalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.emitirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gbCpfCnpj = new System.Windows.Forms.GroupBox();
			this.rbCNPJ = new System.Windows.Forms.RadioButton();
			this.rbCpf = new System.Windows.Forms.RadioButton();
			this.menuStrip1.SuspendLayout();
			this.gbCpfCnpj.SuspendLayout();
			this.SuspendLayout();
			// 
			// mtCpf
			// 
			this.mtCpf.Location = new System.Drawing.Point(84, 115);
			this.mtCpf.Mask = "999.999.999-99";
			this.mtCpf.Name = "mtCpf";
			this.mtCpf.Size = new System.Drawing.Size(126, 20);
			this.mtCpf.TabIndex = 0;
			// 
			// btEmitir
			// 
			this.btEmitir.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btEmitir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btEmitir.Location = new System.Drawing.Point(30, 217);
			this.btEmitir.Name = "btEmitir";
			this.btEmitir.Size = new System.Drawing.Size(123, 45);
			this.btEmitir.TabIndex = 2;
			this.btEmitir.Text = "&Emitir - F2";
			this.btEmitir.UseVisualStyleBackColor = true;
			this.btEmitir.Click += new System.EventHandler(this.btEmitir_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(159, 217);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 3;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cupomFiscalToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(294, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// cupomFiscalToolStripMenuItem
			// 
			this.cupomFiscalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cupomFiscalToolStripMenuItem.Name = "cupomFiscalToolStripMenuItem";
			this.cupomFiscalToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
			this.cupomFiscalToolStripMenuItem.Text = "Cupom Fiscal";
			// 
			// emitirToolStripMenuItem
			// 
			this.emitirToolStripMenuItem.Name = "emitirToolStripMenuItem";
			this.emitirToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.emitirToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.emitirToolStripMenuItem.Text = "&Emitir";
			this.emitirToolStripMenuItem.Click += new System.EventHandler(this.emitirToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// gbCpfCnpj
			// 
			this.gbCpfCnpj.Controls.Add(this.rbCNPJ);
			this.gbCpfCnpj.Controls.Add(this.rbCpf);
			this.gbCpfCnpj.Location = new System.Drawing.Point(84, 75);
			this.gbCpfCnpj.Name = "gbCpfCnpj";
			this.gbCpfCnpj.Size = new System.Drawing.Size(126, 34);
			this.gbCpfCnpj.TabIndex = 5;
			this.gbCpfCnpj.TabStop = false;
			// 
			// rbCNPJ
			// 
			this.rbCNPJ.AutoSize = true;
			this.rbCNPJ.Location = new System.Drawing.Point(57, 9);
			this.rbCNPJ.Name = "rbCNPJ";
			this.rbCNPJ.Size = new System.Drawing.Size(52, 17);
			this.rbCNPJ.TabIndex = 1;
			this.rbCNPJ.Text = "CNPJ";
			this.rbCNPJ.UseVisualStyleBackColor = true;
			this.rbCNPJ.CheckedChanged += new System.EventHandler(this.rbCNPJ_CheckedChanged);
			// 
			// rbCpf
			// 
			this.rbCpf.AutoSize = true;
			this.rbCpf.Checked = true;
			this.rbCpf.Location = new System.Drawing.Point(6, 9);
			this.rbCpf.Name = "rbCpf";
			this.rbCpf.Size = new System.Drawing.Size(45, 17);
			this.rbCpf.TabIndex = 0;
			this.rbCpf.TabStop = true;
			this.rbCpf.Text = "CPF";
			this.rbCpf.UseVisualStyleBackColor = true;
			this.rbCpf.CheckedChanged += new System.EventHandler(this.rbCpf_CheckedChanged);
			// 
			// frmCapturaCPFNota
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 274);
			this.Controls.Add(this.gbCpfCnpj);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btEmitir);
			this.Controls.Add(this.mtCpf);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCapturaCPFNota";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cupom Fiscal";
			this.Load += new System.EventHandler(this.frmCapturaCPFNota_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbCpfCnpj.ResumeLayout(false);
			this.gbCpfCnpj.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MaskedTextBox mtCpf;
		private System.Windows.Forms.Button btEmitir;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cupomFiscalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem emitirToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.GroupBox gbCpfCnpj;
		private System.Windows.Forms.RadioButton rbCNPJ;
		private System.Windows.Forms.RadioButton rbCpf;
	}
}