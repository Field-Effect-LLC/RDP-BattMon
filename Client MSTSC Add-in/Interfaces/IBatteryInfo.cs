using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldEffect.Interfaces
{
    /**
     * This interface provides information about the battery. Future
     * state might include battery health, etc; however, in the initial
     * implementation we'll only worry about the battery level.
     */
    interface IBatteryInfo
    {
        /// <summary>
        /// Level of the battery, represented as a percentage
        /// </summary>
        int EstimatedChargeRemaining
        {
            get;
        }

        TimeSpan EstimatedRunTime
        {
            get;
        }
    }
}
