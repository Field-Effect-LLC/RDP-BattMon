using System;
using System.Diagnostics;
using System.Drawing;
using FieldEffect;
using FieldEffect.Interfaces;
using FieldEffect.Models;
using FieldEffect.Presenters;
using FieldEffect.VCL.CommunicationProtocol;
using FieldEffect.VCL.Server;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.Views;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;

namespace Tray_App_Tests
{
    [TestClass]
    public class UnitTest1
    {
        MoqMockingKernel _kernel;

        public UnitTest1()
        {
            _kernel = new MoqMockingKernel();
            _kernel.Bind<IBatteryInfo>()
                .To<BatteryInfo>();

            _kernel.Bind<IBatteryParameters>()
                .To<BatteryParameters>();

            _kernel.Bind<IBatteryParametersFactory>()
                .ToFactory()
                .InSingletonScope();

            _kernel.Bind<IBatteryDetailPresenter>()
                .To<BatteryDetailPresenter>()
                .InSingletonScope();

            _kernel.Bind<IBatteryDetail>()
                .To<BatteryDetail>()
                .InSingletonScope();

            _kernel.Bind<IBatteryIcon>()
                .To<BatteryIcon>()
                .InSingletonScope()
                //.WithConstructorArgument("batteryTemplate", Properties.Resources.BattLevel)
                .WithConstructorArgument("batteryLevelMask", new Rectangle(5, 10, 20, 10))
                .WithConstructorArgument("batteryOrientation", BatteryIcon.BatteryOrientation.HorizontalL)
                .WithPropertyValue("BatteryLevel", 0);

            _kernel.Bind<IBatteryDataRetriever>()
                .To<BatteryDataRetriever>()
                .InSingletonScope();

            _kernel.Bind<IRdpServerVirtualChannel>()
                 .ToMock()
                 .InSingletonScope()
                 .WithConstructorArgument("channelName", "BATTMON");

            //_kernel.Bind<ILog>().ToMethod(context =>
            //    LogManager.GetLogger(context.Request.Target.Member.ReflectedType));

            _kernel.Bind<ILog>()
                .ToMock()
                .InSingletonScope();

            _kernel.Bind<System.Timers.Timer>()
                .ToSelf()
                .InSingletonScope()
                .WithPropertyValue("AutoReset", true)
                .WithPropertyValue("Interval", 10 * 1000.0);

            
        }

        private IBatteryDataRetriever _batteryDataRetriever;


        [Inject]
        public void MoqInjection(IBatteryDataRetriever batteryDataRetriever)
        {
            _batteryDataRetriever = batteryDataRetriever;
        }

        [TestInitialize]
        public void Initialize()
        {
            _kernel.Reset();
            MockingSetup();
            _kernel.Inject(this);
        }

        private void MockingSetup()
        {
            //Do mocking setup (is there a better way?!)
            Mock<IRdpServerVirtualChannel> rdpServerVirtualChannel = _kernel.GetMock<IRdpServerVirtualChannel>();
            rdpServerVirtualChannel.Setup(v => v.ReadChannel())
                .Returns("{\"$type\":\"FieldEffect.VCL.CommunicationProtocol.Response, RDP - BattMon Comm Protocol, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null\",\"Value\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089],[System.Object, mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089]], mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089\",\"BatteryInfo\":{\"$type\":\"System.Collections.Generic.List`1[[FieldEffect.Interfaces.IBatteryInfo, BatteryInfo, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null]], mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089\",\"$values\":[{\"$type\":\"FieldEffect.BatteryInfo, BatteryInfo, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null\",\"ClientName\":\"DESKTOP - CA1M2JN\",\"EstimatedChargeRemaining\":74,\"EstimatedRunTime\":406,\"BatteryStatus\":1}]}}}\0");

        }

        [TestMethod]
        public void Test_BatteryDataRetriever()
        {
            //var virtChannel = _kernel.GetMock<IRdpServerVirtualChannel>();
            //var log = _kernel.GetMock<ILog>();
            //BatteryDataRetriever retriever = new BatteryDataRetriever(log.Object, virtChannel.Object);

            //virtChannel.Setup(v => v.ReadChannel())
            //    .Returns("{\"$type\":\"FieldEffect.VCL.CommunicationProtocol.Response, RDP - BattMon Comm Protocol, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null\",\"Value\":{\"$type\":\"System.Collections.Generic.Dictionary`2[[System.String, mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089],[System.Object, mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089]], mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089\",\"BatteryInfo\":{\"$type\":\"System.Collections.Generic.List`1[[FieldEffect.Interfaces.IBatteryInfo, BatteryInfo, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null]], mscorlib, Version = 4.0.0.0, Culture = neutral, PublicKeyToken = b77a5c561934e089\",\"$values\":[{\"$type\":\"FieldEffect.BatteryInfo, BatteryInfo, Version = 1.0.1.0, Culture = neutral, PublicKeyToken = null\",\"ClientName\":\"DESKTOP - CA1M2JN\",\"EstimatedChargeRemaining\":74,\"EstimatedRunTime\":406,\"BatteryStatus\":1}]}}}\0");

            
            var battInfo = _batteryDataRetriever.BatteryInfo;
            foreach (var battery in battInfo)
            {
                Debug.Print(battery.BatteryStatus.ToString());
            }
        }
    }
}
