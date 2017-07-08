namespace DSoft_Delivery.Forms
{
	partial class frmConfirmarUsoEquipamentos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfirmarUsoEquipamentos));
			this.cbFuncionario = new System.Windows.Forms.ComboBox();
			this.lbOrdensDeServico = new System.Windows.Forms.ListBox();
			this.clEquipamentosUtilizados = new System.Windows.Forms.CheckedListBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbFuncionario
			// 
			this.cbFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFuncionario.FormattingEnabled = true;
			this.cbFuncionario.Location = new System.Drawing.Point(12, 36);
			this.cbFuncionario.Name = "cbFuncionario";
			this.cbFuncionario.Size = new System.Drawing.Size(300, 21);
			this.cbFuncionario.TabIndex = 0;
			this.cbFuncionario.SelectedIndexChanged += new System.EventHandler(this.cbFuncionario_SelectedIndexChanged);
			// 
			// lbOrdensDeServico
			// 
			this.lbOrdensDeServico.FormattingEnabled = true;
			this.lbOrdensDeServico.Location = new System.Drawing.Point(12, 97);
			this.lbOrdensDeServico.Name = "lbOrdensDeServico";
			this.lbOrdensDeServico.Size = new System.Drawing.Size(120, 264);
			this.lbOrdensDeServico.TabIndex = 1;
			this.lbOrdensDeServico.SelectedIndexChanged += new System.EventHandler(this.lbOrdensDeServico_SelectedIndexChanged);
			// 
			// clEquipamentosUtilizados
			// 
			this.clEquipamentosUtilizados.FormattingEnabled = true;
			this.clEquipamentosUtilizados.Location = new System.Drawing.Point(138, 97);
			this.clEquipamentosUtilizados.Name = "clEquipamentosUtilizados";
			this.clEquipamentosUtilizados.Size = new System.Drawing.Size(257, 274);
			this.clEquipamentosUtilizados.TabIndex = 2;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(401, 97);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 3;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(401, 348);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 4;
			this.btSair.Text = "&Sair";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Funcionário";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Ordens de serviço";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(135, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Equipamentos utilizados";
			// 
			// frmConfirmarUsoEquipamentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(489, 382);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.clEquipamentosUtilizados);
			this.Controls.Add(this.lbOrdensDeServico);
			this.Controls.Add(this.cbFuncionario);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmConfirmarUsoEquipamentos";
			this.ShowInTaskbar = false;
			this.Text = "Confirmar uso de equipamentos";
			this.Load += new System.EventHandler(this.frmConfirmarUsoEquipamentos_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbFuncionario;
		private System.Windows.Forms.ListBox lbOrdensDeServico;
		private System.Windows.Forms.CheckedListBox clEquipamentosUtilizados;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}