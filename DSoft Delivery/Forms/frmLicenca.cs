using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoft_Delivery
{
	public partial class frmLicenca : Form
	{
		#region Properties

		private Dictionary<string, DateTime> _chaves;

		#endregion Properties

		#region Constructors

		public frmLicenca()
		{
			InitializeComponent();

			CenterToParent();

			quitButton1.Click += button1_Click;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmLicenca_Load(object sender, EventArgs e)
		{
			InicializarChaves();

			LerLicenca();
		}

		private void LerLicenca()
		{
			if (Licenca.Instance.Demo)
			{
				lbDemo.Visible = true;
			}
			else
			{
				lbNumero.Text = Licenca.Instance.Numero.ToString();
				lbNome.Text = Licenca.Instance.Nome;
				lbCNPJ.Text = Licenca.Instance.CNPJ;
				lbEndereco.Text = Licenca.Instance.Endereco;
				lbTelefone.Text = Licenca.Instance.Telefone;
				lbValidade.Text = Licenca.Instance.Validade.ToShortDateString();
			}
		}

		private void InicializarChaves()
		{
			_chaves = new Dictionary<string, DateTime>();
			_chaves.Add("IJ9HU8", new DateTime(2015, 06, 01));
			_chaves.Add("98H89H", new DateTime(2015, 07, 01));
			_chaves.Add("2J9F9J", new DateTime(2015, 08, 01));
			_chaves.Add("0IJFF8", new DateTime(2015, 09, 01));
			_chaves.Add("VBCU7D", new DateTime(2015, 10, 01));
			_chaves.Add("XNIC0C", new DateTime(2015, 11, 01));
			_chaves.Add("CJIOJV", new DateTime(2015, 12, 01));
			_chaves.Add("E3E7YD", new DateTime(2016, 01, 01));
			_chaves.Add("F8HFJH", new DateTime(2016, 02, 01));
			_chaves.Add("Q198UQ", new DateTime(2016, 03, 01));
			_chaves.Add("L009IF", new DateTime(2016, 04, 01));
			_chaves.Add("KJFIJ8", new DateTime(2016, 05, 01));
			_chaves.Add("1IJIDJ", new DateTime(2016, 06, 01));
			_chaves.Add("8ZDH9D", new DateTime(2016, 07, 01));
			_chaves.Add("554DHD", new DateTime(2016, 08, 01));
			_chaves.Add("4FDFF8", new DateTime(2016, 09, 01));
			_chaves.Add("HGADUH", new DateTime(2016, 10, 01));
			_chaves.Add("JHHB88", new DateTime(2016, 11, 01));
			_chaves.Add("NVHVHF", new DateTime(2016, 12, 01));
			_chaves.Add("8Y87FF", new DateTime(2017, 01, 01));
			_chaves.Add("987F7F", new DateTime(2017, 02, 01));
			_chaves.Add("53437D", new DateTime(2017, 03, 01));
			_chaves.Add("766F58", new DateTime(2017, 04, 01));
			_chaves.Add("23HG7H", new DateTime(2017, 05, 01));
			_chaves.Add("88FYF7", new DateTime(2017, 06, 01));
			_chaves.Add("BCBCUU", new DateTime(2017, 07, 01));
			_chaves.Add("3A3A3F", new DateTime(2017, 08, 01));
			_chaves.Add("747NNF", new DateTime(2017, 09, 01));
			_chaves.Add("2987G2", new DateTime(2017, 10, 01));
			_chaves.Add("78D7DH", new DateTime(2017, 11, 01));
			_chaves.Add("9UHBCU", new DateTime(2017, 12, 01));
			_chaves.Add("VKJHVV", new DateTime(2018, 01, 01));
			_chaves.Add("VUU238", new DateTime(2018, 02, 01));
			_chaves.Add("PIDN1D", new DateTime(2018, 03, 01));
			_chaves.Add("ZARFRS", new DateTime(2018, 04, 01));
			_chaves.Add("AZKJAH", new DateTime(2018, 05, 01));
			_chaves.Add("QUYQ7J", new DateTime(2018, 06, 01));
			_chaves.Add("JJIFI2", new DateTime(2018, 07, 01));
			_chaves.Add("GGJGHH", new DateTime(2018, 08, 01));
			_chaves.Add("773JSV", new DateTime(2018, 09, 01));
			_chaves.Add("MVHWT2", new DateTime(2018, 10, 01));
			_chaves.Add("BDVFWR", new DateTime(2018, 11, 01));
			_chaves.Add("JDHSBA", new DateTime(2018, 12, 01));
		}

		private void tbChave_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				if (_chaves.ContainsKey(tbChave.Text))
				{
					DSKey.DSKey key = new DSKey.DSKey();
					key.CNPJ = Licenca.Instance.CNPJ;
					key.Endereco = Licenca.Instance.Endereco;
					key.Nome = Licenca.Instance.Nome;
					key.Numero = Licenca.Instance.Numero;
					key.Telefone = Licenca.Instance.Telefone;
					key.Validade = _chaves[tbChave.Text];

					Generator.Generate(key);

					Licenca.Instance.LerLicenca();

					tbChave.Text = string.Empty;
					LerLicenca();
				}
			}
		}

		private void sairToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		#endregion Methods
	}
}