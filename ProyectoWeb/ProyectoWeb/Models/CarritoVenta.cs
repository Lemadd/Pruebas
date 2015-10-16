using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class CarritoVenta
    {
        [Key]
        public int id_venta { get; set; }
        public int item { get; set; }
        public string asiento { get; set; }
        public string id_tipo_entrada { get; set; }


    }
}