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
    
    public partial class produto_estoque
    {
        public int produto_estoque_id { get; set; }
        public int produto_id { get; set; }
        public int estoque_id { get; set; }
        public System.DateTime data_fabricacao { get; set; }
        public System.DateTime data_vencimento { get; set; }
    
        public virtual estoque estoque { get; set; }
        public virtual produto produto { get; set; }
    }
}
