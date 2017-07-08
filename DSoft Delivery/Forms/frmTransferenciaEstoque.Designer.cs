namespace DSoft_Delivery.Forms
{
	partial class frmTransferenciaEstoque
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferenciaEstoque));
			this.cbFilial = new System.Windows.Forms.ComboBox();
			this.tbEquipamento = new System.Windows.Forms.TextBox();
			this.lbEquipamentos = new System.Windows.Forms.ListBox();
			this.btExcluir = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbFilial
			// 
			this.cbFilial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFilial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFilial.FormattingEnabled = true;
			this.cbFilial.Location = new System.Drawing.Point(12, 41);
			this.cbFilial.Name = "cbFilial";
			this.cbFilial.Size = new System.Drawing.Size(200, 21);
			this.cbFilial.TabIndex = 0;
			this.cbFilial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFilial_KeyDown);
			// 
			// tbEquipamento
			// 
			this.tbEquipamento.Location = new System.Drawing.Point(12, 116);
			this.tbEquipamento.Name = "tbEquipamento";
			this.tbEquipamento.Size = new System.Drawing.Size(147, 20);
			this.tbEquipamento.TabIndex = 1;
			this.tbEquipamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEquipamento_KeyDown);
			// 
			// lbEquipamentos
			// 
			this.lbEquipamentos.FormattingEnabled = true;
			this.lbEquipamentos.Location = new System.Drawing.Point(165, 116);
			this.lbEquipamentos.Name = "lbEquipamentos";
			this.lbEquipamentos.Size = new System.Drawing.Size(207, 303);
			this.lbEquipamentos.TabIndex = 2;
			// 
			// btExcluir
			// 
			this.btExcluir.Location = new System.Drawing.Point(216, 425);
			this.btExcluir.Name = "btExcluir";
			this.btExcluir.Size = new System.Drawing.Size(75, 23);
			this.btExcluir.TabIndex = 3;
			this.btExcluir.Text = "&Excluir item";
			this.btExcluir.UseVisualStyleBackColor = true;
			this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(297, 425);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 4;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(378, 425);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 5;
			this.btSair.Text = "&Sair";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Filial";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 100);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Equipamento";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(162, 100);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(162, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Equipamentos para transferência";
			// 
			// frmTransferenciaEstoque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 456);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.btExcluir);
			this.Controls.Add(this.lbEquipamentos);
			this.Controls.Add(this.tbEquipamento);
			this.Controls.Add(this.cbFilial);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmTransferenciaEstoque";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Transferência de estoque entre filiais";
			this.Load += new System.EventHandler(this.frmTransferenciaEstoque_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbFilial;
		private System.Windows.Forms.TextBox tbEquipamento;
		private System.Windows.Forms.ListBox lbEquipamentos;
		private System.Windows.Forms.Button btExcluir;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}