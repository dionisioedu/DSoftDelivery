namespace DSoft_Delivery.Forms
{
	partial class frmCadAdicionaisRapido
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadAdicionaisRapido));
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.btConfirma = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(12, 45);
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.Size = new System.Drawing.Size(240, 20);
			this.tbDescricao.TabIndex = 0;
			this.tbDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDescricao_KeyDown);
			// 
			// tbValor
			// 
			this.tbValor.Location = new System.Drawing.Point(286, 45);
			this.tbValor.Name = "tbValor";
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 1;
			this.tbValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbValor_KeyDown);
			// 
			// btConfirma
			// 
			this.btConfirma.Location = new System.Drawing.Point(392, 43);
			this.btConfirma.Name = "btConfirma";
			this.btConfirma.Size = new System.Drawing.Size(75, 23);
			this.btConfirma.TabIndex = 2;
			this.btConfirma.Text = "Confirma";
			this.btConfirma.UseVisualStyleBackColor = true;
			this.btConfirma.Click += new System.EventHandler(this.btConfirma_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Descrição";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(283, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(31, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Valor";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(259, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "R$";
			// 
			// frmCadAdicionaisRapido
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(479, 99);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btConfirma);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.tbDescricao);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCadAdicionaisRapido";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Item Adicional";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCadAdicionaisRapido_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Button btConfirma;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
	}
}