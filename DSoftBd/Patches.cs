using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSoftBd
{
	public class PatchesManager
	{
		private Dictionary<int, string> _patches;

		public PatchesManager()
		{
			Load();
		}

		private void Load()
		{
			int number = 1;

			_patches = new Dictionary<int, string>();

			_patches.Add(number++, "alter table cad_clientes add contato varchar, add site varchar;");
			_patches.Add(number++, "alter table cad_recursos add email varchar;");
			_patches.Add(number++, "alter table cad_fornecedores drop tipo; alter table cad_fornecedores add tipo integer;");
			_patches.Add(number++, "insert into pagamentos_formas (codigo, descricao) values ('R', 'VR');");
			_patches.Add(number++, "alter table cad_recursos add disponivel boolean default false;");
			_patches.Add(number++, "alter table pedidos add troco double precision default 0;");
			_patches.Add(number++, "create table cad_observacoes ( observacao varchar, ordem integer );");
			_patches.Add(number++, "create table calendario_tabelas ( gerencia boolean default false, dom integer, seg integer, ter integer, qua integer, qui integer, sex integer, sab integer ); "
				+ "insert into calendario_tabelas (gerencia, dom, seg, ter, qua, qui, sex, sab) values (false, 1, 1, 1, 1, 1, 1, 1)");
			_patches.Add(number++, "CREATE TABLE recebimentos ( indice serial NOT NULL, data date DEFAULT now(), hora time without time zone DEFAULT now(), cliente bigint, valor double precision DEFAULT 0, "
				+ "situacao character varying DEFAULT 'A'::character varying,  usuario integer,  pago_data date, pago_hora time without time zone, pago_usuario integer, cancelado_data date, "
				+ "cancelado_hora time without time zone, cancelado_usuario integer, observacao character varying, tipo integer, vencimento date, valor_pago double precision DEFAULT 0, caixa_fluxo integer,"
				+ " CONSTRAINT recebimentos_pkey PRIMARY KEY (indice));");
			_patches.Add(number++, "CREATE TABLE recebimentos_tipos (  codigo integer,   nome character varying, CONSTRAINT recebimentos_tipos_codigo_key UNIQUE (codigo));");
			_patches.Add(number++, "ALTER TABLE pedidos ADD comanda integer;");
			_patches.Add(number++, "ALTER TABLE cad_adicionais ADD produto bigint;");
			_patches.Add(number++, "ALTER TABLE produtos_tipos ADD imprime_total boolean DEFAULT false;");
			_patches.Add(number++, "ALTER TABLE cad_adicionais ADD tipo integer;");
			_patches.Add(number++, "ALTER TABLE clientes_grupos ADD cidade varchar, ADD estado varchar;");
			_patches.Add(number++, "ALTER TABLE cad_clientes ADD taxa_de_entrega double precision;");
			_patches.Add(number++, "ALTER TABLE usuario_niveis ADD cadastrar_grupos_de_clientes BOOLEAN DEFAULT false;");
			_patches.Add(number++, "ALTER TABLE pedidos ADD motivo_cancelamento VARCHAR;");
			_patches.Add(number++, "ALTER TABLE pedidos ADD retira BOOLEAN DEFAULT false;");
			_patches.Add(number++, "ALTER TABLE pagamentos_formas ADD debito BOOLEAN DEFAULT FALSE;");
			_patches.Add(number++, "ALTER TABLE cad_clientes ALTER nascimento SET DEFAULT now();");
			_patches.Add(number++, "ALTER TABLE recursos_tipos ADD diaria numeric DEFAULT 0;");
			_patches.Add(number++, "ALTER TABLE cad_recursos ADD saldo numeric default 0;");
			_patches.Add(number++, "ALTER TABLE ordem_servico ADD num_coleta varchar;");
			_patches.Add(number++, "ALTER TABLE clientes_grupos ADD taxa_servico double precision DEFAULT 0;");
			_patches.Add(number++, "ALTER TABLE cad_clientes ADD aux_tel VARCHAR;");
			_patches.Add(number++, "ALTER TABLE pagamentos_formas ADD ativo BOOLEAN DEFAULT true;");
			_patches.Add(number++, "ALTER TABLE manifestos ADD arquivo VARCHAR;");
			_patches.Add(number++, "ALTER TABLE pedidos ADD taxa_entregador DOUBLE PRECISION DEFAULT 0");
			_patches.Add(number++, "ALTER TABLE cad_caixa ADD aberto BOOLEAN DEFAULT false, ADD aberto_usuario integer, ADD aberto_data date, ADD aberto_hora time;");
			_patches.Add(number++, "CREATE TABLE log_caixas (indice SERIAL NOT NULL PRIMARY KEY, data date DEFAULT now(), hora time DEFAULT now(), caixa integer, usuario integer, tipo character, saldo double precision, entrada double precision);");
			_patches.Add(number++, "ALTER TABLE cad_clientes ADD funcionario bigint;");
			_patches.Add(number++, "ALTER TABLE ordem_servico ADD icms_orig varchar;");
			_patches.Add(number++, "ALTER TABLE usuario_niveis ADD alterar_cliente_pedido BOOLEAN DEFAULT FALSE;");
			_patches.Add(number++, "ALTER TABLE ordem_servico ADD obs_cont varchar, ADD obs_fisco varchar, ADD carac_ad varchar, ADD carac_ser varchar;");
			_patches.Add(number++, "ALTER TABLE ordem_servico ADD xobs varchar;");
			_patches.Add(number++, "ALTER TABLE cad_usuarios ADD display varchar; UPDATE cad_usuarios SET display = nome;");
		}

		public Dictionary<int, string> Patches()
		{
			return _patches;
		}
	}
}
