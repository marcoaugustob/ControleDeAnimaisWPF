using CadastroDeAnimais.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CadastroDeAnimais.ViewModel
{
    class AnimalViewModel : INotifyPropertyChanged
    {

        #region Propriedades

        private ObservableCollection<Especie> _listEspecies;
        AnimalRepository animalRepos = new AnimalRepository();


        public ObservableCollection<Especie> ListEspecies
        {
            get { return _listEspecies; }

            set
            {
                _listEspecies = value;
                this.NotifyPropertyChanged("ListEspecies");
            }
        }

        private Especie _especie;

        public Especie Especie
        {
            get { return _especie; }
            set
            {
                if (value != _especie)
                {
                    _especie = value;
                    //Notificar alteração da propriedade
                    this.NotifyPropertyChanged("Especie");
                }

            }
        }
        #endregion


        #region Construtor

        public AnimalViewModel()
        {
            this.Initialize();
        }

        #endregion


        private void Initialize()
        {
            this._listEspecies = new ObservableCollection<Especie>();

            //Monta a lista de estados
            var list = animalRepos.GetEspecies();
            foreach (Especie element in list)
            {
                _listEspecies.Add(element);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
