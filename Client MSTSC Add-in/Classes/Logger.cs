using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Classes
{
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
            eventLogAppender.ApplicationName = "RDS_Client_Addin_BattMon";
            eventLogAppender.LogName = "Application";
            eventLogAppender.Name = "EventLogAppender";
            eventLogAppender.Layout = patternLayout;
            eventLogAppender.ActivateOptions();

            hierarchy.Root.AddAppender(eventLogAppender);

            hierarchy.Root.Level = Level.All;

            BasicConfigurator.Configure(hierarchy);
            hierarchy.Configured = true;

        }
    }
}
