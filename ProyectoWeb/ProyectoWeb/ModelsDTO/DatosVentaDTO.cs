using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoWeb.ModelsDTO
{
    public class DatosVentaDTO
    {
        public int id_horario_funcion { get; set; }
        public string nom_sala { get; set; }
        public decimal monto_total { get; set; }

        public List<Entrada> listaEntradas { get; set; }
        public List<Asiento> listaAsientos { get; set; }
    }
}