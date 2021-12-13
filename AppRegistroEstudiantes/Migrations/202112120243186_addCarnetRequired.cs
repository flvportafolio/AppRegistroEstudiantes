namespace AppRegistroEstudiantes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCarnetRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Persona", "CI", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Persona", "CI", c => c.String());
        }
    }
}
