namespace DSoft_Delivery
{
	partial class frmControlePontos
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlePontos));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.controleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.btSair = new System.Windows.Forms.Button();
			this.cbFuncionario = new System.Windows.Forms.ComboBox();
			this.dtData = new System.Windows.Forms.DateTimePicker();
			this.dtHora = new System.Windows.Forms.DateTimePicker();
			this.btNovo = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controleToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(794, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// controleToolStripMenuItem
			// 
			this.controleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sairToolStripMenuItem});
			this.controleToolStripMenuItem.Name = "controleToolStripMenuItem";
			this.controleToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.controleToolStripMenuItem.Text = "&Controle";
			// 
			// sairToolStripMenuItem
			// 
			this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
			this.sairToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
			this.sairToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sairToolStripMenuItem.Text = "&Sair";
			this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
			// 
			// relatóriosToolStripMenuItem
			// 
			this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
			this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.relatóriosToolStripMenuItem.Text = "Relatórios";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 86);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.Size = new System.Drawing.Size(547, 424);
			this.dataGridView1.TabIndex = 1;
			// 
			// btSair
			// 
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(659, 27);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(123, 45);
			this.btSair.TabIndex = 2;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.btSair_Click);
			// 
			// cbFuncionario
			// 
			this.cbFuncionario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cbFuncionario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cbFuncionario.DropDownWidth = 300;
			this.cbFuncionario.FormattingEnabled = true;
			this.cbFuncionario.Location = new System.Drawing.Point(12, 59);
			this.cbFuncionario.Name = "cbFuncionario";
			this.cbFuncionario.Size = new System.Drawing.Size(210, 21);
			this.cbFuncionario.TabIndex = 3;
			// 
			// dtData
			// 
			this.dtData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtData.Location = new System.Drawing.Point(228, 60);
			this.dtData.Name = "dtData";
			this.dtData.Size = new System.Drawing.Size(100, 20);
			this.dtData.TabIndex = 4;
			// 
			// dtHora
			// 
			this.dtHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtHora.Location = new System.Drawing.Point(334, 60);
			this.dtHora.Name = "dtHora";
			this.dtHora.Size = new System.Drawing.Size(100, 20);
			this.dtHora.TabIndex = 5;
			// 
			// btNovo
			// 
			this.btNovo.Location = new System.Drawing.Point(440, 57);
			this.btNovo.Name = "btNovo";
			this.btNovo.Size = new System.Drawing.Size(119, 23);
			this.btNovo.TabIndex = 6;
			this.btNovo.Text = "&Nova Entrada";
			this.btNovo.UseVisualStyleBackColor = true;
			this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// frmControlePontos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 522);
			this.Controls.Add(this.btNovo);
			this.Controls.Add(this.dtHora);
			this.Controls.Add(this.dtData);
			this.Controls.Add(this.cbFuncionario);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "frmControlePontos";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Controle de Pontos";
			this.Load += new System.EventHandler(this.frmControlePontos_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem controleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
		private System.Windows.Forms.ComboBox cbFuncionario;
		private System.Windows.Forms.DateTimePicker dtData;
		private System.Windows.Forms.DateTimePicker dtHora;
		private System.Windows.Forms.Button btNovo;
		private System.Windows.Forms.Timer timer1;
	}
}