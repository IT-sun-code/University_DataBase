using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DataBase.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        

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
