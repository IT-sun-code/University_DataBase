using DataBase.Helper;
using DataBase.ViewModel;
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
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        private void OnSelectStudents(object sender, RoutedEventArgs args)
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllStudent();
            }
        }

        private void OnSelectTeachers(object sender, RoutedEventArgs args)
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllTeachers();
            }
        }

        private void OnSelectSubjects(object sender, RoutedEventArgs args)
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllSubjects();
            }
        }

        private void OnSelectGroups(object sender, RoutedEventArgs args)
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllGroups();
            }
        } 
    }
}
