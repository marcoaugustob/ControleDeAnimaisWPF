using CadastroDeAnimais.Model;
using System.Data.Entity;

namespace CadastroDeAnimais
{
    class AnimalDBContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Especie> Especies { get; set; }

    }
}
