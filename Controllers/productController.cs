using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADIM_2.Controllers
{
    public class productController : BaseController
    {
        // GET: product
        public ActionResult i()
        {
           
            var products = context.products.ToList();
            return View(products);
        }
    }
}