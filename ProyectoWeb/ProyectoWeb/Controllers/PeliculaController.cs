using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using System.IO;
using System.Web.UI.WebControls;
namespace ProyectoWeb.Controllers
{
    public class PeliculaController : Controller
    {
        //
        // GET: /Pelicula/
        Entities db = new Entities();

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Peliculas.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public ActionResult BuscarPeliculas(string pelicula = null)
        {
            if (Request.IsAuthenticated)
            {
                var listaPeliculas = from s in db.Peliculas.Where(s => s.nombre_peli.Contains(pelicula)) select s;


                if (listaPeliculas.Count() == 0)
                {
                    ViewBag.mensaje = "No hay coincidencias con la busqueda";
                }
                return View(listaPeliculas.ToList());

            }else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult AgregarPelicula()
        {
            CodigoPelicula();
            ViewBag.actualyear = DateTime.Today.Year;
            ViewBag.generos = new SelectList(db.Generos.ToList(), "cod_genero", "descripcion");
            ViewBag.estadopelicula = new SelectList(db.EstadoPelicula.ToList(), "cod_estado_pelicula", "descripcion");
            ViewBag.tipopelicula = new SelectList(db.TipoPelicula.ToList(), "cod_tipo_pelicula", "descripcion");
            ViewBag.clasificacionpelicula = new SelectList(db.ClasificacionPelicula.ToList(), "cod_clasificacion_pelicula", "descripcion");
            tb_peliculas reg = new tb_peliculas();
            return View(reg);
        }

        public void CodigoPelicula()
        {
            String numero = db.Peliculas.Max(v => v.cod_peli);

            if (numero == null)
            {
                ViewBag.codigo = "PE" + "000001";
            }
            else
            {
                int num = int.Parse(numero.Substring(5)) + 1;
                ViewBag.codigo = "PE" + num.ToString("000000");
            }
        }

        [HttpPost]
        public ActionResult AgregarPelicula(tb_peliculas reg, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                CodigoPelicula();
                ViewBag.actualyear = DateTime.Today.Year;
                ViewBag.generos = new SelectList(db.Generos.ToList(), "cod_genero", "descripcion");
                ViewBag.estadopelicula = new SelectList(db.EstadoPelicula.ToList(), "cod_estado_pelicula", "descripcion");
                ViewBag.tipopelicula = new SelectList(db.TipoPelicula.ToList(), "cod_tipo_pelicula", "descripcion");
                ViewBag.clasificacionpelicula = new SelectList(db.ClasificacionPelicula.ToList(), "cod_clasificacion_pelicula", "descripcion");
                ModelState.AddModelError("Error", "Error al grabar Pelicula");
                return View(reg);
            }else
            { 
                if(file!=null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/images/peliculas/")+ file.FileName);
                    reg.imagePath = file.FileName;
                }
                    db.Peliculas.Add(reg);
                    db.SaveChanges();
                    TempData["SUCCESS"] = "Pelicula registrada correctamente.";
                    return RedirectToAction("Index", "Pelicula");
            }

        }
        public ActionResult EditarPelicula(string id=null)
        {
            tb_peliculas peli = db.Peliculas.Where(v => v.cod_peli == id).FirstOrDefault();
            ViewBag.generos = new SelectList(db.Generos.ToList(), "cod_genero", "descripcion");
            ViewBag.estadopelicula = new SelectList(db.EstadoPelicula.ToList(), "cod_estado_pelicula", "descripcion");
            ViewBag.tipopelicula = new SelectList(db.TipoPelicula.ToList(), "cod_tipo_pelicula", "descripcion");
            ViewBag.clasificacionpelicula = new SelectList(db.ClasificacionPelicula.ToList(), "cod_clasificacion_pelicula", "descripcion");
            return View(peli);
        }

        [HttpPost]
        public ActionResult EditarPelicula(tb_peliculas reg, HttpPostedFileBase file)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.generos = new SelectList(db.Generos.ToList(), "cod_genero", "descripcion");
                    ViewBag.estadopelicula = new SelectList(db.EstadoPelicula.ToList(), "cod_estado_pelicula", "descripcion");
                    ViewBag.tipopelicula = new SelectList(db.TipoPelicula.ToList(), "cod_tipo_pelicula", "descripcion");
                    ViewBag.clasificacionpelicula = new SelectList(db.ClasificacionPelicula.ToList(), "cod_clasificacion_pelicula", "descripcion");
                    return View(reg);
                }
                tb_peliculas peli = db.Peliculas.Where(v => v.cod_peli == reg.cod_peli).FirstOrDefault();
                peli.nombre_peli = reg.nombre_peli;
                peli.titulo_origen = reg.titulo_origen;
                peli.sinopsis = reg.sinopsis;
                peli.director = reg.director;
                peli.actores = reg.actores;
                peli.cod_clasificacion_pelicula = reg.cod_clasificacion_pelicula;
                peli.duracion = reg.duracion;
                peli.pais_origen = reg.pais_origen;
                peli.fecha_estreno = reg.fecha_estreno;
                peli.cod_genero = reg.cod_genero;
                peli.cod_tipo_pelicula = reg.cod_tipo_pelicula;
                peli.cod_estado_pelicula = reg.cod_estado_pelicula;
                peli.trailer = reg.trailer;
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/images/peliculas/") + file.FileName);
                    reg.imagePath = file.FileName;
                    peli.imagePath = reg.imagePath;
                }
                db.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Error al editar datos");
            }
            return RedirectToAction("Index", "Pelicula");
        }

        public ActionResult EliminarPelicula(string id)
        {
            tb_peliculas v = db.Peliculas.Where(ven => ven.cod_peli == id).FirstOrDefault();
            db.Peliculas.Remove(v);
            db.SaveChanges();
            return RedirectToAction("Index", "Pelicula");
        }
        public ActionResult EjemploJSON()
        {
            var pel = db.Peliculas.ToList();
            return Json(pel, JsonRequestBehavior.AllowGet);
        }
    }
}
