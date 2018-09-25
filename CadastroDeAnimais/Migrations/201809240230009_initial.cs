namespace CadastroDeAnimais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altura = c.Int(nullable: false),
                        EspecieId = c.Int(),
                        Especie_Nome = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Nome)
                .ForeignKey("dbo.Especies", t => t.Especie_Nome)
                .Index(t => t.Especie_Nome);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        Nome = c.String(nullable: false, maxLength: 128),
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Nome);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "Especie_Nome", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "Especie_Nome" });
            DropTable("dbo.Especies");
            DropTable("dbo.Animals");
        }
    }
}
