using System;
using FieldEffect.VCL.Exceptions;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.CommunicationProtocol;
using FieldEffect.Interfaces;
using System.Collections.Generic;

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
                    var batteryInfo = RetrieveBatteryInfoFromClient();
                    return batteryInfo;
                }
                catch
                {
                    //Return empty list
                    return new List<IBatteryInfo>();
                }
            }
        }

        private List<IBatteryInfo> RetrieveBatteryInfoFromClient()
        {
            var request = new Request();
            request.Value.Add("BatteryInfo");

            _channel.OpenChannel();

            _channel.WriteChannel(request.Serialize());

            var reply = _channel.ReadChannel();

            var response = Response.Deserialize(reply);

            var propertyValue = (List<IBatteryInfo>)response.Value["BatteryInfo"];

            _channel.CloseChannel();

            return propertyValue;
        }
    }
}
