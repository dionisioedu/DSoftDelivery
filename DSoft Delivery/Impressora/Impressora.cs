//#define PIZZARELLA
//#define BELLO_PIZZARIA
//#define COLEGIO_CONTINENTAL
//#define PIZZARIA_MC
//#define PIZZARIA

#if PIZZARELLA
	#define _50colunas
#endif
#if COLEGIO_CONTINENTAL
	#define _48colunas
#endif
#if BELLO_PIZZARIA || PIZZARIA_MC
	#define _40colunas
#endif

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;
using DSoftModels;
using DSoftParameters;
using DSoftCore;
using DSoftBd;

namespace DSoft_Delivery
{
	public class RawPrinterHelper
	{
		// Structure and API declarions:
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public class DOCINFOA
		{
			[MarshalAs(UnmanagedType.LPStr)]
			public string pDocName;
			[MarshalAs(UnmanagedType.LPStr)]
			public string pOutputFile;
			[MarshalAs(UnmanagedType.LPStr)]
			public string pDataType;
		}

		[DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

		[DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool ClosePrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

		[DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool EndDocPrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool StartPagePrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool EndPagePrinter(IntPtr hPrinter);

		[DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
		public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

		// SendBytesToPrinter()
		// When the function is given a printer name and an unmanaged array
		// of bytes, the function sends those bytes to the print queue.
		// Returns true on success, false on failure.
		public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
		{
			Int32 dwError = 0, dwWritten = 0;
			IntPtr hPrinter = new IntPtr(0);
			DOCINFOA di = new DOCINFOA();
			bool bSuccess = false; // Assume failure unless you specifically succeed.

			di.pDocName = "DSoft Delivery Document";
			di.pDataType = "RAW";

			// Open the printer.
			if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
			{
				// Start a document.
				if (StartDocPrinter(hPrinter, 1, di))
				{
					// Start a page.
					if (StartPagePrinter(hPrinter))
					{
						// Write your bytes.
						bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
						EndPagePrinter(hPrinter);
					}
					EndDocPrinter(hPrinter);
				}
				ClosePrinter(hPrinter);
			}
			// If you did not succeed, GetLastError may give more information
			// about why not.
			if (bSuccess == false)
			{
				dwError = Marshal.GetLastWin32Error();
			}
			return bSuccess;
		}

		public static bool SendFileToPrinter(string szPrinterName, string szFileName)
		{
			// Open the file.
			FileStream fs = new FileStream(szFileName, FileMode.Open);
			// Create a BinaryReader on the file.
			BinaryReader br = new BinaryReader(fs);
			// Dim an array of bytes big enough to hold the file's contents.
			Byte[] bytes = new Byte[fs.Length];
			bool bSuccess = false;
			// Your unmanaged pointer.
			IntPtr pUnmanagedBytes = new IntPtr(0);
			int nLength;

			nLength = Convert.ToInt32(fs.Length);
			// Read the contents of the file into the array.
			bytes = br.ReadBytes(nLength);
			// Allocate some unmanaged memory for those bytes.
			pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
			// Copy the managed byte array into the unmanaged array.
			Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
			// Send the unmanaged bytes to the printer.
			bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
			// Free the unmanaged memory that you allocated earlier.
			Marshal.FreeCoTaskMem(pUnmanagedBytes);
			return bSuccess;
		}

		public static bool SendStringToPrinter(string szPrinterName, string szString)
		{
			IntPtr pBytes;
			Int32 dwCount;
			// How many characters are in the string?
			dwCount = szString.Length;
			// Assume that the printer is expecting ANSI text, and then convert
			// the string to ANSI text.
			pBytes = Marshal.StringToCoTaskMemAnsi(szString);
			// Send the converted ANSI string to the printer.
			bool success = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
			Marshal.FreeCoTaskMem(pBytes);
			return success;
		}
	}

	public class Impressora
	{
		private static StringBuilder Buffer = new StringBuilder();

		public static int Colunas { get; set; }

		public static void ImprimirBuffer(string buff)
		{
			Buffer.Append(buff);
		}

		public static void ImprimirBuffer()
		{
			Imprimir(Buffer.ToString());

			Buffer.Clear();
		}

		public static void ImprimirBufferImpressora(string impressora)
		{
			Imprimir(impressora, Buffer.ToString());

			Buffer.Clear();
		}

		public static bool Imprimir(string impressora, string buff)
		{
			return RawPrinterHelper.SendStringToPrinter(impressora, buff);
		}

		public static bool Imprimir(string buff)
		{
			return RawPrinterHelper.SendStringToPrinter(Terminal.Impressora(), buff);
		}

		public static bool ImprimirCabecalho()
		{
			try
			{
#if PIZZARELLA	// Ticket da Pizzarella
				Imprimir("               PIZZARELLA PIZZARIA                \n");
				Imprimir("       AV. MONTEIRO LOBATO, 5442 - CUMBICA        \n");
				Imprimir("                  GUARULHOS - SP                  \n");
				Imprimir("                                                  \n");
				Imprimir("     2488-9211      2488-0549      2482-4681      \n");
				Imprimir("    FORNO A LENHA             DELIVERY E SALAO    \n");
				Imprimir("--------------------------------------------------\n");
#elif BELLO_PIZZARIA
				// Ticket Bello
				ImprimirBuffer("             BELLO PIZZARIA             \n");
				ImprimirBuffer("R WANDERLEY LEITE DE LIMA 32  JD MOREIRA\n");
				ImprimirBuffer("             GUARULHOS - SP             \n");
				ImprimirBuffer("                                        \n");
				ImprimirBuffer("   2457-8747   2456-5273   2457-0988    \n");
				ImprimirBuffer("        SABOR E PRAZER AO FORNO         \n");
				ImprimirBuffer("----------------------------------------\n");
#elif COLEGIO_CONTINENTAL
				ImprimirBuffer("------------------------------------------------\n");
#elif PIZZARIA_MC
				ImprimirBuffer("              PIZZARIA  MC              \n");
				ImprimirBuffer("AVENIDA TORRES TIBAGY, 885       GOPOUVA\n");
				ImprimirBuffer("             GUARULHOS - SP             \n");
				ImprimirBuffer("                                        \n");
				ImprimirBuffer("   3436-1295               2453-5306    \n");
				ImprimirBuffer("      QUALIDADE EM PRIMEIRO LUGAR       \n");
				ImprimirBuffer("----------------------------------------\n");
#else
				string endereco = Licenca.Instance.Endereco;

				if (Licenca.Instance.Nome.Length > 0)
				{
					ImprimirBuffer(Util.Centralize(Licenca.Instance.Nome, Terminal.ImpressoraColunas) + "\n");
				}

				if (Licenca.Instance.Endereco.Length > 0)
				{
					ImprimirBuffer(Util.Centralize(endereco.Split("&".ToCharArray())[0], Terminal.ImpressoraColunas) + "\n");

					if (endereco.Split("&".ToCharArray()).Length > 1)
					{
						ImprimirBuffer(Util.Centralize(endereco.Split("&".ToCharArray())[1], Terminal.ImpressoraColunas) + "\n");
					}
				}

				if (Licenca.Instance.Telefone.Length > 0)
				{
					ImprimirBuffer(Util.Centralize(Licenca.Instance.Telefone, Terminal.ImpressoraColunas) + "\n");
					ImprimirBuffer(Util.Centralize(Preferencias.MensagemCupom, Terminal.ImpressoraColunas) + "\n");
					ImprimirBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");
				}

				if (Licenca.Instance.Demo)
				{
					ImprimirBuffer(Util.Centralize("*** VERSAO DE DEMOSTRACAO ***", Terminal.ImpressoraColunas) + "\n");
					ImprimirBuffer(new string('-', Terminal.ImpressoraColunas) + "\n");
				}
#endif

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message, "DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public static void ImprimirLinha(bool buffer = false)
		{
			ImprimirLinha('-', buffer);
		}

		public static void ImprimirLinhaDupla(bool buffer = false)
		{
			ImprimirLinha('=', buffer);
		}

		public static void ImprimirLinha(char c, bool buffer = false)
		{
			string s = new string(c, Terminal.ImpressoraColunas);

			if (buffer)
			{
				Buffer.Append(s);
			}
			else
			{
				Imprimir(s + Environment.NewLine);
			}
		}

		public static bool ImprimirPedido(Pedido pedido, Caixa caixa, int usuario, Bd bd, bool imprimir_producao = true, string impressora = "")
		{
			bool unico_tipo = true;
			int tipos_produtos = 0;
			decimal dinheiro;
			string linha;
			int nome_len;
			decimal total_producao = 0;
			Dictionary<string, decimal> tipos_producao = new Dictionary<string, decimal>();

			linha = new string('-', Terminal.ImpressoraColunas) + "\n";
			nome_len = Terminal.ImpressoraColunas - 24;

			try
			{
				ImprimirCabecalho();
#if COLEGIO_CONTINENTAL
				ImprimirBuffer(DateTime.Now.ToString("dd/MM/yy") + "  " + DateTime.Now.ToString("HH:mm:ss") + "   COLEGIO CONTINENTAL\n");
#else
				ImprimirBuffer(string.Format("{0}  {1}   {2}\n", DateTime.Now.ToString("dd/MM/yy"), DateTime.Now.ToString("HH:mm:ss"), caixa.ToString()));
#endif
				if (pedido.ClientePedido() != 0)
				{
					Cliente cliente = bd.CarregarCliente(pedido.Cliente);

					ImprimirBuffer(linha);
#if COLEGIO_CONTINENTAL
					string nome_cliente, nome_grupo;
					nome_cliente = Bd.ClienteNome(pedido.ClientePedido());
					nome_grupo = Bd.ClienteGrupoDescricao(Bd.ClienteGrupo(pedido.ClientePedido()));

					nome_cliente = Util.Formata(nome_cliente, 32);
					nome_grupo = Util.Formata(nome_grupo, 12);

					ImprimirBuffer(nome_cliente + " - " + nome_grupo + "\n");
#else
					//ImprimirBuffer("DADOS DO CLIENTE                        \n");
					ImprimirBuffer(Util.Max(pedido.ClientePedido().ToString() + " - " + bd.ClienteNome(pedido.ClientePedido()), Terminal.ImpressoraColunas) + "\n");

					if (pedido.Retirar == false)
					{
						if (cliente.Endereco.Length > Terminal.ImpressoraColunas)
						{
							ImprimirBuffer(Util.Max(cliente.Endereco, Terminal.ImpressoraColunas) + "\n");
							ImprimirBuffer(cliente.Endereco.Remove(0, Terminal.ImpressoraColunas) + "\n");
						}
						else
						{
							ImprimirBuffer(cliente.Endereco + "\n");
						}

						if (cliente.Cidade.Length > 0)
						{
							ImprimirBuffer(Util.Max(string.Format("{0} - {1}", cliente.Bairro, cliente.Cidade), Terminal.ImpressoraColunas) + "\n");
						}
						else
						{
							ImprimirBuffer(Util.Max(cliente.Bairro, Terminal.ImpressoraColunas) + "\n");
						}

						ImprimirBuffer(Util.Max(string.Format("{0}  {1}  {2}", (cliente.Telefone1 == 0 ? " " : cliente.Telefone1.ToString()),
							(cliente.Telefone2 == 0 ? " " : cliente.Telefone2.ToString()), (cliente.Celular == 0 ? " " : cliente.Celular.ToString())), Terminal.ImpressoraColunas) + "\n");
#endif
						if (cliente.Referencia.Length > 0)
						{
							ImprimirBuffer(Util.Max(cliente.Referencia, Terminal.ImpressoraColunas) + "\n");
						}
					}
					else
					{
						ImprimirBuffer(linha);
						ImprimirBuffer(Util.Centralize("*** RETIRAR ***", Impressora.Colunas) + "\n");
					}
				}
				else
				{
					ImprimirBuffer(linha);
					ImprimirBuffer(Util.Centralize("*** BALCAO ***", Impressora.Colunas) + "\n");
				}

				ImprimirBuffer(linha);

				if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
				{
					//ImprimirBuffer(string.Format("COMANDA: {0}                       PEDIDO: {1} \n", pedido.Comanda, pedido.NumeroPedido()));
					ImprimirBuffer(string.Format("COMANDA: {0}\n", pedido.Comanda));
				}
				else
				{
					ImprimirBuffer(string.Format("PEDIDO: {0}\n", pedido.NumeroPedido()));
				}

				ImprimirBuffer(linha);

				ImprimirBuffer(Util.Centralize("CUPOM NAO FISCAL", Terminal.ImpressoraColunas) + "\n");

				if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
				{
					ImprimirBuffer(string.Format("QTD PRODUTO{0}VALOR R$\n", new string(' ', Terminal.ImpressoraColunas - 20)));
				}
				else
				{
					ImprimirBuffer("ITEM CODIGO DESCRICAO" + new string(' ', Terminal.ImpressoraColunas - 37) + "QTD    VALOR R$\n");
				}

				ImprimirBuffer(linha);

				bool primeiro_item = true;

				for (int i = 0; i < pedido.ItensQtd; i++)
				{
					string prod = string.Empty;

					if (pedido.ItensPedido[i] == null)
						break;

					if (pedido.ItensPedido[i].Situacao != 'A')
						continue;

					ItemPedido itemPedido = pedido.ItensPedido[i];
					ProdutoTipo produtoTipo = bd.CarregarProdutoTipo(bd.ProdutoTipo(itemPedido.Produto));

					if (produtoTipo.ImprimeQuantidadeTotal)
					{
						if (tipos_producao.ContainsKey(produtoTipo.Nome))
						{
							tipos_producao[produtoTipo.Nome] += (decimal)itemPedido.Quantidade;
						}
						else
						{
							tipos_producao.Add(produtoTipo.Nome, (decimal)itemPedido.Quantidade);
						}

						total_producao += (decimal)itemPedido.Quantidade;
					}

					prod = bd.ProdutoNome(pedido.ItensPedido[i].Produto);

					if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
					{
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
								if (RegrasDeNegocio.Instance.ImprimirLinhaEntreItens)
								{
									ImprimirBuffer(linha);
								}
							}
						}
						else
						{
							primeiro_item = false;
						}

						ImprimirBuffer(item_linha.ToString());

						// Imprimimos os itens adicionais
						foreach (ItemAdicional adicional in itemPedido.ItensAdicionais)
						{
							ImprimirBuffer(string.Format("    ##{0}\n", adicional.ToString().Trim()));
						}

						// Verificamos se temos de imprimir alguma observacao
						if (!string.IsNullOrEmpty(itemPedido.Observacao))
						{
							ImprimirBuffer("    #" + Util.Formata(itemPedido.Observacao, Terminal.ImpressoraColunas - 5) + "\n");

							if (itemPedido.Observacao.Length > Terminal.ImpressoraColunas - 5)
							{
								ImprimirBuffer("    #" + Util.Formata(itemPedido.Observacao.Remove(0, Terminal.ImpressoraColunas - 5), Terminal.ImpressoraColunas - 5) + "\n");
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
					}
					else
					{
						if (prod.Length < nome_len)
							prod = prod.PadRight(nome_len);
						else if (prod.Length > nome_len)
							prod = prod.Remove(nome_len, (prod.Length - nome_len));

						if (!pedido.ItensPedido[i].Secundario)
						{
							ImprimirBuffer(pedido.ItensPedido[i].NumeroItem().ToString("000") + "  " +
								pedido.ItensPedido[i].Produto.ToString("000") + " " +
								prod + " " +
								pedido.ItensPedido[i].Quantidade.ToString("0.0") + " " +
								pedido.ItensPedido[i].Preco.ToString("###,##0.00").PadLeft(10) + "\n");

							// Imprimimos os itens adicionais
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
							}

							// Verificamos se temos de imprimir alguma observacao
							if (!string.IsNullOrEmpty(pedido.ItensPedido[i].Observacao))
							{
								ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

								if (pedido.ItensPedido[i].Observacao.Length >= 40)
								{
									ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
								}
							}

							// Vamos verificar se o pedido tem apenas um tipo de produto, para evitar de imprimir o ticket da produção
							if (unico_tipo)
							{
								if (tipos_produtos == 0)
								{
									tipos_produtos = bd.ProdutoTipo(pedido.ItensPedido[i].Produto);
								}
								else if (tipos_produtos != bd.ProdutoTipo(pedido.ItensPedido[i].Produto))
								{
									unico_tipo = false;
								}
							}
						}
						else
						{
							ImprimirBuffer("  >> " + pedido.ItensPedido[i].Produto.ToString("000") + " " +
								prod + " " + pedido.ItensPedido[i].Quantidade.ToString("0.0") + "\n");

							// Imprimimos os itens adicionais
							foreach (ItemAdicional adicional in pedido.ItensPedido[i].ItensAdicionais)
							{
								ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
							}

							// Verificamos se temos de imprimir alguma observacao
							if (pedido.ItensPedido[i].Observacao != null && pedido.ItensPedido[i].Observacao.Length > 0)
							{
								ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao, 39) + "\n");

								if (pedido.ItensPedido[i].Observacao.Length >= 40)
								{
									ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[i].Observacao.Remove(0, 39), 39) + "\n");
								}
							}
						}
					}
				}

				ImprimirBuffer(linha);

				if (pedido.TaxaDeServico > 0)
				{
					ImprimirBuffer("TAXA DE SERVICO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.TaxaDeServico.ToString("0.00").PadLeft(10) + "\n");
					ImprimirBuffer(linha);
				}

				if (pedido.TaxaDeEntrega > 0)
				{
					ImprimirBuffer("TAXA DE ENTREGA R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.TaxaDeEntrega.ToString("0.00").PadLeft(10) + "\n");
					ImprimirBuffer(linha);
				}

				if (pedido.DescontoPedido != 0)
				{
					ImprimirBuffer("DESCONTO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.DescontoPedido.ToString("###,##0.00").PadLeft(10) + "\n");
				}

				ImprimirBuffer("TOTAL R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.TotalPedido.ToString("###,##0.00").PadLeft(10) + "\n");

				if (pedido.Troco > 0)
				{
					dinheiro = pedido.Troco - pedido.TotalPedido;

					ImprimirBuffer("TROCO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + dinheiro.ToString("###,##0.00").PadLeft(10) + "\n");
					ImprimirBuffer("DINHEIRO R$ ".PadLeft(Terminal.ImpressoraColunas - 10) + pedido.Troco.ToString("###,##0.00").PadLeft(10) + "\n");
				}

				if (pedido.Retirar)
				{
					ImprimirBuffer(linha);
					ImprimirBuffer(Util.Centralize("*** RETIRAR ***", Impressora.Colunas) + "\n");
				}

				// Se o pedido já estiver pago, imprimimos também a forma de pagamento
				if (pedido.Situacao == 'N' || pedido.Situacao == 'O' || pedido.Situacao == 'P')
				{
					List<FormaDePagamento> formasDePagamento = bd.PagamentosDoPedido(pedido);

					if (formasDePagamento != null && formasDePagamento.Count > 0)
					{
						ImprimirBuffer(linha);

						foreach (FormaDePagamento formaDePagamento in formasDePagamento)
						{
							ImprimirBuffer(string.Format("** {0}\n", formaDePagamento.Descricao));
						}
					}
				}

				if (pedido.Observacao.Length > 0)
				{
					ImprimirBuffer(linha);
					ImprimirBuffer(pedido.Observacao + "\n");
				}

#if COLEGIO_CONTINENTAL
				// Apenas se estiver pago
				if (!pedido.Debito && (pedido.Situacao == 'P' || pedido.Situacao == 'N'))
					ImprimirBuffer("                 *** PAGO ***                  \n");
				else
				{
					ImprimirBuffer("               *** A  PAGAR ***                \n");
					ImprimirBuffer("Autorizacao:\n");
				}
#endif

				ImprimirBuffer(linha);

				if (total_producao > 0)
				{
					foreach (var tp in tipos_producao)
					{
						ImprimirBuffer(string.Format("TOTAL DE {0}: {1}\n", tp.Key, tp.Value));
					}

					//ImprimirBuffer(string.Format("TOTAL PRODUCAO: {0}\n", total_producao));
					ImprimirBuffer(linha);
				}

				if (RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda)
				{
					ImprimirBuffer("USUARIO: " + bd.UsuarioNome(usuario) + "\n");
					ImprimirBuffer(linha);
				}

				if (RegrasDeNegocio.Instance.ImprimirVendedorNaComanda && pedido.Vendedor != null)
				{
					ImprimirBuffer("VENDEDOR: " + pedido.Vendedor.Nome + "\n");
					ImprimirBuffer(linha);
				}

				if (Terminal.Promocao1().Length + Terminal.Promocao2().Length > 0)
				{
					ImprimirBuffer(Util.Centralize("PROMOCAO", Terminal.ImpressoraColunas) + "\n");
					ImprimirBuffer(Terminal.Promocao1() + "\n");
					ImprimirBuffer(Terminal.Promocao2() + "\n");
					ImprimirBuffer(linha);
				}

				ImprimirBuffer("www.dsoftsistemas.com.br \n");

				if (Terminal.ImpressoraCorte)
				{
					CortarPapel(impressora);
				}
				else
				{
					ImprimirBuffer("\n\n\n\n\n\n");
				}

				if (!imprimir_producao)
				{
					if (!Terminal.ImpressoraCorte)
					{
						ImprimirBuffer("\n\n\n\n\n\n");
					}

					if (impressora == "")
					{
						ImprimirBuffer();

						if (Terminal.ImpressoraCorte)
						{
							CortarPapel(Terminal.Impressora());
						}
					}
					else
					{
						ImprimirBufferImpressora(impressora);
					}

					return true;
				}

				// Verificamos se devemos imprimir a produção.
				if (Preferencias.ImprimeProducao && !unico_tipo)
				{
					System.Data.DataSet ds = new System.Data.DataSet();

					bd.TiposProdutos(ds);

					for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
					{
						if (bool.Parse(ds.Tables[0].Rows[i].ItemArray[3].ToString()))
						{
							bool cabeca = false;
							int tipo = int.Parse(ds.Tables[0].Rows[i].ItemArray[0].ToString());

							for (int j = 0; j < pedido.ItensQtd; j++)
							{
								if (bd.ProdutoTipo(pedido.ItensPedido[j].Produto) == tipo)
								{
									if (!cabeca)
									{
										ImprimirBuffer("PRODUCAO " + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "\n");
										ImprimirBuffer("====================\n");

										if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
										{
											ImprimirBuffer(string.Format("COMANDA: {0}\n", pedido.Comanda));
										}
										else
										{
											ImprimirBuffer("PEDIDO: " + pedido.NumeroPedido() + "\n");
										}

										ImprimirBuffer("====================\n");

										cabeca = true;
									}

									if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
									{
										ImprimirBuffer(string.Format("{0} {1}\n", Util.NotacaoQuantidade(pedido.ItensPedido[j].Quantidade).PadLeft(3, ' '),
											pedido.ItensPedido[j].ProdutoNome));
									}
									else
									{
										ImprimirBuffer(pedido.ItensPedido[j].Produto.ToString("000") + " " +
											Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
											pedido.ItensPedido[j].Quantidade.ToString("0.0") + "\n");
									}

									// Imprimimos os itens adicionais
									foreach (ItemAdicional adicional in pedido.ItensPedido[j].ItensAdicionais)
									{
										ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
									}

									// Verificamos se temos de imprimir alguma observacao
									if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
									{
										ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39) + "\n");

										if (pedido.ItensPedido[j].Observacao.Length >= 40)
										{
											ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39) + "\n");
										}
									}
								}
							}

							if (cabeca)
							{
								ImprimirBuffer("\n\n\n\n\n\n");
							}
						}
					}
				}

				ImprimirBuffer("\n\n\n");

				if (impressora == "")
				{
					ImprimirBuffer();

					if (Terminal.ImpressoraCorte)
					{
						CortarPapel(Terminal.Impressora());
					}
				}
				else
				{
					ImprimirBufferImpressora(impressora);
				}

				// Verificamos se tem algo para ser impresso nas impressoras externas
				if (Terminal.ImpressoraExterna1.Length > 0)// && !unico_tipo)
				{
					bool cabeca = false;

					for (int j = 0; j < pedido.ItensQtd; j++)
					{
						int tipo = bd.ProdutoTipo(pedido.ItensPedido[j].Produto);

						if (bd.ProdutoTipoImpressoraExterna(tipo) == 1)
						{
							if (!cabeca)
							{
								ImprimirBuffer(linha);

								if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
								{
									ImprimirBuffer(string.Format("COMANDA: {0}\n", pedido.Comanda));
								}
								else
								{
									ImprimirBuffer("PEDIDO: " + pedido.NumeroPedido() + "\n");
								}

								ImprimirBuffer(linha);

								cabeca = true;
							}

							if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
							{
								ImprimirBuffer(string.Format("{0} {1}\n", Util.NotacaoQuantidade(pedido.ItensPedido[j].Quantidade).PadLeft(3, ' '),
									pedido.ItensPedido[j].ProdutoNome));
							}
							else
							{
								ImprimirBuffer(pedido.ItensPedido[j].Produto.ToString("000") + " " +
									Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
									pedido.ItensPedido[j].Quantidade.ToString("0.0") + "\n");
							}

							// Imprimimos os itens adicionais
							foreach (ItemAdicional adicional in pedido.ItensPedido[j].ItensAdicionais)
							{
								ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
							}

							// Verificamos se temos de imprimir alguma observacao
							if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
							{
								ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39) + "\n");

								if (pedido.ItensPedido[j].Observacao.Length >= 40)
								{
									ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39) + "\n");
								}
							}
						}
					}

					if (cabeca)
					{
						ImprimirBuffer(linha);
						ImprimirBuffer("\n\n\n\n\n\n\n");
						ImprimirBufferImpressora(Terminal.ImpressoraExterna1);
						CortarPapel(Terminal.ImpressoraExterna1);
					}
				}

