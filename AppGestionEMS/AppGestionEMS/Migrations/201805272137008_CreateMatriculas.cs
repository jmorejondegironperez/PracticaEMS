namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatriculas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.String(),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        GrupoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId)
                .Index(t => t.GrupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "GrupoId", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "GrupoId" });
            DropIndex("dbo.Matriculas", new[] { "UserId" });
            DropIndex("dbo.Matriculas", new[] { "CursoId" });
            DropTable("dbo.Matriculas");
        }
    }
}
