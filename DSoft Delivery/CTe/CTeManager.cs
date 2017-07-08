using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using DSoftBd;

using DSoftCore;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public class CTeManager
	{
		#region Fields

		public const string DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:ss";
		public const string DATE_FORMAT = "yyyy-MM-dd";

		#endregion Fields

		#region Methods

		public static bool EnviarCte(string cte)
		{
			try
			{

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Cte", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public static bool ImprimirCTe(string cte)
		{
			string file = Preferencias.PastaCteArquivo + "\\" + cte + "-procCTe.xml";

			if (File.Exists(file))
			{
				System.Diagnostics.Process.Start(Preferencias.PastaCteArquivo + "\\" + cte + "-procCTe.xml");

				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool ImprimirCTeCrystalReports(string arquivo)
		{
			/*
			string modal;
			string emitente_endereco;
			string emitente_cnpj;
			string emitente_ie;
			string emitente_telefone;
			string modelo;
			string serie;
			string numero;
			string fl;
			string data_hora_emissao;
			string tipo_cte;
			string tipo_servico;
			string tomador_servico;
			string forma_pagamento;
			string protocolo;
			string insc_suframa_destinatario;
			string cfop;
			string origem_prestacao;
			string destino_prestacao;
			string remetente;
			string remetente_endereco;
			string remetente_municipio;
			string remetente_doc;
			string remetente_pais;
			string remetente_cep;
			string remetente_ie;
			string remetente_fone;
			string destinatario;
			string destinatario_endereco;
			string destinatario_municipio;
			string destinatario_doc;
			string destinatario_pais;
			string destinatario_cep;
			string destinatario_ie;
			string destinatario_fone;
			string expeditor;
			string expeditor_endereco;
			string expeditor_municipio;
			string expeditor_doc;
			string expeditor_pais;
			string expeditor_cep;
			string expeditor_ie;
			string expeditor_fone;
			string recebedor;
			string recebedor_endereco;
			string recebedor_municipio;
			string recebedor_doc;
			string recebedor_pais;
			string recebedor_cep;
			string recebedor_ie;
			string recebedor_fone;
			string tomador_servico2;
			string tomador_municipio;
			string tomador_uf;
			string tomador_cep;
			string tomador_endereco;
			string tomador_pais;
			string tomador_doc;
			string tomador_ie;
			string tomador_fone;
			string produto_predominante;
			string outras_caracteristicas_carga;
			double valor_total_mercadoria;
			string qtd_1, qtd_2, qtd_3, qtd_4, qtd_5;
			string seguradora_nome;
			string seguradora_responsavel;
			string seguradora_apolice;
			string seguradora_averbacao;
			string comp_1, comp_2, comp_3, comp_4, comp_5, comp_6, comp_7, comp_8, comp_9, comp_10, comp_11, comp_12;
			double val_1, val_2, val_3, val_4, val_5, val_6, val_7, val_8, val_9, val_10, val_11, val_12;
			string chave_acesso, chave_acessof;
			double val_total_servico;
			double val_total_receber;
			string situacao_tributaria;
			double bc_icms, aliq_icms, valor_icms, red_bc_calc, icms_st;
			string obs1, obs2, obs3;

			if (!File.Exists(arquivo))
			{
				MessageBox.Show("Arquivo não encontrado!" + Environment.NewLine + arquivo, "CTe", MessageBoxButtons.OK, MessageBoxIcon.Hand);

				return false;
			}

			DataSet ds = new DataSet();

			ds.ReadXml(arquivo);

			frmRelatorio form = new frmRelatorio();
			form.Text = "DSoft - CTe";

			relDACTE report = new relDACTE();

			modal = ds.Tables["ide"].Rows[0].ItemArray[19].ToString();

			if (modal == "01")
				modal += "-Rodoviário";
			else if (modal == "02")
				modal += "-Aéreo";
			else if (modal == "03")
				modal += "-Aquaviário";
			else if (modal == "04")
				modal += "-Ferroviário";
			else if (modal == "05")
				modal += "-Dutoviário";

			emitente_endereco = ds.Tables["enderEmit"].Rows[0].ItemArray[0].ToString() + ", " + ds.Tables["enderEmit"].Rows[0].ItemArray[1].ToString() + " " + ds.Tables["enderEmit"].Rows[0].ItemArray[2].ToString() +
				Environment.NewLine + ds.Tables["enderEmit"].Rows[0].ItemArray[3].ToString() + " - " + ds.Tables["enderEmit"].Rows[0].ItemArray[5].ToString() + " - " + ds.Tables["enderEmit"].Rows[0].ItemArray[7].ToString();
			emitente_cnpj = Util.Formata(ulong.Parse(ds.Tables["emit"].Rows[0].ItemArray[0].ToString()), "00.000.000/0000-00");
			emitente_ie = Util.Formata(ulong.Parse(ds.Tables["emit"].Rows[0].ItemArray[1].ToString()), "000.000.000.000");
			emitente_telefone = ds.Tables["enderEmit"].Rows[0].ItemArray[9].ToString();
			modelo = ds.Tables["ide"].Rows[0].ItemArray[5].ToString();
			serie = ds.Tables["ide"].Rows[0].ItemArray[6].ToString();
			numero = ds.Tables["ide"].Rows[0].ItemArray[7].ToString();
			fl = "1/1";
			data_hora_emissao = ds.Tables["ide"].Rows[0].ItemArray[8].ToString().Replace('T', ' ');
			tipo_cte = (ds.Tables["ide"].Rows[0].ItemArray[10].ToString() == "1" ? "NORMAL" : "CONTINGÊNCIA");

			switch (ds.Tables["ide"].Rows[0].ItemArray[20].ToString())
			{
				case "0":
					tipo_servico = "NORMAL";
					break;

				case "1":
					tipo_servico = "SUBCONTRATAÇÃO";
					break;

				case "2":
					tipo_servico = "REDESPACHO";
					break;

				case "3":
				default:
					tipo_servico = "REDESPACHO INTERMEDIÁRIO";
					break;
			}

			switch (ds.Tables["toma03"].Rows[0].ItemArray[0].ToString())
			{
				case "0":
					tomador_servico = "REMETENTE";
					break;

				case "1":
					tomador_servico = "EXPEDITOR";
					break;

				case "2":
					tomador_servico = "RECEBEDOR";
					break;

				case "3":
				default:
					tomador_servico = "DESTINATÁRIO";
					break;
			}

			switch (ds.Tables["ide"].Rows[0].ItemArray[4].ToString())
			{
				case "0":
					forma_pagamento = "PAGO";
					break;

				case "1":
					forma_pagamento = "À PAGAR";
					break;

				case "2":
				default:
					forma_pagamento = "OUTROS";
					break;
			}

			protocolo = ds.Tables["infProt"].Rows[0].ItemArray[4].ToString();
			insc_suframa_destinatario = "";
			cfop = ds.Tables["ide"].Rows[0].ItemArray[2].ToString() + " - " + ds.Tables["ide"].Rows[0].ItemArray[3].ToString();
			origem_prestacao = ds.Tables["ide"].Rows[0].ItemArray[22].ToString() + " - " + ds.Tables["ide"].Rows[0].ItemArray[23].ToString();
			destino_prestacao = ds.Tables["ide"].Rows[0].ItemArray[25].ToString() + " - " + ds.Tables["ide"].Rows[0].ItemArray[26].ToString();
			remetente = ds.Tables["rem"].Rows[0].ItemArray[2].ToString();
			remetente_endereco = ds.Tables["enderReme"].Rows[0].ItemArray[0].ToString() + ", " + ds.Tables["enderReme"].Rows[0].ItemArray[1].ToString();
			remetente_municipio = ds.Tables["enderReme"].Rows[0].ItemArray[5].ToString();
			remetente_doc = Util.Formata(ulong.Parse(ds.Tables["rem"].Rows[0].ItemArray[0].ToString()), "00.000.000/0000-00");
			remetente_pais = ds.Tables["enderReme"].Rows[0].ItemArray[8].ToString();
			remetente_cep = Util.Formata(ulong.Parse(ds.Tables["enderReme"].Rows[0].ItemArray[ds.Tables["enderReme"].Columns.IndexOf("cep")].ToString()), "00000-000");
			remetente_ie = (ds.Tables["rem"].Rows[0].ItemArray[1].ToString() == "ISENTO" ? "ISENTO" : Util.Formata(ulong.Parse(ds.Tables["rem"].Rows[0].ItemArray[1].ToString()), "000.000.000.000"));
			remetente_fone = (ds.Tables["rem"].Columns.IndexOf("fone") >= 0 ? ds.Tables["rem"].Rows[0].ItemArray[ds.Tables["rem"].Columns.IndexOf("fone")].ToString() : " ");
			destinatario = ds.Tables["dest"].Rows[0].ItemArray[2].ToString();
			destinatario_endereco = ds.Tables["enderDest"].Rows[0].ItemArray[0].ToString() + ", " + ds.Tables["enderDest"].Rows[0].ItemArray[1].ToString();
			destinatario_municipio = ds.Tables["enderDest"].Rows[0].ItemArray[5].ToString();
			destinatario_doc = Util.Formata(ulong.Parse(ds.Tables["dest"].Rows[0].ItemArray[0].ToString()), "00.000.000/0000-00");
			destinatario_pais = ds.Tables["enderDest"].Rows[0].ItemArray[8].ToString();
			destinatario_cep = Util.Formata(ulong.Parse(ds.Tables["enderDest"].Rows[0].ItemArray[ds.Tables["enderDest"].Columns.IndexOf("cep")].ToString()), "00000-000");
			destinatario_ie = (ds.Tables["dest"].Rows[0].ItemArray[1].ToString() == "ISENTO" ? "ISENTO" : Util.Formata(ulong.Parse(ds.Tables["dest"].Rows[0].ItemArray[1].ToString()), "000.000.000.000"));
			destinatario_fone = (ds.Tables["dest"].Columns.IndexOf("fone") >= 0 ? ds.Tables["dest"].Rows[0].ItemArray[ds.Tables["dest"].Columns.IndexOf("fone")].ToString() : " ");
			expeditor = ds.Tables["exped"].Rows[0].ItemArray[2].ToString();
			expeditor_endereco = ds.Tables["enderExped"].Rows[0].ItemArray[0].ToString() + ", " + ds.Tables["enderExped"].Rows[0].ItemArray[1].ToString();
			expeditor_municipio = ds.Tables["enderExped"].Rows[0].ItemArray[5].ToString();
			expeditor_doc = Util.Formata(ulong.Parse(ds.Tables["exped"].Rows[0].ItemArray[0].ToString()), "00.000.000/0000-00");
			expeditor_pais = ds.Tables["enderExped"].Rows[0].ItemArray[8].ToString();
			expeditor_cep = Util.Formata(ulong.Parse(ds.Tables["enderExped"].Rows[0].ItemArray[6].ToString()), "00000-000");
			expeditor_ie = (ds.Tables["exped"].Rows[0].ItemArray[1].ToString() == "ISENTO" ? "ISENTO" : Util.Formata(ulong.Parse(ds.Tables["exped"].Rows[0].ItemArray[1].ToString()), "000.000.000.000"));
			expeditor_fone = (ds.Tables["exped"].Columns.IndexOf("fone") >= 0 ? ds.Tables["exped"].Rows[0].ItemArray[ds.Tables["exped"].Columns.IndexOf("fone")].ToString() : " ");
			recebedor = string.Empty;
			recebedor_endereco = string.Empty;
			recebedor_municipio = string.Empty;
			recebedor_doc = string.Empty;
			recebedor_pais = string.Empty;
			recebedor_cep = string.Empty;
			recebedor_ie = string.Empty;
			recebedor_fone = string.Empty;

			tomador_servico2 = string.Empty;
			tomador_municipio = string.Empty;
			tomador_uf = string.Empty;
			tomador_cep = string.Empty;
			tomador_endereco = string.Empty;
			tomador_pais = string.Empty;
			tomador_doc = string.Empty;
			tomador_ie = string.Empty;
			tomador_fone = string.Empty;
			produto_predominante = ds.Tables["infCarga"].Rows[0].ItemArray[ds.Tables["infCarga"].Columns.IndexOf("proPred")].ToString();
			outras_caracteristicas_carga = ds.Tables["infCarga"].Rows[0].ItemArray[ds.Tables["infCarga"].Columns.IndexOf("xOutCat")].ToString();
			valor_total_mercadoria = double.Parse(ds.Tables["infCarga"].Rows[0].ItemArray[ds.Tables["infCarga"].Columns.IndexOf("vMerc")].ToString()) / 100;

			qtd_1 = string.Empty;
			qtd_2 = string.Empty;
			qtd_3 = string.Empty;
			qtd_4 = string.Empty;
			qtd_5 = string.Empty;

			for (int i = 0; i < ds.Tables["infQ"].Rows.Count; i++)
			{
				string temp;

				temp = ds.Tables["infQ"].Rows[i].ItemArray[ds.Tables["infQ"].Columns.IndexOf("qCarga")].ToString();

				switch (ds.Tables["infQ"].Rows[i].ItemArray[ds.Tables["infQ"].Columns.IndexOf("cUnid")].ToString())
				{
					case "00":
						temp += " M3";
						break;
					case "01":
						temp += " KG";
						break;
					case "02":
						temp += " TON";
						break;
					case "03":
						temp += " UN";
						break;
					case "04":
						temp += " TON";
						break;
					default:
						temp += " UN";
						break;
				}

				switch (i)
				{
					case 0:
						qtd_1 = temp;
						break;
					case 1:
						qtd_2 = temp;
						break;
					case 2:
						qtd_3 = temp;
						break;
					case 3:
						qtd_4 = temp;
						break;
					case 4:
						qtd_5 = temp;
						break;
				}
			}

			seguradora_nome = string.Empty;
			seguradora_responsavel = string.Empty;
			seguradora_apolice = string.Empty;
			seguradora_averbacao = string.Empty;
			comp_1 = string.Empty;
			comp_2 = string.Empty;
			comp_3 = string.Empty;
			comp_4 = string.Empty;
			comp_5 = string.Empty;
			comp_6 = string.Empty;
			comp_7 = string.Empty;
			comp_8 = string.Empty;
			comp_9 = string.Empty;
			comp_10 = string.Empty;
			comp_11 = string.Empty;
			comp_12 = string.Empty;
			val_1 = 0;
			val_2 = 0;
			val_3 = 0;
			val_4 = 0;
			val_5 = 0;
			val_6 = 0;
			val_7 = 0;
			val_8 = 0;
			val_9 = 0;
			val_10 = 0;
			val_11 = 0;
			val_12 = 0;

			for (int i = 0; i < ds.Tables["Comp"].Rows.Count; i++)
			{
				switch (i)
				{
					case 0:
						comp_1 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_1 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 1:
						comp_2 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_2 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 2:
						comp_3 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_3 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 3:
						comp_4 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_4 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 4:
						comp_5 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_5 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 5:
						comp_6 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_6 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 6:
						comp_7 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_7 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 7:
						comp_8 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_8 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 8:
						comp_9 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_9 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 9:
						comp_10 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_10 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 10:
						comp_11 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_11 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;

					case 11:
						comp_12 = ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("xNome")].ToString();
						val_12 = double.Parse(ds.Tables["Comp"].Rows[i].ItemArray[ds.Tables["Comp"].Columns.IndexOf("vComp")].ToString());
						break;
				}
			}

			chave_acesso = ds.Tables["infProt"].Rows[0].ItemArray[2].ToString();
			chave_acessof = Util.Formata(ds.Tables["infProt"].Rows[0].ItemArray[2].ToString(), "00.0000.00.000.000/0000-00-00-000-000.000.000-000.000.000-0");
			val_total_servico = double.Parse(ds.Tables["vPrest"].Rows[0].ItemArray[ds.Tables["vPrest"].Columns.IndexOf("vTPrest")].ToString());
			val_total_receber = double.Parse(ds.Tables["vPrest"].Rows[0].ItemArray[ds.Tables["vPrest"].Columns.IndexOf("vRec")].ToString());
			situacao_tributaria = ds.Tables["CST00"].Rows[0].ItemArray[ds.Tables["CST00"].Columns.IndexOf("CST")].ToString();
			bc_icms = double.Parse(ds.Tables["CST00"].Rows[0].ItemArray[ds.Tables["CST00"].Columns.IndexOf("vBC")].ToString());
			aliq_icms = double.Parse(ds.Tables["CST00"].Rows[0].ItemArray[ds.Tables["CST00"].Columns.IndexOf("pICMS")].ToString());
			valor_icms = double.Parse(ds.Tables["CST00"].Rows[0].ItemArray[ds.Tables["CST00"].Columns.IndexOf("vICMS")].ToString());
			red_bc_calc = 0; //TODO Continuar o CTe daqui
			icms_st = 0;
			obs1 = string.Empty;
			obs2 = string.Empty;
			obs3 = string.Empty;

			report.ParameterFields["modal"].CurrentValues.AddValue(modal);
			report.ParameterFields["emitente_endereco"].CurrentValues.AddValue(emitente_endereco);
			report.ParameterFields["emitente_cnpj"].CurrentValues.AddValue(emitente_cnpj);
			report.ParameterFields["emitente_ie"].CurrentValues.AddValue(emitente_ie);
			report.ParameterFields["emitente_telefone"].CurrentValues.AddValue(emitente_telefone);
			report.ParameterFields["modelo"].CurrentValues.AddValue(modelo);
			report.ParameterFields["serie"].CurrentValues.AddValue(serie);
			report.ParameterFields["numero"].CurrentValues.AddValue(numero);
			report.ParameterFields["fl"].CurrentValues.AddValue(fl);
			report.ParameterFields["data_hora_emissao"].CurrentValues.AddValue(data_hora_emissao);
			report.ParameterFields["tipo_cte"].CurrentValues.AddValue(tipo_cte);
			report.ParameterFields["tipo_servico"].CurrentValues.AddValue(tipo_servico);
			report.ParameterFields["tomador_servico"].CurrentValues.AddValue(tomador_servico);
			report.ParameterFields["forma_pagamento"].CurrentValues.AddValue(forma_pagamento);
			report.ParameterFields["protocolo"].CurrentValues.AddValue(protocolo);
			report.ParameterFields["insc_suframa_destinatario"].CurrentValues.AddValue(insc_suframa_destinatario);
			report.ParameterFields["cfop"].CurrentValues.AddValue(cfop);
			report.ParameterFields["origem_prestacao"].CurrentValues.AddValue(origem_prestacao);
			report.ParameterFields["destino_prestacao"].CurrentValues.AddValue(destino_prestacao);
			report.ParameterFields["remetente"].CurrentValues.AddValue(remetente);
			report.ParameterFields["remetente_endereco"].CurrentValues.AddValue(remetente_endereco);
			report.ParameterFields["remetente_municipio"].CurrentValues.AddValue(remetente_municipio);
			report.ParameterFields["remetente_doc"].CurrentValues.AddValue(remetente_doc);
			report.ParameterFields["remetente_pais"].CurrentValues.AddValue(remetente_pais);
			report.ParameterFields["remetente_cep"].CurrentValues.AddValue(remetente_cep);
			report.ParameterFields["remetente_ie"].CurrentValues.AddValue(remetente_ie);
			report.ParameterFields["remetente_fone"].CurrentValues.AddValue(remetente_fone);
			report.ParameterFields["destinatario"].CurrentValues.AddValue(destinatario);
			report.ParameterFields["destinatario_endereco"].CurrentValues.AddValue(destinatario_endereco);
			report.ParameterFields["destinatario_municipio"].CurrentValues.AddValue(destinatario_municipio);
			report.ParameterFields["destinatario_doc"].CurrentValues.AddValue(destinatario_doc);
			report.ParameterFields["destinatario_pais"].CurrentValues.AddValue(destinatario_pais);
			report.ParameterFields["destinatario_cep"].CurrentValues.AddValue(destinatario_cep);
			report.ParameterFields["destinatario_ie"].CurrentValues.AddValue(destinatario_ie);
			report.ParameterFields["destinatario_fone"].CurrentValues.AddValue(destinatario_fone);
			report.ParameterFields["expeditor"].CurrentValues.AddValue(expeditor);
			report.ParameterFields["expeditor_endereco"].CurrentValues.AddValue(expeditor_endereco);
			report.ParameterFields["expeditor_municipio"].CurrentValues.AddValue(expeditor_municipio);
			report.ParameterFields["expeditor_doc"].CurrentValues.AddValue(expeditor_doc);
			report.ParameterFields["expeditor_pais"].CurrentValues.AddValue(expeditor_pais);
			report.ParameterFields["expeditor_cep"].CurrentValues.AddValue(expeditor_cep);
			report.ParameterFields["expeditor_ie"].CurrentValues.AddValue(expeditor_ie);
			report.ParameterFields["expeditor_fone"].CurrentValues.AddValue(expeditor_fone);
			report.ParameterFields["recebedor"].CurrentValues.AddValue(recebedor);
			report.ParameterFields["recebedor_endereco"].CurrentValues.AddValue(recebedor_endereco);
			report.ParameterFields["recebedor_municipio"].CurrentValues.AddValue(recebedor_municipio);
			report.ParameterFields["recebedor_doc"].CurrentValues.AddValue(recebedor_doc);
			report.ParameterFields["recebedor_pais"].CurrentValues.AddValue(recebedor_pais);
			report.ParameterFields["recebedor_cep"].CurrentValues.AddValue(recebedor_cep);
			report.ParameterFields["recebedor_ie"].CurrentValues.AddValue(recebedor_ie);
			report.ParameterFields["recebedor_fone"].CurrentValues.AddValue(recebedor_fone);

			report.ParameterFields["tomador_servico2"].CurrentValues.AddValue(tomador_servico2);
			report.ParameterFields["tomador_municipio"].CurrentValues.AddValue(tomador_municipio);
			report.ParameterFields["tomador_uf"].CurrentValues.AddValue(tomador_uf);
			report.ParameterFields["tomador_cep"].CurrentValues.AddValue(tomador_cep);
			report.ParameterFields["tomador_endereco"].CurrentValues.AddValue(tomador_endereco);
			report.ParameterFields["tomador_pais"].CurrentValues.AddValue(tomador_pais);
			report.ParameterFields["tomador_doc"].CurrentValues.AddValue(tomador_doc);
			report.ParameterFields["tomador_ie"].CurrentValues.AddValue(tomador_ie);
			report.ParameterFields["tomador_fone"].CurrentValues.AddValue(tomador_fone);
			report.ParameterFields["produto_predominante"].CurrentValues.AddValue(produto_predominante);
			report.ParameterFields["outras_caracteristicas_carga"].CurrentValues.AddValue(outras_caracteristicas_carga);
			report.ParameterFields["valor_total_mercadoria"].CurrentValues.AddValue(valor_total_mercadoria);
			report.ParameterFields["qtd_1"].CurrentValues.AddValue(qtd_1);
			report.ParameterFields["qtd_2"].CurrentValues.AddValue(qtd_2);
			report.ParameterFields["qtd_3"].CurrentValues.AddValue(qtd_3);
			report.ParameterFields["qtd_4"].CurrentValues.AddValue(qtd_4);
			report.ParameterFields["qtd_5"].CurrentValues.AddValue(qtd_5);
			report.ParameterFields["seguradora_nome"].CurrentValues.AddValue(seguradora_nome);
			report.ParameterFields["seguradora_responsavel"].CurrentValues.AddValue(seguradora_responsavel);
			report.ParameterFields["seguradora_apolice"].CurrentValues.AddValue(seguradora_apolice);
			report.ParameterFields["seguradora_averbacao"].CurrentValues.AddValue(seguradora_averbacao);
			report.ParameterFields["comp_1"].CurrentValues.AddValue(comp_1);
			report.ParameterFields["comp_2"].CurrentValues.AddValue(comp_2);
			report.ParameterFields["comp_3"].CurrentValues.AddValue(comp_3);
			report.ParameterFields["comp_4"].CurrentValues.AddValue(comp_4);
			report.ParameterFields["comp_5"].CurrentValues.AddValue(comp_5);
			report.ParameterFields["comp_6"].CurrentValues.AddValue(comp_6);
			report.ParameterFields["comp_7"].CurrentValues.AddValue(comp_7);
			report.ParameterFields["comp_8"].CurrentValues.AddValue(comp_8);
			report.ParameterFields["comp_9"].CurrentValues.AddValue(comp_9);
			report.ParameterFields["comp_10"].CurrentValues.AddValue(comp_10);
			report.ParameterFields["comp_11"].CurrentValues.AddValue(comp_11);
			report.ParameterFields["comp_12"].CurrentValues.AddValue(comp_12);
			report.ParameterFields["val_1"].CurrentValues.AddValue(val_1);
			report.ParameterFields["val_2"].CurrentValues.AddValue(val_2);
			report.ParameterFields["val_3"].CurrentValues.AddValue(val_3);
			report.ParameterFields["val_4"].CurrentValues.AddValue(val_4);
			report.ParameterFields["val_5"].CurrentValues.AddValue(val_5);
			report.ParameterFields["val_6"].CurrentValues.AddValue(val_6);
			report.ParameterFields["val_7"].CurrentValues.AddValue(val_7);
			report.ParameterFields["val_8"].CurrentValues.AddValue(val_8);
			report.ParameterFields["val_9"].CurrentValues.AddValue(val_9);
			report.ParameterFields["val_10"].CurrentValues.AddValue(val_10);
			report.ParameterFields["val_11"].CurrentValues.AddValue(val_11);
			report.ParameterFields["val_12"].CurrentValues.AddValue(val_12);
			report.ParameterFields["chave_acesso"].CurrentValues.AddValue(chave_acesso);
			report.ParameterFields["chave_acessof"].CurrentValues.AddValue(chave_acessof);
			report.ParameterFields["val_total_servico"].CurrentValues.AddValue(val_total_servico);
			report.ParameterFields["val_total_receber"].CurrentValues.AddValue(val_total_receber);
			report.ParameterFields["situacao_tributaria"].CurrentValues.AddValue(situacao_tributaria);
			report.ParameterFields["bc_icms"].CurrentValues.AddValue(bc_icms);
			report.ParameterFields["aliq_icms"].CurrentValues.AddValue(aliq_icms);
			report.ParameterFields["valor_icms"].CurrentValues.AddValue(valor_icms);
			report.ParameterFields["red_bc_calc"].CurrentValues.AddValue(red_bc_calc);
			report.ParameterFields["icms_st"].CurrentValues.AddValue(icms_st);
			report.ParameterFields["obs1"].CurrentValues.AddValue(obs1);
			report.ParameterFields["obs2"].CurrentValues.AddValue(obs2);
			report.ParameterFields["obs3"].CurrentValues.AddValue(obs3);

			//form.crystalReportViewer1.ReportSource = report;

			form.Show();
			*/
			return true;
		}

		public static string Serializar<T>(T objeto)
		{
			XElement xml = null;

			try
			{
				XmlSerializer ser = new XmlSerializer(typeof(T));

				using (MemoryStream memory = new MemoryStream())
				{
					using (TextReader tr = new StreamReader(memory, Encoding.UTF8))
					{
						ser.Serialize(memory, objeto);
						memory.Position = 0;
						xml = XElement.Load(tr);
						xml.Attributes().Where(x => x.Name.LocalName.Equals("xsd") || x.Name.LocalName.Equals("xsi")).Remove();
					}
				}
			}
			catch
			{
				throw;
			}

			return xml.ToString();
		}

		/*
		 *	usuario-477190283
			senha x8p2ztxs9m
		*/
		public static string ServicoAtivo()
		{
			try
			{
				string nome;

				DataSet ds = new DataSet();

				ds.ReadXmlSchema(Preferencias.SchemaStatusServico);

				ds.DataSetName = "consStatServ";

				DataRow dr = ds.Tables["consStatServCTe"].NewRow();

				dr["versao"] = "1.03";
				dr["tpAmb"] = "2"; // Homologação
				dr["xServ"] = "STATUS";

				ds.Tables["consStatServCTe"].Rows.Add(dr);

				XmlWriterSettings writerSett = new XmlWriterSettings();
				writerSett.Indent = true;
				writerSett.IndentChars = "\t";
				//writerSett.CheckCharacters = true;
				writerSett.Encoding = Encoding.UTF8;
				writerSett.ConformanceLevel = ConformanceLevel.Document;

				nome = DateTime.Now.ToString("yyyyMMdd") + "T" + DateTime.Now.ToString("HHmmss") + "-ped-sta.xml";

				XmlWriter xmlWriter = XmlWriter.Create(Preferencias.PastaCTe + nome, writerSett);

				XmlDocument xmlDoc = new XmlDocument();

				xmlDoc.LoadXml(ds.GetXml());

				xmlDoc.FirstChild.WriteContentTo(xmlWriter);

				xmlWriter.Flush();

				return nome;

				/*
				XmlDocument xmlDoc = new XmlDocument();

				xmlDoc.LoadXml(ds.GetXml());

				HCteStatusServico.cteCabecMsg cab = new DSoft_Delivery.HCteStatusServico.cteCabecMsg();

				cab.versaoDados = "1.03";
				cab.cUF = "51"; //SP

				X509Store store = new X509Store("My", StoreLocation.CurrentUser);
				store.Open(OpenFlags.OpenExistingOnly);
				X509Certificate2 certificado = store.Certificates[0];

				// Assinamos o xml
				SignedXml signedXml = new SignedXml(xmlDoc);
				System.Security.Cryptography.RSACryptoServiceProvider key = new System.Security.Cryptography.RSACryptoServiceProvider();

				signedXml.SigningKey = key;// certificado.PrivateKey;

				Reference reference = new Reference();

				XmlAttributeCollection uri = xmlDoc.DocumentElement.Attributes;

				foreach (XmlAttribute atributo in uri)
				{
					reference.Uri = "#" + atributo.InnerText;
				}

				XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
				reference.AddTransform(env);

				XmlDsigExcC14NTransform c14 = new XmlDsigExcC14NTransform();
				reference.AddTransform(c14);

				signedXml.AddReference(reference);

				KeyInfo keyInfo = new KeyInfo();
				keyInfo.AddClause(new KeyInfoX509Data(certificado));

				signedXml.KeyInfo = keyInfo;

				signedXml.ComputeSignature();

				XmlElement digitalSignature = signedXml.GetXml();

				xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(digitalSignature, true));

				HCteStatusServico.CteStatusServicoSoap12Client client = new DSoft_Delivery.HCteStatusServico.CteStatusServicoSoap12Client();

				client.ClientCredentials.ClientCertificate.SetCertificate(certificado.SubjectName.Name, StoreLocation.CurrentUser, StoreName.My);
				client.ClientCredentials.ClientCertificate.Certificate = certificado;
				client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(certificado.SubjectName.Name, StoreLocation.CurrentUser, StoreName.My);
				client.ClientCredentials.UserName.UserName = "477190283";
				client.ClientCredentials.UserName.Password = "x8p2ztxs9m";

				client.Open();

				client.cteStatusServicoCT(ref cab, xmlDoc);

				client.Open();

				return true;*/
			}
			catch (System.Security.Cryptography.CryptographicException ce)
			{
				MessageBox.Show(ce.Message, "CTe", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + Environment.NewLine
					+ e.Data + Environment.NewLine
					+ e.Source + Environment.NewLine
					+ e.HelpLink + Environment.NewLine
					+ e.InnerException + Environment.NewLine
					+ e.StackTrace + Environment.NewLine
					+ e.TargetSite, "DSoft CTe", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return string.Empty;
			}
		}

		public static bool VerificarServico(string nome, ref string msg)
		{
			//20101202T131323-ped-sta.xml
			string arquivo = nome.Remove(15, 4);
			string erro = arquivo.Remove(20, 3) + "err";

			if (File.Exists(Preferencias.PastaCteRetorno + erro))
			{
				msg = "Erro!";

				return true;
			}

			if (!File.Exists(Preferencias.PastaCteRetorno + arquivo))
			{
				msg = "Aguardando retorno..";

				return false;
			}

			if (File.ReadAllText(Preferencias.PastaCteRetorno + nome).Substring(0, 5) == "<?xml")
			{
				msg = "Ok!";

				return true;
			}

			return true;
		}

		public bool CancelarCTe(string emitente, string cte, string protocolo, string motivo)
		{
			CTe.cancCTe canc = new CTe.cancCTe();

			canc.versao = "1.04";

			canc.infCanc.Id = "ID" + cte;
			canc.infCanc.chCTe = cte;
			canc.infCanc.nProt = protocolo;
			canc.infCanc.tpAmb = "1";
			canc.infCanc.xJust = motivo;
			canc.infCanc.xServ = "CANCELAR";

			string serializado = Serializar<CTe.cancCTe>(canc);

			StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + cte + "-ped-can.xml");
			writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
			writer.Flush();
			writer.Close();

			return true;
		}

		public bool CancelarCTe200(string emitente, string cte, string protocolo, string motivo)
		{
			CTe.eventoCTe evento = new CTe.eventoCTe();
			evento.versao = "2.00";

			evento.infEvento.Id = string.Format("ID110111{0}01", cte);
			evento.infEvento.cOrgao = "35";
			evento.infEvento.tpAmb = "1";
			evento.infEvento.CNPJ = Util.LimpaFormatacao(emitente);
			evento.infEvento.chCTe = cte;
			evento.infEvento.dhEvento = DateTime.Now.ToString(DATETIME_FORMAT);
			evento.infEvento.tpEvento = "110111";
			evento.infEvento.nSeqEvento = "1";

			evento.infEvento.detEvento.versaoEvento = "2.00";
			evento.infEvento.detEvento.evCancCTe = new CTe.evCancCTe();
			evento.infEvento.detEvento.evCancCTe.xJust = motivo;
			evento.infEvento.detEvento.evCancCTe.nProt = protocolo;
			evento.infEvento.detEvento.evCancCTe.descEvento = "Cancelamento";

			string serializado = Serializar<CTe.eventoCTe>(evento);

			StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + cte + "-ped-eve.xml");
			writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
			writer.Flush();
			writer.Close();

			return true;
		}

		public bool CorrecaoCTe(string emitente, string cte, string procotolo, List<string[]> correcoes, int seqEvento)
		{
			CTe.eventoCTe evento = new CTe.eventoCTe();
			evento.versao = "2.00";

			evento.infEvento.cOrgao = "35";
			evento.infEvento.tpAmb = "1";
			evento.infEvento.CNPJ = Util.LimpaFormatacao(emitente);
			evento.infEvento.chCTe = cte;
			evento.infEvento.dhEvento = DateTime.Now.ToString(DATETIME_FORMAT);
			evento.infEvento.nSeqEvento = seqEvento.ToString();

			if (correcoes == null || correcoes.Count == 0)
			{
				return false;
			}

			evento.infEvento.detEvento.evCCeCTe = new CTe.evCCeCTe();

			foreach (string[] c in correcoes)
			{
				CTe.infCorrecao correcao = new CTe.infCorrecao();
				correcao.grupoAlterado = c[0];
				correcao.campoAlterado = c[1];
				correcao.valorAlterado = c[2];

				evento.infEvento.detEvento.evCCeCTe.infCorrecao.Add(correcao);
			}

			string serializado = Serializar<CTe.eventoCTe>(evento);

			StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + cte + "-ped-eve.xml");
			writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
			writer.Flush();
			writer.Close();

			return true;
		}

		public bool Gerar(OrdemDeColeta ordem, Bd bd, Usuario usuario)
		{
			try
			{
				// A chave é composta pelos seguintes campos:
				// cUf [2]
				// AAMM [4]
				// CNPJ [14]
				// Modelo [2]
				// Serie [3]
				// Numero do CTe [9]
				// Código Numérico [9]
				// DV [1]
				// 3510100509809300023357000123456789987654321
				string ct = bd.NovaChaveCTe(usuario.Autorizado);
				string rnd = Util.Randomico(8);
				string chave = string.Empty;
				string dv;

				chave = bd.CodigoEstado(ordem.Emitente.Uf.Substring(0, 2)).ToString("00");
				chave += (ordem.Data.Year % 100).ToString("00") + ordem.Data.Month.ToString("00");
				chave += ordem.Emitente.Cnpj.ToString("00000000000000");
				chave += "57"; // Modelo
				chave += "000"; // Série
				chave += ct.Trim();
				chave += "1"; // Tipo de Emissão
				chave += rnd;
				dv = Util.Modulo11(chave);
				chave += dv;

				DataSet ds = new DataSet();

				XmlWriterSettings writerSett = new XmlWriterSettings();
				writerSett.Indent = true;
				writerSett.IndentChars = "\t";
				//writerSett.CheckCharacters = true;
				writerSett.Encoding = Encoding.UTF8;
				writerSett.ConformanceLevel = ConformanceLevel.Document;

				XmlWriter xmlWriter = XmlWriter.Create(Preferencias.PastaCTe + "\\" + chave + "-cte.xml", writerSett);

				ds.ReadXmlSchema(Preferencias.SchemaCTe);

				ds.DataSetName = "CTe_";

				// Tabela 'CTe'
				DataRow drCTe = ds.Tables["CTe"].NewRow();

				ds.Tables["CTe"].Rows.Add(drCTe);

				// Tabela 'infCTe'
				DataRow drInfCTe = ds.Tables["infCTe"].NewRow();

				drInfCTe["id"] = "CTe" + chave.Trim();
				drInfCTe["versao"] = "2.00";
				drInfCTe["CTe_Id"] = drCTe["CTe_Id"];

				ds.Tables["infCTe"].Rows.Add(drInfCTe);

				// Tabela 'ide'
				DataRow drIde = ds.Tables["ide"].NewRow();

				drIde["cUF"] = bd.CodigoEstado(ordem.Emitente.Uf.Substring(0, 2));		// Código do estado do emitente. Seguir tabela do IBGE
				drIde["cCT"] = rnd;													// Código numérico gerado pelo emitente para identificar cada CTe para evitar acessos indevidos.
				drIde["CFOP"] = ordem.CFOP;												// Código fiscal de operações e prestações.
				drIde["natOp"] = ordem.NaturezaDaOperacao;								// Natureza da operação
				drIde["forPag"] = (ordem.Pago ? 0 : 1);									// Forma de pagamento. 0-Pago, 1-A pagar, 2-Outros
				drIde["mod"] = 57;														// Modelo do documento fiscal.
				drIde["serie"] = 0;														// Série do CT-e.
				drIde["nCT"] = int.Parse(ct);														// Número do CT-e.
				drIde["dhEmi"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");			// Data e hora da emissão
				drIde["tpImp"] = 1;														// Forma de impressão. 1-Retrato, 2-Paisagem.
				drIde["tpEmis"] = 1;													// Forma de emissão do CT-e. 1-Normal, 2-Contingencia.
				drIde["cDV"] = dv;														// Digito verificador da chave de acesso do CT-e. Deve ser calculado usando o algoritmo módulo 11 (base 2,9)
				drIde["tpAmb"] = 2;														// Tipo de ambiente. 1-Producao, 2-Homologação.
				drIde["tpCTe"] = 0;														// Tipo de CT-e. 0-Normal, 1-Complemento de valores, 2-Anulação de valores, 3-Substituto.
				drIde["procEmi"] = 0;													// Processo de emissão do CTe. 0-Software do emitente, 1-Avulsa pelo fisco, 2-Avulsa pelo emitente no site, 3-Pelo emitente pelo software do fisco.
				drIde["verProc"] = "1.0";												// Versão do software emissor.
				//drIde["refCTe"] = "99999999999999999999999999999999999999999999";		// Chave de acesso do CT-e referenciado.
				drIde["cMunEnv"] = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));		// Código do município emissor. Utilizar tabela do IBGE.
				drIde["xMunEnv"] = ordem.Emitente.Municipio;							// Nome do município emissor.
				drIde["UFEnv"] = ordem.Emitente.Uf.Substring(0, 2);						// Sigla do UF emissor.
				drIde["modal"] = "01";													// Modal. 01-Rodoviario, 02-Aereo, 03-Aquaviario, 04-Ferroviario, 05-Dutoviario.
				drIde["tpServ"] = 0;													// Tipo de serviço. 0-Normal, 1-Subcontratação, 2-Redespacho, 3-Redespacho intermediário.
				drIde["cMunIni"] = bd.CodigoMunicipio(ordem.Remetente.Cidade, ordem.Remetente.Estado.Substring(0, 2));			// Código de município do início da prestação.
				drIde["xMunIni"] = ordem.Remetente.Cidade;								// Nome do município do início da prestação.
				drIde["UFIni"] = ordem.Remetente.Estado.Substring(0, 2);				// Sigla do UF do início da prestação.
				drIde["cMunFim"] = bd.CodigoMunicipio(ordem.Destinatario.Cidade, ordem.Destinatario.Estado.Substring(0, 2));		// Código do município do término da prestação.
				drIde["xMunFim"] = ordem.Destinatario.Cidade;							// Nome do município do término da prestação.
				drIde["UFFim"] = ordem.Destinatario.Estado.Substring(0, 2);				// UF do término da prestação.
				drIde["retira"] = 1;													// Indica se o recebedor retira a mercadoria. 0-sim, 1-não.
				//drIde["xDetRetira"] = "";												// Detalhes da retirada.
				drIde["dhCont"] = "";													// Data e hora da entrada em contingência. AAAA-MM-DDTHH:MM:SS
				drIde["xJust"] = "";

				drIde["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["ide"].Rows.Add(drIde);

				// Tabela 'toma03'
				DataRow drToma03 = ds.Tables["toma03"].NewRow();

				if (ordem.Pago)
				{
					drToma03["toma"] = 0;													// Tomador do serviço. 0-Remetente, 1-Expeditor, 2-Recebedor, 3-Destinatário.
				}
				else
				{
					drToma03["toma"] = 3;
				}

				drToma03["ide_Id"] = drIde["ide_Id"];

				ds.Tables["toma03"].Rows.Add(drToma03);

				// Tabela 'compl'
				//DataRow drCompl = ds.Tables["compl"].NewRow();

				// Tabela 'emit'
				DataRow drEmit = ds.Tables["emit"].NewRow();

				drEmit["CNPJ"] = ordem.Emitente.Cnpj.ToString("00000000000000");

				if (ordem.Emitente.InscricaoEstadual == "ISENTO")
				{
					drEmit["IE"] = "ISENTO";
				}
				else
				{
					drEmit["IE"] = Util.LimpaFormatacao(ordem.Emitente.InscricaoEstadual);
				}

				drEmit["xNome"] = ordem.Emitente.RazaoSocial;
				drEmit["xFant"] = ordem.Emitente.NomeFantasia;
				drEmit["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["emit"].Rows.Add(drEmit);

				// Tabela 'enderEmit'
				DataRow drEnderEmit = ds.Tables["enderEmit"].NewRow();

				drEnderEmit["xLgr"] = ordem.Emitente.Logradouro.Trim();
				drEnderEmit["nro"] = ordem.Emitente.Numero;
				drEnderEmit["xCpl"] = (ordem.Emitente.Complemento.Length > 0 ? ordem.Emitente.Complemento : "-");
				drEnderEmit["xBairro"] = ordem.Emitente.Bairro;
				drEnderEmit["cMun"] = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));		// Utilizar tabela do IBGE
				drEnderEmit["xMun"] = ordem.Emitente.Municipio;
				drEnderEmit["CEP"] = Util.LimpaFormatacao(ordem.Emitente.Cep);
				drEnderEmit["UF"] = ordem.Emitente.Uf.Substring(0, 2);
				//drEnderEmit["cPais"] = ;					// Utilizar tabela do BACEN
				//drEnderEmit["xPais"] = ordem.Emitente.Pais;
				drEnderEmit["fone"] = Util.LimpaFormatacao(ordem.Emitente.Telefone);
				drEnderEmit["emit_Id"] = drEmit["emit_Id"];

				ds.Tables["enderEmit"].Rows.Add(drEnderEmit);

				// Tabela 'rem'
				DataRow drRem = ds.Tables["rem"].NewRow();

				if (ordem.Remetente.Tipo == 'F')
				{
					//drRem["CNPJ"] = "00000000000000";
					drRem["CPF"] = Util.LimpaFormatacao(ordem.Remetente.Documento);
				}
				else
				{
					drRem["CNPJ"] = Util.LimpaFormatacao(ordem.Remetente.Documento);
					drRem["CPF"] = "";
				}

				if (ordem.Remetente.InscricaoEstadual == "ISENTO")
				{
					drRem["IE"] = "ISENTO";
				}
				else
				{
					drRem["IE"] = Util.LimpaFormatacao(ordem.Remetente.InscricaoEstadual);
				}

				drRem["xNome"] = ordem.Remetente.Nome;
				drRem["xFant"] = ordem.Remetente.Nome;
				drRem["fone"] = ordem.Remetente.Telefone1.ToString();
				drRem["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["rem"].Rows.Add(drRem);

				// Tabela 'enderRem'
				DataRow drEnderReme = ds.Tables["enderReme"].NewRow();

				drEnderReme["xLgr"] = ordem.Remetente.Endereco.Trim();
				drEnderReme["nro"] = ordem.Remetente.Numero;
				drEnderReme["xCpl"] = (ordem.Remetente.Complemento.Length > 0 ? ordem.Remetente.Complemento : "-");
				drEnderReme["xBairro"] = ordem.Remetente.Bairro;
				drEnderReme["cMun"] = bd.CodigoMunicipio(ordem.Remetente.Cidade, ordem.Remetente.Estado.Substring(0, 2));		// Utilizar tabela do IBGE
				drEnderReme["xMun"] = ordem.Remetente.Cidade;
				drEnderReme["CEP"] = Util.LimpaFormatacao(ordem.Remetente.Cep);
				drEnderReme["UF"] = (ordem.Remetente.Estado.Length > 2 ? ordem.Remetente.Estado.Substring(0, 2) : ordem.Remetente.Estado);
				//drEnderReme["cPais"] = ;												// Utilizar tabela BACEN
				drEnderReme["xPais"] = ordem.Remetente.Pais;
				drEnderReme["rem_Id"] = drRem["rem_Id"];

				ds.Tables["enderReme"].Rows.Add(drEnderReme);

				// Tabela 'infCTeNorm'
				DataRow drInfCTeNorm = ds.Tables["infCTeNorm"].NewRow();

				drInfCTeNorm["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["infCTeNorm"].Rows.Add(drInfCTeNorm);

				// Tabela 'infCarga'
				DataRow drInfCarga = ds.Tables["infCarga"].NewRow();

				//drInfCarga["vMerc"] = Util.Formata2(ordem.ValorMercadoria);		// Valor total da mercadoria
				drInfCarga["proPred"] = ordem.ProdudoPredominante;						// Descrição do produto predominante da carga
				drInfCarga["xOutCat"] = ordem.OutrasCaracteristicas;					// Outras características da carga
				drInfCarga["vCarga"] = ordem.ValorMercadoria.ToString("");
				drInfCarga["infCTeNorm_Id"] = drInfCTeNorm["infCTeNorm_Id"];

				ds.Tables["infCarga"].Rows.Add(drInfCarga);

				for (int i = 0; i < ordem.Quantidade.Length; i++)
				{
					if (ordem.Quantidade[i] > 0)
					{
						DataRow drInfQ = ds.Tables["infQ"].NewRow();

						switch (ordem.UnidadeMedida[i])
						{
							case "M3":
								drInfQ["cUnid"] = "00";
								break;
							case "KG":
								drInfQ["cUnid"] = "01";
								break;
							case "TON":
								drInfQ["cUnid"] = "02";
								break;
							case "UNIDADE":
								drInfQ["cUnid"] = "03";
								break;
							case "LITROS":
								drInfQ["cUnid"] = "04";
								break;
							default:
								drInfQ["cUnid"] = "03";
								break;
						}

						drInfQ["tpMed"] = ordem.TipoMedida[i];
						drInfQ["qCarga"] = ordem.Quantidade[i].ToString();
						drInfQ["infCarga_Id"] = drInfCarga["infCarga_Id"];

						ds.Tables["infQ"].Rows.Add(drInfQ);
					}
				}

				// infDoc
				//DataRow drInfDoc = ds.Tables["infDoc"].NewRow();

				//drInfDoc["infCTeNorm_Id"] = drInfCTeNorm["infCTeNorm_Id"];

				//ds.Tables["infDoc"].Rows.Add(drInfDoc);

				// Tabela 'infNF' Deve ser informado quando o documento originário for Nota Fiscal
				DataRow drInfNF = ds.Tables["infNF"].NewRow();

				drInfNF["nRoma"] = "1";													// Número do romaneio da nota fiscal
				drInfNF["nPed"] = "1";													// Número do pedido da nota fiscal
				drInfNF["serie"] = ordem.DocSerie[0];
				drInfNF["nDoc"] = ordem.DocNota[0];										// Número da nota fiscal
				//drInfNF["dEmi"] = " "; // DateTime.Now.ToString("yyyy-MM-dd");					// Data de emissão em formato YYYY-MM-DD
				//drInfNF["vBC"] = Util.Formata2(ordem.ValorBCICMS);				// Valor de base de cálculo do ICMS
				//drInfNF["vICMS"] = Util.Formata2(ordem.ValorICMS);				// Valor total do ICMS
				//drInfNF["vBCST"] = "0.00";												// Valor de base de cálcuo do ICMS ST
				//drInfNF["vST"] = Util.Formata2(ordem.ICMSST);						// Valor total do ICMS ST
				//drInfNF["vProd"] = Util.Formata2(ordem.ValorMercadoria);			// Valor total dos produtos. Tem de ser '.' e não ','
				//drInfNF["vNF"] = Util.Formata2(ordem.ValorMercadoria);			// Valor total da nota fiscal
				//drInfNF["nCFOP"] = 1234;												// CFOP predominante da nota fiscal
				//drInfNF["nPeso"] = ordem.Peso;										// Peso total em quilos da nota fiscal
				//drInfNF["PIN"] = ;													// PIN SUFRAMA
				drInfNF["mod"] = "01";				// Código do modelo do Documento Fiscal. Utilizar 55 para identificação da NF-e, emitida em substituição ao modelo 1 e 1A.

				drInfNF["Rem_Id"] = drRem["Rem_Id"];

				ds.Tables["infNF"].Rows.Add(drInfNF);

				// NFe
				for (int i = 0; i < ordem.ChaveAcesso.Length; i++)
				{
					if (ordem.ChaveAcesso[i] != string.Empty)
					{
						DataRow drInfNFe = ds.Tables["infNFe"].NewRow();

						drInfNFe["chave"] = ordem.ChaveAcesso[i];
						drInfNFe["rem_Id"] = drRem["rem_Id"];

						ds.Tables["infNFe"].Rows.Add(drInfNFe);
					}
				}

				// Tabela 'exped'
				DataRow drExped = ds.Tables["exped"].NewRow();

				drExped["CNPJ"] = ordem.Emitente.Cnpj.ToString("00000000000000");
				drExped["CPF"] = "";

				if (ordem.Emitente.InscricaoEstadual == "ISENTO")
				{
					drExped["IE"] = "ISENTO";
				}
				else
				{
					drExped["IE"] = Util.LimpaFormatacao(ordem.Emitente.InscricaoEstadual);
				}

				drExped["xNome"] = ordem.Emitente.RazaoSocial;
				drExped["fone"] = Util.LimpaFormatacao(ordem.Emitente.Telefone);
				drExped["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["exped"].Rows.Add(drExped);

				// Tabela 'enderExped'
				DataRow drEnderExped = ds.Tables["enderExped"].NewRow();

				drEnderExped["xLgr"] = ordem.Emitente.Logradouro.Trim();
				drEnderExped["nro"] = ordem.Emitente.Numero;
				drEnderExped["xCpl"] = (ordem.Emitente.Complemento.Length > 0 ? ordem.Emitente.Complemento : "-");
				drEnderExped["xBairro"] = ordem.Emitente.Bairro;
				drEnderExped["cMun"] = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));	// Utilizar tabela do IBGE
				drEnderExped["xMun"] = ordem.Emitente.Municipio;
				drEnderExped["CEP"] = Util.LimpaFormatacao(ordem.Emitente.Cep);
				drEnderExped["UF"] = ordem.Emitente.Uf.Substring(0, 2);
				//drEnderExped["cPais"] = ;												// Utilizar tabela BACEN
				drEnderExped["xPais"] = ordem.Emitente.Pais;
				drEnderExped["exped_Id"] = drExped["exped_Id"];

				ds.Tables["enderExped"].Rows.Add(drEnderExped);

				// Tabela 'dest'
				DataRow drDest = ds.Tables["dest"].NewRow();

				drDest["CNPJ"] = Util.LimpaFormatacao(ordem.Destinatario.Documento);
				drDest["CPF"] = "";

				if (ordem.Destinatario.InscricaoEstadual == "ISENTO")
				{
					drDest["IE"] = "ISENTO";
				}
				else
				{
					drDest["IE"] = Util.LimpaFormatacao(ordem.Destinatario.InscricaoEstadual);
				}

				drDest["xNome"] = ordem.Destinatario.Nome;
				drDest["fone"] = ordem.Destinatario.Telefone1;
				//drDest["ISUF"] = ""; // ??
				drDest["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["dest"].Rows.Add(drDest);

				// Tabela 'enderDest'
				DataRow drEnderDest = ds.Tables["enderDest"].NewRow();

				drEnderDest["xLgr"] = ordem.Destinatario.Endereco.Trim();
				drEnderDest["nro"] = ordem.Destinatario.Numero;
				drEnderDest["xCpl"] = (ordem.Destinatario.Complemento.Length > 0 ? ordem.Destinatario.Complemento : "-");
				drEnderDest["xBairro"] = ordem.Destinatario.Bairro;
				drEnderDest["cMun"] = bd.CodigoMunicipio(ordem.Destinatario.Cidade, ordem.Destinatario.Estado.Substring(0, 2));
				drEnderDest["xMun"] = ordem.Destinatario.Cidade;
				drEnderDest["CEP"] = Util.LimpaFormatacao(ordem.Destinatario.Cep);
				drEnderDest["UF"] = ordem.Destinatario.Estado.Substring(0, 2);
				//drEnderDest["cPais"] = ;
				drEnderDest["xPais"] = ordem.Destinatario.Pais;
				drEnderDest["dest_Id"] = drDest["dest_Id"];

				ds.Tables["enderDest"].Rows.Add(drEnderDest);

				// Tabela 'vPrest'
				DataRow drVPrest = ds.Tables["vPrest"].NewRow();

				drVPrest["vTPrest"] = Util.Formata2(ordem.ValorFrete);			// Valor total da prestação do serviço
				drVPrest["vRec"] = "0.00";												// Valor que falta receber
				drVPrest["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["vPrest"].Rows.Add(drVPrest);

				// Tabela 'Comp'
				for (int i = 0; i < ordem.Componente.Length; i++)
				{
					if (ordem.Componente[i] != string.Empty && ordem.ValorPrestacao[i] > 0)
					{
						DataRow drComp = ds.Tables["Comp"].NewRow();

						drComp["xNome"] = ordem.Componente[i];
						drComp["vComp"] = Util.Formata2(ordem.ValorPrestacao[i]);
						drComp["vPrest_Id"] = drVPrest["vPrest_Id"];

						ds.Tables["Comp"].Rows.Add(drComp);
					}
				}

				// Tabela 'imp'
				DataRow drImp = ds.Tables["imp"].NewRow();

				drImp["infCTe_Id"] = drInfCTe["infCTe_Id"];

				ds.Tables["imp"].Rows.Add(drImp);

				// Tabela 'ICMS'
				DataRow drICMS = ds.Tables["ICMS"].NewRow();

				drICMS["imp_Id"] = drImp["imp_Id"];

				ds.Tables["ICMS"].Rows.Add(drICMS);

				// Tabela 'CST00'
				DataRow drCST00 = ds.Tables["CST00"].NewRow();

				drCST00["CST"] = ordem.CST;												// Classificação tributária do serviço: 00 - tributação normal do ICMS
				drCST00["vBC"] = Util.Formata2(ordem.ValorBCICMS);				// Valor da BC do ICMS
				drCST00["pICMS"] = Util.Formata2(ordem.AliquotaICMS);				// Alíquota do ICMS
				drCST00["vICMS"] = Util.Formata2(ordem.ValorICMS);				// Valor do ICMS
				drCST00["ICMS_Id"] = drICMS["ICMS_Id"];

				ds.Tables["CST00"].Rows.Add(drCST00);

				// Tabela 'CST45'
				//DataRow drCST45 = ds.Tables["CST45"].NewRow();

				//drCST45["CST"] = 40;							// 40 - ICMS isento; 41 - ICMS não tributado; 51 - ICMS diferido
				//drCST45["ICMS_Id"] = drICMS["ICMS_Id"];

				//ds.Tables["CST45"].Rows.Add(drCST45);

				// Tabela 'rodo'
				//DataRow drRodo = ds.Tables["rodo"].NewRow();

				//drRodo["RNTRC"] = ordem.RNTRC;											// Registro Nacional de Transportadores Rodoviários de Cargas
				//drRodo["dPrev"] = ordem.PrevisaoEntrega.ToString("yyyy-MM-dd");			// Previsão de entrega
				//drRodo["lota"] = 0;														// Indicador de lotação. 0 - Não; 1 - Sim
				//drRodo["infCTeNorm_Id"] = drInfCTeNorm["infCTeNorm_Id"];

				//ds.Tables["rodo"].Rows.Add(drRodo);

				ds.Tables["rem"].Columns.Remove("CPF");
				ds.Tables["exped"].Columns.Remove("CPF");
				ds.Tables["dest"].Columns.Remove("CPF");

				if (ordem.DocNota[0] == string.Empty)
				{
					ds.Tables["infNf"].Columns.Remove("serie");
					ds.Tables["infNf"].Columns.Remove("nDoc");
				}

				XmlDocument xmlDoc = new XmlDocument();

				xmlDoc.LoadXml(ds.GetXml());

				xmlDoc.FirstChild.WriteContentTo(xmlWriter);

				xmlWriter.Flush();

				ordem.CTe = chave;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.Data + Environment.NewLine + e.StackTrace, "DSoft CTe", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool GerarCTe(Bd bd, OrdemDeColeta ordem, int usuario)
		{
			try
			{
				// A chave é composta pelos seguintes campos:
				// cUf [2]
				// AAMM [4]
				// CNPJ [14]
				// Modelo [2]
				// Serie [3]
				// Numero do CTe [9]
				// Código Numérico [9]
				// DV [1]
				// 3510100509809300023357000123456789987654321
				string ct = ordem.Indice.ToString("000000000"); //bd.NovaChaveCTe();
				string rnd = Util.Randomico(8);
				string chave = string.Empty;
				string dv;

				chave = bd.CodigoEstado(ordem.Emitente.Uf.Substring(0, 2)).ToString("00");
				chave += (ordem.Data.Year % 100).ToString("00") + ordem.Data.Month.ToString("00");
				chave += ordem.Emitente.Cnpj.ToString("00000000000000");
				chave += "57"; // Modelo
				chave += "001"; // Série
				chave += ct.Trim();
				chave += "1"; // Tipo de Emissão
				chave += rnd;
				dv = Util.Modulo11(chave);
				chave += dv;

				CTe.CTe cte = new CTe.CTe("CTe" + chave.Trim(), "2.00");

				// tabela ide
				cte.infCTe.ide.cUF = bd.CodigoEstado(ordem.Emitente.Uf.Substring(0, 2));		// Código do estado do emitente. Seguir tabela do IBGE
				cte.infCTe.ide.cCT = rnd;														// Código numérico gerado pelo emitente para identificar cada CTe para evitar acessos indevidos.
				cte.infCTe.ide.CFOP = ordem.CFOP;												// Código fiscal de operações e prestações.
				cte.infCTe.ide.natOp = ordem.NaturezaDaOperacao;								// Natureza da operação
				cte.infCTe.ide.forPag = (ordem.Pago ? 0 : 1);									// Forma de pagamento. 0-Pago, 1-A pagar, 2-Outros
				cte.infCTe.ide.mod = 57;														// Modelo do documento fiscal.
				cte.infCTe.ide.serie = "1";														// Série do CT-e.
				cte.infCTe.ide.nCT = int.Parse(ct).ToString();									// Número do CT-e.
				cte.infCTe.ide.dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");			// Data e hora da emissão
				cte.infCTe.ide.tpImp = "1";														// Forma de impressão. 1-Retrato, 2-Paisagem.
				cte.infCTe.ide.tpEmis = "1";													// Forma de emissão do CT-e. 1-Normal, 2-Contingencia.
				cte.infCTe.ide.cDV = dv;														// Digito verificador da chave de acesso do CT-e. Deve ser calculado usando o algoritmo módulo 11 (base 2,9)
				cte.infCTe.ide.tpAmb = "1";														// Tipo de ambiente. 1-Producao, 2-Homologação.
				cte.infCTe.ide.tpCTe = "0";														// Tipo de CT-e. 0-Normal, 1-Complemento de valores, 2-Anulação de valores, 3-Substituto.
				cte.infCTe.ide.procEmi = "0";													// Processo de emissão do CTe. 0-Software do emitente, 1-Avulsa pelo fisco, 2-Avulsa pelo emitente no site, 3-Pelo emitente pelo software do fisco.
				cte.infCTe.ide.verProc = "1.4";													// Versão do software emissor.
				cte.infCTe.ide.cMunEnv = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));			// Código do município emissor. Utilizar tabela do IBGE.
				cte.infCTe.ide.xMunEnv = ordem.Emitente.Municipio;								// Nome do município emissor.
				cte.infCTe.ide.UFEnv = ordem.Emitente.Uf.Substring(0, 2);						// Sigla do UF emissor.
				cte.infCTe.ide.modal = "01";													// Modal. 01-Rodoviario, 02-Aereo, 03-Aquaviario, 04-Ferroviario, 05-Dutoviario.
				cte.infCTe.ide.tpServ = "0";													// Tipo de serviço. 0-Normal, 1-Subcontratação, 2-Redespacho, 3-Redespacho intermediário.
				cte.infCTe.ide.cMunIni = bd.CodigoMunicipio(ordem.Remetente.Cidade, ordem.Remetente.Estado.Substring(0, 2));			// Código de município do início da prestação.
				cte.infCTe.ide.xMunIni = ordem.Remetente.Cidade;								// Nome do município do início da prestação.
				cte.infCTe.ide.UFIni = ordem.Remetente.Estado.Substring(0, 2);					// Sigla do UF do início da prestação.
				cte.infCTe.ide.cMunFim = bd.CodigoMunicipio(ordem.Destinatario.Cidade, ordem.Destinatario.Estado.Substring(0, 2));			// Código do município do término da prestação.
				cte.infCTe.ide.xMunFim = ordem.Destinatario.Cidade;								// Nome do município do término da prestação.
				cte.infCTe.ide.UFFim = ordem.Destinatario.Estado.Substring(0, 2);				// UF do término da prestação.
				cte.infCTe.ide.retira = "1";													// Indica se o recebedor retira a mercadoria. 0-sim, 1-não.

				// tabela toma03
				if (ordem.Pago)
				{
					cte.infCTe.ide.toma03.toma = "0";												// Tomador do serviço. 0-Remetente, 1-Expeditor, 2-Recebedor, 3-Destinatário.
				}
				else
				{
					cte.infCTe.ide.toma03.toma = "3";												// Tomador do serviço. 0-Remetente, 1-Expeditor, 2-Recebedor, 3-Destinatário.
				}

				// tabela emit
				cte.infCTe.emit.CNPJ = ordem.Emitente.Cnpj.ToString("00000000000000");

				if (ordem.Emitente.InscricaoEstadual == "ISENTO")
				{
					cte.infCTe.emit.IE = "ISENTO";
				}
				else
				{
					cte.infCTe.emit.IE = Util.LimpaFormatacao(ordem.Emitente.InscricaoEstadual);
				}

				cte.infCTe.emit.xNome = ordem.Emitente.RazaoSocial;
				cte.infCTe.emit.xFant = ordem.Emitente.NomeFantasia;

				// tabela enderEmit
				cte.infCTe.emit.enderEmit.xLgr = ordem.Emitente.Logradouro.Trim();
				cte.infCTe.emit.enderEmit.nro = ordem.Emitente.Numero;
				cte.infCTe.emit.enderEmit.xCpl = (ordem.Emitente.Complemento.Length > 0 ? ordem.Emitente.Complemento : "-");
				cte.infCTe.emit.enderEmit.xBairro = ordem.Emitente.Bairro;
				cte.infCTe.emit.enderEmit.cMun = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));		// Utilizar tabela do IBGE
				cte.infCTe.emit.enderEmit.xMun = ordem.Emitente.Municipio;
				cte.infCTe.emit.enderEmit.CEP = Util.LimpaFormatacao(ordem.Emitente.Cep);
				cte.infCTe.emit.enderEmit.UF = ordem.Emitente.Uf.Substring(0, 2);
				cte.infCTe.emit.enderEmit.fone = Util.LimpaFormatacao(ordem.Emitente.Telefone);

				// tabela rem
				if (ordem.Remetente.Tipo == 'F')
				{
					cte.infCTe.rem.CPF = Util.LimpaFormatacao(ordem.Remetente.Documento);
				}
				else
				{
					cte.infCTe.rem.CNPJ = Util.LimpaFormatacao(ordem.Remetente.Documento);
				}

				if (ordem.Remetente.InscricaoEstadual == "ISENTO")
				{
					cte.infCTe.rem.IE = "ISENTO";
				}
				else
				{
					cte.infCTe.rem.IE = Util.LimpaFormatacao(ordem.Remetente.InscricaoEstadual);
				}

				cte.infCTe.rem.xNome = ordem.Remetente.Nome;
				cte.infCTe.rem.xFant = ordem.Remetente.Nome;
				cte.infCTe.rem.fone = ordem.Remetente.Telefone1.ToString();

				// tabela enderReme
				cte.infCTe.rem.enderReme.xLgr = ordem.Remetente.Endereco.Trim();
				cte.infCTe.rem.enderReme.nro = ordem.Remetente.Numero;
				cte.infCTe.rem.enderReme.xCpl = (ordem.Remetente.Complemento.Length > 0 ? ordem.Remetente.Complemento : "-");
				cte.infCTe.rem.enderReme.xBairro = ordem.Remetente.Bairro;
				cte.infCTe.rem.enderReme.cMun = bd.CodigoMunicipio(ordem.Remetente.Cidade, ordem.Remetente.Estado.Substring(0, 2));		// Utilizar tabela do IBGE
				cte.infCTe.rem.enderReme.xMun = ordem.Remetente.Cidade;
				cte.infCTe.rem.enderReme.CEP = Util.LimpaFormatacao(ordem.Remetente.Cep);
				cte.infCTe.rem.enderReme.UF = (ordem.Remetente.Estado.Length > 2 ? ordem.Remetente.Estado.Substring(0, 2) : ordem.Remetente.Estado);
				cte.infCTe.rem.enderReme.xPais = ordem.Remetente.Pais;

				foreach (string acesso in ordem.ChaveAcesso)
				{
					if (!string.IsNullOrEmpty(acesso))
					{
						DSoft_Delivery.CTe.infNFe infNFe = new CTe.infNFe();

						infNFe.chave = acesso;

						cte.infCTe.infCTeNorm.infDoc.infNFe.Add(infNFe);
					}
				}

				if (cte.infCTe.infCTeNorm.infDoc.infNFe.Count < 1)
				{
					// tabela infNF
					for (int n = 0; n < ordem.DocNota.Length; n++)
					{
						if (ordem.DocNota[n].Length > 0)
						{
							CTe.infNF infNF = new CTe.infNF();

							infNF.nRoma = 1;													// Número do romaneio da nota fiscal
							infNF.nPed = 1;													// Número do pedido da nota fiscal
							infNF.serie = ordem.DocSerie[n].Trim();
							infNF.nDoc = ordem.DocNota[n].Trim();									// Número da nota fiscal
							infNF.mod = "01";												// Código do modelo do Documento Fiscal. Utilizar 55 para identificação da NF-e, emitida em substituição ao modelo 1 e 1A.
							infNF.dEmi = DateTime.Now.ToString(DATE_FORMAT);
							infNF.vBC = Util.Formata2(ordem.ValorBCICMS);				// Valor de base de cálculo do ICMS
							infNF.vICMS = Util.Formata2(ordem.ValorICMS);				// Valor total do ICMS
							infNF.vBCST = "0.00";											// Valor de base de cálcuo do ICMS ST
							infNF.vST = Util.Formata2(ordem.ICMSST);					// Valor total do ICMS ST
							infNF.vProd = Util.Formata2(ordem.ValorMercadoria);		// Valor total dos produtos. Tem de ser '.' e não ','
							infNF.vNF = Util.Formata2(ordem.ValorMercadoria);			// Valor total da nota fiscal
							infNF.nCFOP = "1234";											// CFOP predominante da nota fiscal
							infNF.nPeso = "1";												// Peso total em quilos da nota fiscal

							cte.infCTe.infCTeNorm.infDoc.infNF.Add(infNF);
						}
					}
				}

				// tabela exped
				cte.infCTe.exped.CNPJ = ordem.Emitente.Cnpj.ToString("00000000000000");

				if (ordem.Emitente.InscricaoEstadual == "ISENTO")
				{
					cte.infCTe.exped.IE = "ISENTO";
				}
				else
				{
					cte.infCTe.exped.IE = Util.LimpaFormatacao(ordem.Emitente.InscricaoEstadual);
				}

				cte.infCTe.exped.xNome = ordem.Emitente.RazaoSocial;
				cte.infCTe.exped.fone = Util.LimpaFormatacao(ordem.Emitente.Telefone);

				// tabela enderExped
				cte.infCTe.exped.enderExped.xLgr = ordem.Emitente.Logradouro.Trim();
				cte.infCTe.exped.enderExped.nro = ordem.Emitente.Numero;
				cte.infCTe.exped.enderExped.xCpl = (ordem.Emitente.Complemento.Length > 0 ? ordem.Emitente.Complemento : "-");
				cte.infCTe.exped.enderExped.xBairro = ordem.Emitente.Bairro;
				cte.infCTe.exped.enderExped.cMun = bd.CodigoMunicipio(ordem.Emitente.Municipio, ordem.Emitente.Uf.Substring(0, 2));// Utilizar tabela do IBGE
				cte.infCTe.exped.enderExped.xMun = ordem.Emitente.Municipio;
				cte.infCTe.exped.enderExped.CEP = Util.LimpaFormatacao(ordem.Emitente.Cep);
				cte.infCTe.exped.enderExped.UF = ordem.Emitente.Uf.Substring(0, 2);
				cte.infCTe.exped.enderExped.xPais = ordem.Emitente.Pais;

				// tabela dest
				if (ordem.Destinatario.Tipo == 'F')
				{
					cte.infCTe.dest.CPF = Util.LimpaFormatacao(ordem.Destinatario.Documento);
				}
				else
				{
					cte.infCTe.dest.CNPJ = Util.LimpaFormatacao(ordem.Destinatario.Documento);
				}

				if (ordem.Destinatario.InscricaoEstadual == "ISENTO")
				{
					cte.infCTe.dest.IE = "ISENTO";
				}
				else
				{
					cte.infCTe.dest.IE = Util.LimpaFormatacao(ordem.Destinatario.InscricaoEstadual);
				}

				cte.infCTe.dest.xNome = ordem.Destinatario.Nome;
				cte.infCTe.dest.fone = ordem.Destinatario.Telefone1.ToString();

				// tabela enderDest
				cte.infCTe.dest.enderDest.xLgr = ordem.Destinatario.Endereco.Trim();
				cte.infCTe.dest.enderDest.nro = ordem.Destinatario.Numero;
				cte.infCTe.dest.enderDest.xCpl = (ordem.Destinatario.Complemento.Length > 0 ? ordem.Destinatario.Complemento : "-");
				cte.infCTe.dest.enderDest.xBairro = ordem.Destinatario.Bairro;
				cte.infCTe.dest.enderDest.cMun = bd.CodigoMunicipio(ordem.Destinatario.Cidade, ordem.Destinatario.Estado.Substring(0, 2));
				cte.infCTe.dest.enderDest.xMun = ordem.Destinatario.Cidade;
				cte.infCTe.dest.enderDest.CEP = Util.LimpaFormatacao(ordem.Destinatario.Cep);
				cte.infCTe.dest.enderDest.UF = ordem.Destinatario.Estado.Substring(0, 2);
				cte.infCTe.dest.enderDest.xPais = ordem.Destinatario.Pais;

				// tabela vPrest
				cte.infCTe.vPrest.vTPrest = Util.Formata2(ordem.ValorFrete);			// Valor total da prestação do serviço

				if (ordem.Pago)
				{
					cte.infCTe.vPrest.vRec = "0.00";										// Valor que falta receber
				}
				else
				{
					cte.infCTe.vPrest.vRec = Util.Formata2(ordem.ValorFrete);
				}

				if (ordem.Componente != null)
				{
					cte.infCTe.vPrest.Comp = new List<CTe.Comp>();

					for (int c = 0; c < ordem.Componente.Length; c++)
					{
						if (ordem.Componente[c].Length > 0)
						{
							cte.infCTe.vPrest.Comp.Add(new CTe.Comp() { xNome = ordem.Componente[c], vComp = Util.Formata2(ordem.ValorPrestacao[c]) });
						}
					}
				}

				// tabela 'imp'

				//cte.infCTe.imp.ICMS.ICMS00.CST = ordem.CST;									// Classificação tributária do serviço: 00 - tributação normal do ICMS
				//cte.infCTe.imp.ICMS.ICMS00.vBC = Util.Formata2(ordem.ValorBCICMS);	// Valor da BC do ICMS
				//cte.infCTe.imp.ICMS.ICMS00.pICMS = Util.Formata2(ordem.AliquotaICMS);	// Alíquota do ICMS
				//cte.infCTe.imp.ICMS.ICMS00.vICMS = Util.Formata2(ordem.ValorICMS);	// Valor do ICMS

				//cte.infCTe.imp.ICMS.ICMSSN101.orig = ordem.Origem.ToString();
				//cte.infCTe.imp.ICMS.ICMSSN101.CSOSN = "101";
				//cte.infCTe.imp.ICMS.ICMSSN101.vCredICMSSN = Util.Formata2(ordem.AliquotaICMS);
				//cte.infCTe.imp.ICMS.ICMSSN101.pCredSN = Util.Formata2(ordem.ValorICMS);

				cte.infCTe.imp.ICMS.ICMSSN.indSN = 1; // Indicador de Simples Nacional

				cte.infCTe.imp.vTotTrib = Util.Formata2(ordem.ValorICMS);
				cte.infCTe.imp.infAdFisco = "Informações";

				// tabela infCTeNorm
				// tabela infCarga
				cte.infCTe.infCTeNorm.infCarga.proPred = ordem.ProdudoPredominante.Trim();	// Descrição do produto predominante da carga
				cte.infCTe.infCTeNorm.infCarga.xOutCat = ordem.OutrasCaracteristicas.Trim();// Outras características da carga
				cte.infCTe.infCTeNorm.infCarga.vCarga = Util.Formata2(ordem.ValorMercadoria);

				// tabela infQ
				for (int i = 0; i < ordem.Quantidade.Length; i++)
				{
					CTe.infQ infQ = new CTe.infQ();

					if (ordem.Quantidade[i] > 0)
					{
						switch (ordem.UnidadeMedida[i])
						{
							case "M3":
								infQ.cUnid = "00";
								break;
							case "KG":
								infQ.cUnid = "01";
								break;
							case "TON":
								infQ.cUnid = "02";
								break;
							case "UNIDADE":
								infQ.cUnid = "03";
								break;
							case "LITROS":
								infQ.cUnid = "04";
								break;
							default:
								infQ.cUnid = "03";
								break;
						}

						infQ.tpMed = ordem.TipoMedida[i].Trim();
						infQ.qCarga = ordem.Quantidade[i].ToString("0");//Util.Formata2(ordem.Quantidade[i]);

						cte.infCTe.infCTeNorm.infCarga.infQ.Add(infQ);
					}
				}

				// tabela rodo
				cte.infCTe.infCTeNorm.infModal.versaoModal = "2.00";
				cte.infCTe.infCTeNorm.infModal.rodo.RNTRC = int.Parse(ordem.RNTRC).ToString("00000000");	// Registro Nacional de Transportadores Rodoviários de Cargas
				cte.infCTe.infCTeNorm.infModal.rodo.dPrev = ordem.PrevisaoEntrega.ToString("yyyy-MM-dd"); // Previsão de entrega
				cte.infCTe.infCTeNorm.infModal.rodo.lota = "0";								// Indicador de lotação. 0 - Não; 1 - Sim
				cte.infCTe.infCTeNorm.infModal.rodo.moto.xNome = ordem.Motorista.Nome;
				cte.infCTe.infCTeNorm.infModal.rodo.moto.CPF = bd.RecursoCPF(ordem.Motorista.Codigo);
				cte.infCTe.infCTeNorm.infModal.rodo.veic.placa = ordem.Veiculo.Placa.Remove(3, 1);
				cte.infCTe.infCTeNorm.infModal.rodo.veic.cInt = "1";
				cte.infCTe.infCTeNorm.infModal.rodo.veic.RENAVAM = bd.VeiculoRENAVAM(ordem.Veiculo.Placa);
				cte.infCTe.infCTeNorm.infModal.rodo.veic.tara = "31000"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.capKG = "31000"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.capM3 = "110"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.tpProp = "T"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.tpVeic = "1"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.tpCar = "02"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.tpRod = "06"; //TODO Adicionar no cadastro do veículo
				cte.infCTe.infCTeNorm.infModal.rodo.veic.UF = ordem.Veiculo.Estado.Substring(0, 2); //TODO Adicionar no cadastro do veículo

				// Verificação básica que identifica se o proprietário do veículo é pessoa física ou jurídica
				if (ordem.Veiculo.Cpf.Length <= 11)
				{
					cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.CPF = ordem.Veiculo.Cpf;
				}
				else
				{
					cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.CNPJ = ordem.Veiculo.Cpf;
				}

				cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.xNome = ordem.Veiculo.Proprietario;
				cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.UF = ordem.Veiculo.Estado.Substring(0,2);
				cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.RNTRC = int.Parse(ordem.RNTRC).ToString("00000000");
				cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.IE = "ISENTO";
				cte.infCTe.infCTeNorm.infModal.rodo.veic.prop.tpProp = "2";

				// tabela seg
				cte.infCTe.infCTeNorm.seg.respSeg = "0"; // 0- Remetente, 1- Expedidor, 2 - Recebedor, 3 - Destinatário, 4 - Emitente do CT-e, 5 - Tomador de Serviço.
				cte.infCTe.infCTeNorm.seg.vCarga = Util.Formata2(ordem.ValorMercadoria);

				if (!string.IsNullOrEmpty(ordem.CaracAd.Trim())
					|| !string.IsNullOrEmpty(ordem.CaracSer.Trim())
					|| !string.IsNullOrEmpty(ordem.ObsCont.Trim())
					|| !string.IsNullOrEmpty(ordem.ObsFisco.Trim())
					|| !string.IsNullOrEmpty(ordem.Obs.Trim()))
				{
					cte.infCTe.compl = new CTe.compl();

					if (!string.IsNullOrEmpty(ordem.CaracAd))
					{
						cte.infCTe.compl.xCaracAd = ordem.CaracAd;
					}
					else
					{
						cte.infCTe.compl.xCaracAd = null;
					}

					if (!string.IsNullOrEmpty(ordem.CaracSer))
					{
						cte.infCTe.compl.xCaracSer = ordem.CaracSer;
					}
					else
					{
						cte.infCTe.compl.xCaracSer = null;
					}

					if (!string.IsNullOrEmpty(ordem.ObsCont.Trim()))
					{
						cte.infCTe.compl.ObsCont = new CTe.ObsCont();
						cte.infCTe.compl.ObsCont.xCampo = "Obs";
						cte.infCTe.compl.ObsCont.xTexto = ordem.ObsCont;
					}

					if (!string.IsNullOrEmpty(ordem.ObsFisco.Trim()))
					{
						cte.infCTe.compl.ObsFisco = new CTe.ObsFisco();
						cte.infCTe.compl.ObsFisco.xCampo = "10";
						cte.infCTe.compl.ObsFisco.xTexto = ordem.ObsFisco;
					}

					if (!string.IsNullOrEmpty(ordem.Obs.Trim()))
					{
						cte.infCTe.compl.xObs = ordem.Obs;
					}
					else
					{
						cte.infCTe.compl.xObs = null;
					}
				}

				string serializado = Serializar<CTe.CTe>(cte);

				StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + chave + "-cte.xml");
				writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
				writer.Flush();
				writer.Close();

				ordem.CTe = chave;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.Data + Environment.NewLine + e.StackTrace, "DSoft CTe", MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}
		}

		public bool ConsultarCTe(string chave)
		{
			CTe.consSitCTe consulta = new CTe.consSitCTe();
			consulta.versao = "2.00";
			consulta.tpAmb = "1";
			consulta.xServ = "CONSULTAR";
			consulta.chCTe = chave;

			string serializado = Serializar<CTe.consSitCTe>(consulta);

			StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + chave + "-ped-sit.xml");
			writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
			writer.Flush();
			writer.Close();

			return true;
		}

		#endregion Methods
	}
}