				if (Terminal.ImpressoraExterna2.Length > 0)// && !unico_tipo)
				{
					bool cabeca = false;

					for (int j = 0; j < pedido.ItensQtd; j++)
					{
						int tipo = bd.ProdutoTipo(pedido.ItensPedido[j].Produto);

						if (bd.ProdutoTipoImpressoraExterna(tipo) == 2)
						{
							if (!cabeca)
							{
								ImprimirBuffer(linha);

								if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
								{
									ImprimirBuffer(string.Format("COMANDA: {0}\n", pedido.Comanda));
								}
								else
								{
									ImprimirBuffer("PEDIDO: " + pedido.NumeroPedido() + "\n");
								}

								ImprimirBuffer(linha);

								cabeca = true;
							}

							if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
							{
								ImprimirBuffer(string.Format("{0} {1}\n", Util.NotacaoQuantidade(pedido.ItensPedido[j].Quantidade).PadLeft(3, ' '),
									pedido.ItensPedido[j].ProdutoNome));
							}
							else
							{
								ImprimirBuffer(pedido.ItensPedido[j].Produto.ToString("000") + " " +
									Util.Formata(bd.ProdutoNome(pedido.ItensPedido[j].Produto), 16) + " " +
									pedido.ItensPedido[j].Quantidade.ToString("0.0") + "\n");
							}

							// Imprimimos os itens adicionais
							foreach (ItemAdicional adicional in pedido.ItensPedido[j].ItensAdicionais)
							{
								ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
							}

							// Verificamos se temos de imprimir alguma observacao
							if (pedido.ItensPedido[j].Observacao != null && pedido.ItensPedido[j].Observacao.Length > 0)
							{
								ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao, 39) + "\n");

								if (pedido.ItensPedido[j].Observacao.Length >= 40)
								{
									ImprimirBuffer("#" + Util.Formata(pedido.ItensPedido[j].Observacao.Remove(0, 39), 39) + "\n");
								}
							}
						}
					}

