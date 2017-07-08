using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoft_Delivery.CTe
{
	#region Enumerations

	public enum Status : int
	{
		AutorizadoUsoCTe = 100,
		CancelamentoCTeHomologado = 101,
		InutilizacaoNumeroHomologado = 102,
		LoteRecebidoComSucesso = 103,
		LoteProcessado = 104,
		LoteEmProcessamento = 105,
		LoteNaoLocalizado = 106,
		ServicoEmOperacao = 107,
		ServicoParalizadoMomentaneamente = 108,
		ServicoParalizadoSemPrevisao = 109,
		UsoDenegado = 110,
		ConsultaCadastroComUmaOcorrencia = 111,
		ConsultaCadastroMaisOcorrencia = 112,
		CTeAnuladoPeloEmissor = 128,
		CTeSubstituidoPeloEmissor = 129,
		ApresentadaCartaCorrecaoEletronica = 130,
		CTeDesclassificadoPeloFisco = 131
	}

	#endregion Enumerations
}