using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoWeb.Models;
using ProyectoWeb.ModelsDTO;
using System.Transactions;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProyectoWeb.Controllers
{
    public class VentaController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comprar(int? id = null)
        {
            tb_horario_funcion hf = db.HorariosFuncion.Where(x => x.id_horario_funcion == id).FirstOrDefault();
            tb_peliculas pelicula = hf.Funcion.Peliculas;
            ViewBag.pelicula = pelicula;
            ViewBag.tipoEntradas = db.TipoEntrada.ToList();
            ViewBag.sala = hf.Funcion.Sala;
            ViewBag.asientos = db.DetalleVenta.Where(x => x.Venta.id_horario_funcion == id).Select(x => x.asiento).ToList();
            return View(hf);
        }
        
        public ActionResult AgregarCarrito()
        {
            if (Session["carrito"] == null)
            {
                List<CarritoVenta> carritoventas = new List<CarritoVenta>();
                Session["carrito"] = carritoventas; 
            }

            return View();
        }

        public ActionResult Pagar()
        {
            return View();
        }

        public ActionResult IngresarDatosVenta(DatosVentaDTO datosVenta)
        {
            foreach(var reg in datosVenta.listaEntradas){
                tb_tipo_entrada entrada = db.TipoEntrada.Where(x => x.id_entrada == reg.id_tipo).FirstOrDefault();
                reg.desc_entrada = entrada.descripcion;
                reg.precio_uni = entrada.costo_ent;
            }

            Session["datosVenta"] = datosVenta;

            return Json(new { ok = true, newurl = Url.Action("ComprarFinal") });
        }

        public ActionResult ComprarFinal()
        {
            tb_cliente cliente = new tb_cliente();
            return View(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> ComprarFinal(tb_cliente cliente)
        {
            String listAsi = "";
            decimal monto = 0;
            int item = 1;
            String nombre_peli;
            String hora_ini ;
            String nom_sala;
            int n = 0;
            using (var scope = new TransactionScope(TransactionScopeOption.Required))
            {
                //VARIABLES PARA MOSTRAR EN COMPROBANTE
                List<tb_entradas_venta> listaEntradas = new List<tb_entradas_venta>();
                List<tb_venta_deta> listaAsientos = new List<tb_venta_deta>();

                //REGISTRANDO CLIENTE
                DatosVentaDTO datosVenta = (DatosVentaDTO)Session["datosVenta"];
                tb_cliente cli = db.Cliente.Where(s => s.correo_cli == cliente.correo_cli).FirstOrDefault();
                int id_cli = -1;
                if (cli == null)
                {
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                }
                else
                {
                    id_cli = cli.id_cliente;
                }
                

                
                tb_venta venta = new tb_venta();
                venta.id_horario_funcion = datosVenta.id_horario_funcion;
                venta.nom_sala = datosVenta.nom_sala;
                if (cli == null)
                {
                    venta.id_cliente = cliente.id_cliente;
                }
                else {
                    venta.id_cliente = id_cli;
                }

                
                venta.fecha_registro = DateTime.Now;
                foreach (var reg1 in datosVenta.listaEntradas)
                {
                    tb_entradas_venta ev1 = new tb_entradas_venta();
                    ev1.subtotal = reg1.cantidad * reg1.precio_uni;
                    monto = monto + ev1.subtotal;
                }
                venta.monto_total = monto;
                db.Venta.Add(venta);
                db.SaveChanges();

                // REGISTRANDO ASIENTOS COMPRADOS
                
                
                foreach (var reg in datosVenta.listaAsientos)
                {
                    tb_venta_deta vd = new tb_venta_deta();
                    vd.id_venta = venta.id_venta;
                    vd.item = item;
                    vd.asiento = reg.numeroAsiento;
                    listAsi = listAsi + vd.asiento + ",";
                    db.DetalleVenta.Add(vd);
                    listaAsientos.Add(vd);
                    item = item + 1;
                }
                db.SaveChanges();

                //REGISTRANDO ENTRADAS COMPRADAS
                foreach (var reg in datosVenta.listaEntradas)
                {
                    tb_entradas_venta ev = new tb_entradas_venta();
                    ev.id_entrada = reg.id_tipo;
                    ev.id_venta = venta.id_venta;
                    ev.cantidad = reg.cantidad;
                    ev.precio = reg.precio_uni;
                    ev.subtotal = reg.cantidad * reg.precio_uni;
                    db.DetalleEntradasVenta.Add(ev);
                    listaEntradas.Add(ev);
                }

                foreach (var ent in listaEntradas)
                {
                    ent.Entrada = db.TipoEntrada.Where(x => x.id_entrada == ent.id_entrada).FirstOrDefault();  
                }

                tb_horario_funcion hora_fun = db.HorariosFuncion.Where(s => s.id_horario_funcion == datosVenta.id_horario_funcion).FirstOrDefault();
                tb_funcion func = db.Funcion.Where(s => s.cod_funcion == hora_fun.cod_funcion).FirstOrDefault();
                tb_peliculas pelicula = db.Peliculas.Where(s => s.cod_peli == func.cod_peli).FirstOrDefault();
                nombre_peli=pelicula.nombre_peli;
                hora_ini=hora_fun.hora_inicio;
                nom_sala=venta.nom_sala;

                db.SaveChanges();

                TempData["horarioFuncion"] = db.HorariosFuncion.Where(x => x.id_horario_funcion == datosVenta.id_horario_funcion).FirstOrDefault();
                TempData["listaEntradas"] = listaEntradas;
                TempData["listaAsientos"] = listaAsientos;
                TempData["venta"] = venta;

                Session["datosVenta"] = null;

                scope.Complete();

               
            }
            if (ModelState.IsValid)
                {
                    

                    String body = "</p><p>Usted a adquirido lo siguiente: </p>" + 
                        "<div>" +
                            "Nombre de la Pelicula              : " + nombre_peli + "</p><br/>" +
                            "Hora de Inicio                     : " + hora_ini + "</p><br/>" +
                            "Nombre de la Sala                  : " + nom_sala + "</p><br/>" +
                            "Total de entradas adquiridas       : " + item + "</p><br/>" +
                            "Asientos comprados para la funcion : " + listAsi + "</p><br/>" +
                            "Total de la Compra                 : s/." + monto + "</p><br/>" +
                            "<p>Muchas gracias por su compra, " + cliente.nombre_cli + " (" + cliente.correo_cli + ")" +
                        "</div>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(cliente.correo_cli));
                    message.From = new MailAddress("yoteveo@black-sword.me");
                    message.Subject = "Compra de Entradas para Cine - YOTEVEO";
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                        {
                            var credential = new NetworkCredential
                            {
                                UserName = "yoteveo@black-sword.me",
                                Password = "yoteveo12345"
                            };
                            smtp.Credentials = credential;
                            smtp.Host = "smtpout.secureserver.net";
                            await smtp.SendMailAsync(message);
                        }
                    }
            Session.Clear();
            return RedirectToAction("Comprobante");
        }

        public ActionResult Comprobante()
        {
            return View();
        }


        public int autogenerado()
        {
            int numero = 0;
            try
            {
                numero = db.Venta.Max(v => v.id_venta);
            }
            catch (Exception e)
            {
                numero = 0;
            }

            int codigo = 0;
            if (numero == null)
            {
                return codigo = 1;
            }
            else
            {
                return codigo = codigo + 1;
            }
        }

    }

}
