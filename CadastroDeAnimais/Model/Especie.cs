using System.ComponentModel.DataAnnotations;

namespace CadastroDeAnimais.Model
{
   public class Especie
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
