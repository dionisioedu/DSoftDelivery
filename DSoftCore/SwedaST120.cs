using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace DSoftCore
{
	public class SwedaST120
	{
		public static string ID = "SWEDA ST120";

		// Classe com a declaração das funções da convecf.dll 
		#region DECLARAÇÃO DAS FUNÇÕES DA CONVECF.DLL

		#region Funções de Inicialização

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AlteraSimboloMoeda(
			string SimbMoeda);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaAliquota(
			string Aliq, int ICMS_ISS);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_NomeiaTotalizadorNaoSujeitoIcms(int Indice, string Totaliz);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaHorarioVerao();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaArredondamento();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaTruncamento();

		#endregion

		#region ANALISA RETORNO DA DLL

		public static string Analisa_Retorno_Dll(int retorno)
		{
			// Alguns retornos
			switch (retorno)
			{
				case 0:
					return "Erro de comunicação";

				case 1:
					return "Comando enviado com sucesso!";

				case -2:
					return "Parâmetro inválido.";

				case -6:
					return "O mês selecionado ainda não está terminado.";

				case -8:
					return "Erro ao criar ou gravar no arquivo RETORNO.TXT.";

				case -11:
					return "Existe um documento aberto ";

				case -24:
					return "Forma de pagamento não programada";

				case -27:
					return "Status do ECF diferente de 6,0,0,0 (ACK,ST1,ST2 e ST3)";

				case -30:
					return "Função não compatível com a impressora.";

				default:
					return string.Format("Mensagem desconhecida ({0})", retorno);
			}
		}

		#endregion

		#region Funções do Cupom Fiscal

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AbreCupom(string CGC_CPF);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VendeItem(string Codigo, string Descricao, string Aliquota,
			string TipoQuantidade, string Quantidade, int CasasDecimais,
			string ValorUnitario, string TipoDesconto, string Desconto);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VendeItemDepartamento(
			string Codigo, string Descricao, string Aliquota, string ValorUnitario,
			string Quantidade, string Acrescimo, string Desconto, string IndiceDepartamento,
			string UnidadeMedida);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CancelaItemAnterior();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CancelaItemGenerico(string NumeroItem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CancelaCupom();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_FechaCupomResumido(string FormaPagamento, string Mensagem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_FechaCupom(
			string FormaPagamento, string AcrescimoDesconto, string TipoAcrescimoDesconto,
			string ValorAcrescimoDesconto, string ValorPago, string Mensagem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_IniciaFechamentoCupom(
			string AcrescimoDesconto, string TipoAcrescimoDesconto,
			string ValorAcrescimoDesconto);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EfetuaFormaPagamento(string FormaPagamento, string ValorFormaPagamento);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EfetuaFormaPagamentoDescricaoForma(string FormaPagamento,
			string ValorFormaPagamento, string Descricao);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TerminaFechamentoCupom(
			string Mensagem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_EstornoFormasPagamento(
			string FormaOrigem, string FormaDestino, string Valor);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AumentaDescricaoItem(
			string Descricao);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_UsaUnidadeMedida(
			string UnidadeMedida);

		#endregion

		#region Funções dos Relatórios Fiscais

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_LeituraX();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_LeituraXSerial();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ReducaoZ(
			string Data, string Hora);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RelatorioGerencial(
			string Textos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_FechaRelatorioGerencial();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_LeituraMemoriaFiscalData(
			string ZDataInicial, string ZDataFinal);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalReducao(string ZCRZInicial, string ZCRZFinal);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalSerialData(string ZDataInicial, string ZDataFinal);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalSerialReducao(string ZCRZInicial, string ZCRZFinal);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DownloadMF(string arquivo);

		#endregion

		#region Funções das Operações Não Fiscais

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RecebimentoNaoFiscal(
			string IndiceTot, string Valor, string MeioPagamento);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_AbreComprovanteNaoFiscalVinculado(string MeioPag, string Valor, string NDoc);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_UsaComprovanteNaoFiscalVinculado(string Texto);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_FechaComprovanteNaoFiscalVinculado();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_Sangria(string Valor);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Suprimento(string Valor, string FormaPag);

		#endregion

		#region Funções de Informações da Impressora

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_Acrescimos(
			StringBuilder ValAcrescimo);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_Cancelamentos(
			StringBuilder ValCanc);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CGC_IE(
			StringBuilder CGC, StringBuilder IE);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ClicheProprietario(StringBuilder Cliche);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ContadoresTotalizadoresNaoFiscais(StringBuilder Contadores);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DadosUltimaReducao(
			StringBuilder DadosReducao);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DataHoraImpressora(
			StringBuilder Data, StringBuilder Hora);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DataHoraReducao(
			StringBuilder Data, StringBuilder Hora);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DataMovimento(
			StringBuilder Data);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_Descontos(
			StringBuilder ValorDesc);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_FlagsFiscais(ref int Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_GrandeTotal(
			StringBuilder GrandeTotal);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_MinutosLigada(
			StringBuilder Minutos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_MinutosImprimindo(
			StringBuilder Minutos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_MonitoramentoPapel(
			ref int Linhas);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroCaixa(
			StringBuilder NumeroCaixa);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroCupom(
			StringBuilder NumeroCupom);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroCuponsCancelados(
			StringBuilder NumeroCancelamentos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroIntervencoes(
			StringBuilder NumeroIntervencoes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroLoja(
			StringBuilder NumeroLoja);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroOperacoesNaoFiscais(StringBuilder NumeroOperacoes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroReducoes(
			StringBuilder NumeroReducoes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroSerie(
			StringBuilder NumeroSerie);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_NumeroSubstituicoesProprietario(StringBuilder NumSubst);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RetornoAliquotas(
			StringBuilder Aliq);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_SimboloMoeda(
			StringBuilder SimboloMoeda);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_SubTotal(
			StringBuilder SubTot);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_UltimoItemVendido(
			StringBuilder NumeroItem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ValorFormaPagamento(
			string Forma, StringBuilder ValorForma);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ValorPagoUltimoCupom(
			StringBuilder ValorCupom);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ValorTotalizadorNaoFiscal(string Totalizador, StringBuilder ValorTotalizador);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaAliquotasIss(
			StringBuilder Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaEpromConectada(
			StringBuilder Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaEstadoImpressora(
			ref int ACK, ref int ST1, ref int ST2);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaFormasPagamento(
			StringBuilder Formas);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaIndiceAliquotasIss(StringBuilder Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaModoOperacao(
			StringBuilder Modo);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaRecebimentoNaoFiscal(StringBuilder Recebimentos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaTipoImpressora(
			ref int TipoImpressora);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaTotalizadoresNaoFiscais(StringBuilder Totalizadores);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaTotalizadoresParciais(StringBuilder Totalizadores);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaTruncamento(
			StringBuilder Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VersaoFirmware(
			StringBuilder VersaoFirmware);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ComprovantesNaoFiscaisNaoEmitidosMFD(StringBuilder Comprovantes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CNPJMFD(
			StringBuilder CNPJ);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ContadorComprovantesCreditoMFD(StringBuilder Comprovantes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ContadorCupomFiscalMFD(
			StringBuilder CuponsEmitidos);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ContadorFitaDetalheMFD(
			StringBuilder ContadorFita);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ContadorOperacoesNaoFiscaisCanceladasMFD(StringBuilder OperacoesCanceladas);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ContadorRelatoriosGerenciaisMFD(StringBuilder Relatorios);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ContadoresTotalizadoresNaoFiscaisMFD(StringBuilder Contadores);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CupomAdicionalMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_DadosUltimaReducaoMFD(StringBuilder DadosReducao);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_DataHoraUltimoDocumentoMFD(StringBuilder cDataHora);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_InscricaoEstadualMFD(
			StringBuilder InscricaoEstadual);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_InscricaoMunicipalMFD(
			StringBuilder InscricaoMunicipal);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_LeituraChequeMFD(
			StringBuilder CodigoCMC7);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_MarcaModeloTipoImpressoraMFD(StringBuilder Marca, StringBuilder Modelo,
			StringBuilder Tipo);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_MinutosEmitindoDocumentosFiscaisMFD(StringBuilder Minutos);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_NomeiaRelatorioGerencialMFD(string Indice, string Descricao);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroSerieMFD
			(StringBuilder NumeroSerie);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_NumeroSerieMemoriaMFD(
			StringBuilder NumeroSerieMFD);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_PercentualLivreMFD(
			StringBuilder cMemoriaLivre);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ReducoesRestantesMFD(
			StringBuilder Reducoes);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TotalLivreMFD(
			StringBuilder cMemoriaLivre);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TamanhoTotalMFD(
			StringBuilder cTamanhoMFD);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TempoOperacionalMFD(
			StringBuilder TempoOperacional);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ValorFormaPagamentoMFD(
			string Forma, StringBuilder ValorForma);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ValorTotalizadorNaoFiscalMFD(string Totalizador, StringBuilder ValorTotal);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaEstadoImpressoraMFD(ref int ACK, ref int ST1, ref int ST2,
			ref int ST3);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaFormasPagamentoMFD(StringBuilder FormasPagamento);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaRecebimentoNaoFiscalMFD(StringBuilder Recebimentos);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaRelatorioGerencialMFD(StringBuilder Relatorios);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaTotalizadoresNaoFiscaisMFD(StringBuilder Totalizadores);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaTotalizadoresParciaisMFD(StringBuilder Totalizadores);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VersaoFirmwareMFD(StringBuilder VersaoFirmware);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaDescricaoFormasPagamento(StringBuilder pagam);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Verifica20DescricaoFormasPagamento(StringBuilder pagam);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaFormasPagamentoEx(StringBuilder pagam);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Verifica20FormasPagamentoEx(StringBuilder pagam);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_RetornaTotalPagamentos(StringBuilder pagam);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Retorna20TotalPagamentos(StringBuilder pagam);

		#endregion

		#region Funções de Autenticação e Gaveta de Dinheiro

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AcionaGaveta();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_Autenticacao();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ProgramaCaracterAutenticacao(string Param);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaEstadoGaveta(
			out int EstadoGav);

		#endregion

		#region Funções de Impressão de Cheques

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CancelaImpressaoCheque();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ImprimeCheque(
			string Banco, string Valor, string Nominal,
			string Cidade, string Data, string Mensagem);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ImprimeCopiaCheque();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_IncluiCidadeFavorecido(
			string Cidade, string Nominal);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaMoedaPlural(
			string MoedaPlural);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaMoedaSingular(
			string MoedaSingular);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaStatusCheque(
			ref int StatusCheque);

		#endregion

		#region Outras Funções

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AberturaDoDia(
			string Valor, string MeioPagto);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AbrePortaSerial();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AbreConnectC(int meio, string path);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_FechamentoDoDia();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_FechaPortaSerial();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ImprimeConfiguracoesImpressora();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ImprimeDepartamentos();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_MapaResumo();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RelatorioTipo60Analitico();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RelatorioTipo60Mestre();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_RetornoImpressora(
			ref int ACK, ref int ST1, ref int ST2);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_VerificaImpressoraLigada();

		#endregion

		#region Funções da Impressora Fiscal MFD

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_AbreComprovanteNaoFiscalVinculadoMFD(string MeioPag, string Valor,
			string NumCupom, string CGC, string nome, string Ender);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AbreCupomMFD(
			string CGC, string Nome, string Endereco);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_AbreRecebimentoNaoFiscalMFD(string CGC, string Nome, string Endereco);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AbreRelatorioGerencialMFD(string Indice);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AcrescimoDescontoItemMFD(
			string Item, string AcrescDesc, string TipoAcresDesc,
			string ValAcrescDesc);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_AcrescimoDescontoSubtotalRecebimentoMFD(string Flag, string Tipo, string Val);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_AcrescimoDescontoSubtotalMFD(string Flag, string Tipo, string Valor);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_AutenticacaoMFD(
			string Linhas, string Texto);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CancelaAcrescimoDescontoItemMFD(string cFlag, string cItem);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CancelaAcrescimoDescontoSubtotalMFD(string cFlag);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CancelaAcrescimoDescontoSubtotalRecebimentoMFD(string cFlag);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_CancelaCupomMFD(
			string CGC, string Nome, string Endereco);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CancelaRecebimentoNaoFiscalMFD(string CGC, string Nome, string Endereco);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_EfetuaFormaPagamentoMFD(
			string FormaPagto, string ValFormaPagto, string Parc, string NomeFormaPagto);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EfetuaRecebimentoNaoFiscalMFD(string IndiceTotal, string ValorReceb);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EstornoNaoFiscalVinculadoMFD(string CGC, string Nome, string Endereco);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_FechaRecebimentoNaoFiscalMFD(string Mensagem);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_HabilitaDesabilitaRetornoEstendidoMFD(string FlagRet);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ImprimeChequeMFD(string NumeroBanco, string Valor, string Favorecido,
			string Cidade, string Data, string Mensagem, string ImpressaoVerso,
			string Linhas);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_IniciaFechamentoCupomMFD(
			string AcrescDesc, string TipoAcresDesc, string ValorAcres, string ValorDesc);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_IniciaFechamentoRecebimentoNaoFiscalMFD(
			string AcrescDesc, string TipoAcresDesc, string ValAcres, string ValDesc);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalDataMFD(string DataIni, string DataFim, string Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalReducaoMFD(string RedIni, string RedFim, string Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalSerialDataMFD(string DataIni, string DataFim, string Flag);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_LeituraMemoriaFiscalSerialReducaoMFD(string RedIni, string RedFim, string Flg);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_MapaResumoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ProgramaFormaPagamentoMFD(string FormaPagto, string OperacaoTef);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ApagaTabelaNomesFormasdePagamento();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ReimpressaoNaoFiscalVinculadoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_RelatorioTipo60AnaliticoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_RetornoImpressoraMFD(ref int ACK, ref int ST1, ref int ST2, ref int ST3);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_SegundaViaNaoFiscalVinculadoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_SubTotalizaCupomMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_SubTotalizaRecebimentoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TotalizaCupomMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_TotalizaRecebimentoMFD();

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_UsaRelatorioGerencialMFD(string Texto);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_GeraRegistrosCAT52MFD
			(string pathbin, string datas);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_ConfiguraECF
			(string gui, string velo, string modo, string beep);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_DataHoraGravacaoUsuarioSWBasicoMFAdicional(string datusu, string datasof, string ind);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_FlagsFiscais3MFD(ref int flag);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ObterMensagemStatus(string buf);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_CodigoModeloFiscal(string cniee, string descr);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EfetuaFormaPagamentoIndice(string s, string c);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_EfetuaFormaPagamentoIndiceDescricaoForma(string s, string v, string d);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_RetornaIndiceNomeMP(StringBuilder s, string v);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_DadosReducaoMFD(string CRZ, StringBuilder dados);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_ReproduzirMemoriaFiscalMFD(string tipo, string fxaini, string fxafim, string pattxt, string patbin);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_VerificaBloqueioZ(string zbloc);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Registry_CupomMania(string mania);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Registry_MinasLegal(string minas);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Registry_MensagemMania(string mania);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Registry_MensagemLegal(string legal);

		[DllImport("CONVECF.DLL")]
		public static extern int
			ECF_Registry_ECF_GeraRegistrosSPEDMFD(string jan, string com,
					string bin, string txt,
					string ini, string fim,
					string perfil, string cfop,
					string codobs, string pis,
					string cofins, string filler);

		[DllImport("CONVECF.DLL")]
		public static extern int ECF_UltimoDocumento(
					 StringBuilder modo,
					 StringBuilder doc,
					 StringBuilder fase,
					 StringBuilder COO);
		#endregion

		#endregion
	}
}
