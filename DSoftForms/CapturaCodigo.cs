using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DSoftBd;

using DSoftModels;

namespace DSoft_Delivery
{
	public partial class CapturaCodigo : Form
	{
		#region Fields

		public string Codigo;
		public string Texto;
		public string Titulo;

		private Bd _dsoftBd;
		private Usuario _usuario;

		#endregion Fields

		#region Constructors

		public CapturaCodigo(Bd bd, Usuario usuario)
		{
			InitializeComponent();

			_dsoftBd = bd;
			_usuario = usuario;
		}

		public CapturaCodigo(string titulo, string texto)
		{
			InitializeComponent();

			Titulo = titulo;
			Texto = texto;
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			int codigo;

			if (tbCodigo.Text.Length < 1)
			{
				MessageBox.Show("Digite o código do vendedor.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbCodigo.SelectAll();
				tbCodigo.Focus();

				return;
			}

			if (!int.TryParse(tbCodigo.Text, out codigo))
			{
				MessageBox.Show("Código deve ser numérico.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

				tbCodigo.SelectAll();
				tbCodigo.Focus();

				return;
			}

			if (_dsoftBd != null)
			{
				if (!_dsoftBd.RecursoAtivo(codigo))
				{
					MessageBox.Show("Código inválido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);

					tbCodigo.SelectAll();
					tbCodigo.Focus();

					return;
				}
			}

			Codigo = tbCodigo.Text;

			DialogResult = DialogResult.OK;

			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

			Close();
		}

		private void frmCapturaCodigo_Load(object sender, EventArgs e)
		{
			Text = Titulo;
			lbTexto.Text = Texto;

			tbCodigo.Focus();
		}

		private void tbCodigo_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btConfirmar.Focus();
		}

		#endregion Methods
	}
}