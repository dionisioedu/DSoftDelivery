namespace DSoft_Delivery
{
	partial class CapturaCodigo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapturaCodigo));
			this.lbTexto = new System.Windows.Forms.Label();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbTexto
			// 
			this.lbTexto.AutoSize = true;
			this.lbTexto.Location = new System.Drawing.Point(27, 77);
			this.lbTexto.Name = "lbTexto";
			this.lbTexto.Size = new System.Drawing.Size(35, 13);
			this.lbTexto.TabIndex = 0;
			this.lbTexto.Text = "label1";
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(30, 110);
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(100, 20);
			this.tbCodigo.TabIndex = 1;
			this.tbCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCodigo_KeyDown);
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(20, 207);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 2;
			this.btConfirmar.Text = "&Confirmar";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.button1_Click);
			// 
			// btCancelar
			// 
			this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btCancelar.Location = new System.Drawing.Point(149, 207);
			this.btCancelar.Name = "btCancelar";
			this.btCancelar.Size = new System.Drawing.Size(123, 45);
			this.btCancelar.TabIndex = 3;
			this.btCancelar.Text = "C&ancelar";
			this.btCancelar.UseVisualStyleBackColor = true;
			this.btCancelar.Click += new System.EventHandler(this.button2_Click);
			// 
			// frmCapturaCodigo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 264);
			this.ControlBox = false;
			this.Controls.Add(this.btCancelar);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.lbTexto);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCapturaCodigo";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "frmCapturaCodigo";
			this.Load += new System.EventHandler(this.frmCapturaCodigo_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbTexto;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btCancelar;
	}
}