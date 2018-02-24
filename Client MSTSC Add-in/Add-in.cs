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

namespace FieldEffect
{
    class Program
    {
        /**
         * Main exists in order to self-register this TS Add-in.
         */
        static void Main(string[] args)
        {
            //[HKEY_CURRENT_USER\Software\Microsoft\Terminal Server Client\Default\AddIns\TSAddinInCS]
            //"Name"="C:\\Documents and Settings\\Selvin\\Pulpit\\TSAddinInCS
            //\\Client\\bin\\Debug\\TSAddinInCS.dll"

            var pathToExe = Assembly.GetExecutingAssembly().Location;
            string addinName = "BattMon";

            using (RegistryKey addinsKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Terminal Server Client\Default\AddIns"))
            using (RegistryKey battMonKey = addinsKey.OpenSubKey(addinName))
            {
                string message = String.Empty;
                //Toggle registry key
                if (battMonKey == null)
                {
                    //key doesn't exist; create it
                    using (RegistryKey newBattMonKey = addinsKey.CreateSubKey(addinName))
                    {
                        newBattMonKey.SetValue("Name", pathToExe);
                        message = "BattMon Remote Desktop Addin has been installed";
                    }
                }
                else
                {
                    //key exists; remove it
                    addinsKey.DeleteSubKey(addinName);
                    message = "BattMon Remote Desktop Addin has been removed";
                }
                MessageBox.Show(message, "Information", MessageBoxButtons.OK);
            }
        }

        [DllExport("VirtualChannelEntry", CallingConvention.StdCall)]
        public static bool VirtualChannelEntry(ref ChannelEntryPoints entry)
        {
            var clientAddIn = new TsClientAddIn("BATTMON", entry);
            if (clientAddIn.Initialize() != ChannelReturnCodes.Ok)
            {
                MessageBox.Show("RDP Battery Add-in: Initialization of communication channel for battery monitor failed.",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            string data = String.Empty;
            clientAddIn.DataChannelEvent += (s, e) =>
            {
                string curData;
                if (e.DataFlags == ChannelFlags.First || e.DataFlags == ChannelFlags.Only)
                {
                    data = "";
                }
                if (e.Data == null)
                    return;

                curData = Encoding.UTF8.GetString(e.Data, 0, e.DataLength);
                data = data + curData;

                if (e.DataFlags == ChannelFlags.Last || e.DataFlags == ChannelFlags.Only)
                {
                    if (data == "EstimatedChargeRemaining\0")
                    {
                        Win32BatteryManagementObject obj = new Win32BatteryManagementObject();
                        WmiBatteryInfo info = new WmiBatteryInfo(obj);

                        byte[] response = Encoding.UTF8.GetBytes(String.Format("EstimatedChargeRemaining,{0}\0", info.EstimatedChargeRemaining));
                        clientAddIn.VirtualChannelWrite(response);

                    }
                }
                    
            };

            return true;
        }
    }
}
