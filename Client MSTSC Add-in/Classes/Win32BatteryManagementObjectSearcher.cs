using FieldEffect.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Classes
{
    public class Win32BatteryManagementObjectSearcher : ManagementObjectSearcher, IBatteryDataCollector
    {
        IBatteryInfoFactory _batteryInfoFactory;

        public Win32BatteryManagementObjectSearcher(IBatteryInfoFactory batteryInfoFactory, string query) : base(query)
        {
            _batteryInfoFactory = batteryInfoFactory;
        }

        private TargetType ConvertValue<TargetType>(String propertyAsString)
        {
            object outValue = default(TargetType);

            if (typeof(TargetType) == typeof(int))
            {
                if (int.TryParse(propertyAsString, out int parsedString))
                {
                    //Boxing conversion
                    outValue = parsedString;
                }
            }

            if (typeof(TargetType) == typeof(String))
            {
                outValue = propertyAsString;
            }

            if (typeof(TargetType) == typeof(TimeSpan))
            {
                int seconds = ConvertValue<int>(propertyAsString);
                outValue = new TimeSpan(0, 0, seconds);
            }

            return (TargetType)outValue;
        }

        public IEnumerable<IBatteryInfo> GetAllBatteries()
        {
            List<IBatteryInfo> batteryInfoList = new List<IBatteryInfo>();
            var batteries = base.Get();
            foreach (ManagementObject battery in batteries)
            {
                var batteryInfo = _batteryInfoFactory.Create(
                        Environment.MachineName,
                        ConvertValue<int>(battery["EstimatedChargeRemaining"].ToString()),
                        ConvertValue<TimeSpan>(battery["EstimatedRunTime"].ToString()),
                        ConvertValue<int>(battery["BatteryStatus"].ToString())
                    );
                battery.Dispose();
            }
            return batteryInfoList;
        }
    }
}
