using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FieldEffect.Classes
{
    public class LoggerErrorHandler : IErrorHandler
    {
        public void Error(string message, Exception e, ErrorCode errorCode)
        {
            Error(message + "\r\n" + e.ToString() + "\r\n" + errorCode.ToString());
        }

        public void Error(string message, Exception e)
        {
            Error(message + "\r\n" + e.ToString());
        }

        public void Error(string message)
        {
            MessageBox.Show(message);
        }
    }

    public static class Logger
    {
        //https://stackoverflow.com/a/19538654/864414
        public static void Initialize()
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            //patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger [%property{NDC}] - %message%newline";
            patternLayout.ActivateOptions();

            EventLogAppender eventLogAppender = new EventLogAppender();
            eventLogAppender.ApplicationName = "RDS_Server_TrayApp_BattMon";
            eventLogAppender.LogName = "Application";
            eventLogAppender.Name = "EventLogAppender";
            eventLogAppender.Layout = patternLayout;
            eventLogAppender.ActivateOptions();
            hierarchy.Root.AddAppender(eventLogAppender);

            /*
            FileAppender file = new FileAppender();
            file.AppendToFile = false;
            var path = System.IO.Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
            file.File = System.IO.Path.Combine(path, "EventLog.txt");
            file.Layout = patternLayout;
            file.ActivateOptions();
            hierarchy.Root.AddAppender(file);
            */


            hierarchy.Root.Level = Level.All;

            BasicConfigurator.Configure(hierarchy);
            hierarchy.Configured = true;

        }

        public static ILog GetLogger()
        {
            return LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }
    }
}
