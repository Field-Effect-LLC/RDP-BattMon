using System;
using FieldEffect.VCL.Exceptions;
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

                //Strip zero
                //result = result.Substring(0, result.Length - 1);

                //Communication expects that the last character read is a null char
                if (!reply.EndsWith("\0"))
                    throw new VirtualChannelException("Bad response");

                reply = reply.Substring(0, reply.Length - 1);

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
