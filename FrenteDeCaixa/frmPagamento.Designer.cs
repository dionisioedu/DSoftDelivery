namespace FrenteDeCaixa
{
	partial class frmPagamento
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbFormaPagamento = new System.Windows.Forms.ComboBox();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbPago = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbTroco = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "X";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft MHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(90, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 26);
			this.label2.TabIndex = 1;
			this.label2.Text = "Pagamento";
			// 
			// cbFormaPagamento
			// 
			this.cbFormaPagamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFormaPagamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFormaPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbFormaPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbFormaPagamento.FormattingEnabled = true;
			this.cbFormaPagamento.Location = new System.Drawing.Point(50, 125);
			this.cbFormaPagamento.Name = "cbFormaPagamento";
			this.cbFormaPagamento.Size = new System.Drawing.Size(203, 28);
			this.cbFormaPagamento.TabIndex = 2;
			this.cbFormaPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFormaPagamento_KeyDown);
			// 
			// tbTotal
			// 
			this.tbTotal.BackColor = System.Drawing.Color.White;
			this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTotal.Location = new System.Drawing.Point(97, 181);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(125, 26);
			this.tbTotal.TabIndex = 3;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft MHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(56, 180);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 26);
			this.label3.TabIndex = 4;
			this.label3.Text = "R$";
			// 
			// tbPago
			// 
			this.tbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPago.Location = new System.Drawing.Point(97, 236);
			this.tbPago.Name = "tbPago";
			this.tbPago.Size = new System.Drawing.Size(125, 26);
			this.tbPago.TabIndex = 5;
			this.tbPago.Text = "0,00";
			this.tbPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbPago.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPago_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft MHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(56, 290);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 26);
			this.label5.TabIndex = 8;
			this.label5.Text = "R$";
			// 
			// tbTroco
			// 
			this.tbTroco.BackColor = System.Drawing.Color.White;
			this.tbTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTroco.ForeColor = System.Drawing.Color.DarkRed;
			this.tbTroco.Location = new System.Drawing.Point(97, 291);
			this.tbTroco.Name = "tbTroco";
			this.tbTroco.ReadOnly = true;
			this.tbTroco.Size = new System.Drawing.Size(125, 26);
			this.tbTroco.TabIndex = 7;
			this.tbTroco.Text = "0,00";
			this.tbTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbTroco.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTroco_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(191, 165);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Total";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(190, 220);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Pago";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft MHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(56, 235);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 26);
			this.label7.TabIndex = 11;
			this.label7.Text = "R$";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(187, 275);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Troco";
			// 
			// frmPagamento
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.ClientSize = new System.Drawing.Size(300, 400);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbTroco);
			this.Controls.Add(this.tbPago);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.cbFormaPagamento);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmPagamento";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pagamento";
			this.Load += new System.EventHandler(this.frmPagamento_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbFormaPagamento;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbPago;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbTroco;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
	}
}