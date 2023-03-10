using System.ComponentModel;
using DataBase.Helper;
using Prism.Commands;
using DataBase.Model;
using System;

namespace DataBase.ViewModel
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        #region - Model Data -
        private UserModel userModel = new UserModel();
        #endregion

        #region - Public Data -
        public UserModel UserModel
        {
            get => userModel;
        }

        public string Login
        {
            get => userModel.Login;
            set => userModel.Login = value;
        }

        public string Password
        {
            get => userModel.Password;
            set => userModel.Password = value;
        }

        public string DataSource
        {
            get => userModel.DataSource;
            set => userModel.DataSource = value;
        }

        public bool State
        {
            get => userModel.ConnectionState;
            set => userModel.ConnectionState = value;
        }
        #endregion

        #region - Delegate Commands -
        public DelegateCommand OnSignInCommand { get; private set; }
        #endregion

        public SignInViewModel() 
        {
            OnSignInCommand = new DelegateCommand(OnSignIn, () => true);
        }

        #region - Implementation Delegate Commands -
        public void OnSignIn()
        {
            // 0. Check login and password
            if (Login == "" || Password == "" || DataSource == "")
                throw new Exception("Incorrect Login/Password or DataSource is empty");
            // 1. Create connection
            State = DatabaseHelper.CreateConnect(Login, Password, DataSource);
            if (!State)
                throw new Exception("Can't connect to database. Maybe incorrect Login/Password");
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
