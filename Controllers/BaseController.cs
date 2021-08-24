using ADIM_2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADIM_2.Controllers
{
    public class BaseController : Controller
    {
        protected OffersEntities1 context { get; private set; }
        public BaseController()
        {
            context = new OffersEntities1();
           
        }
    }

    
}