using AppRegistroEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PracticaWeb1.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            dbModelBuilder.Entity<Persona>().ToTable("Persona");
            dbModelBuilder.Entity<Tutor>().ToTable("Tutor");
            dbModelBuilder.Entity<Alumno>().ToTable("Alumno");

            /*dbModelBuilder.Entity<Alumno>()
               .HasRequired<Tutor>(s => s.Padre)
               .WithMany(g => g.Padre)
               .HasForeignKey<int>(s => s.PadreID);
            dbModelBuilder.Entity<Alumno>()
               .HasRequired<Tutor>(s => s.Madre)
               .WithMany(g => g.Madre)
               .HasForeignKey<int>(s => s.MadreID);*/
        }

        //public DbSet<Alumno> Persona { get; set; }
        public DbSet<Tutor> Tutor { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<Registro> Registro { get; set; }

        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Horario> Horario { get; set; }
    }
}