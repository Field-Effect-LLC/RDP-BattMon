using System;
using System.Drawing;

namespace FieldEffect.Interfaces
{
    public interface IBatteryIcon : IDisposable
    {
        int BatteryLevel { get; set; }
        Icon RenderedIcon { get; }

        void Render();
    }
}