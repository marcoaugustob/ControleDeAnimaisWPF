using System.ComponentModel.DataAnnotations;

namespace CadastroDeAnimais.Model
{
    class Animal
    {
        public int Id { get; set; }
        [Key]
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public int? EspecieId { get; set; }

        public virtual Especie Especie { get; set; }
    }
}
