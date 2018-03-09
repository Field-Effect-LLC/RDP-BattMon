using FieldEffect.Classes;
using FieldEffect.Interfaces;
using FieldEffect.VCL.Exceptions;
using FieldEffect.VCL.Client.WtsApi32;
using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FieldEffect
{
    class Program
    {
        private static Lazy<ILog> _iLog = new Lazy<ILog>(() =>
        {
            return LogManager.GetLogger(typeof(Program));
        });

        private static ILog _log => _iLog.Value;

        private static Lazy<Program> _instance = new Lazy<Program>();

        private static Lazy<string> _dllPath = new Lazy<string>(() => {
            return Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        });

        private IBatteryDataReporter batteryReporter = null;

        ~Program()
        {
            //Don't GC the batteryCommunicator until the program is done
            GC.KeepAlive(batteryReporter);
            _log.Info("BattMon Remote Desktop client battery reporter exited.");
        }

        public bool Run(ref ChannelEntryPoints entry)
        {
            try
            {
                batteryReporter = (IBatteryDataReporter)NinjectConfig.Instance.GetService(typeof(IBatteryDataReporter));
                batteryReporter.EntryPoints = entry;
                batteryReporter.Initialize();

                //TODO: We need a good place to Dispose() of batteryCommunicator.
                //The destructor is the wrong place, but I'm not sure how
                //else to tell when the add-in is exiting.
            }
            catch (VirtualChannelException e)
            {
                //Communication problem
                _log.Fatal(e.ToString());
                return false;
            }
            catch (Ninject.ActivationException e)
            {
                _log.Fatal(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                _log.Fatal(e.ToString());
                return false;
            }
            return true;
        }
        
        [DllExport("VirtualChannelEntry", CallingConvention.StdCall)]
        public static bool VirtualChannelEntry(ref ChannelEntryPoints entry)
        {
            _log.Info("BattMon Remote Desktop client battery reporter started.");

            Application.ThreadException += (s, e) => _log.Fatal(e.Exception.ToString());
            AppDomain.CurrentDomain.UnhandledException += (s, e) => _log.Fatal(e.ExceptionObject.ToString());
            return _instance.Value.Run(ref entry);
        }
    }
}
