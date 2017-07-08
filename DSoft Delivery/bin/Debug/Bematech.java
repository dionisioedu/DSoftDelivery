package bemajava;
/**
*  Bematech.java
*
*  Classe utilizada para compatibilidade com a dll BemaFI32.dll
**/

public class Bematech {

	//Inicializa��o
	public static native int AlteraSimboloMoeda(String simboloMoeda);
	public static native int EspacoEntreLinhas(int dots);
	public static native int ForcaImpactoAgulhas(int valorImpacto);
	public static native int LinhasEntreCupons(int linhas);
	public static native int NomeiaDepartamento(int indice, String departamento);
	public static native int NomeiaTotalizadorNaoSujeitoIcms(int indice, String totalizador);
	public static native int ProgramaAliquota(String aliquota, int vinculo);
	public static native int ProgramaArredondamento();
	public static native int ProgramaHorarioVerao();
	public static native int ProgramaTruncamento();
	
	//Cupom Fiscal
	public static native int AbreCupom(String CPF_CGC);
	public static native int AumentaDescricaoItem(String descricao);
	public static native int CancelaItemAnterior();
	public static native int CancelaItemGenerico(String numeroItem);
	public static native int CancelaCupom();
	public static native int EfetuaFormaPagamento(String formaPagamento, String valorFormaPagamento);
	public static native int EfetuaFormaPagamentoDescricaoForma(String formaPagamento, String valorFormaPagamento, String descricaoForma);
	public static native int EfetuaFormaPagamentoIndiceDescricao(String indice, String valorFormaPagamento, String descricaoForma); 
	public static native int EfetuaFormaPagamentoImpAntiga(String formaPagamento, String valorFormaPagamento);
	public static native int EfetuaFormaPagamentoIndice(String indice,String valorFormaPagamento);
	public static native int EstornoFormasPagamento(String formaOrigem,String formaDestino,String valor);
	public static native int FechaCupom(String formaPagamento,String acrescimoDesconto,String tipoAcrescimoDesconto,String valorAcrescimoDesconto,String valorPago,String mensagem);
	public static native int FechaCupomResumido(String formaPagamento,String mensagem);
	public static native int IniciaFechamentoCupom(String acrescimoDesconto,String tipoAcrescimoDesconto,String valorAcrescimoDesconto);
	public static native int TerminaFechamentoCupom(String mensagem);
	public static native int UsaUnidadeMedida(String unidadeMedida);
	public static native int VendeItem(String codigo, String descricao, String aliquota,String tipoQuantidade, String quantidade, int casasDecimais, String unitario, String tipoDesconto,String desconto);
	public static native int VendeItemDepartamento(String codigo,String descricao,String aliquota,String valorUnitario,String quantidade,String valorAcrescimo,String valorDesconto,String indiceDepartamento,String unidadeMedida);
	
	//Relat�rios Fiscais
	
	public static native int FechaRelatorioXouZ();
	public static native int LeituraMemoriaFiscalData(String dataInicial, String dataFinal);
	public static native int LeituraMemoriaFiscalReducao(String reducaoInicial, String reducaoFinal);
	public static native int LeituraMemoriaFiscalSerialData(String dataInicial, String dataFinal);
	public static native int LeituraMemoriaFiscalSerialReducao(String reducaoInicial, String reducaoFinal);
	public static native int LeituraX();
	public static native int LeituraXSerial();
	public static native int ReducaoZ(String data, String hora);
	public static native int ReducaoZImpAntiga();
	
	
	//Opera��es N�o Fiscais
	public static native int AbreComprovanteNaoFiscalVinculado(String formaPagamento,String valor,String numeroCupom);
	public static native int FechaComprovanteNaoFiscalVinculado();
	public static native int FechaRelatorioGerencial();
	public static native int RecebimentoNaoFiscal(String indiceTotalizador, String valorRecebimento, String formaPagamento);
	public static native int RelatorioGerencial(String texto);
	public static native int RelatorioGerencialImpAntiga( String texto );
	public static native int RelatorioGerencialTEF( String texto );
	public static native int Sangria(String valor);
	public static native int Suprimento(String valor, String formaPagamento);
	public static native int UsaComprovanteNaoFiscalVinculado(String texto);
	public static native int UsaComprovanteNaoFiscalVinculadoTEF( String texto );

