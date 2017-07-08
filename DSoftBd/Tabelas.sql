-- Table: atendimentos

-- DROP TABLE atendimentos;

CREATE TABLE atendimentos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time without time zone DEFAULT now(),
  tipo character(1),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  cliente integer,
  ocorrencia integer,
  motivo character varying,
  obs character varying,
  conclusao character varying,
  encerrado date,
  encerrado_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  CONSTRAINT atendimentos_pkey PRIMARY KEY (indice)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE atendimentos
  OWNER TO postgres;

-- Table: usuarios_nivel

-- DROP TABLE usuarios_nivel;

CREATE TABLE usuarios_nivel
(
  codigo character(1),
  descricao character varying,
  ativo boolean DEFAULT true,
  CONSTRAINT usuarios_nivel_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE usuarios_nivel
  OWNER TO postgres;



  -- Table: cad_usuarios

-- DROP TABLE cad_usuarios;

CREATE TABLE cad_usuarios
(
  indice serial NOT NULL,
  codigo integer NOT NULL,
  nome character varying,
  senha character varying,
  nivel character(1),
  situacao character(1) DEFAULT 'A'::bpchar,
  cadastro date DEFAULT now(),
  cancelado date,
  bloqueado date,
  alterado date,
  recurso integer,
  CONSTRAINT cad_usuarios_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_usuarios_nivel_fkey FOREIGN KEY (nivel)
      REFERENCES usuarios_nivel (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_usuarios_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_usuarios
  OWNER TO postgres;




-- Table: cad_caixa

-- DROP TABLE cad_caixa;

CREATE TABLE cad_caixa
(
  indice serial NOT NULL,
  codigo integer,
  descricao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  saldo_anterior numeric(12,2) DEFAULT 0,
  saldo numeric(12,2) DEFAULT 0,
  CONSTRAINT cad_caixa_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_caixa_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_caixa
  OWNER TO postgres;



-- Table: clientes_grupos

-- DROP TABLE clientes_grupos;

CREATE TABLE clientes_grupos
(
  indice serial NOT NULL,
  codigo integer NOT NULL,
  nome character varying,
  taxa_entrega numeric DEFAULT 0,
  situacao character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT clientes_grupos_pkey PRIMARY KEY (indice),
  CONSTRAINT clientes_grupos_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE clientes_grupos
  OWNER TO postgres;
ALTER TABLE clientes_grupos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE clientes_grupos ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE clientes_grupos ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE clientes_grupos ALTER COLUMN situacao SET STATISTICS 0;



-- Table: clientes_tipos

-- DROP TABLE clientes_tipos;

CREATE TABLE clientes_tipos
(
  indice serial NOT NULL,
  codigo integer NOT NULL,
  nome character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT clientes_tipos_pkey PRIMARY KEY (indice),
  CONSTRAINT clientes_tipos_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE clientes_tipos
  OWNER TO postgres;
ALTER TABLE clientes_tipos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE clientes_tipos ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE clientes_tipos ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE clientes_tipos ALTER COLUMN situacao SET STATISTICS 0;



-- Table: cad_clientes

-- DROP TABLE cad_clientes;

CREATE TABLE cad_clientes
(
  indice serial NOT NULL,
  codigo bigint NOT NULL,
  nome character varying,
  nascimento date,
  tipo character(1),
  documento character varying,
  rg character varying,
  tel1 bigint,
  tel2 bigint,
  celular bigint,
  endereco character varying,
  bairro character varying,
  cidade character varying,
  estado character varying,
  pais character varying,
  referencia character varying,
  observacao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  cadastro date DEFAULT now(),
  usuario integer,
  alterado date,
  alterado_usuario integer,
  bloqueado date,
  bloqueado_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  grupo integer,
  saldo double precision NOT NULL DEFAULT 0,
  cep character varying(9),
  tmp1 character varying,
  tmp2 character varying,
  tmp3 character varying,
  tmp4 character varying,
  tmp5 character varying,
  tmp6 character varying,
  numero character varying,
  complemento character varying,
  inscricao_estadual character varying,
  inscricao_suframa character varying,
  isento_icms boolean DEFAULT false,
  credito_limite double precision DEFAULT 0,
  status character(1) DEFAULT 'A'::bpchar,
  pai character varying,
  mae character varying,
  conjuge character varying,
  profissao character varying,
  ultima_compra date,
  tabela_precos integer,
  web boolean DEFAULT false,
  senha character varying,
  CONSTRAINT cad_clientes_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_clientes_fk FOREIGN KEY (grupo)
      REFERENCES clientes_grupos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_clientes_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_clientes
  OWNER TO postgres;
ALTER TABLE cad_clientes ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN nascimento SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN documento SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN rg SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN tel1 SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN tel2 SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN celular SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN endereco SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN bairro SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN cidade SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN estado SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN pais SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN referencia SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN observacao SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN cadastro SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN alterado SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN alterado_usuario SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN bloqueado SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN bloqueado_usuario SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE cad_clientes ALTER COLUMN cancelado_usuario SET STATISTICS 0;



-- Table: cad_emitentes

-- DROP TABLE cad_emitentes;

CREATE TABLE cad_emitentes
(
  razao_social character varying,
  nome_fantasia character varying,
  cnpj bigint not null,
  inscricao_estadual character varying,
  cnae_fiscal character varying,
  inscricao_municipal character varying,
  logradouro character varying,
  numero character varying,
  complemento character varying,
  bairro character varying,
  cep character varying,
  pais character varying,
  uf character varying,
  municipio character varying,
  telefone character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  "RNTRC" character varying,
  CONSTRAINT pk_cnpj PRIMARY KEY (cnpj)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_emitentes
  OWNER TO postgres;


-- Table: cad_filiais

-- DROP TABLE cad_filiais;

CREATE TABLE cad_filiais
(
  codigo integer NOT NULL,
  nome character varying,
  cnpj character varying,
  endereco character varying,
  bairro character varying,
  cep character varying,
  cidade character varying,
  estado character varying,
  pais character varying,
  telefone character varying,
  ip character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  status character(1) DEFAULT 'A'::bpchar,
  porta integer,
  banco character varying,
  ie character varying,
  CONSTRAINT cad_filiais_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_filiais
  OWNER TO postgres;


-- Table: cad_fornecedores

-- DROP TABLE cad_fornecedores;

CREATE TABLE cad_fornecedores
(
  indice serial NOT NULL,
  codigo bigint,
  nome character varying,
  cnpj character varying,
  endereco character varying,
  bairro character varying,
  cidade character varying,
  estado character varying,
  pais character varying,
  contato character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  tipo character(1),
  cep integer,
  tel1 integer,
  tel2 integer,
  obs character varying,
  CONSTRAINT cad_fornecedores_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_fornecedores_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_fornecedores
  OWNER TO postgres;
ALTER TABLE cad_fornecedores ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN cnpj SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN endereco SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN bairro SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN cidade SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN estado SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN pais SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN contato SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE cad_fornecedores ALTER COLUMN tipo SET STATISTICS 0;



-- Table: medidas

-- DROP TABLE medidas;

CREATE TABLE medidas
(
  codigo integer NOT NULL,
  descricao character varying,
  abreviatura character varying,
  CONSTRAINT medidas_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE medidas
  OWNER TO postgres;



-- Table: materiais_tipos

-- DROP TABLE materiais_tipos;

CREATE TABLE materiais_tipos
(
  codigo integer NOT NULL,
  nome character varying,
  descricao character varying,
  CONSTRAINT materiais_tipos_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE materiais_tipos
  OWNER TO postgres;




-- Table: cad_materiais

-- DROP TABLE cad_materiais;

CREATE TABLE cad_materiais
(
  codigo integer NOT NULL,
  nome character varying,
  fornecedor integer,
  tipo integer,
  medida integer,
  cadastro date DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  alterado date,
  cancelado date,
  bloqueado date,
  usuario integer,
  alterado_usuario integer,
  bloqueado_usuario integer,
  cancelado_usuario integer,
  descricao character varying,
  CONSTRAINT cad_materiais_pkey PRIMARY KEY (codigo),
  CONSTRAINT cad_materiais_alterado_usuario_fkey FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_bloqueado_usuario_fkey FOREIGN KEY (bloqueado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_cancelado_usuario_fkey FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_fornecedor_fkey FOREIGN KEY (fornecedor)
      REFERENCES cad_fornecedores (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_medida_fkey FOREIGN KEY (medida)
      REFERENCES medidas (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_tipo_fkey FOREIGN KEY (tipo)
      REFERENCES materiais_tipos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_materiais_usuario_fkey FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_materiais
  OWNER TO postgres;


-- Table: cad_motoristas

-- DROP TABLE cad_motoristas;

CREATE TABLE cad_motoristas
(
  nome character varying,
  cpf bigint NOT NULL,
  endereco character varying,
  cidade character varying,
  estado character varying,
  telefone character varying,
  habilitacao character varying,
  nascimento date,
  situacao character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT pk_cpf PRIMARY KEY (cpf)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_motoristas
  OWNER TO postgres;




-- Table: produtos_grupos

-- DROP TABLE produtos_grupos;

CREATE TABLE produtos_grupos
(
  descricao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  codigo integer NOT NULL,
  CONSTRAINT produtos_grupos_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE produtos_grupos
  OWNER TO postgres;
ALTER TABLE produtos_grupos ALTER COLUMN descricao SET STATISTICS 0;



-- Table: produtos_tipos

-- DROP TABLE produtos_tipos;

CREATE TABLE produtos_tipos
(
  descricao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  codigo integer NOT NULL,
  producao boolean,
  estoque boolean,
  nome character varying,
  soma boolean DEFAULT true,
  impressora_externa integer DEFAULT 0,
  CONSTRAINT produtos_tipos_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE produtos_tipos
  OWNER TO postgres;
ALTER TABLE produtos_tipos ALTER COLUMN descricao SET STATISTICS 0;
ALTER TABLE produtos_tipos ALTER COLUMN situacao SET STATISTICS 0;





-- Table: cad_produtos

-- DROP TABLE cad_produtos;

CREATE TABLE cad_produtos
(
  indice serial NOT NULL,
  codigo bigint,
  nome character varying(64),
  situacao character(1) DEFAULT 'A'::bpchar,
  cadastro date DEFAULT now(),
  descricao character varying,
  alterado date DEFAULT now(),
  cancelado date,
  bloqueado date,
  alterado_usuario integer,
  cancelado_usuario integer,
  bloqueado_usuario integer,
  usuario integer,
  grupo integer,
  tipo integer,
  grupo_tributario integer,
  medida integer,
  producao boolean NOT NULL DEFAULT false,
  fornecedor bigint,
  foto character varying,
  estoque double precision DEFAULT 0,
  ncm character varying,
  cfop character varying,
  ean character varying,
  ean_trib character varying,
  medida_tributavel integer,
  quantidade_tributavel integer,
  CONSTRAINT cad_produtos_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_produtos_fk FOREIGN KEY (grupo)
      REFERENCES produtos_grupos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_fk1 FOREIGN KEY (tipo)
      REFERENCES produtos_tipos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_fk2 FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_fk3 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_fk4 FOREIGN KEY (bloqueado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_fk5 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_produtos_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_produtos
  OWNER TO postgres;
ALTER TABLE cad_produtos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE cad_produtos ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE cad_produtos ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE cad_produtos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE cad_produtos ALTER COLUMN cadastro SET STATISTICS 0;
ALTER TABLE cad_produtos ALTER COLUMN descricao SET STATISTICS 0;



-- Table: recursos_tipos

-- DROP TABLE recursos_tipos;

CREATE TABLE recursos_tipos
(
  codigo character(1) NOT NULL,
  descricao character varying,
  entrega boolean DEFAULT false,
  producao boolean DEFAULT false,
  comissao_diaria numeric(4,2),
  comissao_nominal numeric(4,2),
  fixo_semanal numeric(12,2),
  fixo_mensal numeric(12,2),
  valor_entrega numeric(12,2),
  CONSTRAINT recursos_tipos_codigo_key UNIQUE (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE recursos_tipos
  OWNER TO postgres;
ALTER TABLE recursos_tipos ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE recursos_tipos ALTER COLUMN descricao SET STATISTICS 0;



-- Table: cad_recursos

-- DROP TABLE cad_recursos;

CREATE TABLE cad_recursos
(
  indice serial NOT NULL,
  codigo integer NOT NULL,
  nome character varying,
  tipo character(1),
  cadastro date DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  nascimento date,
  tel1 bigint,
  tel2 bigint,
  celular bigint,
  alterado date,
  alterado_usuario integer,
  bloqueado date,
  bloqueado_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  rg character varying,
  cpf character varying,
  habilitacao character varying,
  categoria character varying,
  endereco character varying,
  cidade character varying,
  estado character varying,
  CONSTRAINT cad_recursos_pkey PRIMARY KEY (indice),
  CONSTRAINT cad_recursos_fk FOREIGN KEY (tipo)
      REFERENCES recursos_tipos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_recursos_fk1 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_recursos
  OWNER TO postgres;
ALTER TABLE cad_recursos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN cadastro SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN nascimento SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN tel1 SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN tel2 SET STATISTICS 0;
ALTER TABLE cad_recursos ALTER COLUMN celular SET STATISTICS 0;


-- Index: cad_recursos_codigo_key

-- DROP INDEX cad_recursos_codigo_key;

CREATE UNIQUE INDEX cad_recursos_codigo_key
  ON cad_recursos
  USING btree
  (codigo);



-- Table: cad_tabelas

-- DROP TABLE cad_tabelas;

CREATE TABLE cad_tabelas
(
  indice serial NOT NULL,
  codigo integer NOT NULL,
  nome character varying,
  descricao character varying,
  cadastro date DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  bloqueada date,
  alterada date,
  cancelada date,
  alterada_usuario integer,
  bloqueada_usuario integer,
  cancelada_usuario integer,
  usuario integer,
  CONSTRAINT cad_tabelas_pkey PRIMARY KEY (indice, codigo),
  CONSTRAINT cad_tabelas_fk FOREIGN KEY (alterada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_tabelas_fk1 FOREIGN KEY (bloqueada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_tabelas_fk2 FOREIGN KEY (cancelada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_tabelas_fk3 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT cad_tabelas_codigo_key UNIQUE (codigo),
  CONSTRAINT cad_tabelas_indice_key UNIQUE (indice)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE cad_tabelas
  OWNER TO postgres;
ALTER TABLE cad_tabelas ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN descricao SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN cadastro SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN bloqueada SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN alterada SET STATISTICS 0;
ALTER TABLE cad_tabelas ALTER COLUMN cancelada SET STATISTICS 0;


-- Table: cad_veiculos

-- DROP TABLE cad_veiculos;

CREATE TABLE cad_veiculos
(
  placa character varying NOT NULL,
  modelo character varying,
  ano integer,
  cor character varying,
  marca character varying,
  proprietario character varying,
  endereco character varying,
  cidade character varying,
  estado character varying,
  telefone character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  cpf character varying,
  renavam character varying,
  CONSTRAINT pk_placa PRIMARY KEY (placa)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE cad_veiculos
  OWNER TO postgres;


-- Table: fec_diario

-- DROP TABLE fec_diario;

CREATE TABLE fec_diario
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  usuario integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  anterior numeric(12,2),
  entrada numeric(12,2),
  saida numeric(12,2),
  pagamento numeric(12,2),
  vale numeric(12,2),
  despesa numeric(12,2),
  transferencia numeric(12,2),
  fechamento integer,
  cancelado date,
  cancelado_usuario integer,
  caixa integer,
  CONSTRAINT fec_diario_pkey PRIMARY KEY (indice),
  CONSTRAINT fec_diario_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fec_diario_fk1 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT fec_diario_fk2 FOREIGN KEY (caixa)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE fec_diario
  OWNER TO postgres;
ALTER TABLE fec_diario ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN anterior SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN entrada SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN saida SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN pagamento SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN vale SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN despesa SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN transferencia SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN fechamento SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE fec_diario ALTER COLUMN cancelado_usuario SET STATISTICS 0;




-- Table: caixa

-- DROP TABLE caixa;

CREATE TABLE caixa
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  tipo character(1),
  saldo double precision DEFAULT 0,
  situacao character(1) DEFAULT 'A'::bpchar,
  caixa integer,
  usuario integer,
  cancel_data date,
  cancel_hora time(1) without time zone,
  cancel_usuario integer,
  entrada double precision DEFAULT 0,
  saida double precision DEFAULT 0,
  despesa double precision DEFAULT 0,
  vale double precision DEFAULT 0,
  transferencia double precision DEFAULT 0,
  pagamento double precision DEFAULT 0,
  fechamento integer,
  fec_diario integer,
  dinheiro double precision DEFAULT 0,
  cartao double precision DEFAULT 0,
  visa double precision DEFAULT 0,
  master double precision DEFAULT 0,
  cheque double precision DEFAULT 0,
  crediario double precision DEFAULT 0,
  recebimentos double precision DEFAULT 0,
  debito double precision DEFAULT 0,
  boleto double precision DEFAULT 0,
  CONSTRAINT caixa_pkey PRIMARY KEY (indice),
  CONSTRAINT caixa_fk FOREIGN KEY (caixa)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fk1 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fk2 FOREIGN KEY (cancel_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fk3 FOREIGN KEY (fec_diario)
      REFERENCES fec_diario (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE caixa
  OWNER TO postgres;
ALTER TABLE caixa ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN caixa SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN cancel_data SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN cancel_hora SET STATISTICS 0;
ALTER TABLE caixa ALTER COLUMN cancel_usuario SET STATISTICS 0;




-- Table: pedidos

-- DROP TABLE pedidos;

CREATE TABLE pedidos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(0) without time zone DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  itens integer DEFAULT 0,
  valor numeric(12,2) NOT NULL DEFAULT 0,
  usuario integer,
  observacao character varying,
  alterado date,
  bloqueado date,
  alterado_usuario integer,
  bloqueado_usuario integer,
  cancelado_usuario integer,
  entrega integer,
  pagamento integer,
  fechamento integer,
  entregue date,
  entregue_usuario integer,
  saida date,
  saida_usuario integer,
  cliente bigint,
  caixa integer,
  total numeric(12,2) DEFAULT 0,
  taxa_entrega numeric DEFAULT 0,
  cancelado date,
  vendedor integer,
  loja integer,
  cupom bigint,
  tabela integer,
  nfe character varying,
  CONSTRAINT pedidos_pkey PRIMARY KEY (indice),
  CONSTRAINT pedidos_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk1 FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk2 FOREIGN KEY (bloqueado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk3 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk4 FOREIGN KEY (entregue_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk5 FOREIGN KEY (caixa)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_fk6 FOREIGN KEY (saida_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE pedidos
  OWNER TO postgres;
ALTER TABLE pedidos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN itens SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN valor SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN observacao SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN alterado SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN bloqueado SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN alterado_usuario SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN bloqueado_usuario SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN cancelado_usuario SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN entrega SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN pagamento SET STATISTICS 0;
ALTER TABLE pedidos ALTER COLUMN fechamento SET STATISTICS 0;



-- Table: pedidos_itens

-- DROP TABLE pedidos_itens;

CREATE TABLE pedidos_itens
(
  indice serial NOT NULL,
  pedido integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  produto integer,
  fracao numeric(6,2) DEFAULT 1,
  preco numeric(12,2),
  observacao character varying,
  usuario integer,
  numero integer DEFAULT 1,
  unitario numeric(12,2),
  CONSTRAINT pedidos_itens_pkey PRIMARY KEY (indice),
  CONSTRAINT pedidos_itens_fk FOREIGN KEY (pedido)
      REFERENCES pedidos (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_itens_fk1 FOREIGN KEY (produto)
      REFERENCES cad_produtos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pedidos_itens_fk2 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE pedidos_itens
  OWNER TO postgres;
ALTER TABLE pedidos_itens ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE pedidos_itens ALTER COLUMN pedido SET STATISTICS 0;
ALTER TABLE pedidos_itens ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE pedidos_itens ALTER COLUMN produto SET STATISTICS 0;
ALTER TABLE pedidos_itens ALTER COLUMN observacao SET STATISTICS 0;



-- Table: despesas_tipo

-- DROP TABLE despesas_tipo;

CREATE TABLE despesas_tipo
(
  codigo integer NOT NULL,
  nome character varying,
  descricao character varying,
  CONSTRAINT despesas_tipo_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE despesas_tipo
  OWNER TO postgres;
ALTER TABLE despesas_tipo ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE despesas_tipo ALTER COLUMN nome SET STATISTICS 0;
ALTER TABLE despesas_tipo ALTER COLUMN descricao SET STATISTICS 0;




-- Table: despesas_subtipo

-- DROP TABLE despesas_subtipo;

CREATE TABLE despesas_subtipo
(
  codigo integer NOT NULL,
  nome character varying,
  descricao character varying,
  tipo integer,
  CONSTRAINT despesas_subtipo_pkey PRIMARY KEY (codigo),
  CONSTRAINT despesas_subtipo_tipo_fkey FOREIGN KEY (tipo)
      REFERENCES despesas_tipo (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE despesas_subtipo
  OWNER TO postgres;




-- Table: despesas

-- DROP TABLE despesas;

CREATE TABLE despesas
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  vencimento date,
  pagamento date,
  documento character varying,
  tipo integer,
  observacao character varying,
  alterado date,
  alterado_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  pagamento_usuario integer,
  fornecedor bigint,
  valor numeric(12,2),
  valor_pago numeric(12,2),
  fechamento integer,
  caixa integer,
  CONSTRAINT despesas_pkey PRIMARY KEY (indice),
  CONSTRAINT despesas_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT despesas_fk1 FOREIGN KEY (tipo)
      REFERENCES despesas_tipo (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT despesas_fk2 FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT despesas_fk3 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT despesas_fk4 FOREIGN KEY (pagamento_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT despesas_fk5 FOREIGN KEY (fornecedor)
      REFERENCES cad_fornecedores (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE despesas
  OWNER TO postgres;
ALTER TABLE despesas ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN vencimento SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN pagamento SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN documento SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN observacao SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN alterado SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN alterado_usuario SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN cancelado_usuario SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN pagamento_usuario SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN fornecedor SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN valor SET STATISTICS 0;
ALTER TABLE despesas ALTER COLUMN valor_pago SET STATISTICS 0;



-- Table: compras

-- DROP TABLE compras;

CREATE TABLE compras
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  itens integer DEFAULT 0,
  valor numeric(12,2) DEFAULT 0,
  usuario integer,
  observacao character varying,
  fornecedor bigint,
  entregue date,
  entregue_usuario integer,
  alterado date,
  alterado_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  valor_pago numeric(12,2),
  pagamento date,
  pagamento_usuario integer,
  CONSTRAINT compras_pkey PRIMARY KEY (indice),
  CONSTRAINT compras_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_fk1 FOREIGN KEY (fornecedor)
      REFERENCES cad_fornecedores (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_fk2 FOREIGN KEY (entregue_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_fk3 FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_fk4 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_fk5 FOREIGN KEY (pagamento_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE compras
  OWNER TO postgres;
ALTER TABLE compras ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN itens SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN valor SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN observacao SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN fornecedor SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN entregue SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN entregue_usuario SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN alterado SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN alterado_usuario SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE compras ALTER COLUMN cancelado_usuario SET STATISTICS 0;



-- Table: compras_itens

-- DROP TABLE compras_itens;

CREATE TABLE compras_itens
(
  indice serial NOT NULL,
  compra integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  produto integer,
  quantidade numeric(6,2),
  total numeric(12,2),
  unitario numeric(12,2),
  numero integer,
  CONSTRAINT compras_itens_pkey PRIMARY KEY (indice),
  CONSTRAINT compras_itens_fk FOREIGN KEY (produto)
      REFERENCES cad_produtos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT compras_itens_fk1 FOREIGN KEY (compra)
      REFERENCES compras (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE compras_itens
  OWNER TO postgres;
ALTER TABLE compras_itens ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN compra SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN produto SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN quantidade SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN total SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN unitario SET STATISTICS 0;
ALTER TABLE compras_itens ALTER COLUMN numero SET STATISTICS 0;




-- Table: caixa_fluxo

-- DROP TABLE caixa_fluxo;

CREATE TABLE caixa_fluxo
(
  indice serial NOT NULL,
  data date NOT NULL DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  tipo character(1) DEFAULT 'E'::bpchar,
  caixa integer,
  valor numeric(12,2),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  fechamento integer,
  pedido integer,
  despesa integer,
  recurso integer,
  observacao character varying,
  caixa_destino integer,
  compra integer,
  cliente bigint,
  prestacao bigint,
  forma character varying,
  pagamento integer,
  cancelado_data date,
  cancelado_hora time without time zone,
  cancelado_usuario integer,
  loja integer,
  cupom bigint,
  CONSTRAINT caixa_fluxo_pkey PRIMARY KEY (indice),
  CONSTRAINT caixa_fluxo_fk FOREIGN KEY (caixa)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk1 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk2 FOREIGN KEY (fechamento)
      REFERENCES caixa (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk3 FOREIGN KEY (pedido)
      REFERENCES pedidos (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk4 FOREIGN KEY (despesa)
      REFERENCES despesas (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk6 FOREIGN KEY (caixa_destino)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT caixa_fluxo_fk7 FOREIGN KEY (compra)
      REFERENCES compras (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE caixa_fluxo
  OWNER TO postgres;
ALTER TABLE caixa_fluxo ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN valor SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE caixa_fluxo ALTER COLUMN fechamento SET STATISTICS 0;




-- Table: conhecimentos

-- DROP TABLE conhecimentos;

CREATE TABLE conhecimentos
(
  emitente character varying,
  codigo integer NOT NULL,
  remetente bigint,
  destinatario bigint,
  frete character(1) DEFAULT 'A'::bpchar,
  nota_fiscal integer[],
  valor_frete double precision DEFAULT 0,
  data date,
  hora time without time zone,
  usuario integer,
  usuario_valor integer,
  situacao character(1) DEFAULT 'A'::bpchar
)
WITH (
  OIDS=FALSE
);
ALTER TABLE conhecimentos
  OWNER TO postgres;




-- Table: entregas

-- DROP TABLE entregas;

CREATE TABLE entregas
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  saida time(0) without time zone,
  entrega time(0) without time zone,
  situacao character(1) DEFAULT 'A'::bpchar,
  recurso integer,
  usuario integer,
  pedido integer,
  CONSTRAINT entregas_pkey PRIMARY KEY (indice),
  CONSTRAINT entregas_fk FOREIGN KEY (pedido)
      REFERENCES pedidos (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE entregas
  OWNER TO postgres;
ALTER TABLE entregas ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN saida SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN entrega SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN recurso SET STATISTICS 0;
ALTER TABLE entregas ALTER COLUMN usuario SET STATISTICS 0;



-- Table: entregas_compras

-- DROP TABLE entregas_compras;

CREATE TABLE entregas_compras
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time without time zone DEFAULT now(),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  previsao_data date,
  previsao_hora time without time zone,
  produto bigint,
  quantidade integer,
  entrega_data date,
  entrega_hora time without time zone,
  entrega_qtd integer,
  entrega_usuario integer,
  fornecedor bigint,
  status character(1) DEFAULT 'A'::bpchar,
  fornecedor_nome character varying,
  compra integer,
  CONSTRAINT entregas_compras_pkey PRIMARY KEY (indice)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE entregas_compras
  OWNER TO postgres;


-- Table: estoque

-- DROP TABLE estoque;

CREATE TABLE estoque
(
  indice serial NOT NULL,
  produto bigint,
  minimo integer DEFAULT 0,
  maximo integer DEFAULT 0,
  situacao character(1) DEFAULT 'A'::bpchar,
  local integer DEFAULT 1,
  quantidade double precision DEFAULT 0,
  status character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT estoque_pkey PRIMARY KEY (indice)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE estoque
  OWNER TO postgres;
ALTER TABLE estoque ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE estoque ALTER COLUMN produto SET STATISTICS 0;
ALTER TABLE estoque ALTER COLUMN minimo SET STATISTICS 0;
ALTER TABLE estoque ALTER COLUMN maximo SET STATISTICS 0;


-- Trigger: dsoft_atualiza_estoque on estoque

-- DROP TRIGGER dsoft_atualiza_estoque ON estoque;

CREATE TRIGGER dsoft_atualiza_estoque
  AFTER UPDATE
  ON estoque
  FOR EACH ROW
  EXECUTE PROCEDURE dsoft_atualiza_estoque();

-- Trigger: dsoft_estoque_status on estoque

-- DROP TRIGGER dsoft_estoque_status ON estoque;

CREATE TRIGGER dsoft_estoque_status
  AFTER UPDATE
  ON estoque
  FOR EACH ROW
  EXECUTE PROCEDURE dsoft_estoque_status();



-- Table: grupos_tributarios

-- DROP TABLE grupos_tributarios;

CREATE TABLE grupos_tributarios
(
  codigo integer NOT NULL,
  nome character varying,
  icms double precision DEFAULT 0,
  ipi double precision DEFAULT 0,
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  alterado_usuario integer,
  cancelado_usuario integer,
  cadastro date DEFAULT now(),
  alterado date,
  cancelado date,
  pis double precision DEFAULT 0,
  cofins double precision DEFAULT 0,
  csll double precision DEFAULT 0,
  irrf double precision DEFAULT 0,
  CONSTRAINT grupos_tributarios_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE grupos_tributarios
  OWNER TO postgres;
COMMENT ON TABLE grupos_tributarios
  IS 'Tabela de Grupos Tributários';


-- Table: locais

-- DROP TABLE locais;

CREATE TABLE locais
(
  codigo integer NOT NULL,
  nome character varying,
  descricao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  tipo character(1),
  responsavel integer,
  CONSTRAINT locais_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE locais
  OWNER TO postgres;


-- Table: log_acessos

-- DROP TABLE log_acessos;

CREATE TABLE log_acessos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  entrada time without time zone DEFAULT now(),
  saida time without time zone,
  usuario integer,
  tipo character(1),
  situacao character(1) DEFAULT 'A'::bpchar,
  caixa integer,
  CONSTRAINT log_acessos_pkey PRIMARY KEY (indice),
  CONSTRAINT log_acessos_usuario_fkey FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE log_acessos
  OWNER TO postgres;


-- Table: manifestos

-- DROP TABLE manifestos;

CREATE TABLE manifestos
(
  indice serial NOT NULL,
  numero integer,
  saida_data date,
  saida_hora time without time zone,
  chegada_data date,
  chegada_hora time without time zone,
  usuario integer,
  motorista integer,
  veiculo character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  itens integer DEFAULT 0,
  valor_total double precision DEFAULT 0,
  peso_total double precision DEFAULT 0,
  volume_total double precision DEFAULT 0,
  frete_total double precision DEFAULT 0,
  montagem_data date,
  montagem_hora time with time zone,
  saida_usuario integer,
  chegada_usuario integer,
  emitente bigint,
  CONSTRAINT manifestos_pkey PRIMARY KEY (indice),
  CONSTRAINT manifestos_usuario_fkey FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT manifestos_veiculo_fkey FOREIGN KEY (veiculo)
      REFERENCES cad_veiculos (placa) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE manifestos
  OWNER TO postgres;


-- Table: materiais_grupos

-- DROP TABLE materiais_grupos;

CREATE TABLE materiais_grupos
(
  codigo integer NOT NULL,
  nome character varying,
  CONSTRAINT materiais_grupos_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE materiais_grupos
  OWNER TO postgres;



-- Table: movimentos

-- DROP TABLE movimentos;

CREATE TABLE movimentos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  tipo character(1),
  situacao character(1) DEFAULT 'A'::bpchar,
  valor numeric(12,2),
  fechamento integer,
  usuario integer,
  caixa integer, -- Número do caixa
  cancel_data date,
  cancel_hora time(1) without time zone,
  cancel_usuario integer,
  CONSTRAINT movimentos_pkey PRIMARY KEY (indice),
  CONSTRAINT movimentos_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT movimentos_fk1 FOREIGN KEY (cancel_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE movimentos
  OWNER TO postgres;
ALTER TABLE movimentos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN valor SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN fechamento SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN usuario SET STATISTICS 0;
COMMENT ON COLUMN movimentos.caixa IS 'Número do caixa';
ALTER TABLE movimentos ALTER COLUMN caixa SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN cancel_data SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN cancel_hora SET STATISTICS 0;
ALTER TABLE movimentos ALTER COLUMN cancel_usuario SET STATISTICS 0;



-- Table: notas_clientes

-- DROP TABLE notas_clientes;

CREATE TABLE notas_clientes
(
  indice serial NOT NULL,
  cliente integer,
  nfe boolean DEFAULT false,
  tipo integer DEFAULT 1,
  numero integer,
  serie integer,
  chave_acesso character varying,
  natureza_carga character varying,
  quantidade double precision DEFAULT 0,
  especie character varying,
  peso double precision DEFAULT 0,
  valor_total double precision DEFAULT 0,
  usuario integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT notas_clientes_pkey PRIMARY KEY (indice),
  CONSTRAINT notas_clientes_cliente_fkey FOREIGN KEY (cliente)
      REFERENCES cad_clientes (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT notas_clientes_usuario_fkey FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE notas_clientes
  OWNER TO postgres;


-- Table: notas_fiscais

-- DROP TABLE notas_fiscais;

CREATE TABLE notas_fiscais
(
  indice serial NOT NULL,
  numero integer NOT NULL,
  serie character(1),
  emissao date DEFAULT now(),
  cliente integer,
  pedido integer,
  tipo character(1),
  valor_total numeric(12,2) DEFAULT 0,
  frete numeric(12,2) DEFAULT 0,
  seguro numeric(12,2) DEFAULT 0,
  base_icms numeric(12,2) DEFAULT 0,
  base_ipi numeric(12,2) DEFAULT 0,
  valor_icms numeric(12,2) DEFAULT 0,
  icms_retido numeric(12,2) DEFAULT 0,
  valor_ipi numeric(12,2) DEFAULT 0,
  valor_mercadorias numeric(12,2) DEFAULT 0,
  caixa_fluxo integer,
  peso_bruto double precision DEFAULT 0,
  peso_liquido double precision DEFAULT 0,
  devolucao integer,
  devolucao_serie character(1),
  CONSTRAINT notas_fiscais_pkey PRIMARY KEY (indice)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE notas_fiscais
  OWNER TO postgres;


-- Table: notas_fiscais_itens

-- DROP TABLE notas_fiscais_itens;

CREATE TABLE notas_fiscais_itens
(
  indice serial NOT NULL,
  nota_fiscal integer,
  produto integer,
  fracao double precision,
  valor_unitario double precision,
  valor_total double precision,
  ipi double precision DEFAULT 0,
  icms double precision DEFAULT 0,
  pis double precision DEFAULT 0,
  cofins double precision DEFAULT 0,
  csll double precision DEFAULT 0,
  irrf double precision DEFAULT 0,
  peso_bruto double precision DEFAULT 0,
  peso_liquido double precision DEFAULT 0,
  seguro double precision DEFAULT 0,
  CONSTRAINT notas_fiscais_itens_pkey PRIMARY KEY (indice),
  CONSTRAINT notas_fiscais_itens_produto_fkey FOREIGN KEY (produto)
      REFERENCES cad_produtos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE notas_fiscais_itens
  OWNER TO postgres;


-- Table: notas_lotes

-- DROP TABLE notas_lotes;

CREATE TABLE notas_lotes
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  usuario integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  inicial integer,
  final integer,
  serie character(1),
  tipo character(1),
  CONSTRAINT notas_lotes_pk PRIMARY KEY (indice)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE notas_lotes
  OWNER TO postgres;
COMMENT ON TABLE notas_lotes
  IS 'Tabela de lotes de notas fiscais.';


-- Table: ocorrencias

-- DROP TABLE ocorrencias;

CREATE TABLE ocorrencias
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time without time zone DEFAULT now(),
  tipo character(1),
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  ocorrencia character varying,
  obs character varying,
  motivo character varying,
  conclusao character varying,
  encerrada date,
  encerrada_usuario integer,
  cancelado date,
  cancelado_usuario integer,
  cliente integer,
  CONSTRAINT ocorrencias_pkey PRIMARY KEY (indice),
  CONSTRAINT ocorrencias_cancelado_usuario_fkey FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ocorrencias_cliente_fkey FOREIGN KEY (cliente)
      REFERENCES cad_clientes (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ocorrencias_encerrada_usuario_fkey FOREIGN KEY (encerrada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ocorrencias_usuario_fkey FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ocorrencias
  OWNER TO postgres;


-- Table: ordem_servico

-- DROP TABLE ordem_servico;

CREATE TABLE ordem_servico
(
  indice serial NOT NULL,
  abertura_data date,
  abertura_hora time without time zone,
  abertura_usuario integer,
  situacao character(1) DEFAULT 'A'::bpchar,
  remetente bigint,
  tipo character(1) DEFAULT 'T'::bpchar,
  recebida_data date,
  recebida_hora time without time zone,
  recebida_usuario integer,
  conferida_data date,
  conferida_hora time without time zone,
  conferida_usuario integer,
  montagem_data date,
  montagem_hora time without time zone,
  montagem_usuario integer,
  manifesto integer,
  chegada_data date,
  chegada_hora time without time zone,
  chegada_usuario integer,
  cancelada_data date,
  cancelada_hora time without time zone,
  cancelada_usuario integer,
  conhecimento integer,
  destinatario bigint,
  valor_mercadoria double precision DEFAULT 0,
  valor_frete double precision DEFAULT 0,
  pago boolean DEFAULT false,
  natureza_mercadoria character varying,
  quantidade double precision DEFAULT 0,
  especie character varying,
  peso double precision DEFAULT 0,
  m3l double precision DEFAULT 0,
  nota_fiscal character varying,
  alterada_data date,
  alterada_hora time with time zone,
  alterada_usuario integer,
  cte character varying,
  serie character varying,
  cfop integer,
  natureza_operacao character varying,
  rntrc character varying,
  cst character varying,
  bc_icms double precision,
  aliquota_icms double precision,
  valor_icms double precision,
  enviada_data date,
  enviada_hora time with time zone,
  msg_erro character varying,
  lote integer,
  ambiente character(1),
  status integer,
  motivo character varying,
  recibo bigint,
  dhrecbto character varying,
  nprot bigint,
  digval character varying,
  arquivo character varying,
  prev_coleta date,
  coleta date,
  emitente bigint,
  prod_predominante character varying,
  outras_caract character varying,
  qtd_merc double precision[],
  un_med character varying[],
  tipo_med character varying[],
  doc_cte character varying[],
  doc_tipo character varying[],
  doc_emit character varying[],
  doc_nota character varying[],
  doc_serie character varying[],
  prev_entrega date,
  componente character varying[],
  valor_prestacao double precision[],
  red_bc double precision,
  icms_st double precision,
  observacoes character varying[],
  remetente_nome character varying,
  destinatario_nome character varying,
  motorista integer,
  veiculo character varying,
  CONSTRAINT ordem_servico_pkey PRIMARY KEY (indice),
  CONSTRAINT ordem_servico_abertura_usuario_fkey FOREIGN KEY (abertura_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_cancelada_usuario_fkey FOREIGN KEY (cancelada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_chegada_usuario_fkey FOREIGN KEY (chegada_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_cliente_fkey FOREIGN KEY (remetente)
      REFERENCES cad_clientes (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_conferida_usuario_fkey FOREIGN KEY (conferida_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_manifesto_fkey FOREIGN KEY (manifesto)
      REFERENCES manifestos (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_montagem_usuario_fkey FOREIGN KEY (montagem_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT ordem_servico_recebida_usuario_fkey FOREIGN KEY (recebida_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE ordem_servico
  OWNER TO postgres;




-- Table: pagamentos_formas

-- DROP TABLE pagamentos_formas;

CREATE TABLE pagamentos_formas
(
  codigo character varying NOT NULL,
  descricao character varying,
  CONSTRAINT pagamentos_formas_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE pagamentos_formas
  OWNER TO postgres;
ALTER TABLE pagamentos_formas ALTER COLUMN codigo SET STATISTICS 0;
ALTER TABLE pagamentos_formas ALTER COLUMN descricao SET STATISTICS 0;



-- Table: pagamentos

-- DROP TABLE pagamentos;

CREATE TABLE pagamentos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(0) with time zone DEFAULT now(),
  pedido integer,
  tipo character varying DEFAULT 'D'::bpchar,
  situacao character(1) DEFAULT 'A'::bpchar,
  usuario integer,
  cancelado date,
  cancelado_usuario integer,
  valor numeric(12,2),
  documento character varying,
  parcela integer,
  vencimento date,
  pago_data date,
  pago_hora time with time zone,
  pago_usuario integer,
  multa double precision DEFAULT 0,
  juros double precision,
  total_pago double precision DEFAULT 0,
  cliente bigint,
  promissoria bigint,
  numero bigint,
  caixa_fluxo integer,
  CONSTRAINT pagamentos_pkey PRIMARY KEY (indice),
  CONSTRAINT pagamentos_fk FOREIGN KEY (pedido)
      REFERENCES pedidos (indice) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pagamentos_fk1 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pagamentos_fk2 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT pagamentos_fk3 FOREIGN KEY (tipo)
      REFERENCES pagamentos_formas (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE pagamentos
  OWNER TO postgres;
ALTER TABLE pagamentos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN pedido SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN tipo SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN cancelado_usuario SET STATISTICS 0;
ALTER TABLE pagamentos ALTER COLUMN valor SET STATISTICS 0;



-- Table: produtos_materiais

-- DROP TABLE produtos_materiais;

CREATE TABLE produtos_materiais
(
  indice serial NOT NULL,
  produto integer,
  material integer,
  quantidade double precision,
  medida integer,
  usuario integer,
  CONSTRAINT produtos_materiais_pkey PRIMARY KEY (indice),
  CONSTRAINT produtos_materiais_material_fkey FOREIGN KEY (material)
      REFERENCES cad_materiais (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT produtos_materiais_medida_fkey FOREIGN KEY (medida)
      REFERENCES medidas (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT produtos_materiais_produto_fkey FOREIGN KEY (produto)
      REFERENCES cad_produtos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=FALSE
);
ALTER TABLE produtos_materiais
  OWNER TO postgres;


-- Table: produtos_precos

-- DROP TABLE produtos_precos;

CREATE TABLE produtos_precos
(
  indice serial NOT NULL,
  tabela integer NOT NULL,
  produto integer NOT NULL,
  preco numeric(12,2),
  alterado date,
  usuario integer,
  tributavel numeric,
  CONSTRAINT produtos_precos_pkey PRIMARY KEY (indice),
  CONSTRAINT produtos_precos_fk FOREIGN KEY (tabela)
      REFERENCES cad_tabelas (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT produtos_precos_fk1 FOREIGN KEY (produto)
      REFERENCES cad_produtos (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT produtos_precos_fk2 FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE produtos_precos
  OWNER TO postgres;
ALTER TABLE produtos_precos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE produtos_precos ALTER COLUMN tabela SET STATISTICS 0;
ALTER TABLE produtos_precos ALTER COLUMN produto SET STATISTICS 0;


-- Table: rectmp

-- DROP TABLE rectmp;

CREATE TABLE rectmp
(
  a character varying,
  b character varying,
  c character varying,
  d character varying,
  e character varying,
  f character varying,
  g character varying,
  h character varying,
  cliente bigint
)
WITH (
  OIDS=FALSE
);
ALTER TABLE rectmp
  OWNER TO postgres;


-- Table: recursos_grupos

-- DROP TABLE recursos_grupos;

CREATE TABLE recursos_grupos
(
  codigo integer NOT NULL,
  descricao character varying,
  situacao character(1) DEFAULT 'A'::bpchar,
  CONSTRAINT recursos_grupos_pkey PRIMARY KEY (codigo)
)
WITH (
  OIDS=TRUE
);
ALTER TABLE recursos_grupos
  OWNER TO postgres;



-- Table: resumos

-- DROP TABLE resumos;

CREATE TABLE resumos
(
  indice serial NOT NULL,
  data date DEFAULT now(),
  hora time(1) without time zone DEFAULT now(),
  usuario integer,
  caixa integer,
  saldo_anterior double precision DEFAULT 0,
  saldo double precision DEFAULT 0,
  entrada double precision DEFAULT 0,
  saida double precision DEFAULT 0,
  vales double precision DEFAULT 0,
  despesas double precision DEFAULT 0,
  pagamentos double precision DEFAULT 0,
  transferencias double precision DEFAULT 0,
  situacao character(1) DEFAULT 'A'::bpchar,
  cancelado date,
  cancelado_usuario integer,
  alterado date,
  alterado_usuario integer,
  status character(1) DEFAULT 'A'::bpchar,
  vendas double precision DEFAULT 0,
  volume integer DEFAULT 0,
  dinheiro double precision DEFAULT 0,
  cheque double precision DEFAULT 0,
  crediario double precision DEFAULT 0,
  visa double precision DEFAULT 0,
  master double precision DEFAULT 0,
  cartao double precision DEFAULT 0,
  recebimentos double precision DEFAULT 0,
  debito double precision DEFAULT 0,
  boleto double precision DEFAULT 0,
  CONSTRAINT resumos_pkey PRIMARY KEY (indice),
  CONSTRAINT resumos_fk FOREIGN KEY (usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT resumos_fk1 FOREIGN KEY (caixa)
      REFERENCES cad_caixa (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT resumos_fk2 FOREIGN KEY (cancelado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT resumos_fk3 FOREIGN KEY (alterado_usuario)
      REFERENCES cad_usuarios (codigo) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (
  OIDS=TRUE
);
ALTER TABLE resumos
  OWNER TO postgres;
ALTER TABLE resumos ALTER COLUMN indice SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN data SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN hora SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN usuario SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN caixa SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN saldo_anterior SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN saldo SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN entrada SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN saida SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN vales SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN despesas SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN pagamentos SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN transferencias SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN situacao SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN cancelado SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN cancelado_usuario SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN alterado SET STATISTICS 0;
ALTER TABLE resumos ALTER COLUMN alterado_usuario SET STATISTICS 0;



CREATE TABLE estados (
    codigo integer,
    nome character varying,
    sigla character varying,
    regiao character varying
);


ALTER TABLE public.estados OWNER TO postgres;

CREATE TABLE municipios (
    estado character varying,
    uf character varying,
    codigo integer,
    nome character varying
);


ALTER TABLE public.municipios OWNER TO postgres;

