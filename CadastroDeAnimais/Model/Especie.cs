using System.ComponentModel.DataAnnotations;

namespace CadastroDeAnimais.Model
{
    class Especie
    {
        public int Id { get; set; }
        [Key]
        public string Nome { get; set; }
    }
}