	//TEF
	
	public static native int IniciaModoTEF();
	public static native int FinalizaModoTEF();
	
	//Gaveta
	public static native int AcionaGaveta();
	public static native int VerificaEstadoGaveta(BemaInteger estado);
	
	//Autentica��o
	public static native int Autenticacao();
	public static native int ProgramaCaracterAutenticacao(String caracter);
	
	//Cheque
	public static native int CancelaImpressaoCheque();
	public static native int ImprimeCheque(String numeroBanco,String valor,String favorecido,String cidade,String data,String mensagem);
	public static native int ImprimeCopiaCheque();
	public static native int IncluiCidadeFavorecido(String cidade,String favorecido);
	public static native int ProgramaMoedaPlural(String moedaPlural);
	public static native int ProgramaMoedaSingular(String moedaSingular);
	public static native int VerificaStatusCheque(BemaInteger status);
	
	
	//Outras Fun��es
	public static native int AberturaDoDia(String valorAux,String formaPagamento);
	public static native int AbrePorta(int numero);
	public static native int AbrePortaSerial();
	public static native int FechamentoDoDia();
	public static native int FechaPortaSerial();
	public static native int ImprimeConfiguracoesImpressora();
	public static native int ImprimeDepartamentos();
	public static native int ImpressaoCarne(String titulo, String parcela, String datas,int quantidade, String texto, String cliente,String CPF,String cupom,int vias,int assina);
	public static native int MapaResumo();
	public static native int RelatorioTipo60Analitico();
	public static native int RelatorioTipo60Mestre();
	public static native int ResetaImpressora();
	public static native int RetornoImpressora(BemaInteger ACK, BemaInteger ST1, BemaInteger ST2);
	public static native int SelecionaIniLocal();
	public static native int VerificaImpressoraLigada();
	
	//Bilhete Passagem
	public static native int AbreBilhetePassagem(String imprimeValorFim,String imprimeEnfatizado,String embarque,String destino,String linha,String prefixo,String agente,String agencia,String data,String hora,String poltrona,String plataforma);
	public static native int ContadorBilhetePassagem(BemaString contador);
	
