namespace DSoft_Delivery
{
	partial class frmCadNiveis
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadNiveis));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btSair = new System.Windows.Forms.Button();
			this.tbCodigo = new System.Windows.Forms.TextBox();
			this.tbDescricao = new System.Windows.Forms.TextBox();
			this.cbAdministrador = new System.Windows.Forms.CheckBox();
			this.cbLancarPedidos = new System.Windows.Forms.CheckBox();
			this.cbAlterarPedidos = new System.Windows.Forms.CheckBox();
			this.cbCancelarPedidos = new System.Windows.Forms.CheckBox();
			this.cbCaixa = new System.Windows.Forms.CheckBox();
			this.cbControleFinanceiro = new System.Windows.Forms.CheckBox();
			this.cbEntregas = new System.Windows.Forms.CheckBox();
			this.cbRelatorios = new System.Windows.Forms.CheckBox();
			this.cbCadastrarProdutos = new System.Windows.Forms.CheckBox();
			this.cbAlterarPrecos = new System.Windows.Forms.CheckBox();
			this.cbCompras = new System.Windows.Forms.CheckBox();
			this.cbCadastrarRecursos = new System.Windows.Forms.CheckBox();
			this.cbCadastrarUsuarios = new System.Windows.Forms.CheckBox();
			this.cbAlterarEstoque = new System.Windows.Forms.CheckBox();
			this.cbScriptBd = new System.Windows.Forms.CheckBox();
			this.cbPreferencias = new System.Windows.Forms.CheckBox();
			this.cbTerminal = new System.Windows.Forms.CheckBox();
			this.cbRegrasNegocio = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btConfirmar = new System.Windows.Forms.Button();
			this.cbCadastrarGruposDeClientes = new System.Windows.Forms.CheckBox();
			this.cbAlmoxarifado = new System.Windows.Forms.CheckBox();
			this.cbEscritorio = new System.Windows.Forms.CheckBox();
			this.cbAlteraClientePedido = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 253);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 18;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.Size = new System.Drawing.Size(569, 215);
			this.dataGridView1.TabIndex = 23;
			this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(593, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// cadastroToolStripMenuItem
			// 
			this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.sairToolStripMenuItem});
			this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
			this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
			this.cadastroToolStripMenuItem.Text = "&Cadastro";
			this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.cadastroToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.toolStripMenuItem2.Size = new System.Drawing.Size(147, 22);
			this.toolStripMenuItem2.Text = "&Confirmar";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
			// btSair
			// 
			this.btSair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btSair.AutoSize = true;
			this.btSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btSair.Location = new System.Drawing.Point(506, 224);
			this.btSair.Name = "btSair";
			this.btSair.Size = new System.Drawing.Size(75, 23);
			this.btSair.TabIndex = 22;
			this.btSair.Text = "&Sair - F10";
			this.btSair.UseVisualStyleBackColor = true;
			this.btSair.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbCodigo
			// 
			this.tbCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbCodigo.Location = new System.Drawing.Point(12, 42);
			this.tbCodigo.MaxLength = 1;
			this.tbCodigo.Name = "tbCodigo";
			this.tbCodigo.Size = new System.Drawing.Size(49, 20);
			this.tbCodigo.TabIndex = 0;
			// 
			// tbDescricao
			// 
			this.tbDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.tbDescricao.Location = new System.Drawing.Point(67, 42);
			this.tbDescricao.Name = "tbDescricao";
			this.tbDescricao.Size = new System.Drawing.Size(148, 20);
			this.tbDescricao.TabIndex = 1;
			// 
			// cbAdministrador
			// 
			this.cbAdministrador.AutoSize = true;
			this.cbAdministrador.Location = new System.Drawing.Point(221, 44);
			this.cbAdministrador.Name = "cbAdministrador";
			this.cbAdministrador.Size = new System.Drawing.Size(89, 17);
			this.cbAdministrador.TabIndex = 2;
			this.cbAdministrador.Text = "Administrador";
			this.cbAdministrador.UseVisualStyleBackColor = true;
			this.cbAdministrador.CheckedChanged += new System.EventHandler(this.cbAdministrador_CheckedChanged);
			// 
			// cbLancarPedidos
			// 
			this.cbLancarPedidos.AutoSize = true;
			this.cbLancarPedidos.Location = new System.Drawing.Point(12, 68);
			this.cbLancarPedidos.Name = "cbLancarPedidos";
			this.cbLancarPedidos.Size = new System.Drawing.Size(100, 17);
			this.cbLancarPedidos.TabIndex = 3;
			this.cbLancarPedidos.Text = "Lançar Pedidos";
			this.cbLancarPedidos.UseVisualStyleBackColor = true;
			// 
			// cbAlterarPedidos
			// 
			this.cbAlterarPedidos.AutoSize = true;
			this.cbAlterarPedidos.Location = new System.Drawing.Point(12, 91);
			this.cbAlterarPedidos.Name = "cbAlterarPedidos";
			this.cbAlterarPedidos.Size = new System.Drawing.Size(97, 17);
			this.cbAlterarPedidos.TabIndex = 4;
			this.cbAlterarPedidos.Text = "Alterar Pedidos";
			this.cbAlterarPedidos.UseVisualStyleBackColor = true;
			// 
			// cbCancelarPedidos
			// 
			this.cbCancelarPedidos.AutoSize = true;
			this.cbCancelarPedidos.Location = new System.Drawing.Point(12, 137);
			this.cbCancelarPedidos.Name = "cbCancelarPedidos";
			this.cbCancelarPedidos.Size = new System.Drawing.Size(109, 17);
			this.cbCancelarPedidos.TabIndex = 5;
			this.cbCancelarPedidos.Text = "Cancelar Pedidos";
			this.cbCancelarPedidos.UseVisualStyleBackColor = true;
			// 
			// cbCaixa
			// 
			this.cbCaixa.AutoSize = true;
			this.cbCaixa.Location = new System.Drawing.Point(12, 160);
			this.cbCaixa.Name = "cbCaixa";
			this.cbCaixa.Size = new System.Drawing.Size(52, 17);
			this.cbCaixa.TabIndex = 6;
			this.cbCaixa.Text = "Caixa";
			this.cbCaixa.UseVisualStyleBackColor = true;
			// 
			// cbControleFinanceiro
			// 
			this.cbControleFinanceiro.AutoSize = true;
			this.cbControleFinanceiro.Location = new System.Drawing.Point(12, 183);
			this.cbControleFinanceiro.Name = "cbControleFinanceiro";
			this.cbControleFinanceiro.Size = new System.Drawing.Size(117, 17);
			this.cbControleFinanceiro.TabIndex = 7;
			this.cbControleFinanceiro.Text = "Controle Financeiro";
			this.cbControleFinanceiro.UseVisualStyleBackColor = true;
			// 
			// cbEntregas
			// 
			this.cbEntregas.AutoSize = true;
			this.cbEntregas.Location = new System.Drawing.Point(146, 68);
			this.cbEntregas.Name = "cbEntregas";
			this.cbEntregas.Size = new System.Drawing.Size(68, 17);
			this.cbEntregas.TabIndex = 8;
			this.cbEntregas.Text = "Entregas";
			this.cbEntregas.UseVisualStyleBackColor = true;
			// 
			// cbRelatorios
			// 
			this.cbRelatorios.AutoSize = true;
			this.cbRelatorios.Location = new System.Drawing.Point(146, 91);
			this.cbRelatorios.Name = "cbRelatorios";
			this.cbRelatorios.Size = new System.Drawing.Size(73, 17);
			this.cbRelatorios.TabIndex = 9;
			this.cbRelatorios.Text = "Relatórios";
			this.cbRelatorios.UseVisualStyleBackColor = true;
			// 
			// cbCadastrarProdutos
			// 
			this.cbCadastrarProdutos.AutoSize = true;
			this.cbCadastrarProdutos.Location = new System.Drawing.Point(146, 114);
			this.cbCadastrarProdutos.Name = "cbCadastrarProdutos";
			this.cbCadastrarProdutos.Size = new System.Drawing.Size(116, 17);
			this.cbCadastrarProdutos.TabIndex = 10;
			this.cbCadastrarProdutos.Text = "Cadastrar Produtos";
			this.cbCadastrarProdutos.UseVisualStyleBackColor = true;
			// 
			// cbAlterarPrecos
			// 
			this.cbAlterarPrecos.AutoSize = true;
			this.cbAlterarPrecos.Location = new System.Drawing.Point(146, 137);
			this.cbAlterarPrecos.Name = "cbAlterarPrecos";
			this.cbAlterarPrecos.Size = new System.Drawing.Size(92, 17);
			this.cbAlterarPrecos.TabIndex = 11;
			this.cbAlterarPrecos.Text = "Alterar Preços";
			this.cbAlterarPrecos.UseVisualStyleBackColor = true;
			// 
			// cbCompras
			// 
			this.cbCompras.AutoSize = true;
			this.cbCompras.Location = new System.Drawing.Point(146, 160);
			this.cbCompras.Name = "cbCompras";
			this.cbCompras.Size = new System.Drawing.Size(67, 17);
			this.cbCompras.TabIndex = 12;
			this.cbCompras.Text = "Compras";
			this.cbCompras.UseVisualStyleBackColor = true;
			// 
			// cbCadastrarRecursos
			// 
			this.cbCadastrarRecursos.AutoSize = true;
			this.cbCadastrarRecursos.Location = new System.Drawing.Point(288, 68);
			this.cbCadastrarRecursos.Name = "cbCadastrarRecursos";
			this.cbCadastrarRecursos.Size = new System.Drawing.Size(119, 17);
			this.cbCadastrarRecursos.TabIndex = 13;
			this.cbCadastrarRecursos.Text = "Cadastrar Recursos";
			this.cbCadastrarRecursos.UseVisualStyleBackColor = true;
			// 
			// cbCadastrarUsuarios
			// 
			this.cbCadastrarUsuarios.AutoSize = true;
			this.cbCadastrarUsuarios.Location = new System.Drawing.Point(288, 91);
			this.cbCadastrarUsuarios.Name = "cbCadastrarUsuarios";
			this.cbCadastrarUsuarios.Size = new System.Drawing.Size(115, 17);
			this.cbCadastrarUsuarios.TabIndex = 14;
			this.cbCadastrarUsuarios.Text = "Cadastrar Usuários";
			this.cbCadastrarUsuarios.UseVisualStyleBackColor = true;
			// 
			// cbAlterarEstoque
			// 
			this.cbAlterarEstoque.AutoSize = true;
			this.cbAlterarEstoque.Location = new System.Drawing.Point(288, 114);
			this.cbAlterarEstoque.Name = "cbAlterarEstoque";
			this.cbAlterarEstoque.Size = new System.Drawing.Size(98, 17);
			this.cbAlterarEstoque.TabIndex = 15;
			this.cbAlterarEstoque.Text = "Alterar Estoque";
			this.cbAlterarEstoque.UseVisualStyleBackColor = true;
			// 
			// cbScriptBd
			// 
			this.cbScriptBd.AutoSize = true;
			this.cbScriptBd.Location = new System.Drawing.Point(288, 137);
			this.cbScriptBd.Name = "cbScriptBd";
			this.cbScriptBd.Size = new System.Drawing.Size(69, 17);
			this.cbScriptBd.TabIndex = 16;
			this.cbScriptBd.Text = "Script Bd";
			this.cbScriptBd.UseVisualStyleBackColor = true;
			// 
			// cbPreferencias
			// 
			this.cbPreferencias.AutoSize = true;
			this.cbPreferencias.Location = new System.Drawing.Point(420, 68);
			this.cbPreferencias.Name = "cbPreferencias";
			this.cbPreferencias.Size = new System.Drawing.Size(85, 17);
			this.cbPreferencias.TabIndex = 17;
			this.cbPreferencias.Text = "Preferências";
			this.cbPreferencias.UseVisualStyleBackColor = true;
			// 
			// cbTerminal
			// 
			this.cbTerminal.AutoSize = true;
			this.cbTerminal.Location = new System.Drawing.Point(420, 91);
			this.cbTerminal.Name = "cbTerminal";
			this.cbTerminal.Size = new System.Drawing.Size(66, 17);
			this.cbTerminal.TabIndex = 18;
			this.cbTerminal.Text = "Terminal";
			this.cbTerminal.UseVisualStyleBackColor = true;
			// 
			// cbRegrasNegocio
			// 
			this.cbRegrasNegocio.AutoSize = true;
			this.cbRegrasNegocio.Location = new System.Drawing.Point(420, 114);
			this.cbRegrasNegocio.Name = "cbRegrasNegocio";
			this.cbRegrasNegocio.Size = new System.Drawing.Size(118, 17);
			this.cbRegrasNegocio.TabIndex = 19;
			this.cbRegrasNegocio.Text = "Regras de Negócio";
			this.cbRegrasNegocio.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Código";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(64, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Descrição";
			// 
			// btConfirmar
			// 
			this.btConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btConfirmar.AutoSize = true;
			this.btConfirmar.Location = new System.Drawing.Point(418, 224);
			this.btConfirmar.Name = "btConfirmar";
			this.btConfirmar.Size = new System.Drawing.Size(82, 23);
			this.btConfirmar.TabIndex = 21;
			this.btConfirmar.Text = "&Confirmar - F2";
			this.btConfirmar.UseVisualStyleBackColor = true;
			this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
			// 
			// cbCadastrarGruposDeClientes
			// 
			this.cbCadastrarGruposDeClientes.AutoSize = true;
			this.cbCadastrarGruposDeClientes.Location = new System.Drawing.Point(420, 137);
			this.cbCadastrarGruposDeClientes.Name = "cbCadastrarGruposDeClientes";
			this.cbCadastrarGruposDeClientes.Size = new System.Drawing.Size(163, 17);
			this.cbCadastrarGruposDeClientes.TabIndex = 20;
			this.cbCadastrarGruposDeClientes.Text = "Cadastrar Grupos de Clientes";
			this.cbCadastrarGruposDeClientes.UseVisualStyleBackColor = true;
			// 
			// cbAlmoxarifado
			// 
			this.cbAlmoxarifado.AutoSize = true;
			this.cbAlmoxarifado.Location = new System.Drawing.Point(420, 160);
			this.cbAlmoxarifado.Name = "cbAlmoxarifado";
			this.cbAlmoxarifado.Size = new System.Drawing.Size(86, 17);
			this.cbAlmoxarifado.TabIndex = 26;
			this.cbAlmoxarifado.Text = "Almoxarifado";
			this.cbAlmoxarifado.UseVisualStyleBackColor = true;
			// 
			// cbEscritorio
			// 
			this.cbEscritorio.AutoSize = true;
			this.cbEscritorio.Location = new System.Drawing.Point(288, 160);
			this.cbEscritorio.Name = "cbEscritorio";
			this.cbEscritorio.Size = new System.Drawing.Size(69, 17);
			this.cbEscritorio.TabIndex = 25;
			this.cbEscritorio.Text = "Escritório";
			this.cbEscritorio.UseVisualStyleBackColor = true;
			// 
			// cbAlteraClientePedido
			// 
			this.cbAlteraClientePedido.AutoSize = true;
			this.cbAlteraClientePedido.Location = new System.Drawing.Point(12, 114);
			this.cbAlteraClientePedido.Name = "cbAlteraClientePedido";
			this.cbAlteraClientePedido.Size = new System.Drawing.Size(127, 17);
			this.cbAlteraClientePedido.TabIndex = 27;
			this.cbAlteraClientePedido.Text = "Alterar Cliente Pedido";
			this.cbAlteraClientePedido.UseVisualStyleBackColor = true;
			// 
			// frmCadNiveis
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 480);
			this.Controls.Add(this.cbAlteraClientePedido);
			this.Controls.Add(this.cbAlmoxarifado);
			this.Controls.Add(this.cbEscritorio);
			this.Controls.Add(this.cbCadastrarGruposDeClientes);
			this.Controls.Add(this.btConfirmar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbRegrasNegocio);
			this.Controls.Add(this.cbTerminal);
			this.Controls.Add(this.cbPreferencias);
			this.Controls.Add(this.cbScriptBd);
			this.Controls.Add(this.cbAlterarEstoque);
			this.Controls.Add(this.cbCadastrarUsuarios);
			this.Controls.Add(this.cbCadastrarRecursos);
			this.Controls.Add(this.cbCompras);
			this.Controls.Add(this.cbAlterarPrecos);
			this.Controls.Add(this.cbCadastrarProdutos);
			this.Controls.Add(this.cbRelatorios);
			this.Controls.Add(this.cbEntregas);
			this.Controls.Add(this.cbControleFinanceiro);
			this.Controls.Add(this.cbCaixa);
			this.Controls.Add(this.cbCancelarPedidos);
			this.Controls.Add(this.cbAlterarPedidos);
			this.Controls.Add(this.cbLancarPedidos);
			this.Controls.Add(this.cbAdministrador);
			this.Controls.Add(this.tbDescricao);
			this.Controls.Add(this.tbCodigo);
			this.Controls.Add(this.btSair);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(570, 380);
			this.Name = "frmCadNiveis";
			this.ShowInTaskbar = false;
			this.Text = "Cadastro de Níveis de Usuários";
			this.Load += new System.EventHandler(this.frmCadNiveis_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
		private System.Windows.Forms.Button btSair;
		private System.Windows.Forms.TextBox tbCodigo;
		private System.Windows.Forms.TextBox tbDescricao;
		private System.Windows.Forms.CheckBox cbAdministrador;
		private System.Windows.Forms.CheckBox cbLancarPedidos;
		private System.Windows.Forms.CheckBox cbAlterarPedidos;
		private System.Windows.Forms.CheckBox cbCancelarPedidos;
		private System.Windows.Forms.CheckBox cbCaixa;
		private System.Windows.Forms.CheckBox cbControleFinanceiro;
		private System.Windows.Forms.CheckBox cbEntregas;
		private System.Windows.Forms.CheckBox cbRelatorios;
		private System.Windows.Forms.CheckBox cbCadastrarProdutos;
		private System.Windows.Forms.CheckBox cbAlterarPrecos;
		private System.Windows.Forms.CheckBox cbCompras;
		private System.Windows.Forms.CheckBox cbCadastrarRecursos;
		private System.Windows.Forms.CheckBox cbCadastrarUsuarios;
		private System.Windows.Forms.CheckBox cbAlterarEstoque;
		private System.Windows.Forms.CheckBox cbScriptBd;
		private System.Windows.Forms.CheckBox cbPreferencias;
		private System.Windows.Forms.CheckBox cbTerminal;
		private System.Windows.Forms.CheckBox cbRegrasNegocio;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btConfirmar;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.CheckBox cbCadastrarGruposDeClientes;
		private System.Windows.Forms.CheckBox cbAlmoxarifado;
		private System.Windows.Forms.CheckBox cbEscritorio;
		private System.Windows.Forms.CheckBox cbAlteraClientePedido;
	}
}