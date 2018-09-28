using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroDeAnimais.Model
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public int EspecieId { get; set; }

        [ForeignKey("EspecieId")]
        public virtual Especie Especie { get; set; }
    }
}
