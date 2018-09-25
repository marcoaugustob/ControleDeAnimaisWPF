using CadastroDeAnimais.Model;
using CadastroDeAnimais.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CadastroDeAnimais
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AnimalDBContext _db = new AnimalDBContext();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            MyDataGrid.ItemsSource = _db.Animais.ToList();
            dataGrid = MyDataGrid;
        }

        private void InsertClick(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage();
            Ipage.ShowDialog();
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            int Id = (MyDataGrid.SelectedItem as Animal).Id;
            UpdatePage Upage = new UpdatePage(Id);
            Upage.ShowDialog();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            int Id = (MyDataGrid.SelectedItem as Animal).Id;
            var deleteAnimal = _db.Animais.FirstOrDefault(x => x.Id == Id);
            _db.Animais.Remove(deleteAnimal);
            _db.SaveChanges();
            MyDataGrid.ItemsSource = _db.Animais.ToList();
        }
    }
}
