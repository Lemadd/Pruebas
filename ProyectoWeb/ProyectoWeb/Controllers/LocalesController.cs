using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class LocalesController : Controller
    {
        //
        // GET: /Locales/
        Entities db=new Entities();

        public ActionResult Index(string nombreLocal = null)
        {
            if (nombreLocal != null)
            {
                ViewBag.local = nombreLocal;
                return View(db.Local.Where(x => x.nom_local.StartsWith(nombreLocal)).ToList());
            }

            return View(db.Local.ToList());
        }


        public ActionResult LocalesMantenimiento()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
        }
        public ActionResult AgregarLocal()
        {
            if (Request.IsAuthenticated)
            {
                tb_local reg = new tb_local();
                return View(reg);
            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
        }

        [HttpPost]
        public ActionResult AgregarLocal(tb_local reg)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error al grabar Local");
                return View(reg);
            }

            db.Local.Add(reg);
            db.SaveChanges();
            TempData["SUCCESS"] = "Local registrado correctamente.";

            return RedirectToAction("Index");
        }

        public ActionResult EditarLocal(int id)
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Local.Where(l => l.id_local == id).FirstOrDefault());
            }

            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult EditarLocal(tb_local reg)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Error al grabar Local");
                return View(reg);
            }

            tb_local local = db.Local.Where(nl => nl.id_local == reg.id_local).FirstOrDefault();
            local.nom_local = reg.nom_local;
            local.dir_local = reg.dir_local;
            local.telefono = reg.telefono;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
