using FieldEffect.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Models
{
    class BatteryLevel
    {
        private string _channelName = String.Empty;
        private IntPtr _mHandle = IntPtr.Zero;

        public BatteryLevel(string channelName)
        {
            _channelName = channelName;
        }

        private void OpenChannel()
        {
            _mHandle = NativeMethods.WTSVirtualChannelOpen(IntPtr.Zero, -1, _channelName);
            if (_mHandle == IntPtr.Zero)
            {
                throw new Exception("Can't open channel");
            }
        }

        private void CloseChannel()
        {
            if (!NativeMethods.WTSVirtualChannelClose(_mHandle))
            {
                throw new Exception("Can't close channel");
            }
        }

        private void WriteChannel(string message)
        {
            int written = 0;
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (!NativeMethods.WTSVirtualChannelWrite(_mHandle, data, data.Length, ref written))
            {
                throw new Exception("Can't write data");
            }
            if (written != data.Length)
            {
                throw new Exception("Didn't write all data");
            }
        }

        private string ReadChannel()
        {
            string result = String.Empty;
            int bytesRead = 0;
            byte[] buffer = new byte[1600];
            if (!NativeMethods.WTSVirtualChannelRead(_mHandle, NativeMethods.INFINITE, buffer, buffer.Length, ref bytesRead))
            {
                throw new Exception("Can't read data");
            }
            if (buffer[bytesRead - 1] != 0)
                throw new Exception("Bad response");

            result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            //Strip zero
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public int Poll()
        {
            string reply = "";
            string[] estChargeRemaining;
            try
            {
                OpenChannel();
            }
            catch (Exception e)
            {
                return -1;
            }
            WriteChannel("EstimatedChargeRemaining\0");
            reply = ReadChannel();
            estChargeRemaining = reply.Split(',');
            if (estChargeRemaining[0] != "EstimatedChargeRemaining")
                throw new Exception("Illegal reply");
            CloseChannel();
            return int.Parse(estChargeRemaining[1]);
        }
    }
}
