namespace CadastroDeAnimais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdPrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Animals", "Especie_Nome", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "Especie_Nome" });
            DropColumn("dbo.Animals", "EspecieId");
            RenameColumn(table: "dbo.Animals", name: "Especie_Nome", newName: "EspecieId");
            DropPrimaryKey("dbo.Animals");
            DropPrimaryKey("dbo.Especies");
            AlterColumn("dbo.Animals", "Nome", c => c.String());
            AlterColumn("dbo.Animals", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Animals", "EspecieId", c => c.Int());
            AlterColumn("dbo.Especies", "Nome", c => c.String());
            AlterColumn("dbo.Especies", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Animals", "Id");
            AddPrimaryKey("dbo.Especies", "Id");
            CreateIndex("dbo.Animals", "EspecieId");
            AddForeignKey("dbo.Animals", "EspecieId", "dbo.Especies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "EspecieId", "dbo.Especies");
            DropIndex("dbo.Animals", new[] { "EspecieId" });
            DropPrimaryKey("dbo.Especies");
            DropPrimaryKey("dbo.Animals");
            AlterColumn("dbo.Especies", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Especies", "Nome", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Animals", "EspecieId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Animals", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Animals", "Nome", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Especies", "Nome");
            AddPrimaryKey("dbo.Animals", "Nome");
            RenameColumn(table: "dbo.Animals", name: "EspecieId", newName: "Especie_Nome");
            AddColumn("dbo.Animals", "EspecieId", c => c.Int());
            CreateIndex("dbo.Animals", "Especie_Nome");
            AddForeignKey("dbo.Animals", "Especie_Nome", "dbo.Especies", "Nome");
        }
    }
}
