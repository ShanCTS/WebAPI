using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class POMasterModel
    {
        public string PONO { get; set; }
        public Nullable<System.DateTime> PODATE { get; set; }
        public string SUPLNO { get; set; }
        //public ICollection<PODETAIL> PODETAILs { get; set; }
        public SupplierModel SUPPLIER { get; set; }
    }
}