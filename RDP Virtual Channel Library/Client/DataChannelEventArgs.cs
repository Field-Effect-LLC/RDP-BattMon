using FieldEffect.VCL.Client.WtsApi32;
using System;

namespace FieldEffect.VCL.Client
{
    public class DataChannelEventArgs : EventArgs
    {
        public int OpenHandle { get; set; }
        public ChannelEvents Event { get; set; }
        public byte[] Data { get; set; }
        public int DataLength { get; set; }
        public uint TotalLength { get; set; }
        public ChannelFlags DataFlags { get; set; }
    }
}