	//FUN��ES RESTAURANTE
	public static native int AbreConferenciaMesa(String mesa);
	public static native int AbreCupomRestaurante(String mesa,String cPF);
	public static native int CancelaVenda(String mesa,String codigo,String descricao,String aliqTributaria,String cQtde,String valor,String flagAcrescimoDesconto,String valorAcreDesc);
	public static native int ConferenciaMesa(String mesa,String flagAcrescimoDesconto,String tipoAcrescimoDesconto,String valorAcrescimoDesconto);
	public static native int ContaDividida(String numeroCupons,String valorPago,String cPF);
	public static native int CardapioPelaSerial();
	public static native int FechaConferenciaMesa(String flagAcrescimoDesconto,String tipoAcrescimoDesconto, String valorAcreDesc);
	public static native int FechaCupomContaDividida(String numeroCupons,String acrescimoDesconto,String tipoAcrescimoDesconto,String valorAcrescimoDesconto,String formaPagamento,String valorFormaPagamento,String valorPagoConta,String cPF);
	public static native int FechaCupomRestaurante(String formaPagamento,String acrescimoDesconto,String tipoAcrescimoDesconto,String valorAcrescimoDesconto,String valorPago,String mensagem);
	public static native int FechaCupomResumidoRestaurante(String formaPagamento,String mensagem);
	public static native int ImprimeCardapio();
	public static native int RegistraVenda(String mesa,String codigo, String descricao,String aliquota, String cQuantidade,String valorUnitario, String FlagAcrescimoDesconto,String ValorAcrescimoDesconto);
	public static native int RegistroVendaSerial(String mesa);
	public static native int RelatorioMesasAbertas(int iTipoRelatorio);
	public static native int RelatorioMesasAbertasSerial();
	public static native int TransferenciaItem(String mesaOrigem,String codigo,String descricao,String aliquota,String cQuantidade,String valorUnitario,String flagAcrescimoDesconto,String valorAcrescimoDesconto,String mesaDestino);
	public static native int TransferenciaMesa(String mesaOrigem, String mesaDestino);
	public static native int VerificaMemoriaLivre(BemaString bytesLivres);
	
	
	//Informa��es da Impressora
	public static native int Acrescimos(BemaString valorAcrescimo);
	public static native int Cancelamentos(BemaString cancelamentos);
	public static native int CGC_IE(BemaString CGC, BemaString IE);
	public static native int ClicheProprietario(BemaString clicheProprietario);
	public static native int ContadoresTotalizadoresNaoFiscais(BemaString Contadores);
	public static native int DadosUltimaReducao(BemaString dadosReducao);
	public static native int DataHoraImpressora(BemaString data, BemaString hora);
	public static native int DataHoraReducao(BemaString data, BemaString hora);
	public static native int DataMovimento(BemaString dataMovimento); 
	public static native int Descontos(BemaString descontos);
	public static native int FlagsFiscais(BemaInteger flagFiscal);
	public static native int FlagsVinculacaoIss(BemaInteger flag1, BemaInteger flag2);
	public static native int GrandeTotal(BemaString grandeTotal);
	public static native int InfoBalanca(BemaString porta, BemaInteger modelo, BemaString peso,BemaString precoKg, BemaString total);
	public static native int LeArquivoRetorno(BemaString retorno);
	public static native int MinutosImprimindo(BemaString minutosImprimindo);
	public static native int MinutosLigada(BemaString minutosLigada);
	public static native int ModeloImpressora(BemaString modeloImpressora);
	public static native int MonitoramentoPapel(BemaInteger linhasImpressas);
	public static native int NumeroCaixa(BemaString numeroCaixa);
	public static native int NumeroCupom(BemaString numeroCupom); 
	public static native int NumeroCuponsCancelados(BemaString numeroCuponsCancelados);
	public static native int NumeroIntervencoes(BemaString numeroIntervencoes);
	public static native int NumeroLoja(BemaString numeroLoja);
	public static native int NumeroOperacoesNaoFiscais(BemaString operacoes);
	public static native int NumeroReducoes(BemaString numeroReducoes); 
	public static native int NumeroSerie(BemaString numeroSerie);
	public static native int NumeroSerieCriptografado(BemaString numeroSerie);
	public static native int NumeroSerieDescriptografado(String numeroSerieCriptografado, BemaString numeroSerieDescriptografado);
	public static native int NumeroSubstituicoesProprietario(BemaString substituicoes);
	public static native int RegistrosTipo60();
	public static native int RetornoAliquotas(BemaString aliquotas);
	public static native int SimboloMoeda(BemaString simboloMoeda);
	public static native int SubTotal(BemaString subTotal);
	public static native int UltimoItemVendido(BemaString ultimoItemVendido);
	public static native int VendaBruta(BemaString valor);
	public static native int ValorFormaPagamento(String forma, BemaString valorForma);
	public static native int ValorPagoUltimoCupom(BemaString valorUltimoCupom);
	public static native int ValorTotalizadorNaoFiscal(String totalizador, BemaString valor);
	public static native int VerificaAliquotasISS(BemaString aliquotasISS);
	public static native int VerificaAliquotasIssImpAntiga(BemaString aliquotasIss);
	public static native int VerificaDepartamentos(BemaString departamentos);
	public static native int VerificaEpromConectada(BemaString flagEprom);
	public static native int VerificaEstadoImpressora(BemaInteger ACK,BemaInteger ST1,BemaInteger ST2); 
	public static native int VerificaFormasPagamento(BemaString formasPagamento);
	public static native int VerificaIndiceAliquotasIss(BemaString indiceAliquotas);
	public static native int VerificaIndiceAliquotasIssImpAntiga(BemaString indices);
	public static native int VerificaModoOperacao(BemaString modoOperacao);
	public static native int VerificaRecebimentoNaoFiscal(BemaString recebimentos);
	public static native int VerificaReducaoZAutomatica(BemaInteger flag);
	public static native int VerificaTipoImpressora(BemaInteger tipo);
	public static native int VerificaTotalizadoresNaoFiscais(BemaString totalizadores);
	public static native int VerificaTotalizadoresParciais(BemaString totalizadores);
	public static native int VerificaTruncamento(BemaString flagTruncamento);
	public static native int VersaoDll(BemaString versao);
	public static native int VersaoFirmware(BemaString versaoFirmware);

	
	
