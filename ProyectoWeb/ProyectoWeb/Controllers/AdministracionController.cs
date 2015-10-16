using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using System.Web.Security;
namespace ProyectoWeb.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/
        Entities db = new Entities();

        public ActionResult Index()
        {
            if(Request.IsAuthenticated){
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }    
    }
}
