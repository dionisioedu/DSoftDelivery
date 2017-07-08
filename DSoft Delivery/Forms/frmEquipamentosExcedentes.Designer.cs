namespace DSoft_Delivery.Forms
{
	partial class frmEquipamentosExcedentes
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipamentosExcedentes));
			this.tbFuncionario = new System.Windows.Forms.TextBox();
			this.lbExcedentes = new System.Windows.Forms.ListBox();
			this.lbAbatimentos = new System.Windows.Forms.ListBox();
			this.btAdicionar = new System.Windows.Forms.Button();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbFuncionario
			// 
			this.tbFuncionario.Location = new System.Drawing.Point(12, 31);
			this.tbFuncionario.Name = "tbFuncionario";
			this.tbFuncionario.ReadOnly = true;
			this.tbFuncionario.Size = new System.Drawing.Size(300, 20);
			this.tbFuncionario.TabIndex = 0;
			// 
			// lbExcedentes
			// 
			this.lbExcedentes.FormattingEnabled = true;
			this.lbExcedentes.Location = new System.Drawing.Point(12, 100);
			this.lbExcedentes.Name = "lbExcedentes";
			this.lbExcedentes.Size = new System.Drawing.Size(249, 238);
			this.lbExcedentes.TabIndex = 1;
			// 
			// lbAbatimentos
			// 
			this.lbAbatimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbAbatimentos.FormattingEnabled = true;
			this.lbAbatimentos.Location = new System.Drawing.Point(348, 100);
			this.lbAbatimentos.Name = "lbAbatimentos";
			this.lbAbatimentos.Size = new System.Drawing.Size(249, 238);
			this.lbAbatimentos.TabIndex = 2;
			// 
			// btAdicionar
			// 
			this.btAdicionar.Location = new System.Drawing.Point(267, 100);
			this.btAdicionar.Name = "btAdicionar";
			this.btAdicionar.Size = new System.Drawing.Size(75, 23);
			this.btAdicionar.TabIndex = 3;
			this.btAdicionar.Text = ">";
			this.btAdicionar.UseVisualStyleBackColor = true;
			this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btConfirmar.Location = new System.Drawing.Point(441, 344);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 4;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.Location = new System.Drawing.Point(522, 344);
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
			this.label1.Location = new System.Drawing.Point(12, 84);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(132, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Equipamentos excedentes";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(345, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Abatimentos";
			// 
			// frmEquipamentosExcedentes
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 379);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.btAdicionar);
			this.Controls.Add(this.lbAbatimentos);
			this.Controls.Add(this.lbExcedentes);
			this.Controls.Add(this.tbFuncionario);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEquipamentosExcedentes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Equipamentos excedentes";
			this.Load += new System.EventHandler(this.frmEquipamentosExcedentes_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbFuncionario;
		private System.Windows.Forms.ListBox lbExcedentes;
		private System.Windows.Forms.ListBox lbAbatimentos;
		private System.Windows.Forms.Button btAdicionar;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}