	//Fun��es MFD

	public static native int GeraRegistrosCAT52MFD(String Arquivo, String Data);
	public static native int GeraRegistrosCAT52MFDEx(String Arquivo, String Data, BemaString PathDestino);
	public static native int AbreBilhetePassagemMFD(String embarque,String destino,String linha,String agencia,String data,String hora,String poltrona,String plataforma,String tipoPassagem,String RG,String nome,String endereco,String UF);
	public static native int AbreComprovanteNaoFiscalVinculadoMFD(String formaPagamento,String valor,String numeroCupom,String CPF,String nome,String endereco);
	public static native int AbreCupomMFD(String CPF,String nome,String endereco);
	public static native int AbreRecebimentoNaoFiscalMFD(String CPF,String nome,String endereco);
	public static native int AbreRelatorioGerencialMFD(String totalizador);
	public static native int AcionaGuilhotinaMFD(int modo);
	public static native int AcrescimoDescontoItemMFD(String item,
													  String acrescimoDesconto,
													  String tipoAcrescimoDesconto,
													  String valorAcrescimoDesconto);
	public static native int AcrescimoDescontoSubtotalRecebimentoMFD(String flag,
																	 String tipo,
																	 String valor);
	public static native int AcrescimoDescontoSubtotalMFD(String flag,
														  String tipo,
														  String valor);
	public static native int AcrescimoItemNaoFiscalMFD(String numeroItem , String acrDesc , String tipoAcrDesc , String valorAcrDesc );
	public static native int AtivaDesativaAlinhamentoEsquerdaMFD(int flag);
	public static native int AtivaDesativaCancelamentoCupom2HorasMFD(int flag);
	public static native int AtivaDesativaTratamentoONOFFLineMFD(int flag);
	public static native int AtivaDesativaVendaUmaLinhaMFD(int flag);
	public static native int AutenticacaoMFD(String cLinhas, String texto);
	public static native int CancelaAcrescimoDescontoItemMFD(String flag, String item);
	public static native int CancelaAcrescimoDescontoSubtotalMFD(String flag);
	public static native int CancelaAcrescimoDescontoSubtotalRecebimentoMFD(String flag);
	public static native int CancelaAcrescimoNaoFiscalMFD(String numeroItem,String acrDesc);
	public static native int CancelaCupomMFD(String CPF, String nome, String endereco);
	public static native int CancelaItemNaoFiscalMFD(String numeroItem);
	public static native int CancelaRecebimentoNaoFiscalMFD(String CPF, String nome, String endereco);
	public static native int ComprovantesNaoFiscaisNaoEmitidosMFD(BemaString comprovantes);
	public static native int CNPJMFD(BemaString cNPJ);
	public static native int CodigoBarrasCODABARMFD(String codigo);
	public static native int CodigoBarrasCODE39MFD(String codigo);
	public static native int CodigoBarrasCODE93MFD(String barcode);
	public static native int CodigoBarrasCODE128MFD(String barcode);
	public static native int CodigoBarrasEAN13MFD(String barcode);
	public static native int CodigoBarrasEAN8MFD(String barcode);
	public static native int CodigoBarrasISBNMFD(String barcode);
	public static native int CodigoBarrasITFMFD(String barcode);
	public static native int CodigoBarrasMSIMFD(String barcode);
	public static native int CodigoBarrasPDF417MFD(int NCE, int altura,int largura,int numColunas,String barcode);
	public static native int CodigoBarrasPLESSEYMFD(String barcode);
	public static native int CodigoBarrasUPCAMFD(String barcode);
	public static native int CodigoBarrasUPCEMFD(String barcode);
	public static native int ConfiguraCodigoBarrasMFD(int altura, int largura,int posicaoCaracteres,int fonte,int margem);
	
