using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Despensometro2.Models
{
    public class ProdutoSimplificado
    {
        public String produto_nome { get; set; }
        public String produto_fabricante { get; set; }
        public String sabor { get; set; }
        public String numero_ean { get; set; }
        public String produto_peso { get; set; }
        public String produto_categoria { get; set; } 
    }
}