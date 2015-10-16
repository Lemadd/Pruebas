using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWeb.Models
{
    public class tb_venta_deta
    {
        [Key]
        [Column(Order = 0)]
        public int id_venta { get; set; }

        [Key]
        [Column(Order = 1)]
        public int item { get; set; }
        public string asiento { get; set; }

        public virtual tb_venta Venta { get; set; }
    }
}