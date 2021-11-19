namespace AppRegistroEstudiantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        ApellidoPaterno = c.String(),
                        ApellidoMaterno = c.String(),
                        Genero = c.Int(nullable: false),
                        CI = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        LugarNacimiento = c.String(),
                        Direccion = c.String(),
                        Zona = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beca = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaInscripcion = c.DateTime(nullable: false),
                        Observacion1 = c.String(),
                        Observacion2 = c.String(),
                        EsTraspaso = c.Boolean(nullable: false),
                        EsBecado = c.Boolean(nullable: false),
                        EsRepitente = c.Boolean(nullable: false),
                        Matricula = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        AlumnoID = c.Int(nullable: false),
                        CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Alumno", t => t.AlumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.AlumnoID)
                .Index(t => t.CursoID);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Alumno",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Foto = c.String(nullable: false),
                        Procedencia = c.String(),
                        PadreID = c.Int(nullable: false),
                        MadreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.Tutor", t => t.PadreID)
                .ForeignKey("dbo.Tutor", t => t.MadreID)
                .Index(t => t.Id)
                .Index(t => t.PadreID)
                .Index(t => t.MadreID);
            
            CreateTable(
                "dbo.Tutor",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Ocupacion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tutor", "Id", "dbo.Persona");
            DropForeignKey("dbo.Alumno", "MadreID", "dbo.Tutor");
            DropForeignKey("dbo.Alumno", "PadreID", "dbo.Tutor");
            DropForeignKey("dbo.Alumno", "Id", "dbo.Persona");
            DropForeignKey("dbo.Registro", "CursoID", "dbo.Curso");
            DropForeignKey("dbo.Registro", "AlumnoID", "dbo.Alumno");
            DropIndex("dbo.Tutor", new[] { "Id" });
            DropIndex("dbo.Alumno", new[] { "MadreID" });
            DropIndex("dbo.Alumno", new[] { "PadreID" });
            DropIndex("dbo.Alumno", new[] { "Id" });
            DropIndex("dbo.Registro", new[] { "CursoID" });
            DropIndex("dbo.Registro", new[] { "AlumnoID" });
            DropTable("dbo.Tutor");
            DropTable("dbo.Alumno");
            DropTable("dbo.Curso");
            DropTable("dbo.Registro");
            DropTable("dbo.Persona");
        }
    }
}
