using ProyectoWeb.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.ModelsDTO;

namespace ProyectoWeb.Controllers
{
    public class CarteleraController : Controller
    {
        //
        // GET: /Cartelera/
        Entities db = new Entities();

        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return View(db.Funcion.Where(f => f.cod_estado_pelicula == "TE000001").ToList());
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public void CodigoCartelera()
        {
            String numero = db.Funcion.Max(v => v.cod_funcion);

            if (numero == null)
            {
                ViewBag.codigo = "F" + "0000001";
            }
            else
            {
                int num = int.Parse(numero.Substring(5)) + 1;
                ViewBag.codigo = "F" + num.ToString("000000");
            }
        }

        public ActionResult SalasDisponibles(int idLocal)
        {
            List<tb_sala> salas = db.Sala.Where(x => x.id_local == idLocal).ToList();
            List<tb_salaDTO> salasDTO = new List<tb_salaDTO>();

            foreach(var sala in salas){
                tb_salaDTO s = new tb_salaDTO();
                s.cod_sala = sala.cod_sala;
                s.nom_sala = sala.nom_sala;
                s.tipo_proyeccion = sala.tipo_proyeccion;
                salasDTO.Add(s);
            }

            return Json(salasDTO, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AgregarHorarioFuncion(List<tb_horarios_funcionDTO> lista)
        {
            //capturar datos del horario y crea nuevo dto y retornar nueva lista
            List<tb_horarios_funcionDTO> listaHorarios = (List<tb_horarios_funcionDTO>)Session["horarios_funcion"];
            
            foreach (var horario in lista)
            {
                listaHorarios.Add(horario);
            }
           
            Session["horarios_funcion"] = listaHorarios;

            return Json(listaHorarios, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarHorarioFuncion(tb_horarios_funcionDTO horarioFuncion)
        {
            List<tb_horarios_funcionDTO> listaHorarios = (List<tb_horarios_funcionDTO>)Session["horarios_funcion"];

            tb_horarios_funcionDTO hf = listaHorarios.Where(x => x.id_dia == horarioFuncion.id_dia && x.hora_inicio == horarioFuncion.hora_inicio).FirstOrDefault();
            if (hf != null)
            {
                listaHorarios.Remove(hf);
            }
            Session["horarios_funcion"] = listaHorarios;

            return Json(listaHorarios, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AgregarCartelera()
        {
            Session["horarios_funcion"] = new List<tb_horarios_funcionDTO>();

            CodigoCartelera();
            ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
            ViewBag.dias = new SelectList(db.Dias.ToList(), "id_dia", "nombre");
            ViewBag.salas = new SelectList(db.Sala.ToList(), "cod_sala", "nom_sala");
            ViewBag.peliculas = new SelectList(db.Peliculas.ToList(), "cod_peli", "nombre_peli");
            tb_funcion reg = new tb_funcion();
            return View(reg);
        }

        [HttpPost]
        public ActionResult AgregarCartelera(tb_funcion reg, String fecha_inicio, String fecha_fin, String hora_inicio)
        {
            if (!ModelState.IsValid)
            {
                CodigoCartelera();
                ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
                ViewBag.dias = new SelectList(db.Dias.ToList(), "id_dia", "nombre");
                ViewBag.salas = new SelectList(db.Sala.ToList(), "cod_sala", "nom_sala");
                ViewBag.peliculas = new SelectList(db.Peliculas.ToList(), "cod_peli", "nombre_peli");
                ViewBag.fecha_inicio = fecha_inicio;
                ViewBag.fecha_fin = fecha_fin;

                ModelState.AddModelError("Error", "Error al grabar Cartelera");
                return View(reg);
            }
            if (fecha_inicio != null || fecha_fin != null)
            {
                reg.fecha_inicio = DateTime.Parse(fecha_inicio);
                reg.fecha_fin = DateTime.Parse(fecha_fin);
            }

            List<tb_horarios_funcionDTO> lista = (List<tb_horarios_funcionDTO>)Session["horarios_funcion"];
            if (lista.Count == 0)
            {
                CodigoCartelera();
                ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
                ViewBag.dias = new SelectList(db.Dias.ToList(), "id_dia", "nombre");
                ViewBag.salas = new SelectList(db.Sala.ToList(), "cod_sala", "nom_sala");
                ViewBag.peliculas = new SelectList(db.Peliculas.ToList(), "cod_peli", "nombre_peli");
                ViewBag.fecha_inicio = fecha_inicio;
                ViewBag.fecha_fin = fecha_fin;
                TempData["ErrorLista"] = "Agregue Horarios";
                return View(reg);
            }

            reg.cod_estado_pelicula = "TE000001";
            db.Funcion.Add(reg);

            
            foreach (var horario in lista)
            {
                tb_horario_funcion hf = new tb_horario_funcion();
                hf.cod_funcion = reg.cod_funcion;
                hf.hora_inicio = horario.hora_inicio;

                TimeSpan t1 = TimeSpan.Parse(horario.hora_inicio);
                TimeSpan t2 = TimeSpan.Parse("02:00:00");
                TimeSpan t3 = t1.Add(t2);

                hf.hora_fin = new DateTime(t3.Ticks).ToString("HH:mm");
                hf.id_dia = horario.id_dia;

                db.HorariosFuncion.Add(hf);
            }

            db.SaveChanges();

            Session["horarios_funcion"] = null;

            return RedirectToAction("Index", "Cartelera");

        }
        public ActionResult EditarCartelera(string id)
        {
            tb_funcion funcion = db.Funcion.Where(v => v.cod_funcion == id).FirstOrDefault();
            ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
            ViewBag.dias = new SelectList(db.Dias.ToList(), "id_dia", "nombre");
            ViewBag.salas = new SelectList(db.Sala.ToList(), "cod_sala", "nom_sala");
            ViewBag.peliculas = new SelectList(db.Peliculas.ToList(), "cod_peli", "nombre_peli");

            ViewBag.fecha_inicio = funcion.fecha_inicio;
            ViewBag.fecha_fin = funcion.fecha_fin;

            return View(funcion);
        }

        [HttpPost]
        public ActionResult EditarCartelera(tb_funcion reg)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
                ViewBag.salas = new SelectList(db.Sala.ToList(), "cod_sala", "nom_sala");
                ViewBag.peliculas = new SelectList(db.Peliculas.ToList(), "cod_peli", "nombre_peli");
                ViewBag.estadopelicula = new SelectList(db.EstadoPelicula.ToList(), "cod_estado_pelicula", "descripcion");
                return View(reg);
                
            }

            try
            {
                tb_funcion funcion = db.Funcion.Where(v => v.cod_funcion == reg.cod_funcion).FirstOrDefault();
                funcion.fecha_inicio = reg.fecha_inicio;
                funcion.fecha_fin = reg.fecha_fin;
                funcion.cod_peli = reg.cod_peli;
                funcion.cod_sala = reg.cod_sala;

                db.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Error al editar datos");
            }
            return RedirectToAction("Index", "Cartelera");
        }


        public ActionResult EliminarCartelera(string id)
        {         
            tb_funcion funcion = db.Funcion.Where(x => x.cod_funcion == id).FirstOrDefault();
            funcion.cod_estado_pelicula = "TE000002";
            db.SaveChanges();
            return RedirectToAction("Index", "Cartelera");
        }


    }
}
