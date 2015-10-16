using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class tb_horario_funcion
    {
        [Key]
        public int id_horario_funcion { get; set; }
        public string cod_funcion { get; set; }
        public int id_dia { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }

        public virtual tb_funcion Funcion { get; set; }
        public List<tb_venta> Ventas { get; set; }
    }
}