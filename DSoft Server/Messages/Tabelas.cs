using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;

using DSoftBd;
using DSoftParameters;

namespace DSoft_Server.Messages
{
	public class Tabelas : IMessage
	{
		#region Properties

		public string DefaultResponse
		{
			get { return string.Empty; }
		}

		public string Id
		{
			get { return "TABELAS"; }
		}

		#endregion Properties

		#region Methods

		public bool ProcessXml(Bd bd, System.Xml.XmlElement element, out string answer, out int handle)
		{
			try
			{
				StringBuilder sb = new StringBuilder();

				// Começamos carregando os produtos
				sb.Append("<TABELAS><PRODUTOS>");

				DataSet ds = new DataSet();
				bd.ProdutosPrecos(1, ds);

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					sb.AppendFormat("<PRODUTO><CODIGO>{0}</CODIGO><NOME>{1}</NOME><PRECO>{2}</PRECO><TIPO>{3}</TIPO></PRODUTO>", dr["codigo"].ToString(), dr["nome"].ToString(), dr["preco"].ToString(), dr["tipo"].ToString());
				}

				sb.Append("</PRODUTOS>");

				// Carregamos os clientes
				sb.Append("<CLIENTES>");

				ds = new DataSet();
				bd.CarregarClientesInternos(ds);

				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					sb.AppendFormat("<CLIENTE><CODIGO>{0}</CODIGO><NOME>{1}</NOME></CLIENTE>", dr["codigo"].ToString(), dr["nome"].ToString());
				}

				sb.Append("</CLIENTES>");

				sb.Append("<OBSERVACOES>");

				ds = new DataSet();

				if (RegrasDeNegocio.Instance.ItensAdicionaisPorProduto)
				{
					sb.Append("<MODO>PRODUTO</MODO>");

					bd.CarregarItensAdicionaisPorProduto(ds);

					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						decimal adicional;
						decimal.TryParse(dr["adicional"].ToString(), out adicional);

						if (adicional > 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (+{1})</DESCRICAO><VALOR>{2}</VALOR><PRODUTO>{3}</PRODUTO></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString(), dr["produto"].ToString());
						}
						else if (adicional < 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (-{1})</DESCRICAO><VALOR>{2}</VALOR><PRODUTO>{3}</PRODUTO></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString(), dr["produto"].ToString());
						}
						else
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0}</DESCRICAO><VALOR>{1}</VALOR><PRODUTO>{2}</PRODUTO></OBSERVACAO>", dr["descricao"].ToString(), dr["adicional"].ToString(), dr["produto"].ToString());
						}
					}
				}
				else if (RegrasDeNegocio.Instance.ItensAdicionaisPorTipoDeProduto)
				{
					sb.Append("<MODO>TIPO</MODO>");

					bd.CarregarItensAdicionaisPorTipo(ds);

					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						decimal adicional;
						decimal.TryParse(dr["adicional"].ToString(), out adicional);

						if (adicional > 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (+{1})</DESCRICAO><VALOR>{2}</VALOR><TIPO>{3}</TIPO></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString(), dr["tipo"].ToString());
						}
						else if (adicional < 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (-{1})</DESCRICAO><VALOR>{2}</VALOR><TIPO>{3}</TIPO></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString(), dr["tipo"].ToString());
						}
						else
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0}</DESCRICAO><VALOR>{1}</VALOR><TIPO>{2}</TIPO></OBSERVACAO>", dr["descricao"].ToString(), dr["adicional"].ToString(), dr["tipo"].ToString());
						}
					}
				}
				else
				{
					sb.Append("<MODO>GERAL</MODO>");

					bd.CarregarItensAdicionais(ds);

					foreach (DataRow dr in ds.Tables[0].Rows)
					{
						decimal adicional;
						decimal.TryParse(dr["adicional"].ToString(), out adicional);

						if (adicional > 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (+{1})</DESCRICAO><VALOR>{2}</VALOR></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString());
						}
						else if (adicional < 0)
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0} (-{1})</DESCRICAO><VALOR>{2}</VALOR></OBSERVACAO>",
								dr["descricao"].ToString(), adicional.ToString("0.00"), dr["adicional"].ToString());
						}
						else
						{
							sb.AppendFormat("<OBSERVACAO><DESCRICAO>{0}</DESCRICAO><VALOR>{1}</VALOR></OBSERVACAO>", dr["descricao"].ToString(), dr["adicional"].ToString());
						}
					}
				}

				sb.Append("</OBSERVACOES></TABELAS>");

				answer = sb.ToString();
				handle = 0;

				return true;
			}
			catch (Exception)
			{
				answer = "<TABELAS><ERRO>Erro ao carregar as tabelas.</ERRO></TABELAS>";
				handle = 0;

				return true;
			}
		}

		public bool ProcessConfirmation(DSoftBd.Bd bd, int handle)
		{
			return true;
		}

		public bool ProcessDisposing(int handle)
		{
			return true;
		}

		#endregion Methods
	}
}