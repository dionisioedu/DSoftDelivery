using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSoftParameters;
using System.Windows.Forms;

namespace DSoftCore
{
	public class ECFHelper
	{
		public void AberturaDoDia(string valor, string forma)
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					int retorno = BemaFI64.Bematech_FI_AberturaDoDia(valor, forma);

					if (retorno == 1)
					{
						MessageBox.Show("Abertuda do dia efetuada com sucesso!");
					}
					else if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação.");
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Parâmetro inválido na função.");
					}
					else if (retorno == -4)
					{
						MessageBox.Show("O arquivo de inicialização BemaFI32.ini não foi encontrado no diretório de sistema do Windows.");
					}
					else if (retorno == -5)
					{
						MessageBox.Show("Erro ao abrir a porta de comunicação.");
					}
					else if (retorno == -27)
					{
						MessageBox.Show("Status da impressora diferente de 6,0,0 (ACK, ST1 e ST2).");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					int retorno = SwedaST120.ECF_AberturaDoDia(valor, forma);

					if (retorno == 1)
					{
						MessageBox.Show("Abertura do dia efetuada com sucesso!");
					}
					else if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação!");
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Parâmetro inválido na função!");
					}
					else if (retorno == -27)
					{
						MessageBox.Show("Status do ECF diferente de 6,0,0,0 (ACK,ST1,ST2 e ST3).");
					}
				}
			}
		}

		public void ProgramaFormasDePagamento(List<String> formas)
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					foreach (string s in formas)
					{
						BemaFI64.Bematech_FI_ProgramaFormaPagamentoMFD(s.ToUpper(), "0");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					SwedaST120.ECF_ApagaTabelaNomesFormasdePagamento();

					foreach (string s in formas)
					{
						SwedaST120.ECF_ProgramaFormaPagamentoMFD(s.ToUpper(), "0");
					}
				}
			}
		}

		/// <summary>
		/// Cancela o último Cupom Fiscal emitido
		/// </summary>
		public void CancelaCupom()
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					BemaFI64.Bematech_FI_CancelaCupom();
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					SwedaST120.ECF_CancelaCupom();
				}
			}
		}

		/// <summary>
		/// Leitura dos totalizadores do ECF, que não altera os contadores. Deve ser efetuado no início do dia.
		/// </summary>
		public void LeituraX()
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					if (BemaFI64.Bematech_FI_LeituraX() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					if (SwedaST120.ECF_LeituraX() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
			}
		}

		public void LeituraMemoriaFiscalData(DateTime de, DateTime ate)
		{
			string data_inicio = de.ToString("dd/MM/yyyy");
			string data_final = ate.ToString("dd/MM/yyyy");

			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					int retorno = BemaFI64.Bematech_FI_LeituraMemoriaFiscalData(data_inicio, data_final);

					if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação.");
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Parâmetro inválido na função.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					int retorno = SwedaST120.ECF_LeituraMemoriaFiscalData(data_inicio, data_final);

					if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação.");
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Parâmetro inválido na função.");
					}
				}
			}
		}

		/// <summary>
		/// Faz o fechamento do dia emitindo uma Redução Z
		/// </summary>
		public void FechamentoDoDia()
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					if (BemaFI64.Bematech_FI_FechamentoDoDia() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					if (SwedaST120.ECF_FechamentoDoDia() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
			}
		}

		/// <summary>
		/// Emite a Redução Z. Permite ajustar o relógio interno da impressora em até 5 minutos.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="hora"></param>
		public void ReducaoZ(DateTime data, DateTime hora)
		{
			string data_ajuste = data.ToString("dd/MM/yyyy");
			string hora_ajuste = hora.ToString("HH:mm:ss");

			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					int retorno = BemaFI64.Bematech_FI_ReducaoZ(data_ajuste, hora_ajuste);

					if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					int retorno = SwedaST120.ECF_ReducaoZ(data_ajuste, hora_ajuste);

					if (retorno == 0)
					{
						MessageBox.Show("Erro de comunicação.");
					}
					else if (retorno == -2)
					{
						MessageBox.Show("Parâmetro inválido na função.");
					}
					else if (retorno == -8)
					{
						MessageBox.Show("Erro no acesso a arquivo interno.");
					}
				}
			}
		}

		public void DownloadMF(string arquivo)
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					if (BemaFI64.Bematech_FI_DownloadMF(arquivo) < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					if (SwedaST120.ECF_DownloadMF(arquivo) < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
			}
		}

		public void AbrePortaSerial()
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					if (BemaFI64.Bematech_FI_AbrePortaSerial() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					if (SwedaST120.ECF_AbrePortaSerial() < 1)
					{
						MessageBox.Show("Erro de comunicação...");
					}
					else
					{
						MessageBox.Show("Comando recebido!");
					}
				}
			}
		}

		public void FechaPortaSerial()
		{
			if (RegrasDeNegocio.Instance.EmiteCupomFiscal)
			{
				if (Terminal.ECF() == BemaFI64.ID)
				{
					if (BemaFI64.Bematech_FI_FechaPortaSerial() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
				}
				else if (Terminal.ECF() == SwedaST120.ID)
				{
					if (SwedaST120.ECF_FechaPortaSerial() < 1)
					{
						MessageBox.Show("Erro de comunicação.");
					}
					else
					{
						MessageBox.Show("Comando recebido!");
					}
				}
			}
		}

		public void Analisa_Retorno_ECF()
		{
			//Retorno igual 6,0,0 Comando Ok.

			int ACK = 0, ST1 = 0, ST2 = 0; //ST3=0;

			if (Terminal.ECF() == SwedaST120.ID)
			{
				SwedaST120.ECF_RetornoImpressora(ref  ACK, ref  ST1, ref  ST2);
			}

			// ECF_RetornoImpressora(ref ACK, ref ST1, ref ST2, ref ST3);
			if (ACK != 6)
			{
				MessageBox.Show("Problemas ao Enviar Comando", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			if (ST1 >= 128)
			{
				MessageBox.Show("Fim de Papel Trocar Bubina", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 128;
			}
			else if (ST1 >= 64)
			{
				// O Papel esta Terminando - Verificar Papel
				MessageBox.Show("O Papel esta Terminando - Verificar Papel", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 64;
			}
			else if (ST1 >= 32)
			{
				MessageBox.Show("Erro no Relogio interno do ECF", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 32;
			}
			else if (ST1 >= 16)
			{
				MessageBox.Show("IMPRESSORA EM ERROR -DELIGUE E LIGUE O ECF", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 16;
			}
			else if (ST1 >= 8)
			{
				MessageBox.Show("ERRO NO ENVIO DO COMANDO - FAVOR REPETIR A OPERAÇÃO", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 8;
			}
			else if (ST1 >= 4)
			{
				MessageBox.Show("COMANDO INEXISTENTE -", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 4;
			}
			else if (ST1 >= 2)
			{
				MessageBox.Show("CUPOM FISCAL ABERTO - CANCELE OU TERMINE A VENDA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 2;
			}
			else if (ST1 >= 1)
			{
				MessageBox.Show("PARAMETRO INVALIDO", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST1 -= 1;
			}

			/***********************************************************************************/
			/* ST2*/

			if (ST2 >= 128)
			{
				MessageBox.Show("TIPO DE CMD INVALIDO - ABRIR CHAMADO", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 128;
			}
			else if (ST2 >= 64)
			{
				MessageBox.Show("MEMORIA FISCAL CHEIA CHAMAR ASSITÊNCIA TECNICA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 64;
			}
			else if (ST2 >= 32)
			{
				MessageBox.Show("ERRO DE CMOS DO ECF CHAMAR ASSINTECIA TECNICA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 32;
			}
			else if (ST2 >= 16)
			{
				MessageBox.Show("ALIQUOTA NÃO PROGRAMADA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 16;
			}
			else if (ST2 >= 8)
			{
				MessageBox.Show("CAPACIDADE DE ALIQUOTA LOTADA ", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 8;
			}
			else if (ST2 >= 4)
			{
				MessageBox.Show("CANCELAMENTO NÃO PERMITIDO PELO ECF", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 4;
			}
			else if (ST2 >= 2)
			{
				MessageBox.Show("CGC/IE NÃO PROGRAMADOS CHAMAR ASSITENCIA TECNICA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 2;
			}
			else if (ST2 >= 1)
			{
				MessageBox.Show("COMANDO NÃO EXECULTADO -  VERIFIQUE STATUS DA IMPRESSORA", "ECF.NET SWEDA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ST2 -= 1;
			}
		}
	}
}
