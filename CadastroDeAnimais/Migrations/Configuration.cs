namespace CadastroDeAnimais.Migrations
{
    using CadastroDeAnimais.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CadastroDeAnimais.AnimalDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CadastroDeAnimais.AnimalDBContext context)
        {

            context.Especies.AddOrUpdate(x => x.Id,
                new Especie() { Id = 1, Nome = "Felina" },
                new Especie() { Id = 2, Nome = "Canina" },
                new Especie() { Id = 3, Nome = "Aquatica" },
                new Especie() { Id = 4, Nome = "Ave" }
                );

        }
    }
}
