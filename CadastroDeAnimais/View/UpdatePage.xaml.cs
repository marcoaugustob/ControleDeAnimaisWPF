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
            especieComboBox.SelectedValue = originalAnimal.EspecieId.ToString();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal updateAnimal = _db.Animais.FirstOrDefault(x => x.Id == Id);
            updateAnimal.Nome = nomeTextBox.Text;
            updateAnimal.Peso = Convert.ToDecimal(pesoTextBox.Text);
            updateAnimal.EspecieId = 2;


            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Animais.ToList();
            this.Hide();
        }
    }
}
