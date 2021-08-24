using ADIM_2.DB;
using ADIM_2.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADIM_2.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        [HttpGet]

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Models.Account.RegisterModels user)
        {
            try
            {
                if (user.rePassword != user.Member.password)
                {
                    throw new Exception("Şifreler aynı değildir");

                }
                context.Members.Add(user.Member);
                context.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.ReError = ex.Message;
                return View();
            }
            
        }
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Login(Models.Account.LoginModels model)
        {
            try
            {
                var user = context.Members.FirstOrDefault(x => x.password == model.Member.password && x.email == model.Member.email);
                if (user!=null)
                {
                    Session["LogonUser"] = user;
                    return RedirectToAction("index", "i");
                }
                else
                {
                    ViewBag.ReError = "Kullanıcı bilgileriniz yanlış";
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ReError = ex.Message;
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            Session["LogonUser"] = null;
            return RedirectToAction("Login","Account");
        }
        [HttpGet]
        public ActionResult Profil(int id = 0)
        {
           
            var user = context.Members.FirstOrDefault(x => x.id == id);
            if (user == null) return RedirectToAction("index", "i");
            ProfilModels model = new ProfilModels()
            {
                Members = user

            };
            return View(model);
        }
        

    }


}