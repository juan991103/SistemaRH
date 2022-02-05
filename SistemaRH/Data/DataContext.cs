using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaRH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaRH.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Competencia> gestion_competencia { get; set; }
        public DbSet<Idioma> gestion_idiomas { get; set; }
        public DbSet<Capacitacion> gestion_capacitacion { get; set; }
        public DbSet<Puestos> gestion_puestos { get; set; }
        public DbSet<Candidatos> gestion_candidatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
