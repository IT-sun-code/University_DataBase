using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Model
{
    public class UserModel : BindableBase
    {
        public string Login { get; set; } = "ST_USER";
        public string Password { get; set; } = "oracle69";
        public string DataSource { get; set; } = "localhost:1521/XEPDB1";
        public bool ConnectionState { get; set; } = false;

        public UserModel() {}

        public void Clear()
        {
            Login = "";
            Password = "";
            ConnectionState = false;
        }
    }
}
