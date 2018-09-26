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
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Altura = c.Int(nullable: false),
                        EspecieId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Especies", t => t.EspecieId)
                .Index(t => t.EspecieId);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "EspecieId", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "EspecieId" });
            DropTable("dbo.Especies");
            DropTable("dbo.Animals");
        }
    }
}
