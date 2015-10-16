using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_genero
    {
        [Key]
        public string cod_genero { get; set; }
        public string descripcion { get; set; }
    }
}