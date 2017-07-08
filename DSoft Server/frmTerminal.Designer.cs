namespace DSoft_Server
{
	partial class frmTerminal
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.cbImpressora = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cb2vias = new System.Windows.Forms.CheckBox();
			this.tbTeste = new System.Windows.Forms.Button();
			this.cbRelatoriosMatricial = new System.Windows.Forms.CheckBox();
			this.nmColunas = new System.Windows.Forms.NumericUpDown();
			this.label11 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbPermiteCancelamento = new System.Windows.Forms.CheckBox();
			this.cbImpressoraExterna2 = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cbImpressoraExterna1 = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmColunas)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(403, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// configuraçõesToolStripMenuItem
			// 
			this.configuraçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
			this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
			this.configuraçõesToolStripMenuItem.Text = "&Configurações";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(140, 381);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(123, 45);
			this.button1.TabIndex = 2;
			this.button1.Text = "&Confirmar - F2";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(269, 381);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(123, 45);
			this.button2.TabIndex = 3;
			this.button2.Text = "&Sair - F10";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// cbImpressora
			// 
			this.cbImpressora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbImpressora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbImpressora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbImpressora.FormattingEnabled = true;
			this.cbImpressora.Location = new System.Drawing.Point(6, 108);
			this.cbImpressora.Name = "cbImpressora";
			this.cbImpressora.Size = new System.Drawing.Size(184, 21);
			this.cbImpressora.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Impressora";
			// 
			// cb2vias
			// 
			this.cb2vias.AutoSize = true;
			this.cb2vias.Location = new System.Drawing.Point(196, 110);
			this.cb2vias.Name = "cb2vias";
			this.cb2vias.Size = new System.Drawing.Size(93, 17);
			this.cb2vias.TabIndex = 5;
			this.cb2vias.Text = "Imprime 2 vias";
			this.cb2vias.UseVisualStyleBackColor = true;
			// 
			// tbTeste
			// 
			this.tbTeste.Location = new System.Drawing.Point(295, 106);
			this.tbTeste.Name = "tbTeste";
			this.tbTeste.Size = new System.Drawing.Size(75, 23);
			this.tbTeste.TabIndex = 6;
			this.tbTeste.Text = "&Testar";
			this.tbTeste.UseVisualStyleBackColor = true;
			this.tbTeste.Click += new System.EventHandler(this.tbTeste_Click);
			// 
			// cbRelatoriosMatricial
			// 
			this.cbRelatoriosMatricial.AutoSize = true;
			this.cbRelatoriosMatricial.Location = new System.Drawing.Point(196, 135);
			this.cbRelatoriosMatricial.Name = "cbRelatoriosMatricial";
			this.cbRelatoriosMatricial.Size = new System.Drawing.Size(163, 17);
			this.cbRelatoriosMatricial.TabIndex = 24;
			this.cbRelatoriosMatricial.Text = "Imprime relatórios na matricial";
			this.cbRelatoriosMatricial.UseVisualStyleBackColor = true;
			// 
			// nmColunas
			// 
			this.nmColunas.Location = new System.Drawing.Point(6, 135);
			this.nmColunas.Name = "nmColunas";
			this.nmColunas.Size = new System.Drawing.Size(39, 20);
			this.nmColunas.TabIndex = 25;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(49, 137);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(45, 13);
			this.label11.TabIndex = 26;
			this.label11.Text = "Colunas";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbPermiteCancelamento);
			this.groupBox2.Controls.Add(this.cbImpressoraExterna2);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Controls.Add(this.cbImpressoraExterna1);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.cbImpressora);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.nmColunas);
			this.groupBox2.Controls.Add(this.cb2vias);
			this.groupBox2.Controls.Add(this.cbRelatoriosMatricial);
			this.groupBox2.Controls.Add(this.tbTeste);
			this.groupBox2.Location = new System.Drawing.Point(12, 29);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(380, 346);
			this.groupBox2.TabIndex = 28;
			this.groupBox2.TabStop = false;
			// 
			// cbPermiteCancelamento
			// 
			this.cbPermiteCancelamento.AutoSize = true;
			this.cbPermiteCancelamento.Location = new System.Drawing.Point(6, 19);
			this.cbPermiteCancelamento.Name = "cbPermiteCancelamento";
			this.cbPermiteCancelamento.Size = new System.Drawing.Size(131, 17);
			this.cbPermiteCancelamento.TabIndex = 32;
			this.cbPermiteCancelamento.Text = "Permite cancelamento";
			this.cbPermiteCancelamento.UseVisualStyleBackColor = true;
			// 
			// cbImpressoraExterna2
			// 
			this.cbImpressoraExterna2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbImpressoraExterna2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbImpressoraExterna2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbImpressoraExterna2.FormattingEnabled = true;
			this.cbImpressoraExterna2.Location = new System.Drawing.Point(6, 235);
			this.cbImpressoraExterna2.Name = "cbImpressoraExterna2";
			this.cbImpressoraExterna2.Size = new System.Drawing.Size(184, 21);
			this.cbImpressoraExterna2.TabIndex = 31;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(6, 219);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(106, 13);
			this.label13.TabIndex = 30;
			this.label13.Text = "Impressora Externa 2";
			// 
			// cbImpressoraExterna1
			// 
			this.cbImpressoraExterna1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbImpressoraExterna1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbImpressoraExterna1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbImpressoraExterna1.FormattingEnabled = true;
			this.cbImpressoraExterna1.Location = new System.Drawing.Point(6, 195);
			this.cbImpressoraExterna1.Name = "cbImpressoraExterna1";
			this.cbImpressoraExterna1.Size = new System.Drawing.Size(184, 21);
			this.cbImpressoraExterna1.TabIndex = 29;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 179);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(106, 13);
			this.label12.TabIndex = 28;
			this.label12.Text = "Impressora Externa 1";
			// 
			// frmTerminal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 437);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmTerminal";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configurações do terminal";
			this.Load += new System.EventHandler(this.frmTerminal_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nmColunas)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox cbImpressora;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cb2vias;
		private System.Windows.Forms.Button tbTeste;
		private System.Windows.Forms.CheckBox cbRelatoriosMatricial;
		private System.Windows.Forms.NumericUpDown nmColunas;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox cbImpressoraExterna2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbImpressoraExterna1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.CheckBox cbPermiteCancelamento;
	}
}