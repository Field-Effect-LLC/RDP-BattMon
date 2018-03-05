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
    [Serializable]
    public class WmiBatteryInfo : BatteryInfo
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
            if (_batteryObject != null)
                _batteryObject.Dispose();

            //For now, let's just get the first battery. In future
            //maybe we will use a seriaized XML object or JSON to send 
            //all battery info.
            _batteryObject = batteries.Cast<ManagementObject>().FirstOrDefault();
        }

        private TargetType GetProperty<TargetType>(string propertyName)
        {
            object outValue = default(TargetType);

            Refresh();

            if (_batteryObject == null)
                return default(TargetType);

            string propertyAsString = _batteryObject[propertyName].ToString();
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

            return (TargetType)outValue;
        }

        override public int EstimatedChargeRemaining
        {
            get
            {
                EstimatedChargeRemaining = GetProperty<int>("EstimatedChargeRemaining");
                return base.EstimatedChargeRemaining;
            }
            protected set
            {
                base.EstimatedChargeRemaining = value;
            }
        }

        override public TimeSpan EstimatedRunTime
        {
            get
            {
                var secondsRemaining = GetProperty<int>("EstimatedRunTime");
                EstimatedRunTime = new TimeSpan(0, 0, secondsRemaining);
                return base.EstimatedRunTime;
            }
            protected set
            {
                base.EstimatedRunTime = value;
            }
        }

        override public int BatteryStatus
        {
            get
            {
                BatteryStatus = GetProperty<int>("BatteryStatus");
                return base.BatteryStatus;
            }
            protected set
            {
                base.BatteryStatus = value;
            }
        }

        public override string ClientName
        {
            get
            {
                ClientName = Environment.MachineName;
                return base.ClientName;
            }
            protected set
            {
                base.ClientName = value;
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
