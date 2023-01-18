using DataBase.Helper;
using DataBase.ViewModel;
using Prism.Commands;
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
        private DelegateCommand OnSelectCommand { get; set; } = null;

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }

        #region - Students -
        private void SelectStudents()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllStudent();
            }
        }

        private void OnSelectStudents(object sender, RoutedEventArgs args)
        {
            SelectStudents();
            OnSelectCommand = new DelegateCommand(SelectStudents, () => true);
        }
        #endregion

        #region - Teachers -
        private void SelectTeachers()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllTeachers();
            }
        }

        private void OnSelectTeachers(object sender, RoutedEventArgs args)
        {
            SelectTeachers();
            OnSelectCommand = new DelegateCommand(SelectTeachers, () => true);
        }
        #endregion

        #region - Subjects -
        private void SelectSubjects()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllSubjects();
            }
        }

        private void OnSelectSubjects(object sender, RoutedEventArgs args)
        {
            SelectSubjects();
            OnSelectCommand = new DelegateCommand(SelectSubjects, () => true);
        }
        #endregion

        #region - Groups -
        private void SelectGroups()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllGroups();
            }
        }

        private void OnSelectGroups(object sender, RoutedEventArgs args)
        {
            SelectGroups();
            OnSelectCommand = new DelegateCommand(SelectGroups, () => true);
        }
        #endregion

        #region - Marks -
        private void SelectMarks()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllMarks();
            }
        }

        private void OnSelectMarks(object sender, RoutedEventArgs args)
        {
            SelectMarks();
            OnSelectCommand = new DelegateCommand(SelectMarks, () => true);
        }
        #endregion

        #region - Teacher Subjects -
        private void SelectTeacherSubjects()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectAllTeacherSubjects();
            }
        }

        private void OnSelectTeacherSubjects(object sender, RoutedEventArgs args)
        {
            SelectTeacherSubjects();
            OnSelectCommand = new DelegateCommand(SelectTeacherSubjects, () => true);
        }
        #endregion

        #region - Buttons Commands -
        private void OnSelect(object sender, RoutedEventArgs args) =>
            OnSelectCommand?.Execute();
        #endregion
    }
}
