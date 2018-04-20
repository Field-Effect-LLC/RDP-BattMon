using FieldEffect.Classes;
using FieldEffect.Interfaces;
using log4net;
using System;
using System.Windows.Forms;

namespace FieldEffect
{
    class Program
    {
        private static ILog _log
        {
            get { return LogManager.GetLogger(typeof(Program)); }
        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            using (var presenter = (IBatteryDetailPresenter)NinjectConfig.Instance.GetService(typeof(IBatteryDetailPresenter)))
            { 
                Application.Run((Form)presenter.BatteryDetailView);
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            _log.Error(e.Exception.ToString());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _log.Error(e.ToString());
        }
    }
}
