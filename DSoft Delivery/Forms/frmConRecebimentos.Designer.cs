namespace DSoft_Delivery.Forms
{
	partial class frmConRecebimentos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConRecebimentos));
			this.dtInicial = new System.Windows.Forms.DateTimePicker();
			this.dtFinal = new System.Windows.Forms.DateTimePicker();
			this.btConsultar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.btImprimir = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.tbPagas = new System.Windows.Forms.TextBox();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbAberto = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dtInicial
			// 
			this.dtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtInicial.Location = new System.Drawing.Point(12, 47);
			this.dtInicial.Name = "dtInicial";
			this.dtInicial.Size = new System.Drawing.Size(100, 20);
			this.dtInicial.TabIndex = 0;
			// 
			// dtFinal
			// 
			this.dtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtFinal.Location = new System.Drawing.Point(118, 47);
			this.dtFinal.Name = "dtFinal";
			this.dtFinal.Size = new System.Drawing.Size(100, 20);
			this.dtFinal.TabIndex = 1;
			// 
			// btConsultar
			// 
			this.btConsultar.Location = new System.Drawing.Point(224, 44);
			this.btConsultar.Name = "btConsultar";
			this.btConsultar.Size = new System.Drawing.Size(75, 23);
			this.btConsultar.TabIndex = 2;
			this.btConsultar.Text = "&Consultar";
			this.btConsultar.UseVisualStyleBackColor = true;
			this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(305, 44);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 3;
			this.btSair.Text = "&Sair";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btImprimir
			// 
			this.btImprimir.Location = new System.Drawing.Point(12, 411);
			this.btImprimir.Name = "btImprimir";
			this.btImprimir.Size = new System.Drawing.Size(75, 23);
			this.btImprimir.TabIndex = 4;
			this.btImprimir.Text = "&Imprimir";
			this.btImprimir.UseVisualStyleBackColor = true;
			this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 73);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(637, 332);
			this.dataGridView1.TabIndex = 5;
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Location = new System.Drawing.Point(224, 411);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(60, 20);
			this.tbQuantidade.TabIndex = 6;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbPagas
			// 
			this.tbPagas.Location = new System.Drawing.Point(549, 411);
			this.tbPagas.Name = "tbPagas";
			this.tbPagas.ReadOnly = true;
			this.tbPagas.Size = new System.Drawing.Size(100, 20);
			this.tbPagas.TabIndex = 7;
			this.tbPagas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbTotal
			// 
			this.tbTotal.Location = new System.Drawing.Point(549, 463);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(100, 20);
			this.tbTotal.TabIndex = 8;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Inicial";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Final";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(153, 414);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Quantidade:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(489, 414);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(54, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Pagas R$";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(495, 466);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Total R$";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(471, 440);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(72, 13);
			this.label6.TabIndex = 15;
			this.label6.Text = "Em aberto R$";
			// 
			// tbAberto
			// 
			this.tbAberto.Location = new System.Drawing.Point(549, 437);
			this.tbAberto.Name = "tbAberto";
			this.tbAberto.ReadOnly = true;
			this.tbAberto.Size = new System.Drawing.Size(100, 20);
			this.tbAberto.TabIndex = 14;
			this.tbAberto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// frmConRecebimentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(661, 509);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbAberto);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.tbPagas);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btImprimir);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConsultar);
			this.Controls.Add(this.dtFinal);
			this.Controls.Add(this.dtInicial);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConRecebimentos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta de contas à receber";
			this.Load += new System.EventHandler(this.frmConRecebimentos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtInicial;
		private System.Windows.Forms.DateTimePicker dtFinal;
		private System.Windows.Forms.Button btConsultar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btImprimir;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.TextBox tbPagas;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbAberto;
	}
}