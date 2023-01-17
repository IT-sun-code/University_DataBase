using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Serilog;

namespace DataBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            Log.Logger = new LoggerConfiguration().
                WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day).
                CreateLogger();
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.Exception;
            MessageBox.Show(e.Message, "Exception");
            Log.Error(e.ToString());
            args.Handled = true;
        }
    }
}
