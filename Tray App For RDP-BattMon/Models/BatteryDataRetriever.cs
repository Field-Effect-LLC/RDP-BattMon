using System;
using FieldEffect.VCL.Server.Interfaces;

namespace FieldEffect.Models
{
    class BatteryDataRetriever
    {
        IRdpServerVirtualChannel _channel;

        public BatteryDataRetriever (IRdpServerVirtualChannel channel)
        {
            _channel = channel;
        }

        public int Poll()
        {
            string reply = "";
            string[] estChargeRemaining;
            try
            {
                _channel.OpenChannel();

                _channel.WriteChannel("EstimatedChargeRemaining\0");

                reply = _channel.ReadChannel();

                estChargeRemaining = reply.Split(',');

                if (estChargeRemaining[0] != "EstimatedChargeRemaining")
                    throw new Exception("Illegal reply");

                _channel.CloseChannel();

                return int.Parse(estChargeRemaining[1]);
            } 
            catch (Exception)
            {
                //Zero means we don't know what the client battery level is
                return 0;
            }
        }
    }
}
