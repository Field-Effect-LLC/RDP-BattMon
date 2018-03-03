using FieldEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Management;

namespace FieldEffect.Models
{
   /**
    * Concrete implementation of the IBatteryInfo interface.
    * In future, we may need to implement a Win32 battery meter,
    * but, for the first release, only a WMI meter is planned.
    */
    public class WmiBatteryInfo : IBatteryInfo
    {
        private ManagementObject _batteryObject;
        private IWin32BatteryManagementObjectSearcher _searcher;
        private bool _isDisposed = false;

        public WmiBatteryInfo(IWin32BatteryManagementObjectSearcher searcher)
        {
            _searcher = searcher;
        }

        private void Refresh()
        {
            var batteries = _searcher.Get();
            if (batteries.Count > 0)
            {
                if (_batteryObject != null)
                    _batteryObject.Dispose();

                //For now, let's just get the first battery. In future
                //maybe we will use a seriaized XML object or JSON to send 
                //all battery info.
                _batteryObject = batteries.Cast<ManagementObject>().First();
            }
        }

        private TargetType GetProperty<TargetType>(string propertyName)
        {
            object outValue = default(TargetType);

            Refresh();
            string propertyAsString = _batteryObject[propertyName].ToString();
            if (typeof(TargetType) == typeof(int))
            {
                int parsedString = 0;
                if (int.TryParse(propertyAsString, out parsedString))
                {
                    //Boxing conversion
                    outValue = parsedString;
                }
            }
            if (typeof(TargetType) == typeof(String))
            {
                outValue = propertyAsString;
            }

            return (TargetType)outValue;
        }

        public int EstimatedChargeRemaining
        {
            get
            {
                return GetProperty<int>("EstimatedChargeRemaining");
            }
        }

        public TimeSpan EstimatedRunTime
        {
            get
            {
                var secondsRemaining = GetProperty<int>("EstimatedRunTime");
                return new TimeSpan(0, 0, secondsRemaining);
            }
        }

        public int BatteryStatus
        {
            get
            {
                return GetProperty<int>("BatteryStatus");
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_isDisposed)
                {
                    if (_batteryObject != null)
                        _batteryObject.Dispose();
                    if (_searcher != null)
                        _searcher.Dispose();

                    _isDisposed = true;
                }
            }
        }
    }
}
