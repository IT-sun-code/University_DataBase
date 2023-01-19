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
        #region - Public Bindings -

        #region - Teacher -
        private string teacherID = "";
        public string TeacherID
        {
            get => teacherID.ToString();
            set
            {
                teacherID = value;
                OnPropertyChanged(nameof(TeacherID));
            }
        }

        private string teacherFirstName = "";
        public string TeacherFirstName
        {
            get => teacherFirstName;
            set
            {
                teacherFirstName = value;
                OnPropertyChanged(nameof(TeacherFirstName));
            }
        }

        private string teacherLastName = "";
        public string TeacherLastName
        {
            get => teacherLastName;
            set
            {
                teacherLastName = value;
                OnPropertyChanged(nameof(TeacherLastName));
            }
        }
        #endregion

        #region - Group -
        private string groupID = "";
        public string GroupID
        {
            get => groupID;
            set
            {
                groupID = value;
                OnPropertyChanged(nameof(GroupID));
            }
        }

        private string groupName = "";
        public string GroupName
        {
            get => groupName;
            set
            {
                groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }
        #endregion

        #region - Subject -
        private string subjectID = "";
        public string SubjectID
        {
            get => subjectID;
            set
            {
                subjectID = value;
                OnPropertyChanged(nameof(SubjectID));
            }
        }

        private string subjectTitle = "";
        public string SubjectTitle
        {
            get => subjectTitle;
            set
            {
                subjectTitle = value;
                OnPropertyChanged(nameof(SubjectTitle));
            }
        }
        #endregion

        #region - Teacher Subjects -
        private string subTeacherID = "";
        public string SubTeacherID
        {
            get => subTeacherID;
            set
            {
                subTeacherID = value;
                OnPropertyChanged(nameof(SubTeacherID));
            }
        }

        private string teachSubjectID = "";
        public string TeachSubjectID
        {
            get => teachSubjectID;
            set
            {
                teachSubjectID = value;
                OnPropertyChanged(nameof(TeachSubjectID));
            }
        }
        #endregion

        #region - Student -
        private string studentID = "";
        public string StudentID
        {
            get => studentID;
            set
            {
                studentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        private string studentFirstName = "";
        public string StudentFirstName
        {
            get => studentFirstName;
            set
            {
                studentFirstName = value;
                OnPropertyChanged(nameof(StudentFirstName));
            }
        }

        private string studentLastName = "";
        public string StudentLastName
        {
            get => studentLastName;
            set
            {
                studentLastName = value;
                OnPropertyChanged(nameof(StudentLastName));
            }
        }

        private string studentGroupID = "";
        public string StudentGroupID
        {
            get => studentGroupID;
            set
            {
                studentGroupID = value;
                OnPropertyChanged(nameof(StudentGroupID));
            }
        }
        #endregion

        #region - Mark -
        private string markID = "";
        public string MarkID
        {
            get => markID;
            set
            {
                markID = value;
                OnPropertyChanged(nameof(MarkID));
            }
        }

        private string markStudentID = "";
        public string MarkStudentID
        {
            get => markStudentID;
            set
            {
                markStudentID = value;
                OnPropertyChanged(nameof(MarkStudentID));
            }
        }

        private string markSubjectID = "";
        public string MarkSubjectID
        {
            get => markSubjectID;
            set
            {
                markSubjectID = value;
                OnPropertyChanged(nameof(MarkSubjectID));
            }
        }

        private string markDate = "";
        public string MarkDate
        {
            get => markDate;
            set
            {
                markDate = value;
                OnPropertyChanged(nameof(MarkDate));
            }
        }

        private string markValue = "";
        public string MarkValue
        {
            get => markValue;
            set
            {
                markValue = value;
                OnPropertyChanged(nameof(MarkValue));
            }
        }
        #endregion

        #endregion

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
            string sql = @"SELECT brigada0_sub_teach.SUBJECT_ID, brigada0_subjects.TITLE, brigada0_sub_teach.TEACHER_ID, brigada0_teachers.FIRST_NAME, brigada0_teachers.LAST_NAME
                            FROM brigada0_sub_teach 
                            INNER JOIN brigada0_teachers ON brigada0_teachers.TEACHER_ID = brigada0_sub_teach.TEACHER_ID
                            INNER JOIN brigada0_subjects ON brigada0_subjects.SUBJECT_ID = brigada0_sub_teach.SUBJECT_ID";
            var data = DatabaseHelper.ExecuteCommand(sql, "Teacher Subjects");
            return data.Tables["Teacher Subjects"].DefaultView;
        }
        #endregion

        #region - Delete - Database Commands -

        public DataView DeleteGroup()
        {
            if(GroupID == "")
                throw new Exception("Empty GroupID value");
            Convert.ToInt64(GroupID);

            // 1. Get Students With Current GroupID
            string sql = @"SELECT STUDENT_ID FROM brigada0_students WHERE GROUP_ID = " + GroupID;
            var data = DatabaseHelper.ExecuteCommand(sql, "Students");
            var tempView = data.Tables["Students"].DefaultView;

            // 2. Delete students with current group
            foreach(var item in tempView)
            {
                var stId = item as DataRowView;
                string id = stId.Row[0].ToString();
                DeleteMarkByCondition("brigada0_marks.STUDENT_ID = " + id);
            }

            // 3. Delete students
            DeleteStudentByCondition("brigada0_students.GROUP_ID = " + GroupID);
            // 4. Delete Group
            DeleteGroupByCondition("brigada0_groups.GROUP_ID = " + GroupID);

            return SelectAllGroups();
        }

        public DataView DeleteStudent()
        {
            if (StudentID == "")
                throw new Exception("Empty StudentID value");
            Convert.ToInt64(StudentID);

            DeleteMarkByCondition("brigada0_marks.STUDENT_ID = " + StudentID);
            DeleteStudentByCondition("brigada0_students.STUDENT_ID = " + StudentID);

            return SelectAllStudent();
        }

        public DataView DeleteMark()
        {
            if (MarkID == "")
                throw new Exception("Empty MarkID value");
            Convert.ToInt64(MarkID);

            DeleteMarkByCondition("brigada0_marks.MARK_ID = " + MarkID);

            return SelectAllMarks();
        }

        public void DeleteMarkByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_marks WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        public void DeleteStudentByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_students WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        public void DeleteGroupByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_groups WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        #endregion

        #region - Update - Database Commands -

        #endregion

        #region - Insert - Database Commands -

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
