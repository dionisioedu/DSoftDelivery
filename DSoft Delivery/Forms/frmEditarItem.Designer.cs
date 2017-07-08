namespace DSoft_Delivery.Forms
{
	partial class frmEditarItem
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarItem));
			this.tbProduto = new System.Windows.Forms.TextBox();
			this.tbQuantidade = new System.Windows.Forms.TextBox();
			this.tbPreco = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.clAdicionais = new System.Windows.Forms.CheckedListBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.tbObs = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// tbProduto
			// 
			this.tbProduto.Location = new System.Drawing.Point(12, 43);
			this.tbProduto.Name = "tbProduto";
			this.tbProduto.ReadOnly = true;
			this.tbProduto.Size = new System.Drawing.Size(210, 20);
			this.tbProduto.TabIndex = 0;
			this.tbProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbProduto_KeyDown);
			// 
			// tbQuantidade
			// 
			this.tbQuantidade.Location = new System.Drawing.Point(228, 43);
			this.tbQuantidade.Name = "tbQuantidade";
			this.tbQuantidade.ReadOnly = true;
			this.tbQuantidade.Size = new System.Drawing.Size(60, 20);
			this.tbQuantidade.TabIndex = 1;
			this.tbQuantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbPreco
			// 
			this.tbPreco.Location = new System.Drawing.Point(321, 43);
			this.tbPreco.Name = "tbPreco";
			this.tbPreco.ReadOnly = true;
			this.tbPreco.Size = new System.Drawing.Size(100, 20);
			this.tbPreco.TabIndex = 2;
			this.tbPreco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Produto";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(225, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Quantidade";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(294, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "R$";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(318, 27);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Preço";
			// 
			// clAdicionais
			// 
			this.clAdicionais.FormattingEnabled = true;
			this.clAdicionais.Location = new System.Drawing.Point(12, 94);
			this.clAdicionais.Name = "clAdicionais";
			this.clAdicionais.Size = new System.Drawing.Size(275, 154);
			this.clAdicionais.TabIndex = 7;
			this.clAdicionais.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clAdicionais_ItemCheck);
			this.clAdicionais.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clAdicionais_KeyDown);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(207, 78);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(81, 13);
			this.linkLabel1.TabIndex = 8;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Itens Adicionais";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// tbObs
			// 
			this.tbObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbObs.Location = new System.Drawing.Point(12, 254);
			this.tbObs.Multiline = true;
			this.tbObs.Name = "tbObs";
			this.tbObs.Size = new System.Drawing.Size(275, 66);
			this.tbObs.TabIndex = 9;
			this.tbObs.TextChanged += new System.EventHandler(this.tbObs_TextChanged);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(346, 297);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 10;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// frmEditarItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(433, 332);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbObs);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.clAdicionais);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbPreco);
			this.Controls.Add(this.tbQuantidade);
			this.Controls.Add(this.tbProduto);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEditarItem";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Editar item";
			this.Load += new System.EventHandler(this.frmEditarItem_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditarItem_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbProduto;
		private System.Windows.Forms.TextBox tbQuantidade;
		private System.Windows.Forms.TextBox tbPreco;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox clAdicionais;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.TextBox tbObs;
		private System.Windows.Forms.Button btConfirmar;
	}
}