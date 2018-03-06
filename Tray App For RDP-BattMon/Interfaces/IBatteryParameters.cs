using System;

namespace FieldEffect.Interfaces
{
    public interface IBatteryParameters : IDisposable
    {
        string BatteryName { get; set; }
        string BatteryStatus { get; set; }
        string ClientEstRuntime { get; set; }
        int EstimatedChargeRemaining { get; set; }
    }
}