using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_tipo_pelicula
    {
        [Key]
        public String cod_tipo_pelicula { get; set; }
        public String descripcion { get; set; }
    }
}