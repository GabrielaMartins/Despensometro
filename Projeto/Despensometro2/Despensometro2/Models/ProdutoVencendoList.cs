using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despensometro2.Models
{
    public class ProdutoVencendoList
    {
        public List<produto> produto { get; set; }
        public List<produto_estoque> produto_estoque { get; set; }

        public ProdutoVencendoList(List<produto> produto, List<produto_estoque> produto_estoque)
        {   
            this.produto_estoque = produto_estoque;
            this.produto = produto;
        }
    }
}