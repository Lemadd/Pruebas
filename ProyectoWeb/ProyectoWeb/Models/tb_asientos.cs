using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoWeb.Models
{
    public class tb_asientos
    {
        [Key]
        public int id_asiento { get; set; }
        public string cod_tipo_sala { get; set; }
        public string letra_asiento { get; set; }
        public int numero_asiento { get; set; }
        public bool estadoDibujo { get; set; }

        public virtual tb_sala Sala { get; set; }
    }
}