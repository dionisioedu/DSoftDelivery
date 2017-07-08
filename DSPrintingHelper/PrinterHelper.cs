using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DSoftBd;
using DSoftCore;
using DSoftModels;
using DSoftParameters;

namespace DSPrintingHelper
{
	public class PrinterHelper
	{
		#region Fields

		private static string _buffer;

		#endregion Fields

		#region Constructors

		public PrinterHelper()
		{
		}

		#endregion Constructors

		#region Properties

		public static int Colunas
		{
			get; set;
		}

		#endregion Properties

		#region Methods

		public static bool Print(string impressora, string buff)
		{
			return RawPrinterHelper.SendStringToPrinter(impressora, buff);
		}

		public static bool Print(string buff)
		{
			return RawPrinterHelper.SendStringToPrinter(Terminal.Impressora(), buff);
		}

		public static void PrintBuffer(string buff)
		{
			_buffer += buff;
		}

		public static void PrintBuffer()
		{
			Print(_buffer);

			_buffer = string.Empty;
		}

		private static void CleanBuffer()
		{
			_buffer = "";
		}

		public static void PrintCancelItem(long cliente, List<ItemPedido> itens, Bd bd)
		{
			StringBuilder sbuild = new StringBuilder();

			sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));
			sbuild.AppendLine("* CANCELAMENTO DE ITEM *");
			sbuild.AppendLine(string.Format("* MESA {0} *", cliente));
			sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));

			foreach (ItemPedido item in itens)
			{
				if (item.Secundario)
				{
					sbuild.Append(" >>");
				}

				sbuild.AppendLine(string.Format("{0:000000} - {1} {2,4}", item.Produto, Util.Formata(item.ProdutoNome, 18), item.Quantidade));
			}

			int impressora = bd.ProdutoTipoImpressoraExterna(bd.ProdutoTipo(itens[0].Produto));

			if (impressora == 1)
			{
				Print(Terminal.ImpressoraExterna1, sbuild.ToString());
				CutPaper(Terminal.ImpressoraExterna1);
			}
			else if (impressora == 2)
			{
				Print(Terminal.ImpressoraExterna2, sbuild.ToString());
				CutPaper(Terminal.ImpressoraExterna2);
			}
		}

		public static void PrintClosing(Fechamento fechamento, int pedidos_volume, int pedidos_itens, decimal pedidos_total, DataTable caixas, DataTable entradas)
		{
			int colunas = 40;
			string buffer = "";

			buffer += "FECHAMENTO DE CAIXA   No " + fechamento.Indice.ToString() + "\n";
			buffer += fechamento.Data.ToShortDateString() + "\n";
			buffer += new string('=', colunas) + "\n";
			buffer += "PEDIDOS\n-------\n";
			buffer += "VOLUME" + pedidos_volume.ToString().PadLeft(colunas - 6) + "\n";
			buffer += "TOTAL" + pedidos_total.ToString("##,###,##0.00").PadLeft(colunas - 5) + "\n";
			buffer += new string('.', colunas) + "\n";

			decimal dinheiro, cartao, visa, master, cheque, debito;
			decimal dinheiro_total = 0;
			decimal cartao_total = 0;
			decimal visa_total = 0;
			decimal master_total = 0;
			decimal cheque_total = 0;
			decimal debito_total = 0;

			foreach (DataRow r in entradas.Rows)
			{
				dinheiro = (r["dinheiro"].ToString() == "") ? 0 : Convert.ToDecimal(r["dinheiro"]);
				cartao = (r["cartao"].ToString() == "") ? 0 : Convert.ToDecimal(r["cartao"]);
				visa = (r["visa"].ToString() == "") ? 0 : Convert.ToDecimal(r["visa"]);
				master = (r["master"].ToString() == "") ? 0 : Convert.ToDecimal(r["master"]);
				cheque = (r["cheque"].ToString() == "") ? 0 : Convert.ToDecimal(r["cheque"]);
				debito = (r["debito"].ToString() == "") ? 0 : Convert.ToDecimal(r["debito"]);

				dinheiro_total += dinheiro;
				cartao_total += cartao;
				visa_total += visa;
				master_total += master;
				cheque_total += cheque;
				debito_total += debito;
			}

			buffer += "ENTRADAS\n--------\n";
			buffer += "DINHEIRO" + dinheiro_total.ToString("##,###,##0.00").PadLeft(colunas - 8) + "\n";
			buffer += "CARTAO" + cartao_total.ToString("##,###,##0.00").PadLeft(colunas - 6) + "\n";
			buffer += "VISA" + visa_total.ToString("##,###,##0.00").PadLeft(colunas - 4) + "\n";
			buffer += "MASTER" + master_total.ToString("##,###,##0.00").PadLeft(colunas - 6) + "\n";
			buffer += "CHEQUE" + cheque_total.ToString("##,###,##0.00").PadLeft(colunas - 6) + "\n";
			buffer += "DEBITO" + debito_total.ToString("##,###,##0.00").PadLeft(colunas - 6) + "\n";
			buffer += new string('.', colunas) + "\n";
			buffer += "TOTAL" + (dinheiro_total + cartao_total + visa_total + master_total + cheque_total + debito_total).ToString("##,###,##0.00").PadLeft(colunas - 5) + "\n";
			buffer += new string('=', colunas) + "\n\n\n\n\n\n\n\n\n\n";

			PrintBuffer(buffer);
			PrintBuffer();
		}

		public static void PrintDoubleLine(bool buffer = false)
		{
			PrintLine('=', buffer);
		}

		public static bool PrintHeader(ILicenca licenca)
		{
			try
			{
				PrintBuffer(Util.Centralize(licenca.Nome, Terminal.ImpressoraColunas) + "\n");
				PrintBuffer(Util.Centralize(licenca.Endereco.Split("&".ToCharArray())[0], Terminal.ImpressoraColunas) + "\n");

				if (licenca.Endereco.Split("&".ToCharArray()).Length > 1)
				{
					PrintBuffer(Util.Centralize(licenca.Endereco.Split("&".ToCharArray())[1], Terminal.ImpressoraColunas) + "\n");
				}

				PrintBuffer(Util.Centralize(licenca.Telefone, Terminal.ImpressoraColunas) + "\n");
				PrintBuffer(Util.Centralize(Preferencias.MensagemCupom, Terminal.ImpressoraColunas) + "\n");
				PrintBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");

				if (licenca.Demo)
				{
					PrintBuffer(Util.Centralize("*** VERSAO DE DEMOSTRACAO ***", Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message, "DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public static void PrintItemOrder(Pedido pedido, Bd bd)
		{
			StringBuilder string0 = new StringBuilder();
			StringBuilder string1 = new StringBuilder();
			StringBuilder string2 = new StringBuilder();

			bool header0 = false;
			bool header1 = false;
			bool header2 = false;

			string linha = new string('-', Terminal.ImpressoraColunas);

			for (int i = 0; i < pedido.ItensPedido.Count; i++)
			{
				ItemPedido item = pedido.ItensPedido[i];

				// Decobrimos em qual impressora devemos imprimir o cancelamento
				int impressora = bd.ProdutoTipoImpressoraExterna(bd.ProdutoTipo(item.Produto));
				bool imprime_producao = bd.ProdutoTipoProducao(bd.ProdutoTipo(item.Produto));

				if (imprime_producao && impressora < 1)
				{
					if (!header0)
					{
						string0.AppendLine("\n");
						string0.AppendLine(linha);
						string0.AppendLine(string.Format("* ADICIONAR ITENS A MESA {0}*", pedido.Cliente));
						//string0.AppendLine(linha);

						header0 = true;
					}

					if (!item.Secundario)
					{
						string0.Append(linha);
					}

					//string0.AppendLine(string.Format("{0:000000} - {1} {2}", item.Produto, Util.Formata(item.ProdutoNome, 18), item.Quantidade.ToString("0.0")));
					string0.AppendLine(string.Format("{0} {1}", Util.NotacaoQuantidade(item.Quantidade).PadLeft(3, ' '), item.ProdutoNome));

					// Imprimimos os itens adicionais
					foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					{
						string0.AppendLine(string.Format("##{0}", adicional.ToString().Trim()));
					}

					// Verificamos se temos de imprimir alguma observacao
					if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
					{
						string0.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

						if (pedido.ItensPedido[i].Observacao.Length >= 40)
						{
							string0.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
						}
					}
				}
				else if (impressora == 1)
				{
					if (!header1)
					{
						string1.AppendLine("\n");
						string1.AppendLine(linha);
						string1.AppendLine(string.Format("* ADICIONAR ITENS A MESA {0}*", pedido.Cliente));
						//string1.AppendLine(linha);

						header1 = true;
					}

					if (!item.Secundario)
					{
						string1.Append(linha);
					}

					//string1.AppendLine(string.Format("{0:000000} - {1} {2}", item.Produto, Util.Formata(item.ProdutoNome, 18), item.Quantidade.ToString("0.0")));
					string1.AppendLine(string.Format("{0} {1}", Util.NotacaoQuantidade(item.Quantidade).PadLeft(3, ' '), item.ProdutoNome));

					// Imprimimos os itens adicionais
					foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					{
						string1.AppendLine(string.Format("##{0}", adicional.ToString().Trim()));
					}

					// Verificamos se temos de imprimir alguma observacao
					if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
					{
						string1.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

						if (pedido.ItensPedido[i].Observacao.Length >= 40)
						{
							string1.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
						}
					}
				}
				else if (impressora == 2)
				{
					if (!header2)
					{
						string2.AppendLine("\n");
						string2.AppendLine(linha);
						string2.AppendLine(string.Format("* ADICIONAR DE ITENS A MESA {0}*", pedido.Cliente));
						//string2.AppendLine(linha);

						header2 = true;
					}

					if (!item.Secundario)
					{
						string2.Append(linha);
					}

					//string2.AppendLine(string.Format("{0:000000} - {1} {2}", item.Produto, Util.Formata(item.ProdutoNome, 18), item.Quantidade.ToString("0.0")));
					string2.AppendLine(string.Format("{0} {1}", Util.NotacaoQuantidade(item.Quantidade).PadLeft(3, ' '), item.ProdutoNome));

					// Imprimimos os itens adicionais
					foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					{
						string2.AppendLine(string.Format("##{0}", adicional.ToString().Trim()));
					}

					// Verificamos se temos de imprimir alguma observacao
					if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
					{
						string2.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

						if (pedido.ItensPedido[i].Observacao.Length >= 40)
						{
							string2.AppendLine("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
						}
					}
				}
			}

			if (string0.Length > 0)
			{
				string0.AppendLine(linha);
				string0.AppendLine("\n");
				string0.AppendLine("\n");
				string0.AppendLine("\n");

				Print(Terminal.ImpressoraExterna1, string0.ToString());
				CutPaper(Terminal.ImpressoraExterna1);
			}

			if (string1.Length > 0)
			{
				string1.AppendLine(linha);
				string1.AppendLine("\n");
				string1.AppendLine("\n");
				string1.AppendLine("\n");

				Print(Terminal.ImpressoraExterna1, string1.ToString());
				CutPaper(Terminal.ImpressoraExterna1);
			}

			if (string2.Length > 0)
			{
				string2.AppendLine(linha);
				string2.AppendLine("\n");
				string2.AppendLine("\n");
				string2.AppendLine("\n");

				Print(Terminal.ImpressoraExterna2, string2.ToString());
				CutPaper(Terminal.ImpressoraExterna2);
			}
		}

		public static void PrintLine(bool buffer = false)
		{
			PrintLine('-', buffer);
		}

		public static void PrintLine(char c, bool buffer = false)
		{
			string s = new string(c, Terminal.ImpressoraColunas);

			if (buffer)
			{
				_buffer += s;
			}
			else
			{
				Print(s + Environment.NewLine);
			}
		}

		public static string PrintOrder(Pedido pedido, Caixa caixa, int usuario, Bd bd, ILicenca licenca, bool print = true, bool print_order = true)
		{
			bool unico_tipo = true;
			int tipos_produtos = 0;
			decimal dinheiro;
			string linha;
			int nome_len;

			linha = new string('-', Terminal.ImpressoraColunas) + "\n";
			nome_len = Terminal.ImpressoraColunas - 24;

			try
			{
				if (licenca != null)
				{
					PrintHeader(licenca);
				}

			#if COLEGIO_CONTINENTAL
				PrintBuffer(DateTime.Now.ToString("dd/MM/yy") + "  " + DateTime.Now.ToString("HH:mm:ss") + "   COLEGIO CONTINENTAL\n");
			#else
				PrintBuffer(DateTime.Now.ToString("dd/MM/yy") + "  " + DateTime.Now.ToString("HH:mm:ss") + "   " + caixa.Codigo.ToString() + " - " + caixa.Descricao + "\n");
			#endif
				if (pedido.ClientePedido() != 0)
				{
					string endereco = string.Empty;
					string bairro = string.Empty;
					string tel1, tel2, celular;
					string referencia = string.Empty;

					bd.ClienteEndereco(pedido.ClientePedido(), out endereco, out bairro);
					bd.ClienteTelefones(pedido.ClientePedido(), out tel1, out tel2, out celular);
					bd.ClienteReferencia(pedido.ClientePedido(), out referencia);

					PrintBuffer(linha);
			#if COLEGIO_CONTINENTAL
					string nome_cliente, nome_grupo;
					nome_cliente = Bd.ClienteNome(pedido.ClientePedido());
					nome_grupo = Bd.ClienteGrupoDescricao(Bd.ClienteGrupo(pedido.ClientePedido()));

					nome_cliente = Util.Formata(nome_cliente, 32);
					nome_grupo = Util.Formata(nome_grupo, 12);

					PrintBuffer(nome_cliente + " - " + nome_grupo + "\n");
			#else
					PrintBuffer("DADOS DO CLIENTE                        \n");
					PrintBuffer(Util.Max(pedido.ClientePedido().ToString() + " - " + bd.ClienteNome(pedido.ClientePedido()), Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(Util.Max(endereco, Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(Util.Max(bairro, Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(Util.Max((tel1 == "0" ? " " : tel1) + "   " + (tel2 == "0" ? " " : tel2) + "   " + (celular == "0" ? " " : celular), Terminal.ImpressoraColunas) + "\n");
			#endif
					if (referencia.Length > 0)
					{
						PrintBuffer(Util.Max(referencia, Terminal.ImpressoraColunas) + "\n");
					}
				}

				PrintBuffer(linha);
				PrintBuffer("COMANDA: " + pedido.NumeroPedido() + "\n");
				PrintBuffer(linha);

				PrintBuffer(Util.Centralize("CUPOM NAO FISCAL", Terminal.ImpressoraColunas) + "\n");

				//if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
				//{
					PrintBuffer(string.Format("QTD PRODUTO{0}VALOR R$\n", new string(' ', Terminal.ImpressoraColunas - 20)));
				//}
				//else
				//{
				//	PrintBuffer("ITEM CODIGO DESCRICAO" + new string(' ', Terminal.ImpressoraColunas - 37) + "QTD    VALOR R$\n");
				//}

				PrintBuffer(linha);

				bool primeiro_item = true;

				for (int i = 0; i < pedido.ItensQtd; i++)
				{
					string prod = string.Empty;

					if (pedido.ItensPedido[i] == null)
						break;

					if (pedido.ItensPedido[i].Situacao != 'A')
						continue;

					ItemPedido itemPedido = pedido.ItensPedido[i];

					prod = bd.ProdutoNome(pedido.ItensPedido[i].Produto);

	//				if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
					//{
						StringBuilder item_linha = new StringBuilder();

						nome_len = Terminal.ImpressoraColunas - 13;

						if (prod.Length < nome_len)
							prod = prod.PadRight(nome_len);
						else if (prod.Length > nome_len)
							prod = prod.Remove(nome_len, (prod.Length - nome_len));

						item_linha.Append(Util.NotacaoQuantidade(itemPedido.Quantidade).PadLeft(3, ' '));
						item_linha.Append(" ");
						item_linha.Append(prod);
						item_linha.Append(" ");
						item_linha.Append(itemPedido.Preco.ToString("#,##0.00").PadLeft(8));
						item_linha.Append("\n");

						if (!primeiro_item)
						{
							if (!itemPedido.Secundario)
							{
								PrintBuffer(linha);
							}
						}
						else
						{
							primeiro_item = false;
						}

						PrintBuffer(item_linha.ToString());

						// Imprimimos os itens adicionais
						foreach (ItemAdicional adicional in itemPedido.ItensAdicionais)
						{
							PrintBuffer(string.Format("    ##{0}\n", adicional.ToString().Trim()));
						}

						// Verificamos se temos de imprimir alguma observacao
						if (!string.IsNullOrEmpty(itemPedido.Observacao))
						{
							PrintBuffer("    #" + Util.Formata(itemPedido.Observacao, Terminal.ImpressoraColunas - 5) + "\n");

							if (itemPedido.Observacao.Length >= 40)
							{
								PrintBuffer("    #" + Util.Formata(itemPedido.Observacao.Remove(0, Terminal.ImpressoraColunas - 5), Terminal.ImpressoraColunas - 5) + "\n");
							}
						}

						// Vamos verificar se o pedido tem apenas um tipo de produto, para evitar de imprimir o ticket da produção
						if (unico_tipo)
						{
							if (tipos_produtos == 0)
							{
								tipos_produtos = bd.ProdutoTipo(itemPedido.Produto);
							}
							else if (tipos_produtos != bd.ProdutoTipo(itemPedido.Produto))
							{
								unico_tipo = false;
							}
						}
					//}
					//else
					//{
					//    if (prod.Length < nome_len)
					//        prod = prod.PadRight(nome_len);
					//    else if (prod.Length > nome_len)
					//        prod = prod.Remove(nome_len, (prod.Length - nome_len));

					//    if (!pedido.ItensPedido[i].Secundario)
					//    {
					//        PrintBuffer(pedido.ItensPedido[i].NumeroItem().ToString("000") + "  " +
					//            pedido.ItensPedido[i].Produto.ToString("000") + " " +
					//            prod + " " +
					//            pedido.ItensPedido[i].Quantidade.ToString("0.0") + " " +
					//            pedido.ItensPedido[i].Preco.ToString("###,##0.00").PadLeft(10) + "\n");

					//        // Imprimimos os itens adicionais
					//        foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					//        {
					//            PrintBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
					//        }

					//        // Verificamos se temos de imprimir alguma observacao
					//        if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
					//        {
					//            PrintBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

					//            if (pedido.ItensPedido[i].Observacao.Length >= 40)
					//            {
					//                PrintBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
					//            }
					//        }

					//        // Vamos verificar se o pedido tem apenas um tipo de produto, para evitar de imprimir o ticket da produção
					//        if (unico_tipo)
					//        {
					//            if (tipos_produtos == 0)
					//            {
					//                tipos_produtos = bd.ProdutoTipo(pedido.ItensPedido[i].Produto);
					//            }
					//            else if (tipos_produtos != bd.ProdutoTipo(pedido.ItensPedido[i].Produto))
					//            {
					//                unico_tipo = false;
					//            }
					//        }
					//    }
					//    else
					//    {
					//        PrintBuffer("  >> " + pedido.ItensPedido[i].Produto.ToString("000") + " " +
					//            prod + " " + pedido.ItensPedido[i].Quantidade.ToString("0.0") + "\n");

					//        // Imprimimos os itens adicionais
					//        foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
					//        {
					//            PrintBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
					//        }

					//        // Verificamos se temos de imprimir alguma observacao
					//        if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
					//        {
					//            PrintBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

					//            if (pedido.ItensPedido[i].Observacao.Length >= 40)
					//            {
					//                PrintBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
					//            }
					//        }
					//    }
					//}
				}

				PrintBuffer(linha);

				if (pedido.TaxaDeEntrega > 0)
				{
					PrintBuffer("TAXA DE ENTREGA R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.TaxaDeEntrega.ToString("0.00").PadLeft(10) + "\n");
					PrintBuffer(linha);
				}

				PrintBuffer("TOTAL R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.TotalPedido.ToString("###,##0.00").PadLeft(10) + "\n");

				if (pedido.Troco > 0)
				{
					dinheiro = pedido.Troco - pedido.TotalPedido;

					PrintBuffer("TROCO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + dinheiro.ToString("###,##0.00").PadLeft(10) + "\n");
					PrintBuffer("DINHEIRO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.Troco.ToString("###,##0.00").PadLeft(10) + "\n");
				}

				if (pedido.Observacao.Length > 0)
				{
					PrintBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(pedido.Observacao + "\n");
					PrintBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");
				}

			#if COLEGIO_CONTINENTAL
				// Apenas se estiver pago
				if (!pedido.Debito && (pedido.Situacao == 'P' || pedido.Situacao == 'N'))
					PrintBuffer("                 *** PAGO ***                  \n");
				else
				{
					PrintBuffer("               *** A  PAGAR ***                \n");
					PrintBuffer("Autorizacao:\n");
				}
			#endif

				PrintBuffer(linha);

				if (RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda)
				{
					PrintBuffer("USUARIO: " + bd.UsuarioNome(usuario) + "\n");
					PrintBuffer(linha);
				}

				if (RegrasDeNegocio.Instance.ImprimirVendedorNaComanda && pedido.Vendedor != null)
				{
					PrintBuffer("VENDEDOR: " + pedido.Vendedor.Nome + "\n");
					PrintBuffer(linha);
				}

				if (Terminal.Promocao1().Length + Terminal.Promocao2().Length > 0)
				{
					PrintBuffer(Util.Centralize("PROMOCAO", Terminal.ImpressoraColunas) + "\n");
					PrintBuffer(Terminal.Promocao1() + "\n");
					PrintBuffer(Terminal.Promocao2() + "\n");
					PrintBuffer(linha);
				}

				PrintBuffer("www.dsoftsistemas.com.br \n\n\n\n\n\n");

				if (!print_order)
				{
					CleanBuffer();
				}

				//// Verificamos se devemos imprimir a produção.
				//if (Preferencias.ImprimeProducao && !unico_tipo)
				//{
				//    System.Data.DataSet ds = new System.Data.DataSet();

				//    bd.TiposProdutos(ds);

				//    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				//    {
				//        if (bool.Parse(ds.Tables[0].Rows[i].ItemArray[3].ToString()))
				//        {
				//            bool cabeca = false;
				//            int tipo = int.Parse(ds.Tables[0].Rows[i].ItemArray[0].ToString());

				//            for (int j = 0; j < pedido.ItensQtd; j++)
				//            {
				//                if (bd.ProdutoTipo(pedido.ItensPedido[j].Produto) == tipo)
				//                {
				//                    if (!cabeca)
				//                    {
				//                        PrintBuffer("PRODUCAO " + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "\n");
				//                        PrintBuffer("====================\n");
				//                        PrintBuffer("PEDIDO NUMERO: " + pedido.NumeroPedido().ToString() + "\n");
				//                        PrintBuffer("====================\n");

				//                        cabeca = true;
				//                    }

				//                    PrintBuffer(pedido.ItensPedido[j].Produto.ToString("000") + " " +
				//                        Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
				//                        pedido.ItensPedido[j].Quantidade.ToString("0.0") + "\n");

				//                    // Verificamos se temos de imprimir alguma observacao
				//                    if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
				//                    {
				//                        PrintBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39) + "\n");

				//                        if (pedido.ItensPedido[j].Observacao.Length >= 40)
				//                        {
				//                            PrintBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39) + "\n");
				//                        }
				//                    }
				//                }
				//            }

				//            if (cabeca)
				//            {
				//                PrintBuffer("\n\n\n\n\n\n");
				//            }
				//        }
				//    }
				//}

				PrintBuffer("\n\n\n\n\n\n");

				if (print)
				{
					PrintBuffer();

					CutPaper(Terminal.Impressora());
				}
				else
				{
					string copy = (string)_buffer.Clone();
					_buffer = string.Empty;
					return copy;
				}

				// Verificamos se tem algo para ser impresso nas impressoras externas
				if (Terminal.ImpressoraExterna1.Length > 0)// && !unico_tipo)
				{
					bool cabeca = false;
					StringBuilder sbuild = new StringBuilder();

					for (int j = 0; j < pedido.ItensQtd; j++)
					{
						int tipo = bd.ProdutoTipo(pedido.ItensPedido[j].Produto);

						if (bd.ProdutoTipoImpressoraExterna(tipo) == 1)
						{
							if (!cabeca)
							{
								sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));
								sbuild.AppendLine(string.Format("MESA {0}", pedido.Cliente));
								sbuild.AppendLine("PEDIDO NUMERO: " + pedido.NumeroPedido().ToString());
								sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));

								cabeca = true;
							}

							sbuild.AppendLine(pedido.ItensPedido[j].Produto.ToString("000") + " " +
								Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
								pedido.ItensPedido[j].Quantidade.ToString("0.0"));

							// Verificamos se temos de imprimir alguma observacao
							if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
							{
								sbuild.AppendLine("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39));

								if (pedido.ItensPedido[j].Observacao.Length >= 40)
								{
									sbuild.AppendLine("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39));
								}
							}
						}
					}

					if (sbuild.Length > 0)
					{
						sbuild.Append(new string('=', Terminal.ImpressoraColunas));
						sbuild.Append("\n\n\n\n\n\n");

						Print(Terminal.ImpressoraExterna1, sbuild.ToString());
						CutPaper(Terminal.ImpressoraExterna1);
					}
				}

				if (Terminal.ImpressoraExterna2.Length > 0)// && !unico_tipo)
				{
					bool cabeca = false;
					StringBuilder sbuild = new StringBuilder();

					for (int j = 0; j < pedido.ItensQtd; j++)
					{
						int tipo = bd.ProdutoTipo(pedido.ItensPedido[j].Produto);

						if (bd.ProdutoTipoImpressoraExterna(tipo) == 2)
						{
							if (!cabeca)
							{
								sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));
								sbuild.AppendLine(string.Format("MESA {0}", pedido.Cliente));
								sbuild.AppendLine("PEDIDO NUMERO: " + pedido.NumeroPedido().ToString());
								sbuild.AppendLine(new string('=', Terminal.ImpressoraColunas));

								cabeca = true;
							}

							sbuild.AppendLine(pedido.ItensPedido[j].Produto.ToString("000") + " " +
								Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
								pedido.ItensPedido[j].Quantidade.ToString("0.0"));

							// Verificamos se temos de imprimir alguma observacao
							if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
							{
								sbuild.AppendLine("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39));

								if (pedido.ItensPedido[j].Observacao.Length >= 40)
								{
									sbuild.AppendLine("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39));
								}
							}
						}
					}

					if (sbuild.Length > 0)
					{
						sbuild.Append(new string('=', Terminal.ImpressoraColunas));
						sbuild.Append("\n\n\n\n\n\n");

						Print(Terminal.ImpressoraExterna2, sbuild.ToString());
						CutPaper(Terminal.ImpressoraExterna2);
					}
				}

				return "";
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message + e.Source + e.StackTrace,
					"DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return "";
			}
		}

		public static bool PrintTicket(string buff, ILicenca licenca)
		{
			try
			{
				PrintHeader(licenca);

				PrintBuffer(buff);

				PrintBuffer("----------------------------------------\n");
				PrintBuffer("DSoft Sistemas   www.dsoftsistemas.com  \n\n\n\n\n\n\n\n\n\n");

				PrintBuffer();

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message, "DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		private static void CutPaper(string impressora)
		{
			string comando = "";
			comando += Convert.ToString((char)29);
			comando += Convert.ToString((char)86);
			comando += Convert.ToString((char)66);

			Print(impressora, comando);
			Print(impressora, ((char)01).ToString());
		}

		#endregion Methods
	}
}