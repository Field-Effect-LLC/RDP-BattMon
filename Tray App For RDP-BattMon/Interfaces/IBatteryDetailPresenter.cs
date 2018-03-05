using FieldEffect.Interfaces;
using System;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDetailPresenter : IDisposable
    {
        IBatteryDetail BatteryDetailView { get; set; }
    }
}