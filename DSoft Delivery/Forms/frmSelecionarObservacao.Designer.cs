namespace DSoft_Delivery.Forms
{
	partial class frmSelecionarObservacao
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionarObservacao));
			this.clObservacoes = new System.Windows.Forms.CheckedListBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// clObservacoes
			// 
			this.clObservacoes.FormattingEnabled = true;
			this.clObservacoes.Location = new System.Drawing.Point(12, 12);
			this.clObservacoes.Name = "clObservacoes";
			this.clObservacoes.Size = new System.Drawing.Size(322, 319);
			this.clObservacoes.TabIndex = 0;
			this.clObservacoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clObservacoes_KeyDown);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(259, 339);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(75, 23);
			this.btConfirmar.TabIndex = 1;
			this.btConfirmar.Text = "&Confirmar F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// frmSelecionarObservacao
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 374);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.clObservacoes);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSelecionarObservacao";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Observação";
			this.Load += new System.EventHandler(this.frmSelecionarObservacao_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox clObservacoes;
		private System.Windows.Forms.Button btConfirmar;
	}
}