using System;
using FieldEffect.Classes;
using Win32.WtsApi32;

namespace FieldEffect.Interfaces
{
    public interface ITsClientAddIn
    {
        event EventHandler<DataChannelEventArgs> DataChannelEvent;

        ChannelReturnCodes Initialize();
        void VirtualChannelInitEventProc(IntPtr initHandle, ChannelEvents Event, byte[] data, int dataLength);
        void VirtualChannelOpenEvent(int openHandle, ChannelEvents Event, byte[] data, int dataLength, uint totalLength, ChannelFlags dataFlags);
        void VirtualChannelWrite(byte[] data);
    }
}