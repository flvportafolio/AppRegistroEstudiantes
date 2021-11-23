namespace AppRegistroEstudiantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHorarioModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Dia = c.String(),
                        HoraInicio = c.String(),
                        HoraFin = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Horario");
        }
    }
}
