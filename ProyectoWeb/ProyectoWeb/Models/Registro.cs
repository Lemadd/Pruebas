using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class Registro
    {
        //CARRITO
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public String cod_funcion { get; set; }
        public String nom_sala { get; set; }
        public DateTime fecha_registro { get; set; }
        public double total { get; set; }



    }
}