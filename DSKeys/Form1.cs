using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSKeys
{
	public partial class frmMain : Form
	{
		#region Constructors

		public frmMain()
		{
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		private void button1_Click(object sender, EventArgs e)
		{
			DSKey.DSKey dsKey = new DSKey.DSKey();

			dsKey.Numero = Convert.ToInt32(textBox1.Text);
			dsKey.Nome = textBox2.Text;
			dsKey.CNPJ = textBox3.Text;
			dsKey.Endereco = textBox4.Text;
			dsKey.Telefone = textBox5.Text;
			dsKey.Validade = dateTimePicker1.Value;

			Generator.Generate(dsKey);

			Limpar();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DSKey.DSKey dsKey = Generator.Read();

			textBox1.Text = dsKey.Numero.ToString();
			textBox2.Text = dsKey.Nome;
			textBox3.Text = dsKey.CNPJ;
			textBox4.Text = dsKey.Endereco;
			textBox5.Text = dsKey.Telefone;
			dateTimePicker1.Value = dsKey.Validade;
		}

		private void Limpar()
		{
			textBox1.Clear();
			textBox2.Clear();
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			dateTimePicker1.Value = DateTime.Now;
		}

		#endregion Methods
	}
}