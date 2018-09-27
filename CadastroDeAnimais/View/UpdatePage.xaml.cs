using CadastroDeAnimais.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            updateAnimal.EspecieId = Convert.ToInt32(especieComboBox.Text);


            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Animais.ToList();
            this.Hide();
        }
    }
}
