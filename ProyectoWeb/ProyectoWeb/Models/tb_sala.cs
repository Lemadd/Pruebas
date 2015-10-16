using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWeb.Models
{
    public class tb_sala
    {
        [Key]
        public String cod_sala { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese nombre de sala")]
        public String nom_sala { get; set; }
        public String cod_tipo_sala { get; set; }
        public int id_local { get; set; }
        public string tipo_proyeccion { get; set; }
        public bool estado;

        public virtual tb_tipo_sala TipoSala { get; set; }
        public virtual tb_local Local { get; set; }
    }
}