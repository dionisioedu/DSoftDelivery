namespace DSoft_Delivery
{
	partial class frmConPedidosCliente
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConPedidosCliente));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tbCliente = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.lbCliente = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button20 = new System.Windows.Forms.Button();
			this.button19 = new System.Windows.Forms.Button();
			this.button18 = new System.Windows.Forms.Button();
			this.button17 = new System.Windows.Forms.Button();
			this.button16 = new System.Windows.Forms.Button();
			this.button15 = new System.Windows.Forms.Button();
			this.button14 = new System.Windows.Forms.Button();
			this.button13 = new System.Windows.Forms.Button();
			this.tbSair = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultaToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(598, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
			// 
			// consultaToolStripMenuItem
			// 
			this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
			this.consultaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.consultaToolStripMenuItem.Text = "&Consulta";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// tbCliente
			// 
			this.tbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.tbCliente.Location = new System.Drawing.Point(12, 53);
			this.tbCliente.Name = "tbCliente";
			this.tbCliente.Size = new System.Drawing.Size(100, 20);
			this.tbCliente.TabIndex = 1;
			this.tbCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCliente_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 37);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Cliente";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 79);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(574, 252);
			this.dataGridView1.TabIndex = 3;
			this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
			this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
			// 
			// lbCliente
			// 
			this.lbCliente.AutoSize = true;
			this.lbCliente.ForeColor = System.Drawing.Color.DarkBlue;
			this.lbCliente.Location = new System.Drawing.Point(118, 56);
			this.lbCliente.Name = "lbCliente";
			this.lbCliente.Size = new System.Drawing.Size(0, 13);
			this.lbCliente.TabIndex = 4;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.label22);
			this.groupBox3.Controls.Add(this.label21);
			this.groupBox3.Controls.Add(this.label20);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label17);
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.button20);
			this.groupBox3.Controls.Add(this.button19);
			this.groupBox3.Controls.Add(this.button18);
			this.groupBox3.Controls.Add(this.button17);
			this.groupBox3.Controls.Add(this.button16);
			this.groupBox3.Controls.Add(this.button15);
			this.groupBox3.Controls.Add(this.button14);
			this.groupBox3.Controls.Add(this.button13);
			this.groupBox3.Location = new System.Drawing.Point(170, 337);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(416, 80);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Legenda";
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(327, 49);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(36, 13);
			this.label23.TabIndex = 15;
			this.label23.Text = "Saída";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(327, 23);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(80, 13);
			this.label22.TabIndex = 14;
			this.label22.Text = "Pago/Entregue";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(227, 49);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(66, 13);
			this.label21.TabIndex = 13;
			this.label21.Text = "Pago/Saída";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(227, 23);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(32, 13);
			this.label20.TabIndex = 12;
			this.label20.Text = "Pago";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(128, 49);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(50, 13);
			this.label19.TabIndex = 11;
			this.label19.Text = "Entregue";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(128, 23);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(58, 13);
			this.label18.TabIndex = 10;
			this.label18.Text = "Cancelado";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(32, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(58, 13);
			this.label17.TabIndex = 9;
			this.label17.Text = "Bloqueado";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(32, 23);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(38, 13);
			this.label16.TabIndex = 8;
			this.label16.Text = "Aberto";
			// 
			// button20
			// 
			this.button20.BackColor = System.Drawing.Color.LightBlue;
			this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button20.Location = new System.Drawing.Point(301, 45);
			this.button20.Name = "button20";
			this.button20.Size = new System.Drawing.Size(20, 20);
			this.button20.TabIndex = 7;
			this.button20.UseVisualStyleBackColor = false;
			// 
			// button19
			// 
			this.button19.BackColor = System.Drawing.Color.Green;
			this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button19.Location = new System.Drawing.Point(301, 19);
			this.button19.Name = "button19";
			this.button19.Size = new System.Drawing.Size(20, 20);
			this.button19.TabIndex = 6;
			this.button19.UseVisualStyleBackColor = false;
			// 
			// button18
			// 
			this.button18.BackColor = System.Drawing.Color.Violet;
			this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button18.Location = new System.Drawing.Point(201, 45);
			this.button18.Name = "button18";
			this.button18.Size = new System.Drawing.Size(20, 20);
			this.button18.TabIndex = 5;
			this.button18.UseVisualStyleBackColor = false;
			// 
			// button17
			// 
			this.button17.BackColor = System.Drawing.Color.LightGreen;
			this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button17.Location = new System.Drawing.Point(201, 19);
			this.button17.Name = "button17";
			this.button17.Size = new System.Drawing.Size(20, 20);
			this.button17.TabIndex = 4;
			this.button17.UseVisualStyleBackColor = false;
			// 
			// button16
			// 
			this.button16.BackColor = System.Drawing.Color.Blue;
			this.button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button16.Location = new System.Drawing.Point(102, 45);
			this.button16.Name = "button16";
			this.button16.Size = new System.Drawing.Size(20, 20);
			this.button16.TabIndex = 3;
			this.button16.UseVisualStyleBackColor = false;
			// 
			// button15
			// 
			this.button15.BackColor = System.Drawing.Color.Red;
			this.button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button15.Location = new System.Drawing.Point(102, 19);
			this.button15.Name = "button15";
			this.button15.Size = new System.Drawing.Size(20, 20);
			this.button15.TabIndex = 2;
			this.button15.UseVisualStyleBackColor = false;
			// 
			// button14
			// 
			this.button14.BackColor = System.Drawing.Color.Yellow;
			this.button14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button14.Location = new System.Drawing.Point(6, 45);
			this.button14.Name = "button14";
			this.button14.Size = new System.Drawing.Size(20, 20);
			this.button14.TabIndex = 1;
			this.button14.UseVisualStyleBackColor = false;
			// 
			// button13
			// 
			this.button13.BackColor = System.Drawing.Color.White;
			this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button13.Location = new System.Drawing.Point(6, 19);
			this.button13.Name = "button13";
			this.button13.Size = new System.Drawing.Size(20, 20);
			this.button13.TabIndex = 0;
			this.button13.UseVisualStyleBackColor = false;
			// 
			// tbSair
			// 
			this.tbSair.Location = new System.Drawing.Point(511, 46);
			this.tbSair.Name = "tbSair";
			this.tbSair.Size = new System.Drawing.Size(75, 23);
			this.tbSair.TabIndex = 14;
			this.tbSair.Text = "&Sair - F10";
			this.tbSair.UseVisualStyleBackColor = true;
			this.tbSair.Click += new System.EventHandler(this.tbSair_Click);
			// 
			// frmConPedidosCliente
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(598, 429);
			this.Controls.Add(this.tbSair);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.lbCliente);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbCliente);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(604, 458);
			this.Name = "frmConPedidosCliente";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Consulta de pedidos por cliente";
			this.Load += new System.EventHandler(this.frmConPedidosCliente_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmConPedidosCliente_KeyPress);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.TextBox tbCliente;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label lbCliente;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button20;
		private System.Windows.Forms.Button button19;
		private System.Windows.Forms.Button button18;
		private System.Windows.Forms.Button button17;
		private System.Windows.Forms.Button button16;
		private System.Windows.Forms.Button button15;
		private System.Windows.Forms.Button button14;
		private System.Windows.Forms.Button button13;
		private System.Windows.Forms.Button tbSair;
	}
}