using FieldEffect.VCL.Client.WtsApi32;
using System;

namespace FieldEffect.Interfaces
{
    public interface IBatteryCommunicator : IDisposable
    {
        ChannelEntryPoints EntryPoints { get; set; }
        void Initialize();
    }
}
