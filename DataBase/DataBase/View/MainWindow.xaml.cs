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
        #region - Delegate Commands -
        private DelegateCommand OnSelectCommand { get; set; } = null;
        private DelegateCommand OnDeleteCommand { get; set; } = null;
        private DelegateCommand OnUpdateCommand { get; set; } = null;
        private DelegateCommand OnInsertCommand { get; set; } = null;
        #endregion

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

        private void DeleteStudent()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteStudent();
            }
        }

        private void OnSelectStudents(object sender, RoutedEventArgs args)
        {
            SelectStudents();
            OnSelectCommand = new DelegateCommand(SelectStudents, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteStudent, () => true);
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

        private void DeleteGroup()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteGroup();
            }
        }

        private void OnSelectGroups(object sender, RoutedEventArgs args)
        {
            SelectGroups();
            OnSelectCommand = new DelegateCommand(SelectGroups, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteGroup, () => true);
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

        private void DeleteMark()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteMark();
            }
        }

        private void OnSelectMarks(object sender, RoutedEventArgs args)
        {
            SelectMarks();
            OnSelectCommand = new DelegateCommand(SelectMarks, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteMark, () => true);
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

        private void OnDelete(object sender, RoutedEventArgs args) =>
            OnDeleteCommand?.Execute();

        private void OnUpdate(object sender, RoutedEventArgs args) =>
            OnUpdateCommand?.Execute();

        private void OnInsert(object sender, RoutedEventArgs args) =>
            OnInsertCommand?.Execute();
        #endregion
    }
}
