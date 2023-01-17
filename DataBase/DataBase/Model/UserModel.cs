using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Model
{
    public class UserModel : BindableBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool ConnectionState { get; set; }

        public UserModel()
        {
            Login = "";
            Password = "";
            ConnectionState = false;
        }

        public void Clear()
        {
            Login = "";
            Password = "";
            ConnectionState = false;
        }
    }
}
