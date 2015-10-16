using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace ProyectoWeb.Models
{
    public class Entities : DbContext
    {
        public DbSet<tb_usuario> Usuarios { get; set; }
        public DbSet<tb_peliculas> Peliculas { get; set; }
        public DbSet<tb_genero> Generos { get; set; }
        public DbSet<tb_funcion> Funcion { get; set; }
        public DbSet<tb_sala> Sala { get; set; }
        public DbSet<tb_tipo_sala> TipoSala { get; set; }
        public DbSet<tb_asientos> Asiento { get; set; }
        public DbSet<tb_local> Local { get; set; }
        public DbSet<tb_estado_pelicula> EstadoPelicula { get; set; }
        public DbSet<tb_clasificacion_pelicula> ClasificacionPelicula { get; set; }
        public DbSet<tb_tipo_pelicula> TipoPelicula { get; set; }
        public DbSet<tb_tipo_entrada> TipoEntrada { get; set; }
        public DbSet<tb_cliente> Cliente { get; set; }
        public DbSet<tb_venta> Venta { get; set; }
        public DbSet<tb_venta_deta> DetalleVenta { get; set; }
        public DbSet<dias> Dias { get; set; }
        public DbSet<tb_horario_funcion> HorariosFuncion { get; set; }
        public DbSet<tb_entradas_venta> DetalleEntradasVenta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}