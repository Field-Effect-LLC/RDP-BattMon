using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Win32.WtsApi32;
using System.Windows.Forms;
using FieldEffect.Classes;
using Microsoft.Win32;
using System.Reflection;
using FieldEffect.Models;
using FieldEffect.Interfaces;
using FieldEffect.Exceptions;
using log4net;
using System.IO;

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

        private IBatteryCommunicator batteryCommunicator = null;

        ~Program()
        {
            //Don't GC the batteryCommunicator until the program is done
            GC.KeepAlive(batteryCommunicator);
        }

        public bool Run(ref ChannelEntryPoints entry)
        {
            try
            {
                batteryCommunicator = (IBatteryCommunicator)NinjectConfig.Instance.GetService(typeof(IBatteryCommunicator));
                batteryCommunicator.EntryPoints = entry;
                batteryCommunicator.Initialize();
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
            Application.ThreadException += (s, e) => _log.Fatal(e.Exception.ToString());
            AppDomain.CurrentDomain.UnhandledException += (s, e) => _log.Fatal(e.ExceptionObject.ToString());
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            return _instance.Value.Run(ref entry);
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            foreach (var file in Directory.GetFiles(_dllPath.Value))
            {
                if (file.ToLower().EndsWith("dll"))
                {
                    try
                    {
                        var assm = Assembly.LoadFrom(file);
                        if (assm.FullName == args.Name)
                        {
                            return assm;
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Debug(ex.ToString());
                    }
                }
            }
            return null;
        }
    }
}
