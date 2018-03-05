using FieldEffect.Interfaces;

namespace FieldEffect.Interfaces
{
    public interface IBatteryDataRetriever
    {
        IBatteryInfo BatteryInfo { get; }
    }
}