using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DSoftModels;

using DSoftParameters;

namespace DSoft_Delivery
{
	public class Sync
	{
		#region Methods

		public static bool AlteraCliente(ref Cliente cliente)
		{
			//try
			//{
			//    string arquivo = /*Matriz.Pasta2() +*/ "\\alteraCliente_" + Filial.Codigo.ToString("000") + "_" + cliente.Codigo.ToString() + ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "alteraCliente_" + Filial.Codigo.ToString("000") + "_" + cliente.Codigo.ToString();

			//    ds.Tables.Add("cad_clientes");
			//    ds.Tables[0].Columns.Add("codigo");
			//    ds.Tables[0].Columns.Add("nome");
			//    ds.Tables[0].Columns.Add("nascimento");
			//    ds.Tables[0].Columns.Add("tipo");
			//    ds.Tables[0].Columns.Add("documento");
			//    ds.Tables[0].Columns.Add("rg");
			//    ds.Tables[0].Columns.Add("tel1");
			//    ds.Tables[0].Columns.Add("tel2");
			//    ds.Tables[0].Columns.Add("celular");
			//    ds.Tables[0].Columns.Add("endereco");
			//    ds.Tables[0].Columns.Add("bairro");
			//    ds.Tables[0].Columns.Add("cidade");
			//    ds.Tables[0].Columns.Add("estado");
			//    ds.Tables[0].Columns.Add("pais");
			//    ds.Tables[0].Columns.Add("referencia");
			//    ds.Tables[0].Columns.Add("observacao");
			//    ds.Tables[0].Columns.Add("situacao");
			//    ds.Tables[0].Columns.Add("cadastro");
			//    ds.Tables[0].Columns.Add("grupo");
			//    ds.Tables[0].Columns.Add("saldo");
			//    ds.Tables[0].Columns.Add("cep");
			//    ds.Tables[0].Columns.Add("numero");
			//    ds.Tables[0].Columns.Add("complemento");
			//    ds.Tables[0].Columns.Add("inscricao_estadual");
			//    ds.Tables[0].Columns.Add("inscricao_suframa");
			//    ds.Tables[0].Columns.Add("isento_icms");
			//    ds.Tables[0].Columns.Add("credito_limite");
			//    ds.Tables[0].Columns.Add("pai");
			//    ds.Tables[0].Columns.Add("mae");
			//    ds.Tables[0].Columns.Add("conjuge");
			//    ds.Tables[0].Columns.Add("profissao");
			//    ds.Tables[0].Columns.Add("ultima_compra");

			//    DataRow drCliente = ds.Tables[0].NewRow();

			//    drCliente["codigo"] = cliente.Codigo.ToString();
			//    drCliente["nome"] = cliente.Nome;
			//    drCliente["nascimento"] = cliente.Nascimento.ToString("dd/MM/yy");
			//    drCliente["tipo"] = cliente.Tipo.ToString();
			//    drCliente["documento"] = cliente.Documento;
			//    drCliente["rg"] = cliente.Rg;
			//    drCliente["tel1"] = cliente.Telefone1.ToString();
			//    drCliente["tel2"] = cliente.Telefone2.ToString();
			//    drCliente["celular"] = cliente.Celular.ToString();
			//    drCliente["endereco"] = cliente.Endereco;
			//    drCliente["bairro"] = cliente.Bairro;
			//    drCliente["cidade"] = cliente.Cidade;
			//    drCliente["estado"] = cliente.Estado;
			//    drCliente["pais"] = cliente.Pais;
			//    drCliente["referencia"] = cliente.Referencia;
			//    drCliente["observacao"] = cliente.Observacao;
			//    drCliente["situacao"] = cliente.Situacao;
			//    drCliente["cadastro"] = DateTime.Now.ToString("dd/MM/yy");
			//    drCliente["grupo"] = cliente.Grupo.ToString();
			//    drCliente["saldo"] = "0";
			//    drCliente["cep"] = cliente.Cep;
			//    drCliente["numero"] = cliente.Numero;
			//    drCliente["complemento"] = cliente.Complemento;
			//    drCliente["inscricao_estadual"] = cliente.InscricaoEstadual;
			//    drCliente["inscricao_suframa"] = cliente.InscricaoSuframa;
			//    drCliente["isento_icms"] = cliente.IsentoICMS.ToString();
			//    drCliente["credito_limite"] = cliente.Limite.ToString("0.00");
			//    //drCliente["pai"] = ;
			//    //drCliente["mae"] = ;
			//    //drCliente["conjuge"] = ;
			//    //drCliente["profissao"] = ;
			//    drCliente["ultima_compra"] = " ";

			//    ds.Tables[0].Rows.Add(drCliente);

			//    ds.Tables[0].WriteXml(arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool AlteraVenda(Pedido pedido, int usuario)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "alteraVenda_";
			//    arquivo += Filial.Codigo.ToString("000");
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "alteraVenda";

			//    ds.Tables.Add("alteraVenda");
			//    ds.Tables["alteraVenda"].Columns.Add("Filial");
			//    ds.Tables["alteraVenda"].Columns.Add("Terminal");
			//    ds.Tables["alteraVenda"].Columns.Add("Usuario");
			//    ds.Tables["alteraVenda"].Columns.Add("Indice");
			//    ds.Tables["alteraVenda"].Columns.Add("Itens");
			//    ds.Tables["alteraVenda"].Columns.Add("Valor");

			//    ds.Tables.Add("itensPedido");
			//    ds.Tables["itensPedido"].Columns.Add("Numero");
			//    ds.Tables["itensPedido"].Columns.Add("Produto");
			//    ds.Tables["itensPedido"].Columns.Add("Quantidade");
			//    ds.Tables["itensPedido"].Columns.Add("Valor");

			//    DataRow drAlteraVenda = ds.Tables["alteraVenda"].NewRow();

			//    drAlteraVenda["Filial"] = Filial.Codigo.ToString("000");
			//    drAlteraVenda["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drAlteraVenda["Usuario"] = _usuario.Autorizado.ToString();
			//    drAlteraVenda["Indice"] = pedido.NumeroPedido().ToString();
			//    drAlteraVenda["Itens"] = pedido.ItensQtd.ToString();
			//    drAlteraVenda["Valor"] = pedido.ValorTotal().ToString("0.00");

			//    ds.Tables["alteraVenda"].Rows.Add(drAlteraVenda);

			//    for (int i = 0; i < pedido.ItensQtd; i++)
			//    {
			//        DataRow drItem = ds.Tables["itensPedido"].NewRow();

			//        drItem["Numero"] = pedido.ItensPedido[i].Numero.ToString();
			//        drItem["Produto"] = pedido.ItensPedido[i].Produto.ToString();
			//        drItem["Quantidade"] = pedido.ItensPedido[i].Quantidade.ToString();
			//        drItem["Valor"] = pedido.ItensPedido[i].Preco.ToString("0.00");

			//        ds.Tables["itensPedido"].Rows.Add(drItem);
			//    }

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool CancelaEntradaEstoque(Compra compra, int usuario)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "cancEntradaEstoque_";
			//    arquivo += Filial.Codigo.ToString("000") + "_";
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "cancEntradaEstoque";

			//    ds.Tables.Add("cancEntradaEstoque");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Filial");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Terminal");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Usuario");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Indice");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Itens");
			//    ds.Tables["cancEntradaEstoque"].Columns.Add("Valor");

			//    DataRow drEntradaEstoque = ds.Tables["cancEntradaEstoque"].NewRow();

			//    drEntradaEstoque["Filial"] = Filial.Codigo.ToString("000");
			//    drEntradaEstoque["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drEntradaEstoque["Usuario"] = Usuario.Autorizado.ToString();
			//    drEntradaEstoque["Indice"] = compra.Codigo.ToString();
			//    drEntradaEstoque["Itens"] = compra.Itens.ToString();
			//    drEntradaEstoque["Valor"] = compra.Valor.ToString("0.00");

			//    ds.Tables["cancEntradaEstoque"].Rows.Add(drEntradaEstoque);

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool CancelaFechamentoDia(int fechamento)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "cancFechaDia_";
			//    arquivo += Filial.Codigo.ToString("000");
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "cancFechaDia";

			//    ds.Tables.Add("cancFechaDia");
			//    ds.Tables["cancFechaDia"].Columns.Add("Filial");
			//    ds.Tables["cancFechaDia"].Columns.Add("Terminal");
			//    ds.Tables["cancFechaDia"].Columns.Add("Usuario");
			//    ds.Tables["cancFechaDia"].Columns.Add("Indice");

			//    DataRow drFechaDia = ds.Tables["cancFechaDia"].NewRow();

			//    drFechaDia["Filial"] = Filial.Codigo.ToString("000");
			//    drFechaDia["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drFechaDia["Usuario"] = Usuario.Autorizado.ToString();
			//    drFechaDia["Indice"] = fechamento;

			//    ds.Tables["cancFechaDia"].Rows.Add(drFechaDia);

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool CancelaParcela(long numero)
		{
			//try
			//{
			//    string arquivo = Matriz.Pasta2() + "\\cancelaParcela_" + Filial.Codigo.ToString("000") + "_" + numero.ToString() + ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "cancelaParcela";

			//    ds.Tables.Add("promissoria");
			//    ds.Tables[0].Columns.Add("filial");
			//    ds.Tables[0].Columns.Add("numero");

			//    DataRow drParcela = ds.Tables[0].NewRow();

			//    drParcela["filial"] = Filial.Codigo;
			//    drParcela["numero"] = numero;

			//    ds.Tables[0].Rows.Add(drParcela);

			//    ds.Tables[0].WriteXml(arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool CancelaVenda(ref Pedido pedido, int usuario)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "cancelaVenda_";
			//    arquivo += Filial.Codigo.ToString("000");
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "cancelaVenda";

			//    ds.Tables.Add("cancelaVenda");
			//    ds.Tables["cancelaVenda"].Columns.Add("Filial");
			//    ds.Tables["cancelaVenda"].Columns.Add("Terminal");
			//    ds.Tables["cancelaVenda"].Columns.Add("Usuario");
			//    ds.Tables["cancelaVenda"].Columns.Add("Indice");
			//    ds.Tables["cancelaVenda"].Columns.Add("Itens");
			//    ds.Tables["cancelaVenda"].Columns.Add("Valor");

			//    DataRow drNovaVenda = ds.Tables["cancelaVenda"].NewRow();

			//    drNovaVenda["Filial"] = Filial.Codigo.ToString("000");
			//    drNovaVenda["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drNovaVenda["Usuario"] = Usuario.Autorizado.ToString();
			//    drNovaVenda["Indice"] = pedido.NumeroPedido().ToString();
			//    drNovaVenda["Itens"] = pedido.ItensQtd.ToString();
			//    drNovaVenda["Valor"] = pedido.ValorTotal().ToString("0.00");

			//    ds.Tables["cancelaVenda"].Rows.Add(drNovaVenda);

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool EntradaEstoque(ref Compra compra, int usuario)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "entradaEstoque_";
			//    arquivo += Filial.Codigo.ToString("000") + "_";
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "entradaEstoque";

			//    ds.Tables.Add("entradaEstoque");
			//    ds.Tables["entradaEstoque"].Columns.Add("Filial");
			//    ds.Tables["entradaEstoque"].Columns.Add("Terminal");
			//    ds.Tables["entradaEstoque"].Columns.Add("Usuario");
			//    ds.Tables["entradaEstoque"].Columns.Add("Indice");
			//    ds.Tables["entradaEstoque"].Columns.Add("Itens");
			//    ds.Tables["entradaEstoque"].Columns.Add("Valor");

			//    ds.Tables.Add("itensPedido");
			//    ds.Tables["itensPedido"].Columns.Add("Numero");
			//    ds.Tables["itensPedido"].Columns.Add("Produto");
			//    ds.Tables["itensPedido"].Columns.Add("Quantidade");
			//    ds.Tables["itensPedido"].Columns.Add("Valor");

			//    DataRow drEntradaEstoque = ds.Tables["entradaEstoque"].NewRow();

			//    drEntradaEstoque["Filial"] = Filial.Codigo.ToString("000");
			//    drEntradaEstoque["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drEntradaEstoque["Usuario"] = Usuario.Autorizado.ToString();
			//    drEntradaEstoque["Indice"] = compra.Codigo.ToString();
			//    drEntradaEstoque["Itens"] = compra.Itens.ToString();
			//    drEntradaEstoque["Valor"] = compra.Valor.ToString("0.00");

			//    ds.Tables["entradaEstoque"].Rows.Add(drEntradaEstoque);

			//    for (int i = 0; i < compra.Itens; i++)
			//    {
			//        DataRow drItem = ds.Tables["itensPedido"].NewRow();

			//        drItem["Numero"] = compra.Item[i].Numero.ToString();
			//        drItem["Produto"] = compra.Item[i].Produto.ToString();
			//        drItem["Quantidade"] = compra.Item[i].Quantidade.ToString();
			//        drItem["Valor"] = compra.Item[i].Total.ToString("0.00");

			//        ds.Tables["itensPedido"].Rows.Add(drItem);
			//    }

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool FechamentoDia(int fechamento)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "fechaDia_";
			//    arquivo += Filial.Codigo.ToString("000") + "_";
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "fechaDia";

			//    ds.Tables.Add("fechaDia");
			//    ds.Tables["fechaDia"].Columns.Add("Filial");
			//    ds.Tables["fechaDia"].Columns.Add("Terminal");
			//    ds.Tables["fechaDia"].Columns.Add("Usuario");
			//    ds.Tables["fechaDia"].Columns.Add("Indice");
			//    ds.Tables["fechaDia"].Columns.Add("DataHora");
			//    ds.Tables["fechaDia"].Columns.Add("SaldoAnterior");
			//    ds.Tables["fechaDia"].Columns.Add("SaldoAtual");
			//    ds.Tables["fechaDia"].Columns.Add("Vendas");
			//    ds.Tables["fechaDia"].Columns.Add("Volume");
			//    ds.Tables["fechaDia"].Columns.Add("Entrada");
			//    ds.Tables["fechaDia"].Columns.Add("Saida");
			//    ds.Tables["fechaDia"].Columns.Add("Vales");
			//    ds.Tables["fechaDia"].Columns.Add("Pagamentos");
			//    ds.Tables["fechaDia"].Columns.Add("Despesas");
			//    ds.Tables["fechaDia"].Columns.Add("Dinheiro");
			//    ds.Tables["fechaDia"].Columns.Add("Cheque");
			//    ds.Tables["fechaDia"].Columns.Add("Cartao");
			//    ds.Tables["fechaDia"].Columns.Add("Crediario");

			//    DataRow drFechaDia = ds.Tables["fechaDia"].NewRow();

			//    Fechamento fechaDia = new Fechamento();

			//    fechaDia.Indice = fechamento;

			//    if (!Bd.CarregarFechamento(ref fechaDia, Usuario.Autorizado))
			//        return false;

			//    drFechaDia["Filial"] = Filial.Codigo.ToString("000");
			//    drFechaDia["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drFechaDia["Usuario"] = Usuario.Autorizado.ToString();
			//    drFechaDia["Indice"] = fechamento;
			//    drFechaDia["DataHora"] = fechaDia.Data.ToString("ddMMyyyy") + fechaDia.Hora.ToString("HHmmss");
			//    drFechaDia["SaldoAnterior"] = fechaDia.SaldoAnterior.ToString("0.00");
			//    drFechaDia["SaldoAtual"] = fechaDia.SaldoAtual.ToString("0.00");
			//    drFechaDia["Vendas"] = fechaDia.Vendas.ToString("0.00");
			//    drFechaDia["Volume"] = fechaDia.Volume.ToString();
			//    drFechaDia["Entrada"] = fechaDia.Entrada.ToString("0.00");
			//    drFechaDia["Saida"] = fechaDia.Saida.ToString("0.00");
			//    drFechaDia["Vales"] = fechaDia.Vales.ToString("0.00");
			//    drFechaDia["Pagamentos"] = fechaDia.Pagamentos.ToString("0.00");
			//    drFechaDia["Despesas"] = fechaDia.Despesas.ToString("0.00");
			//    drFechaDia["Dinheiro"] = fechaDia.Dinheiro.ToString("0.00");
			//    drFechaDia["Cheque"] = fechaDia.Cheque.ToString("0.00");
			//    drFechaDia["Cartao"] = fechaDia.Cartao.ToString("0.00");
			//    drFechaDia["Crediario"] = fechaDia.Crediario.ToString("0.00");

			//    ds.Tables["fechaDia"].Rows.Add(drFechaDia);

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool NovaParcela(ref Pedido pedido, Parcela parcela, long numero)
		{
			//try
			//{
			//    string arquivo = Matriz.Pasta2() + "\\novaParcela_" + Filial.Codigo.ToString("000") + "_" + pedido.ClientePedido().ToString() + "_"
			//        + pedido.NumeroPedido().ToString() + "_" + parcela.Numero.ToString() + "_" + numero + ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "novaParcela";

			//    ds.Tables.Add("promissoria");
			//    ds.Tables[0].Columns.Add("filial");
			//    ds.Tables[0].Columns.Add("pedido");
			//    ds.Tables[0].Columns.Add("parcela");
			//    ds.Tables[0].Columns.Add("data");
			//    ds.Tables[0].Columns.Add("vencimento");
			//    ds.Tables[0].Columns.Add("valor");
			//    ds.Tables[0].Columns.Add("juros");
			//    ds.Tables[0].Columns.Add("cliente");
			//    ds.Tables[0].Columns.Add("numero");

			//    DataRow drParcela = ds.Tables[0].NewRow();

			//    drParcela["filial"] = Filial.Codigo;
			//    drParcela["pedido"] = pedido.NumeroPedido();
			//    drParcela["parcela"] = parcela.Numero;
			//    drParcela["data"] = pedido.Data.ToString("dd/MM/yy");
			//    drParcela["vencimento"] = parcela.Vencimento.ToString("dd/MM/yy");
			//    drParcela["valor"] = parcela.Valor.ToString("0.00");
			//    drParcela["juros"] = parcela.Juros.ToString("0.00");
			//    drParcela["cliente"] = pedido.ClientePedido();
			//    drParcela["numero"] = numero;

			//    ds.Tables[0].Rows.Add(drParcela);

			//    ds.Tables[0].WriteXml(arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool NovaVenda(Pedido pedido, int usuario)
		{
			//try
			//{
			//    string arquivo;

			//    arquivo = "novaVenda_";
			//    arquivo += Filial.Codigo.ToString("000");
			//    arquivo += Terminal.NumeroCaixa().ToString("00");
			//    arquivo += "_";
			//    arquivo += DateTime.Now.ToString("yyyyMMddHHmmss");
			//    arquivo += ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "novaVenda";

			//    ds.Tables.Add("novaVenda");
			//    ds.Tables["novaVenda"].Columns.Add("Filial");
			//    ds.Tables["novaVenda"].Columns.Add("Terminal");
			//    ds.Tables["novaVenda"].Columns.Add("Usuario");
			//    ds.Tables["novaVenda"].Columns.Add("Indice");
			//    ds.Tables["novaVenda"].Columns.Add("Itens");
			//    ds.Tables["novaVenda"].Columns.Add("Valor");

			//    ds.Tables.Add("itensPedido");
			//    ds.Tables["itensPedido"].Columns.Add("Numero");
			//    ds.Tables["itensPedido"].Columns.Add("Produto");
			//    ds.Tables["itensPedido"].Columns.Add("Quantidade");
			//    ds.Tables["itensPedido"].Columns.Add("Valor");

			//    DataRow drNovaVenda = ds.Tables["novaVenda"].NewRow();

			//    drNovaVenda["Filial"] = Filial.Codigo.ToString("000");
			//    drNovaVenda["Terminal"] = Terminal.NumeroCaixa().ToString("00");
			//    drNovaVenda["Usuario"] = Usuario.Autorizado.ToString();
			//    drNovaVenda["Indice"] = pedido.NumeroPedido().ToString();
			//    drNovaVenda["Itens"] = pedido.ItensQtd.ToString();
			//    drNovaVenda["Valor"] = pedido.ValorTotal().ToString("0.00");

			//    ds.Tables["novaVenda"].Rows.Add(drNovaVenda);

			//    for (int i = 0; i < pedido.ItensQtd; i++)
			//    {
			//        DataRow drItem = ds.Tables["itensPedido"].NewRow();

			//        drItem["Numero"] = pedido.ItensPedido[i].Numero.ToString();
			//        drItem["Produto"] = pedido.ItensPedido[i].Produto.ToString();
			//        drItem["Quantidade"] = pedido.ItensPedido[i].Quantidade.ToString();
			//        drItem["Valor"] = pedido.ItensPedido[i].Preco.ToString("0.00");

			//        ds.Tables["itensPedido"].Rows.Add(drItem);
			//    }

			//    ds.WriteXml(Matriz.Pasta2() + arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool NovoCliente(ref Cliente cliente)
		{
			//try
			//{
			//    string arquivo = Matriz.Pasta2() + "\\novoCliente_" + Filial.Codigo.ToString("000") + "_" + cliente.Codigo.ToString() + ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "novoCliente_" + Filial.Codigo.ToString("000") + "_" + cliente.Codigo.ToString();

			//    ds.Tables.Add("cad_clientes");
			//    ds.Tables[0].Columns.Add("codigo");
			//    ds.Tables[0].Columns.Add("nome");
			//    ds.Tables[0].Columns.Add("nascimento");
			//    ds.Tables[0].Columns.Add("tipo");
			//    ds.Tables[0].Columns.Add("documento");
			//    ds.Tables[0].Columns.Add("rg");
			//    ds.Tables[0].Columns.Add("tel1");
			//    ds.Tables[0].Columns.Add("tel2");
			//    ds.Tables[0].Columns.Add("celular");
			//    ds.Tables[0].Columns.Add("endereco");
			//    ds.Tables[0].Columns.Add("bairro");
			//    ds.Tables[0].Columns.Add("cidade");
			//    ds.Tables[0].Columns.Add("estado");
			//    ds.Tables[0].Columns.Add("pais");
			//    ds.Tables[0].Columns.Add("referencia");
			//    ds.Tables[0].Columns.Add("observacao");
			//    ds.Tables[0].Columns.Add("situacao");
			//    ds.Tables[0].Columns.Add("cadastro");
			//    ds.Tables[0].Columns.Add("grupo");
			//    ds.Tables[0].Columns.Add("saldo");
			//    ds.Tables[0].Columns.Add("cep");
			//    ds.Tables[0].Columns.Add("numero");
			//    ds.Tables[0].Columns.Add("complemento");
			//    ds.Tables[0].Columns.Add("inscricao_estadual");
			//    ds.Tables[0].Columns.Add("inscricao_suframa");
			//    ds.Tables[0].Columns.Add("isento_icms");
			//    ds.Tables[0].Columns.Add("credito_limite");
			//    ds.Tables[0].Columns.Add("pai");
			//    ds.Tables[0].Columns.Add("mae");
			//    ds.Tables[0].Columns.Add("conjuge");
			//    ds.Tables[0].Columns.Add("profissao");
			//    ds.Tables[0].Columns.Add("ultima_compra");

			//    DataRow drCliente = ds.Tables[0].NewRow();

			//    drCliente["codigo"] = cliente.Codigo.ToString();
			//    drCliente["nome"] = cliente.Nome;
			//    drCliente["nascimento"] = cliente.Nascimento.ToString("dd/MM/yy");
			//    drCliente["tipo"] = cliente.Tipo.ToString();
			//    drCliente["documento"] = cliente.Documento;
			//    drCliente["rg"] = cliente.Rg;
			//    drCliente["tel1"] = cliente.Telefone1.ToString();
			//    drCliente["tel2"] = cliente.Telefone2.ToString();
			//    drCliente["celular"] = cliente.Celular.ToString();
			//    drCliente["endereco"] = cliente.Endereco;
			//    drCliente["bairro"] = cliente.Bairro;
			//    drCliente["cidade"] = cliente.Cidade;
			//    drCliente["estado"] = cliente.Estado;
			//    drCliente["pais"] = cliente.Pais;
			//    drCliente["referencia"] = cliente.Referencia;
			//    drCliente["observacao"] = cliente.Observacao;
			//    drCliente["situacao"] = cliente.Situacao;
			//    drCliente["cadastro"] = DateTime.Now.ToString("dd/MM/yy");
			//    drCliente["grupo"] = cliente.Grupo.ToString();
			//    drCliente["saldo"] = "0";
			//    drCliente["cep"] = cliente.Cep;
			//    drCliente["numero"] = cliente.Numero;
			//    drCliente["complemento"] = cliente.Complemento;
			//    drCliente["inscricao_estadual"] = cliente.InscricaoEstadual;
			//    drCliente["inscricao_suframa"] = cliente.InscricaoSuframa;
			//    drCliente["isento_icms"] = cliente.IsentoICMS.ToString();
			//    drCliente["credito_limite"] = cliente.Limite.ToString("0.00");
			//    //drCliente["pai"] = ;
			//    //drCliente["mae"] = ;
			//    //drCliente["conjuge"] = ;
			//    //drCliente["profissao"] = ;
			//    drCliente["ultima_compra"] = " ";

			//    ds.Tables[0].Rows.Add(drCliente);

			//    ds.Tables[0].WriteXml(arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		public static bool PagaParcela(Pagamento pagamento)
		{
			//try
			//{
			//    string arquivo = Matriz.Pasta2() + "\\pagaParcela_" + Filial.Codigo.ToString("000") + "_" + pagamento.Numero.ToString() + ".xml";

			//    DataSet ds = new DataSet();

			//    ds.DataSetName = "pagaParcela";

			//    ds.Tables.Add("promissoria");
			//    ds.Tables[0].Columns.Add("filial");
			//    ds.Tables[0].Columns.Add("numero");
			//    ds.Tables[0].Columns.Add("multa");
			//    ds.Tables[0].Columns.Add("pago");
			//    ds.Tables[0].Columns.Add("data");

			//    DataRow drParcela = ds.Tables[0].NewRow();

			//    drParcela["filial"] = Filial.Codigo;
			//    drParcela["numero"] = pagamento.Numero;
			//    drParcela["multa"] = pagamento.Multa.ToString("0.00");
			//    drParcela["pago"] = pagamento.TotalPago.ToString("0.00");
			//    drParcela["data"] = pagamento.Data.ToString("dd/MM/yy");

			//    ds.Tables[0].Rows.Add(drParcela);

			//    ds.Tables[0].WriteXml(arquivo);

				return true;
			//}
			//catch (Exception e)
			//{
			//    MessageBox.Show(e.Message, "Sync", MessageBoxButtons.OK, MessageBoxIcon.Error);

			//    return false;
			//}
		}

		#endregion Methods
	}
}