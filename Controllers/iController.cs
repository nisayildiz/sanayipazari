
using ADIM_2.DB;
using ADIM_2.Models.i;
//using ADIM2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADIM_2.Controllers
{
    public class iController :BaseController
    {
        
       
        // GET: i
        [HttpGet]
        public ActionResult Index()
        {
            IQueryable<DB.products> products = context.products;

            
            var viewModel = new Models.i.IndexModel()
            {
                products = context.products.ToList()
               
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult product(int id)
        {
            var pro = context.products.FirstOrDefault(x => x.id == id);
            if (pro == null) return RedirectToAction("index", "i");
            productModels model = new productModels()
            {
                product = pro
            };
            return View(model);
        }
    }
}