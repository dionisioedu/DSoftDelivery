namespace DSoft_Delivery
{
	partial class frmCrediario
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrediario));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.crediárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbSaldo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbLimite = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbDisponivel = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.dtVencimento = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.tbParcelas = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbJuros = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.btGerar = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label14 = new System.Windows.Forms.Label();
			this.tbTotalJuros = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbValorTotal = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tbPendente = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crediárioToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// crediárioToolStripMenuItem
			// 
			this.crediárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.crediárioToolStripMenuItem.Name = "crediárioToolStripMenuItem";
			this.crediárioToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
			this.crediárioToolStripMenuItem.Text = "Crediário";
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
			// tbCliente
			// 
			this.tbCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCliente.Location = new System.Drawing.Point(12, 52);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.ReadOnly = true;
			this.tbCliente.Size = new System.Drawing.Size(200, 20);
			this.tbCliente.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cliente";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(280, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Saldo";
			// 
			// tbSaldo
			// 
			this.tbSaldo.Location = new System.Drawing.Point(283, 52);
			this.tbSaldo.Name = "tbSaldo";
			this.tbSaldo.ReadOnly = true;
			this.tbSaldo.Size = new System.Drawing.Size(100, 20);
			this.tbSaldo.TabIndex = 2;
			this.tbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(256, 55);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "R$";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(389, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "R$";
			// 
			// tbLimite
			// 
			this.tbLimite.Location = new System.Drawing.Point(416, 52);
			this.tbLimite.Name = "tbLimite";
			this.tbLimite.ReadOnly = true;
			this.tbLimite.Size = new System.Drawing.Size(100, 20);
			this.tbLimite.TabIndex = 3;
			this.tbLimite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(413, 36);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 13);
			this.label5.TabIndex = 6;
			this.label5.Text = "Limite";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(655, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "R$";
			// 
			// tbDisponivel
			// 
			this.tbDisponivel.Location = new System.Drawing.Point(682, 52);
			this.tbDisponivel.Name = "tbDisponivel";
			this.tbDisponivel.ReadOnly = true;
			this.tbDisponivel.Size = new System.Drawing.Size(100, 20);
			this.tbDisponivel.TabIndex = 4;
			this.tbDisponivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(679, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 13);
			this.label7.TabIndex = 9;
			this.label7.Text = "Disponível";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(530, 317);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 10;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 317);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 11;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 116);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "R$";
			// 
			// tbValor
			// 
			this.tbValor.Location = new System.Drawing.Point(36, 113);
			this.tbValor.Name = "tbValor";
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 5;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(33, 97);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Valor";
			// 
			// dtVencimento
			// 
			this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtVencimento.Location = new System.Drawing.Point(171, 113);
			this.dtVencimento.Name = "dtVencimento";
			this.dtVencimento.Size = new System.Drawing.Size(100, 20);
			this.dtVencimento.TabIndex = 6;
			this.dtVencimento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtVencimento_KeyDown);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(168, 97);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 13);
			this.label10.TabIndex = 18;
			this.label10.Text = "Vencimento";
			// 
			// tbParcelas
			// 
			this.tbParcelas.Location = new System.Drawing.Point(304, 113);
			this.tbParcelas.Name = "tbParcelas";
			this.tbParcelas.Size = new System.Drawing.Size(50, 20);
			this.tbParcelas.TabIndex = 7;
			this.tbParcelas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbParcelas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbParcelas_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(301, 97);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 13);
			this.label11.TabIndex = 20;
			this.label11.Text = "Parcelas";
			// 
			// tbJuros
			// 
			this.tbJuros.Location = new System.Drawing.Point(400, 113);
			this.tbJuros.Name = "tbJuros";
			this.tbJuros.Size = new System.Drawing.Size(50, 20);
			this.tbJuros.TabIndex = 8;
			this.tbJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbJuros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbJuros_KeyDown);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(397, 97);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(32, 13);
			this.label12.TabIndex = 21;
			this.label12.Text = "Juros";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(456, 116);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(15, 13);
			this.label13.TabIndex = 23;
			this.label13.Text = "%";
			// 
			// btGerar
			// 
			this.btGerar.Location = new System.Drawing.Point(483, 110);
			this.btGerar.Name = "btGerar";
			this.btGerar.Size = new System.Drawing.Size(123, 23);
			this.btGerar.TabIndex = 9;
			this.btGerar.Text = "Gerar Parcelas";
			this.btGerar.UseVisualStyleBackColor = true;
			this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(140, 139);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(466, 150);
			this.dataGridView1.TabIndex = 25;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(655, 233);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 28;
			this.label14.Text = "R$";
			// 
			// tbTotalJuros
			// 
			this.tbTotalJuros.Location = new System.Drawing.Point(682, 230);
			this.tbTotalJuros.Name = "tbTotalJuros";
			this.tbTotalJuros.ReadOnly = true;
			this.tbTotalJuros.Size = new System.Drawing.Size(100, 20);
			this.tbTotalJuros.TabIndex = 27;
			this.tbTotalJuros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(679, 214);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(74, 13);
			this.label15.TabIndex = 26;
			this.label15.Text = "Total de Juros";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(655, 272);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(21, 13);
			this.label16.TabIndex = 31;
			this.label16.Text = "R$";
			// 
			// tbValorTotal
			// 
			this.tbValorTotal.Location = new System.Drawing.Point(682, 269);
			this.tbValorTotal.Name = "tbValorTotal";
			this.tbValorTotal.ReadOnly = true;
			this.tbValorTotal.Size = new System.Drawing.Size(100, 20);
			this.tbValorTotal.TabIndex = 30;
			this.tbValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(679, 253);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 29;
			this.label17.Text = "Valor Total";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(522, 55);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(21, 13);
			this.label18.TabIndex = 34;
			this.label18.Text = "R$";
			// 
			// tbPendente
			// 
			this.tbPendente.Location = new System.Drawing.Point(549, 52);
			this.tbPendente.Name = "tbPendente";
			this.tbPendente.ReadOnly = true;
			this.tbPendente.Size = new System.Drawing.Size(100, 20);
			this.tbPendente.TabIndex = 32;
			this.tbPendente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(546, 36);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(53, 13);
			this.label19.TabIndex = 33;
			this.label19.Text = "Pendente";
			// 
			// frmCrediario
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 374);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.tbPendente);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbValorTotal);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbTotalJuros);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btGerar);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tbJuros);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.tbParcelas);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.dtVencimento);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbDisponivel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbLimite);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbSaldo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCrediario";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Crediário";
			this.Load += new System.EventHandler(this.frmCrediario_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem crediárioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSaldo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbLimite;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbDisponivel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.DateTimePicker dtVencimento;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbParcelas;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbJuros;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btGerar;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbTotalJuros;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbValorTotal;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbPendente;
		private System.Windows.Forms.Label label19;
	}
}