using CadastroDeAnimais.Model;
using CadastroDeAnimais.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            try
            {
                int Id = (MyDataGrid.SelectedItem as Animal).Id;
                UpdatePage Upage = new UpdatePage(Id);
                Upage.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Não foi possível atualizar!");
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = (MyDataGrid.SelectedItem as Animal).Id;
                var deleteAnimal = _db.Animais.FirstOrDefault(x => x.Id == Id);
                _db.Animais.Remove(deleteAnimal);
                _db.SaveChanges();
                MyDataGrid.ItemsSource = _db.Animais.ToList();
            }
            catch
            {
                MessageBox.Show("Não foi possível deletar");
            }
        }
    }
}
