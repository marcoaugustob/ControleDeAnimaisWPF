using CadastroDeAnimais.Model;
using CadastroDeAnimais.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CadastroDeAnimais
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        AnimalDBContext _db = new AnimalDBContext();

        public InsertPage()
        {
            InitializeComponent();
            DataContext = new AnimalViewModel();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            Animal newAnimal = new Animal()
            {
                Nome = nomeTextBox.Text,
                Peso = Convert.ToDecimal(pesoTextBox.Text),
                EspecieId = 2
            };
            _db.Animais.Add(newAnimal);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Animais.ToList();
            this.Hide();
        }

      
    }
}
