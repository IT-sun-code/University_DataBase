using DataBase.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace DataBase.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel() { }

        #region - Select - Database Commands -
        public DataView SelectAllStudent()
        {
            string sql = @"SELECT STUDENT_ID, FIRST_NAME, LAST_NAME, brigada0_groups.NAME FROM brigada0_students 
                            INNER JOIN brigada0_groups ON brigada0_groups.GROUP_ID = brigada0_students.GROUP_ID";
            var data = DatabaseHelper.ExecuteCommand(sql, "Students");
            return data.Tables["Students"].DefaultView;
        } 

        public DataView SelectAllTeachers()
        {
            string sql = @"SELECT * FROM brigada0_teachers";
            var data = DatabaseHelper.ExecuteCommand(sql, "Teachers");
            return data.Tables["Teachers"].DefaultView;
        }

        public DataView SelectAllGroups()
        {
            string sql = @"SELECT * FROM brigada0_groups";
            var data = DatabaseHelper.ExecuteCommand(sql, "Groups");
            return data.Tables["Groups"].DefaultView;
        }

        public DataView SelectAllSubjects()
        {
            string sql = @"SELECT * FROM brigada0_subjects";
            var data = DatabaseHelper.ExecuteCommand(sql, "Subjects");
            return data.Tables["Subjects"].DefaultView;
        }

        public DataView SelectAllMarks()
        {
            string sql = @"SELECT MARK_ID, brigada0_students.FIRST_NAME, brigada0_students.LAST_NAME, brigada0_subjects.TITLE, MARK_DATE, MARK
                            FROM brigada0_marks 
                            INNER JOIN brigada0_students ON brigada0_students.STUDENT_ID = brigada0_marks.STUDENT_ID
                            INNER JOIN brigada0_subjects ON brigada0_subjects.SUBJECT_ID = brigada0_marks.SUBJECT_ID";
            var data = DatabaseHelper.ExecuteCommand(sql, "Marks");
            return data.Tables["Marks"].DefaultView;
        }

        public DataView SelectAllTeacherSubjects()
        {
            string sql = @"SELECT brigada0_subjects.TITLE, brigada0_teachers.FIRST_NAME, brigada0_teachers.LAST_NAME
                            FROM brigada0_sub_teach 
                            INNER JOIN brigada0_teachers ON brigada0_teachers.TEACHER_ID = brigada0_sub_teach.TEACHER_ID
                            INNER JOIN brigada0_subjects ON brigada0_subjects.SUBJECT_ID = brigada0_sub_teach.SUBJECT_ID";
            var data = DatabaseHelper.ExecuteCommand(sql, "Teacher Subjects");
            return data.Tables["Teacher Subjects"].DefaultView;
        }
        #endregion

        #region - On Property Changed -
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
