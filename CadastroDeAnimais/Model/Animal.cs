using System.ComponentModel.DataAnnotations;

namespace CadastroDeAnimais.Model
{
    class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public int Altura { get; set; }
        public int? EspecieId { get; set; }

        public virtual Especie Especie { get; set; }
    }
}
