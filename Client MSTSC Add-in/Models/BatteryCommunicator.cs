using FieldEffect.Interfaces;
using FieldEffect.VCL.Client;
using FieldEffect.VCL.Client.Interfaces;
using FieldEffect.VCL.Client.WtsApi32;
using FieldEffect.VCL.CommunicationProtocol;
using System;
using System.Text;

namespace FieldEffect.Models
{
    public class BatteryCommunicator : IBatteryCommunicator
    {
        IRdpClientVirtualChannel _clientAddIn;
        IBatteryInfo _batteryInfo;
        IBatteryInfoFactory _batteryInfoFactory;
        string _data = String.Empty;
        private bool _isDisposed = false;

        public BatteryCommunicator(IRdpClientVirtualChannel clientAddin, IBatteryInfo batteryInfo, IBatteryInfoFactory batteryInfoFactory)
        {
            _clientAddIn = clientAddin;
            _batteryInfo = batteryInfo;
            _batteryInfoFactory = batteryInfoFactory;

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
                    {
                        //BatteryInfo may (or may not) be Disposable,
                        //depending on the implementation.
                        if (_batteryInfo is IDisposable disposableBattInfo)
                            disposableBattInfo.Dispose();
                    }
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

                if (request.Value.Contains("BatteryInfo"))
                {
                    BatteryInfo toSerialize = _batteryInfoFactory.Create(
                            _batteryInfo.ClientName,
                            _batteryInfo.EstimatedChargeRemaining,
                            _batteryInfo.EstimatedRunTime,
                            _batteryInfo.BatteryStatus
                        );
                    
                    response.Value.Add("BatteryInfo", toSerialize);
                }

                byte[] responseBytes = Encoding.UTF8.GetBytes(response.Serialize());
                _clientAddIn.VirtualChannelWrite(responseBytes);
            }
        }
    }
}
