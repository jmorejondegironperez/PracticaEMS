namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCursos1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cursos", "NotaCorte", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cursos", "NotaCorte", c => c.Single(nullable: false));
        }
    }
}
