using System;
using FieldEffect.VCL.Exceptions;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.CommunicationProtocol;
using FieldEffect.Interfaces;
using System.Collections.Generic;
using log4net;

namespace FieldEffect.Models
{
    public class BatteryDataRetriever : IBatteryDataRetriever
    {
        private IRdpServerVirtualChannel _channel;
        private ILog _log;

        public BatteryDataRetriever (ILog log, IRdpServerVirtualChannel channel)
        {
            _channel = channel;
            _log = log;
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
                catch(Exception e)
                {
                    //Log the exception
                    _log.Error(e.ToString());
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

            string serializedRequest = request.Serialize();
            _log.Debug(String.Format(Properties.Resources.DebugMsgRequestingBattInfo, serializedRequest));
            _channel.WriteChannel(request.Serialize());

            var reply = _channel.ReadChannel();
            _log.Debug(String.Format(Properties.Resources.DebugMsgReceivedBattInfo, reply));

            var response = Response.Deserialize(reply);
            var propertyValue = (List<IBatteryInfo>)response.Value["BatteryInfo"];

            _channel.CloseChannel();

            return propertyValue;
        }
    }
}
