namespace DSoft_Delivery.Modulos.Locacao
{
	partial class frmConsulta
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsulta));
			this.cbUsuario = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtInicio = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rbCancelamentos = new System.Windows.Forms.RadioButton();
			this.rbCaixa = new System.Windows.Forms.RadioButton();
			this.rbRecebimento = new System.Windows.Forms.RadioButton();
			this.rbLocacao = new System.Windows.Forms.RadioButton();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btImprimir = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.tbConsulta = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbUsuario
			// 
			this.cbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUsuario.FormattingEnabled = true;
			this.cbUsuario.Location = new System.Drawing.Point(12, 48);
			this.cbUsuario.Name = "cbUsuario";
			this.cbUsuario.Size = new System.Drawing.Size(268, 21);
			this.cbUsuario.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Usuário";
			// 
			// dtInicio
			// 
			this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicio.Location = new System.Drawing.Point(344, 48);
			this.dtInicio.Name = "dtInicio";
			this.dtInicio.Size = new System.Drawing.Size(100, 20);
			this.dtInicio.TabIndex = 2;
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(478, 49);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(341, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Período da consulta";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(319, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "de";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(450, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(22, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "até";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.rbCancelamentos);
			this.panel1.Controls.Add(this.rbCaixa);
			this.panel1.Controls.Add(this.rbRecebimento);
			this.panel1.Controls.Add(this.rbLocacao);
			this.panel1.Location = new System.Drawing.Point(12, 75);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 10;
			// 
			// rbCancelamentos
			// 
			this.rbCancelamentos.AutoSize = true;
			this.rbCancelamentos.Location = new System.Drawing.Point(3, 72);
			this.rbCancelamentos.Name = "rbCancelamentos";
			this.rbCancelamentos.Size = new System.Drawing.Size(98, 17);
			this.rbCancelamentos.TabIndex = 3;
			this.rbCancelamentos.Text = "Cancelamentos";
			this.rbCancelamentos.UseVisualStyleBackColor = true;
			// 
			// rbCaixa
			// 
			this.rbCaixa.AutoSize = true;
			this.rbCaixa.Location = new System.Drawing.Point(3, 49);
			this.rbCaixa.Name = "rbCaixa";
			this.rbCaixa.Size = new System.Drawing.Size(132, 17);
			this.rbCaixa.TabIndex = 2;
			this.rbCaixa.Text = "Lançamentos de caixa";
			this.rbCaixa.UseVisualStyleBackColor = true;
			// 
			// rbRecebimento
			// 
			this.rbRecebimento.AutoSize = true;
			this.rbRecebimento.Location = new System.Drawing.Point(3, 26);
			this.rbRecebimento.Name = "rbRecebimento";
			this.rbRecebimento.Size = new System.Drawing.Size(149, 17);
			this.rbRecebimento.TabIndex = 1;
			this.rbRecebimento.Text = "Recebimento de locações";
			this.rbRecebimento.UseVisualStyleBackColor = true;
			// 
			// rbLocacao
			// 
			this.rbLocacao.AutoSize = true;
			this.rbLocacao.Checked = true;
			this.rbLocacao.Location = new System.Drawing.Point(3, 3);
			this.rbLocacao.Name = "rbLocacao";
			this.rbLocacao.Size = new System.Drawing.Size(145, 17);
			this.rbLocacao.TabIndex = 0;
			this.rbLocacao.TabStop = true;
			this.rbLocacao.Text = "Lançamento de locações";
			this.rbLocacao.UseVisualStyleBackColor = true;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(137, 181);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 11;
			this.btConfirmar.Text = "Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btImprimir
			// 
			this.btImprimir.Location = new System.Drawing.Point(137, 210);
			this.btImprimir.Name = "btImprimir";
			this.btImprimir.Size = new System.Drawing.Size(75, 23);
			this.btImprimir.TabIndex = 12;
			this.btImprimir.Text = "Imprimir";
			this.btImprimir.UseVisualStyleBackColor = true;
			this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Location = new System.Drawing.Point(137, 239);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 13;
			this.btSair.Text = "Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// tbConsulta
			// 
			this.tbConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbConsulta.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbConsulta.Location = new System.Drawing.Point(218, 75);
			this.tbConsulta.Multiline = true;
			this.tbConsulta.Name = "tbConsulta";
			this.tbConsulta.ReadOnly = true;
			this.tbConsulta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConsulta.Size = new System.Drawing.Size(722, 339);
			this.tbConsulta.TabIndex = 14;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(614, 24);
			this.menuStrip1.TabIndex = 15;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "Consulta";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// frmConsulta
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btSair;
			this.ClientSize = new System.Drawing.Size(952, 426);
			this.Controls.Add(this.tbConsulta);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btImprimir);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicio);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbUsuario);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConsulta";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta";
			this.Load += new System.EventHandler(this.frmConsulta_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbUsuario;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dtInicio;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton rbCancelamentos;
		private System.Windows.Forms.RadioButton rbCaixa;
		private System.Windows.Forms.RadioButton rbRecebimento;
		private System.Windows.Forms.RadioButton rbLocacao;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btImprimir;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbConsulta;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;

	}
}