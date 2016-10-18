using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Despensometro2.Models;
using System.Data.Entity;

namespace Despensometro2.Repositories
{
    public class EstoqueRepository
    {
        private despensometroEntities db;
        private usuario user;

        public EstoqueRepository(usuario user)
        {
            db = new despensometroEntities();
            this.user = user;
        }

        //obtém todos os produtos dos estoques de um usuário que estão vencendo (a 5 dias do vencimento)
        public ProdutoVencendoList ProdutoVencendo()
        {
            DateTime dataHoje = DateTime.Today;

            IQueryable<estoque> e = EstoquesUsuario();

            List<produto_estoque> produtosVenEstoque = db.produto_estoque.Where(obj =>
                (obj.data_vencimento.Day - dataHoje.Day <= 5 && obj.data_vencimento.Day - dataHoje.Day >= 0)
                    && obj.data_vencimento.Month == dataHoje.Month && obj.data_vencimento.Year == dataHoje.Year &&
                    e.Select(x => x.estoque_id).Contains(obj.estoque_id))
                    .ToList();

            List<produto> produtosVencendo = new List<produto>();

            foreach (produto_estoque prod_est in produtosVenEstoque){

               produtosVencendo.Add(db.produto.First(obj => prod_est.produto_id == obj.produto_id ));
            }

            return new ProdutoVencendoList(produtosVencendo, produtosVenEstoque);
        }

        public ProdutoVencendoList ProdutoVencido()
        {
            DateTime dataHoje = DateTime.Today;

            IQueryable<estoque> e = EstoquesUsuario();

            List<produto_estoque> produtos = db.produto_estoque.Where(obj =>
                obj.data_vencimento < dataHoje &&
                    e.Select(x => x.estoque_id).Contains(obj.estoque_id)).ToList();

            List<produto> produtosVencido = new List<produto>();

            foreach (produto_estoque prod_est in produtos)
            {

                produtosVencido.Add(db.produto.First(obj => prod_est.produto_id == obj.produto_id));
            }

            return new ProdutoVencendoList(produtosVencido, produtos);
        }

        //lista todos os estoques de determinado usuario
        public IQueryable<estoque> EstoquesUsuario()
        {
            IQueryable<estoque> e = db.estoque.Where(obj => obj.usuario.Any(x => x.usuario_id == user.usuario_id));

            return e;
        }

        //lista todos os produtos de um determinado estoque
        public IQueryable<produto> ProdutoEstoque(estoque e)
        {

            IQueryable<produto> p = db.produto.Where(obj => obj.produto_estoque.Any(x => x.estoque_id == e.estoque_id));

            return p;
        }
    }
}