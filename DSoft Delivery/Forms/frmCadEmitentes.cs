using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftCore;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class frmCadEmitentes : Form
	{
		#region Fields

		private char Situacao;
		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public frmCadEmitentes(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		#endregion Constructors

		#region Methods

		private void Atualizar()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEmitentes(ds);

			dataGridView1.DataSource = ds.Tables[0];

			for (int i = 0; i < dataGridView1.Rows.Count; i++)
			{
				if (dataGridView1.Rows[i].Cells["situacao"].Value.ToString() == "C")
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
				}
			}
		}

		private void btCancelar_Click(object sender, EventArgs e)
		{
			Cancelar();
		}

		private void btIncluir_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			Limpar();
		}

		private void btSair_Click(object sender, EventArgs e)
		{
			Sair();
		}

		private void Cancelar()
		{
			if (btCancelar.Text == "&Cancelar - F4")
			{
				if (_dsoftBd.CancelarEmitente(Util.LimpaFormatacao(mbCnpj.Text)))
				{
					Limpar();
					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.ReativarEmitente(Util.LimpaFormatacao(mbCnpj.Text)))
				{
					Limpar();
					Atualizar();
				}
			}
		}

		void CarregarEstados()
		{
			DataSet ds = new DataSet();

			_dsoftBd.CarregarEstados(ds);

			cbUf.Items.Clear();

			if (ds != null && ds.Tables.Count > 0)
			{
				foreach (DataRow d in ds.Tables[0].Rows)
				{
					cbUf.Items.Add(d[0].ToString() + " - " + d[1].ToString());
				}
			}
		}

		void CarregarMunicipios()
		{
			DataSet ds = new DataSet();

			if (cbUf.Text.Length < 2)
				return;

			_dsoftBd.CarregarMunicipios(ds, cbUf.Text.Substring(0, 2));

			cbMunicipio.Items.Clear();

			if (ds != null && ds.Tables.Count > 0)
			{
				foreach (DataRow d in ds.Tables[0].Rows)
				{
					cbMunicipio.Items.Add(d[1].ToString());
				}
			}
		}

		private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
		{
			CarregarMunicipios();
		}

		private void confirmarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Incluir();
		}

		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		{
			int row;

			if (dataGridView1.SelectedRows.Count < 1)
				return;

			row = dataGridView1.SelectedRows[0].Index;

			tbRazaoSocial.Text = dataGridView1.Rows[row].Cells["razao_social"].Value.ToString();
			tbNomeFantasia.Text = dataGridView1.Rows[row].Cells["nome_fantasia"].Value.ToString();
			mbCnpj.Text = long.Parse(dataGridView1.Rows[row].Cells["cnpj"].Value.ToString()).ToString("00000000000000");
			tbInscricaoEstadual.Text = dataGridView1.Rows[row].Cells["inscricao_estadual"].Value.ToString();
			tbCnaeFiscal.Text = dataGridView1.Rows[row].Cells["cnae_fiscal"].Value.ToString();
			tbInscricaoMunicipal.Text = dataGridView1.Rows[row].Cells["inscricao_municipal"].Value.ToString();
			tbLogradouro.Text = dataGridView1.Rows[row].Cells["logradouro"].Value.ToString();
			tbNumero.Text = dataGridView1.Rows[row].Cells["numero"].Value.ToString();
			tbComplemento.Text = dataGridView1.Rows[row].Cells["complemento"].Value.ToString();
			tbBairro.Text = dataGridView1.Rows[row].Cells["bairro"].Value.ToString();
			mbCep.Text = dataGridView1.Rows[row].Cells["cep"].Value.ToString();
			tbPais.Text = dataGridView1.Rows[row].Cells["pais"].Value.ToString();
			cbUf.Text = dataGridView1.Rows[row].Cells["uf"].Value.ToString();
			cbMunicipio.Text = dataGridView1.Rows[row].Cells["municipio"].Value.ToString();
			tbTelefone.Text = dataGridView1.Rows[row].Cells["telefone"].Value.ToString();
			tbRNTRC.Text = dataGridView1.Rows[row].Cells["rntrc"].Value.ToString();

			btIncluir.Text = "Confirmar - F2";

			if ((Situacao = dataGridView1.Rows[row].Cells["situacao"].Value.ToString()[0]) == 'A')
			{
				btCancelar.Enabled = true;
			}
			else
			{
				btCancelar.Text = "&Reativar - F4";
				btCancelar.Enabled = true;
			}

			mbCnpj.ReadOnly = true;

			btIncluir.Text = "Conf&irmar - F2";
		}

		private void frmCadEmitentes_Load(object sender, EventArgs e)
		{
			Atualizar();

			CarregarEstados();
		}

		private void Incluir()
		{
			if (tbRazaoSocial.Text.Length < 1)
				return;

			if (!cbUf.Items.Contains(cbUf.Text))
			{
				MessageBox.Show("Campo 'UF' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbUf.Focus();

				return;
			}

			if (!cbMunicipio.Items.Contains(cbMunicipio.Text))
			{
				MessageBox.Show("Campo 'municipio' inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				cbMunicipio.Focus();

				return;
			}

			Emitente emitente = new Emitente();

			long cnpj;
			long.TryParse(Util.LimpaFormatacao(mbCnpj.Text), out cnpj);

			emitente.RazaoSocial = tbRazaoSocial.Text;
			emitente.NomeFantasia = tbNomeFantasia.Text;
			emitente.Cnpj = cnpj;
			emitente.InscricaoEstadual = tbInscricaoEstadual.Text;
			emitente.CNAEFiscal = tbCnaeFiscal.Text;
			emitente.InscricaoMunicipal = tbInscricaoMunicipal.Text;
			emitente.Logradouro = tbLogradouro.Text;
			emitente.Numero = tbNumero.Text;
			emitente.Complemento = tbComplemento.Text;
			emitente.Bairro = tbBairro.Text;
			emitente.Cep = mbCep.Text;
			emitente.Pais = tbPais.Text;
			emitente.Uf = cbUf.Text;
			emitente.Municipio = cbMunicipio.Text;
			emitente.Telefone = tbTelefone.Text;
			emitente.RNTRC = tbRNTRC.Text;

			if (btIncluir.Text == "&Incluir - F2")
			{
				if (_dsoftBd.NovoEmitente(emitente))
				{
					Limpar();

					Atualizar();
				}
			}
			else
			{
				if (_dsoftBd.AlterarEmitente(emitente))
				{
					Limpar();

					Atualizar();
				}
			}
		}

		private void Limpar()
		{
			foreach (Control c in Controls)
			{
				if (c is TextBox || c is ComboBox || c is MaskedTextBox)
				{
					c.Text = string.Empty;
				}
			}

			btIncluir.Text = "&Incluir - F2";

			btCancelar.Text = "&Cancelar - F4";
			btCancelar.Enabled = false;

			mbCnpj.ReadOnly = false;

			tbRazaoSocial.Focus();
		}

		private void Sair()
		{
			Close();
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Sair();
		}

		#endregion Methods
	}
}