using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoWeb.Models;

namespace ProyectoWeb.ModelsDTO
{
    public class CompraRealizada
    {
        public tb_venta venta { get; set; }
        public List<tb_entradas_venta> entradas_venta { get; set; }
        public List<tb_venta_deta> asientos_venta { get; set; }
    }
}