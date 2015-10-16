using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWeb.Models
{
    public class tb_clasificacion_pelicula
    {
        [Key]
        public String cod_clasificacion_pelicula { get; set; }
        public String descripcion { get; set; }
    }
}