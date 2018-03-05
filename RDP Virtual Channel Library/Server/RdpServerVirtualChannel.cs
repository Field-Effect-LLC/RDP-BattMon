using System;
using System.Text;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.Exceptions;

namespace FieldEffect.VCL.Server
{
    public class RdpServerVirtualChannel : IRdpServerVirtualChannel
    {
        private string _channelName = String.Empty;
        private IntPtr _mHandle = IntPtr.Zero;

        public RdpServerVirtualChannel(string channelName)
        {
            _channelName = channelName;
        }

        public void OpenChannel()
        {
            _mHandle = WtsApi32.WTSVirtualChannelOpen(IntPtr.Zero, -1, _channelName);
            if (_mHandle == IntPtr.Zero)
            {
                throw new VirtualChannelException("Can't open channel");
            }
        }

        public void CloseChannel()
        {
            if (!WtsApi32.WTSVirtualChannelClose(_mHandle))
            {
                throw new VirtualChannelException("Can't close channel");
            }
        }

        public void WriteChannel(string message)
        {
            int written = 0;
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (!WtsApi32.WTSVirtualChannelWrite(_mHandle, data, data.Length, ref written))
            {
                throw new VirtualChannelException("Can't write data");
            }
            if (written != data.Length)
            {
                throw new VirtualChannelException("Didn't write all data");
            }
        }

        public string ReadChannel()
        {
            string result = String.Empty;
            int bytesRead = 0;
            byte[] buffer = new byte[1600];
            if (!WtsApi32.WTSVirtualChannelRead(_mHandle, WtsApi32.INFINITE, buffer, buffer.Length, ref bytesRead))
            {
                throw new VirtualChannelException("Can't read data");
            }

            result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            return result;
        }
    }
}
