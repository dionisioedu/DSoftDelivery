using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

using DSoftBd;

using DSoftCore;

using DSoftModels;
using DSoftParameters;
using System.Windows.Forms;

namespace DSoft_Delivery.MDFe
{
	public class MDFeManager
	{
		#region Constructors

		public MDFeManager()
		{
		}

		#endregion Constructors

		#region Methods

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

		public bool Gerar(Bd bd, Manifesto manifesto)
		{
			try
			{
				Chave chave = GerarChave(manifesto, bd);

				MDFe mdfe = new MDFe("1.00", "MDFe" + chave.chave);

				// Tabela ide
				mdfe.infMDFe.ide.cUF = bd.CodigoEstado(manifesto.Emitente.Uf.Substring(0, 2));
				mdfe.infMDFe.ide.tpAmb = "1";
				mdfe.infMDFe.ide.tpEmit = "1";
				mdfe.infMDFe.ide.mod = "58";
				mdfe.infMDFe.ide.serie = "1";
				mdfe.infMDFe.ide.nMDF = manifesto.Indice;
				mdfe.infMDFe.ide.cMDF = chave.codigo;
				mdfe.infMDFe.ide.cDV = chave.digito;
				mdfe.infMDFe.ide.modal = "1"; // Rodoviário
				mdfe.infMDFe.ide.dhEmi = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
				mdfe.infMDFe.ide.tpEmis = "1"; // Normal
				mdfe.infMDFe.ide.procEmi = "0"; // emissão de MDF-e com aplicativo do contribuinte
				mdfe.infMDFe.ide.verProc = "1.4";
				mdfe.infMDFe.ide.UFIni = manifesto.Emitente.Uf.Substring(0, 2);
				mdfe.infMDFe.ide.UFFim = "CE"; //TODO Resolver isso aqui

				mdfe.infMDFe.ide.infMunCarrega.cMunCarrega = bd.CodigoMunicipio(manifesto.Emitente.Municipio, manifesto.Emitente.Uf.Substring(0, 2));
				mdfe.infMDFe.ide.infMunCarrega.xMunCarrega = manifesto.Emitente.Municipio;

				mdfe.infMDFe.ide.infPercurso.Add(new infPercurso() { UFPer = "RJ" });
				mdfe.infMDFe.ide.infPercurso.Add(new infPercurso() { UFPer = "MG" });
				mdfe.infMDFe.ide.infPercurso.Add(new infPercurso() { UFPer = "BA" });
				mdfe.infMDFe.ide.infPercurso.Add(new infPercurso() { UFPer = "PE" });
				mdfe.infMDFe.ide.infPercurso.Add(new infPercurso() { UFPer = "PI" });

				// Tabela emit
				mdfe.infMDFe.emit.CNPJ = manifesto.Emitente.Cnpj.ToString("00000000000000");

				if (manifesto.Emitente.InscricaoEstadual == "ISENTO")
				{
					mdfe.infMDFe.emit.IE = "ISENTO";
				}
				else
				{
					mdfe.infMDFe.emit.IE = Util.LimpaFormatacao(manifesto.Emitente.InscricaoEstadual);
				}

				mdfe.infMDFe.emit.xNome = manifesto.Emitente.RazaoSocial;
				mdfe.infMDFe.emit.xFant = manifesto.Emitente.NomeFantasia;

				mdfe.infMDFe.emit.enderEmit.xLgr = manifesto.Emitente.Logradouro;
				mdfe.infMDFe.emit.enderEmit.nro = manifesto.Emitente.Numero;
				mdfe.infMDFe.emit.enderEmit.xCpl = manifesto.Emitente.Complemento;
				mdfe.infMDFe.emit.enderEmit.xBairro = manifesto.Emitente.Bairro;
				mdfe.infMDFe.emit.enderEmit.cMun = bd.CodigoMunicipio(manifesto.Emitente.Municipio, manifesto.Emitente.Uf.Substring(0, 2));
				mdfe.infMDFe.emit.enderEmit.xMun = manifesto.Emitente.Municipio;
				mdfe.infMDFe.emit.enderEmit.CEP = Util.LimpaFormatacao(manifesto.Emitente.Cep);
				mdfe.infMDFe.emit.enderEmit.UF = manifesto.Emitente.Uf.Substring(0, 2);
				mdfe.infMDFe.emit.enderEmit.fone = Util.LimpaFormatacao(manifesto.Emitente.Telefone);
				mdfe.infMDFe.emit.enderEmit.email = manifesto.Emitente.Email;

				// Tabela infModal
				mdfe.infMDFe.infModal.versaoModal = "1.00";
				mdfe.infMDFe.infModal.rodo.Xmlns = "http://www.portalfiscal.inf.br/mdfe";
				mdfe.infMDFe.infModal.rodo.RNTRC = Convert.ToInt32(manifesto.RNTRC).ToString("00000000");
				//mdfe.infMDFe.infModal.rodo.CIOT = manifesto.CIOT;
				mdfe.infMDFe.infModal.rodo.veicPrincipal.cInt = manifesto.Veiculo.Placa.Remove(0, 4);
				mdfe.infMDFe.infModal.rodo.veicPrincipal.placa = manifesto.Veiculo.Placa.Remove(3, 1);
				mdfe.infMDFe.infModal.rodo.veicPrincipal.tara = manifesto.Veiculo.Tara;
				mdfe.infMDFe.infModal.rodo.veicPrincipal.condutor.xNome = manifesto.Motorista.Nome;
				mdfe.infMDFe.infModal.rodo.veicPrincipal.condutor.CPF = Util.LimpaFormatacao(manifesto.Motorista.Cpf);
				mdfe.infMDFe.infModal.rodo.veicPrincipal.tpRod = "01";
				mdfe.infMDFe.infModal.rodo.veicPrincipal.tpCar = "00";
				mdfe.infMDFe.infModal.rodo.veicPrincipal.UF = manifesto.Veiculo.Estado.Substring(0, 2);

				mdfe.infMDFe.infModal.rodo.veicReboque.cInt = manifesto.Carreta.Placa.Remove(0, 4);
				mdfe.infMDFe.infModal.rodo.veicReboque.placa = manifesto.Carreta.Placa.Remove(3, 1);
				mdfe.infMDFe.infModal.rodo.veicReboque.tara = manifesto.Carreta.Tara;
				mdfe.infMDFe.infModal.rodo.veicReboque.capKG = manifesto.Carreta.CapKg;
				mdfe.infMDFe.infModal.rodo.veicReboque.capM3 = manifesto.Carreta.CapM3;
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.CNPJ = Util.LimpaFormatacao(manifesto.Carreta.Cpf);
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.RNTRC = Convert.ToInt32(manifesto.RNTRC).ToString("00000000"); //Convert.ToInt32(manifesto.Carreta.RNTRC).ToString("00000000");
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.xNome = manifesto.Carreta.Proprietario;
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.IE = manifesto.Carreta.IE;
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.UF = manifesto.Carreta.Estado.Substring(0, 2);
				mdfe.infMDFe.infModal.rodo.veicReboque.prop.tpProp = "1"; //TODO Implementar campo tpProp
				mdfe.infMDFe.infModal.rodo.veicReboque.tpCar = "01";
				mdfe.infMDFe.infModal.rodo.veicReboque.UF = manifesto.Carreta.Estado.Substring(0, 2);

				// Tabela infDoc
				double peso = 0, valor = 0;
				foreach (OrdemDeColeta oc in manifesto.OrdemDeColeta)
				{
					bool find = false;
					int mun = bd.CodigoMunicipio(oc.MunicipioDestino, oc.EstadoDestino.Substring(0, 2));

					peso += oc.Peso;
					valor += oc.ValorMercadoria;

					for (int i = 0; i < mdfe.infMDFe.infDoc.infMunDescarga.Count; i++)
					{
						if (mdfe.infMDFe.infDoc.infMunDescarga[i].cMunDescarga == mun)
						{
							mdfe.infMDFe.infDoc.infMunDescarga[i].infCTe.Add(new infCTe() { chCTe = oc.CTe });
							find = true;
							break;
						}
					}

					if (find == false)
					{
						infMunDescarga desc = new infMunDescarga();
						desc.xMunDescarga = oc.MunicipioDestino;
						desc.cMunDescarga = bd.CodigoMunicipio(oc.MunicipioDestino, oc.EstadoDestino.Substring(0, 2));

						desc.infCTe.Add(new infCTe() { chCTe = oc.CTe });

						mdfe.infMDFe.infDoc.infMunDescarga.Add(desc);
					}
				}

				// Tabela tot
				mdfe.infMDFe.tot.qCTe = manifesto.OrdemDeColeta.Count;
				mdfe.infMDFe.tot.vCarga = Util.Formata2(valor);
				mdfe.infMDFe.tot.cUnid = "01";
				mdfe.infMDFe.tot.qCarga = Util.Formata4(peso);

				string serializado = Serializar<MDFe>(mdfe);

				//Por algum motivo não conseguimos gerar o atributo xmlns automaticamente, então vamos editar manualmente
				serializado = serializado.Replace("xxmlnsx", "xmlns");

				StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + chave.chave + "-mdfe.xml");
				writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
				writer.Flush();
				writer.Close();

				manifesto.Chave = chave.chave;

				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message + Environment.NewLine + e.Source + Environment.NewLine + e.StackTrace, "MDFeManager");
				return false;
			}
		}

		private Chave GerarChave(Manifesto manifesto, Bd bd)
		{
			string chave = string.Empty;
			string codigo = Util.Randomico(8);
			string dv;

			chave = bd.CodigoEstado(manifesto.Emitente.Uf.Substring(0, 2)).ToString("00");
			chave += (manifesto.Data.Year % 100).ToString("00") + manifesto.Data.Month.ToString("00");
			chave += manifesto.Emitente.Cnpj.ToString("00000000000000");
			chave += "58"; // Modelo
			chave += "001"; // Série
			chave += manifesto.Indice.ToString("000000000");
			chave += "1"; // Tipo de Emissão
			chave += codigo;
			dv = Util.Modulo11(chave);
			chave += dv;

			Chave Chave_ = new Chave();
			Chave_.chave = chave;
			Chave_.codigo = codigo;
			Chave_.digito = dv;

			return Chave_;
		}

		public bool EncerrarManifesto(Manifesto manifesto, DateTime encerramento)
		{
			eventoMDFe evento = new eventoMDFe();

			evento.versao = "1.00";
			evento.infEvento.Id = GerarId(manifesto);
			evento.infEvento.cOrgao = "35";
			evento.infEvento.tpAmb = "1";
			evento.infEvento.CNPJ = manifesto.Emitente.Cnpj.ToString("00000000000000");
			evento.infEvento.chMDFe = manifesto.Chave;
			evento.infEvento.dhEvento = encerramento.ToString("yyyy-MM-ddTHH:mm:ss");
			evento.infEvento.tpEvento = "110112";
			evento.infEvento.nSeqEvento = 1;

			evento.infEvento.detEvento.versaoEvento = "1.00";
			evento.infEvento.detEvento.evEncMDFe.descEvento = "Encerramento";
			evento.infEvento.detEvento.evEncMDFe.nProt = manifesto.Protocolo;
			evento.infEvento.detEvento.evEncMDFe.dtEnc = encerramento.ToString("yyyy-MM-dd");
			evento.infEvento.detEvento.evEncMDFe.cUF = manifesto.CodUFEntrega.ToString();
			evento.infEvento.detEvento.evEncMDFe.cMun = manifesto.CodMunEntrega.ToString();

			string serializado = Serializar<eventoMDFe>(evento);

			StreamWriter writer = new StreamWriter(Preferencias.PastaCTe + "\\" + manifesto.Chave + "-ped-eve.xml");
			writer.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + serializado);
			writer.Flush();
			writer.Close();

			return true;
		}

		public string GerarId(Manifesto manifesto)
		{
			return string.Format("ID110112{0}01", manifesto.Chave);
		}

		#endregion Methods
	}
}