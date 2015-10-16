using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_peliculas
    {
        [Key]
        public string cod_peli { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        public string nombre_peli { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        public string titulo_origen { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        public string sinopsis { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        public string director { get; set; }
        public string actores { get; set; }
        public string cod_clasificacion_pelicula { get; set; }

        [Required(ErrorMessage = "Por Favor completar el campo")]
        [Range(1, 200, ErrorMessage = "Ingrese una cantidad correcta")]
        public string duracion { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Por Favor completar el campo")]
        public string pais_origen { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime fecha_estreno { get; set; }
        public string cod_genero { get; set; }
        public string cod_tipo_pelicula { get; set; }
        public string cod_estado_pelicula { get; set; }
        public string imagePath { get; set; }
        public string trailer { get; set; }
        public virtual tb_estado_pelicula EstadoPelicula { get; set; }
        public virtual tb_clasificacion_pelicula ClasificacionPelicula { get; set; }
        public virtual tb_tipo_pelicula TipoPelicula { get; set; }
        public virtual tb_genero Generos { get; set; }
        public List<tb_funcion> Funcion { get; set; }
    }
}