namespace DSoft_Delivery.Forms
{
	partial class frmCalendarioDeTabelas
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalendarioDeTabelas));
			this.cbGerenciarCalendario = new System.Windows.Forms.CheckBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.calendárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbDomingo = new System.Windows.Forms.ComboBox();
			this.cbSegunda = new System.Windows.Forms.ComboBox();
			this.cbTerca = new System.Windows.Forms.ComboBox();
			this.cbQuarta = new System.Windows.Forms.ComboBox();
			this.cbQuinta = new System.Windows.Forms.ComboBox();
			this.cbSexta = new System.Windows.Forms.ComboBox();
			this.cbSabado = new System.Windows.Forms.ComboBox();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbGerenciarCalendario
			// 
			this.cbGerenciarCalendario.AutoSize = true;
			this.cbGerenciarCalendario.Location = new System.Drawing.Point(12, 27);
			this.cbGerenciarCalendario.Name = "cbGerenciarCalendario";
			this.cbGerenciarCalendario.Size = new System.Drawing.Size(226, 17);
			this.cbGerenciarCalendario.TabIndex = 0;
			this.cbGerenciarCalendario.Text = "Gerenciar calendário de tabelas de preços";
			this.cbGerenciarCalendario.UseVisualStyleBackColor = true;
			this.cbGerenciarCalendario.CheckedChanged += new System.EventHandler(this.cbGerenciarCalendario_CheckedChanged);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendárioToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(380, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// calendárioToolStripMenuItem
			// 
			this.calendárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.sairToolStripMenuItem});
			this.calendárioToolStripMenuItem.Name = "calendárioToolStripMenuItem";
			this.calendárioToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
			this.calendárioToolStripMenuItem.Text = "Calendário";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.confirmarToolStripMenuItem.Text = "Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.sairToolStripMenuItem.Text = "Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbDomingo
			// 
			this.cbDomingo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbDomingo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbDomingo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDomingo.FormattingEnabled = true;
			this.cbDomingo.Location = new System.Drawing.Point(158, 77);
			this.cbDomingo.Name = "cbDomingo";
			this.cbDomingo.Size = new System.Drawing.Size(210, 21);
			this.cbDomingo.TabIndex = 2;
			// 
			// cbSegunda
			// 
			this.cbSegunda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbSegunda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbSegunda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSegunda.FormattingEnabled = true;
			this.cbSegunda.Location = new System.Drawing.Point(158, 104);
			this.cbSegunda.Name = "cbSegunda";
			this.cbSegunda.Size = new System.Drawing.Size(210, 21);
			this.cbSegunda.TabIndex = 3;
			// 
			// cbTerca
			// 
			this.cbTerca.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbTerca.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbTerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTerca.FormattingEnabled = true;
			this.cbTerca.Location = new System.Drawing.Point(158, 131);
			this.cbTerca.Name = "cbTerca";
			this.cbTerca.Size = new System.Drawing.Size(210, 21);
			this.cbTerca.TabIndex = 4;
			// 
			// cbQuarta
			// 
			this.cbQuarta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbQuarta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbQuarta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbQuarta.FormattingEnabled = true;
			this.cbQuarta.Location = new System.Drawing.Point(158, 158);
			this.cbQuarta.Name = "cbQuarta";
			this.cbQuarta.Size = new System.Drawing.Size(210, 21);
			this.cbQuarta.TabIndex = 5;
			// 
			// cbQuinta
			// 
			this.cbQuinta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbQuinta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbQuinta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbQuinta.FormattingEnabled = true;
			this.cbQuinta.Location = new System.Drawing.Point(158, 185);
			this.cbQuinta.Name = "cbQuinta";
			this.cbQuinta.Size = new System.Drawing.Size(210, 21);
			this.cbQuinta.TabIndex = 6;
			// 
			// cbSexta
			// 
			this.cbSexta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbSexta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbSexta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSexta.FormattingEnabled = true;
			this.cbSexta.Location = new System.Drawing.Point(158, 212);
			this.cbSexta.Name = "cbSexta";
			this.cbSexta.Size = new System.Drawing.Size(210, 21);
			this.cbSexta.TabIndex = 7;
			// 
			// cbSabado
			// 
			this.cbSabado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbSabado.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbSabado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSabado.FormattingEnabled = true;
			this.cbSabado.Location = new System.Drawing.Point(158, 239);
			this.cbSabado.Name = "cbSabado";
			this.cbSabado.Size = new System.Drawing.Size(210, 21);
			this.cbSabado.TabIndex = 8;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Location = new System.Drawing.Point(202, 302);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(85, 23);
			this.btConfirmar.TabIndex = 9;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Location = new System.Drawing.Point(293, 302);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 10;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(103, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "Domingo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(79, 107);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "Segunda-feira";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(94, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(58, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Terça-feira";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(90, 161);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(62, 13);
			this.label4.TabIndex = 14;
			this.label4.Text = "Quarta-feira";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(91, 188);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(61, 13);
			this.label5.TabIndex = 15;
			this.label5.Text = "Quinta-feira";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(95, 215);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(57, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "Sexta-feira";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(105, 244);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(44, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Sábado";
			// 
			// frmCalendarioDeTabelas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(380, 337);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.cbSabado);
			this.Controls.Add(this.cbSexta);
			this.Controls.Add(this.cbQuinta);
			this.Controls.Add(this.cbQuarta);
			this.Controls.Add(this.cbTerca);
			this.Controls.Add(this.cbSegunda);
			this.Controls.Add(this.cbDomingo);
			this.Controls.Add(this.cbGerenciarCalendario);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmCalendarioDeTabelas";
			this.ShowInTaskbar = false;
			this.Text = "Calendário de tabelas de preços";
			this.Load += new System.EventHandler(this.frmCalendarioDeTabelas_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbGerenciarCalendario;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem calendárioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbDomingo;
		private System.Windows.Forms.ComboBox cbSegunda;
		private System.Windows.Forms.ComboBox cbTerca;
		private System.Windows.Forms.ComboBox cbQuarta;
		private System.Windows.Forms.ComboBox cbQuinta;
		private System.Windows.Forms.ComboBox cbSexta;
		private System.Windows.Forms.ComboBox cbSabado;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}