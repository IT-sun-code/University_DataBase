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

        private void UpdateStudent()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateStudent();
            }
        }

        private void OnSelectStudents(object sender, RoutedEventArgs args)
        {
            SelectStudents();
            OnSelectCommand = new DelegateCommand(SelectStudents, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteStudent, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateStudent, () => true);
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

        private void DeleteTeacher()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteTeacher();
            }
        }

        private void UpdateTeacher()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateTeacher();
            }
        }

        private void OnSelectTeachers(object sender, RoutedEventArgs args)
        {
            SelectTeachers();
            OnSelectCommand = new DelegateCommand(SelectTeachers, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteTeacher, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateTeacher, () => true);
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

        private void DeleteSubject()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteSubject();
            }
        }

        private void UpdateSubject()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateSubject();
            }
        }

        private void OnSelectSubjects(object sender, RoutedEventArgs args)
        {
            SelectSubjects();
            OnSelectCommand = new DelegateCommand(SelectSubjects, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteSubject, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateSubject, () => true);
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

        private void UpdateGroup()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateGroup();
            }
        }

        private void InsertGroup()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertGroup();
            }
        }

        private void OnSelectGroups(object sender, RoutedEventArgs args)
        {
            SelectGroups();
            OnSelectCommand = new DelegateCommand(SelectGroups, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteGroup, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateGroup, () => true);
            OnInsertCommand = new DelegateCommand(InsertGroup, () => true);
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

        private void UpdateMark()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateMark();
            }
        }

        private void OnSelectMarks(object sender, RoutedEventArgs args)
        {
            SelectMarks();
            OnSelectCommand = new DelegateCommand(SelectMarks, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteMark, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateMark, () => true);
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

        private void DeleteTeacherSubjects()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.DeleteTeacherSubject();
            }
        }

        private void UpdateTeacherSubjects()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.UpdateTeacherSubject();
            }
        }

        private void OnSelectTeacherSubjects(object sender, RoutedEventArgs args)
        {
            SelectTeacherSubjects();
            OnSelectCommand = new DelegateCommand(SelectTeacherSubjects, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteTeacherSubjects, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateTeacherSubjects, () => true);
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