					if (cabeca)
					{
						ImprimirBuffer(linha);
						ImprimirBuffer("\n\n\n\n\n\n\n\n");
						ImprimirBufferImpressora(Terminal.ImpressoraExterna2);

						CortarPapel(Terminal.ImpressoraExterna2);
					}
				}

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message + e.Source + e.StackTrace,
					"DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public static void ImprimirProducao(Bd bd, Pedido pedido, List<ItemPedido> itens, Usuario usuario)
		{
			string linha = new string('-', Terminal.ImpressoraColunas) + "\n";

			ImprimirBuffer(linha);

			if (pedido.Cliente > 0)
			{
				ImprimirBuffer(bd.ClienteNome(pedido.Cliente) + "\n");
			}
			else
			{
				ImprimirBuffer(pedido.Observacao + "\n");
			}

			if (RegrasDeNegocio.Instance.ControlaPedidosPorComanda)
			{
				ImprimirBuffer(string.Format("COMANDA: {0} - {1}   {2}\n", pedido.Comanda, pedido.Data.ToShortDateString(), pedido.Hora.ToShortTimeString()));
			}
			else
			{
				ImprimirBuffer(string.Format("PEDIDO: {0} - {1}   {2}\n", pedido.Indice, pedido.Data.ToShortDateString(), pedido.Hora.ToShortTimeString()));
			}

			ImprimirBuffer(linha);

			foreach (ItemPedido item in itens)
			{
				if (RegrasDeNegocio.Instance.ModeloImpressao == Constants.MODELO_IMPRESSAO_QCNV)
				{
					ImprimirBuffer(string.Format("{0} {1}\n", Util.NotacaoQuantidade(item.Quantidade).PadLeft(3, ' '),
						item.ProdutoNome));
				}
				else
				{
					ImprimirBuffer(item.Produto.ToString("000") + " " +
						Util.Formata(bd.ProdutoNome(item.Produto), 16) + " " +
						item.Quantidade.ToString("0.0") + "\n");
				}

				// Imprimimos os itens adicionais
				foreach (ItemAdicional adicional in item.ItensAdicionais)
				{
					ImprimirBuffer(string.Format("##{0}\n", adicional.ToString().Trim()));
				}

				// Verificamos se temos de imprimir alguma observacao
				if (!string.IsNullOrEmpty(item.Observacao))
				{
					ImprimirBuffer("#" + Util.Formata(item.Observacao, 39) + "\n");

					if (item.Observacao.Length >= 40)
					{
						ImprimirBuffer("#" + Util.Formata(item.Observacao.Remove(0, 39), 39) + "\n");
					}
				}
			}

			ImprimirBuffer(linha);

			if (RegrasDeNegocio.Instance.ImprimirUsuarioNaComanda)
			{
				ImprimirBuffer(string.Format("USUARIO: {0}\n", usuario.Nome));
			}
			else if (RegrasDeNegocio.Instance.ImprimirVendedorNaComanda)
			{
				if (pedido.Vendedor != null)
				{
					ImprimirBuffer(string.Format("VENDEDOR: {0}\n", pedido.Vendedor.Nome));
				}
			}

			ImprimirBuffer("\n\n\n\n\n\n");
			ImprimirBuffer();

			CortarPapel(Terminal.Impressora());
		}

		public static bool ImprimirTicket(string buff)
		{
			try
			{
				ImprimirCabecalho();

				ImprimirBuffer(buff);

				ImprimirBuffer(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));
				ImprimirBuffer("DSoft Sistemas   www.dsoftsistemas.com.br  \n\n\n\n\n\n\n\n\n\n");

				ImprimirBuffer();

				CortarPapel(Terminal.Impressora());

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show("Erro ao imprimir ticket." + Environment.NewLine + e.Message, "DSoft Delivery", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public static void ImprimirFechamento(Fechamento fechamento, int pedidos_volume, int pedidos_itens, decimal pedidos_total, DataTable caixas, DataTable entradas)
		{
			int colunas = Terminal.ImpressoraColunas;
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

			ImprimirBuffer(buffer);
			ImprimirBuffer();

			CortarPapel(Terminal.Impressora());
		}

		public static void ImprimirFechamentoCaixa()
		{

		}

		public static void ImprimirFechamentoDetalhado(DateTime data, List<ItemFechamentoDetalhe> itens)
		{
			ImprimirBuffer("FECHAMENTO DIARIO DETALHADO\n");
			ImprimirBuffer(string.Format("{0}\n", data.ToShortDateString()));
			ImprimirBuffer(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));

			foreach (ItemFechamentoDetalhe item in itens)
			{
				ImprimirBuffer(string.Format("{0} {1} {2} {3} {4} R$ {5}\n", item.Comanda.ToString().PadLeft(3), item.DataHora.Date.ToString("dd/MM"), item.DataHora.ToString("HH:mm"),
					item.FormaDePagamento, new string(' ', (Terminal.ImpressoraColunas - 34)), item.Valor.ToString("##,###,##0.00").PadLeft(12)));
			}

			ImprimirBuffer(string.Format("{0}\n", new string('-', Terminal.ImpressoraColunas)));

			ImprimirBuffer();

			CortarPapel(Terminal.Impressora());
		}

		public static void CortarPapel(string impressora)
		{
			string comando = "\x1b\x77";

			Imprimir(impressora, comando);
			Imprimir(impressora, "\n");
		}
	}

//    private void PopulateInstalledPrintersCombo()
//{
//    // Add list of installed printers found to the combo box.
//    // The pkInstalledPrinters string will be used to provide the display string.
//    String pkInstalledPrinters;
//    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++){
//        pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
//        comboInstalledPrinters.Items.Add(pkInstalledPrinters);
//    }
//}

//private void comboInstalledPrinters_SelectionChanged(object sender, System.EventArgs e)
//{

//    // Set the printer to a printer in the combo box when the selection changes.

//    if (comboInstalledPrinters.SelectedIndex != -1) 
//    {
//        // The combo box's Text property returns the selected item's text, which is the printer name.
//        printDoc.PrinterSettings.PrinterName= comboInstalledPrinters.Text;
//    }

//}
}
