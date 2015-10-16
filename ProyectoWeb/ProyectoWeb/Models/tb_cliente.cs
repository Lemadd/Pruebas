using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class tb_cliente
    {
        [Key]
        public int id_cliente { get; set; }

        public string nombre_cli { get; set; }
        public string correo_cli { get; set; }
        public bool estado { get; set; }

    }
}