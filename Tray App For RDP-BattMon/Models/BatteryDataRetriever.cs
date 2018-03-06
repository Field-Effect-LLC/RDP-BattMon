using System;
using FieldEffect.VCL.Exceptions;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.CommunicationProtocol;
using FieldEffect.Interfaces;
using System.Collections.Generic;
using FieldEffect.Classes;
using log4net;
using System.Reflection;

namespace FieldEffect.Models
{
    public class BatteryDataRetriever : IBatteryDataRetriever
    {
        IRdpServerVirtualChannel _channel;

        public BatteryDataRetriever (IRdpServerVirtualChannel channel)
        {
            _channel = channel;
        }

        public IEnumerable<IBatteryInfo> BatteryInfo
        {
            get
            {
                try
                {
                    var batteryInfo = RetrieveClientProperty<IEnumerable<IBatteryInfo>>("BatteryInfo");
                    return batteryInfo;
                }
                catch
                {
                    //Return empty list
                    return new List<IBatteryInfo>();
                }
            }
        }

        private RequestedType RetrieveClientProperty<RequestedType>(string propertyName)
        {
            var request = new Request();
            request.Value.Add(propertyName);

            _channel.OpenChannel();

            _channel.WriteChannel(request.Serialize());

            var reply = _channel.ReadChannel();

            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType).Debug(reply);
            //Logger.GetLogger().Debug(reply);

            var response = Response.Deserialize(reply);

            var propertyValue = response.Value[propertyName];

            _channel.CloseChannel();

            return (RequestedType)propertyValue;
        }
    }
}
