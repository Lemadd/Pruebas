using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class dias
    {
        [Key]
        public int id_dia { get; set; }
        public string nombre { get; set; }


    }
}