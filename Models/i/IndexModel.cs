
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADIM_2.Models.i
{
    public class IndexModel
    {
        public List<DB.products>  products { get; set; }
        public DB.productcategories category { get; set; }
    }
}