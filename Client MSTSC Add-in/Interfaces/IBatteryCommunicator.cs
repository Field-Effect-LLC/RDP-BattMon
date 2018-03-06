using FieldEffect.VCL.Client.WtsApi32;
using System;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDataReporter : IDisposable
    {
        ChannelEntryPoints EntryPoints { get; set; }
        void Initialize();
    }
}
