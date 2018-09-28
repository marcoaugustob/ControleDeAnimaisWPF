using CadastroDeAnimais.Model;
using CadastroDeAnimais.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace CadastroDeAnimais.View
{
    /// <summary>
    /// Interaction logic for UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        AnimalDBContext _db = new AnimalDBContext();
        int Id;


        public UpdatePage(int animalId)
        {
            InitializeComponent();
            DataContext = new AnimalViewModel();
           
            Id = animalId;

            Animal originalAnimal = _db.Animais.FirstOrDefault(x => x.Id == Id);
            nomeTextBox.Text = originalAnimal.Nome;
            pesoTextBox.Text = originalAnimal.Peso.ToString();
            (DataContext as AnimalViewModel).Especie = originalAnimal.Especie;
            //especieComboBox.Text = originalAnimal.Especie.Nome;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = (especieComboBox.SelectedValue as Especie).Id;
            Animal updateAnimal = _db.Animais.FirstOrDefault(x => x.Id == Id);
            updateAnimal.Nome = nomeTextBox.Text;
            updateAnimal.Peso = Convert.ToDecimal(pesoTextBox.Text);
            updateAnimal.EspecieId = Convert.ToInt32(selected);

            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Animais.ToList();
            this.Hide();
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            nomeTextBox.Text = "";
            pesoTextBox.Text = "";
            especieComboBox.SelectedIndex = -1;
        }
    }
}
