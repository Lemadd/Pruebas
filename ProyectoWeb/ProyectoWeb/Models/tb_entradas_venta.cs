using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class tb_entradas_venta
    {
        [Key]
        public int id_ent_venta { get; set; }
        public int id_venta { get; set; }
        public int id_entrada { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public decimal subtotal { get; set; }


        public virtual tb_venta Venta { get; set; }
        public virtual tb_tipo_entrada Entrada { get; set; }
    }
}