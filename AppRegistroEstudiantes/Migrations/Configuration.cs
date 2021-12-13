namespace AppRegistroEstudiantes.Migrations
{
    using AppRegistroEstudiantes.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;

    internal sealed class Configuration : DbMigrationsConfiguration<PracticaWeb1.Context.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        /*protected override void Seed(PracticaWeb1.Context.SchoolContext context)
        {
            List<Curso> cursos = new List<Curso>
            {
                new Curso { Nombre = "1ro Primaria.", Descripcion = "ninguna" },
                new Curso { Nombre = "2do Primaria.", Descripcion = "ninguna" },
                new Curso { Nombre = "3ro Primaria.", Descripcion = "ninguna" },
                new Curso { Nombre = "4to Primaria.", Descripcion = "ninguna" },
                new Curso { Nombre = "5to Primaria.", Descripcion = "ninguna" },            
            };
            cursos.ForEach(item => context.Curso.AddOrUpdate(item));
            context.SaveChanges();

            Tutor padre1 = new Tutor {
                Nombre = "Juan",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Soliz",
                Genero = Tutor.TipoGenero.Hombre,
                CI = "2233445",
                FechaNacimiento = DateTime.Today,
                LugarNacimiento = "Tarija",
                Direccion = "Av landivar 123",
                Zona = "Centro",
                Telefono = "70000111",
                Ocupacion = "Abogado"
            };
            Tutor madre1 = new Tutor {
                Nombre = "Carla",
                ApellidoPaterno = "Gomez",
                ApellidoMaterno = "Rivera",
                Genero = Tutor.TipoGenero.Mujer,
                CI = "2200111",
                FechaNacimiento = DateTime.Today,
                LugarNacimiento = "Tarija",
                Direccion = "Av landivar 123",
                Zona = "Centro",
                Telefono = "70000222",
                Ocupacion = "Enfermera"
            };
            context.Tutor.AddOrUpdate(padre1, madre1);
            context.SaveChanges();

            Alumno student_1 = new Alumno {
                Nombre = "Carlos",
                ApellidoPaterno = "Perez",
                ApellidoMaterno = "Gomez",
                Genero = Alumno.TipoGenero.Hombre,
                CI = "1100678",
                FechaNacimiento = DateTime.Today,
                LugarNacimiento = "Tarija",
                Direccion = "Av landivar 123",
                Zona = "Centro",
                Telefono = "76543210",
                Foto = "Profile.png",
                Procedencia = "Colegio La Salle",
                PadreID = 1,
                MadreID = 2,
            };
            context.Alumno.AddOrUpdate(student_1);
            context.SaveChanges();
            File.Copy(
               @"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\ProfileTest.png",
               @"C:\Users\FABIOPC\Documents\Visual Studio 2019\Proyectos\AppRegistroEstudiantes\AppRegistroEstudiantes\Content\Images\Profile.png", 
                true
            );

            Registro registro_1 = new Registro {
                Beca = 0,
                FechaInscripcion = DateTime.Today,
                Observacion1 = "ninguna",
                Observacion2 = "ninguna",
                EsTraspaso = false,
                EsBecado = false,
                EsRepitente = false,
                Matricula = 1100,
                Estado = true,
                AlumnoID = 3,
                CursoID = 1,
            };
            context.Registro.AddOrUpdate(registro_1);
            context.SaveChanges();
        }*/
    }
}
