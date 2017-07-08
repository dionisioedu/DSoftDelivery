  -- Function: dsoft_versao()

-- DROP FUNCTION dsoft_versao();

CREATE OR REPLACE FUNCTION dsoft_versao()
  RETURNS character varying AS
$BODY$
begin
	return '1.2.7.3';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_versao()
  OWNER TO postgres;


-- Function: dsoft_altera_caixa(integer, character varying)

-- DROP FUNCTION dsoft_altera_caixa(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_caixa(p_codigo integer, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar 	char;

begin

	auxiliar := situacao from cad_caixa where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    update cad_caixa set descricao = p_descricao
    	where codigo = p_codigo;
        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_caixa(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer)

-- DROP FUNCTION dsoft_altera_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_cliente(p_codigo bigint, p_nome character varying, p_nascimento date, p_tipo character, p_documento character varying, p_insc_estadual character varying, p_insc_suframa character varying, p_rg character varying, p_isento_icms boolean, p_tel1 bigint, p_tel2 bigint, p_celular bigint, p_endereco character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cidade character varying, p_estado character varying, p_pais character varying, p_cep character varying, p_referencia character varying, p_observacao character varying, cod_usuario integer, p_grupo integer, p_pai character varying, p_mae character varying, p_conjuge character varying, p_profissao character varying, p_senha character varying, p_tabela integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (p_codigo is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    update cad_clientes set nome = p_nome,
                              nascimento = p_nascimento,
                              tipo = p_tipo,
                              documento = p_documento,
                              inscricao_estadual = p_insc_estadual,
                              inscricao_suframa = p_insc_suframa,
                              rg = p_rg,
                              isento_icms = p_isento_icms,
                              tel1 = p_tel1,
                              tel2 = p_tel2,
                              celular = p_celular,
                              endereco = p_endereco,
                              numero = p_numero,
                              complemento = p_complemento,
                              bairro = p_bairro,
                              cidade = p_cidade,
                              pais = p_pais,
                              cep = p_cep,
                              estado = p_estado,
                              referencia = p_referencia,
                              observacao = p_observacao,
                              grupo = p_grupo,
                              alterado = now(),
                              alterado_usuario = cod_usuario,
                              pai = p_pai,
                              mae = p_mae,
                              conjuge = p_conjuge,
                              profissao = p_profissao,
                              senha = p_senha,
                              tabela_precos = p_tabela
                              where codigo = p_codigo;
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_codigo_cliente(bigint, bigint, integer)

-- DROP FUNCTION dsoft_altera_codigo_cliente(bigint, bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_codigo_cliente(p_antigo bigint, p_novo bigint, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin


	update cad_clientes set codigo = p_novo where codigo = p_antigo;
	update pedidos set cliente = p_novo where cliente = p_antigo;
	update caixa_fluxo set cliente = p_novo where cliente = p_antigo;
	update pagamentos set cliente = p_novo where cliente = p_antigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_codigo_cliente(bigint, bigint, integer)
  OWNER TO postgres;


  -- Function: dsoft_altera_despesa(integer, integer, integer, integer, numeric, date, character varying, character varying)

-- DROP FUNCTION dsoft_altera_despesa(integer, integer, integer, integer, numeric, date, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_despesa(p_usuario integer, p_despesa integer, p_tipo integer, p_fornecedor integer, p_valor numeric, p_vencimento date, p_documento character varying, p_observacao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;
declare tmp			varchar;
declare n_despesa	integer;

begin

	if (p_usuario is null or p_fornecedor is null or p_tipo is null) then
    	return false;
    end if;
    
    tmp := nome from despesas_tipo where codigo = p_tipo;
    
    if (tmp is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_fornecedores where codigo = p_fornecedor;
    
    if (auxiliar is null) then
    	return false;
    end if;

	if (p_valor is null or p_valor < 0) then
    	return false;
    end if;
    
    auxiliar := situacao from despesas where indice = p_despesa;
    
    if (auxiliar is null or (auxiliar <> 'A' and auxiliar <> 'V')) then
    	return false;
    end if;
    
    update despesas set alterado_usuario = p_usuario,
                      vencimento = p_vencimento,
                      documento = p_documento,
                      tipo = p_tipo,
                      observacao = p_observacao,
                      fornecedor = p_fornecedor,
                      valor = p_valor
                      where indice = p_despesa;
                      
	if (p_vencimento >= now()) then
    	update despesas set situacao = 'A' where indice = p_despesa;
    end if;
                            
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_despesa(integer, integer, integer, integer, numeric, date, character varying, character varying)
  OWNER TO postgres;


  -- Function: dsoft_altera_despesa_subtipo(integer, character varying, character varying, integer)

-- DROP FUNCTION dsoft_altera_despesa_subtipo(integer, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_despesa_subtipo(p_codigo integer, p_nome character varying, p_descricao character varying, p_tipo integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	varchar;

begin

	auxiliar := nome from despesas_subtipo where codigo = p_codigo;

	if (auxiliar is null) then
		return false;
	end if;

	if (p_nome is null) then
		return false;
	end if;
    
	update despesas_subtipo set nome = p_nome,
		descricao = p_descricao,
		tipo = p_tipo
		where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_despesa_subtipo(integer, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_despesa_tipo(integer, character varying, character varying)

-- DROP FUNCTION dsoft_altera_despesa_tipo(integer, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_despesa_tipo(p_codigo integer, p_nome character varying, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	varchar;

begin

	auxiliar := nome from despesas_tipo where codigo = p_codigo;

	if (auxiliar is null) then
		return false;
	end if;

	if (p_nome is null) then
		return false;
	end if;

	update despesas_tipo set nome = p_nome,
		descricao = p_descricao
		where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_despesa_tipo(integer, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_altera_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_emitente(p_razao character varying, p_nome character varying, p_cnpj character varying, p_inscr_est character varying, p_cnae_fiscal character varying, p_inscr_municipal character varying, p_logradouro character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cep character varying, p_pais character varying, p_uf character varying, p_municipio character varying, p_telefone character varying, p_rntrc character varying)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (not found) then
		return false;
	end if;

	update cad_emitentes set razao_social = p_razao,
				nome_fantasia = p_nome,
				inscricao_estadual = p_inscr_est,
				cnae_fiscal = p_cnae_fiscal,
				inscricao_municipal = p_inscr_municipal,
				logradouro = p_logradouro,
				numero = p_numero,
				complemento = p_complemento,
				bairro = p_bairro,
				cep = p_cep,
				pais = p_pais,
				uf = p_uf,
				municipio = p_municipio,
				telefone = p_telefone,
				"RNTRC" = p_rntrc
				where cnpj = p_cnpj;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_entrada(integer, integer, integer, bigint, character varying, numeric, character varying, date)

-- DROP FUNCTION dsoft_altera_entrada(integer, integer, integer, bigint, character varying, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_altera_entrada(p_indice integer, p_usuario integer, p_caixa integer, p_cliente bigint, p_forma character varying, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare numero int;
declare v_saldo_anterior numeric;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null or auxiliar <> 'A') then
		return false;
	end if;

	auxiliar := situacao from cad_caixa where codigo = p_caixa;

	if (auxiliar is null or auxiliar <> 'A') then
		return false;
	end if;

	v_saldo_anterior := valor from caixa_fluxo where indice = p_indice;

	update caixa_fluxo set caixa = p_caixa, forma = p_forma, cliente = p_cliente, valor = p_valor, usuario = p_usuario, observacao = p_observacao, data = p_data
		where indice = p_indice;
		
	update pagamentos set data = p_data, usuario = p_usuario, valor = p_valor, documento = p_observacao, pago_data = p_data, pago_hora = now(), pago_usuario = p_usuario, total_pago = p_valor, cliente = p_cliente
		where caixa_fluxo = p_indice;

	update cad_clientes set saldo = saldo + p_valor::double precision - v_saldo_anterior where codigo = p_cliente;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_entrada(integer, integer, integer, bigint, character varying, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_altera_estoque(integer, integer, integer)

-- DROP FUNCTION dsoft_altera_estoque(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_estoque(p_produto integer, p_minimo integer, p_maximo integer)
  RETURNS boolean AS
$BODY$
declare auxiliar integer;

begin

	perform quantidade from estoque where produto = p_produto;

	if (not found) then
		return false;
	end if;

	update estoque set minimo = p_minimo, maximo = p_maximo
		where produto = p_produto;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_estoque(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_grupo_clientes(integer, character varying)

-- DROP FUNCTION dsoft_altera_grupo_clientes(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_grupo_clientes(p_codigo integer, p_nome character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	auxiliar := situacao from clientes_grupos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    if (p_nome is null) then
    	return false;
    end if;
    
    update clientes_grupos set nome = p_nome where codigo = p_codigo;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_grupo_clientes(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer)

-- DROP FUNCTION dsoft_altera_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_grupo_tributario(p_codigo integer, p_nome character varying, p_icms double precision, p_ipi double precision, p_pis double precision, p_cofins double precision, p_csll double precision, p_irrf double precision, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	if (p_codigo is null or p_codigo = 0) then
		return false;
	end if;

	if (p_nome is null or p_nome = '') then
		return false;
	end if;

	if (p_icms is null or p_icms < 0) then
		return false;
	end if;

	if (p_ipi is null or p_ipi < 0) then
		return false;
	end if;

	if (p_pis is null or p_pis < 0) then
		return false;
	end if;

	if (p_cofins is null or p_cofins < 0) then
		return false;
	end if;

	if (p_csll is null or p_csll < 0) then
		return false;
	end if;

	if (p_irrf is null or p_irrf < 0) then
		return false;
	end if;

	perform nome from grupos_tributarios where codigo = p_codigo;

	if (not found) then
		return false;
	end if;

	update grupos_tributarios set nome = p_nome,
					icms = p_icms,
					ipi = p_ipi,
					pis = p_pis,
					cofins = p_cofins,
					csll = p_csll,
					irrf = p_irrf,
					alterado = now(),
					alterado_usuario = p_usuario
		where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_local(integer, character varying, character varying, character, integer)

-- DROP FUNCTION dsoft_altera_local(integer, character varying, character varying, character, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_local(p_codigo integer, p_nome character varying, p_descricao character varying, p_tipo character, p_responsavel integer)
  RETURNS boolean AS
$BODY$

begin

	update locais set nome = p_nome,
			descricao = p_descricao,
			tipo = p_tipo,
			responsavel = p_responsavel
			where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_local(integer, character varying, character varying, character, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_material(integer, character varying, character varying, integer, integer, integer, integer)

-- DROP FUNCTION dsoft_altera_material(integer, character varying, character varying, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_material(p_codigo integer, p_nome character varying, p_descricao character varying, p_fornecedor integer, p_tipo integer, p_medida integer, p_usuario integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null or p_nome is null) then
		return false;
	end if;

	auxiliar := situacao from cad_materiais where codigo = p_codigo;

	if (auxiliar is null) then
		return false;
	end if;

	update cad_materiais set nome = p_nome,
				descricao = p_descricao,
				fornecedor = p_fornecedor,
				tipo = p_tipo,
				medida = p_medida,
				usuario = p_usuario
				where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_material(integer, character varying, character varying, integer, integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date)

-- DROP FUNCTION dsoft_altera_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_altera_motorista(p_nome character varying, p_cpf bigint, p_endereco character varying, p_cidade character varying, p_estado character varying, p_telefone character varying, p_habilitacao character varying, p_nacimento date)
  RETURNS boolean AS
$BODY$

begin

	select nome from cad_motoristas where cpf = p_cpf;

	if (not found) then
		return false;
	end if;

	update cad_motoristas set nome = p_nome,
				endereco = p_endereco,
				cidade = p_cidade,
				estado = p_estado,
				telefone = p_telefone,
				habilitacao = p_habilitacao,
				nascimento = p_nascimento
				where cpf = p_cpf;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_altera_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision, integer)

-- DROP FUNCTION dsoft_altera_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_ordem_transporte(p_ordem integer, p_natureza character varying, p_qtd double precision, p_especie character varying, p_peso double precision, p_m3l double precision, p_nota_fiscal character varying, p_serie character varying, p_valor_mercadoria double precision, p_valor_frete double precision, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set natureza_mercadoria = p_natureza,
				quantidade = p_qtd,
				especie = p_especie,
				peso = p_peso,
				m3l = p_m3l,
				nota_fiscal = p_nota_fiscal,
				serie = p_serie,
				valor_mercadoria = p_valor_mercadoria,
				valor_frete = p_valor_frete,
				alterada_data = now(),
				alterada_hora = now(),
				alterada_usuario = p_usuario
				where indice = p_ordem;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_pagamento(integer, integer, integer, numeric, integer, character varying, date)

-- DROP FUNCTION dsoft_altera_pagamento(integer, integer, integer, numeric, integer, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_altera_pagamento(p_indice integer, p_usuario integer, p_caixa integer, p_valor numeric, p_recurso integer, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_recurso;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    update caixa_fluxo set caixa = p_caixa, valor = p_valor, usuario = p_usuario, recurso = p_recurso, observacao = p_observacao, data = p_data
    	where indice = p_indice;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_pagamento(integer, integer, integer, numeric, integer, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_altera_preco(bigint, integer, numeric, integer)

-- DROP FUNCTION dsoft_altera_preco(bigint, integer, numeric, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_preco(cod_produto bigint, cod_tabela integer, preco_atual numeric, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_produto < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_produtos where codigo = cod_produto limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    if (preco_atual is null) then
    	return CAMPO_INVALIDO || ' preco'::text;
    end if;
    
    update produtos_precos set preco = preco_atual,
    							alterado = now(),
                                usuario = cod_usuario
                                where produto = cod_produto and tabela = cod_tabela;

	return OPERACAO_CONCLUIDA;    

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_preco(bigint, integer, numeric, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer)

-- DROP FUNCTION dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_produto(cod_produto bigint, nome_produto character varying, tipo_produto integer, grupo_produto integer, descr_produto character varying, _grupo_tributario integer, _medida integer, p_producao boolean, p_fornecedor bigint, p_foto character varying, p_ncm character varying, p_cfop character varying, p_ean character varying, p_ean_trib character varying, p_med_trib integer, p_qtd_trib integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO 	varchar := 'ERRO_10';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare ERRO_NA_INCLUSAO	varchar := 'ERRO_07';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar		varchar;

declare p_tipo			integer;
declare p_grupo			integer;
declare p_grupo_tributario	integer;
declare p_medida		integer;

begin

	auxiliar := nome from cad_produtos where codigo = cod_produto limit 1;
    
	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO;
	end if;

	if (cod_produto < 1 or cod_produto is null) then
		return CODIGO_INVALIDO;
	end if;

	if (nome_produto is NULL) then
		return CAMPO_INVALIDO || " nome"::text;
	end if;

	if (tipo_produto = 0) then
		p_tipo := null;
	else
		p_tipo = tipo_produto;
	end if;

	if (grupo_produto = 0) then
		p_grupo := null;
	else
		p_grupo := grupo_produto;
	end if;

	if (_grupo_tributario = 0) then
		p_grupo_tributario := null;
	else
		p_grupo_tributario := _grupo_tributario;
	end if;

	if (_medida = 0) then
		p_medida := null;
	else
		p_medida := _medida;
	end if;

	update cad_produtos set nome = nome_produto,
				tipo = p_tipo,
				grupo = p_grupo,
				descricao = descr_produto,
				grupo_tributario = p_grupo_tributario,
				medida = p_medida,
				producao = p_producao,
				fornecedor = p_fornecedor,
				foto = p_foto,
				ncm = p_ncm,
				cfop = p_cfop,
				ean = p_ean,
				ean_trib = p_ean_trib,
				medida_tributavel = p_med_trib,
				quantidade_tributavel = p_qtd_trib
				where codigo = cod_produto;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint)

-- DROP FUNCTION dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint);

CREATE OR REPLACE FUNCTION dsoft_altera_produto(cod_produto bigint, nome_produto character varying, tipo_produto integer, grupo_produto integer, descr_produto character varying, _grupo_tributario integer, _medida integer, p_producao boolean, p_fornecedor bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO 	varchar := 'ERRO_10';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare ERRO_NA_INCLUSAO	varchar := 'ERRO_07';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar		varchar;

declare p_tipo			integer;
declare p_grupo			integer;
declare p_grupo_tributario	integer;
declare p_medida		integer;

begin

	auxiliar := nome from cad_produtos where codigo = cod_produto limit 1;
    
	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO;
	end if;

	if (cod_produto < 1 or cod_produto is null) then
		return CODIGO_INVALIDO;
	end if;

	if (nome_produto is NULL) then
		return CAMPO_INVALIDO || " nome"::text;
	end if;

	if (tipo_produto = 0) then
		p_tipo := null;
	else
		p_tipo = tipo_produto;
	end if;

	if (grupo_produto = 0) then
		p_grupo := null;
	else
		p_grupo := grupo_produto;
	end if;

	if (_grupo_tributario = 0) then
		p_grupo_tributario := null;
	else
		p_grupo_tributario := _grupo_tributario;
	end if;

	if (_medida = 0) then
		p_medida := null;
	else
		p_medida := _medida;
	end if;

	update cad_produtos set nome = nome_produto,
				tipo = p_tipo,
				grupo = p_grupo,
				descricao = descr_produto,
				grupo_tributario = p_grupo_tributario,
				medida = p_medida,
				producao = p_producao,
				fornecedor = p_fornecedor
				where codigo = cod_produto;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint)
  OWNER TO postgres;


-- Function: dsoft_altera_produto_grupo(integer, character varying)

-- DROP FUNCTION dsoft_altera_produto_grupo(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_produto_grupo(p_codigo integer, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null)then
    	return false;
    end if;
    
	auxiliar := situacao from produtos_grupos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    if (p_descricao is null) then
    	return false;
    end if;
    
    update produtos_grupos set descricao = p_descricao
    	where codigo = p_codigo;

	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_produto_grupo(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer)

-- DROP FUNCTION dsoft_altera_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_produto_tipo(p_codigo integer, p_nome character varying, p_descricao character varying, p_producao boolean, p_estoque boolean, p_soma boolean, p_impressora integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null or p_nome is null) then
		return false;
	end if;

	auxiliar := situacao from produtos_tipos where codigo = p_codigo;

	if (auxiliar is null) then
		return false;
	end if;

	update produtos_tipos set nome = p_nome,
    				descricao = p_descricao,
                                producao = p_producao,
                                estoque = p_estoque,
                                soma = p_soma,
								impressora_externa = p_impressora
                                where codigo = p_codigo;
        
	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_altera_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_recurso(p_codigo integer, p_nome character varying, p_tipo character, cod_usuario integer, p_nascimento date, p_tel1 bigint, p_tel2 bigint, p_celular bigint, p_endereco character varying, p_cidade character varying, p_estado character varying, p_rg character varying, p_cpf character varying, p_habilitacao character varying, p_categoria character varying)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO;
    end if;
    
    update cad_recursos set nome = p_nome,
				tipo = p_tipo,
				nascimento = p_nascimento,
				tel1 = p_tel1,
				tel2 = p_tel2,
				celular = p_celular,
				endereco = p_endereco,
				cidade = p_cidade,
				estado = p_estado,
				alterado = now(),
				alterado_usuario = cod_usuario,
				rg = p_rg,
				cpf = p_cpf,
				habilitacao = p_habilitacao,
				categoria = p_categoria
				where codigo = p_codigo;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric)

-- DROP FUNCTION dsoft_altera_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric);

CREATE OR REPLACE FUNCTION dsoft_altera_recurso_tipo(p_codigo character, p_descricao character varying, p_entrega boolean, p_producao boolean, p_com_dia numeric, p_com_nom numeric, p_fixo_sem numeric, p_fixo_mes numeric, p_valor_entrega numeric)
  RETURNS boolean AS
$BODY$
declare auxiliar varchar;

begin

	if (p_codigo is null) then
    	return false;
    end if;
    
	auxiliar := descricao from recursos_tipos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    update recursos_tipos set descricao = p_descricao,
                                entrega = p_entrega,
                                producao = p_producao,
                                comissao_diaria = p_com_dia,
                                comissao_nominal = p_com_nom,
                                fixo_semanal = p_fixo_sem,
                                fixo_mensal = p_fixo_mes,
                                valor_entrega = p_valor_entrega
                                where codigo = p_codigo;
                                
	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric)
  OWNER TO postgres;


-- Function: dsoft_altera_saida(integer, integer, integer, numeric, character varying, date)

-- DROP FUNCTION dsoft_altera_saida(integer, integer, integer, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_altera_saida(p_indice integer, p_usuario integer, p_caixa integer, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    update caixa_fluxo set caixa = p_caixa, valor = p_valor, usuario = p_usuario, observacao = p_observacao, data = p_data
    	where indice = p_indice;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_saida(integer, integer, integer, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_altera_tabela(integer, character varying, character varying, integer)

-- DROP FUNCTION dsoft_altera_tabela(integer, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_altera_tabela(cod_tabela integer, nome_tabela character varying, descr_tabela character varying, p_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_04';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				varchar;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := nome from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (nome_tabela is null) then
    	return CAMPO_INVALIDO || ' nome'::text;
    end if;
    
    if (p_usuario < 1) then
    	return CAMPO_INVALIDO || ' usuario'::text;
    end if;
    
    auxiliar := nome from cad_usuarios where codigo = p_usuario limit 1;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' usuario'::text;
    end if;
    
    update cad_tabelas set nome = nome_tabela,
    						descricao = descr_tabela,
                            alterada = now(),
                            alterada_usuario = p_usuario
                            where codigo = cod_tabela;
                            
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_tabela(integer, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_altera_tipo_clientes(integer, character varying)

-- DROP FUNCTION dsoft_altera_tipo_clientes(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_tipo_clientes(p_codigo integer, p_nome character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	auxiliar := situacao from clientes_tipos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    if (p_nome is null) then
    	return false;
    end if;
    
    update clientes_tipos set nome = p_nome where codigo = p_codigo;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_tipo_clientes(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_altera_usuario(integer, character varying, character varying, character)

-- DROP FUNCTION dsoft_altera_usuario(integer, character varying, character varying, character);

CREATE OR REPLACE FUNCTION dsoft_altera_usuario(cod_usuario integer, nome_usuario character varying, senha_usuario character varying, nivel_usuario character)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO	varchar := 'ERRO_00';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				varchar;

begin

	auxiliar := nome from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_NAO_ENCONTRADO;
    end if;

	if (nome_usuario is null) then
    	return CAMPO_INVALIDO || ' nome'::text;
    end if;
    
    if (senha_usuario is null) then
    	return CAMPO_INVALIDO || ' senha'::text;
    end if;
    
    if (nivel_usuario is null) then
    	return CAMPO_INVALIDO || ' nivel'::text;
    end if;
    
    update cad_usuarios set nome = nome_usuario,
    						senha = senha_usuario,
                            nivel = nivel_usuario,
                            alterado = now()
                            where codigo = cod_usuario;
                            
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_usuario(integer, character varying, character varying, character)
  OWNER TO postgres;


-- Function: dsoft_altera_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_altera_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_veiculo(p_placa character varying, p_modelo character varying, p_ano integer, p_cor character varying, p_marca character varying, p_proprietario character varying, p_endereco character varying, p_cidade character varying, p_estado character varying, p_telefone character varying, p_cpf character varying, p_renavam character varying)
  RETURNS boolean AS
$BODY$

begin

	perform modelo from cad_veiculos where placa = p_placa;

	if (not found) then
		return false;
	end if;

	update cad_veiculos set modelo = p_modelo,
				ano = p_ano,
				cor = p_cor,
				marca = p_marca,
				proprietario = p_proprietario,
				endereco = p_endereco,
				cidade = p_cidade,
				estado = p_estado,
				telefone = p_telefone,
				cpf = p_cpf,
				renavam = p_renavam
				where placa = p_placa;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_atualiza_estoque(bigint, double precision, integer)

-- DROP FUNCTION dsoft_atualiza_estoque(bigint, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_atualiza_estoque(p_produto bigint, p_quantidade double precision, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	update estoque set quantidade = p_quantidade where produto = p_produto and local = 1;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_atualiza_estoque(bigint, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_cliente(bigint, integer)

-- DROP FUNCTION dsoft_bloqueia_cliente(bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_cliente(cod_cliente bigint, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare CLIENTE_CANCELADO		varchar := 'ERRO_20';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (cod_cliente is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = cod_cliente;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    elseif (auxiliar = 'B') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return CLIENTE_CANCELADO;
    end if;
    
	update cad_clientes set situacao = 'B',
    						bloqueado = now(),
                            bloqueado_usuario = cod_usuario
                            where codigo = cod_cliente;
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_cliente(bigint, integer)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_pedido(integer, character varying, integer)

-- DROP FUNCTION dsoft_bloqueia_pedido(integer, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_pedido(p_pedido integer, motivo character varying, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_pedido < 1) then
    	return CAMPO_INVALIDO || ' pedido'::text;
    end if;
    
    auxiliar := situacao from pedidos where indice = p_pedido limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO || ' pedido'::text;
    elseif (auxiliar = 'B') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return PEDIDO_CANCELADO;
    elseif (auxiliar = 'E' or auxiliar = 'S') then
    	return OPERACAO_NEGADA;
    elseif (auxiliar = 'N' or auxiliar = 'O' or auxiliar = 'P') then
    	return OPERACAO_NEGADA;
    end if;
    
    if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    update pedidos set situacao = 'B',
    					bloqueado = now(),
                        bloqueado_usuario = cod_usuario,
                        observacao = motivo
                        where indice = p_pedido;
                        
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_pedido(integer, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_produto(bigint)

-- DROP FUNCTION dsoft_bloqueia_produto(bigint);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_produto(cod_produto bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO varchar := 'ERRO_10';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar			char;

begin

	auxiliar := situacao from cad_produtos where codigo = cod_produto limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'C') then
    	return PRODUTO_CANCELADO;
    end if;
    
    if (auxiliar = 'B') then
    	return PRODUTO_BLOQUEADO;
    end if;
    
    if (cod_produto < 1 or cod_produto is null) then
    	return CODIGO_INVALIDO;
    end if;
    
	update cad_produtos set situacao = 'B',
    						bloqueado = now()
                            where codigo = cod_produto;
        
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_produto(bigint)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_recurso(integer, integer)

-- DROP FUNCTION dsoft_bloqueia_recurso(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_recurso(p_codigo integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare RECURSO_BLOQUEADO		varchar := 'ERRO_20';
declare RECURSO_CANCELADO		varchar := 'ERRO_21';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return RECURSO_CANCELADO;
    end if;    	
    
    update cad_recursos set situacao = 'B',
    			bloqueado = now(),
                bloqueado_usuario = cod_usuario
				where codigo = p_codigo;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_recurso(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_tabela(integer, integer)

-- DROP FUNCTION dsoft_bloqueia_tabela(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_tabela(cod_tabela integer, usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare TABELA_CANCELADA		varchar := 'ERRO_13';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    elseif (auxiliar = 'C') then
    	return TABELA_CANCELADA;
    elseif (auxiliar = 'B') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    update cad_tabelas set situacao = 'B',
    						bloqueada = now(),
                            bloqueada_usuario = usuario
                            where codigo = cod_tabela;

	return OPERACAO_CONCLUIDA;    

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_tabela(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_bloqueia_usuario(integer)

-- DROP FUNCTION dsoft_bloqueia_usuario(integer);

CREATE OR REPLACE FUNCTION dsoft_bloqueia_usuario(cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO 	varchar := 'ERRO_00';
declare USUARIO_CANCELADO      	varchar := 'ERRO_02';
declare USUARIO_JA_BLOQUEADO   	varchar := 'ERRO_08';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare sit_usuario char;
  
BEGIN

	sit_usuario := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (sit_usuario is null) then
    	return USUARIO_NAO_ENCONTRADO;
    end if;
    
    if (sit_usuario = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (sit_usuario = 'B') then
    	return USUARIO_JA_BLOQUEADO;
    end if;
    
    if (cod_usuario = 1) then
    	return OPERACAO_NEGADA;
    end if;
    
    update cad_usuarios set situacao = 'B', bloqueado = now() where codigo = cod_usuario;
    
    return OPERACAO_CONCLUIDA;    
  
END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_bloqueia_usuario(integer)
  OWNER TO postgres;


-- Function: dsoft_busca_repetidos()

-- DROP FUNCTION dsoft_busca_repetidos();

CREATE OR REPLACE FUNCTION dsoft_busca_repetidos()
  RETURNS bigint AS
$BODY$
declare _cursor refcursor;
_ant bigint;
_atual bigint;

begin
	_ant := 0;

	open _cursor for select cod from temp order by cod;
	fetch _cursor into _atual;

	while(_cursor is not null) loop
		if (_atual = _ant) then
			return _atual;
		end if;

		_ant := _atual;

		fetch _cursor into _atual;

	end loop;
	
	return 0;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_busca_repetidos()
  OWNER TO postgres;


-- Function: dsoft_busca_repetidos2()

-- DROP FUNCTION dsoft_busca_repetidos2();

CREATE OR REPLACE FUNCTION dsoft_busca_repetidos2()
  RETURNS character varying AS
$BODY$
declare _cursor refcursor;
_ant bigint;
_atual bigint;
_resp varchar;
begin
	_resp := '';
	_ant := 0;

	open _cursor for select cod from temp order by cod;
	fetch _cursor into _atual;

	while(_atual is not null) loop
		if (_atual = _ant) then
			_resp := _resp || ',' || to_char(_atual, '99999999999');
		end if;

		_ant := _atual;

		fetch _cursor into _atual;

	end loop;
	
	return _resp;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_busca_repetidos2()
  OWNER TO postgres;


-- Function: dsoft_caixa_aberto()

-- DROP FUNCTION dsoft_caixa_aberto();

CREATE OR REPLACE FUNCTION dsoft_caixa_aberto()
  RETURNS boolean AS
$BODY$
begin
	perform indice from caixa_fluxo where situacao = 'A';

	return FOUND;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_caixa_aberto()
  OWNER TO postgres;


-- Function: dsoft_cancela_cliente(bigint, integer)

-- DROP FUNCTION dsoft_cancela_cliente(bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_cliente(cod_cliente bigint, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare CLIENTE_CANCELADO		varchar := 'ERRO_20';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (cod_cliente is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = cod_cliente;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    elseif (auxiliar = 'C') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
	update cad_clientes set situacao = 'C',
    						cancelado = now(),
                            cancelado_usuario = cod_usuario
                            where codigo = cod_cliente;
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_cliente(bigint, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_crediario(integer, integer)

-- DROP FUNCTION dsoft_cancela_crediario(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_crediario(p_crediario integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare _sit char;
begin

	perform indice from pagamentos where pedido = p_crediario and situacao = 'A' limit 1;

	if (not FOUND) then
		return false;
	end if;

	perform indice from pagamentos where pedido = p_crediario and (situacao = 'P' or situacao = 'R') limit 1;

	if (FOUND) then
		return false;
	end if;

	
	update pagamentos set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where pedido = p_crediario and situacao = 'A';

	_sit := situacao from pedidos where indice = p_crediario;

	if (_sit = 'N') then
		update pedidos set situacao = 'A' where indice = p_crediario;
	elseif (_sit = 'P') then
		update pedidos set situacao = 'E' where indice = p_crediario;
	elseif (_sit = 'O') then
		update pedidos set situacao = 'S' where indice = p_crediario;
	end if;

	return true;
	
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_crediario(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_despesa(integer, integer)

-- DROP FUNCTION dsoft_cancela_despesa(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_despesa(p_usuario integer, p_despesa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_pagamento		integer;

begin

	auxiliar := situacao from despesas where indice = p_despesa;
    
    if (auxiliar is null or auxiliar = 'C' or auxiliar = 'F') then
    	return false;
    end if;

	update despesas set situacao = 'C',
    					cancelado = now(),
                        cancelado_usuario = p_usuario
                        where indice = p_despesa;
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_despesa(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_emitente(bigint)

-- DROP FUNCTION dsoft_cancela_emitente(bigint);

CREATE OR REPLACE FUNCTION dsoft_cancela_emitente(p_cnpj bigint)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (not found) then
		return false;
	end if;

	update cad_emitentes set situacao = 'C'
				where cnpj = p_cnpj;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_emitente(bigint)
  OWNER TO postgres;


-- Function: dsoft_cancela_entrada(integer, integer, integer)

-- DROP FUNCTION dsoft_cancela_entrada(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_entrada(p_indice integer, p_usuario integer, p_caixa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;
declare n_valor		double precision;
declare n_cliente	bigint;
declare n_pagamento	integer;
declare n_promissoria	bigint;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null or auxiliar <> 'A') then
		return false;
	end if;

	auxiliar := situacao from cad_caixa where codigo = p_caixa;

	if (auxiliar is null or auxiliar <> 'A') then
		return false;
	end if;

	auxiliar := situacao from caixa_fluxo where indice = p_indice;

	if (auxiliar is null) then
		return false;
	end if;

	if (auxiliar <> 'A') then
		return false; -- So podemos cancelar se tiver em aberto.
	end if;

	update caixa_fluxo set situacao = 'C', cancelado_data = now(), cancelado_hora = now(), cancelado_usuario = p_usuario
		where indice = p_indice;

	-- Verificamos se foi gerado a partir de um pagamento para cancelar tambem
	n_pagamento := pagamento from caixa_fluxo where indice = p_indice;

	if (n_pagamento is not null) then
		perform dsoft_cancela_pagamento(n_pagamento, p_usuario, 'CANCELADO NO CONTROLE FINANCEIRO');
	end if;

	-- Cancelamos o pagamento se foi lançado
	update pagamentos set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where caixa_fluxo = p_indice;

	-- Verificamos se foi o pagamento de uma promissória para retornar o status
	n_promissoria := prestacao from caixa_fluxo where indice = p_indice;

	if (n_promissoria is not null) then
		n_valor := valor from caixa_fluxo where indice = p_indice;

		update pagamentos set total_pago = (total_pago - n_valor) where numero = n_promissoria;

		if ((select total_pago from pagamentos where numero = n_promissoria) = 0) then
			update pagamentos set situacao = 'A' where numero = n_promissoria;
		else
			update pagamentos set situacao = 'R' where numero = n_promissoria;
		end if;
	end if;

	auxiliar := tipo from caixa_fluxo where indice = p_indice;

	if (auxiliar = 'E') then
		n_valor := valor from caixa_fluxo where indice = p_indice;
		n_cliente := cliente from caixa_fluxo where indice = p_indice;

		if (n_cliente is not null) then
			update cad_clientes set saldo = saldo - n_valor where codigo = n_cliente;
		end if;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_entrada(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_grupo_tributario(integer, integer)

-- DROP FUNCTION dsoft_cancela_grupo_tributario(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_grupo_tributario(p_codigo integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	if (p_codigo is null or p_codigo = 0) then
		return false;
	end if;

	perform nome from grupos_tributarios where codigo = p_codigo;

	if (not found) then
		return false;
	end if;

	update grupos_tributarios set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_grupo_tributario(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_local(integer)

-- DROP FUNCTION dsoft_cancela_local(integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_local(p_codigo integer)
  RETURNS boolean AS
$BODY$

begin

	update locais set situacao = 'C'
			where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_local(integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_material(integer)

-- DROP FUNCTION dsoft_cancela_material(integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_material(cod_material integer)
  RETURNS boolean AS
$BODY$

declare auxiliar		char;

begin

	auxiliar := situacao from cad_materiais where codigo = cod_material limit 1;

	if (auxiliar is null) then
		return false;
	end if;

	if (auxiliar = 'C') then
		return false;
	end if;

	if (cod_material < 1 or cod_material is null) then
		return false;
	end if;

	update cad_materiais set situacao = 'C',
		cancelado = now()
		where codigo = cod_material;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_material(integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_motorista(bigint)

-- DROP FUNCTION dsoft_cancela_motorista(bigint);

CREATE OR REPLACE FUNCTION dsoft_cancela_motorista(p_cpf bigint)
  RETURNS boolean AS
$BODY$

begin

	select nome from cad_motoristas where cpf = p_cpf;

	if (not found) then
		return false;
	end if;

	update cad_motoristas set situacao = 'C'
				where cpf = p_cpf;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_motorista(bigint)
  OWNER TO postgres;


-- Function: dsoft_cancela_ocorrencia(integer, integer, character varying)

-- DROP FUNCTION dsoft_cancela_ocorrencia(integer, integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_cancela_ocorrencia(p_ocorrencia integer, p_usuario integer, p_motivo character varying)
  RETURNS boolean AS
$BODY$

declare p_aux char;

begin

	if (p_usuario is null) then
		return false;
	end if;

	p_aux := situacao from cad_usuarios where codigo = p_usuario;

	if (p_aux is null or p_aux <> 'A') then
		return false;
	end if;

	p_aux := situacao from ocorrencias where indice = p_ocorrencia;

	if (p_aux is null or p_aux <> 'A') then
		return false;
	end if;

	update ocorrencias set cancelada = now(), situacao = 'C', motivo = p_motivo, cancelada_usuario = p_usuario
		where indice = p_ocorrencia;

	return true;

end;

$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_ocorrencia(integer, integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_cancela_pagamento(integer, integer, character varying)

-- DROP FUNCTION dsoft_cancela_pagamento(integer, integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_cancela_pagamento(p_pagamento integer, cod_usuario integer, p_motivo character varying)
  RETURNS boolean AS
$BODY$

declare auxiliar character;
declare n_pedido integer;
declare total_ double precision;
declare valor_pedido double precision;
declare n_promissoria bigint;

begin

	if (cod_usuario < 1) then
		return false;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario;

	if (auxiliar is null) then
		return false;
	elseif (auxiliar = 'B') then
		return false;
	elseif (auxiliar = 'C') then
		return false;
	end if;

	if (p_pagamento < 1) then
		return false;
	end if;

	auxiliar := situacao from pagamentos where indice = p_pagamento;

	if (auxiliar <> 'A') then
		return false;
	end if;

	update pagamentos set situacao = 'C', cancelado = now(), cancelado_usuario = cod_usuario
		where indice = p_pagamento;

	-- Verificamos se foi pagamento de promissória para retornar o status
	--n_promissoria := promissoria from pagamentos where indice = p_pagamento;

	--if (n_promissoria is not null) then
	--	total_ := valor from pagamentos where indice = p_pagamento;
		
	--	update pagamentos set total_pago = (total_pago - total_) where numero = n_promissoria;

	--	if ((select total_pago from pagamentos where numero = n_promissoria) = 0) then
	--		update pagamentos set situacao = 'A' where numero = n_promissoria;
	--	else
	--		update pagamentos set situacao = 'R' where numero = n_promissoria;
	--	end if;
	--end if;

	-- Agora atualizamos o pedido
	n_pedido := pedido from pagamentos where indice = p_pagamento;

	auxiliar := situacao from pedidos where indice = n_pedido;

	if (auxiliar = 'N') then
		update pedidos set situacao = 'A' where indice = n_pedido;
	elseif (auxiliar = 'P') then
		update pedidos set situacao = 'E' where indice = n_pedido;
	elseif (auxiliar = 'O') then
		update pedidos set situacao = 'S' where indice = n_pedido;
	end if;

	-- E no caso de ser o último cupom fiscal, cancelamos também o cupom fiscal

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_pagamento(integer, integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_cancela_pedido(integer, character varying, integer)

-- DROP FUNCTION dsoft_cancela_pedido(integer, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_pedido(p_pedido integer, motivo character varying, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO		varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar			char;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;
    
	auxiliar := situacao from pedidos where indice = p_pedido limit 1;
    
	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'C') then
		return OPERACAO_CONCLUIDA;
	elseif (auxiliar = 'E' or auxiliar = 'S') then
		return OPERACAO_NEGADA;
	elseif (auxiliar = 'N' or auxiliar = 'O' or auxiliar = 'P') then
		return OPERACAO_NEGADA;
	end if;
    
	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;
    
	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;
    
	update pedidos set situacao = 'C',
		cancelado = now(),
		cancelado_usuario = cod_usuario,
		motivo_cancelamento = motivo
		where indice = p_pedido;
                        
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_pedido(integer, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_produto(bigint)

-- DROP FUNCTION dsoft_cancela_produto(bigint);

CREATE OR REPLACE FUNCTION dsoft_cancela_produto(cod_produto bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO varchar := 'ERRO_10';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar			char;

begin

	auxiliar := situacao from cad_produtos where codigo = cod_produto limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'C') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (cod_produto < 1 or cod_produto is null) then
    	return CODIGO_INVALIDO;
    end if;
    
	update cad_produtos set situacao = 'C',
    						cancelado = now()
                            where codigo = cod_produto;
        
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_produto(bigint)
  OWNER TO postgres;


-- Function: dsoft_cancela_recurso(integer, integer)

-- DROP FUNCTION dsoft_cancela_recurso(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_recurso(p_codigo integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare RECURSO_BLOQUEADO		varchar := 'ERRO_20';
declare RECURSO_CANCELADO		varchar := 'ERRO_21';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return OPERACAO_CONCLUIDA;
    end if;    	
    
    update cad_recursos set situacao = 'C',
    			cancelado = now(),
                cancelado_usuario = cod_usuario
				where codigo = p_codigo;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_recurso(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_tabela(integer, integer)

-- DROP FUNCTION dsoft_cancela_tabela(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_tabela(cod_tabela integer, usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare TABELA_CANCELADA		varchar := 'ERRO_13';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    elseif (auxiliar = 'C') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    update cad_tabelas set situacao = 'C',
    						cancelada = now(),
                            cancelada_usuario = usuario
                            where codigo = cod_tabela;

	return OPERACAO_CONCLUIDA;    

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_tabela(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_usuario(integer)

-- DROP FUNCTION dsoft_cancela_usuario(integer);

CREATE OR REPLACE FUNCTION dsoft_cancela_usuario(cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO	varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    update cad_usuarios set situacao = 'C', cancelado = now() where codigo = cod_usuario;
    
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_usuario(integer)
  OWNER TO postgres;


-- Function: dsoft_cancela_veiculo(character varying)

-- DROP FUNCTION dsoft_cancela_veiculo(character varying);

CREATE OR REPLACE FUNCTION dsoft_cancela_veiculo(p_placa character varying)
  RETURNS boolean AS
$BODY$

begin

	perform modelo from cad_veiculos where placa = p_placa;

	if (not found) then
		return false;
	end if;

	update cad_veiculos set situacao = 'C'
				where placa = p_placa;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cancela_veiculo(character varying)
  OWNER TO postgres;


-- Function: dsoft_cliente_codigo_prox()

-- DROP FUNCTION dsoft_cliente_codigo_prox();

CREATE OR REPLACE FUNCTION dsoft_cliente_codigo_prox()
  RETURNS bigint AS
$BODY$
 declare p_prox bigint;

 begin

	p_prox := codigo from cad_clientes order by codigo limit 1;

	if (p_prox is null) then
		p_prox := 1;
	end if;

	p_prox := p_prox + 1;

	return p_prox;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cliente_codigo_prox()
  OWNER TO postgres;


-- Function: dsoft_cliente_limite(bigint, double precision)

-- DROP FUNCTION dsoft_cliente_limite(bigint, double precision);

CREATE OR REPLACE FUNCTION dsoft_cliente_limite(p_cliente bigint, p_limite double precision)
  RETURNS boolean AS
$BODY$

begin

	update cad_clientes set credito_limite = p_limite where codigo = p_cliente;

	return true;
	
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cliente_limite(bigint, double precision)
  OWNER TO postgres;


-- Function: dsoft_cliente_limite(bigint)

-- DROP FUNCTION dsoft_cliente_limite(bigint);

CREATE OR REPLACE FUNCTION dsoft_cliente_limite(p_cliente bigint)
  RETURNS double precision AS
$BODY$

declare limite_cliente double precision;

begin

	limite_cliente := credito_limite from cad_clientes where codigo = p_cliente;

	if (limite_cliente is null) then
		return 0;
	end if;

	return limite_cliente;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cliente_limite(bigint)
  OWNER TO postgres;


-- Function: dsoft_cliente_saldo(bigint)

-- DROP FUNCTION dsoft_cliente_saldo(bigint);

CREATE OR REPLACE FUNCTION dsoft_cliente_saldo(p_cliente bigint)
  RETURNS double precision AS
$BODY$

declare saldo_cliente double precision;

begin

	saldo_cliente := saldo from cad_clientes where codigo = p_cliente;

	if (saldo_cliente is null) then
		return 0;
	end if;

	return saldo_cliente;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_cliente_saldo(bigint)
  OWNER TO postgres;


-- Function: dsoft_completar_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision)

-- DROP FUNCTION dsoft_completar_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision);

CREATE OR REPLACE FUNCTION dsoft_completar_ordem_transporte(p_indice integer, p_natureza character varying, p_qtd double precision, p_especie character varying, p_peso double precision, p_m3l double precision, p_nota_fiscal character varying, p_serie character varying, p_valor_mercadoria double precision, p_valor_frete double precision)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set natureza_mercadoria = p_natureza,
				quantidade = p_qtd,
				especie = p_especie,
				peso = p_peso,
				m3l = p_m3l,
				nota_fiscal = p_nota_fiscal,
				serie = p_serie,
				valor_mercadoria = p_valor_mercadoria,
				valor_frete = p_valor_frete
				where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_completar_ordem_transporte(integer, character varying, double precision, character varying, double precision, double precision, character varying, character varying, double precision, double precision)
  OWNER TO postgres;


-- Function: dsoft_confirma_entrega(integer, integer)

-- DROP FUNCTION dsoft_confirma_entrega(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_confirma_entrega(p_indice integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare aux character;
declare _produto bigint;
declare _quantidade integer;

begin

	aux := situacao from entregas_compras where indice = p_indice;

	if (aux is null or aux <> 'A') then
		return false;
	end if;

	_produto := produto from entregas_compras where indice = p_indice;
	_quantidade := quantidade from entregas_compras where indice = p_indice;

	update estoque set quantidade = quantidade + _quantidade where produto = _produto and local is null;

	update entregas_compras set entrega_data = now(), entrega_hora = now(), situacao = 'E', status = 'A' where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_confirma_entrega(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_confirma_pagamento(bigint, date, character varying, character varying, character varying, character varying, character varying, character varying, double precision[], integer, integer)

-- DROP FUNCTION dsoft_confirma_pagamento(bigint, date, character varying, character varying, character varying, character varying, character varying, character varying, double precision[], integer, integer);

CREATE OR REPLACE FUNCTION dsoft_confirma_pagamento(p_numero bigint, p_data date, p_forma1 character varying, p_forma2 character varying, p_forma3 character varying, p_doc1 character varying, p_doc2 character varying, p_doc3 character varying, p_valor double precision[], p_usuario integer, p_caixa integer)
  RETURNS boolean AS
$BODY$

declare aux character;
declare i integer;
declare qtd integer;
declare t_pago double precision;
declare a_pagar double precision;

begin

	aux := situacao from pagamentos where numero = p_numero;

	if (aux is null) then
		return false;
	end if;

	if (aux <> 'A' and aux <> 'R') then
		return false;
	end if;

	t_pago := 0;
	a_pagar := ((valor + multa + juros) - total_pago) from pagamentos where numero = p_numero;
	
	i := 0;
	qtd := 3; --lenght(p_forma);

	if (p_forma1 <> '0' and p_valor[1] > 0) then
		insert into pagamentos (promissoria,
			data,
			tipo,
			documento,
			valor,
			usuario)
			values (
			p_numero,
			p_data,
			p_forma1,
			p_doc1,
			(p_valor[1] / 100),
			p_usuario);

		insert into caixa_fluxo (tipo, valor, usuario, prestacao, caixa, observacao, forma)
			values ('E', (p_valor[1] / 100), p_usuario, p_numero, p_caixa, 'PAGAMENTO REFERENTE A PROMISSORIA N. ' || to_char(p_numero, '9999999999999999'), p_forma1);

		t_pago := t_pago + (p_valor[1] / 100);
	end if;

	
	if (p_forma2 <> '0' and p_valor[2] > 0) then
		insert into pagamentos (promissoria,
			data,
			tipo,
			documento,
			valor,
			usuario)
			values (
			p_numero,
			p_data,
			p_forma2,
			p_doc2,
			(p_valor[2] / 100),
			p_usuario);

		insert into caixa_fluxo (tipo, valor, usuario, prestacao, caixa, observacao, forma)
			values ('E', (p_valor[2] / 100), p_usuario, p_numero, p_caixa, 'PAGAMENTO REFERENTE A PROMISSORIA N. ' || to_char(p_numero, '9999999999999999'), p_forma2);

		t_pago := t_pago + (p_valor[2] / 100);
	end if;

	if (p_forma3 <> '0' and p_valor[3] > 0) then
		insert into pagamentos (promissoria,
			data,
			tipo,
			documento,
			valor,
			usuario)
			values (
			p_numero,
			p_data,
			p_forma3,
			p_doc3,
			(p_valor[3] / 100),
			p_usuario);

		insert into caixa_fluxo (tipo, valor, usuario, prestacao, caixa, observacao, forma)
			values ('E', (p_valor[3] / 100), p_usuario, p_numero, p_caixa, 'PAGAMENTO REFERENTE A PROMISSORIA N. ' || to_char(p_numero, '9999999999999999'), p_forma3);

		t_pago := t_pago + (p_valor[3] / 100);
	end if;
	
	if (t_pago = a_pagar) then
		update pagamentos set situacao = 'P', total_pago = (total_pago + t_pago), pago_data = p_data, pago_hora = now(), pago_usuario = p_usuario where numero = p_numero;
	else
		update pagamentos set situacao = 'R', total_pago = (total_pago + t_pago), pago_data = p_data, pago_hora = now(), pago_usuario = p_usuario where numero = p_numero;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_confirma_pagamento(bigint, date, character varying, character varying, character varying, character varying, character varying, character varying, double precision[], integer, integer)
  OWNER TO postgres;


-- Function: dsoft_confirma_pagamento(bigint, date, character varying[], character varying[], double precision[], integer, integer)

-- DROP FUNCTION dsoft_confirma_pagamento(bigint, date, character varying[], character varying[], double precision[], integer, integer);

CREATE OR REPLACE FUNCTION dsoft_confirma_pagamento(p_numero bigint, p_data date, p_forma character varying[], p_doc character varying[], p_valor double precision[], p_usuario integer, p_caixa integer)
  RETURNS boolean AS
$BODY$

declare aux character;
declare i integer;
declare qtd integer;
declare t_pago double precision;
declare a_pagar double precision;

begin

	aux := situacao from pagamentos where numero = p_numero;

	if (aux is null) then
		return false;
	end if;

	if (aux <> 'A' and aux <> 'R') then
		return false;
	end if;

	t_pago := 0;
	a_pagar := ((valor + multa + juros) - total_pago) from pagamentos where numero = p_numero;
	
	i := 0;
	qtd := 3; --lenght(p_forma);

	for i in 1..3 loop
		if (p_forma[i] <> '0' and p_valor[i] > 0) then
			insert into pagamentos (promissoria,
				data,
				--tipo,
				documento,
				valor,
				usuario)
				values (
				p_numero,
				p_data,
				--p_forma[i],
				p_doc[i],
				(p_valor[i] / 100),
				p_usuario);

			insert into caixa_fluxo (tipo, valor, usuario, prestacao, caixa, observacao, forma)
				values ('E', (p_valor[i] / 100), p_usuario, p_numero, p_caixa, 'PAGAMENTO REFERENTE A PROMISSORIA N. ' || to_char(p_numero, '9999999999999999'), p_forma[i]);

			t_pago := t_pago + (p_valor[i] / 100);
		end if;
	end loop;

	if (t_pago = a_pagar) then
		update pagamentos set situacao = 'P', total_pago = (total_pago + t_pago), pago_data = p_data, pago_hora = now(), pago_usuario = p_usuario where numero = p_numero;
	else
		update pagamentos set situacao = 'R', total_pago = (total_pago + t_pago), pago_data = p_data, pago_hora = now(), pago_usuario = p_usuario where numero = p_numero;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_confirma_pagamento(bigint, date, character varying[], character varying[], double precision[], integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_cliente(bigint, integer)

-- DROP FUNCTION dsoft_desbloqueia_cliente(bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_cliente(cod_cliente bigint, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare CLIENTE_CANCELADO		varchar := 'ERRO_20';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (cod_cliente is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = cod_cliente;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return CLIENTE_CANCELADO;
    end if;
    
	update cad_clientes set situacao = 'A',
    						bloqueado = now(),
                            bloqueado_usuario = cod_usuario
                            where codigo = cod_cliente;
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_cliente(bigint, integer)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_pedido(integer, integer)

-- DROP FUNCTION dsoft_desbloqueia_pedido(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_pedido(p_pedido integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_pedido < 1) then
    	return CAMPO_INVALIDO || ' pedido'::text;
    end if;
    
    auxiliar := situacao from pedidos where indice = p_pedido limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO || ' pedido'::text;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return PEDIDO_CANCELADO;
    end if;
    
    if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    update pedidos set situacao = 'A',
    					bloqueado = now(),
                        bloqueado_usuario = cod_usuario
                        where indice = p_pedido;
                        
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_pedido(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_produto(bigint)

-- DROP FUNCTION dsoft_desbloqueia_produto(bigint);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_produto(cod_produto bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO varchar := 'ERRO_10';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar			char;

begin

	auxiliar := situacao from cad_produtos where codigo = cod_produto limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'C') then
    	return PRODUTO_CANCELADO;
    end if;
    
    if (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (cod_produto < 1 or cod_produto is null) then
    	return CODIGO_INVALIDO;
    end if;
    
	update cad_produtos set situacao = 'A',
    						bloqueado = now()
                            where codigo = cod_produto;
        
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_produto(bigint)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_recurso(integer, integer)

-- DROP FUNCTION dsoft_desbloqueia_recurso(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_recurso(p_codigo integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare RECURSO_BLOQUEADO		varchar := 'ERRO_20';
declare RECURSO_CANCELADO		varchar := 'ERRO_21';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'C') then
    	return RECURSO_CANCELADO;
    end if;    	
    
    update cad_recursos set situacao = 'A',
    			bloqueado = now(),
                bloqueado_usuario = cod_usuario
				where codigo = p_codigo;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_recurso(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_tabela(integer, integer)

-- DROP FUNCTION dsoft_desbloqueia_tabela(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_tabela(cod_tabela integer, usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare TABELA_CANCELADA		varchar := 'ERRO_13';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    elseif (auxiliar = 'C') then
    	return TABELA_CANCELADA;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    update cad_tabelas set situacao = 'A',
    						bloqueada = now(),
                            bloqueada_usuario = usuario
                            where codigo = cod_tabela;

	return OPERACAO_CONCLUIDA;    

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_tabela(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desbloqueia_usuario(integer)

-- DROP FUNCTION dsoft_desbloqueia_usuario(integer);

CREATE OR REPLACE FUNCTION dsoft_desbloqueia_usuario(cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO	varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    update cad_usuarios set situacao = 'A', bloqueado = now() where codigo = cod_usuario;
    
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desbloqueia_usuario(integer)
  OWNER TO postgres;


-- Function: dsoft_desfaz_compra(integer, integer, integer)

-- DROP FUNCTION dsoft_desfaz_compra(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desfaz_compra(p_usuario integer, p_compra integer, p_caixa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_valor			numeric;
declare situacao_atual	char;

begin

	auxiliar := situacao from compras where indice = p_compra;
    
    --Se está em aberto, então não precisa fazer nada
    --Se está apenas entregue, não podemos fazer nada também
    --Se já está fechado, não podemos fazer nada mesmo
    if (auxiliar is null or auxiliar = 'A' or auxiliar = 'E' or auxiliar = 'F') then
    	return false;
    end if;
    
    if (auxiliar = 'N') then
    	situacao_atual := 'A';
    elseif (auxiliar = 'P') then
    	situacao_atual := 'E';
    end if;

	update compras set situacao = situacao_atual,
    					pagamento = now(),
                        pagamento_usuario = p_usuario,
                        valor_pago = 0
                        where indice = p_compra;
                        
	update caixa_fluxo set situacao = 'C'
    	where compra = p_compra and caixa = p_caixa;
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desfaz_compra(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desfaz_despesa(integer, integer)

-- DROP FUNCTION dsoft_desfaz_despesa(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desfaz_despesa(p_usuario integer, p_despesa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_pagamento		integer;

begin

	auxiliar := situacao from despesas where indice = p_despesa;
    
    if (auxiliar is null or auxiliar = 'C' or auxiliar = 'A' or auxiliar = 'F' or auxiliar = 'V') then
    	return false;
    end if;

	update despesas set situacao = 'A',
    					pagamento = now(),
                        pagamento_usuario = p_usuario,
                        valor_pago = 0
                        where indice = p_despesa;
                        
    update caixa_fluxo set situacao = 'C' where despesa = p_despesa and situacao = 'A';
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desfaz_despesa(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desfaz_fechamento(integer, integer)

-- DROP FUNCTION dsoft_desfaz_fechamento(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desfaz_fechamento(p_fechamento integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare n_numero integer;

begin

	n_numero := count(indice) from resumos where indice = p_fechamento and situacao = 'A';

	if (n_numero is null or n_numero = 0) then
		return false;
	end if;

	update resumos set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where indice = p_fechamento;

	update caixa set situacao = 'A', fechamento = null where fechamento = p_fechamento;

	update pedidos set fechamento = null where fechamento = p_fechamento;

	update despesas set fechamento = null, situacao = 'P' where fechamento = p_fechamento;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desfaz_fechamento(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_desvincula_produto_material(integer, integer, integer)

-- DROP FUNCTION dsoft_desvincula_produto_material(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desvincula_produto_material(cod_produto integer, cod_material integer, cod_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	perform nome from cad_produtos where codigo = cod_produto;

	if (not found) then
		return false;
	end if;

	perform nome from cad_materiais where codigo = cod_material;

	if (not found) then
		return false;
	end if;

	delete from produtos_materiais where produto = cod_produto and material = cod_material;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desvincula_produto_material(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_encerra_ocorrencia(integer, integer, character varying)

-- DROP FUNCTION dsoft_encerra_ocorrencia(integer, integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_encerra_ocorrencia(p_ocorrencia integer, p_usuario integer, p_conclusao character varying)
  RETURNS boolean AS
$BODY$

declare p_aux char;

begin

	if (p_usuario is null) then
		return false;
	end if;

	p_aux := situacao from cad_usuarios where codigo = p_usuario;

	if (p_aux is null or p_aux <> 'A') then
		return false;
	end if;

	p_aux := situacao from ocorrencias where indice = p_ocorrencia;

	if (p_aux is null or p_aux <> 'A') then
		return false;
	end if;

	update ocorrencias set encerrada = now(), situacao = 'E', conclusao = p_conclusao, encerrada_usuario = p_usuario
		where indice = p_ocorrencia;

	return true;

end;

$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_encerra_ocorrencia(integer, integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_entrega_compra(integer, integer)

-- DROP FUNCTION dsoft_entrega_compra(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_entrega_compra(p_usuario integer, p_compra integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare novo_estado		char;
declare c_produtos		refcursor;
declare c_indice		integer;
declare c_produto		integer;
declare c_quantidade	numeric;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from compras where indice = p_compra;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    if (auxiliar = 'E') then
    	return false;
    elseif (auxiliar = 'P') then
    	return false;
    elseif (auxiliar = 'N') then
    	novo_estado := 'P';
    elseif (auxiliar = 'A') then
    	novo_estado := 'E';
    end if;	

	update compras set situacao = novo_estado,
    					entregue = now(),
                        entregue_usuario = p_usuario
                        where indice = p_compra;
        
    -- Damos entrada no estoque                
	open c_produtos for select indice from compras_itens where compra = p_compra;
    
    fetch c_produtos into c_indice;
    
    while (c_indice is not null) loop
    
        c_produto := produto from compras_itens where indice = c_indice;
        c_quantidade := quantidade from compras_itens where indice = c_indice;

    	update estoque set quantidade = (quantidade + c_quantidade)
        	where produto = c_produto;
            
    	fetch c_produtos into c_indice;
            
    end loop;
    
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_entrega_compra(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_entrega_manifesto(integer, integer)

-- DROP FUNCTION dsoft_entrega_manifesto(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_entrega_manifesto(p_indice integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare sit character;

begin

	sit := situacao from manifestos where indice = p_indice;

	if (sit <> 'S') then
		return false;
	end if;

	update manifestos set chegada_data = now(),
				chegada_hora = now(),
				chegada_usuario = p_usuario,
				situacao = 'E'
				where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_entrega_manifesto(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_entrega_pedido(integer, integer)

-- DROP FUNCTION dsoft_entrega_pedido(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_entrega_pedido(p_pedido integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;
declare cod_entrega				integer;
declare situacao_atual			char;

declare c_produtos		refcursor;
declare c_indice		integer;
declare c_produto		integer;
declare c_quantidade	numeric;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'E' or auxiliar = 'P') then
		return OPERACAO_CONCLUIDA;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	end if;

	if (auxiliar = 'A' or auxiliar = 'S') then
		situacao_atual := 'E';
	elseif (auxiliar = 'N' or auxiliar = 'O') then
		situacao_atual := 'P';
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	cod_entrega := entrega from pedidos where indice = p_pedido limit 1;

	--Caso o cliente não seja definido podemos fazer a entrega diretamente
	--apenas para dar baixa no estoque
	--if (cod_entrega is null) then
		--return CODIGO_INVALIDO || ' entrega'::text;
	--end if;

	update pedidos set situacao = situacao_atual,
		entregue = now(),
		entregue_usuario = cod_usuario
		where indice = p_pedido;

	update entregas set entrega = now(), situacao = 'E'
		where indice = cod_entrega;

	-- Damos saida no estoque                
	open c_produtos for select pedidos_itens.indice from pedidos_itens 
		left join cad_produtos on (pedidos_itens.produto = cad_produtos.codigo)
		left join produtos_tipos on (produtos_tipos.codigo = cad_produtos.tipo)
		where pedido = p_pedido and produtos_tipos.estoque = true;

	fetch c_produtos into c_indice;

	while (c_indice is not null) loop
		c_produto := produto from pedidos_itens where indice = c_indice;
		c_quantidade := fracao from pedidos_itens where indice = c_indice;

		update estoque set quantidade = (quantidade - c_quantidade)
			where produto = c_produto and local = 1;

		fetch c_produtos into c_indice;
	end loop;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_entrega_pedido(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_fecha_caixa(integer, integer)

-- DROP FUNCTION dsoft_fecha_caixa(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_fecha_caixa(p_caixa integer, p_usuario integer)
  RETURNS integer AS
$BODY$
declare auxiliar			char;
declare v_entrada			numeric;
declare v_saida				numeric;
declare v_despesa			numeric;
declare v_vale				numeric;
declare v_pagamento			numeric;
declare v_transferencia		numeric;
declare v_saldo				numeric;
declare v_saldo_anterior	numeric;
declare fecha		 		integer;

begin

	fecha := indice from resumos where data = now() and caixa = p_caixa and situacao = 'A';
    
    if (fecha is not null) then
    	return 0;
    end if;
    
	auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null) then
    	return 0;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null) then
    	return 0;
    end if;
    
    v_saldo_anterior := saldo from cad_caixa where codigo = p_caixa;
    
    if (v_saldo_anterior is null) then
    	v_saldo_anterior := 0;
    end if;
    
    v_entrada := sum(valor) from caixa_fluxo
    			where situacao = 'A' and caixa = p_caixa and tipo = 'E';
                
	if (v_entrada is null) then
    	v_entrada := 0;
    end if;
    
    v_saida   := sum(valor) from caixa_fluxo
    			where situacao = 'A' and caixa = p_caixa and tipo = 'S';
    
    if (v_saida is null) then
    	v_saida := 0;
    end if;    
    
    v_despesa := sum(valor) from caixa_fluxo
    			where situacao = 'A' and caixa = p_caixa and tipo = 'D';
                
    if (v_despesa is null) then
    	v_despesa := 0;
    end if;
            
    v_vale := sum(valor) from caixa_fluxo
    	where situacao = 'A' and caixa = p_caixa and tipo = 'V';
        
    if (v_vale is null) then
    	v_vale := 0;
    end if;
    
    v_pagamento := sum(valor) from caixa_fluxo
    	where situacao = 'A' and caixa = p_caixa and tipo = 'P';
        
    if (v_pagamento is null) then
    	v_pagamento := 0;
    end if;
    
    v_transferencia := sum(valor) from caixa_fluxo
    					where situacao = 'A' and caixa = p_caixa and tipo = 'T';
                        
    if (v_transferencia is null) then
    	v_transferencia := 0;
    end if;
        
    v_saldo := (v_saldo_anterior + v_entrada - v_saida - v_despesa - v_vale - v_pagamento - v_transferencia);
    
    insert into caixa (tipo,
    					saldo,
                        entrada,
                        saida,
                        despesa,
                        vale,
                        pagamento,
                        transferencia,
                        caixa,
                        usuario
                        ) values (
                        'F',
                        v_saldo,
                        v_entrada,
                        v_saida,
                        v_despesa,
                        v_vale,
                        v_pagamento,
                        v_transferencia,
                        p_caixa,
                        p_usuario);
        
    fecha := indice from caixa order by indice desc limit 1;
    
    update caixa_fluxo set situacao = 'F', fechamento = fecha
    	where situacao = 'A' and caixa = p_caixa;
        
    update cad_caixa set saldo_anterior = saldo,
    						saldo = v_saldo
                            where codigo = p_caixa;
        
    return fecha;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_fecha_caixa(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_fecha_caixa_saida(integer, integer)

-- DROP FUNCTION dsoft_fecha_caixa_saida(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_fecha_caixa_saida(p_caixa integer, p_usuario integer)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare v_entrada		double precision;
declare v_saida			double precision;
declare v_despesa		double precision;
declare v_vale			double precision;
declare v_pagamento		double precision;
declare v_transferencia		double precision;
declare v_saldo			double precision;
declare v_saldo_anterior	double precision;
declare fecha		 	integer;

declare n_dinheiro		double precision;
declare n_cartao		double precision;
declare n_visa			double precision;
declare n_master		double precision;
declare n_crediario		double precision;
declare n_cheque		double precision;
declare n_debito		double precision;
declare n_vr			double precision;

declare n_recebimentos		double precision;

begin

	-- Primeiro verificamos se o dia já foi encerrado
	fecha := indice from resumos where data = now() and situacao = 'A';

	if (fecha is not null) then
		return 0;
	end if;

	auxiliar := situacao from cad_caixa where codigo = p_caixa;

	if (auxiliar is null) then
		return 0;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null) then
		return 0;
	end if;

	v_saldo_anterior := saldo from cad_caixa where codigo = p_caixa;

	if (v_saldo_anterior is null) then
		v_saldo_anterior := 0;
	end if;

	v_entrada := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'E';

	if (v_entrada is null) then
		v_entrada := 0;
	end if;

	v_saida   := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'S';

	if (v_saida is null) then
		v_saida := 0;
	end if;    

	v_despesa := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'D';

	if (v_despesa is null) then
		v_despesa := 0;
	end if;

	v_vale := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'V';

	if (v_vale is null) then
		v_vale := 0;
	end if;

	v_pagamento := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'P';

	if (v_pagamento is null) then
		v_pagamento := 0;
	end if;

	v_transferencia := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'T';

	if (v_transferencia is null) then
		v_transferencia := 0;
	end if;

	-- Detalhes dos pagamento
	n_dinheiro := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'D';

	if (n_dinheiro is null) then
		n_dinheiro := 0;
	end if;

	n_cheque := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'X';

	if (n_cheque is null) then
		n_cheque := 0;
	end if;

	n_cartao := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'C';

	if (n_cartao is null) then
		n_cartao := 0;
	end if;

	n_visa := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'V';

	if (n_visa is null) then
		n_visa := 0;
	end if;

	n_master := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'M';

	if (n_master is null) then
		n_master := 0;
	end if;

	n_crediario := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'P';

	if (n_crediario is null) then
		n_crediario := 0;
	end if;

	n_debito := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'A';

	if (n_debito is null) then
		n_debito := 0;
	end if;

	n_vr := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'R';

	if (n_vr is null) then
		n_vr := 0;
	end if;

	n_recebimentos := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and prestacao is not null;

	if (n_recebimentos is null) then
		n_recebimentos := 0;
	end if;

	v_saldo := (v_saldo_anterior + v_entrada - v_saida - v_despesa - v_vale - v_pagamento - v_transferencia);

	if (v_saldo > 0) then
		v_saida := v_saida + v_saldo;
		v_saldo := 0;

		insert into caixa_fluxo (tipo, caixa, usuario, valor, observacao) values ('S', p_caixa, p_usuario, v_saida, 'FECHAMENTO DE CAIXA');
	end if;

	insert into caixa (tipo,
			saldo,
			entrada,
			saida,
			despesa,
			vale,
			pagamento,
			transferencia,
			caixa,
			dinheiro,
			cheque,
			cartao,
			visa,
			master,
			crediario,
			recebimentos,
			debito,
			vr,
			usuario
			) values (
			'F',
			v_saldo,
			v_entrada,
			v_saida,
			v_despesa,
			v_vale,
			v_pagamento,
			v_transferencia,
			p_caixa,
			n_dinheiro,
			n_cheque,
			n_cartao,
			n_visa,
			n_master,
			n_crediario,
			n_recebimentos,
			n_debito,
			n_vr,
			p_usuario);

	fecha := indice from caixa order by indice desc limit 1;

	update caixa_fluxo set situacao = 'F', fechamento = fecha
				where situacao = 'A' and caixa = p_caixa;

	update caixa_fluxo set fechamento = fecha
				where situacao = 'C' and caixa = p_caixa and fechamento is null;

	update cad_caixa set saldo_anterior = saldo,
				saldo = v_saldo
				where codigo = p_caixa;

	return fecha;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_fecha_caixa_saida(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_fecha_dia(integer, date)

-- DROP FUNCTION dsoft_fecha_dia(integer, date);

CREATE OR REPLACE FUNCTION dsoft_fecha_dia(p_usuario integer, p_data date)
  RETURNS integer AS
$BODY$
declare CAIXA_ABERTO		integer := -1;
declare FECHAMENTO_EFETUADO	integer := -2;
declare auxiliar		char;
declare n_numero		int;
declare n_saldo_anterior	double precision;
declare n_entrada		double precision;
declare n_saldo			double precision;
declare n_saida_total		double precision;
declare n_saida			double precision;
declare n_vale			double precision;
declare n_despesa		double precision;
declare n_transferencia		double precision;
declare n_pagamento		double precision;
declare n_vendas		double precision;
declare n_volume		integer;

declare n_dinheiro		double precision;
declare n_cheque		double precision;
declare n_cartao		double precision;
declare n_visa			double precision;
declare n_master		double precision;
declare n_crediario		double precision;
declare n_boleto		double precision;
declare n_debito		double precision;
declare n_vr			double precision;

declare n_recebimentos		double precision;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null or auxiliar <> 'A') then
		return 0;
	end if;

	n_numero := indice from resumos where data = p_data and situacao = 'A' limit 1;

	if (n_numero is not null) then
		return FECHAMENTO_EFETUADO;
	end if;

	n_numero := count(indice) from caixa_fluxo where situacao = 'A';

	if (n_numero > 0) then
		return CAIXA_ABERTO;
	end if;

	n_saldo_anterior := saldo from resumos where situacao = 'A' order by indice desc limit 1;

	if (n_saldo_anterior is null) then
		n_saldo_anterior := 0;
	end if;

	n_entrada := sum(entrada) from caixa where situacao = 'A';

	if (n_entrada is null) then
		n_entrada := 0;
	end if;

	n_saida := sum(saida) from caixa where situacao = 'A';

	if (n_saida is null) then
		n_saida := 0;
	end if;

	n_vale := sum(vale) from caixa where situacao = 'A';

	if (n_vale is null) then
		n_vale := 0;
	end if;

	n_despesa := sum(despesa) from caixa where situacao = 'A';

	if (n_despesa is null) then
		n_despesa := 0;
	end if;

	n_transferencia := sum(transferencia) from caixa where situacao = 'A';

	if (n_transferencia is null) then
		n_transferencia := 0;
	end if;

	n_pagamento := sum(pagamento) from caixa where situacao = 'A';

	if (n_pagamento is null) then
		n_pagamento := 0;
	end if;

	n_vendas := sum(total) from pedidos where (situacao = 'N' or situacao = 'O' or situacao = 'P') and fechamento is null;
	n_volume := count(indice) from pedidos where (situacao = 'N' or situacao = 'O' or situacao = 'P') and fechamento is null;

	-- Detalhes do pagamento
	n_dinheiro := sum(dinheiro) from caixa where situacao = 'A';

	if (n_dinheiro is null) then
		n_dinheiro := 0;
	end if;

	n_cheque := sum(cheque) from caixa where situacao = 'A';

	if (n_cheque is null) then
		n_cheque := 0;
	end if;

	n_cartao := sum(cartao) from caixa where situacao = 'A';

	if (n_cartao is null) then
		n_cartao := 0;
	end if;

	n_visa := sum(visa) from caixa where situacao = 'A';

	if (n_visa is null) then
		n_visa := 0;
	end if;

	n_master := sum(master) from caixa where situacao = 'A';

	if (n_master is null) then
		n_master := 0;
	end if;

	n_crediario := sum(valor) from pagamentos where data = p_data and tipo = 'P' and situacao <> 'C';

	if (n_crediario is null) then
		n_crediario := 0;
	end if;

	n_recebimentos := sum(recebimentos) from caixa where situacao = 'A';

	if (n_recebimentos is null) then
		n_recebimentos := 0;
	end if;

	n_boleto := sum(boleto) from caixa where situacao = 'A';

	if (n_boleto is null) then
		n_boleto := 0;
	end if;

	n_debito := sum(debito) from caixa where situacao = 'A';

	if (n_debito is null) then
		n_debito := 0;
	end if;

	n_vr := sum(vr) from caixa where situacao = 'A';

	if (n_vr is null) then
		n_vr := 0;
	end if;

	n_saida_total := n_saida + n_vale + n_despesa + n_transferencia + n_pagamento;

	n_saldo := n_saldo_anterior + n_entrada - n_saida_total;

	insert into resumos (data,
				usuario,
				entrada,
				saida,
				vales,
				despesas,
				pagamentos,
				transferencias,
				vendas,
				volume,
				dinheiro,
				cheque,
				cartao,
				visa,
				master,
				debito,
				boleto,
				vr,
				crediario,
				recebimentos,
				saldo_anterior,
				saldo
				) values (
				p_data,
				p_usuario,
				n_entrada,
				n_saida,
				n_vale,
				n_despesa,
				n_pagamento,
				n_transferencia,
				n_vendas,
				n_volume,
				n_dinheiro,
				n_cheque,
				n_cartao,
				n_visa,
				n_master,
				n_debito,
				n_boleto,
				n_vr,
				n_crediario,
				n_recebimentos,
				n_saldo_anterior,
				n_saldo);

	n_numero := indice from resumos order by indice desc limit 1;

	update caixa set situacao = 'F', fechamento = n_numero where situacao = 'A';

	update pedidos set fechamento = n_numero where fechamento is null;

	update despesas set fechamento = n_numero, situacao = 'F' where situacao = 'P';

	return n_numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_fecha_dia(integer, date)
  OWNER TO postgres;



-- Function: dsoft_fecha_dia(integer, integer, date)

-- DROP FUNCTION dsoft_fecha_dia(integer, integer, date);

CREATE OR REPLACE FUNCTION dsoft_fecha_dia(p_usuario integer, p_caixa integer, p_data date)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare n_numero		int;
declare n_saldo_anterior	numeric;
declare n_entrada		numeric;
declare n_saldo			numeric;
declare n_saida_total	numeric;
declare n_saida			numeric;
declare n_vale			numeric;
declare n_despesa		numeric;
declare n_transferencia	numeric;
declare n_pagamento		numeric;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    n_numero := indice from resumos where data = p_data and caixa = p_caixa and situacao = 'A' limit 1;
    
    if (n_numero is not null) then
    	return 0;
    end if;
    
    n_numero := count(indice) from caixa_fluxo where situacao = 'A';
    
    if (n_numero is not null or n_numero > 0) then
    	perform dsoft_fecha_caixa(p_caixa, p_usuario);
    end if;
    
    n_saldo_anterior := saldo from resumos where caixa = p_caixa and situacao = 'A' order by data desc limit 1;
    
    if (n_saldo_anterior is null) then
    	n_saldo_anterior := 0;
    end if;
    
    n_entrada := sum(entrada) from caixa where caixa = p_caixa and situacao = 'A';
    
    if (n_entrada is null) then
    	n_entrada := 0;
    end if;
    
    n_saida := sum(saida) from caixa where caixa = p_caixa and situacao = 'A';
    
	if (n_saida is null) then
    	n_saida := 0;
    end if;
    
    n_vale := sum(vale) from caixa where caixa = p_caixa and situacao = 'A';
    
    if (n_vale is null) then
    	n_vale := 0;
    end if;
    
    n_despesa := sum(despesa) from caixa where caixa = p_caixa and situacao = 'A';
    
    if (n_despesa is null) then
    	n_despesa := 0;
    end if;
    
    n_transferencia := sum(transferencia) from caixa where caixa = p_caixa and situacao = 'A';
    
    if (n_transferencia is null) then
    	n_transferencia := 0;
    end if;
    
    n_pagamento := sum(pagamento) from caixa where caixa = p_caixa and situacao = 'A';
    
    if (n_pagamento is null) then
    	n_pagamento := 0;
    end if;
    
    n_saida_total := n_saida + n_vale + n_despesa + n_transferencia + n_pagamento;
    
    n_saldo := n_saldo_anterior + n_entrada - n_saida_total;
    
    insert into resumos (data,
                        usuario,
                        caixa,
                        entrada,
                        saida,
                        vales,
                        despesas,
                        pagamentos,
                        transferencias,
                        saldo_anterior,
                        saldo
                        ) values (
                        p_data,
                        p_usuario,
                        p_caixa,
                        n_entrada,
                        n_saida,
                        n_vale,
                        n_despesa,
                        n_pagamento,
                        n_transferencia,
                        n_saldo_anterior,
                        n_saldo);
                        
    n_numero := indice from resumos order by indice desc limit 1;
    
    update caixa set situacao = 'F', fechamento = n_numero where caixa = p_caixa and data = p_data and situacao = 'A';

	return n_numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_fecha_dia(integer, integer, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_entrada(integer, integer, numeric, character varying, date)

-- DROP FUNCTION dsoft_lanca_entrada(integer, integer, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_entrada(p_usuario integer, p_caixa integer, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare numero int;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, valor, usuario, observacao, data)
    	values ('E', p_caixa, p_valor, p_usuario, p_observacao, p_data);

    numero := indice from caixa_fluxo where tipo = 'E' and caixa = p_caixa and valor = p_valor order by indice desc limit 1;
    
    return numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_entrada(integer, integer, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_entrada(integer, integer, character varying, numeric, character varying, date)

-- DROP FUNCTION dsoft_lanca_entrada(integer, integer, character varying, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_entrada(p_usuario integer, p_caixa integer, p_forma character varying, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare numero int;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, forma, valor, usuario, observacao, data)
    	values ('E', p_caixa, p_forma, p_valor, p_usuario, p_observacao, p_data);

    numero := indice from caixa_fluxo where tipo = 'E' and caixa = p_caixa and valor = p_valor order by indice desc limit 1;
    
    return numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_entrada(integer, integer, character varying, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_entrada(integer, integer, bigint, character varying, numeric, character varying, date)

-- DROP FUNCTION dsoft_lanca_entrada(integer, integer, bigint, character varying, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_entrada(p_usuario integer, p_caixa integer, p_cliente bigint, p_forma character varying, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare numero int;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null or auxiliar <> 'A') then
		return 0;
	end if;

	auxiliar := situacao from cad_caixa where codigo = p_caixa;

	if (auxiliar is null or auxiliar <> 'A') then
		return 0;
	end if;

	insert into caixa_fluxo (tipo, caixa, forma, cliente, valor, usuario, observacao, data)
		values ('E', p_caixa, p_forma, p_cliente, p_valor, p_usuario, p_observacao, p_data);

	numero := indice from caixa_fluxo where tipo = 'E' and caixa = p_caixa and cliente = p_cliente and valor = p_valor order by indice desc limit 1;

	insert into pagamentos (data, tipo, usuario, valor, documento, pago_data, pago_hora, pago_usuario, total_pago, cliente, caixa_fluxo)
		values (p_data, p_forma, p_usuario, p_valor, p_observacao, p_data, now(), p_usuario, p_valor, p_cliente, numero);

	update cad_clientes set saldo = saldo + p_valor::double precision where codigo = p_cliente;

	return numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_entrada(integer, integer, bigint, character varying, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_pagamento(integer, integer, numeric, integer, character varying, date)

-- DROP FUNCTION dsoft_lanca_pagamento(integer, integer, numeric, integer, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_pagamento(p_usuario integer, p_caixa integer, p_valor numeric, p_recurso integer, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_recurso;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, valor, usuario, recurso, observacao, data)
    	values ('P', p_caixa, p_valor, p_usuario, p_recurso, p_observacao, p_data);
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_pagamento(integer, integer, numeric, integer, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_saida(integer, integer, numeric, character varying, date)

-- DROP FUNCTION dsoft_lanca_saida(integer, integer, numeric, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_saida(p_usuario integer, p_caixa integer, p_valor numeric, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, valor, usuario, observacao, data)
    	values ('S', p_caixa, p_valor, p_usuario, p_observacao, p_data);
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_saida(integer, integer, numeric, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lanca_vale(integer, integer, numeric, integer, character varying, date)

-- DROP FUNCTION dsoft_lanca_vale(integer, integer, numeric, integer, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_lanca_vale(p_usuario integer, p_caixa integer, p_valor numeric, p_recurso integer, p_observacao character varying, p_data date)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_recurso;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, valor, usuario, recurso, observacao, data)
    	values ('V', p_caixa, p_valor, p_usuario, p_recurso, p_observacao, p_data);
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lanca_vale(integer, integer, numeric, integer, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_lancamento_caixa(integer, character, numeric, integer)

-- DROP FUNCTION dsoft_lancamento_caixa(integer, character, numeric, integer);

CREATE OR REPLACE FUNCTION dsoft_lancamento_caixa(p_caixa integer, p_tipo character, p_valor numeric, p_usuario integer)
  RETURNS integer AS
$BODY$
declare auxiliar	char;
declare p_numero	integer;

begin

	auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null) then
    	return 0;
    end if;
    
    auxiliar := situacao from cas_usuarios where codigo = p_usuario;

    if (auxiliar is null) then
    	return 0;
    end if;
    
    insert into caixa (tipo, valor, caixa, usuario)
    	values (p_tipo, p_valor, p_caixa, p_usuario);
        
    p_numero := indice from caixa order by indice desc limit 1;
    
    return p_numero;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_lancamento_caixa(integer, character, numeric, integer)
  OWNER TO postgres;


-- Function: dsoft_limpa_manifesto(integer)

-- DROP FUNCTION dsoft_limpa_manifesto(integer);

CREATE OR REPLACE FUNCTION dsoft_limpa_manifesto(p_indice integer)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set manifesto = null,
				montagem_data = null,
				montagem_hora = null,
				montagem_usuario = null
				where manifesto = p_indice;

	update manifestos set itens = 0,
				valor_total = 0,
				peso_total = 0,
				volume_total = 0,
				frete_total = 0
				where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_limpa_manifesto(integer)
  OWNER TO postgres;


-- Function: dsoft_limpa_movimentos()

-- DROP FUNCTION dsoft_limpa_movimentos();

CREATE OR REPLACE FUNCTION dsoft_limpa_movimentos()
  RETURNS boolean AS
$BODY$
begin

	delete from pedidos_itens;
    delete from entregas;
    delete from pagamentos;
    delete from pedidos;
    delete from log_acessos;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_limpa_movimentos()
  OWNER TO postgres;


-- Function: dsoft_limpamov()

-- DROP FUNCTION dsoft_limpamov();

CREATE OR REPLACE FUNCTION dsoft_limpamov()
  RETURNS boolean AS
$BODY$

begin

	delete from caixa_fluxo;
	delete from compras_itens;
	delete from compras;
	delete from pedidos_itens;
	delete from pagamentos;
	delete from entregas;
	delete from despesas;
	delete from fec_diario;
	delete from log_acessos;
	delete from resumos;
	delete from pedidos;
	delete from caixa;
	
	update cad_caixa set saldo = 0, saldo_anterior = 0;
	update estoque set quantidade = 0;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_limpamov()
  OWNER TO postgres;


-- Function: dsoft_limpar_compra(integer, integer)

-- DROP FUNCTION dsoft_limpar_compra(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_limpar_compra(p_usuario integer, p_compra integer)
  RETURNS boolean AS
$BODY$
begin

	update compras set valor = 0,
    					itens = 0,
                        alterado = now(),
                        alterado_usuario = p_usuario
                        where indice = p_compra;
                        
    delete from compras_itens where compra = p_compra;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_limpar_compra(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_limpar_pedido(integer, integer)

-- DROP FUNCTION dsoft_limpar_pedido(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_limpar_pedido(p_pedido integer, p_usuario integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_pedido is null or p_pedido < 1) then
    	return false;
    end if;
    
    if (p_usuario is null or p_usuario < 1) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then    
    	return false;
    end if;
    
    update pedidos set itens = 0,
    					valor = 0,
    					total = 0,
                        alterado = now(),
                        alterado_usuario = p_usuario
                        where indice = p_pedido;
                        
	delete from pedidos_itens where pedido = p_pedido;
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_limpar_pedido(integer, integer)
  OWNER TO dsoft;


-- Function: dsoft_loga_entrada(integer, integer)

-- DROP FUNCTION dsoft_loga_entrada(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_loga_entrada(cod_usuario integer, cod_caixa integer)
  RETURNS void AS
$BODY$
begin
	insert into log_acessos (usuario, caixa) values (cod_usuario, cod_caixa);
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_loga_entrada(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_loga_entrada(integer)

-- DROP FUNCTION dsoft_loga_entrada(integer);

CREATE OR REPLACE FUNCTION dsoft_loga_entrada(cod_usuario integer)
  RETURNS void AS
$BODY$
begin
	insert into log_acessos (usuario) values (cod_usuario);
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_loga_entrada(integer)
  OWNER TO postgres;


-- Function: dsoft_loga_saida(integer)

-- DROP FUNCTION dsoft_loga_saida(integer);

CREATE OR REPLACE FUNCTION dsoft_loga_saida(cod_usuario integer)
  RETURNS void AS
$BODY$
begin
	update log_acessos set saida = now() where usuario = cod_usuario and saida is null;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_loga_saida(integer)
  OWNER TO postgres;


-- Function: dsoft_login(integer, character varying)

-- DROP FUNCTION dsoft_login(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_login(cod_usuario integer, senha_usuario character varying)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO varchar := 'ERRO_00';
declare SENHA_INVALIDA varchar := 'ERRO_01';
declare USUARIO_CANCELADO varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO varchar := 'ERRO_03';
declare usuario varchar;
declare situacao_usuario char;

begin

	usuario := nome from cad_usuarios where codigo = cod_usuario limit 1;

	if (usuario is null) then
		return USUARIO_NAO_ENCONTRADO;
	end if;

	usuario := nome from cad_usuarios where codigo = cod_usuario and senha = senha_usuario limit 1;

	if (usuario is null) then
		return SENHA_INVALIDA;
	end if;

	situacao_usuario := situacao from cad_usuarios where codigo = cod_usuario and senha = senha_usuario limit 1;

	if (situacao_usuario = 'C') then
		return USUARIO_CANCELADO;
	end if;
	
	if (situacao_usuario = 'B') then
		return USUARIO_BLOQUEADO;
	end if;

	perform dsoft_loga_entrada(cod_usuario);

	return usuario;
	
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_login(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_move_estoque(integer, double precision, integer, integer)

-- DROP FUNCTION dsoft_move_estoque(integer, double precision, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_move_estoque(p_produto integer, p_quantidade double precision, p_de integer, p_para integer)
  RETURNS boolean AS
$BODY$

declare p_minimo integer;
declare p_maximo integer;
declare v_quantidade double precision;

begin

	perform nome from cad_produtos where codigo = p_produto;

	if (not found) then
		return false;
	end if;

	if (p_de = 0) then
		v_quantidade := quantidade from estoque where produto = p_produto and "local" is null limit 1;
		
		if (v_quantidade is null or v_quantidade < p_quantidade) then
			return false;
		end if;
	else
		v_quantidade := quantidade from estoque where produto = p_produto and "local" = p_de limit 1;
		
		if (v_quantidade is null or v_quantidade < p_quantidade) then
			return false;
		end if;
	end if;

	perform indice from estoque where produto = p_produto and "local" = p_para;

	if (not found) then
		p_minimo := minimo from estoque where produto = p_produto limit 1;
		p_maximo := maximo from estoque where produto = p_produto limit 1;

		insert into estoque (produto, "local", minimo, maximo) values (p_produto, p_para, p_minimo, p_maximo);
	end if;

	update estoque set quantidade = quantidade + p_quantidade where produto = p_produto and "local" = p_para;

	if (p_de = 0) then
		update estoque set quantidade = quantidade - p_quantidade where produto = p_produto and "local" is null;
	else
		update estoque set quantidade = quantidade - p_quantidade where produto = p_produto and "local" = p_de;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_move_estoque(integer, double precision, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_nova_chave_cte()

-- DROP FUNCTION dsoft_nova_chave_cte();

CREATE OR REPLACE FUNCTION dsoft_nova_chave_cte()
  RETURNS character varying AS
$BODY$

declare c integer;

begin

	c := conhecimento from ordem_servico where conhecimento is not null order by conhecimento desc limit 1;

	if (c is null) then
		c := 0;
	end if;
	
	c := c + 1;

	return to_char(c, '000000000');

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_chave_cte()
  OWNER TO postgres;



-- Function: dsoft_nova_compra(integer, bigint, character varying)

-- DROP FUNCTION dsoft_nova_compra(integer, bigint, character varying);

CREATE OR REPLACE FUNCTION dsoft_nova_compra(p_usuario integer, p_fornecedor bigint, p_observacao character varying)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare compra_numero	integer;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
    auxiliar := situacao from cad_fornecedores where codigo = p_fornecedor;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return 0;
    end if;
    
	insert into compras (fornecedor, usuario, observacao)
    	values (p_fornecedor, p_usuario, p_observacao);
        
    compra_numero := indice from compras order by indice desc limit 1;
    
    return compra_numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_compra(integer, bigint, character varying)
  OWNER TO postgres;


-- Function: dsoft_nova_despesa(integer, integer, bigint, numeric, date, character varying, character varying)

-- DROP FUNCTION dsoft_nova_despesa(integer, integer, bigint, numeric, date, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_nova_despesa(p_usuario integer, p_tipo integer, p_fornecedor bigint, p_valor numeric, p_vencimento date, p_documento character varying, p_observacao character varying)
  RETURNS integer AS
$BODY$
declare USUARIO_NAO_ENCONTRADO	integer := 0;
declare CODIGO_INVALIDO		integer := -5;
declare OPERACAO_NEGADA		integer := -9;
declare CODIGO_NAO_ENCONTRADO	integer	:= -10;

declare auxiliar		char;
declare tmp			varchar;
declare n_despesa		integer;
declare v_fornecedor		integer;

begin

	if (p_usuario is null or p_fornecedor is null or p_tipo is null) then
		return CODIGO_INVALIDO;
	end if;
    
	tmp := nome from despesas_tipo where codigo = p_tipo;
    
	if (tmp is null) then
		return CODIGO_NAO_ENCONTRADO;
	end if;
    
	if (p_fornecedor = 0) then
		v_fornecedor = null;
	else
		auxiliar := situacao from cad_fornecedores where codigo = p_fornecedor;
    
		if (auxiliar is null) then
			return CODIGO_NAO_ENCONTRADO;
		end if;
		
		v_fornecedor = p_fornecedor;
	end if;

	if (p_valor is null or p_valor < 0) then
		return OPERACAO_NEGADA;
	end if;
    
	insert into despesas (usuario,
		vencimento,
		documento,
		tipo,
		observacao,
		fornecedor,
		valor
		) values (
		p_usuario,
		p_vencimento,
		p_documento,
		p_tipo,
		p_observacao,
		v_fornecedor,
		p_valor);

	n_despesa := indice from despesas order by indice desc limit 1;

	return n_despesa;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_despesa(integer, integer, bigint, numeric, date, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_nova_ocorrencia(integer, character, character varying, bigint)

-- DROP FUNCTION dsoft_nova_ocorrencia(integer, character, character varying, bigint);

CREATE OR REPLACE FUNCTION dsoft_nova_ocorrencia(p_usuario integer, p_tipo character, p_ocorrencia character varying, p_cliente bigint)
  RETURNS boolean AS
$BODY$

declare p_aux char;

begin

	if (p_usuario is null) then
		return false;
	end if;

	p_aux := situacao from cad_usuarios where codigo = p_usuario;

	if (p_aux is null or p_aux <> 'A') then
		return false;
	end if;

	if (p_cliente is not null) then
		p_aux := situacao from cad_clientes where codigo = p_cliente;

		if (p_aux is null or p_aux <> 'A') then
			return false;
		end if;
	end if;

	insert into ocorrencias (usuario, tipo, ocorrencia, cliente) values (p_usuario, p_tipo, p_ocorrencia, p_cliente);

	return true;

end;

$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_ocorrencia(integer, character, character varying, bigint)
  OWNER TO postgres;


-- Function: dsoft_nova_ordem_servico(bigint, character, integer)

-- DROP FUNCTION dsoft_nova_ordem_servico(bigint, character, integer);

CREATE OR REPLACE FUNCTION dsoft_nova_ordem_servico(p_cliente bigint, p_tipo character, p_usuario integer)
  RETURNS integer AS
$BODY$

declare numero integer;

begin

	insert into ordem_servico (cliente, tipo, abertura_usuario) values (p_cliente, p_tipo, p_usuario);

	numero := indice from ordem_servico where abertura_usuario = p_usuario order by indice desc limit 1;

	return numero;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_ordem_servico(bigint, character, integer)
  OWNER TO postgres;


-- Function: dsoft_nova_ordem_transporte(character varying, date, bigint, bigint, boolean, integer)

-- DROP FUNCTION dsoft_nova_ordem_transporte(character varying, date, bigint, bigint, boolean, integer);

CREATE OR REPLACE FUNCTION dsoft_nova_ordem_transporte(p_emitente character varying, p_data date, p_remetente bigint, p_destinatario bigint, p_pago boolean, p_usuario integer)
  RETURNS integer AS
$BODY$

declare p_indice integer;
declare c integer; -- Para pegar o proximo numero de conhecimento

begin

	c := conhecimento from ordem_servico order by conhecimento desc limit 1;
	c := c + 1;

	insert into ordem_servico(emitente, abertura_data, abertura_hora, abertura_usuario, remetente, destinatario, pago, conhecimento)
		values (p_emitente, p_data, now(), p_usuario, p_remetente, p_destinatario, p_pago, c);

	p_indice := indice from ordem_servico where abertura_usuario = p_usuario and remetente = p_remetente order by indice desc limit 1;

	return p_indice;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_ordem_transporte(character varying, date, bigint, bigint, boolean, integer)
  OWNER TO postgres;


-- Function: dsoft_nova_tabela(integer, character varying, character varying, integer)

-- DROP FUNCTION dsoft_nova_tabela(integer, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_nova_tabela(cod_tabela integer, nome_tabela character varying, descr_tabela character varying, tabela_pai integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_JA_CADASTRADO	varchar := 'ERRO_04';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				varchar;
declare cod_cursor				refcursor;
declare cod_produto				integer;
declare preco_produto			money;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
	auxiliar := nome from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is not null) then
    	return CODIGO_JA_CADASTRADO;
    end if;
    
    if (nome_tabela is null) then
    	return CAMPO_INVALIDO || ' nome'::text;
    end if;
    
    if (tabela_pai > 0) then
    	auxiliar := nome from cad_tabelas where codigo = tabela_pai limit 1;
        
        if (auxiliar is null) then
        	return CAMPO_INVALIDO || ' tabela_pai'::text;
        end if;
        
    end if;
    
    insert into cad_tabelas (codigo, nome, descricao)
    	values (cod_tabela, nome_tabela, descr_tabela);
        
    open cod_cursor for select codigo from cad_produtos;
    
    fetch cod_cursor into cod_produto;
    
    while (cod_produto is not null) loop
    
    	if (tabela_pai = 0) then
        
    		insert into produtos_precos (tabela, produto, preco)
        		values (cod_tabela, cod_produto, 0::numeric);
                
        else
        
        	preco_produto := preco from produtos_precos
            					where tabela = cod_tabela and produto = cod_produto limit 1;
                        
            insert into produtos_precos (tabela, produto, preco)
            	values (cod_tabela, cod_produto, preco_produto);
        
        end if;
        
        fetch cod_cursor into cod_produto;
    
    end loop;
    
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_tabela(integer, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_caixa(integer, character varying)

-- DROP FUNCTION dsoft_novo_caixa(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_caixa(p_codigo integer, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar 	char;

begin

	auxiliar := situacao from cad_caixa where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    insert into cad_caixa (codigo, descricao)
    	values (p_codigo, p_descricao);
        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_caixa(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer)

-- DROP FUNCTION dsoft_novo_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_cliente(p_codigo bigint, p_nome character varying, p_nascimento date, p_tipo character, p_documento character varying, p_insc_estadual character varying, p_insc_suframa character varying, p_rg character varying, p_isento_icms boolean, p_tel1 bigint, p_tel2 bigint, p_celular bigint, p_endereco character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cidade character varying, p_estado character varying, p_pais character varying, p_cep character varying, p_referencia character varying, p_observacao character varying, cod_usuario integer, p_grupo integer, p_pai character varying, p_mae character varying, p_conjuge character varying, p_profissao character varying, p_senha character varying, p_tabela integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (p_codigo is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    insert into cad_clientes (codigo,
    							nome,
                                nascimento,
                                tipo,
                                documento,
				inscricao_estadual,
				inscricao_suframa,
                                rg,
				isento_icms,
                                tel1,
                                tel2,
                                celular,
                                endereco,
				numero,
				complemento,
                                bairro,
                                cidade,
                                estado,
                                pais,
                                cep,
                                referencia,
                                observacao,
                                usuario,
                                cadastro,
                                grupo,
                                pai,
                                mae,
                                conjuge,
                                profissao,
                                senha,
                                tabela_precos)
                                values (
                                p_codigo,
                                p_nome,
                                p_nascimento,
                                p_tipo,
                                p_documento,
				p_insc_estadual,
				p_insc_suframa,
                                p_rg,
				p_isento_icms,
                                p_tel1,
                                p_tel2,
                                p_celular,
                                p_endereco,
				p_numero,
				p_complemento,
                                p_bairro,
                                p_cidade,
                                p_estado,
                                p_pais,
                                p_cep,
                                p_referencia,
                                p_observacao,
                                cod_usuario,
                                now(),
                                p_grupo,
                                p_pai,
                                p_mae,
                                p_conjuge,
                                p_profissao,
                                p_senha,
                                p_tabela);
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_cliente(bigint, character varying, date, character, character varying, character varying, character varying, character varying, boolean, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, integer, integer, character varying, character varying, character varying, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_compra_item(integer, integer, integer, numeric, numeric, numeric)

-- DROP FUNCTION dsoft_novo_compra_item(integer, integer, integer, numeric, numeric, numeric);

CREATE OR REPLACE FUNCTION dsoft_novo_compra_item(p_compra integer, p_numero integer, p_produto integer, p_unitario numeric, p_quantidade numeric, p_total numeric)
  RETURNS boolean AS
$BODY$
begin

	insert into compras_itens (compra, numero, produto, unitario, quantidade, total)
    	values (p_compra, p_numero, p_produto, p_unitario, p_quantidade, p_total);
        
    update compras set valor = (valor + p_total), itens = (itens + 1)
    	where indice = p_compra;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_compra_item(integer, integer, integer, numeric, numeric, numeric)
  OWNER TO postgres;


-- Function: dsoft_novo_despesa_subtipo(integer, character varying, character varying, integer)

-- DROP FUNCTION dsoft_novo_despesa_subtipo(integer, character varying, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_despesa_subtipo(p_codigo integer, p_nome character varying, p_descricao character varying, p_tipo integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	varchar;

begin

	auxiliar := nome from despesas_subtipo where codigo = p_codigo;

	if (auxiliar is not null) then
		return false;
	end if;

	if (p_nome is null) then
		return false;
	end if;

	insert into despesas_subtipo (codigo, nome, descricao, tipo)
		values (p_codigo, p_nome, p_descricao, p_tipo);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_despesa_subtipo(integer, character varying, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_despesa_tipo(integer, character varying, character varying)

-- DROP FUNCTION dsoft_novo_despesa_tipo(integer, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_despesa_tipo(p_codigo integer, p_nome character varying, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	varchar;

begin

	auxiliar := nome from despesas_tipo where codigo = p_codigo;

	if (auxiliar is not null) then
		return false;
	end if;

	if (p_nome is null) then
		return false;
	end if;

	insert into despesas_tipo (codigo, nome, descricao)
		values (p_codigo, p_nome, p_descricao);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_despesa_tipo(integer, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_novo_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_emitente(p_razao character varying, p_nome character varying, p_cnpj character varying, p_inscr_est character varying, p_cnae_fiscal character varying, p_inscr_municipal character varying, p_logradouro character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cep character varying, p_pais character varying, p_uf character varying, p_municipio character varying, p_telefone character varying, p_rntrc character varying)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (found) then
		return false;
	end if;

	insert into cad_emitentes (razao_social,
				nome_fantasia,
				cnpj,
				inscricao_estadual,
				cnae_fiscal,
				inscricao_municipal,
				logradouro,
				numero,
				complemento,
				bairro,
				cep,
				pais,
				uf,
				municipio,
				telefone,
				"RNTRC") values (
				p_razao,
				p_nome,
				p_cnpj,
				p_inscr_est,
				p_cnae_fiscal,
				p_inscr_municipal,
				p_logradouro,
				p_numero,
				p_complemento,
				p_bairro,
				p_cep,
				p_pais,
				p_uf,
				p_municipio,
				p_telefone,
				p_rntrc);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_emitente(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_grupo_clientes(integer, character varying)

-- DROP FUNCTION dsoft_novo_grupo_clientes(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_grupo_clientes(p_codigo integer, p_nome character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	auxiliar := situacao from clientes_grupos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    if (p_nome = null) then
    	return false;
    end if;
    
    insert into clientes_grupos (codigo, nome) values (p_codigo, p_nome);
    
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_grupo_clientes(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer)

-- DROP FUNCTION dsoft_novo_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_grupo_tributario(p_codigo integer, p_nome character varying, p_icms double precision, p_ipi double precision, p_pis double precision, p_cofins double precision, p_csll double precision, p_irrf double precision, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	if (p_codigo is null or p_codigo = 0) then
		return false;
	end if;

	if (p_nome is null or p_nome = '') then
		return false;
	end if;

	if (p_icms is null) then
		return false;
	end if;

	if (p_ipi is null) then
		return false;
	end if;

	if (p_pis is null) then
		return true;
	end if;

	if (p_cofins is null) then
		return false;
	end if;

	if (p_csll is null) then
		return false;
	end if;

	if (p_irrf is null) then
		return false;
	end if;

	perform nome from grupos_tributarios where codigo = p_codigo;

	if (found) then
		return false;
	end if;

	insert into grupos_tributarios (codigo, nome, icms, ipi, pis, cofins, csll, irrf, usuario)
		values (p_codigo, p_nome, p_icms, p_ipi, p_pis, p_cofins, p_csll, p_irrf, p_usuario);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_grupo_tributario(integer, character varying, double precision, double precision, double precision, double precision, double precision, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_item(integer, integer, integer, double precision, character varying, integer)

-- DROP FUNCTION dsoft_novo_item(integer, integer, integer, double precision, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_item(p_pedido integer, n_numero integer, cod_produto integer, p_fracao double precision, p_obs character varying, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO	varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO	varchar := 'ERRO_03';
declare USUARIO_CANCELADO	varchar := 'ERRO_02';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PEDIDO_CANCELADO	varchar := 'ERRO_15';
declare PEDIDO_BLOQUEADO	varchar := 'ERRO_16';

declare auxiliar		char;
--declare n_numero		integer;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	if (cod_produto < 1) then
		return CAMPO_INVALIDO || ' produto'::text;
	end if;

	auxiliar = situacao from cad_produtos where codigo = cod_produto limit 1;

	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO || ' produtos'::text;
	elseif (auxiliar = 'B') then
		return PRODUTO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PRODUTO_CANCELADO;
	end if;

	insert into pedidos_itens (pedido, produto, fracao, observacao, usuario, numero)
		values (p_pedido, cod_produto, p_fracao, p_obs, cod_usuario, n_numero);

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_item(integer, integer, integer, double precision, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_item(integer, integer, double precision, double precision, character varying, integer, double precision)

-- DROP FUNCTION dsoft_novo_item(integer, integer, double precision, double precision, character varying, integer, double precision);

CREATE OR REPLACE FUNCTION dsoft_novo_item(p_pedido integer, cod_produto integer, p_fracao double precision, p_preco double precision, p_obs character varying, cod_usuario integer, p_unitario double precision)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO	varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO	varchar := 'ERRO_03';
declare USUARIO_CANCELADO	varchar := 'ERRO_02';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PEDIDO_CANCELADO	varchar := 'ERRO_15';
declare PEDIDO_BLOQUEADO	varchar := 'ERRO_16';

declare auxiliar		char;
declare n_numero		integer;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	if (cod_produto < 1) then
		return CAMPO_INVALIDO || ' produto'::text;
	end if;

	auxiliar = situacao from cad_produtos where codigo = cod_produto limit 1;

	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO || ' produtos'::text;
	elseif (auxiliar = 'B') then
		return PRODUTO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PRODUTO_CANCELADO;
	end if;

	if (p_fracao <= 0) then
		return CAMPO_INVALIDO || ' fracao'::text;
	end if;

	if (p_preco < 0) then
		return CAMPO_INVALIDO || ' preco'::text;
	end if;

	n_numero := numero from pedidos_itens where pedido = p_pedido order by numero desc limit 1;

	if (n_numero is null) then
		n_numero := 1;
	else
		n_numero := (n_numero + 1);
	end if;

	insert into pedidos_itens (pedido, produto, fracao, preco, observacao, usuario, numero, unitario)
		values (p_pedido, cod_produto, p_fracao, p_preco, p_obs, cod_usuario, n_numero, p_unitario);

	update pedidos set valor = (valor + p_preco), itens = (itens + 1)
		where indice = p_pedido;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_item(integer, integer, double precision, double precision, character varying, integer, double precision)
  OWNER TO dsoft;


-- Function: dsoft_novo_item2(integer, integer, integer, double precision, character varying, character varying, integer, double precision)

-- DROP FUNCTION dsoft_novo_item2(integer, integer, integer, double precision, character varying, character varying, integer, double precision);

CREATE OR REPLACE FUNCTION dsoft_novo_item2(p_pedido integer, cod_produto integer, cod_produto2 integer, p_preco double precision, p_obs character varying, p_obs2 character varying, cod_usuario integer, p_unitario double precision)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO	varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO	varchar := 'ERRO_03';
declare USUARIO_CANCELADO	varchar := 'ERRO_02';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PEDIDO_CANCELADO	varchar := 'ERRO_15';
declare PEDIDO_BLOQUEADO	varchar := 'ERRO_16';

declare auxiliar		char;
declare n_numero		integer;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	if (cod_produto < 1) then
		return CAMPO_INVALIDO || ' produto'::text;
	end if;

	auxiliar = situacao from cad_produtos where codigo = cod_produto limit 1;

	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO || ' produtos'::text;
	elseif (auxiliar = 'B') then
		return PRODUTO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PRODUTO_CANCELADO;
	end if;

	if (p_preco < 0) then
		return CAMPO_INVALIDO || ' preco'::text;
	end if;

	n_numero := numero from pedidos_itens where pedido = p_pedido order by numero desc limit 1;

	if (n_numero is null) then
		n_numero := 1;
	else
		n_numero := (n_numero + 1);
	end if;

	insert into pedidos_itens (pedido, produto, fracao, preco, observacao, usuario, numero, unitario)
		values (p_pedido, cod_produto, 0.5, p_preco, p_obs, cod_usuario, n_numero, p_unitario);
		
	insert into pedidos_itens (pedido, produto, fracao, preco, observacao, usuario, numero, unitario)
		values (p_pedido, cod_produto2, 0.5, 0, p_obs2, cod_usuario, n_numero, 0);

	update pedidos set valor = (valor + p_preco), itens = (itens + 1)
		where indice = p_pedido;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_item2(integer, integer, integer, double precision, character varying, character varying, integer, double precision)
  OWNER TO postgres;


-- Function: dsoft_novo_item2(integer, integer, integer, integer, integer)

-- DROP FUNCTION dsoft_novo_item2(integer, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_item2(p_pedido integer, p_item integer, cod_produto integer, p_fracao integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO	varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO	varchar := 'ERRO_03';
declare USUARIO_CANCELADO	varchar := 'ERRO_02';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PEDIDO_CANCELADO	varchar := 'ERRO_15';
declare PEDIDO_BLOQUEADO	varchar := 'ERRO_16';

declare auxiliar		char;
declare n_numero		integer;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	if (cod_produto < 1) then
		return CAMPO_INVALIDO || ' produto'::text;
	end if;

	auxiliar = situacao from cad_produtos where codigo = cod_produto limit 1;

	if (auxiliar is null) then
		return CODIGO_NAO_ENCONTRADO || ' produtos'::text;
	elseif (auxiliar = 'B') then
		return PRODUTO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PRODUTO_CANCELADO;
	end if;

	insert into pedidos_itens (pedido, produto, fracao, usuario, numero)
		values (p_pedido, cod_produto, p_fracao::double precision, cod_usuario, p_item);

	update pedidos set itens = (itens + 1)
		where indice = p_pedido;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_item2(integer, integer, integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_local(integer, character varying, character varying, character, integer)

-- DROP FUNCTION dsoft_novo_local(integer, character varying, character varying, character, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_local(p_codigo integer, p_nome character varying, p_descricao character varying, p_tipo character, p_responsavel integer)
  RETURNS boolean AS
$BODY$

begin

	insert into locais (codigo, nome, descricao, tipo, responsavel)
		values (p_codigo, p_nome, p_descricao, p_tipo, p_responsavel);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_local(integer, character varying, character varying, character, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_lote_notas(integer, integer, character, character, integer)

-- DROP FUNCTION dsoft_novo_lote_notas(integer, integer, character, character, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_lote_notas(p_inicial integer, p_final integer, p_serie character, p_tipo character, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	if (p_inicial is null or p_inicial < 0) then
		return false;
	end if;

	if (p_final is null or p_final < 0) then
		return false;
	end if;

	insert into notas_lotes (inicial, final, serie, tipo, usuario)
		values (p_inicial, p_final, p_serie, p_tipo, p_usuario);

	return true;

end;

$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_lote_notas(integer, integer, character, character, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_manifesto(bigint, date, integer, character varying, integer)

-- DROP FUNCTION dsoft_novo_manifesto(bigint, date, integer, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_manifesto(p_emitente bigint, p_data date, p_motorista integer, p_veiculo character varying, p_usuario integer)
  RETURNS integer AS
$BODY$

declare p_indice integer;

begin

	insert into manifestos (emitente, montagem_data, montagem_hora, motorista, veiculo, usuario)
		values (p_emitente, p_data, now(), p_motorista, p_veiculo, p_usuario);

	p_indice := indice from manifestos order by indice desc limit 1;

	return p_indice;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_manifesto(bigint, date, integer, character varying, integer)
  OWNER TO postgres;



-- Function: dsoft_novo_material(integer, character varying, character varying, integer, integer, integer, integer)

-- DROP FUNCTION dsoft_novo_material(integer, character varying, character varying, integer, integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_material(p_codigo integer, p_nome character varying, p_descricao character varying, p_fornecedor integer, p_tipo integer, p_medida integer, p_usuario integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null or p_nome is null) then
		return false;
	end if;
    
	auxiliar := situacao from cad_materiais where codigo = p_codigo;

	if (auxiliar is not null) then
		return false;
	end if;
    
	insert into cad_materiais (codigo, nome, descricao, fornecedor, tipo, medida, usuario)
		values (p_codigo, p_nome, p_descricao, p_fornecedor, p_tipo, p_medida, p_usuario);
        
	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_material(integer, character varying, character varying, integer, integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date)

-- DROP FUNCTION dsoft_novo_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date);

CREATE OR REPLACE FUNCTION dsoft_novo_motorista(p_nome character varying, p_cpf bigint, p_endereco character varying, p_cidade character varying, p_estado character varying, p_telefone character varying, p_habilitacao character varying, p_nacimento date)
  RETURNS boolean AS
$BODY$

begin

	select nome from cad_motoristas where cpf = p_cpf;

	if (found) then
		return false;
	end if;

	insert into cad_motoristas (nome,
				cpf,
				endereco,
				cidade,
				estado,
				telefone,
				habilitacao,
				nascimento) values (
				p_nome,
				p_cpf,
				p_endereco,
				p_cidade,
				p_estado,
				p_telefone,
				p_habilitacao,
				p_nascimento);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_motorista(character varying, bigint, character varying, character varying, character varying, character varying, character varying, date)
  OWNER TO postgres;


-- Function: dsoft_novo_pagamento(bigint, integer, date, time without time zone, date, character, integer, double precision, double precision, integer)

-- DROP FUNCTION dsoft_novo_pagamento(bigint, integer, date, time without time zone, date, character, integer, double precision, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_pagamento(p_cliente bigint, p_pedido integer, p_data date, p_hora time without time zone, p_vencimento date, p_tipo character, p_numero integer, p_valor double precision, p_juros double precision, p_usuario integer)
  RETURNS bigint AS
$BODY$

declare p_filial integer;
declare p_indice integer;
declare p_codigo varchar;

begin

	p_filial := codigo from cad_filiais limit 1;

	p_codigo := to_char(p_filial, '000000');
	p_codigo := p_codigo || to_char(p_pedido, '000000');

	insert into pagamentos (cliente, pedido, data, hora, vencimento, tipo, parcela, valor, juros, usuario, situacao)
		values (p_cliente, p_pedido, p_data, p_hora, p_vencimento, p_tipo, p_numero, p_valor, p_juros, p_usuario, 'A');

	p_indice := indice from pagamentos order by indice desc limit 1;

	p_codigo := p_codigo || to_char(p_indice, '000000');

	update pagamentos set numero = to_number(p_codigo, '999999999999999999')::bigint where indice = p_indice;

	return to_number(p_codigo, '999999999999999999')::bigint;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_pagamento(bigint, integer, date, time without time zone, date, character, integer, double precision, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_pedido(integer, character varying, bigint, integer, numeric)

-- DROP FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric);

CREATE OR REPLACE FUNCTION dsoft_novo_pedido(cod_usuario integer, p_obs character varying, cod_cliente bigint, p_caixa integer, p_valor numeric)
  RETURNS integer AS
$BODY$
declare USUARIO_INVALIDO		integer := 0;
declare USUARIO_CANCELADO		integer := -2;
declare USUARIO_BLOQUEADO		integer := -3;
declare CLIENTE_BLOQUEADO		integer := -18;
declare CLIENTE_CANCELADO		integer := -19;
declare OPERACAO_NEGADA			integer := -9;

declare auxiliar				char;
declare n_pedido				integer;

begin

	if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return OPERACAO_NEGADA;
    end if;
    
    if (cod_cliente is not null and cod_cliente > 0) then
      
      auxiliar := situacao from cad_clientes where codigo = cod_cliente;
      
      if (auxiliar = 'B') then
          return CLIENTE_BLOQUEADO;
      elseif (auxiliar = 'C') then
          return CLIENTE_CANCELADO;
      end if;
      
      insert into pedidos (usuario, observacao, cliente, caixa, total)
          values (cod_usuario, p_obs, cod_cliente, p_caixa, p_valor);
          
    else

      insert into pedidos (usuario, observacao, caixa, total)
          values (cod_usuario, p_obs, p_caixa, p_valor);

	end if;
    
    n_pedido := indice from pedidos order by indice desc limit 1;
    	
    return n_pedido;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric)
  OWNER TO postgres;


-- Function: dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer, integer)

-- DROP FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_pedido(cod_usuario integer, p_obs character varying, cod_cliente bigint, p_caixa integer, p_valor numeric, p_vendedor integer, p_tabela integer)
  RETURNS integer AS
$BODY$
declare USUARIO_INVALIDO		integer := 0;
declare USUARIO_CANCELADO		integer := -2;
declare USUARIO_BLOQUEADO		integer := -3;
declare CLIENTE_BLOQUEADO		integer := -18;
declare CLIENTE_CANCELADO		integer := -19;
declare OPERACAO_NEGADA			integer := -9;

declare auxiliar				char;
declare n_pedido				integer;

begin

	if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return OPERACAO_NEGADA;
    end if;
    
    if (cod_cliente is not null and cod_cliente > 0) then
      
      auxiliar := situacao from cad_clientes where codigo = cod_cliente;
      
      if (auxiliar = 'B') then
          return CLIENTE_BLOQUEADO;
      elseif (auxiliar = 'C') then
          return CLIENTE_CANCELADO;
      end if;
      
      insert into pedidos (usuario, observacao, cliente, caixa, total, vendedor, tabela)
          values (cod_usuario, p_obs, cod_cliente, p_caixa, p_valor, p_vendedor, p_tabela);
          
    else

      insert into pedidos (usuario, observacao, caixa, total, vendedor, tabela)
          values (cod_usuario, p_obs, p_caixa, p_valor, p_vendedor, p_tabela);

	end if;
    
    n_pedido := indice from pedidos order by indice desc limit 1;
    	
    return n_pedido;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer)

-- DROP FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_pedido(cod_usuario integer, p_obs character varying, cod_cliente bigint, p_caixa integer, p_valor numeric, p_vendedor integer)
  RETURNS integer AS
$BODY$
declare USUARIO_INVALIDO		integer := 0;
declare USUARIO_CANCELADO		integer := -2;
declare USUARIO_BLOQUEADO		integer := -3;
declare CLIENTE_BLOQUEADO		integer := -18;
declare CLIENTE_CANCELADO		integer := -19;
declare OPERACAO_NEGADA			integer := -9;

declare auxiliar				char;
declare n_pedido				integer;

begin

	if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return OPERACAO_NEGADA;
    end if;
    
    if (cod_cliente is not null and cod_cliente > 0) then
      
      auxiliar := situacao from cad_clientes where codigo = cod_cliente;
      
      if (auxiliar = 'B') then
          return CLIENTE_BLOQUEADO;
      elseif (auxiliar = 'C') then
          return CLIENTE_CANCELADO;
      end if;
      
      insert into pedidos (usuario, observacao, cliente, caixa, total, vendedor)
          values (cod_usuario, p_obs, cod_cliente, p_caixa, p_valor, p_vendedor);
          
    else

      insert into pedidos (usuario, observacao, caixa, total, vendedor)
          values (cod_usuario, p_obs, p_caixa, p_valor, p_vendedor);

	end if;
    
    n_pedido := indice from pedidos order by indice desc limit 1;
    	
    return n_pedido;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer, numeric, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_pedido(integer, character varying, bigint, integer)

-- DROP FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_pedido(cod_usuario integer, p_obs character varying, cod_cliente bigint, p_caixa integer)
  RETURNS integer AS
$BODY$
declare USUARIO_INVALIDO		integer := 0;
declare USUARIO_CANCELADO		integer := -2;
declare USUARIO_BLOQUEADO		integer := -3;
declare CLIENTE_BLOQUEADO		integer := -18;
declare CLIENTE_CANCELADO		integer := -19;
declare OPERACAO_NEGADA			integer := -9;

declare auxiliar				char;
declare n_pedido				integer;

begin

	if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return OPERACAO_NEGADA;
    end if;
    
    if (cod_cliente is not null and cod_cliente > 0) then
      
      auxiliar := situacao from cad_clientes where codigo = cod_cliente;
      
      if (auxiliar = 'B') then
          return CLIENTE_BLOQUEADO;
      elseif (auxiliar = 'C') then
          return CLIENTE_CANCELADO;
      end if;
      
      insert into pedidos (usuario, observacao, cliente, caixa)
          values (cod_usuario, p_obs, cod_cliente, p_caixa);
          
    else

      insert into pedidos (usuario, observacao, caixa)
          values (cod_usuario, p_obs, p_caixa);

	end if;
    
    n_pedido := indice from pedidos order by indice desc limit 1;
    	
    return n_pedido;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_pedido(integer, character varying, bigint, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint)

-- DROP FUNCTION dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint);

CREATE OR REPLACE FUNCTION dsoft_novo_produto(cod_produto bigint, nome_produto character varying, tipo_produto integer, grupo_produto integer, descr_produto character varying, _grupo_tributario integer, _medida integer, p_producao boolean, p_fornecedor bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_JA_CADASTRADO 	varchar := 'ERRO_04';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare ERRO_NA_INCLUSAO	varchar := 'ERRO_07';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar		varchar;

declare p_tipo			integer;
declare p_grupo			integer;
declare p_grupo_tributario	integer;
declare p_medida		integer;

declare cod_cursor		refcursor;
declare cod_tabela		integer;

declare controla_estoque	boolean;

begin

	auxiliar := nome from cad_produtos where codigo = cod_produto limit 1;
    
	if (auxiliar is not null) then
		return CODIGO_JA_CADASTRADO;
	end if;
    
	if (cod_produto < 1 or cod_produto is null) then
		return CODIGO_INVALIDO;
	end if;
    
	if (nome_produto is NULL) then
		return CAMPO_INVALIDO || " nome"::text;
	end if;
    
	if (tipo_produto = 0) then
		p_tipo := null;
	else
		p_tipo := tipo_produto;
	end if;

	if (grupo_produto = 0) then
		p_grupo := null;
	else
		p_grupo := grupo_produto;
	end if;

	if (_grupo_tributario = 0) then
		p_grupo_tributario := null;
	else
		p_grupo_tributario := _grupo_tributario;
	end if;

	if (_medida = 0) then
		p_medida := null;
	else
		p_medida := _medida;
	end if;

	insert into cad_produtos (codigo, nome, tipo, grupo, descricao, grupo_tributario, medida, producao, fornecedor)
		values (cod_produto, nome_produto, p_tipo, p_grupo, descr_produto, p_grupo_tributario, p_medida, p_producao, p_fornecedor);

	-- Adicionamos o produto da tabela de estoque
	insert into estoque (produto) values (cod_produto);

	open cod_cursor for select codigo from cad_tabelas;

	fetch cod_cursor into cod_tabela;

	while (cod_tabela is not null) loop
		insert into produtos_precos (tabela, produto, preco)
			values (cod_tabela, cod_produto, 0);

		fetch cod_cursor into cod_tabela;
	end loop;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint)
  OWNER TO postgres;


-- Function: dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer)

-- DROP FUNCTION dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_produto(cod_produto bigint, nome_produto character varying, tipo_produto integer, grupo_produto integer, descr_produto character varying, _grupo_tributario integer, _medida integer, p_producao boolean, p_fornecedor bigint, p_foto character varying, p_ncm character varying, p_cfop character varying, p_ean character varying, p_ean_trib character varying, p_med_trib integer, p_qtd_trib integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_JA_CADASTRADO 	varchar := 'ERRO_04';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare ERRO_NA_INCLUSAO	varchar := 'ERRO_07';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar		varchar;

declare p_tipo			integer;
declare p_grupo			integer;
declare p_grupo_tributario	integer;
declare p_medida		integer;

declare cod_cursor		refcursor;
declare cod_tabela		integer;

declare controla_estoque	boolean;

begin

	auxiliar := nome from cad_produtos where codigo = cod_produto limit 1;
    
	if (auxiliar is not null) then
		return CODIGO_JA_CADASTRADO;
	end if;
    
	if (cod_produto < 1 or cod_produto is null) then
		return CODIGO_INVALIDO;
	end if;
    
	if (nome_produto is NULL) then
		return CAMPO_INVALIDO || " nome"::text;
	end if;
    
	if (tipo_produto = 0) then
		p_tipo := null;
	else
		p_tipo := tipo_produto;
	end if;

	if (grupo_produto = 0) then
		p_grupo := null;
	else
		p_grupo := grupo_produto;
	end if;

	if (_grupo_tributario = 0) then
		p_grupo_tributario := null;
	else
		p_grupo_tributario := _grupo_tributario;
	end if;

	if (_medida = 0) then
		p_medida := null;
	else
		p_medida := _medida;
	end if;

	insert into cad_produtos (codigo, nome, tipo, grupo, descricao, grupo_tributario, medida, producao, fornecedor, foto, ncm, cfop, ean, ean_trib, medida_tributavel, quantidade_tributavel)
		values (cod_produto, nome_produto, p_tipo, p_grupo, descr_produto, p_grupo_tributario, p_medida, p_producao, p_fornecedor, p_foto, p_ncm, p_cfop, p_ean, p_ean_trib, p_med_trib, p_qtd_trib);

	-- Adicionamos o produto da tabela de estoque
	insert into estoque (produto) values (cod_produto);

	open cod_cursor for select codigo from cad_tabelas;

	fetch cod_cursor into cod_tabela;

	while (cod_tabela is not null) loop
		insert into produtos_precos (tabela, produto, preco)
			values (cod_tabela, cod_produto, 0);

		fetch cod_cursor into cod_tabela;
	end loop;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_produto(bigint, character varying, integer, integer, character varying, integer, integer, boolean, bigint, character varying, character varying, character varying, character varying, character varying, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_produto_grupo(integer, character varying)

-- DROP FUNCTION dsoft_novo_produto_grupo(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_produto_grupo(p_codigo integer, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null)then
    	return false;
    end if;
    
	auxiliar := situacao from produtos_grupos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    if (p_descricao is null) then
    	return false;
    end if;
    
    insert into produtos_grupos (codigo, descricao)
    	values (p_codigo, p_descricao);

	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_produto_grupo(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer)

-- DROP FUNCTION dsoft_novo_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_produto_tipo(p_codigo integer, p_nome character varying, p_descricao character varying, p_producao boolean, p_estoque boolean, p_soma boolean, p_impressora integer)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null or p_nome is null) then
		return false;
	end if;
    
	auxiliar := situacao from produtos_tipos where codigo = p_codigo;

	if (auxiliar is not null) then
		return false;
	end if;
    
	insert into produtos_tipos (codigo, nome, descricao, producao, estoque, soma, impressora_externa)
		values (p_codigo, p_nome, p_descricao, p_producao, p_estoque, p_soma, p_impressora);
        
	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_produto_tipo(integer, character varying, character varying, boolean, boolean, boolean, integer)
  OWNER TO postgres;



-- Function: dsoft_novo_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_novo_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_recurso(p_codigo integer, p_nome character varying, p_tipo character, cod_usuario integer, p_nascimento date, p_tel1 bigint, p_tel2 bigint, p_celular bigint, p_endereco character varying, p_cidade character varying, p_estado character varying, p_rg character varying, p_cpf character varying, p_habilitacao character varying, p_categoria character varying)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CODIGO_JA_CADASTRADO	varchar := 'ERRO_04';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return CODIGO_JA_CADASTRADO;
    end if;
    
    insert into cad_recursos (codigo, nome, tipo, usuario, nascimento, tel1, tel2, celular, endereco, cidade, estado, rg, cpf, habilitacao, categoria)
    	values (p_codigo, p_nome, p_tipo, cod_usuario, p_nascimento, p_tel1, p_tel2, p_celular, p_endereco, p_cidade, p_estado, p_rg, p_cpf, p_habilitacao, p_categoria);    

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_recurso(integer, character varying, character, integer, date, bigint, bigint, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;



-- Function: dsoft_novo_recurso_grupo(integer, character varying)

-- DROP FUNCTION dsoft_novo_recurso_grupo(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_recurso_grupo(p_codigo integer, p_descricao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	if (p_codigo is null)then
    	return false;
    end if;
    
	auxiliar := situacao from recursos_grupos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    if (p_descricao is null) then
    	return false;
    end if;
    
    insert into recursos_grupos (codigo, descricao)
    	values (p_codigo, p_descricao);

	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_recurso_grupo(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric)

-- DROP FUNCTION dsoft_novo_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric);

CREATE OR REPLACE FUNCTION dsoft_novo_recurso_tipo(p_codigo character, p_descricao character varying, p_entrega boolean, p_producao boolean, p_com_dia numeric, p_com_nom numeric, p_fixo_sem numeric, p_fixo_mes numeric, p_valor_entrega numeric)
  RETURNS boolean AS
$BODY$
declare auxiliar varchar;

begin

	if (p_codigo is null) then
    	return false;
    end if;
    
	auxiliar := descricao from recursos_tipos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    insert into recursos_tipos (codigo,
    							descricao,
                                entrega,
                                producao,
                                comissao_diaria,
                                comissao_nominal,
                                fixo_semanal,
                                fixo_mensal,
                                valor_entrega
                                ) values (
                                p_codigo,
                                p_descricao,
                                p_entrega,
                                p_producao,
                                p_com_dia,
                                p_com_nom,
                                p_fixo_sem,
                                p_fixo_mes,
                                p_valor_entrega);
                                
	return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_recurso_tipo(character, character varying, boolean, boolean, numeric, numeric, numeric, numeric, numeric)
  OWNER TO postgres;


-- Function: dsoft_novo_resumo(integer, integer, date, time without time zone, integer, integer, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, integer)

-- DROP FUNCTION dsoft_novo_resumo(integer, integer, date, time without time zone, integer, integer, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_novo_resumo(p_filial integer, p_indice integer, p_data date, p_hora time without time zone, p_usuario integer, p_caixa integer, p_anterior double precision, p_saldo double precision, p_entrada double precision, p_saida double precision, p_vales double precision, p_despesas double precision, p_pagamentos double precision, p_transferencias double precision, p_vendas double precision, p_volume integer)
  RETURNS boolean AS
$BODY$

begin

	insert into resumos (filial,
				indice_real,
				data,
				hora,
				usuario,
				caixa,
				saldo_anterior,
				saldo,
				entrada,
				saida,
				vales,
				despesas,
				pagamentos,
				transferencias,
				vendas,
				volume)
				values (
				p_filial,
				p_indice,
				p_data,
				p_hora,
				p_usuario,
				p_caixa,
				p_anterior,
				p_saldo,
				p_entrada,
				p_saida,
				p_vales,
				p_despesas,
				p_pagamentos,
				p_transferencias,
				p_vendas,
				p_volume);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_resumo(integer, integer, date, time without time zone, integer, integer, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, double precision, integer)
  OWNER TO postgres;


-- Function: dsoft_novo_tipo_clientes(integer, character varying)

-- DROP FUNCTION dsoft_novo_tipo_clientes(integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_tipo_clientes(p_codigo integer, p_nome character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar	char;

begin

	auxiliar := situacao from clientes_tipos where codigo = p_codigo;
    
    if (auxiliar is not null) then
    	return false;
    end if;
    
    if (p_nome = null) then
    	return false;
    end if;
    
    insert into clientes_tipos (codigo, nome) values (p_codigo, p_nome);
    
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_tipo_clientes(integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_novo_usuario(integer, character varying, character varying, character)

-- DROP FUNCTION dsoft_novo_usuario(integer, character varying, character varying, character);

CREATE OR REPLACE FUNCTION dsoft_novo_usuario(cod_usuario integer, nome_usuario character varying, senha_usuario character varying, nivel_usuario character)
  RETURNS character varying AS
$BODY$
declare CODIGO_JA_CADASTRADO 	varchar := 'ERRO_04';
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CAMPO_INVALIDO		varchar := 'ERRO_06';
declare ERRO_NA_INCLUSAO	varchar := 'ERRO_07';
declare INCLUSAO_OK		varchar := 'OK';

declare dados 			integer;
declare strings			varchar;

begin

	dados := codigo from cad_usuarios where codigo = cod_usuario limit 1;

	if (dados is not null) then
		return CODIGO_JA_CADASTRADO;
	end if;

	if (cod_usuario < 1) then
		return CODIGO_INVALIDO;
	end if;

	if (nome_usuario is null) then
		return CAMPO_INVALIDO || ' nome'::text;
	end if;

	if (senha_usuario is null) then
		return CAMPO_INVALIDO || ' senha'::text;
	end if;

	if (nivel_usuario is null) then
		return CAMPO_INVALIDO || ' nivel'::text;
	end if;

	strings := descricao from usuarios_nivel where codigo = nivel_usuario limit 1;

	if (strings is null) then
		return CAMPO_INVALIDO || ' nivel'::text;
	end if;

	insert into cad_usuarios (codigo, nome, senha, nivel) values (cod_usuario, nome_usuario, senha_usuario, nivel_usuario);

	strings := nome from cad_usuarios where codigo = cod_usuario limit 1;

	if (strings is null) then
		return ERRO_NA_INCLUSAO;
	end if;

	return INCLUSAO_OK;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_usuario(integer, character varying, character varying, character)
  OWNER TO postgres;


-- Function: dsoft_novo_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_novo_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_veiculo(p_placa character varying, p_modelo character varying, p_ano integer, p_cor character varying, p_marca character varying, p_proprietario character varying, p_endereco character varying, p_cidade character varying, p_estado character varying, p_telefone character varying, p_cpf character varying, p_renavam character varying)
  RETURNS boolean AS
$BODY$

begin

	perform modelo from cad_veiculos where placa = p_placa;

	if (found) then
		return false;
	end if;

	insert into cad_veiculos (placa,
				modelo,
				ano,
				cor,
				marca,
				proprietario,
				endereco,
				cidade,
				estado,
				telefone,
				cpf,
				renavam) values (
				p_placa,
				p_modelo,
				p_ano,
				p_cor,
				p_marca,
				p_proprietario,
				p_endereco,
				p_cidade,
				p_estado,
				p_telefone,
				p_cpf,
				p_renavam);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_veiculo(character varying, character varying, integer, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


-- Function: dsoft_paga_compra(integer, integer, integer)

-- DROP FUNCTION dsoft_paga_compra(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_paga_compra(p_usuario integer, p_compra integer, p_caixa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_valor			numeric;
declare situacao_atual	char;

begin

	auxiliar := situacao from compras where indice = p_compra;
    
    if (auxiliar is null or auxiliar = 'C' or auxiliar = 'P') then
    	return false;
    end if;
    
    if (auxiliar = 'A') then
    	situacao_atual := 'N';
    elseif (auxiliar = 'E') then
    	situacao_atual := 'P';
    end if;

	update compras set situacao = situacao_atual,
    					pagamento = now(),
                        pagamento_usuario = p_usuario,
                        valor_pago = valor
                        where indice = p_compra;
                        
    n_valor := valor_pago from compras where indice = p_compra;
                        
	insert into caixa_fluxo (tipo, valor, usuario, compra, caixa)
    	values ('P', n_valor, p_usuario, p_compra, p_caixa);
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_paga_compra(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_paga_despesa(integer, integer, integer)

-- DROP FUNCTION dsoft_paga_despesa(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_paga_despesa(p_usuario integer, p_despesa integer, p_caixa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_valor			numeric;

begin

	auxiliar := situacao from despesas where indice = p_despesa;
    
    if (auxiliar is null or auxiliar = 'C' or auxiliar = 'P') then
    	return false;
    end if;

	update despesas set situacao = 'P',
    					pagamento = now(),
                        pagamento_usuario = p_usuario,
                        valor_pago = valor
                        where indice = p_despesa;
                        
    n_valor := valor_pago from despesas where indice = p_despesa;
                        
	insert into caixa_fluxo (tipo, valor, usuario, despesa, caixa)
    	values ('D', n_valor, p_usuario, p_despesa, p_caixa);
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_paga_despesa(integer, integer, integer)
  OWNER TO postgres;


-- Function: dsoft_paga_pedido(integer, integer, numeric, character, character varying, integer)

-- DROP FUNCTION dsoft_paga_pedido(integer, integer, numeric, character, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_paga_pedido(p_pedido integer, cod_usuario integer, p_valor numeric, p_tipo character, p_documento character varying, p_caixa integer)
  RETURNS integer AS
$BODY$
declare USUARIO_INVALIDO	integer := 0;
declare USUARIO_CANCELADO	integer := -2;
declare USUARIO_BLOQUEADO	integer := -3;
declare CODIGO_INVALIDO		integer := -5;
declare OPERACAO_NEGADA		integer := -9;
declare SALDO_INSUFICIENTE	integer := -13;

declare auxiliar		char;
declare total_			numeric;
declare valor_pedido		numeric;
declare total_pagamentos	numeric;
declare total_pedido		numeric;
declare saldo_cliente		double precision;
declare limite_cliente		double precision;
declare n_cliente		bigint;
declare n_pagamento		integer;
declare _debito			boolean;

begin

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario;

	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	if (p_pedido < 1) then
		return CODIGO_INVALIDO;
	end if;

	auxiliar := situacao from pedidos where indice = p_pedido;

	if (auxiliar = 'B' or auxiliar = 'C') then
		return OPERACAO_NEGADA;
	elseif (auxiliar = 'N' or auxiliar = 'O' or auxiliar = 'P') then
		return OPERACAO_NEGADA;
	end if;

	total_ := sum(valor) from pagamentos where pedido = p_pedido and (situacao = 'A' or situacao = 'P');

	valor_pedido := total from pedidos where indice = p_pedido;

	if ((total_ + p_valor) > valor_pedido) then
		return OPERACAO_NEGADA;
	end if;

	n_cliente := cliente from pedidos where indice = p_pedido;
	
	_debito := debito from pagamentos_formas where codigo = p_tipo;

	if (_debito = true) then			
		if (n_cliente is null or n_cliente < 1) then
			return OPERACAO_NEGADA;
		end if;
		
		saldo_cliente := saldo from cad_clientes where codigo in (select cliente from pedidos where indice = p_pedido);
		limite_cliente := credito_limite from cad_clientes where codigo in (select cliente from pedidos where indice = p_pedido);

		if (p_valor > (saldo_cliente + limite_cliente)) then
			return SALDO_INSUFICIENTE;
		else
			update cad_clientes set saldo = saldo - p_valor where codigo in (select cliente from pedidos where indice = p_pedido);
		end if;
	end if;

	insert into pagamentos (pedido, tipo, usuario, valor, documento)
		values (p_pedido, p_tipo, cod_usuario, p_valor, p_documento);

	n_pagamento := indice from pagamentos order by indice desc limit 1;

	-- Insere o registro no fluxo de caixa para calcular fechamento    
	insert into caixa_fluxo (tipo, valor, usuario, pedido, caixa, forma, observacao, cliente, pagamento)
		values ('E', p_valor, cod_usuario, p_pedido, p_caixa, p_tipo, 'REFERENTE AO PEDIDO N. ' || to_char(p_pedido, '99999999') || '  -  ' || p_documento, n_cliente, n_pagamento);

	total_pagamentos := sum(valor) from pagamentos where pedido = p_pedido and (situacao = 'A' or situacao = 'P');

	total_pedido := total from pedidos where indice = p_pedido;

	if (total_pagamentos >= total_pedido) then

		if (auxiliar = 'A') then

			update pedidos set situacao = 'N' where indice = p_pedido;

		elseif (auxiliar = 'E') then

			update pedidos set situacao = 'P' where indice = p_pedido;

		elseif (auxiliar = 'S') then

			update pedidos set situacao = 'O' where indice = p_pedido;

		end if;

	end if;

	return indice from pagamentos order by indice desc limit 1;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_paga_pedido(integer, integer, numeric, character, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_paga_pedido_crediario(integer, integer)

-- DROP FUNCTION dsoft_paga_pedido_crediario(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_paga_pedido_crediario(p_pedido integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare auxiliar character;
declare total_pagamentos double precision;
declare total_pedido double precision;

begin

	auxiliar := situacao from pedidos where indice = p_pedido;

	if (auxiliar is null) then
		return false;
	end if;

	if (auxiliar = 'C' or auxiliar = 'B') then
		return false;
	end if;

	if (auxiliar = 'N' or auxiliar = 'P' or auxiliar = 'O') then
		return false;
	end if;

	total_pagamentos := sum(valor) from pagamentos where pedido = p_pedido and situacao = 'A' or situacao = 'P';
	total_pedido := total from pedidos where indice = p_pedido;

	if (total_pagamentos >= total_pedido) then

		if (auxiliar = 'A') then

			update pedidos set situacao = 'N' where indice = p_pedido;

		elseif (auxiliar = 'E') then

			update pedidos set situacao = 'P' where indice = p_pedido;

		elseif (auxiliar = 'S') then

			update pedidos set situacao = 'O' where indice = p_pedido;

		end if;

	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_paga_pedido_crediario(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_pagamentos_pendentes(bigint)

-- DROP FUNCTION dsoft_pagamentos_pendentes(bigint);

CREATE OR REPLACE FUNCTION dsoft_pagamentos_pendentes(p_cliente bigint)
  RETURNS double precision AS
$BODY$

declare v_valor double precision;
declare v_juros double precision;

begin

	v_valor := sum(valor) from pagamentos where cliente = p_cliente and tipo = 'P' and situacao = 'P';
	v_juros := sum(juros) from pagamentos where cliente = p_cliente and tipo = 'P' and situacao = 'P';

	if (v_valor is null) then
		v_valor := 0;
	end if;

	if (v_juros is null) then
		v_juros := 0;
	end if;

	return (v_valor + v_juros);

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_pagamentos_pendentes(bigint)
  OWNER TO postgres;


-- Function: dsoft_produtos_fechamento(integer)

-- DROP FUNCTION dsoft_produtos_fechamento(integer);

CREATE OR REPLACE FUNCTION dsoft_produtos_fechamento(p_fechamento integer)
  RETURNS double precision AS
$BODY$

begin

	return sum(pedidos_itens.fracao) from pedidos_itens left join pedidos on (pedidos.indice = pedidos_itens.pedido)
		where pedidos.fechamento = p_fechamento and pedidos.situacao <> 'C' and pedidos_itens.situacao <> 'C';

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_produtos_fechamento(integer)
  OWNER TO postgres;


-- Function: dsoft_prox_cliente()

-- DROP FUNCTION dsoft_prox_cliente();

CREATE OR REPLACE FUNCTION dsoft_prox_cliente()
  RETURNS bigint AS
$BODY$

declare _prox bigint;

begin

	_prox := codigo from cad_clientes order by codigo desc limit 1;

	_prox := _prox + 1;

	return _prox;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_prox_cliente()
  OWNER TO postgres;


-- Function: dsoft_reativa_cliente(bigint, integer)

-- DROP FUNCTION dsoft_reativa_cliente(bigint, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_cliente(cod_cliente bigint, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare CLIENTE_CANCELADO		varchar := 'ERRO_20';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_usuario is null) then
    	return false;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    if (cod_cliente is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    end if;
    
    auxiliar := situacao from cad_clientes where codigo = cod_cliente;
    
    if (auxiliar is null) then
    	return CAMPO_INVALIDO || ' codigo'::text;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
	update cad_clientes set situacao = 'A',
    						cancelado = now(),
                            cancelado_usuario = cod_usuario
                            where codigo = cod_cliente;
    
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_cliente(bigint, integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_despesa(integer, integer)

-- DROP FUNCTION dsoft_reativa_despesa(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_despesa(p_usuario integer, p_despesa integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare n_pagamento		integer;

begin

	auxiliar := situacao from despesas where indice = p_despesa;
    
    if (auxiliar is null or auxiliar = 'A' or auxiliar = 'F' or auxiliar = 'V' or auxiliar = 'P') then
    	return false;
    end if;

	update despesas set situacao = 'A',
    					cancelado = now(),
                        cancelado_usuario = p_usuario
                        where indice = p_despesa;
                        
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_despesa(integer, integer)
  OWNER TO postgres;


  -- Function: dsoft_reativa_emitente(bigint)

-- DROP FUNCTION dsoft_reativa_emitente(bigint);

CREATE OR REPLACE FUNCTION dsoft_reativa_emitente(p_cnpj bigint)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (not found) then
		return false;
	end if;

	update cad_emitentes set situacao = 'A'
				where cnpj = p_cnpj;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_emitente(bigint)
  OWNER TO postgres;



-- Function: dsoft_reativa_grupo_tributario(integer, integer)

-- DROP FUNCTION dsoft_reativa_grupo_tributario(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_grupo_tributario(p_codigo integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	if (p_codigo is null or p_codigo = 0) then
		return false;
	end if;

	perform nome from grupos_tributarios where codigo = p_codigo;

	if (not found) then
		return false;
	end if;

	update grupos_tributarios set situacao = 'A' where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_grupo_tributario(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_local(integer)

-- DROP FUNCTION dsoft_reativa_local(integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_local(p_codigo integer)
  RETURNS boolean AS
$BODY$

begin

	update locais set situacao = 'A'
			where codigo = p_codigo;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_local(integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_material(integer)

-- DROP FUNCTION dsoft_reativa_material(integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_material(cod_material integer)
  RETURNS boolean AS
$BODY$

declare auxiliar		char;

begin

	auxiliar := situacao from cad_materiais where codigo = cod_material limit 1;

	if (auxiliar is null) then
		return false;
	end if;

	if (auxiliar = 'A') then
		return false;
	end if;

	if (cod_material < 1 or cod_material is null) then
		return false;
	end if;

	update cad_materiais set situacao = 'A'
		where codigo = cod_material;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_material(integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_motorista(bigint)

-- DROP FUNCTION dsoft_reativa_motorista(bigint);

CREATE OR REPLACE FUNCTION dsoft_reativa_motorista(p_cpf bigint)
  RETURNS boolean AS
$BODY$

begin

	select nome from cad_motoristas where cpf = p_cpf;

	if (not found) then
		return false;
	end if;

	update cad_motoristas set situacao = 'A'
				where cpf = p_cpf;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_motorista(bigint)
  OWNER TO postgres;


-- Function: dsoft_reativa_pedido(integer, integer)

-- DROP FUNCTION dsoft_reativa_pedido(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_pedido(p_pedido integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_pedido < 1) then
    	return CAMPO_INVALIDO || ' pedido'::text;
    end if;
    
    auxiliar := situacao from pedidos where indice = p_pedido limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO || ' pedido'::text;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    update pedidos set situacao = 'A',
    					cancelado = now(),
                        cancelado_usuario = cod_usuario
                        where indice = p_pedido;
                        
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_pedido(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_produto(bigint)

-- DROP FUNCTION dsoft_reativa_produto(bigint);

CREATE OR REPLACE FUNCTION dsoft_reativa_produto(cod_produto bigint)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO		varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO varchar := 'ERRO_10';
declare PRODUTO_CANCELADO	varchar := 'ERRO_11';
declare PRODUTO_BLOQUEADO	varchar := 'ERRO_12';
declare OPERACAO_NEGADA		varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA	varchar := 'OK';

declare auxiliar			char;

begin

	auxiliar := situacao from cad_produtos where codigo = cod_produto limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    end if;
    
    if (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (auxiliar = 'B') then
    	return PRODUTO_BLOQUEADO;
    end if;
    
    if (cod_produto < 1 or cod_produto is null) then
    	return CODIGO_INVALIDO;
    end if;
    
	update cad_produtos set situacao = 'A',
    						cancelado = now()
                            where codigo = cod_produto;
        
    return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_produto(bigint)
  OWNER TO postgres;


-- Function: dsoft_reativa_recurso(integer, integer)

-- DROP FUNCTION dsoft_reativa_recurso(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_recurso(p_codigo integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare RECURSO_BLOQUEADO		varchar := 'ERRO_20';
declare RECURSO_CANCELADO		varchar := 'ERRO_21';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (p_codigo is null or p_codigo < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario;
    
    if (cod_usuario is null or cod_usuario < 1 or auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    auxiliar := situacao from cad_recursos where codigo = p_codigo;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;    	
    
    update cad_recursos set situacao = 'A',
    			cancelado = now(),
                cancelado_usuario = cod_usuario
				where codigo = p_codigo;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_recurso(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_tabela(integer, integer)

-- DROP FUNCTION dsoft_reativa_tabela(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_tabela(cod_tabela integer, usuario integer)
  RETURNS character varying AS
$BODY$
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare TABELA_CANCELADA		varchar := 'ERRO_13';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	if (cod_tabela < 1) then
    	return CODIGO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_tabelas where codigo = cod_tabela limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_NAO_ENCONTRADO;
    elseif (auxiliar = 'B') then
    	return TABELA_BLOQUEADA;
    elseif (auxiliar = 'A') then
    	return OPERACAO_CONCLUIDA;
    end if;
    
    if (usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    end if;
    
    update cad_tabelas set situacao = 'A',
    						cancelada = now(),
                            cancelada_usuario = usuario
                            where codigo = cod_tabela;

	return OPERACAO_CONCLUIDA;    

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_tabela(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_usuario(integer)

-- DROP FUNCTION dsoft_reativa_usuario(integer);

CREATE OR REPLACE FUNCTION dsoft_reativa_usuario(cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_NAO_ENCONTRADO	varchar := 'ERRO_00';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;

begin

	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_NAO_ENCONTRADO;
    end if;
    
    update cad_usuarios set situacao = 'A', cancelado = now() where codigo = cod_usuario;
    
    return OPERACAO_CONCLUIDA;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_usuario(integer)
  OWNER TO postgres;


-- Function: dsoft_reativa_veiculo(character varying)

-- DROP FUNCTION dsoft_reativa_veiculo(character varying);

CREATE OR REPLACE FUNCTION dsoft_reativa_veiculo(p_placa character varying)
  RETURNS boolean AS
$BODY$

begin

	perform modelo from cad_veiculos where placa = p_placa;

	if (not found) then
		return false;
	end if;

	update cad_veiculos set situacao = 'A'
				where placa = p_placa;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_reativa_veiculo(character varying)
  OWNER TO postgres;


-- Function: dsoft_retorna_compra(integer, integer)

-- DROP FUNCTION dsoft_retorna_compra(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_retorna_compra(p_usuario integer, p_compra integer)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;
declare novo_estado		char;
declare c_produtos		refcursor;
declare c_indice		integer;
declare c_produto		integer;
declare c_quantidade	numeric;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from compras where indice = p_compra;
    
    if (auxiliar is null) then
    	return false;
    end if;
    
    if (auxiliar = 'A') then
    	return false;
    elseif (auxiliar = 'N') then
    	return false;
    elseif (auxiliar = 'P') then
    	novo_estado := 'N';
    elseif (auxiliar = 'E') then
    	novo_estado := 'A';
    end if;	

	update compras set situacao = novo_estado,
    					entregue = now(),
                        entregue_usuario = p_usuario
                        where indice = p_compra;
        
    -- Damos entrada no estoque                
	open c_produtos for select indice from compras_itens where compra = p_compra;
    
    fetch c_produtos into c_indice;
    
    while (c_indice is not null) loop
    
        c_produto := produto from compras_itens where indice = c_indice;
        c_quantidade := quantidade from compras_itens where indice = c_indice;

    	update estoque set quantidade = (quantidade - c_quantidade)
        	where produto = c_produto;
            
    	fetch c_produtos into c_indice;
            
    end loop;
    
    return true;
    
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_retorna_compra(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_retorna_manifesto(integer, integer)

-- DROP FUNCTION dsoft_retorna_manifesto(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_retorna_manifesto(p_indice integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare sit char;

begin

	sit := situacao from manifestos where indice = p_indice;

	if (sit is null) then
		return false;
	end if;

	if (sit = 'S') then

		update manifestos set situacao = 'A', saida_data = null, saida_hora = null where indice = p_indice;

		return true;

	elsif (sit = 'E') then

		update manifestos set situacao = 'S', chegada_data = null, chegada_hora = null where indice = p_indice;

		return true;

	end if;

	return false;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_retorna_manifesto(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_retorna_pedido(integer, integer)

-- DROP FUNCTION dsoft_retorna_pedido(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_retorna_pedido(p_pedido integer, cod_usuario integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare auxiliar				char;
declare cod_entrega				integer;
declare situacao_atual			char;

begin

	if (p_pedido < 1) then
    	return CAMPO_INVALIDO || ' pedido'::text;
    end if;
    
    auxiliar := situacao from pedidos where indice = p_pedido limit 1;
    
    if (auxiliar is null) then
    	return CODIGO_INVALIDO || ' pedido'::text;
    elseif (auxiliar = 'A' or auxiliar = 'N') then
    	return OPERACAO_CONCLUIDA;
    elseif (auxiliar = 'B') then
    	return PEDIDO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return PEDIDO_CANCELADO;
    end if;
    
    if (auxiliar = 'E' or auxiliar = 'S') then
    	situacao_atual := 'A';
    elseif (auxiliar = 'O' or auxiliar = 'P') then
    	situacao_atual := 'N';
    end if;
    
    if (cod_usuario < 1) then
    	return USUARIO_INVALIDO;
    end if;
    
    auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
    if (auxiliar is null) then
    	return USUARIO_INVALIDO;
    elseif (auxiliar = 'B') then
    	return USUARIO_BLOQUEADO;
    elseif (auxiliar = 'C') then
    	return USUARIO_CANCELADO;
    end if;
    
    cod_entrega := entrega from pedidos where indice = p_pedido;
    
    if (cod_entrega is not null) then
    
    	update entregas set situacao = 'C', usuario = cod_usuario
        	where indice = cod_entrega;
            
    end if;
    
    update pedidos set situacao = situacao_atual,
    					entregue = now(),
                        entregue_usuario = cod_usuario
                        where indice = p_pedido;
                        
	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_retorna_pedido(integer, integer)
  OWNER TO postgres;


-- Function: dsoft_saida_manifesto(integer, integer)

-- DROP FUNCTION dsoft_saida_manifesto(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_saida_manifesto(p_indice integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare sit character;

begin

	sit := situacao from manifestos where indice = p_indice;

	if (sit <> 'A') then
		return false;
	end if;

	update manifestos set saida_data = now(),
				saida_hora = now(),
				saida_usuario = p_usuario,
				situacao = 'S'
				where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_saida_manifesto(integer, integer)
  OWNER TO postgres;




-- Function: dsoft_saida_pedido(integer, integer, integer)

-- DROP FUNCTION dsoft_saida_pedido(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_saida_pedido(p_pedido integer, cod_usuario integer, cod_recurso integer)
  RETURNS character varying AS
$BODY$
declare USUARIO_INVALIDO		varchar := 'ERRO_00';
declare USUARIO_BLOQUEADO		varchar := 'ERRO_03';
declare USUARIO_CANCELADO		varchar := 'ERRO_02';
declare PEDIDO_BLOQUEADO		varchar := 'ERRO_16';
declare PEDIDO_CANCELADO		varchar := 'ERRO_15';
declare PEDIDO_ENTREGUE			varchar := 'ERRO_17';
declare CODIGO_INVALIDO			varchar := 'ERRO_05';
declare CODIGO_NAO_ENCONTRADO	varchar := 'ERRO_10';
declare CAMPO_INVALIDO			varchar := 'ERRO_06';
declare OPERACAO_NEGADA			varchar := 'ERRO_09';
declare OPERACAO_CONCLUIDA		varchar := 'OK';

declare situacao_atual			char;
declare auxiliar			char;
declare cod_entrega			integer;

begin

	if (p_pedido < 1) then
		return CAMPO_INVALIDO || ' pedido'::text;
	end if;
    
	auxiliar := situacao from pedidos where indice = p_pedido limit 1;

	if (auxiliar is null) then
		return CODIGO_INVALIDO || ' pedido'::text;
	elseif (auxiliar = 'B') then
		return PEDIDO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return PEDIDO_CANCELADO;
	elseif (auxiliar = 'E' or auxiliar = 'P') then
		return PEDIDO_ENTREGUE;
	elseif (auxiliar = 'S' or auxiliar = 'O') then
		update entregas set recurso = cod_recurso, usuario = cod_usuario where pedido = p_pedido;
	
		return OPERACAO_CONCLUIDA;
	end if;

	if (auxiliar = 'A') then
		situacao_atual := 'S';
	elseif (auxiliar = 'N') then
		situacao_atual := 'O';
	end if;

	if (cod_usuario < 1) then
		return USUARIO_INVALIDO;
	end if;
    
	auxiliar := situacao from cad_usuarios where codigo = cod_usuario limit 1;
    
	if (auxiliar is null) then
		return USUARIO_INVALIDO;
	elseif (auxiliar = 'B') then
		return USUARIO_BLOQUEADO;
	elseif (auxiliar = 'C') then
		return USUARIO_CANCELADO;
	end if;

	delete from entregas where pedido = p_pedido;
    
	insert into entregas (saida, recurso, usuario, pedido)
		values (now(), cod_recurso, cod_usuario, p_pedido);

	cod_entrega := indice from entregas order by indice desc limit 1;

	update pedidos set situacao = situacao_atual,
		saida = now(),
		saida_usuario = cod_usuario,
		entrega = cod_entrega
		where indice = p_pedido;

	return OPERACAO_CONCLUIDA;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_saida_pedido(integer, integer, integer)
  OWNER TO postgres;




-- Function: dsoft_sincroniza_produto(bigint, character varying, character, character varying, integer, integer, integer, integer, boolean)

-- DROP FUNCTION dsoft_sincroniza_produto(bigint, character varying, character, character varying, integer, integer, integer, integer, boolean);

CREATE OR REPLACE FUNCTION dsoft_sincroniza_produto(p_codigo bigint, p_nome character varying, p_situacao character, p_descricao character varying, p_grupo integer, p_tipo integer, p_g_tributario integer, p_medida integer, p_producao boolean)
  RETURNS boolean AS
$BODY$

declare aux character;

begin

	aux := situacao from cad_produtos where codigo = p_codigo;

	if (aux is null) then
		perform dsoft_novo_produto(p_codigo, p_nome, p_tipo, p_grupo, p_descricao, p_g_tributario, p_medida, p_producao);
	end if;

	if (aux <> p_situacao or
		(select nome from cad_produtos where codigo = p_codigo) <> p_nome or
		(select descricao from cad_produtos where codigo = p_codigo) <> p_descricao or
		(select grupo from cad_produtos where codigo = p_codigo) <> p_grupo or
		(select tipo from cad_produtos where codigo = p_codigo) <> p_tipo or
		(select grupo_tributario from cad_produtos where codigo = p_codigo) <> p_g_tributario or
		(select medida from cad_produtos where codigo = p_codigo) <> p_medida) then
		update cad_produtos set situacao = p_situacao,
					nome = p_nome,
					descricao = p_descricao,
					grupo = p_grupo,
					tipo = p_tipo,
					grupo_tributario = p_g_tributario,
					medida = p_medida
					where codigo = p_codigo;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_sincroniza_produto(bigint, character varying, character, character varying, integer, integer, integer, integer, boolean)
  OWNER TO postgres;


-- Function: dsoft_sincroniza_tabela(integer, character varying, character, character varying)

-- DROP FUNCTION dsoft_sincroniza_tabela(integer, character varying, character, character varying);

CREATE OR REPLACE FUNCTION dsoft_sincroniza_tabela(p_codigo integer, p_nome character varying, p_situacao character, p_descricao character varying)
  RETURNS boolean AS
$BODY$

declare aux character;

begin

	aux := situacao from cad_tabelas where codigo = p_codigo;

	if (aux is null) then
		perform dsoft_nova_tabela(p_codigo, p_nome, p_descricao, 0);
	end if;

	if (aux <> p_situacao) then
		update cad_tabelas set situacao = p_situacao where codigo = p_codigo;
	end if;

	if ((select nome from cad_tabelas where codigo = p_codigo) <> p_nome) then
		update cad_tabelas set nome = p_nome where codigo = p_codigo;
	end if;

	if ((select descricao from cad_tabelas where codigo = p_codigo) <> p_descricao) then
		update cad_tabelas set descricao = p_descricao where codigo = p_codigo;
	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_sincroniza_tabela(integer, character varying, character, character varying)
  OWNER TO postgres;


-- Function: dsoft_total_estoque(bigint)

-- DROP FUNCTION dsoft_total_estoque(bigint);

CREATE OR REPLACE FUNCTION dsoft_total_estoque(p_produto bigint)
  RETURNS double precision AS
$BODY$

begin

	return sum(quantidade) from estoque where produto = p_produto;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_total_estoque(bigint)
  OWNER TO postgres;


-- Function: dsoft_transferencia(integer, integer, numeric, integer, character varying)

-- DROP FUNCTION dsoft_transferencia(integer, integer, numeric, integer, character varying);

CREATE OR REPLACE FUNCTION dsoft_transferencia(p_usuario integer, p_caixa integer, p_valor numeric, p_destino integer, p_observacao character varying)
  RETURNS boolean AS
$BODY$
declare auxiliar		char;

begin

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_caixa;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    auxiliar := situacao from cad_caixa where codigo = p_destino;
    
    if (auxiliar is null or auxiliar <> 'A') then
    	return false;
    end if;
    
    insert into caixa_fluxo (tipo, caixa, valor, usuario, caixa_destino, observacao)
    	values ('T', p_caixa, p_valor, p_usuario, p_destino, p_observacao);
        
    insert into caixa_fluxo (tipo, caixa, valor, usuario)
    	values ('E', p_destino, p_valor, p_usuario);
    
    return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_transferencia(integer, integer, numeric, integer, character varying)
  OWNER TO postgres;


-- Function: dsoft_transmite_ordem_transporte(integer, character varying, integer)

-- DROP FUNCTION dsoft_transmite_ordem_transporte(integer, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_transmite_ordem_transporte(p_indice integer, p_cte character varying, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set situacao = 'T', cte = p_cte where indice = p_indice;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_transmite_ordem_transporte(integer, character varying, integer)
  OWNER TO postgres;



-- Function: dsoft_vincula_conhecimento_manifesto(integer, integer, date, integer)

-- DROP FUNCTION dsoft_vincula_conhecimento_manifesto(integer, integer, date, integer);

CREATE OR REPLACE FUNCTION dsoft_vincula_conhecimento_manifesto(p_conhecimento integer, p_manifesto integer, p_data date, p_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	perform situacao from manifestos where indice = p_manifesto;

	if (not found) then
		return false;
	end if;

	perform situacao from ordem_servico where indice = p_conhecimento;

	if (not found) then
		return false;
	end if;

	update ordem_servico set manifesto = p_manifesto, montagem_data = p_data, montagem_hora = now(), montagem_usuario = p_usuario where indice = p_conhecimento;

	update manifestos set itens = itens + 1,
				valor_total = valor_total + (select valor_mercadoria from ordem_servico where indice = p_conhecimento limit 1),
				peso_total = peso_total + (select peso from ordem_servico where indice = p_conhecimento limit 1),
				volume_total = volume_total + (select m3l from ordem_servico where indice = p_conhecimento limit 1),
				frete_total = frete_total + (select valor_frete from ordem_servico where indice = p_conhecimento limit 1)
				where indice = p_manifesto;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_vincula_conhecimento_manifesto(integer, integer, date, integer)
  OWNER TO postgres;



-- Function: dsoft_vincula_produto_material(bigint, integer, double precision, integer)

-- DROP FUNCTION dsoft_vincula_produto_material(bigint, integer, double precision, integer);

CREATE OR REPLACE FUNCTION dsoft_vincula_produto_material(cod_produto bigint, cod_material integer, qtd double precision, cod_usuario integer)
  RETURNS boolean AS
$BODY$

begin

	perform nome from cad_produtos where codigo = cod_produto;

	if (not found) then
		return false;
	end if;

	perform nome from cad_materiais where codigo = cod_material;

	if (not found) then
		return false;
	end if;

	if (qtd <= 0) then
		return false;
	end if;

	insert into produtos_materiais (produto, material, quantidade, usuario)
		values (cod_produto, cod_material, qtd, cod_usuario);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_vincula_produto_material(bigint, integer, double precision, integer)
  OWNER TO postgres;


-- Function: todate(character varying)

-- DROP FUNCTION todate(character varying);

CREATE OR REPLACE FUNCTION todate(p_data character varying)
  RETURNS date AS
$BODY$

begin

	return to_date(p_data, 'DDMMYY');
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION todate(character varying)
  OWNER TO postgres;


  -- Function: dsoft_atualiza_estoque()

-- DROP FUNCTION dsoft_atualiza_estoque();

CREATE OR REPLACE FUNCTION dsoft_atualiza_estoque()
  RETURNS trigger AS
$BODY$

begin

	update cad_produtos set estoque = dsoft_total_estoque(new.produto) where cad_produtos.codigo = new.produto;

	return new;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_atualiza_estoque()
  OWNER TO postgres;


-- Function: dsoft_estoque_status()

-- DROP FUNCTION dsoft_estoque_status();

CREATE OR REPLACE FUNCTION dsoft_estoque_status()
  RETURNS trigger AS
$BODY$

begin

	if (new.quantidade <> old.quantidade) then
		new.status = 'A';
	end if;

	return new;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_estoque_status()
  OWNER TO postgres;


  -- Function: dsoft_novo_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_novo_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_novo_emitente(p_razao character varying, p_nome character varying, p_cnpj bigint, p_inscr_est character varying, p_cnae_fiscal character varying, p_inscr_municipal character varying, p_logradouro character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cep character varying, p_pais character varying, p_uf character varying, p_municipio character varying, p_telefone character varying, p_rntrc character varying)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (found) then
		return false;
	end if;

	insert into cad_emitentes (razao_social,
				nome_fantasia,
				cnpj,
				inscricao_estadual,
				cnae_fiscal,
				inscricao_municipal,
				logradouro,
				numero,
				complemento,
				bairro,
				cep,
				pais,
				uf,
				municipio,
				telefone,
				"RNTRC") values (
				p_razao,
				p_nome,
				p_cnpj,
				p_inscr_est,
				p_cnae_fiscal,
				p_inscr_municipal,
				p_logradouro,
				p_numero,
				p_complemento,
				p_bairro,
				p_cep,
				p_pais,
				p_uf,
				p_municipio,
				p_telefone,
				p_rntrc);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_novo_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;


  -- Function: dsoft_altera_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)

-- DROP FUNCTION dsoft_altera_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying);

CREATE OR REPLACE FUNCTION dsoft_altera_emitente(p_razao character varying, p_nome character varying, p_cnpj bigint, p_inscr_est character varying, p_cnae_fiscal character varying, p_inscr_municipal character varying, p_logradouro character varying, p_numero character varying, p_complemento character varying, p_bairro character varying, p_cep character varying, p_pais character varying, p_uf character varying, p_municipio character varying, p_telefone character varying, p_rntrc character varying)
  RETURNS boolean AS
$BODY$

begin

	perform nome_fantasia from cad_emitentes where cnpj = p_cnpj;

	if (not found) then
		return false;
	end if;

	update cad_emitentes set razao_social = p_razao,
				nome_fantasia = p_nome,
				inscricao_estadual = p_inscr_est,
				cnae_fiscal = p_cnae_fiscal,
				inscricao_municipal = p_inscr_municipal,
				logradouro = p_logradouro,
				numero = p_numero,
				complemento = p_complemento,
				bairro = p_bairro,
				cep = p_cep,
				pais = p_pais,
				uf = p_uf,
				municipio = p_municipio,
				telefone = p_telefone,
				"RNTRC" = p_rntrc
				where cnpj = p_cnpj;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_altera_emitente(character varying, character varying, bigint, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying)
  OWNER TO postgres;



-- Function: fechamento_entrada(integer, integer)

-- DROP FUNCTION fechamento_entrada(integer, integer);

CREATE OR REPLACE FUNCTION fechamento_entrada(p_fechamento integer, p_caixa integer)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'E';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_entrada(integer, integer)
  OWNER TO postgres;


-- Function: fechamento_entrada_forma(integer, integer, character)

-- DROP FUNCTION fechamento_entrada_forma(integer, integer, character);

CREATE OR REPLACE FUNCTION fechamento_entrada_forma(p_fechamento integer, p_caixa integer, p_forma character)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'E' and forma = p_forma;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_entrada_forma(integer, integer, character)
  OWNER TO postgres;



-- Function: fechamento_pagamento(integer, integer)

-- DROP FUNCTION fechamento_pagamento(integer, integer);

CREATE OR REPLACE FUNCTION fechamento_pagamento(p_fechamento integer, p_caixa integer)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'P';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_pagamento(integer, integer)
  OWNER TO postgres;


-- Function: fechamento_saida(integer, integer)

-- DROP FUNCTION fechamento_saida(integer, integer);

CREATE OR REPLACE FUNCTION fechamento_saida(p_fechamento integer, p_caixa integer)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'S';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_saida(integer, integer)
  OWNER TO postgres;


-- Function: fechamento_transferencia(integer, integer)

-- DROP FUNCTION fechamento_transferencia(integer, integer);

CREATE OR REPLACE FUNCTION fechamento_transferencia(p_fechamento integer, p_caixa integer)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'T';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_transferencia(integer, integer)
  OWNER TO postgres;


-- Function: fechamento_vale(integer, integer)

-- DROP FUNCTION fechamento_vale(integer, integer);

CREATE OR REPLACE FUNCTION fechamento_vale(p_fechamento integer, p_caixa integer)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento in (select indice from caixa where fechamento = p_fechamento and situacao <> 'C') and caixa = p_caixa and situacao <> 'C' and tipo = 'V';
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_vale(integer, integer)
  OWNER TO postgres;


  -- Function: fechamento_caixa_entrada_forma(integer, integer, character)

-- DROP FUNCTION fechamento_caixa_entrada_forma(integer, integer, character);

CREATE OR REPLACE FUNCTION fechamento_caixa_entrada_forma(p_fechamento integer, p_caixa integer, p_forma character)
  RETURNS numeric AS
$BODY$
begin
	return sum(valor) from caixa_fluxo where fechamento = p_fechamento and caixa = p_caixa and situacao <> 'C' and tipo = 'E' and forma = p_forma;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION fechamento_caixa_entrada_forma(integer, integer, character)
  OWNER TO postgres;

  -- Function: dsoft_desfaz_fechamento2(integer, integer)

-- DROP FUNCTION dsoft_desfaz_fechamento2(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_desfaz_fechamento2(p_fechamento integer, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare n_numero integer;

begin

	n_numero := count(indice) from resumos where indice = p_fechamento and situacao = 'A';

	if (n_numero is null or n_numero = 0) then
		return false;
	end if;

	update resumos set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where indice = p_fechamento;

	update caixa_fluxo set situacao = 'A', fechamento = null where fechamento in (select indice from caixa where fechamento = p_fechamento);

	update caixa set situacao = 'C' where fechamento = p_fechamento;

	update pedidos set fechamento = null where fechamento in (select indice from caixa where fechamento = p_fechamento);

	update despesas set fechamento = null, situacao = 'P' where fechamento in (select indice from caixa where fechamento = p_fechamento);

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desfaz_fechamento2(integer, integer)
  OWNER TO postgres;


  -- Function: cliente_saldo_real(bigint)

-- DROP FUNCTION cliente_saldo_real(bigint);

CREATE OR REPLACE FUNCTION cliente_saldo_real(p_cliente bigint)
  RETURNS numeric AS
$BODY$

declare _debitos numeric;
declare _entradas numeric;

begin

	_debitos := sum(valor) from caixa_fluxo where cliente = p_cliente and situacao <> 'C' and tipo = 'E' and forma = 'A';
	_entradas := sum(valor) from caixa_fluxo where cliente = p_cliente and situacao <> 'C' 
		and tipo = 'E' and (forma = 'D' or forma = 'B' or forma = 'C' or forma = 'M' or forma = 'V' or forma = 'X') and pedido is null;

	if (_debitos is null) then
		_debitos := 0;
	end if;

	if (_entradas is null) then
		_entradas := 0;
	end if;

	return (_entradas - _debitos);

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION cliente_saldo_real(bigint)
  OWNER TO postgres;


  -- Function: dsoft_nova_chave_nfe()

-- DROP FUNCTION dsoft_nova_chave_nfe();

CREATE OR REPLACE FUNCTION dsoft_nova_chave_nfe()
  RETURNS character varying AS
$BODY$

declare ultima_nfe integer;

begin

	ultima_nfe := numero from notas_fiscais order by numero desc limit 1;

	if (ultima_nfe is null) then
		ultima_nfe := 0;
	end if;

	ultima_nfe := ultima_nfe + 1;
	
	return to_char(ultima_nfe, '000000000');

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_nova_chave_nfe()
  OWNER TO postgres;


  -- Function: dsoft_oc_merc_transportadas(integer, character varying, character varying, double precision[], character varying[], character varying[], double precision)

-- DROP FUNCTION dsoft_oc_merc_transportadas(integer, character varying, character varying, double precision[], character varying[], character varying[], double precision);

CREATE OR REPLACE FUNCTION dsoft_oc_merc_transportadas(p_ordem integer, p_prod character varying, p_out_carac character varying, p_qtd double precision[], p_un_med character varying[], p_tipo_med character varying[], p_val_merc double precision)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set 
		prod_predominante = p_prod,
		outras_caract = p_out_carac,
		qtd_merc = p_qtd,
		un_med = p_un_med,
		tipo_med = p_tipo_med,
		valor_mercadoria = p_val_merc
		where indice = p_ordem;

	return true;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_oc_merc_transportadas(integer, character varying, character varying, double precision[], character varying[], character varying[], double precision)
  OWNER TO postgres;


  -- Function: dsoft_oc_prest_servicos(integer, integer, character varying, character varying, date, character varying[], double precision[], double precision)

-- DROP FUNCTION dsoft_oc_prest_servicos(integer, integer, character varying, character varying, date, character varying[], double precision[], double precision);

CREATE OR REPLACE FUNCTION dsoft_oc_prest_servicos(p_ordem integer, p_cfop integer, p_nat_op character varying, p_rntrc character varying, p_prev_entrega date, p_comp character varying[], p_valor double precision[], p_frete double precision)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set
		cfop = p_cfop,
		natureza_operacao = p_nat_op,
		rntrc = p_rntrc,
		prev_entrega = p_prev_entrega,
		componente = p_comp,
		valor_prestacao = p_valor,
		valor_frete = p_frete
		where indice = p_ordem;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_oc_prest_servicos(integer, integer, character varying, character varying, date, character varying[], double precision[], double precision)
  OWNER TO postgres;


  -- Function: dsoft_oc_impostos(integer, character varying, double precision, double precision, double precision, double precision, double precision)

-- DROP FUNCTION dsoft_oc_impostos(integer, character varying, double precision, double precision, double precision, double precision, double precision);

CREATE OR REPLACE FUNCTION dsoft_oc_impostos(p_ordem integer, p_cst character varying, p_bc double precision, p_aliq double precision, p_valor double precision, p_red double precision, p_st double precision)
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set
		cst = p_cst,
		bc_icms = p_bc,
		aliquota_icms = p_aliq,
		valor_icms = p_valor,
		red_bc = p_red,
		icms_st = p_st
		where indice = p_ordem;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_oc_impostos(integer, character varying, double precision, double precision, double precision, double precision, double precision)
  OWNER TO postgres;


  -- Function: dsoft_atribuir_numero_conhecimento(integer, integer)

-- DROP FUNCTION dsoft_atribuir_numero_conhecimento(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_atribuir_numero_conhecimento(p_indice integer, p_usuario integer)
  RETURNS integer AS
$BODY$

declare p_prox integer;

begin

	p_prox := conhecimento from ordem_servico where conhecimento is not null order by conhecimento desc limit 1;

	if (p_prox is null) then
		p_prox := 1;
	else
		p_prox := p_prox + 1;
	end if;

	update ordem_servico set conhecimento = p_prox where indice = p_indice;

	return p_prox;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_atribuir_numero_conhecimento(integer, integer)
  OWNER TO postgres;


  -- Function: dsoft_oc_doc_originarios(integer, character varying[], character varying[], character varying[], character varying[], character varying[])

-- DROP FUNCTION dsoft_oc_doc_originarios(integer, character varying[], character varying[], character varying[], character varying[], character varying[]);

CREATE OR REPLACE FUNCTION dsoft_oc_doc_originarios(p_ordem integer, p_cte character varying[], p_tipo character varying[], p_emit character varying[], p_nota character varying[], p_serie character varying[])
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set
		doc_cte = p_cte,
		doc_tipo = p_tipo,
		doc_emit = p_emit,
		doc_nota = p_nota,
		doc_serie = p_serie
		where indice = p_ordem;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_oc_doc_originarios(integer, character varying[], character varying[], character varying[], character varying[], character varying[])
  OWNER TO postgres;

  -- Function: dsoft_oc_outros(integer, character varying[])

-- DROP FUNCTION dsoft_oc_outros(integer, character varying[]);

CREATE OR REPLACE FUNCTION dsoft_oc_outros(p_ordem integer, p_obs character varying[])
  RETURNS boolean AS
$BODY$

begin

	update ordem_servico set observacoes = p_obs where indice = p_ordem;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_oc_outros(integer, character varying[])
  OWNER TO postgres;


  -- Function: dsoft_ordem_servico_peso(integer)

-- DROP FUNCTION dsoft_ordem_servico_peso(integer);

CREATE OR REPLACE FUNCTION dsoft_ordem_servico_peso(p_indice integer)
  RETURNS double precision AS
$BODY$
declare _meds character varying[];
declare _peso double precision = 0;
begin

	_meds := un_med from ordem_servico where indice = p_indice;
	
	if _meds[1] = '''KG''' then
		_peso := qtd_merc[1] from ordem_servico where indice = p_indice;
	elseif (_meds[2] = '''KG''') then
		_peso := qtd_merc[2] from ordem_servico where indice = p_indice;
	elseif (_meds[3] = '''KG''') then
		_peso := qtd_merc[3] from ordem_servico where indice = p_indice;
	elseif (_meds[4] = '''KG''') then
		_peso := qtd_merc[4] from ordem_servico where indice = p_indice;
	elseif (_meds[5] = '''KG''') then
		_peso := qtd_merc[5] from ordem_servico where indice = p_indice;
	end if;

	return _peso;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_ordem_servico_peso(integer)
  OWNER TO postgres;


-- Function: dsoft_ordem_servico_volume(integer)

-- DROP FUNCTION dsoft_ordem_servico_volume(integer);

CREATE OR REPLACE FUNCTION dsoft_ordem_servico_volume(p_indice integer)
  RETURNS double precision AS
$BODY$
declare _meds character varying[];
declare _vol double precision = 0;
begin

	_meds := un_med from ordem_servico where indice = p_indice;
	
	if _meds[1] = '''UNIDADE''' then
		_vol := qtd_merc[1] from ordem_servico where indice = p_indice;
	elseif (_meds[2] = '''UNIDADE''') then
		_vol := qtd_merc[2] from ordem_servico where indice = p_indice;
	elseif (_meds[3] = '''UNIDADE''') then
		_vol := qtd_merc[3] from ordem_servico where indice = p_indice;
	elseif (_meds[4] = '''UNIDADE''') then
		_vol := qtd_merc[4] from ordem_servico where indice = p_indice;
	elseif (_meds[5] = '''UNIDADE''') then
		_vol := qtd_merc[5] from ordem_servico where indice = p_indice;
	end if;

	return _vol;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_ordem_servico_volume(integer)
  OWNER TO postgres;


-- Function: dsoft_recalcula_total_pedido(integer)

-- DROP FUNCTION dsoft_recalcula_total_pedido(integer);

CREATE OR REPLACE FUNCTION dsoft_recalcula_total_pedido(p_pedido integer)
  RETURNS numeric AS
$BODY$
declare _total numeric := 0;
declare _itens integer;
begin

	_total :=  sum(preco) from pedidos_itens where pedido = p_pedido and situacao = 'A';
	_itens := sum(fracao)::integer from pedidos_itens where pedido = p_pedido and situacao = 'A';

	update pedidos set total = _total, itens = _itens where indice = p_pedido;

	return _total;
end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_recalcula_total_pedido(integer)
  OWNER TO postgres;

  -- Function: dsoft_insert_or_update_locacao_especial(integer, character varying, integer)

-- DROP FUNCTION dsoft_insert_or_update_locacao_especial(integer, character varying, integer);

CREATE OR REPLACE FUNCTION dsoft_insert_or_update_locacao_especial(p_produto_tipo integer, p_descricao character varying, p_periodo integer)
  RETURNS boolean AS
$BODY$

begin

	perform indice from locacao_especial where produto_tipo = p_produto_tipo and descricao = p_descricao and periodo = p_periodo;

	if FOUND then
		return false;
	else
		insert into locacao_especial(produto_tipo, descricao, periodo) values (p_produto_tipo, p_descricao, p_periodo);

		return true;
	end if;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_insert_or_update_locacao_especial(integer, character varying, integer)
  OWNER TO postgres;


-- Function: dsoft_insert_or_update_locacao_especial_precos(integer, integer, integer)

-- DROP FUNCTION dsoft_insert_or_update_locacao_especial_precos(integer, integer, integer);

CREATE OR REPLACE FUNCTION dsoft_insert_or_update_locacao_especial_precos(p_produto integer, p_tabela integer, p_especial integer)
  RETURNS boolean AS
$BODY$

begin

	perform indice from locacao_especial_precos where locacao_especial = p_especial and tabela_precos = p_tabela and produto = p_produto;

	if FOUND then
		return false;
	else
		insert into locacao_especial_precos(locacao_especial, tabela_precos, produto, preco) values (p_especial, p_tabela, p_produto, 0);

		return true;
	end if;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_insert_or_update_locacao_especial_precos(integer, integer, integer)
  OWNER TO postgres;


  -- Function: dsoft_fecha_caixa_saida(integer, integer)

-- DROP FUNCTION dsoft_fecha_caixa_saida(integer, integer);

CREATE OR REPLACE FUNCTION dsoft_fecha_caixa_saida(p_caixa integer, p_saldo double precision, p_usuario integer)
  RETURNS integer AS
$BODY$
declare auxiliar		char;
declare v_entrada		double precision;
declare v_saida			double precision;
declare v_despesa		double precision;
declare v_vale			double precision;
declare v_pagamento		double precision;
declare v_transferencia		double precision;
declare v_saldo			double precision;
declare v_saldo_anterior	double precision;
declare fecha		 	integer;

declare n_dinheiro		double precision;
declare n_cartao		double precision;
declare n_visa			double precision;
declare n_master		double precision;
declare n_crediario		double precision;
declare n_cheque		double precision;
declare n_debito		double precision;
declare n_vr			double precision;

declare n_recebimentos		double precision;

begin

	-- Primeiro verificamos se o dia j? foi encerrado
	fecha := indice from resumos where data = now() and situacao = 'A';

	if (fecha is not null) then
		return 0;
	end if;

	auxiliar := situacao from cad_caixa where codigo = p_caixa;

	if (auxiliar is null) then
		return 0;
	end if;

	auxiliar := situacao from cad_usuarios where codigo = p_usuario;

	if (auxiliar is null) then
		return 0;
	end if;

	v_saldo_anterior := saldo from cad_caixa where codigo = p_caixa;

	if (v_saldo_anterior is null) then
		v_saldo_anterior := 0;
	end if;

	v_entrada := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'E';

	if (v_entrada is null) then
		v_entrada := 0;
	end if;

	v_saida   := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'S';

	if (v_saida is null) then
		v_saida := 0;
	end if;    

	v_despesa := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'D';

	if (v_despesa is null) then
		v_despesa := 0;
	end if;

	v_vale := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'V';

	if (v_vale is null) then
		v_vale := 0;
	end if;

	v_pagamento := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'P';

	if (v_pagamento is null) then
		v_pagamento := 0;
	end if;

	v_transferencia := sum(valor) from caixa_fluxo
		where situacao = 'A' and caixa = p_caixa and tipo = 'T';

	if (v_transferencia is null) then
		v_transferencia := 0;
	end if;

	-- Detalhes dos pagamento
	n_dinheiro := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'D';

	if (n_dinheiro is null) then
		n_dinheiro := 0;
	end if;

	n_cheque := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'X';

	if (n_cheque is null) then
		n_cheque := 0;
	end if;

	n_cartao := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'C';

	if (n_cartao is null) then
		n_cartao := 0;
	end if;

	n_visa := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'V';

	if (n_visa is null) then
		n_visa := 0;
	end if;

	n_master := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'M';

	if (n_master is null) then
		n_master := 0;
	end if;

	n_crediario := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'P';

	if (n_crediario is null) then
		n_crediario := 0;
	end if;

	n_debito := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'A';

	if (n_debito is null) then
		n_debito := 0;
	end if;

	n_vr := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and forma = 'R';

	if (n_vr is null) then
		n_vr := 0;
	end if;

	n_recebimentos := sum(valor) from caixa_fluxo where situacao = 'A' and caixa = p_caixa and tipo = 'E' and prestacao is not null;

	if (n_recebimentos is null) then
		n_recebimentos := 0;
	end if;

	v_saldo := (v_saldo_anterior + v_entrada - v_saida - v_despesa - v_vale - v_pagamento - v_transferencia);

	if (v_saldo > p_saldo) then
		v_saida := v_saida + (v_saldo - p_saldo);
		v_saldo := p_saldo;

		insert into caixa_fluxo (tipo, caixa, usuario, valor, observacao) values ('S', p_caixa, p_usuario, v_saida, 'FECHAMENTO DE CAIXA');
	end if;

	insert into caixa (tipo,
			saldo,
			entrada,
			saida,
			despesa,
			vale,
			pagamento,
			transferencia,
			caixa,
			dinheiro,
			cheque,
			cartao,
			visa,
			master,
			crediario,
			recebimentos,
			debito,
			vr,
			usuario
			) values (
			'F',
			v_saldo,
			v_entrada,
			v_saida,
			v_despesa,
			v_vale,
			v_pagamento,
			v_transferencia,
			p_caixa,
			n_dinheiro,
			n_cheque,
			n_cartao,
			n_visa,
			n_master,
			n_crediario,
			n_recebimentos,
			n_debito,
			n_vr,
			p_usuario);

	fecha := indice from caixa order by indice desc limit 1;

	update caixa_fluxo set situacao = 'F', fechamento = fecha
				where situacao = 'A' and caixa = p_caixa;

	update caixa_fluxo set fechamento = fecha
				where situacao = 'C' and caixa = p_caixa and fechamento is null;

	update cad_caixa set saldo_anterior = saldo,
				saldo = v_saldo
				where codigo = p_caixa;

	return fecha;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_fecha_caixa_saida(integer, double precision, integer)
  OWNER TO postgres;

  -- Function: dsoft_desfaz_fechamento_diario(date, integer)

-- DROP FUNCTION dsoft_desfaz_fechamento_diario(date, integer);

CREATE OR REPLACE FUNCTION dsoft_desfaz_fechamento_diario(p_data date, p_usuario integer)
  RETURNS boolean AS
$BODY$

declare n_numero integer;

begin

	n_numero := indice from resumos where data = p_data and situacao = 'A';

	if (n_numero is null or n_numero = 0) then
		return false;
	end if;

	update resumos set situacao = 'C', cancelado = now(), cancelado_usuario = p_usuario where indice = n_numero;

	/*update caixa_fluxo set situacao = 'A', fechamento = null where fechamento in (select indice from caixa where fechamento = p_fechamento);*/

	update caixa set situacao = 'A', fechamento = null where fechamento = n_numero;

	/*update pedidos set fechamento = null where fechamento in (select indice from caixa where fechamento = p_fechamento);*/

	update pedidos set fechamento = null where fechamento = n_numero;

	/*update despesas set fechamento = null, situacao = 'P' where fechamento in (select indice from caixa where fechamento = p_fechamento);*/

	update despesas set fechamento = null, situacao = 'P' where fechamento = n_numero and situacao = 'F';

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_desfaz_fechamento_diario(date, integer)
  OWNER TO postgres;


  -- Function: pedidos_qtd(bigint, date, date)

-- DROP FUNCTION pedidos_qtd(bigint, date, date);

CREATE OR REPLACE FUNCTION pedidos_qtd(p_cliente bigint, p_inicio date, p_final date)
  RETURNS double precision AS
$BODY$

begin

	return count(indice) from pedidos where cliente = p_cliente and data between p_inicio and p_final and situacao <> 'C';

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION pedidos_qtd(bigint, date, date)
  OWNER TO postgres;


  -- Function: pedidos_valor(bigint, date, date)

-- DROP FUNCTION pedidos_valor(bigint, date, date);

CREATE OR REPLACE FUNCTION pedidos_valor(p_cliente bigint, p_inicio date, p_final date)
  RETURNS double precision AS
$BODY$

begin

	return sum(total) from pedidos where cliente = p_cliente and data between p_inicio and p_final and situacao <> 'C';

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION pedidos_valor(bigint, date, date)
  OWNER TO postgres;


  -- Function: dsoft_adicionar_item_adicional(character varying, numeric, bigint)

-- DROP FUNCTION dsoft_adicionar_item_adicional(character varying, numeric, bigint);

CREATE OR REPLACE FUNCTION dsoft_adicionar_item_adicional(p_descricao character varying, p_valor numeric, p_produto bigint)
  RETURNS boolean AS
$BODY$
begin
	if not EXISTS (select 1 from cad_adicionais where descricao = p_descricao and adicional = p_valor and produto = p_produto) then

		insert into cad_adicionais (descricao, adicional, produto) values (p_descricao, p_valor, p_produto);

		return true;
		
	end if; 

	return false;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_adicionar_item_adicional(character varying, numeric, bigint)
  OWNER TO dsoft;


-- Function: dsoft_adicionar_item_adicional_tipo(character varying, numeric, int)

-- DROP FUNCTION dsoft_adicionar_item_adicional_tipo(character varying, numeric, int);

CREATE OR REPLACE FUNCTION dsoft_adicionar_item_adicional_tipo(p_descricao character varying, p_valor numeric, p_tipo integer)
  RETURNS boolean AS
$BODY$
begin
	if not EXISTS (select 1 from cad_adicionais where descricao = p_descricao and adicional = p_valor and tipo = p_tipo) then

		insert into cad_adicionais (descricao, adicional, tipo) values (p_descricao, p_valor, p_tipo);

		return true;
		
	end if; 

	return false;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION dsoft_adicionar_item_adicional_tipo(character varying, numeric, integer)
  OWNER TO dsoft;


  create or replace function dsoft_cliente_interno(p_cliente bigint) returns boolean as
$$

begin

	if (p_cliente is null) then
		return false;
	end if;

	if ((select cliente_interno from clientes_tipos where codigo = (select tipo_cliente from cad_clientes where codigo = p_cliente)) = true) then
		return true;
	else
		return false;
	end if;
end;
$$
language 'plpgsql' volatile;

-- Function: insert_or_update_forma_de_pagamento(character, character varying, boolean)

-- DROP FUNCTION insert_or_update_forma_de_pagamento(character, character varying, boolean);

CREATE OR REPLACE FUNCTION insert_or_update_forma_de_pagamento(p_codigo character, p_descricao character varying, p_debito boolean, p_ativo boolean)
  RETURNS boolean AS
$BODY$
begin

	if EXISTS (SELECT 1 FROM pagamentos_formas WHERE codigo = p_codigo) then

		UPDATE pagamentos_formas SET descricao = p_descricao, debito = p_debito, ativo = p_ativo WHERE codigo = p_codigo;

	else

		INSERT INTO pagamentos_formas (codigo, descricao, debito, ativo) VALUES (p_codigo, p_descricao, p_debito, p_ativo);

	end if;

	return true;

end;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION insert_or_update_forma_de_pagamento(character, character varying, boolean)
  OWNER TO postgres;


