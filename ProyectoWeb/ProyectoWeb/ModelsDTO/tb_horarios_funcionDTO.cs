using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.ModelsDTO
{
    public class tb_horarios_funcionDTO
    {
        public int id_horario_funcion { get; set; }
        public string cod_funcion { get; set; }
        public int id_dia { get; set; }
        public string nombre_dia { get; set; }
        public string hora_inicio { get; set; }
        public string hora_fin { get; set; }
    }
}