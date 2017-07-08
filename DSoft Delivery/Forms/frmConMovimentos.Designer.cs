namespace DSoft_Delivery
{
	partial class frmConMovimentos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConMovimentos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.fecharF10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btSair = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.tbCaixasSaldo = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.tbTotalSaidas = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.tbTransferencia = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.tbDespesa = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.tbVale = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.tbPagamento = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbSaida = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbEntrada = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbDinheiro = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbVisa = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbMaster = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.tbCheque = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.fecharF10ToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "&Consulta";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem1.Text = "&Confirmar";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 6);
			// 
			// fecharF10ToolStripMenuItem
			// 
			this.fecharF10ToolStripMenuItem.Name = "fecharF10ToolStripMenuItem";
			this.fecharF10ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.fecharF10ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.fecharF10ToolStripMenuItem.Text = "&Sair";
			this.fecharF10ToolStripMenuItem.Click += new System.EventHandler(this.fecharF10ToolStripMenuItem_Click);
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(12, 51);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 1;
			this.dtInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtInicial_KeyPress);
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(118, 51);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(21, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "De";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Até";
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 35);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 7;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(530, 35);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 6;
			this.btConfirmar.Text = "&Confirmar - F5";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(655, 261);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(21, 13);
			this.label24.TabIndex = 71;
			this.label24.Text = "R$";
			// 
			// tbCaixasSaldo
			// 
			this.tbCaixasSaldo.BackColor = System.Drawing.Color.White;
			this.tbCaixasSaldo.Location = new System.Drawing.Point(682, 258);
			this.tbCaixasSaldo.Name = "tbCaixasSaldo";
			this.tbCaixasSaldo.ReadOnly = true;
			this.tbCaixasSaldo.Size = new System.Drawing.Size(100, 20);
			this.tbCaixasSaldo.TabIndex = 70;
			this.tbCaixasSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(615, 261);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(34, 13);
			this.label25.TabIndex = 69;
			this.label25.Text = "Saldo";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(388, 261);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(21, 13);
			this.label22.TabIndex = 68;
			this.label22.Text = "R$";
			// 
			// tbTotalSaidas
			// 
			this.tbTotalSaidas.BackColor = System.Drawing.Color.White;
			this.tbTotalSaidas.Location = new System.Drawing.Point(415, 258);
			this.tbTotalSaidas.Name = "tbTotalSaidas";
			this.tbTotalSaidas.ReadOnly = true;
			this.tbTotalSaidas.Size = new System.Drawing.Size(100, 20);
			this.tbTotalSaidas.TabIndex = 67;
			this.tbTotalSaidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(314, 261);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(68, 13);
			this.label23.TabIndex = 66;
			this.label23.Text = "Total Saídas";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(388, 222);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(21, 13);
			this.label20.TabIndex = 65;
			this.label20.Text = "R$";
			// 
			// tbTransferencia
			// 
			this.tbTransferencia.BackColor = System.Drawing.Color.White;
			this.tbTransferencia.Location = new System.Drawing.Point(415, 219);
			this.tbTransferencia.Name = "tbTransferencia";
			this.tbTransferencia.ReadOnly = true;
			this.tbTransferencia.Size = new System.Drawing.Size(100, 20);
			this.tbTransferencia.TabIndex = 64;
			this.tbTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(305, 222);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(77, 13);
			this.label21.TabIndex = 63;
			this.label21.Text = "Transferências";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(388, 196);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(21, 13);
			this.label18.TabIndex = 62;
			this.label18.Text = "R$";
			// 
			// tbDespesa
			// 
			this.tbDespesa.BackColor = System.Drawing.Color.White;
			this.tbDespesa.Location = new System.Drawing.Point(415, 193);
			this.tbDespesa.Name = "tbDespesa";
			this.tbDespesa.ReadOnly = true;
			this.tbDespesa.Size = new System.Drawing.Size(100, 20);
			this.tbDespesa.TabIndex = 61;
			this.tbDespesa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(328, 196);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(54, 13);
			this.label19.TabIndex = 60;
			this.label19.Text = "Despesas";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(388, 170);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(21, 13);
			this.label16.TabIndex = 59;
			this.label16.Text = "R$";
			// 
			// tbVale
			// 
			this.tbVale.BackColor = System.Drawing.Color.White;
			this.tbVale.Location = new System.Drawing.Point(415, 167);
			this.tbVale.Name = "tbVale";
			this.tbVale.ReadOnly = true;
			this.tbVale.Size = new System.Drawing.Size(100, 20);
			this.tbVale.TabIndex = 58;
			this.tbVale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(349, 170);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(33, 13);
			this.label17.TabIndex = 57;
			this.label17.Text = "Vales";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(388, 144);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 56;
			this.label14.Text = "R$";
			// 
			// tbPagamento
			// 
			this.tbPagamento.BackColor = System.Drawing.Color.White;
			this.tbPagamento.Location = new System.Drawing.Point(415, 141);
			this.tbPagamento.Name = "tbPagamento";
			this.tbPagamento.ReadOnly = true;
			this.tbPagamento.Size = new System.Drawing.Size(100, 20);
			this.tbPagamento.TabIndex = 55;
			this.tbPagamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(316, 144);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(66, 13);
			this.label15.TabIndex = 54;
			this.label15.Text = "Pagamentos";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(388, 118);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(21, 13);
			this.label12.TabIndex = 53;
			this.label12.Text = "R$";
			// 
			// tbSaida
			// 
			this.tbSaida.BackColor = System.Drawing.Color.White;
			this.tbSaida.Location = new System.Drawing.Point(415, 115);
			this.tbSaida.Name = "tbSaida";
			this.tbSaida.ReadOnly = true;
			this.tbSaida.Size = new System.Drawing.Size(100, 20);
			this.tbSaida.TabIndex = 52;
			this.tbSaida.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(346, 118);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(36, 13);
			this.label13.TabIndex = 51;
			this.label13.Text = "Saída";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(91, 261);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(21, 13);
			this.label10.TabIndex = 50;
			this.label10.Text = "R$";
			// 
			// tbEntrada
			// 
			this.tbEntrada.BackColor = System.Drawing.Color.White;
			this.tbEntrada.Location = new System.Drawing.Point(118, 258);
			this.tbEntrada.Name = "tbEntrada";
			this.tbEntrada.ReadOnly = true;
			this.tbEntrada.Size = new System.Drawing.Size(100, 20);
			this.tbEntrada.TabIndex = 49;
			this.tbEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(41, 261);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 48;
			this.label11.Text = "Entrada";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(412, 242);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 72;
			this.label3.Text = "--------------------------------";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(91, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 75;
			this.label4.Text = "R$";
			// 
			// tbDinheiro
			// 
			this.tbDinheiro.BackColor = System.Drawing.Color.White;
			this.tbDinheiro.Location = new System.Drawing.Point(118, 141);
			this.tbDinheiro.Name = "tbDinheiro";
			this.tbDinheiro.ReadOnly = true;
			this.tbDinheiro.Size = new System.Drawing.Size(100, 20);
			this.tbDinheiro.TabIndex = 74;
			this.tbDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(39, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(46, 13);
			this.label5.TabIndex = 73;
			this.label5.Text = "Dinheiro";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(91, 170);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 78;
			this.label6.Text = "R$";
			// 
			// tbVisa
			// 
			this.tbVisa.BackColor = System.Drawing.Color.White;
			this.tbVisa.Location = new System.Drawing.Point(118, 167);
			this.tbVisa.Name = "tbVisa";
			this.tbVisa.ReadOnly = true;
			this.tbVisa.Size = new System.Drawing.Size(100, 20);
			this.tbVisa.TabIndex = 77;
			this.tbVisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(58, 171);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(27, 13);
			this.label7.TabIndex = 76;
			this.label7.Text = "Visa";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(91, 196);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 81;
			this.label8.Text = "R$";
			// 
			// tbMaster
			// 
			this.tbMaster.BackColor = System.Drawing.Color.White;
			this.tbMaster.Location = new System.Drawing.Point(118, 193);
			this.tbMaster.Name = "tbMaster";
			this.tbMaster.ReadOnly = true;
			this.tbMaster.Size = new System.Drawing.Size(100, 20);
			this.tbMaster.TabIndex = 80;
			this.tbMaster.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(21, 196);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(64, 13);
			this.label9.TabIndex = 79;
			this.label9.Text = "Master Card";
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(91, 222);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(21, 13);
			this.label26.TabIndex = 84;
			this.label26.Text = "R$";
			// 
			// tbCheque
			// 
			this.tbCheque.BackColor = System.Drawing.Color.White;
			this.tbCheque.Location = new System.Drawing.Point(118, 219);
			this.tbCheque.Name = "tbCheque";
			this.tbCheque.ReadOnly = true;
			this.tbCheque.Size = new System.Drawing.Size(100, 20);
			this.tbCheque.TabIndex = 83;
			this.tbCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(36, 222);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(49, 13);
			this.label27.TabIndex = 82;
			this.label27.Text = "Cheques";
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(115, 242);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(103, 13);
			this.label28.TabIndex = 85;
			this.label28.Text = "--------------------------------";
			// 
			// frmConMovimentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 525);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.tbCheque);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbMaster);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbVisa);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbDinheiro);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.tbCaixasSaldo);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.tbTotalSaidas);
			this.Controls.Add(this.label23);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.tbTransferencia);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.tbDespesa);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbVale);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbPagamento);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbSaida);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbEntrada);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmConMovimentos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta de Movimentos";
			this.Load += new System.EventHandler(this.frmConMovimentos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fecharF10ToolStripMenuItem;
		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tbCaixasSaldo;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox tbTotalSaidas;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tbTransferencia;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbDespesa;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbVale;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbPagamento;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbSaida;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbEntrada;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbDinheiro;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbVisa;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbMaster;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox tbCheque;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
	}
}