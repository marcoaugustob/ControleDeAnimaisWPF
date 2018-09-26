namespace CadastroDeAnimais.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Animals", "Altura");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "Altura", c => c.Int(nullable: false));
        }
    }
}
