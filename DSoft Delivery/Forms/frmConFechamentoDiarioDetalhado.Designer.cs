namespace DSoft_Delivery.Forms
{
	partial class frmConFechamentoDiarioDetalhado
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConFechamentoDiarioDetalhado));
			this.dtData = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btConsultar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.btImprmir = new System.Windows.Forms.Button();
			this.btExportar = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dtData
			// 
			this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtData.Location = new System.Drawing.Point(12, 44);
			this.dtData.Name = "dtData";
			this.dtData.Size = new System.Drawing.Size(100, 20);
			this.dtData.TabIndex = 0;
			this.dtData.ValueChanged += new System.EventHandler(this.dtData_ValueChanged);
			this.dtData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtData_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Data do fechamento";
			// 
			// btConsultar
			// 
			this.btConsultar.Location = new System.Drawing.Point(118, 41);
			this.btConsultar.Name = "btConsultar";
			this.btConsultar.Size = new System.Drawing.Size(75, 23);
			this.btConsultar.TabIndex = 2;
			this.btConsultar.Text = "&Consultar";
			this.btConsultar.UseVisualStyleBackColor = true;
			this.btConsultar.Click += new System.EventHandler(this.btConsultar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(199, 41);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 3;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// btImprmir
			// 
			this.btImprmir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btImprmir.Location = new System.Drawing.Point(12, 466);
			this.btImprmir.Name = "btImprmir";
			this.btImprmir.Size = new System.Drawing.Size(75, 23);
			this.btImprmir.TabIndex = 4;
			this.btImprmir.Text = "&Imprimir";
			this.btImprmir.UseVisualStyleBackColor = true;
			this.btImprmir.Click += new System.EventHandler(this.btImprmir_Click);
			// 
			// btExportar
			// 
			this.btExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btExportar.Enabled = false;
			this.btExportar.Location = new System.Drawing.Point(93, 466);
			this.btExportar.Name = "btExportar";
			this.btExportar.Size = new System.Drawing.Size(75, 23);
			this.btExportar.TabIndex = 5;
			this.btExportar.Text = "&Exportar";
			this.btExportar.UseVisualStyleBackColor = true;
			this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 70);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(455, 390);
			this.dataGridView1.TabIndex = 6;
			// 
			// frmConFechamentoDiarioDetalhado
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 501);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btExportar);
			this.Controls.Add(this.btImprmir);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConsultar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dtData);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConFechamentoDiarioDetalhado";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Fechamento diário detalhado";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btConsultar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Button btImprmir;
		private System.Windows.Forms.Button btExportar;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}