	public static native int ContadorComprovantesCreditoMFD(BemaString contador);
	public static native int ContadorCupomFiscalMFD(BemaString contador);
	public static native int ContadorFitaDetalheMFD(BemaString contador);
	public static native int ContadorOperacoesNaoFiscaisCanceladasMFD(BemaString contador);
	public static native int ContadorRelatoriosGerenciaisMFD(BemaString contador);
	public static native int ContadoresTotalizadoresNaoFiscaisMFD(BemaString contador);
	public static native int CupomAdicionalMFD();
	public static native int DadosSintegra(String dataInicial ,String dataFinal);
	
	public static native int DadosUltimaReducaoMFD(BemaString dadosUltReducao);
	public static native int DataHoraUltimoDocumentoMFD(BemaString dataHora);
	public static native int DataMovimentoUltimaReducaoMFD(BemaString dataMovimento);
	public static native int DownloadMF(String nomeArquivo);
	public static native int DownloadMFD(String nomeArquivo,String tipoDownload,String dadoInicial,String dadoFinal,String usuario);
	public static native int DownloadSB(String nomeArquivo);
	public static native int EfetuaFormaPagamentoMFD(String formaPagamento, 
													 String valorFormaPagamento, 
													 String cParcelas, 
													 String descricaoFormaPagto);
	
	public static native int EfetuaFormaPagamentoIndiceMFD(String indice,String valorFormaPagamento,String cParcelas, String descricaoForma);
	public static native int EfetuaRecebimentoNaoFiscalMFD(String indiceTotalizador,
														   String valorRecebimento);
	public static native int EstornoNaoFiscalVinculadoMFD(String CPF, String nome, String endereco);
	public static native int FechaRecebimentoNaoFiscalMFD(String mensagem);
	public static native int FormatoDadosMFD(String arquivoMFD,String destino,String formato,String tipoDownload,String dadoInicial,String dadoFinal,String cUsuario);
	public static native int GeraRelatorioSintegraMFD(int iRelatorios,String cOrigem,String destino, String mes,String ano,String cRazaoSocial,String endereco,String numero,String complemento,String cBairro,String cidade,String CEP,String telefone,String fax,String contato);
	public static native int GrandeTotalUltimaReducaoMFD(BemaString grandeTotal);
	public static native int HabilitaDesabilitaRetornoEstendidoMFD(String flagRetorno);
	public static native int ImpressaoFitaDetalhe( String tipo, String dadoInicial, String dadoFinal, String usuario );
	public static native int ImprimeChequeMFD(String numeroBanco, String valor,
											  String favorecido, String cidade,
											  String data,String msg,String impressaoVerso,
							  				  String linhas);
	
