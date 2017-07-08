namespace DSoft_Delivery.Forms
{
	partial class frmFiltroEstoque
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFiltroEstoque));
			this.cbSomenteCritico = new System.Windows.Forms.CheckBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbCodigo = new System.Windows.Forms.RadioButton();
			this.rbNome = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbSomenteCritico
			// 
			this.cbSomenteCritico.AutoSize = true;
			this.cbSomenteCritico.Location = new System.Drawing.Point(266, 48);
			this.cbSomenteCritico.Name = "cbSomenteCritico";
			this.cbSomenteCritico.Size = new System.Drawing.Size(101, 17);
			this.cbSomenteCritico.TabIndex = 3;
			this.cbSomenteCritico.Text = "Somente crítico";
			this.cbSomenteCritico.UseVisualStyleBackColor = true;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(230, 135);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 0;
			this.btConfirmar.Text = "&Confirmar F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.AutoSize = true;
			this.btSair.Location = new System.Drawing.Point(311, 135);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 1;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbNome);
			this.groupBox1.Controls.Add(this.rbCodigo);
			this.groupBox1.Location = new System.Drawing.Point(21, 29);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 69);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ordenado por";
			// 
			// rbCodigo
			// 
			this.rbCodigo.AutoSize = true;
			this.rbCodigo.Checked = true;
			this.rbCodigo.Location = new System.Drawing.Point(6, 19);
			this.rbCodigo.Name = "rbCodigo";
			this.rbCodigo.Size = new System.Drawing.Size(58, 17);
			this.rbCodigo.TabIndex = 0;
			this.rbCodigo.TabStop = true;
			this.rbCodigo.Text = "Código";
			this.rbCodigo.UseVisualStyleBackColor = true;
			// 
			// rbNome
			// 
			this.rbNome.AutoSize = true;
			this.rbNome.Location = new System.Drawing.Point(6, 42);
			this.rbNome.Name = "rbNome";
			this.rbNome.Size = new System.Drawing.Size(53, 17);
			this.rbNome.TabIndex = 1;
			this.rbNome.Text = "Nome";
			this.rbNome.UseVisualStyleBackColor = true;
			// 
			// frmFiltroEstoque
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 170);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.cbSomenteCritico);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmFiltroEstoque";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Estoque";
			this.Load += new System.EventHandler(this.frmFiltroEstoque_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFiltroEstoque_KeyDown);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbSomenteCritico;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbNome;
		private System.Windows.Forms.RadioButton rbCodigo;
	}
}