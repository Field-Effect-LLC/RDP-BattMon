using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32.WtsApi32;

namespace FieldEffect.Classes
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
