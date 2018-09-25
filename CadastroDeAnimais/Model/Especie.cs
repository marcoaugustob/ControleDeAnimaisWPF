using System.ComponentModel.DataAnnotations;

namespace CadastroDeAnimais.Model
{
    class Especie
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
