CREATE DATABASE despensometro;
USE despensometro
GO
CREATE TABLE fabricante(
	fabricante_id INT IDENTITY(0,1) NOT NULL,
	nome_fabricante VARCHAR(80) NOT NULL,
	site NVARCHAR(1000),
	telefone VARCHAR(20),

	PRIMARY KEY(fabricante_id)
);

CREATE TABLE tipo(
	tipo_id INT IDENTITY(0,1) NOT NULL,
	categoria_produto VARCHAR(40),
	perecivel BIT NOT NULL,
	
	PRIMARY KEY(tipo_id)
);

CREATE TABLE produto(
	produto_id INT IDENTITY(0,1) NOT NULL,
	fabricante_id INT NOT NULL,
	tipo_id INT,
	produto_nome VARCHAR(50) NOT NULL,
	produto_peso VARCHAR(10),
	sabor VARCHAR(20),
	numero_ean VARCHAR(15),

	PRIMARY KEY(produto_id),
	FOREIGN KEY(fabricante_id) REFERENCES fabricante 
	ON DELETE CASCADE,
	FOREIGN KEY (tipo_id) REFERENCES tipo
	ON DELETE SET NULL
);

CREATE TABLE estoque(
	estoque_id INT IDENTITY(0,1) NOT NULL,
	estoque_nome VARCHAR(40) NOT NULL,
	compartilhavel BIT NOT NULL DEFAULT (0),

	PRIMARY KEY(estoque_id)
);

CREATE TABLE produto_estoque(
	produto_estoque_id INT NOT NULL IDENTITY(0,1),
	produto_id INT NOT NULL,
	estoque_id INT NOT NULL,
	data_fabricacao DATE NOT NULL,
	data_vencimento DATE NOT NULL,
	PRIMARY KEY (produto_estoque_id),
	FOREIGN KEY(produto_id)	REFERENCES produto ON DELETE CASCADE,
	FOREIGN KEY(estoque_id) REFERENCES estoque ON DELETE CASCADE
);

CREATE TABLE usuario(
	usuario_id INT IDENTITY(0,1) NOT NULL,
	nome_usuario VARCHAR(100) NOT NULL DEFAULT ('ANÔNIMO'),
	login_usuario VARCHAR(40) NOT NULL,
	senha NVARCHAR(16) NOT NULL,

	PRIMARY KEY (usuario_id)
);

CREATE TABLE usuario_estoque(
	estoque_id INT NOT NULL REFERENCES estoque ON DELETE CASCADE,
	usuario_id INT NOT NULL REFERENCES usuario ON DELETE CASCADE,

	PRIMARY KEY(estoque_id, usuario_id)
);

CREATE TABLE listaCompras(
	lista_id INT IDENTITY(0,1) NOT NULL,
	nome_lista VARCHAR(40) NOT NULL DEFAULT ('SUPERMERCADO'),
	compartilhavel BIT NOT NULL DEFAULT (0),
	usuario_id INT NOT NULL,

	PRIMARY KEY(lista_id), 

	FOREIGN KEY(usuario_id) REFERENCES usuario
	ON DELETE CASCADE
);

CREATE TABLE listaCompras_produto(
	lista_id INT NOT NULL REFERENCES listaCompras,
	produto_id INT NOT NULL REFERENCES produto,
	quantidade_produto INT NOT NULL DEFAULT (1),

	PRIMARY KEY(lista_id, produto_id)
);

CREATE TABLE receitaInternet(
	receita_id INT IDENTITY(0,1) NOT NULL,
	nome_receita VARCHAR(40) NOT NULL,
	link_receita NVARCHAR(1000) NOT NULL,

	PRIMARY KEY(receita_id)
);

CREATE TABLE receitaInternet_produto(
	receita_id INT NOT NULL REFERENCES receitaInternet ON DELETE CASCADE,
	produto_id INT NOT NULL REFERENCES produto ON DELETE CASCADE,

	PRIMARY KEY(receita_id, produto_id)
);

CREATE TABLE ingrediente(
	ingrediente_id INT IDENTITY(0,1) NOT NULL,
	produto_id INT,
	ingrediente_nome VARCHAR(50),
	quantidade_ingrediente VARCHAR(100) NOT NULL,

	PRIMARY KEY(ingrediente_id),
	FOREIGN KEY(produto_id) REFERENCES produto
	ON DELETE SET NULL
);

CREATE TABLE receitaUsuario(
	receita_id INT IDENTITY(0,1) NOT NULL,
	nome_receita VARCHAR(40) NOT NULL,
	ingrediente_id INT,
	modo_preparo VARCHAR(8000) NOT NULL,
	usuario_id INT,

	PRIMARY KEY(receita_id),
	FOREIGN KEY(ingrediente_id) REFERENCES ingrediente 
	ON DELETE SET NULL,
	FOREIGN KEY(usuario_id) REFERENCES usuario
	ON DELETE SET NULL
);

