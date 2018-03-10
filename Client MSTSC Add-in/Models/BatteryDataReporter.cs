using FieldEffect.Interfaces;
using FieldEffect.VCL.Client;
using FieldEffect.VCL.Client.Interfaces;
using FieldEffect.VCL.Client.WtsApi32;
using FieldEffect.VCL.CommunicationProtocol;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using log4net;

namespace FieldEffect.Models
{
    public class BatteryDataReporter : IBatteryDataReporter
    {
        IRdpClientVirtualChannel _clientAddIn;
        IBatteryDataCollector _batteryDataCollector;
        string _data = String.Empty;
        private bool _isDisposed = false;
        private ILog _log;

        public BatteryDataReporter(ILog log, IRdpClientVirtualChannel clientAddin, IBatteryDataCollector batteryDataCollector)
        {
            _clientAddIn = clientAddin;
            _batteryDataCollector = batteryDataCollector;
            _log = log;

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
                _log.Debug(String.Format(Properties.Resources.DebugMsgReceivedRequest, _data));
                var request = Request.Deserialize(_data);
                var response = new Response();

                if (request.Value.Contains("BatteryInfo"))
                {
                    List<IBatteryInfo> batteryInfo = new List<IBatteryInfo>(_batteryDataCollector.GetAllBatteries());
                    response.Value.Add("BatteryInfo", batteryInfo);
                }
                string serializedResponse = response.Serialize();
                _log.Debug(String.Format(Properties.Resources.DebugMsgSendingBattInfo, serializedResponse));

                byte[] responseBytes = Encoding.UTF8.GetBytes(serializedResponse);
                _clientAddIn.VirtualChannelWrite(responseBytes);
            }
        }
    }
}
