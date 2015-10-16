using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class tb_tipo_entrada
    {
        [Key]
        public int id_entrada { get; set; }
        public string descripcion { get; set; }
        public decimal costo_ent { get; set; }
        public bool estado { get; set; }

        public List<tb_entradas_venta> DetalleVentaEntrada { get; set; }

    }
}