INSERT INTO fabricante VALUES ('Lacta', 'www.lacta.com.br', '0800-7041940');
INSERT INTO fabricante VALUES ('Garoto', 'www.garoto.com.br', '0800-559550');
INSERT INTO fabricante VALUES ('Nestle', 'www.nestle.com.br', '0800-7702411');

INSERT INTO tipo VALUES ('Chocolate', 1);

INSERT INTO produto VALUES (0, 0, 'Sonho de Valsa', '21,5g', 'chocolate', '0000078913547');
INSERT INTO produto VALUES (1, 0, 'Batom', '16g', 'chocolate', '0000078912359');
INSERT INTO produto VALUES (2, 0, 'Chokito', '32g', 'chocolate', '7891000066201');

INSERT INTO estoque VALUES ('Despensa de casa', 1);
INSERT INTO estoque VALUES('Despensa do trabalho', 1);

INSERT INTO usuario VALUES ('Maria Lúcia', 'marilu', '12345');
INSERT INTO usuario VALUES ('Marcos', 'marcao', '67890');

INSERT INTO usuario_estoque VALUES (0,0);
INSERT INTO usuario_estoque VALUES (1,1);

INSERT INTO produto_estoque VALUES (0, 0, '08/20/2015', '01/23/2016');
INSERT INTO produto_estoque VALUES (1, 1, '08/24/2015', '01/21/2016');
INSERT INTO produto_estoque VALUES (2, 0, '08/28/2015', '01/29/2016');

select * from usuario