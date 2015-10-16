using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.ModelsDTO
{
    public class CarritoVentaEntradas
    {
        public int id_ven_entrada { get; set; }
        public int id_tipo { get; set; }
        public int cantidad { get; set; }
        public decimal precio_uni { get; set; }
        public string desc_entrada { get; set; }
        public int id_venta { get; set; }
    }
}