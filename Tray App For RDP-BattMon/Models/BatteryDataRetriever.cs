using System;
using FieldEffect.VCL.Exceptions;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.CommunicationProtocol;

namespace FieldEffect.Models
{
    class BatteryDataRetriever
    {
        IRdpServerVirtualChannel _channel;

        public BatteryDataRetriever (IRdpServerVirtualChannel channel)
        {
            _channel = channel;
        }

        private RequestedType RetrieveClientProperty<RequestedType>(string propertyName)
        {
            var request = new Request();
            request.Value.Add(propertyName);
            try
            {
                _channel.OpenChannel();

                _channel.WriteChannel(request.Serialize());

                var reply = _channel.ReadChannel();

                var response = Response.Deserialize(reply);

                var propertyValue = response.Value[propertyName];

                _channel.CloseChannel();

                return (RequestedType)propertyValue;
            }
            catch (Exception)
            {
                //Zero means we don't know what the client battery level is
                return default(RequestedType);
            }
        }

        public string ClientName
        {
            get { return RetrieveClientProperty<String>("ClientName"); }
        }

        public int EstimatedChargeRemaining
        {
            get { return (int)RetrieveClientProperty<Int64>("EstimatedChargeRemaining"); }
        }

        public string EstimatedRunTime
        {
            get { return RetrieveClientProperty<string>("EstimatedRunTime"); }
        }

        public int BatteryStatus
        {
            get { return (int)RetrieveClientProperty<Int64>("BatteryStatus"); }
        }

    }
}