	public static native int ImprimeClicheMFD();
	public static native int ImprimeInformacaoChequeMFD(int posicao, int linhas, String mensagem);
	public static native int IniciaFechamentoCupomMFD(String acrescimoDesconto,
													  String tipoAcrescimoDesconto,
													  String valorAcrescimo,
													  String valorDesconto);
	public static native int IniciaFechamentoRecebimentoNaoFiscalMFD(String acrescimoDesconto,
																	 String tipoAcrescimoDesconto,
			   														 String valorAcrescimo,
			   														 String valorDesconto);
	public static native int InicioFimCOOsMFD(BemaString COOInicial, BemaString COOFinal);
	public static native int InicioFimGTsMFD(BemaString GTInicial, BemaString GTFinal);
	public static native int InscricaoEstadualMFD(BemaString IE);
	public static native int InscricaoMunicipalMFD(BemaString IM);
	public static native int LeituraChequeMFD(BemaString CMC7);
	public static native int LeituraMemoriaFiscalDataMFD(String dataInicial,String dataFinal,String flagLeitura);
	public static native int LeituraMemoriaFiscalReducaoMFD(String reducaoInicial,String reducaoFinal,String flagLeitura);
	public static native int LeituraMemoriaFiscalSerialDataMFD(String dataInicial,String dataFinal,String flagLeitura);
	public static native int LeituraMemoriaFiscalSerialReducaoMFD(String reducaoInicial,String reducaoFinal,String flagLeitura);
	public static native int MapaResumoMFD();
	public static native int MarcaModeloTipoImpressoraMFD(BemaString marca, BemaString modelo, BemaString tipo);
	public static native int MinutosEmitindoDocumentosFiscaisMFD(BemaString minutos);
	public static native int NomeiaRelatorioGerencialMFD(String indice, String descricao);
	public static native int NumeroSerieMFD(BemaString numeroSerie);
	public static native int NumeroSerieMemoriaMFD(BemaString numeroSerie);
	public static native int PercentualLivreMFD(BemaString valor);
	public static native int ProgramaFormaPagamentoMFD(String formaPagamento, String operacaoTef);
	public static native int ProgramaIdAplicativoMFD(String idAplicativo);
	public static native int ReducoesRestantesMFD(BemaString valor);
	public static native int ReimpressaoNaoFiscalVinculadoMFD();
	public static native int RelatorioSintegraMFD(int relatorios, String arquivo,String mes,String ano,String razaoSocial,String endereco,String numero,String complemento,String bairro,String cidade,String CEP,String telefone,String fax,String contato);
	public static native int RelatorioTipo60AnaliticoMFD();
	public static native int RetornoImpressoraMFD(BemaInteger ACK,BemaInteger ST1,BemaInteger ST2,BemaInteger ST3);
	public static native int SegundaViaNaoFiscalVinculadoMFD();
	public static native int SetaMFD(int flag);
	public static native int StatusEstendidoMFD(BemaInteger status);
	public static native int SubTotalComprovanteNaoFiscalMFD(BemaString subTotal);
	public static native int SubTotalizaCupomMFD();
	public static native int SubTotalizaRecebimentoMFD();
	public static native int TotalLivreMFD(BemaString tamanho);
	public static native int TamanhoTotalMFD(BemaString tamanho);
	public static native int TempoOperacionalMFD(BemaString tempo);
	public static native int TempoRestanteComprovanteMFD(BemaString tempo);
	public static native int TerminaFechamentoCupomCodigoBarrasMFD(String mensagem,String tipoCodigo,String codigo,int iAltura,int iLargura,int iPosicaoCaracteres,int iFonte,int iMargem,int iCorrecaoErros,int iColunas);
	public static native int TotalizaCupomMFD();
	public static native int TotalizaRecebimentoMFD();
	public static native int UFProprietarioMFD(BemaString UF);
	public static native int UsaRelatorioGerencialMFD(String texto);
	public static native int UsaRelatorioGerencialMFDTEF(String texto);
	public static native int ValorFormaPagamentoMFD(String formaPagamento, BemaString valorForma);
	public static native int ValorTotalizadorNaoFiscalMFD(String totalizador, BemaString valor);
	public static native int VerificaCancelamentoCupom2HorasMFD(BemaString flag);
	public static native int VerificaEstadoImpressoraMFD(BemaInteger ACK,BemaInteger ST1,BemaInteger ST2,BemaInteger ST3);
	public static native int VerificaFlagCorteMFD(BemaInteger flag);
	public static native int VerificaFormasPagamentoMFD(BemaString formasPagamento);
	public static native int VerificaRecebimentoNaoFiscalMFD(BemaString recebimentoNaoFiscal);
	public static native int VerificaRelatorioGerencialMFD(BemaString relatorio);
	public static native int VerificaSensorPoucoPapelMFD(BemaString flag);
	public static native int VerificaTotalizadoresNaoFiscaisMFD(BemaString totalizadores);
	public static native int VerificaTotalizadoresParciaisMFD(BemaString totalizadores);
	public static native int VersaoFirmwareMFD(BemaString versao);
		
	static{
		System.loadLibrary ("BemaFI32");
	}
	
}






