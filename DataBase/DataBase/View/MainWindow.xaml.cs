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


        private DelegateCommand OnSelectByConditionCommand { get; set; } = null;
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

        private void SelectStudentByCondition()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectStudentByCondition();
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

        private void InsertStudent()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertStudent();
            }
        }

        private void OnSelectStudents(object sender, RoutedEventArgs args)
        {
            SelectStudents();
            OnSelectCommand = new DelegateCommand(SelectStudents, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteStudent, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateStudent, () => true);
            OnInsertCommand = new DelegateCommand(InsertStudent, () => true);
            OnSelectByConditionCommand = new DelegateCommand(SelectStudentByCondition, () => true);
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

        private void SelectTeacherByCondition()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectTeacherByCondition();
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

        private void InsertTeacher()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertTeacher();
            }
        }

        private void OnSelectTeachers(object sender, RoutedEventArgs args)
        {
            SelectTeachers();
            OnSelectCommand = new DelegateCommand(SelectTeachers, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteTeacher, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateTeacher, () => true);
            OnInsertCommand = new DelegateCommand(InsertTeacher, () => true);
            OnSelectByConditionCommand = new DelegateCommand(SelectTeacherByCondition, () => true);
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

        private void SelectSubjectByCondition()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectSubjectByCondition();
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

        private void InsertSubject()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertSubject();
            }
        }

        private void OnSelectSubjects(object sender, RoutedEventArgs args)
        {
            SelectSubjects();
            OnSelectCommand = new DelegateCommand(SelectSubjects, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteSubject, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateSubject, () => true);
            OnInsertCommand = new DelegateCommand(InsertSubject, () => true);
            OnSelectByConditionCommand = new DelegateCommand(SelectSubjectByCondition, () => true);
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

        private void SelectGroupByCondition()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectGroupByCondition();
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
            OnSelectByConditionCommand = new DelegateCommand(SelectGroupByCondition, () => true);
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

        private void SelectMarkByCondition()
        {
            if(DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectMarkByCondition();
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

        private void InsertMark()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertMark();
            }
        }

        private void OnSelectMarks(object sender, RoutedEventArgs args)
        {
            SelectMarks();
            OnSelectCommand = new DelegateCommand(SelectMarks, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteMark, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateMark, () => true);
            OnInsertCommand = new DelegateCommand(InsertMark, () => true);
            OnSelectByConditionCommand = new DelegateCommand(SelectMarkByCondition, () => true);
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

        private void SelectTeacherSubjectsByCondition()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.SelectTeacherSubjectsByCondition();
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

        private void InsertTeacherSubjects()
        {
            if (DataContext != null)
            {
                var mainWndViewModel = DataContext as MainWindowViewModel;
                DatabaseTable.ItemsSource = mainWndViewModel.InsertTeacherSubject();
            }
        }

        private void OnSelectTeacherSubjects(object sender, RoutedEventArgs args)
        {
            SelectTeacherSubjects();
            OnSelectCommand = new DelegateCommand(SelectTeacherSubjects, () => true);
            OnDeleteCommand = new DelegateCommand(DeleteTeacherSubjects, () => true);
            OnUpdateCommand = new DelegateCommand(UpdateTeacherSubjects, () => true);
            OnInsertCommand = new DelegateCommand(InsertTeacherSubjects, () => true);
            OnSelectByConditionCommand = new DelegateCommand(SelectTeacherSubjectsByCondition, () => true);
        }
        #endregion

        #region - Buttons Commands -
        private void OnSelect(object sender, RoutedEventArgs args) =>
            OnSelectCommand?.Execute();

        private void OnSelectByCondition(object sender, RoutedEventArgs args) =>
            OnSelectByConditionCommand?.Execute();

        private void OnDelete(object sender, RoutedEventArgs args) =>
            OnDeleteCommand?.Execute();

        private void OnUpdate(object sender, RoutedEventArgs args) =>
            OnUpdateCommand?.Execute();

        private void OnInsert(object sender, RoutedEventArgs args) =>
            OnInsertCommand?.Execute();
        #endregion
    }
}
