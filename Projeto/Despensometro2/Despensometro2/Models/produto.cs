//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Despensometro2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class produto
    {
        public produto()
        {
            this.ingrediente = new HashSet<ingrediente>();
            this.listaCompras_produto = new HashSet<listaCompras_produto>();
            this.produto_estoque = new HashSet<produto_estoque>();
            this.receitaInternet = new HashSet<receitaInternet>();
        }
    
        public int produto_id { get; set; }
        public int fabricante_id { get; set; }
        public Nullable<int> tipo_id { get; set; }
        public string produto_nome { get; set; }
        public string produto_peso { get; set; }
        public string sabor { get; set; }
        public string numero_ean { get; set; }
    
        public virtual fabricante fabricante { get; set; }
        public virtual ICollection<ingrediente> ingrediente { get; set; }
        public virtual ICollection<listaCompras_produto> listaCompras_produto { get; set; }
        public virtual tipo tipo { get; set; }
        public virtual ICollection<produto_estoque> produto_estoque { get; set; }
        public virtual ICollection<receitaInternet> receitaInternet { get; set; }
    }
}
