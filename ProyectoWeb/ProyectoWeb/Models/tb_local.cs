using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_local
    {
        [Key]
        public int id_local { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar nombre de local")]
        public String nom_local { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar direccion")]
        public String dir_local { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe ingresar telefono")]
        [RegularExpression("[0-9]{7,}", ErrorMessage = "Ingrese telefono correcto, minimo 7 digitos")]
        public String telefono { get; set; }

        public List<tb_sala> Salas { get; set; }
    }
}