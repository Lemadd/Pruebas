using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWeb.Models
{
    public class tb_funcion
    {
        [Key]
        public String cod_funcion { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_inicio { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_fin { get; set; }
        public string cod_estado_pelicula { get; set; }
        public String cod_peli { get; set; }
        public String cod_sala { get; set; }

        public virtual tb_peliculas Peliculas { get; set; }
        public virtual tb_sala Sala { get; set; }
        public virtual tb_estado_pelicula EstadoPelicula { get; set; }

        public List<tb_horario_funcion> HorariosFuncion { get; set; }
    }
}