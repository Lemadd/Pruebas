using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
namespace ProyectoWeb.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        Entities db = new Entities();

        public ActionResult Index()
        {
            var listaPeliculas = from s in db.Peliculas.Where(s => s.TipoPelicula.descripcion == "Estreno") select s;
            if (listaPeliculas.Count() == 0)
            {
                ViewBag.mensaje = "No hay estrenos en estos momentos";
            }
            return View(listaPeliculas.ToList());
        }

        //Lista todas las Peliculas en Cartelera(Activas)
        public ActionResult ListarTodo()
        {
            var listaPeliculas = from s in db.Peliculas.Where(s => s.EstadoPelicula.descripcion == "Activo") select s;
            return View(listaPeliculas.ToList());
        }

        //Lista todas las Peliculas que son estrenos
        public ActionResult ListarEstrenos()
        {
            var listaPeliculas = from s in db.Peliculas.Where(s => s.TipoPelicula.descripcion == "Estreno") select s;
            if (listaPeliculas.Count() == 0)
            {
                ViewBag.mensaje = "No hay estrenos en estos momentos";
            }
            return View(listaPeliculas.ToList());
        }

        //Lista todas las Peliculas por genero 
        public ActionResult ListarPeliculasGenero(string id = null)
        {
            System.Diagnostics.Trace.WriteLine("el genero elegido es : ", "" + id);
            var listaPeliculas = from s in db.Peliculas.Where(s => s.cod_genero == id) select s;
            //Para jalar el nombre del genero
            tb_genero reggenero = db.Generos.Where(s => s.cod_genero == id).FirstOrDefault();
            ViewBag.mensajegenero = reggenero.descripcion;

            if (listaPeliculas.Count() == 0)
            {
                ViewBag.mensaje = "No hay peliculas de este genero";
            }
            return View(listaPeliculas.ToList());
        }

        //busqueda de peliculas relacionadas al nombre ingresado
        public ActionResult BuscarPeliculas(string pelicula = null)
        {
            System.Diagnostics.Trace.WriteLine("La peli buscada es : ", "" + pelicula);
            ViewBag.pelicula = pelicula;
            var listaPeliculas = from s in db.Peliculas.Where(s => s.nombre_peli.Contains(pelicula)) select s;

            if (listaPeliculas.Count() == 0)
            {
                ViewBag.mensaje = "No hay coincidencias con la busqueda";
            }
            return View(listaPeliculas.ToList());
        }

        //Busca pelicula en base al id y devuelve pantalla con los datos de la pelicula
        public ActionResult VerPelicula(string id = null)
        {
            System.Diagnostics.Trace.WriteLine("La peli elegida es : ", "" + id);
            tb_peliculas reg = db.Peliculas.Where(s => s.cod_peli == id).FirstOrDefault();
            return View(reg);
        }



        public ActionResult DetalleCartelera(String idpelicula = null)
        {
            ViewBag.locales = new SelectList(db.Local.ToList(), "id_local", "nom_local");
            tb_peliculas pelicula = db.Peliculas.Where(p => p.cod_peli == idpelicula).FirstOrDefault();
            ViewBag.nombrePeli = pelicula.nombre_peli;

            string codigoFuncion = db.Funcion.Where(v => v.cod_peli == idpelicula).Max(v => v.cod_funcion);
            DateTime fecha = DateTime.Now;

            List<tb_horario_funcion> funciones = db.HorariosFuncion.Where(s => s.cod_funcion == codigoFuncion).
                Where(s=> s.id_dia >= (int)fecha.DayOfWeek).
                OrderBy(s => s.id_dia).ToList();

            List<int> dias = db.HorariosFuncion.Where(s => s.cod_funcion == codigoFuncion).
                Where(s => s.id_dia >= (int)fecha.DayOfWeek).Select(s => s.id_dia).Distinct().OrderBy(id_dia => id_dia).ToList();

            List<String> fechas = new List<String>();
            int numeroDiaActual = (int)DateTime.Now.DayOfWeek;
            foreach(var dia in dias)
            {
                int diferenciaDias = dia - numeroDiaActual;
                fechas.Add(DateTime.Now.AddDays(diferenciaDias).ToString("dd/MM/yyyy"));
            }

            ViewBag.dias = dias;
            ViewBag.fechas = fechas;
            return View(funciones);
        }


    }
}
