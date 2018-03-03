using FieldEffect.Interfaces;
using System;
using System.Linq;
using System.Text;
using FieldEffect.VCL.Client.Interfaces;
using FieldEffect.VCL.Client.WtsApi32;
using FieldEffect.VCL.Client;
using FieldEffect.VCL.CommunicationProtocol;

namespace FieldEffect.Models
{
    public class BatteryCommunicator : IBatteryCommunicator
    {
        IRdpClientVirtualChannel _clientAddIn;
        IBatteryInfo _batteryInfo;
        string _data = String.Empty;
        private bool _isDisposed = false;

        public BatteryCommunicator(IRdpClientVirtualChannel clientAddin, IBatteryInfo batteryInfo)
        {
            _clientAddIn = clientAddin;
            _batteryInfo = batteryInfo;

            _clientAddIn.DataChannelEvent += _clientAddIn_DataChannelEvent;
        }

        public ChannelEntryPoints EntryPoints
        {
            get { return _clientAddIn.EntryPoints; }
            set { _clientAddIn.EntryPoints = value; }
        }
        
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!_isDisposed)
                {
                    if (_batteryInfo != null)
                        _batteryInfo.Dispose();
                }
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        public void Initialize()
        {
            //Will throw a VirtualChannelException on failure
            _clientAddIn.Initialize();
        }

        private void _clientAddIn_DataChannelEvent(object sender, DataChannelEventArgs e)
        {
            string curData;
            if (e.DataFlags == ChannelFlags.First || e.DataFlags == ChannelFlags.Only)
            {
                _data = "";
            }
            if (e.Data == null)
                return;

            curData = Encoding.UTF8.GetString(e.Data, 0, e.DataLength);
            _data = _data + curData;

            if (e.DataFlags == ChannelFlags.Last || e.DataFlags == ChannelFlags.Only)
            {
                var request = Request.Deserialize(_data);
                var response = new Response();
                if (request.Value.Contains("EstimatedChargeRemaining"))
                {
                    response.Value.Add("EstimatedChargeRemaining", _batteryInfo.EstimatedChargeRemaining);
                }

                if (request.Value.Contains("ClientName"))
                {
                    response.Value.Add("ClientName", Environment.MachineName);
                }

                if (request.Value.Contains("BatteryStatus"))
                {
                    response.Value.Add("BatteryStatus", _batteryInfo.BatteryStatus);
                }

                if (request.Value.Contains("EstimatedRunTime"))
                {
                    response.Value.Add("EstimatedRunTime", _batteryInfo.EstimatedRunTime);
                }

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.Serialize());
                _clientAddIn.VirtualChannelWrite(responseBytes);
            }
        }
    }
}
