using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DSoftCore
{
	public class Util
	{
		#region Methods

		public static bool CarregarXml(string arquivo)
		{
			//DataSet ds = new DataSet();

			//ds.ReadXml(arquivo);

			//foreach (DataRow d in ds.Tables[1].Rows)
			//{
			//    NpgsqlCommand com = new NpgsqlCommand("insert into municipios (estado, codigo, nome) values (:estado, :codigo, :nome);", Bd.Conn2);

			//    com.Parameters.Add(new NpgsqlParameter("estado", d[0].ToString()));
			//    com.Parameters.Add(new NpgsqlParameter("codigo", int.Parse(d[1].ToString())));
			//    com.Parameters.Add(new NpgsqlParameter("nome", d[2].ToString()));

			//    com.ExecuteNonQuery();
			//}

			return true;
		}

		public static string Centralize(string text, int len)
		{
			int sides = (len - text.Length) / 2;
			string centralized = text.PadRight(text.Length + sides);
			centralized = centralized.PadLeft(text.Length + (sides * 2));
			return centralized;
		}

		public static int Codigo(string texto)
		{
			int i;
			char[] tmp = new char[texto.Length];

			for (i = 0; i < texto.Length; i++)
			{
				if (texto[i] == ' ')
					break;

				tmp[i] = texto[i];
			}

			return int.Parse(new string(tmp, 0, i));
		}

		public static int fibo(int k)
		{
			int prox, atual, anterior;

			atual = 1;
			anterior = 0;

			for (int i = 0; i < k; i++)
			{
				prox = atual;

				atual += anterior;

				anterior = prox;
			}

			return atual;
		}

		public static string Formata(string original, int len)
		{
			char[] intermediario = new char[len];
			string resultado;

			for (int i = 0; i < len; i++)
			{
				if (i < original.Length)
				{
					intermediario[i] = original[i];
				}
				else
				{
					intermediario[i] = ' ';
				}
			}

			resultado = new string(intermediario);

			return resultado;
		}

		public static string Formata(string original, int len, char c)
		{
			char[] intermediario = new char[len];
			string resultado;

			for (int i = 0; i < len; i++)
			{
				if (i < original.Length)
				{
					intermediario[i] = original[i];
				}
				else
				{
					intermediario[i] = c;
				}
			}

			resultado = new string(intermediario);

			return resultado;
		}

		public static string Formata(ulong original, string mascara)
		{
			int posicao = mascara.Length - 1;
			string resultado = string.Empty;

			for (int i = mascara.Length - 1; i >= 0; i--)
			{
				if (mascara[i] == '9' || mascara[i] == '0')
				{
					resultado = (original % 10).ToString() + resultado;

					original /= 10;
				}
				else
				{
					resultado = mascara[i].ToString() + resultado;
				}
			}

			return resultado;
		}

		public static string Formata(string original, string mascara)
		{
			int posicao = original.Length - 1;
			string resultado = string.Empty;

			for (int i = mascara.Length - 1; i >= 0; i--)
			{
				if (mascara[i] == '9' || mascara[i] == '0')
				{
					resultado = original[posicao].ToString() + resultado;

					posicao--;
				}
				else
				{
					resultado = mascara[i].ToString() + resultado;
				}
			}

			return resultado;
		}

		/// <summary>
		/// Formata um código numérico e um nome para apresentação em combobox e listas.
		/// </summary>
		/// <param name="codigo"></param>
		/// <param name="nome"></param>
		/// <returns></returns>
		public static string Formata(int codigo, string nome)
		{
			return string.Format("{0} - {1}", codigo, nome);
		}

		/// <summary>
		/// Formata um código numérico e um nome para apresentação em combobox e listas.
		/// </summary>
		/// <param name="codigo"></param>
		/// <param name="nome"></param>
		/// <returns></returns>
		public static string Formata(long codigo, string nome)
		{
			return string.Format("{0} - {1}", codigo, nome);
		}

		public static string Formata2(double n)
		{
			string temp = n.ToString("0.00");

			return temp.Replace(',', '.');
		}

		public static string Formata4(double n)
		{
			string temp = n.ToString("0.0000");

			return temp.Replace(',', '.');
		}

		public static string LimpaFormatacao(string original)
		{
			string limpa = string.Empty;

			for (int i = 0; i < original.Length; i++)
			{
				if (original[i] >= '0' && original[i] <= '9')
					limpa += original[i].ToString();
			}

			return limpa;
		}

		public static string LimparCaracteresEspeciais(string original)
		{
			string nova = "";

			for (int i = 0; i < original.Length; i++)
			{
				switch (original[i])
				{
					case 'Á':
					case 'À':
					case 'Ã':
					case 'Â':
					case 'Ä':
						nova += 'A';
						break;

					case 'Ç':
						nova += 'C';
						break;

					case 'É':
					case 'È':
					case 'Ê':
					case 'Ë':
						nova += 'E';
						break;

					case 'Í':
					case 'Ì':
					case 'Î':
					case 'Ï':
						nova += 'I';
						break;

					case 'Ó':
					case 'Ò':
					case 'Õ':
					case 'Ô':
					case 'Ö':
						nova += 'O';
						break;

					case 'Ú':
					case 'Ù':
					case 'Û':
					case 'Ü':
						nova += 'U';
						break;

					default:
						nova += original[i];
						break;
				}
			}

			return nova;
		}

		public static string Max(string text, int len)
		{
			if (text.Length > len)
			{
				return new string(text.ToCharArray(), 0, len);
			}
			else
			{
				return text;
			}
		}

		public static string Modulo11(string mensagem)
		{
			char[] pesos = { '2', '3', '4', '5', '6', '7', '8', '9' };
			string msg_peso = string.Empty;
			int p = 0;
			int soma = 0;
			int resto;
			int dv;

			for (int i = mensagem.Length - 1; i >= 0; i--)
			{
				msg_peso = pesos[p].ToString() + msg_peso;

				if (++p == pesos.Length)
					p = 0;
			}

			for (int i = 0; i < mensagem.Length; i++)
			{
				soma += (int.Parse(mensagem[i].ToString()) * int.Parse(msg_peso[i].ToString()));
			}

			resto = soma % 11;

			if (resto < 2)
			{
				dv = 0;
			}
			else
			{
				dv = 11 - resto;
			}

			return dv.ToString();
		}

		public static void Pintar(ref DataGridView dg)
		{
			for (int i = 0; i < dg.Rows.Count; i++)
			{
				switch (dg.Rows[i].Cells["situacao"].Value.ToString())
				{
					case "A": // Aberto/Ativo
						dg.Rows[i].DefaultCellStyle.BackColor = Color.White;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "B": // Bloqueado
						dg.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "C": // Cancelado
						dg.Rows[i].DefaultCellStyle.BackColor = Color.Red;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "E": // Entregue
						dg.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "N": // Pago
						dg.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;

					case "O": // Pago/Saida
						dg.Rows[i].DefaultCellStyle.BackColor = Color.Violet;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "P": // Pago/Entregue
						dg.Rows[i].DefaultCellStyle.BackColor = Color.Green;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						break;

					case "S": // Saida
						dg.Rows[i].DefaultCellStyle.BackColor = Color.LightBlue;
						dg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
						break;
				}
			}
		}

		public static string Randomico(int digitos)
		{
			int min = 1;
			int max;
			string fmt;

			switch (digitos)
			{
				case 1:
					max = 9;
					fmt = "0";
					break;

				case 2:
					max = 99;
					fmt = "00";
					break;

				case 3:
					max = 999;
					fmt = "000";
					break;

				case 4:
					max = 9999;
					fmt = "0000";
					break;

				case 5:
					max = 99999;
					fmt = "00000";
					break;

				case 6:
					max = 999999;
					fmt = "000000";
					break;

				case 7:
					max = 9999999;
					fmt = "0000000";
					break;

				case 8:
					max = 99999999;
					fmt = "00000000";
					break;

				case 9:
					max = 999999999;
					fmt = "000000000";
					break;

				default:
					max = 0;
					fmt = "0";
					break;
			}

			Random rnd = new Random();
			int r = rnd.Next(min, max);

			return r.ToString(fmt);
		}

		public static string ReadFromTag(string content, string open, string close)
		{
			int initial = content.IndexOf(open) + open.Length;
			int last = content.IndexOf(close);

			string value = content.Substring(initial, last - initial);

			return value;
		}

		public static string NotacaoQuantidade(float fracao)
		{
			if (fracao == 0.5)
			{
				return "1/2";
			}
			else if (fracao == (1 / 3) || Convert.ToDecimal(fracao.ToString("0.0")) == (decimal)0.3)
			{
				return "1/3";
			}
			else if (fracao == (1 / 4) || Convert.ToDecimal(fracao.ToString("0.0")) == (decimal)0.2)
			{
				return "1/4";
			}
			else if (fracao == (1 / 8) || Convert.ToDecimal(fracao.ToString("0.0")) == (decimal)0.1)
			{
				return "1/8";
			}
			else
			{
				return fracao.ToString("0.");
			}
		}

		public static int TryParseInt(string s)
		{
			int i;
			int.TryParse(s, out i);
			return i;
		}

		public static int TryParseInt(object o)
		{
			int i;

			if (o == null)
			{
				return 0;
			}

			int.TryParse(o.ToString(), out i);

			return i;
		}

		public static long TryParseLong(string s)
		{
			long l;
			long.TryParse(s, out l);
			return l;
		}

		public static long TryParseLong(object o)
		{
			long l;

			if (o == null)
				return 0;

			long.TryParse(o.ToString(), out l);

			return l;
		}

		public static decimal TryParseDecimal(string s)
		{
			decimal l;
			decimal.TryParse(s, out l);
			return l;
		}

		public static decimal TryParseDecimal(object o)
		{
			decimal l;

			if (o == null)
				return 0;

			decimal.TryParse(o.ToString(), out l);

			return l;
		}

		public static string TryGetValue(object o)
		{
			if (o == null)
				return string.Empty;

			return o.ToString();
		}

		public static char TryGetChar(object o)
		{
			if (o == null || o.ToString().Length < 1)
				return '\0';

			return o.ToString()[0];
		}

		#endregion Methods
	}
}