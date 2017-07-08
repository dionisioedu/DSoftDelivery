namespace DSoft_Delivery.Forms
{
	partial class frmReceber
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceber));
			this.dgRecebimentos = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.recebimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cancelarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbTipo = new System.Windows.Forms.ComboBox();
			this.cbCliente = new System.Windows.Forms.ComboBox();
			this.dtVencimento = new System.Windows.Forms.DateTimePicker();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.tbObservacao = new System.Windows.Forms.TextBox();
			this.btNovo = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.btLimpar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btPagar = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button19 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.consultaDeContasÀReceberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.dgRecebimentos)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgRecebimentos
			// 
			this.dgRecebimentos.AllowUserToAddRows = false;
			this.dgRecebimentos.AllowUserToDeleteRows = false;
			this.dgRecebimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgRecebimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgRecebimentos.Location = new System.Drawing.Point(361, 27);
			this.dgRecebimentos.Name = "dgRecebimentos";
			this.dgRecebimentos.ReadOnly = true;
			this.dgRecebimentos.RowHeadersWidth = 18;
			this.dgRecebimentos.Size = new System.Drawing.Size(577, 432);
			this.dgRecebimentos.TabIndex = 0;
			this.dgRecebimentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRecebimentos_CellDoubleClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recebimentosToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(950, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// recebimentosToolStripMenuItem
			// 
			this.recebimentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.cancelarToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.sairToolStripMenuItem});
			this.recebimentosToolStripMenuItem.Name = "recebimentosToolStripMenuItem";
			this.recebimentosToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.recebimentosToolStripMenuItem.Text = "&Recebimentos";
			// 
			// novoToolStripMenuItem
			// 
			this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
			this.novoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.novoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.novoToolStripMenuItem.Text = "&Novo";
			this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
			// 
			// cancelarToolStripMenuItem
			// 
			this.cancelarToolStripMenuItem.Name = "cancelarToolStripMenuItem";
			this.cancelarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
			this.cancelarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.cancelarToolStripMenuItem.Text = "&Cancelar";
			this.cancelarToolStripMenuItem.Click += new System.EventHandler(this.cancelarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
			this.toolStripMenuItem1.Text = "Tipos de recebimentos";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaDeContasÀReceberToolStripMenuItem});
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Consultas";
			// 
			// cbTipo
			// 
			this.cbTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTipo.FormattingEnabled = true;
			this.cbTipo.Location = new System.Drawing.Point(12, 52);
			this.cbTipo.Name = "cbTipo";
			this.cbTipo.Size = new System.Drawing.Size(120, 21);
			this.cbTipo.TabIndex = 2;
			// 
			// cbCliente
			// 
			this.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCliente.FormattingEnabled = true;
			this.cbCliente.Location = new System.Drawing.Point(138, 52);
			this.cbCliente.Name = "cbCliente";
			this.cbCliente.Size = new System.Drawing.Size(210, 21);
			this.cbCliente.TabIndex = 3;
			// 
			// dtVencimento
			// 
			this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtVencimento.Location = new System.Drawing.Point(12, 92);
			this.dtVencimento.Name = "dtVencimento";
			this.dtVencimento.Size = new System.Drawing.Size(100, 20);
			this.dtVencimento.TabIndex = 4;
			// 
			// tbValor
			// 
			this.tbValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbValor.Location = new System.Drawing.Point(248, 92);
			this.tbValor.Name = "tbValor";
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 5;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbValor_KeyPress);
			// 
			// tbObservacao
			// 
			this.tbObservacao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObservacao.Location = new System.Drawing.Point(12, 131);
			this.tbObservacao.Multiline = true;
			this.tbObservacao.Name = "tbObservacao";
			this.tbObservacao.Size = new System.Drawing.Size(336, 68);
			this.tbObservacao.TabIndex = 6;
			// 
			// btNovo
			// 
			this.btNovo.Location = new System.Drawing.Point(12, 205);
			this.btNovo.Name = "btNovo";
			this.btNovo.Size = new System.Drawing.Size(93, 23);
			this.btNovo.TabIndex = 7;
			this.btNovo.Text = "&Novo - F2";
			this.btNovo.UseVisualStyleBackColor = true;
			this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.Enabled = false;
			this.btCancelar.Location = new System.Drawing.Point(111, 205);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(75, 23);
			this.btCancelar.TabIndex = 8;
			this.btCancelar.Text = "&Cancelar F4";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
			// 
			// btLimpar
			// 
			this.btLimpar.Location = new System.Drawing.Point(273, 205);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(75, 23);
			this.btLimpar.TabIndex = 9;
			this.btLimpar.Text = "&Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(273, 234);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 10;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Tipo de recebimento";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(135, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Cliente";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Vencimento";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(245, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Valor";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 115);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Observação";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(221, 95);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "R$";
			// 
			// btPagar
			// 
			this.btPagar.Enabled = false;
			this.btPagar.Location = new System.Drawing.Point(192, 205);
			this.btPagar.Name = "btPagar";
			this.btPagar.Size = new System.Drawing.Size(75, 23);
			this.btPagar.TabIndex = 17;
			this.btPagar.Text = "&Pagar - F5";
			this.btPagar.UseVisualStyleBackColor = true;
			this.btPagar.Click += new System.EventHandler(this.btPagar_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.button19);
			this.groupBox3.Controls.Add(this.button15);
			this.groupBox3.Controls.Add(this.button14);
			this.groupBox3.Controls.Add(this.button13);
			this.groupBox3.Location = new System.Drawing.Point(232, 332);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(123, 127);
			this.groupBox3.TabIndex = 18;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Legenda";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(32, 101);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(37, 13);
			this.label22.TabIndex = 14;
			this.label22.Text = "Pagas";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(32, 75);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(63, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Canceladas";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(51, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Vencidas";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(32, 23);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(43, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Abertas";
			// 
			// button19
			// 
			this.button19.BackColor = System.Drawing.Color.Green;
			this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button19.Location = new System.Drawing.Point(6, 97);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(20, 20);
			this.button19.TabIndex = 6;
			this.button19.UseVisualStyleBackColor = false;
			// 
			// button15
			// 
			this.button15.BackColor = System.Drawing.Color.Red;
			this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button15.Location = new System.Drawing.Point(6, 71);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(20, 20);
			this.button15.TabIndex = 2;
			this.button15.UseVisualStyleBackColor = false;
			// 
			// button14
			// 
			this.button14.BackColor = System.Drawing.Color.Yellow;
			this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button14.Location = new System.Drawing.Point(6, 45);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(20, 20);
			this.button14.TabIndex = 1;
			this.button14.UseVisualStyleBackColor = false;
			// 
			// button13
			// 
			this.button13.BackColor = System.Drawing.Color.White;
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button13.Location = new System.Drawing.Point(6, 19);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(20, 20);
			this.button13.TabIndex = 0;
			this.button13.UseVisualStyleBackColor = false;
			// 
			// consultaDeContasÀReceberToolStripMenuItem
			// 
			this.consultaDeContasÀReceberToolStripMenuItem.Name = "consultaDeContasÀReceberToolStripMenuItem";
			this.consultaDeContasÀReceberToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
			this.consultaDeContasÀReceberToolStripMenuItem.Text = "Consulta de contas à receber";
			this.consultaDeContasÀReceberToolStripMenuItem.Click += new System.EventHandler(this.consultaDeContasÀReceberToolStripMenuItem_Click);
			// 
			// frmReceber
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(950, 471);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btPagar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btNovo);
			this.Controls.Add(this.tbObservacao);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.dtVencimento);
			this.Controls.Add(this.cbCliente);
			this.Controls.Add(this.cbTipo);
			this.Controls.Add(this.dgRecebimentos);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(601, 444);
			this.Name = "frmReceber";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Contas à receber";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReceber_FormClosing);
			this.Load += new System.EventHandler(this.frmReceber_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgRecebimentos)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgRecebimentos;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem recebimentosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cancelarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ComboBox cbTipo;
		private System.Windows.Forms.ComboBox cbCliente;
		private System.Windows.Forms.DateTimePicker dtVencimento;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.TextBox tbObservacao;
		private System.Windows.Forms.Button btNovo;
		private System.Windows.Forms.Button btCancelar;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btPagar;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.ToolStripMenuItem consultaDeContasÀReceberToolStripMenuItem;
	}
}