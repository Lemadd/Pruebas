using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.tb_usuario user)
        {
            if (ModelState.IsValid)
            {


                if (Isvalid(user.dni, user.clave))
                {
                    FormsAuthentication.SetAuthCookie(user.dni, false);
                    return RedirectToAction("Index", "Administracion");
                }
                else
                {
                    ModelState.AddModelError("", "Datos Incorrectos");
                }
            }
            return View(user);
        }
        private bool Isvalid(string dni, string clave)
        {
            bool Isvalid = false;
            {
                var user = db.Usuarios.FirstOrDefault(u => u.dni == dni);
                if (user != null)
                {
                    if (user.clave == clave)
                    {
                        Isvalid = true;
                    }
                }
            }
            return Isvalid;
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
