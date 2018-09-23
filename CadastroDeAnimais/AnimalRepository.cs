using CadastroDeAnimais.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeAnimais
{
    class AnimalRepository
    {
        public List<Especie> GetEspecies()
        {
            AnimalDBContext animalDBContext = new AnimalDBContext();
            return animalDBContext.Especies.ToList();
        }
    }
}
