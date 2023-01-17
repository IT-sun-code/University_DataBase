using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using DataBase.Model;
using DataBase.Helper;
using DataBase.View;

namespace DataBase.ViewModel
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        #region - Model Data -
        private UserModel userModel = new UserModel();
        #endregion

        #region - Public Data -
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
        #endregion

        #region - Delegate Commands -
        public DelegateCommand OnSignInCommand { get; private set; }
        #endregion

        public SignInViewModel() 
        {
            OnSignInCommand = new DelegateCommand(OnSignIn, () => true);
        }

        #region - Implementation Delegate Commands -
        void OnSignIn()
        {
            // 0. Check login and password
            if (Login == "" || Password == "")
                throw new Exception("Incorrect Login/Password");
            // 1. Create connection 
            if (!DatabaseHelper.CreateConnect(Login, Password))
                throw new Exception("Can't connect to database. Maybe incorrect Login/Password");
            // 2. Open Main Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
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
