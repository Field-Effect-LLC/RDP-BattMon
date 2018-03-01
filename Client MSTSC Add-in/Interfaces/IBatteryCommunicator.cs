using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Win32.WtsApi32;

namespace FieldEffect.Interfaces
{
    public interface IBatteryCommunicator : IDisposable
    {
        ChannelEntryPoints EntryPoints { get; set; }
        void Initialize();
    }
}
