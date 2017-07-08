using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftModels
{
	public class OrdemDeColeta
	{
		#region Fields

		public double AliquotaICMS;
		public string Ambiente;
		public string Arquivo;
		public DateTime Cancelada;
		public int CFOP;
		public string[] ChaveAcesso;
		public DateTime Chegada;
		public DateTime Coleta;
		public string[] Componente;
		public DateTime Conferida;
		public string Conhecimento;
		public string CST;
		public string CTe;
		public DateTime Data;
		public string DataHoraRecebimento;
		public Cliente Destinatario;
		public string DigVal;
		public string[] DocEmit;
		public string[] DocNota;
		public string[] DocSerie;
		public string[] DocTipo;
		public Emitente Emitente;
		public DateTime Enviada;
		public double ICMSST;
		public int Indice;
		public int Lote;
		public int Manifesto;
		public DateTime Montagem;
		public string Motivo;
		public Recurso Motorista;
		public string MsgErro;
		public string NaturezaDaOperacao;
		public long NumeroProtocolo;
		public string[] Observacoes;
		public string OutrasCaracteristicas;
		public bool Pago;
		public DateTime PrevisaoColeta;
		public DateTime PrevisaoEntrega;
		public string ProdudoPredominante;
		public double[] Quantidade;
		public DateTime Recebida;
		public long Recibo;
		public double RedBCICMS;
		public Cliente Remetente;
		public string RNTRC;
		public char Situacao;
		public string Status;
		public string[] TipoMedida;
		public string[] UnidadeMedida;
		public double ValorBCICMS;
		public double ValorFrete;
		public double ValorICMS;
		public double ValorMercadoria;
		public double[] ValorPrestacao;
		public Veiculo Veiculo;
		public string MunicipioDestino;
		public string EstadoDestino;
		public double Peso;
		public string NumeroColeta;
		public string Origem;
		public string CaracAd;
		public string CaracSer;
		public string ObsCont;
		public string ObsFisco;
		public string Obs;

		#endregion Fields

		#region Constructors

		public OrdemDeColeta()
		{
			Emitente = new Emitente();

			Situacao = 'A';

			Remetente = new Cliente();
			Destinatario = new Cliente();
			ValorMercadoria = 0;
			ValorFrete = 0;
			ProdudoPredominante = string.Empty;
			OutrasCaracteristicas = string.Empty;
			Quantidade = new double[5];
			UnidadeMedida = new string[5];
			TipoMedida = new string[5];
			ChaveAcesso = new string[6];
			DocTipo = new string[6];
			DocEmit = new string[6];
			DocNota = new string[6];
			DocSerie = new string[6];
			Componente = new string[12];
			ValorPrestacao = new double[12];
			Observacoes = new string[5];

			for (int i = 0; i < Quantidade.Length; i++)
				Quantidade[i] = 0;

			for (int i = 0; i < UnidadeMedida.Length; i++)
				UnidadeMedida[i] = string.Empty;

			for (int i = 0; i < TipoMedida.Length; i++)
				TipoMedida[i] = string.Empty;

			for (int i = 0; i < ChaveAcesso.Length; i++)
				ChaveAcesso[i] = string.Empty;

			for (int i = 0; i < DocTipo.Length; i++)
			{
				DocTipo[i] = string.Empty;
				DocEmit[i] = string.Empty;
				DocNota[i] = string.Empty;
				DocSerie[i] = string.Empty;
			}

			for (int i = 0; i < Componente.Length; i++)
			{
				Componente[i] = string.Empty;
				ValorPrestacao[i] = 0;
			}

			for (int i = 0; i < Observacoes.Length; i++)
				Observacoes[i] = string.Empty;

			Motorista = new Recurso();
			Veiculo = new Veiculo();
		}

		#endregion Constructors

		#region Methods

		public bool TemDados()
		{
			if (ProdudoPredominante.Length > 0 || ValorMercadoria > 0 || ValorFrete > 0)
			{
				return true;
			}

			return false;
		}

		#endregion Methods
	}
}