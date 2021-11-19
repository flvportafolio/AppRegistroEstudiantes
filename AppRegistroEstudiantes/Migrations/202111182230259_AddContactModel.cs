namespace AppRegistroEstudiantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(maxLength: 100),
                        Correo = c.String(nullable: false, maxLength: 100),
                        Asunto = c.String(maxLength: 50),
                        Mensaje = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacto");
        }
    }
}
