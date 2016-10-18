using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Despensometro2.Models;
using System.Data.Entity;

namespace Despensometro2.Repositories
{

    public class ProdutoRepository
    {
        private despensometroEntities db;

        public ProdutoRepository()
        {
            db = new despensometroEntities();

        }

        public List<dynamic> FiltraProduto(string valor)
        {
            
            if (valor != null)
            {
                //var produtosFiltrados = db.produto.Where(obj => obj.produto_nome.Contains(valor)
                //|| obj.fabricante.nome_fabricante.Contains(valor)
                //|| obj.tipo.categoria_produto.Contains(valor)
                //|| obj.sabor.Contains(valor)
                //|| obj.numero_ean.Contains(valor)
                //|| obj.produto_peso.Contains(valor))
                //.Select().ToList();

                var produtosFiltrados = (from p in db.produto
                                                   where p.produto_nome.Contains(valor)
                                                   || p.fabricante.nome_fabricante.Contains(valor)
                                                   || p.tipo.categoria_produto.Contains(valor)
                                                   || p.sabor.Contains(valor)
                                                   || p.numero_ean.Contains(valor)
                                                   || p.produto_peso.Contains(valor)
                                                   select new { p.produto_nome, p.produto_peso, p.sabor, p.fabricante.nome_fabricante, p.numero_ean, p.tipo.categoria_produto, p.tipo.perecivel }).ToList<dynamic>();

                return produtosFiltrados;
            }
            else
            {
                var produtosFiltrados = (from p in db.produto
                                             select new { p.produto_nome, p.produto_peso, p.sabor, p.fabricante.nome_fabricante, p.numero_ean, p.tipo.categoria_produto, p.tipo.perecivel }).ToList<dynamic>();

                return produtosFiltrados;
            }         
        }
    }
}