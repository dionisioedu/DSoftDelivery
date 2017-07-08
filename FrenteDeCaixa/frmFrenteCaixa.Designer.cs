namespace FrenteDeCaixa
{
	partial class frmFrenteCaixa
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
			this.tbProduto = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.tbValorUnitario = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.pbImagem = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.tbValorTotal = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbTotalCompra = new System.Windows.Forms.TextBox();
			this.lbPedido = new System.Windows.Forms.ListBox();
			this.lbCaixa = new System.Windows.Forms.Label();
			this.lbUsuario = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.lbData = new System.Windows.Forms.Label();
			this.lbHora = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btLimpar = new System.Windows.Forms.Button();
			this.btExcluir = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbImagem)).BeginInit();
			this.SuspendLayout();
			// 
			// tbProduto
			// 
			this.tbProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbProduto.Location = new System.Drawing.Point(101, 111);
			this.tbProduto.Name = "tbProduto";
			this.tbProduto.Size = new System.Drawing.Size(158, 31);
			this.tbProduto.TabIndex = 0;
			this.tbProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProduto_KeyDown);
			this.tbProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbProduto_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(215, 95);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Produto";
			// 
			// tbDescricao
			// 
			this.tbDescricao.BackColor = System.Drawing.SystemColors.HighlightText;
			this.tbDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbDescricao.Location = new System.Drawing.Point(284, 111);
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.ReadOnly = true;
			this.tbDescricao.Size = new System.Drawing.Size(457, 31);
			this.tbDescricao.TabIndex = 2;
			this.tbDescricao.TabStop = false;
			// 
			// tbValorUnitario
			// 
			this.tbValorUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbValorUnitario.Location = new System.Drawing.Point(137, 178);
			this.tbValorUnitario.Name = "tbValorUnitario";
			this.tbValorUnitario.Size = new System.Drawing.Size(122, 31);
			this.tbValorUnitario.TabIndex = 3;
			this.tbValorUnitario.TabStop = false;
			this.tbValorUnitario.Text = "0,00";
			this.tbValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(188, 162);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Valor Produto";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(96, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 25);
			this.label3.TabIndex = 5;
			this.label3.Text = "R$";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft MHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(711, 30);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(321, 64);
			this.label4.TabIndex = 6;
			this.label4.Text = "DSoft Delivery";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(1074, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(26, 25);
			this.label5.TabIndex = 7;
			this.label5.Text = "X";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// pbImagem
			// 
			this.pbImagem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbImagem.Location = new System.Drawing.Point(776, 111);
			this.pbImagem.Name = "pbImagem";
			this.pbImagem.Size = new System.Drawing.Size(265, 300);
			this.pbImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbImagem.TabIndex = 8;
			this.pbImagem.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(197, 232);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(62, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Quantidade";
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbQuantidade.Location = new System.Drawing.Point(137, 248);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.Size = new System.Drawing.Size(122, 31);
			this.tbQuantidade.TabIndex = 1;
			this.tbQuantidade.Text = "1";
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbQuantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQuantidade_KeyPress);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(96, 321);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 25);
			this.label7.TabIndex = 13;
			this.label7.Text = "R$";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(201, 303);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Valor Total";
			// 
			// tbValorTotal
			// 
			this.tbValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbValorTotal.Location = new System.Drawing.Point(137, 319);
			this.tbValorTotal.Name = "tbValorTotal";
			this.tbValorTotal.Size = new System.Drawing.Size(122, 31);
			this.tbValorTotal.TabIndex = 11;
			this.tbValorTotal.TabStop = false;
			this.tbValorTotal.Text = "0,00";
			this.tbValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(776, 401);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(39, 25);
			this.label9.TabIndex = 17;
			this.label9.Text = "R$";
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(885, 374);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(85, 13);
			this.label10.TabIndex = 16;
			this.label10.Text = "Valor da Compra";
			// 
			// tbTotalCompra
			// 
			this.tbTotalCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.tbTotalCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbTotalCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTotalCompra.Location = new System.Drawing.Point(821, 390);
			this.tbTotalCompra.Name = "tbTotalCompra";
			this.tbTotalCompra.Size = new System.Drawing.Size(149, 44);
			this.tbTotalCompra.TabIndex = 15;
			this.tbTotalCompra.TabStop = false;
			this.tbTotalCompra.Text = "0,00";
			this.tbTotalCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbPedido
			// 
			this.lbPedido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lbPedido.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbPedido.FormattingEnabled = true;
			this.lbPedido.ItemHeight = 15;
			this.lbPedido.Location = new System.Drawing.Point(284, 178);
			this.lbPedido.Name = "lbPedido";
			this.lbPedido.Size = new System.Drawing.Size(457, 244);
			this.lbPedido.TabIndex = 2;
			this.lbPedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbPedido_KeyDown);
			this.lbPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lbPedido_KeyPress);
			// 
			// lbCaixa
			// 
			this.lbCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbCaixa.AutoSize = true;
			this.lbCaixa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCaixa.Location = new System.Drawing.Point(12, 512);
			this.lbCaixa.Name = "lbCaixa";
			this.lbCaixa.Size = new System.Drawing.Size(93, 25);
			this.lbCaixa.TabIndex = 19;
			this.lbCaixa.Text = "Caixa ID";
			// 
			// lbUsuario
			// 
			this.lbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbUsuario.AutoSize = true;
			this.lbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbUsuario.Location = new System.Drawing.Point(279, 512);
			this.lbUsuario.Name = "lbUsuario";
			this.lbUsuario.Size = new System.Drawing.Size(86, 25);
			this.lbUsuario.TabIndex = 20;
			this.lbUsuario.Text = "Usuario";
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(12, 499);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(33, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "Caixa";
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(281, 499);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(53, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "Vendedor";
			// 
			// lbData
			// 
			this.lbData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbData.AutoSize = true;
			this.lbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbData.Location = new System.Drawing.Point(683, 512);
			this.lbData.Name = "lbData";
			this.lbData.Size = new System.Drawing.Size(96, 25);
			this.lbData.TabIndex = 23;
			this.lbData.Text = "00/00/00";
			// 
			// lbHora
			// 
			this.lbHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.lbHora.AutoSize = true;
			this.lbHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbHora.Location = new System.Drawing.Point(848, 512);
			this.lbHora.Name = "lbHora";
			this.lbHora.Size = new System.Drawing.Size(96, 25);
			this.lbHora.TabIndex = 24;
			this.lbHora.Text = "00:00:00";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btLimpar
			// 
			this.btLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btLimpar.Location = new System.Drawing.Point(284, 428);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new System.Drawing.Size(118, 23);
			this.btLimpar.TabIndex = 25;
			this.btLimpar.Text = "Limpar pedido";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
			// 
			// btExcluir
			// 
			this.btExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btExcluir.Location = new System.Drawing.Point(408, 428);
			this.btExcluir.Name = "btExcluir";
			this.btExcluir.Size = new System.Drawing.Size(118, 23);
			this.btExcluir.TabIndex = 26;
			this.btExcluir.Text = "Excluir item";
			this.btExcluir.UseVisualStyleBackColor = true;
			this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
			// 
			// frmFrenteCaixa
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DarkCyan;
			this.ClientSize = new System.Drawing.Size(1112, 546);
			this.Controls.Add(this.btExcluir);
			this.Controls.Add(this.btLimpar);
			this.Controls.Add(this.lbHora);
			this.Controls.Add(this.lbData);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.lbUsuario);
			this.Controls.Add(this.lbCaixa);
			this.Controls.Add(this.lbPedido);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbTotalCompra);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbValorTotal);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.pbImagem);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbValorUnitario);
			this.Controls.Add(this.tbDescricao);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbProduto);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmFrenteCaixa";
			this.Text = "Frente de Caixa";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmFrenteCaixa_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbImagem)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbProduto;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.TextBox tbValorUnitario;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pbImagem;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbValorTotal;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbTotalCompra;
		private System.Windows.Forms.ListBox lbPedido;
		private System.Windows.Forms.Label lbCaixa;
		private System.Windows.Forms.Label lbUsuario;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label lbData;
		private System.Windows.Forms.Label lbHora;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btLimpar;
		private System.Windows.Forms.Button btExcluir;
	}
}

