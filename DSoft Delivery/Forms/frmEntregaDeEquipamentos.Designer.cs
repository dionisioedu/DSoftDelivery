namespace DSoft_Delivery.Forms
{
	partial class frmEntregaDeEquipamentos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaDeEquipamentos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.entregaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbFuncionario = new System.Windows.Forms.ComboBox();
			this.lbEquipamentos = new System.Windows.Forms.ListBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbEstoque = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbEquipamento = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.pnEquipamentosExtra = new System.Windows.Forms.Panel();
			this.btEquipamentosExtra = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.btImprimir = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.pnEquipamentosExtra.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.entregaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(708, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
			// 
			// entregaToolStripMenuItem
			// 
			this.entregaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.entregaToolStripMenuItem.Name = "entregaToolStripMenuItem";
			this.entregaToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.entregaToolStripMenuItem.Text = "&Entrega";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbFuncionario
			// 
			this.cbFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFuncionario.FormattingEnabled = true;
			this.cbFuncionario.Location = new System.Drawing.Point(12, 55);
			this.cbFuncionario.Name = "cbFuncionario";
			this.cbFuncionario.Size = new System.Drawing.Size(200, 21);
			this.cbFuncionario.TabIndex = 1;
			this.cbFuncionario.SelectedIndexChanged += new System.EventHandler(this.cbFuncionario_SelectedIndexChanged);
			// 
			// lbEquipamentos
			// 
			this.lbEquipamentos.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEquipamentos.FormattingEnabled = true;
			this.lbEquipamentos.ItemHeight = 15;
			this.lbEquipamentos.Location = new System.Drawing.Point(12, 161);
			this.lbEquipamentos.Name = "lbEquipamentos";
			this.lbEquipamentos.Size = new System.Drawing.Size(298, 229);
			this.lbEquipamentos.TabIndex = 2;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Enabled = false;
			this.btConfirmar.Location = new System.Drawing.Point(316, 161);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 3;
			this.btConfirmar.Text = ">>";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Location = new System.Drawing.Point(621, 400);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Funcionário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Produtos necessários";
			// 
			// lbEstoque
			// 
			this.lbEstoque.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbEstoque.FormattingEnabled = true;
			this.lbEstoque.ItemHeight = 15;
			this.lbEstoque.Location = new System.Drawing.Point(397, 161);
			this.lbEstoque.Name = "lbEstoque";
			this.lbEstoque.Size = new System.Drawing.Size(298, 229);
			this.lbEstoque.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(394, 145);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Produtos com funcionário";
			// 
			// tbEquipamento
			// 
			this.tbEquipamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbEquipamento.Location = new System.Drawing.Point(12, 103);
			this.tbEquipamento.Name = "tbEquipamento";
			this.tbEquipamento.Size = new System.Drawing.Size(120, 20);
			this.tbEquipamento.TabIndex = 9;
			this.tbEquipamento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEquipamento_KeyPress);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Equipamento";
			// 
			// pnEquipamentosExtra
			// 
			this.pnEquipamentosExtra.Controls.Add(this.btEquipamentosExtra);
			this.pnEquipamentosExtra.Controls.Add(this.label5);
			this.pnEquipamentosExtra.Location = new System.Drawing.Point(397, 39);
			this.pnEquipamentosExtra.Name = "pnEquipamentosExtra";
			this.pnEquipamentosExtra.Size = new System.Drawing.Size(200, 100);
			this.pnEquipamentosExtra.TabIndex = 11;
			this.pnEquipamentosExtra.Visible = false;
			// 
			// btEquipamentosExtra
			// 
			this.btEquipamentosExtra.AutoSize = true;
			this.btEquipamentosExtra.Location = new System.Drawing.Point(3, 48);
			this.btEquipamentosExtra.Name = "btEquipamentosExtra";
			this.btEquipamentosExtra.Size = new System.Drawing.Size(175, 23);
			this.btEquipamentosExtra.TabIndex = 1;
			this.btEquipamentosExtra.Text = "Utilizar equipamentos excedentes";
			this.btEquipamentosExtra.UseVisualStyleBackColor = true;
			this.btEquipamentosExtra.Click += new System.EventHandler(this.btEquipamentosExtra_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(194, 51);
			this.label5.TabIndex = 0;
			this.label5.Text = "O funcionário possue equipamentos excedentes. Gostaria de utilizá-los agora?";
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// btImprimir
			// 
			this.btImprimir.Enabled = false;
			this.btImprimir.Location = new System.Drawing.Point(540, 400);
			this.btImprimir.Name = "btImprimir";
			this.btImprimir.Size = new System.Drawing.Size(75, 23);
			this.btImprimir.TabIndex = 12;
			this.btImprimir.Text = "&Imprimir";
			this.btImprimir.UseVisualStyleBackColor = true;
			this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
			// 
			// frmEntregaDeEquipamentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(708, 435);
			this.Controls.Add(this.btImprimir);
			this.Controls.Add(this.pnEquipamentosExtra);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbEquipamento);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lbEstoque);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.lbEquipamentos);
			this.Controls.Add(this.cbFuncionario);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmEntregaDeEquipamentos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Entrega de equipamentos";
			this.Load += new System.EventHandler(this.frmEntregaDeEquipamentoscs_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.pnEquipamentosExtra.ResumeLayout(false);
			this.pnEquipamentosExtra.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem entregaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbFuncionario;
		private System.Windows.Forms.ListBox lbEquipamentos;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbEstoque;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbEquipamento;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel pnEquipamentosExtra;
		private System.Windows.Forms.Button btEquipamentosExtra;
		private System.Windows.Forms.Label label5;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.Button btImprimir;
	}
}