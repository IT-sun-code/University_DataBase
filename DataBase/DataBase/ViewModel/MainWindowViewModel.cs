using DataBase.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataBase.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region - Private Data -
        private List<DatabaseRow> table = new List<DatabaseRow>();
        #endregion

        #region - Public Data - 
        public List<DatabaseRow> Table
        {
            get => table;
            set
            {
                table = value;
                OnPropertyChanged(nameof(Table));
            }
        }
        #endregion

        MainWindowViewModel() { }

        #region - On Property Changed -
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
