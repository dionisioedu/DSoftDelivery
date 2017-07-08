namespace DSoft_Delivery
{
	partial class frmRecebimentos
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecebimentos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.recebimentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.confirmarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbNumero = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbValor = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dtVencimento = new System.Windows.Forms.DateTimePicker();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tbMulta = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.cbForma1 = new System.Windows.Forms.ComboBox();
			this.tbDoc1 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.tbVal1 = new System.Windows.Forms.TextBox();
			this.cbForma2 = new System.Windows.Forms.ComboBox();
			this.tbDoc2 = new System.Windows.Forms.TextBox();
			this.tbVal2 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.cbForma3 = new System.Windows.Forms.ComboBox();
			this.tbDoc3 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbVal3 = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbTotal2 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.tbTroco = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.btSair = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tbPago = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.dtPagamento = new System.Windows.Forms.DateTimePicker();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recebimentosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// recebimentosToolStripMenuItem
			// 
			this.recebimentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmarToolStripMenuItem,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.recebimentosToolStripMenuItem.Name = "recebimentosToolStripMenuItem";
			this.recebimentosToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.recebimentosToolStripMenuItem.Text = "&Recebimentos";
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
			// tbNumero
			// 
			this.tbNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbNumero.Location = new System.Drawing.Point(12, 87);
			this.tbNumero.Name = "tbNumero";
			this.tbNumero.Size = new System.Drawing.Size(100, 20);
			this.tbNumero.TabIndex = 1;
			this.tbNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNumero_KeyDown);
			this.tbNumero.Leave += new System.EventHandler(this.tbNumero_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Número";
			// 
			// tbCliente
			// 
			this.tbCliente.BackColor = System.Drawing.Color.White;
			this.tbCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCliente.Enabled = false;
			this.tbCliente.ForeColor = System.Drawing.Color.Black;
			this.tbCliente.Location = new System.Drawing.Point(118, 87);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.Size = new System.Drawing.Size(200, 20);
			this.tbCliente.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(115, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(39, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Cliente";
			// 
			// tbValor
			// 
			this.tbValor.BackColor = System.Drawing.Color.White;
			this.tbValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbValor.ForeColor = System.Drawing.Color.Black;
			this.tbValor.Location = new System.Drawing.Point(218, 145);
			this.tbValor.Name = "tbValor";
			this.tbValor.ReadOnly = true;
			this.tbValor.Size = new System.Drawing.Size(100, 20);
			this.tbValor.TabIndex = 5;
			this.tbValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(154, 148);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Valor";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(191, 148);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "R$";
			// 
			// dtVencimento
			// 
			this.dtVencimento.Enabled = false;
			this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtVencimento.Location = new System.Drawing.Point(12, 145);
			this.dtVencimento.Name = "dtVencimento";
			this.dtVencimento.Size = new System.Drawing.Size(100, 20);
			this.dtVencimento.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 129);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(63, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Vencimento";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(191, 174);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(21, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "R$";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(152, 174);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(33, 13);
			this.label7.TabIndex = 11;
			this.label7.Text = "Multa";
			// 
			// tbMulta
			// 
			this.tbMulta.BackColor = System.Drawing.Color.White;
			this.tbMulta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbMulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbMulta.ForeColor = System.Drawing.Color.DarkRed;
			this.tbMulta.Location = new System.Drawing.Point(218, 171);
			this.tbMulta.Name = "tbMulta";
			this.tbMulta.Size = new System.Drawing.Size(100, 20);
			this.tbMulta.TabIndex = 10;
			this.tbMulta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbMulta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMulta_KeyDown);
			this.tbMulta.Leave += new System.EventHandler(this.tbMulta_Leave);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(191, 226);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(21, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "R$";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(154, 226);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(31, 13);
			this.label9.TabIndex = 14;
			this.label9.Text = "Total";
			// 
			// tbTotal
			// 
			this.tbTotal.BackColor = System.Drawing.Color.White;
			this.tbTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTotal.ForeColor = System.Drawing.Color.Black;
			this.tbTotal.Location = new System.Drawing.Point(218, 223);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.ReadOnly = true;
			this.tbTotal.Size = new System.Drawing.Size(100, 20);
			this.tbTotal.TabIndex = 13;
			this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(419, 129);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(108, 13);
			this.label10.TabIndex = 16;
			this.label10.Text = "Forma de Pagamento";
			// 
			// cbForma1
			// 
			this.cbForma1.AutoCompleteCustomSource.AddRange(new string[] {
            "C - Cartão",
            "D - Dinheiro",
            "M - Master Card",
            "V - Visa",
            "X - Cheque"});
			this.cbForma1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbForma1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbForma1.Enabled = false;
			this.cbForma1.FormattingEnabled = true;
			this.cbForma1.Location = new System.Drawing.Point(422, 145);
			this.cbForma1.Name = "cbForma1";
			this.cbForma1.Size = new System.Drawing.Size(121, 21);
			this.cbForma1.TabIndex = 17;
			this.cbForma1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbForma1_KeyDown);
			// 
			// tbDoc1
			// 
			this.tbDoc1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDoc1.Enabled = false;
			this.tbDoc1.Location = new System.Drawing.Point(549, 145);
			this.tbDoc1.Name = "tbDoc1";
			this.tbDoc1.Size = new System.Drawing.Size(100, 20);
			this.tbDoc1.TabIndex = 18;
			this.tbDoc1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbDoc1_KeyDown);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(546, 129);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(62, 13);
			this.label11.TabIndex = 19;
			this.label11.Text = "Documento";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(655, 148);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(21, 13);
			this.label12.TabIndex = 22;
			this.label12.Text = "R$";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(679, 129);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(31, 13);
			this.label13.TabIndex = 21;
			this.label13.Text = "Valor";
			// 
			// tbVal1
			// 
			this.tbVal1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbVal1.Enabled = false;
			this.tbVal1.Location = new System.Drawing.Point(682, 145);
			this.tbVal1.Name = "tbVal1";
			this.tbVal1.Size = new System.Drawing.Size(100, 20);
			this.tbVal1.TabIndex = 20;
			this.tbVal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tbVal1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbVal1_KeyDown);
			// 
			// cbForma2
			// 
			this.cbForma2.AutoCompleteCustomSource.AddRange(new string[] {
            "C - Cartão",
            "D - Dinheiro",
            "M - Master Card",
            "V - Visa",
            "X - Cheque"});
			this.cbForma2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbForma2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbForma2.Enabled = false;
			this.cbForma2.FormattingEnabled = true;
			this.cbForma2.Location = new System.Drawing.Point(422, 172);
			this.cbForma2.Name = "cbForma2";
			this.cbForma2.Size = new System.Drawing.Size(121, 21);
			this.cbForma2.TabIndex = 23;
			// 
			// tbDoc2
			// 
			this.tbDoc2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDoc2.Enabled = false;
			this.tbDoc2.Location = new System.Drawing.Point(549, 171);
			this.tbDoc2.Name = "tbDoc2";
			this.tbDoc2.Size = new System.Drawing.Size(100, 20);
			this.tbDoc2.TabIndex = 24;
			// 
			// tbVal2
			// 
			this.tbVal2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbVal2.Enabled = false;
			this.tbVal2.Location = new System.Drawing.Point(682, 171);
			this.tbVal2.Name = "tbVal2";
			this.tbVal2.Size = new System.Drawing.Size(100, 20);
			this.tbVal2.TabIndex = 25;
			this.tbVal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(655, 174);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(21, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "R$";
			// 
			// cbForma3
			// 
			this.cbForma3.AutoCompleteCustomSource.AddRange(new string[] {
            "C - Cartão",
            "D - Dinheiro",
            "M - Master Card",
            "V - Visa",
            "X - Cheque"});
			this.cbForma3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbForma3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cbForma3.Enabled = false;
			this.cbForma3.FormattingEnabled = true;
			this.cbForma3.Location = new System.Drawing.Point(422, 199);
			this.cbForma3.Name = "cbForma3";
			this.cbForma3.Size = new System.Drawing.Size(121, 21);
			this.cbForma3.TabIndex = 27;
			// 
			// tbDoc3
			// 
			this.tbDoc3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDoc3.Enabled = false;
			this.tbDoc3.Location = new System.Drawing.Point(549, 197);
			this.tbDoc3.Name = "tbDoc3";
			this.tbDoc3.Size = new System.Drawing.Size(100, 20);
			this.tbDoc3.TabIndex = 28;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(655, 200);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(21, 13);
			this.label15.TabIndex = 30;
			this.label15.Text = "R$";
			// 
			// tbVal3
			// 
			this.tbVal3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbVal3.Enabled = false;
			this.tbVal3.Location = new System.Drawing.Point(682, 197);
			this.tbVal3.Name = "tbVal3";
			this.tbVal3.Size = new System.Drawing.Size(100, 20);
			this.tbVal3.TabIndex = 29;
			this.tbVal3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(655, 226);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(21, 13);
			this.label16.TabIndex = 32;
			this.label16.Text = "R$";
			// 
			// tbTotal2
			// 
			this.tbTotal2.BackColor = System.Drawing.Color.White;
			this.tbTotal2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTotal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTotal2.Location = new System.Drawing.Point(682, 223);
			this.tbTotal2.Name = "tbTotal2";
			this.tbTotal2.ReadOnly = true;
			this.tbTotal2.Size = new System.Drawing.Size(100, 20);
			this.tbTotal2.TabIndex = 31;
			this.tbTotal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(655, 252);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(21, 13);
			this.label17.TabIndex = 34;
			this.label17.Text = "R$";
			// 
			// tbTroco
			// 
			this.tbTroco.BackColor = System.Drawing.Color.White;
			this.tbTroco.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbTroco.ForeColor = System.Drawing.Color.Red;
			this.tbTroco.Location = new System.Drawing.Point(682, 249);
			this.tbTroco.Name = "tbTroco";
			this.tbTroco.ReadOnly = true;
			this.tbTroco.Size = new System.Drawing.Size(100, 20);
			this.tbTroco.TabIndex = 33;
			this.tbTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(618, 226);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(31, 13);
			this.label18.TabIndex = 35;
			this.label18.Text = "Total";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(614, 252);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(35, 13);
			this.label19.TabIndex = 36;
			this.label19.Text = "Troco";
			// 
			// btConfirmar
			// 
			this.btConfirmar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btConfirmar.Location = new System.Drawing.Point(530, 317);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(123, 45);
			this.btConfirmar.TabIndex = 37;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// btSair
			// 
			this.btSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 317);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 38;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(191, 200);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(21, 13);
			this.label20.TabIndex = 41;
			this.label20.Text = "R$";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(152, 202);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(32, 13);
			this.label21.TabIndex = 40;
			this.label21.Text = "Pago";
			// 
			// tbPago
			// 
			this.tbPago.BackColor = System.Drawing.Color.White;
			this.tbPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPago.ForeColor = System.Drawing.Color.DarkGreen;
			this.tbPago.Location = new System.Drawing.Point(218, 197);
			this.tbPago.Name = "tbPago";
			this.tbPago.ReadOnly = true;
			this.tbPago.Size = new System.Drawing.Size(100, 20);
			this.tbPago.TabIndex = 39;
			this.tbPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(679, 68);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(61, 13);
			this.label22.TabIndex = 43;
			this.label22.Text = "Pagamento";
			// 
			// dtPagamento
			// 
			this.dtPagamento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtPagamento.Location = new System.Drawing.Point(682, 84);
			this.dtPagamento.Name = "dtPagamento";
			this.dtPagamento.Size = new System.Drawing.Size(100, 20);
			this.dtPagamento.TabIndex = 42;
			// 
			// frmRecebimentos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 374);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.dtPagamento);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.tbPago);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.tbTroco);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.tbTotal2);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.tbVal3);
			this.Controls.Add(this.tbDoc3);
			this.Controls.Add(this.cbForma3);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.tbVal2);
			this.Controls.Add(this.tbDoc2);
			this.Controls.Add(this.cbForma2);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.tbVal1);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.tbDoc1);
			this.Controls.Add(this.cbForma1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbMulta);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.dtVencimento);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbValor);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbNumero);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmRecebimentos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Recebimentos";
			this.Load += new System.EventHandler(this.frmRecebimentos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem recebimentosToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem confirmarToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbNumero;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbValor;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtVencimento;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbMulta;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox cbForma1;
		private System.Windows.Forms.TextBox tbDoc1;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbVal1;
		private System.Windows.Forms.ComboBox cbForma2;
		private System.Windows.Forms.TextBox tbDoc2;
		private System.Windows.Forms.TextBox tbVal2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox cbForma3;
		private System.Windows.Forms.TextBox tbDoc3;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbVal3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbTotal2;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbTroco;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox tbPago;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.DateTimePicker dtPagamento;
	}
}