using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProyectoWeb.Models
{
    public class tb_tipo_sala
    {
        [Key]
        public String cod_tipo_sala { get; set; }
        public String descripcion { get; set; }
        public int ancho { get; set; }
        public int largo { get; set; }
        public bool estado { get; set; }

        public List<tb_asientos> Asientos { get; set; }
        public List<tb_sala> Salas { get; set; }
    }
}