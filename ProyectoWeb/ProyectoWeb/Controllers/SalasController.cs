using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoWeb.Controllers
{
    public class SalasController : Controller
    {
        //
        // GET: /Salas/
        Entities db = new Entities();
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Sala.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");

            }
        }
        public void CodigoSala()
        {
            String numero = db.Sala.Max(v => v.cod_sala);

            if (numero == null)
            {
                ViewBag.codigo = "SAL" + "00001";
            }
            else
            {
                int num = int.Parse(numero.Substring(5)) + 1;
                ViewBag.codigo = "SAL" + num.ToString("00000");
            }
        }

        public ActionResult AgregarSala()
        {
            CodigoSala();
            ViewBag.tiposala = new SelectList(db.TipoSala.ToList(), "cod_tipo_sala", "descripcion");
            ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
            tb_sala reg = new tb_sala();
            return View(reg);

        }

        [HttpPost]
        public ActionResult AgregarSala(tb_sala reg)
        {
            if (!ModelState.IsValid)
            {
                CodigoSala();
                ViewBag.tiposala = new SelectList(db.TipoSala.ToList(), "cod_tipo_sala", "descripcion");
                ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
                ModelState.AddModelError("Error", "Error al grabar Pelicula");
                return View(reg);
            }
            else
            {
                db.Sala.Add(reg);
                db.SaveChanges();
                TempData["SUCCESS"] = "Sala registrada correctamente.";
                return RedirectToAction("Index", "Salas");
            }

        }
        public ActionResult EditarSala(string id)
        {
            ViewBag.tiposala = new SelectList(db.TipoSala.ToList(), "cod_tipo_sala", "descripcion");
            ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
            return View(db.Sala.Where(v => v.cod_sala == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditarSala(tb_sala reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.tiposala = new SelectList(db.TipoSala.ToList(), "cod_tipo_sala", "descripcion");
                ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
                return View(reg);
            }
            try
            {
                tb_sala sala = db.Sala.Where(v => v.cod_sala == reg.cod_sala).FirstOrDefault();
                sala.nom_sala = reg.nom_sala;
                sala.cod_tipo_sala = reg.cod_tipo_sala;
                sala.tipo_proyeccion = reg.tipo_proyeccion;
                sala.id_local = reg.id_local;
                db.SaveChanges();
                TempData["SUCCESS"] = "Sala actualizada correctamente.";
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Error al editar datos");
            }
            return RedirectToAction("Index", "Salas");
        }

        public ActionResult AgregarTipoSala()
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

    }
}
