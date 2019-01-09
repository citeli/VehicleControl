namespace ControleVeiculos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Responsaveis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false, maxLength: 50, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 50, unicode: false),
                        ResponsavelId = c.Int(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Responsaveis", t => t.ResponsavelId, cascadeDelete: true)
                .Index(t => t.Placa, unique: true, name: "Index")
                .Index(t => t.ResponsavelId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculos", "ResponsavelId", "dbo.Responsaveis");
            DropForeignKey("dbo.Veiculos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Veiculos", new[] { "CategoriaId" });
            DropIndex("dbo.Veiculos", new[] { "ResponsavelId" });
            DropIndex("dbo.Veiculos", "Index");
            DropTable("dbo.Veiculos");
            DropTable("dbo.Responsaveis");
            DropTable("dbo.Categorias");
        }
    }
}
