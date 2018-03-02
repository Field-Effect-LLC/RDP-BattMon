using FieldEffect.VCL.Client.WtsApi32;
using System;

namespace FieldEffect.VCL.Client.Interfaces
{
    public interface IRdpClientVirtualChannel
    {
        event EventHandler<DataChannelEventArgs> DataChannelEvent;

        ChannelEntryPoints EntryPoints { get; set; }

        ChannelReturnCodes Initialize();
        void VirtualChannelInitEventProc(IntPtr initHandle, ChannelEvents Event, byte[] data, int dataLength);
        void VirtualChannelOpenEvent(int openHandle, ChannelEvents Event, byte[] data, int dataLength, uint totalLength, ChannelFlags dataFlags);
        void VirtualChannelWrite(byte[] data);
    }
}