using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWeb.Models
{
    public class tb_venta
    {
        [Key]
        public int id_venta { get; set; }

        public int id_cliente { get; set; }
        public int id_horario_funcion { get; set; }
        public string nom_sala { get; set; }
        public DateTime fecha_registro { get; set; }
        public decimal monto_total { get; set; }
        public bool estado { get; set; }

        public virtual tb_cliente Cliente { get; set; }
        public virtual tb_horario_funcion HorarioFuncion { get; set; }
        public List<tb_venta_deta> DetalleVenta { get; set; }
        public List<tb_entradas_venta> EntradasVenta { get; set; }

    }
}