using DataBase.Helper;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DataBase.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region - Helpers -
        private Regex dateRegex = new Regex(@"\d{2}-\d{2}-\d{4}");
        #endregion

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

        private string newSubTeacherID = "";
        public string NewSubTeacherID
        {
            get => newSubTeacherID;
            set
            {
                newSubTeacherID = value;
                OnPropertyChanged(nameof(NewSubTeacherID));
            }
        }

        private string newTeachSubjectID = "";
        public string NewTeachSubjectID
        {
            get => newTeachSubjectID;
            set
            {
                newTeachSubjectID = value;
                OnPropertyChanged(nameof(NewTeachSubjectID));
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

        public DataView DeleteTeacher()
        {
            if (TeacherID == "")
                throw new Exception("Empty TeacherID value");
            Convert.ToInt64(TeacherID);

            DeleteSubTeachByCondition("brigada0_sub_teach.TEACHER_ID = " + TeacherID);
            DeleteTeacherByCondition("brigada0_teachers.TEACHER_ID = " + TeacherID);

            return SelectAllTeachers();
        }

        public DataView DeleteTeacherSubject()
        {
            if (SubTeacherID == "" || TeachSubjectID == "")
                throw new Exception("Empty SubjectID/TeacherID value");
            Convert.ToInt64(SubTeacherID);
            Convert.ToInt64(TeachSubjectID);

            DeleteSubTeachByCondition("brigada0_sub_teach.SUBJECT_ID = " + TeachSubjectID +
                " AND brigada0_sub_teach.TEACHER_ID = " + subTeacherID);

            return SelectAllTeacherSubjects();
        }

        public DataView DeleteSubject()
        {
            if (SubjectID == "")
                throw new Exception("Empty SubjectID value");
            Convert.ToInt64(SubjectID);

            DeleteMarkByCondition("brigada0_marks.SUBJECT_ID = " + SubjectID);
            DeleteSubTeachByCondition("brigada0_sub_teach.SUBJECT_ID = " + SubjectID);
            DeleteSubjectByCondition("brigada0_subjects.SUBJECT_ID = " + SubjectID);

            return SelectAllSubjects();
        }

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

        public void DeleteSubTeachByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_sub_teach WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        public void DeleteSubjectByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_subjects WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        public void DeleteTeacherByCondition(string condition)
        {
            string sql = @"DELETE FROM brigada0_teachers WHERE " + condition;
            DatabaseHelper.ExecuteCommand(sql);
        }

        #endregion

        #region - Update - Database Commands -
        public DataView UpdateGroup()
        {
            if (GroupID == "" || GroupName == "")
                throw new Exception("Empty GroupID/GroupName value");
            Convert.ToInt64(GroupID);

            string sql = @"UPDATE brigada0_groups SET NAME = '" + GroupName + "' WHERE GROUP_ID = " + GroupID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllGroups();
        }

        public DataView UpdateStudent()
        {
            if (StudentID == "" || StudentFirstName == "" || StudentLastName == "" || StudentGroupID == "")
                throw new Exception("Empty StudentID/FirstName/LastName/GroupID value");
            Convert.ToInt64(StudentID);
            Convert.ToInt64(StudentGroupID);

            string sql = @"UPDATE brigada0_students SET FIRST_NAME = '" + StudentFirstName + 
                "', LAST_NAME = '" + StudentLastName + "', GROUP_ID = " + StudentGroupID + 
                " WHERE STUDENT_ID = " + StudentID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllStudent();
        }

        public DataView UpdateMark()
        {
            if (MarkID == "" || MarkStudentID == "" || MarkSubjectID == "" || MarkDate == "" || MarkValue == "")
                throw new Exception("Empty MarkID/StudentID/SubjectID/Date/Mark value");
            Convert.ToInt64(MarkID);
            Convert.ToInt64(MarkStudentID);
            Convert.ToInt64(MarkSubjectID);
            int mark = Convert.ToInt32(MarkValue);

            var match = dateRegex.Match(MarkDate);
            if (!match.Success)
                throw new Exception("Incorrect Date format (dd-mm-yyyy)");
            else
                DateTime.ParseExact(match.Value, "dd-mm-yyyy", CultureInfo.InvariantCulture);

            if (!(mark <= 5 && mark >= 1))
                throw new Exception("Incorrect Mark value (from 1 t 5)");

            string sql = @"UPDATE brigada0_marks SET STUDENT_ID = " + MarkStudentID +
                ", SUBJECT_ID = " + MarkSubjectID + ", MARK_DATE = TO_DATE('" + MarkDate + "', 'DD-MM-YYYY')" +
                ", MARK = " + MarkValue + " WHERE MARK_ID = "  + MarkID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllMarks();
        }

        public DataView UpdateSubject()
        {
            if (SubjectID == "" || SubjectTitle == "")
                throw new Exception("Empty SubjectID/Title value");
            Convert.ToInt64(SubjectID);

            string sql = @"UPDATE brigada0_subjects SET TITLE = '" + SubjectTitle + "' WHERE SUBJECT_ID = " + SubjectID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllSubjects(); 
        }

        public DataView UpdateTeacherSubject()
        {
            if (SubTeacherID == "" || TeachSubjectID == "" || NewSubTeacherID == "" || NewTeachSubjectID == "")
                throw new Exception("Empty SubjectID/TeacherID value");
            Convert.ToInt64(SubTeacherID);
            Convert.ToInt64(TeachSubjectID);
            Convert.ToInt64(NewSubTeacherID);
            Convert.ToInt64(NewTeachSubjectID);

            string sql = @"UPDATE brigada0_sub_teach SET SUBJECT_ID = " + NewTeachSubjectID + ", TEACHER_ID = " + NewSubTeacherID + 
                " WHERE TEACHER_ID = " + SubTeacherID + " AND SUBJECT_ID = " + TeachSubjectID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllTeacherSubjects();
        }

        public DataView UpdateTeacher()
        {
            if (TeacherID == "" || TeacherFirstName == "" || TeacherLastName == "")
                throw new Exception("Empty TeacherID/FirstName/LastName value");
            Convert.ToInt64(TeacherID);

            string sql = @"UPDATE brigada0_teachers SET brigada0_teachers.FIRST_NAME = '" + TeacherFirstName +
                "', brigada0_teachers.LAST_NAME = '" + TeacherLastName + "' WHERE brigada0_teachers.TEACHER_ID = " + TeacherID;
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllTeachers();
        }

        #endregion

        #region - Insert - Database Commands -

        public DataView InsertGroup()
        {
            if (GroupName == "")
                throw new Exception("Empty GroupName value");

            int maxID = GetMaxID("brigada0_groups", "GROUP_ID");
            string sql = @"INSERT INTO brigada0_groups VALUES(" + (maxID + 1).ToString() + ",'" + GroupName + "')";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllGroups();
        }

        public DataView InsertStudent()
        {
            if (StudentFirstName == "" || StudentLastName == "" || StudentGroupID == "")
                throw new Exception("Empty StudentID/FirstName/LastName/GroupID value");
            Convert.ToInt64(StudentGroupID);

            int maxID = GetMaxID("brigada0_students", "STUDENT_ID");
            string sql = @"INSERT INTO brigada0_students VALUES(" + (maxID + 1).ToString() + 
                ",'" + StudentFirstName+ "','" + StudentLastName +"'," + StudentGroupID + ")";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllStudent();
        }

        public DataView InsertMark()
        {
            if (MarkStudentID == "" || MarkSubjectID == "" || MarkDate == "" || MarkValue == "")
                throw new Exception("Empty MarkID/StudentID/SubjectID/Date/Mark value");
            Convert.ToInt64(MarkStudentID);
            Convert.ToInt64(MarkSubjectID);
            int mark = Convert.ToInt32(MarkValue);

            var match = dateRegex.Match(MarkDate);
            if (!match.Success)
                throw new Exception("Incorrect Date format (dd-mm-yyyy)");
            else
                DateTime.ParseExact(match.Value, "dd-mm-yyyy", CultureInfo.InvariantCulture);

            if (!(mark <= 5 && mark >= 1))
                throw new Exception("Incorrect Mark value (from 1 t 5)");


            int maxID = GetMaxID("brigada0_marks", "MARK_ID");
            string sql = @"INSERT INTO brigada0_marks VALUES(" + (++maxID).ToString() + "," + MarkStudentID +
                "," + MarkSubjectID + ", TO_DATE('" + MarkDate + "', 'DD-MM-YYYY'), " + MarkValue + ")";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllMarks();
        }

        public DataView InsertSubject()
        {
            if (SubjectTitle == "")
                throw new Exception("Empty SubjectTitle value");

            int maxID = GetMaxID("brigada0_subjects", "SUBJECT_ID");
            string sql = @"INSERT INTO brigada0_subjects VALUES(" + (maxID + 1).ToString() + ",'" + SubjectTitle + "')";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllSubjects();
        }

        public DataView InsertTeacherSubject()
        {
            if (SubTeacherID == "" || TeachSubjectID == "")
                throw new Exception("Empty SubjectID/TeacherID value");
            Convert.ToInt64(SubTeacherID);
            Convert.ToInt64(TeachSubjectID);

            string sql = @"INSERT INTO brigada0_sub_teach VALUES(" + TeachSubjectID + "," + SubTeacherID + ")";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllTeacherSubjects();
        }

        public DataView InsertTeacher()
        {
            if (TeacherFirstName == "" || TeacherLastName == "")
                throw new Exception("Empty FirstName/LastName value");

            int maxID = GetMaxID("brigada0_teachers", "TEACHER_ID");
            string sql = @"INSERT INTO brigada0_teachers VALUES(" + (maxID + 1).ToString() +
                ",'" + TeacherFirstName + "','" + TeacherLastName + "')";
            DatabaseHelper.ExecuteCommand(sql);

            return SelectAllTeachers();
        }

        public int GetMaxID(string tableName, string idName)
        {
            string sql = @"SELECT * FROM " + tableName + " WHERE ROWNUM = 1 ORDER BY " + idName + " DESC ";
            var data = DatabaseHelper.ExecuteCommand(sql, "Table");
            var view = data.Tables["Table"].DefaultView;
            string maxID = "";

            foreach (var item in view)
            {
                var stId = item as DataRowView;
                maxID = stId.Row[0].ToString();
            }

            if (maxID == "")
                maxID = "0";

            return Convert.ToInt32(maxID);
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
