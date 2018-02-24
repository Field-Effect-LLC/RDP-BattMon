using FieldEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FieldEffect.Models
{
   /**
    * Concrete implementation of the IBatteryInfo interface.
    * In future, we may need to implement a Win32 battery meter,
    * but, for the first release, only a WMI meter is planned.
    */
    internal class WmiBatteryInfo : IBatteryInfo, IDisposable
    {
        private IManagementObject _batteryObject;
        private bool _isDisposed = false;

        public WmiBatteryInfo(IManagementObject wmiBatteryObject)
        {
            _batteryObject = wmiBatteryObject;
        }

        private void Refresh()
        {
            _batteryObject.Get();
        }

        public int EstimatedChargeRemaining
        {
            get
            {
                Refresh();
                return int.Parse(_batteryObject["EstimatedChargeRemaining"].ToString());
            }
        }

        public TimeSpan EstimatedRunTime
        {
            get
            {
                Refresh();
                return new TimeSpan(0, 0, (int)_batteryObject["EstimatedRunTime"]);
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
                    _batteryObject.Dispose();
                    _isDisposed = true;
                }
            }
        }
    }
}
