namespace CadastroDeAnimais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quarta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "EspecieId", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "EspecieId" });
            AlterColumn("dbo.Animals", "EspecieId", c => c.Int(nullable: false));
            CreateIndex("dbo.Animals", "EspecieId");
            AddForeignKey("dbo.Animals", "EspecieId", "dbo.Especies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "EspecieId", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "EspecieId" });
            AlterColumn("dbo.Animals", "EspecieId", c => c.Int());
            CreateIndex("dbo.Animals", "EspecieId");
            AddForeignKey("dbo.Animals", "EspecieId", "dbo.Especies", "Id");
        }
    }
}
