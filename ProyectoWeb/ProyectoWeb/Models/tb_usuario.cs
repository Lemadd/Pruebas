using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_usuario
    {
        [Key]
        public string dni { get; set; }
        public string clave { get; set; }
        public DateTime ultima_fecha_ingreso { get; set; }
    }
}