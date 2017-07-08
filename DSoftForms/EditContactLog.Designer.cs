namespace DSoftForms
{
	partial class EditContactLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditContactLog));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.formulárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbLead = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lbCidadeEstado = new System.Windows.Forms.Label();
			this.tbMotivo = new System.Windows.Forms.TextBox();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.tbConclusao = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gbTemperatura = new System.Windows.Forms.GroupBox();
			this.rbCliente = new System.Windows.Forms.RadioButton();
			this.rbPerdido = new System.Windows.Forms.RadioButton();
			this.rbQuente = new System.Windows.Forms.RadioButton();
			this.rbMorno = new System.Windows.Forms.RadioButton();
			this.rbFrio = new System.Windows.Forms.RadioButton();
			this.gbRetorno = new System.Windows.Forms.GroupBox();
			this.cbAlerta = new System.Windows.Forms.CheckBox();
			this.dtHora = new System.Windows.Forms.DateTimePicker();
			this.dtRetorno = new System.Windows.Forms.DateTimePicker();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.cbRetorno = new System.Windows.Forms.CheckBox();
			this.lbErroLead = new System.Windows.Forms.Label();
			this.lbErroMotivo = new System.Windows.Forms.Label();
			this.lbErroDescricao = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.gbTemperatura.SuspendLayout();
			this.gbRetorno.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulárioToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(677, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// formulárioToolStripMenuItem
			// 
			this.formulárioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.formulárioToolStripMenuItem.Name = "formulárioToolStripMenuItem";
			this.formulárioToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.formulárioToolStripMenuItem.Text = "&Formulário";
			// 
			// confirmarToolStripMenuItem
			// 
			this.confirmarToolStripMenuItem.Name = "confirmarToolStripMenuItem";
			this.confirmarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.confirmarToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.confirmarToolStripMenuItem.Text = "&Confirmar";
			this.confirmarToolStripMenuItem.Click += new System.EventHandler(this.confirmarToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// cbLead
			// 
			this.cbLead.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbLead.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbLead.FormattingEnabled = true;
			this.cbLead.Location = new System.Drawing.Point(12, 53);
			this.cbLead.Name = "cbLead";
			this.cbLead.Size = new System.Drawing.Size(240, 21);
			this.cbLead.Sorted = true;
			this.cbLead.TabIndex = 1;
			this.cbLead.SelectedValueChanged += new System.EventHandler(this.cbLead_SelectedValueChanged);
			this.cbLead.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbLead_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Lead";
			// 
			// lbCidadeEstado
			// 
			this.lbCidadeEstado.AutoSize = true;
			this.lbCidadeEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbCidadeEstado.ForeColor = System.Drawing.Color.MidnightBlue;
			this.lbCidadeEstado.Location = new System.Drawing.Point(258, 56);
			this.lbCidadeEstado.Name = "lbCidadeEstado";
			this.lbCidadeEstado.Size = new System.Drawing.Size(0, 15);
			this.lbCidadeEstado.TabIndex = 3;
			// 
			// tbMotivo
			// 
			this.tbMotivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbMotivo.Location = new System.Drawing.Point(12, 93);
			this.tbMotivo.Name = "tbMotivo";
			this.tbMotivo.Size = new System.Drawing.Size(652, 20);
			this.tbMotivo.TabIndex = 4;
			this.tbMotivo.TextChanged += new System.EventHandler(this.tbMotivo_TextChanged);
			this.tbMotivo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbMotivo_KeyUp);
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(12, 132);
			this.tbDescricao.Multiline = true;
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDescricao.Size = new System.Drawing.Size(652, 83);
			this.tbDescricao.TabIndex = 5;
			this.tbDescricao.TextChanged += new System.EventHandler(this.tbDescricao_TextChanged);
			// 
			// tbConclusao
			// 
			this.tbConclusao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbConclusao.Location = new System.Drawing.Point(12, 234);
			this.tbConclusao.Name = "tbConclusao";
			this.tbConclusao.Size = new System.Drawing.Size(652, 20);
			this.tbConclusao.TabIndex = 6;
			this.tbConclusao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbConclusao_KeyUp);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Motivo";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Descrição";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 218);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(57, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Conclusão";
			// 
			// gbTemperatura
			// 
			this.gbTemperatura.Controls.Add(this.rbCliente);
			this.gbTemperatura.Controls.Add(this.rbPerdido);
			this.gbTemperatura.Controls.Add(this.rbQuente);
			this.gbTemperatura.Controls.Add(this.rbMorno);
			this.gbTemperatura.Controls.Add(this.rbFrio);
			this.gbTemperatura.Location = new System.Drawing.Point(12, 260);
			this.gbTemperatura.Name = "gbTemperatura";
			this.gbTemperatura.Size = new System.Drawing.Size(128, 136);
			this.gbTemperatura.TabIndex = 10;
			this.gbTemperatura.TabStop = false;
			this.gbTemperatura.Text = "Temperatura";
			// 
			// rbCliente
			// 
			this.rbCliente.AutoSize = true;
			this.rbCliente.Location = new System.Drawing.Point(6, 111);
			this.rbCliente.Name = "rbCliente";
			this.rbCliente.Size = new System.Drawing.Size(57, 17);
			this.rbCliente.TabIndex = 11;
			this.rbCliente.Text = "Cliente";
			this.rbCliente.UseVisualStyleBackColor = true;
			// 
			// rbPerdido
			// 
			this.rbPerdido.AutoSize = true;
			this.rbPerdido.Location = new System.Drawing.Point(6, 88);
			this.rbPerdido.Name = "rbPerdido";
			this.rbPerdido.Size = new System.Drawing.Size(61, 17);
			this.rbPerdido.TabIndex = 3;
			this.rbPerdido.Text = "Perdido";
			this.rbPerdido.UseVisualStyleBackColor = true;
			// 
			// rbQuente
			// 
			this.rbQuente.AutoSize = true;
			this.rbQuente.Location = new System.Drawing.Point(6, 65);
			this.rbQuente.Name = "rbQuente";
			this.rbQuente.Size = new System.Drawing.Size(60, 17);
			this.rbQuente.TabIndex = 2;
			this.rbQuente.Text = "Quente";
			this.rbQuente.UseVisualStyleBackColor = true;
			// 
			// rbMorno
			// 
			this.rbMorno.AutoSize = true;
			this.rbMorno.Location = new System.Drawing.Point(6, 42);
			this.rbMorno.Name = "rbMorno";
			this.rbMorno.Size = new System.Drawing.Size(55, 17);
			this.rbMorno.TabIndex = 1;
			this.rbMorno.Text = "Morno";
			this.rbMorno.UseVisualStyleBackColor = true;
			// 
			// rbFrio
			// 
			this.rbFrio.AutoSize = true;
			this.rbFrio.Checked = true;
			this.rbFrio.Location = new System.Drawing.Point(6, 19);
			this.rbFrio.Name = "rbFrio";
			this.rbFrio.Size = new System.Drawing.Size(42, 17);
			this.rbFrio.TabIndex = 0;
			this.rbFrio.TabStop = true;
			this.rbFrio.Text = "Frio";
			this.rbFrio.UseVisualStyleBackColor = true;
			// 
			// gbRetorno
			// 
			this.gbRetorno.Controls.Add(this.cbRetorno);
			this.gbRetorno.Controls.Add(this.cbAlerta);
			this.gbRetorno.Controls.Add(this.dtHora);
			this.gbRetorno.Controls.Add(this.dtRetorno);
			this.gbRetorno.Location = new System.Drawing.Point(443, 260);
			this.gbRetorno.Name = "gbRetorno";
			this.gbRetorno.Size = new System.Drawing.Size(222, 95);
			this.gbRetorno.TabIndex = 11;
			this.gbRetorno.TabStop = false;
			this.gbRetorno.Text = "Retorno";
			// 
			// cbAlerta
			// 
			this.cbAlerta.AutoSize = true;
			this.cbAlerta.Location = new System.Drawing.Point(6, 68);
			this.cbAlerta.Name = "cbAlerta";
			this.cbAlerta.Size = new System.Drawing.Size(76, 17);
			this.cbAlerta.TabIndex = 2;
			this.cbAlerta.Text = "Criar alerta";
			this.cbAlerta.UseVisualStyleBackColor = true;
			// 
			// dtHora
			// 
			this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtHora.Location = new System.Drawing.Point(112, 42);
			this.dtHora.Name = "dtHora";
			this.dtHora.Size = new System.Drawing.Size(100, 20);
			this.dtHora.TabIndex = 1;
			// 
			// dtRetorno
			// 
			this.dtRetorno.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtRetorno.Location = new System.Drawing.Point(6, 42);
			this.dtRetorno.Name = "dtRetorno";
			this.dtRetorno.Size = new System.Drawing.Size(100, 20);
			this.dtRetorno.TabIndex = 0;
			// 
			// btConfirmar
			// 
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(413, 361);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 12;
			this.btConfirmar.Text = "&Confirmar F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(542, 361);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 13;
			this.btSair.Text = "&Sair F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// cbRetorno
			// 
			this.cbRetorno.AutoSize = true;
			this.cbRetorno.Location = new System.Drawing.Point(6, 20);
			this.cbRetorno.Name = "cbRetorno";
			this.cbRetorno.Size = new System.Drawing.Size(67, 17);
			this.cbRetorno.TabIndex = 3;
			this.cbRetorno.Text = "Retornar";
			this.cbRetorno.UseVisualStyleBackColor = true;
			// 
			// lbErroLead
			// 
			this.lbErroLead.AutoSize = true;
			this.lbErroLead.ForeColor = System.Drawing.Color.Red;
			this.lbErroLead.Location = new System.Drawing.Point(44, 37);
			this.lbErroLead.Name = "lbErroLead";
			this.lbErroLead.Size = new System.Drawing.Size(99, 13);
			this.lbErroLead.TabIndex = 14;
			this.lbErroLead.Text = "* Campo obrigatório";
			this.lbErroLead.Visible = false;
			// 
			// lbErroMotivo
			// 
			this.lbErroMotivo.AutoSize = true;
			this.lbErroMotivo.ForeColor = System.Drawing.Color.Red;
			this.lbErroMotivo.Location = new System.Drawing.Point(57, 77);
			this.lbErroMotivo.Name = "lbErroMotivo";
			this.lbErroMotivo.Size = new System.Drawing.Size(99, 13);
			this.lbErroMotivo.TabIndex = 15;
			this.lbErroMotivo.Text = "* Campo obrigatório";
			this.lbErroMotivo.Visible = false;
			// 
			// lbErroDescricao
			// 
			this.lbErroDescricao.AutoSize = true;
			this.lbErroDescricao.ForeColor = System.Drawing.Color.Red;
			this.lbErroDescricao.Location = new System.Drawing.Point(73, 116);
			this.lbErroDescricao.Name = "lbErroDescricao";
			this.lbErroDescricao.Size = new System.Drawing.Size(99, 13);
			this.lbErroDescricao.TabIndex = 16;
			this.lbErroDescricao.Text = "* Campo obrigatório";
			this.lbErroDescricao.Visible = false;
			// 
			// EditContactLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(677, 418);
			this.Controls.Add(this.lbErroDescricao);
			this.Controls.Add(this.lbErroMotivo);
			this.Controls.Add(this.lbErroLead);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.gbRetorno);
			this.Controls.Add(this.gbTemperatura);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbConclusao);
			this.Controls.Add(this.tbDescricao);
			this.Controls.Add(this.tbMotivo);
			this.Controls.Add(this.lbCidadeEstado);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbLead);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "EditContactLog";
			this.Text = "Formulário de contato";
			this.Load += new System.EventHandler(this.EditContactLog_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.gbTemperatura.ResumeLayout(false);
			this.gbTemperatura.PerformLayout();
			this.gbRetorno.ResumeLayout(false);
			this.gbRetorno.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem formulárioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbLead;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbCidadeEstado;
		private System.Windows.Forms.TextBox tbMotivo;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.TextBox tbConclusao;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox gbTemperatura;
		private System.Windows.Forms.RadioButton rbCliente;
		private System.Windows.Forms.RadioButton rbPerdido;
		private System.Windows.Forms.RadioButton rbQuente;
		private System.Windows.Forms.RadioButton rbMorno;
		private System.Windows.Forms.RadioButton rbFrio;
		private System.Windows.Forms.GroupBox gbRetorno;
		private System.Windows.Forms.CheckBox cbAlerta;
		private System.Windows.Forms.DateTimePicker dtHora;
		private System.Windows.Forms.DateTimePicker dtRetorno;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.CheckBox cbRetorno;
		private System.Windows.Forms.Label lbErroLead;
		private System.Windows.Forms.Label lbErroMotivo;
		private System.Windows.Forms.Label lbErroDescricao;
	}
}