using DataBase.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBase.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnGetStudents(object sender, RoutedEventArgs args)
        {
            var data = DatabaseHelper.ExecuteCommand("SELECT * FROM brigada0_students", "Students");
            DatabaseTable.ItemsSource = data.Tables["Students"].DefaultView;
        }
    }
}
