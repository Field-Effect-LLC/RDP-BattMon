using FieldEffect.Interfaces;
using FieldEffect.Models;
using log4net;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using FieldEffect.VCL.Server.Interfaces;
using FieldEffect.VCL.Server;

namespace FieldEffect.Classes
{
    internal class NinjectConfig : NinjectModule
    {
        private static Lazy<IKernel> _instance = new Lazy<IKernel>(()=>
        {
            return new StandardKernel(new NinjectConfig());
        });

        public static IKernel Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public override void Load()
        {
            KernelInstance.Bind<IManagementObjectSearcherFactory>()
                .ToFactory()
                .InSingletonScope();

            KernelInstance.Bind<IManagementObject>()
                .To<Win32BatteryManagementObject>()
                .InSingletonScope()
                .WithConstructorArgument("query", "Win32_Battery");

            KernelInstance.Bind<IBatteryInfo>()
                .To<WmiBatteryInfo>()
                .InSingletonScope();

            KernelInstance.Bind<IRdpClientVirtualChannel>()
                .To<RdpClientVirtualChannel>()
                .InSingletonScope()
                .WithConstructorArgument("channelName", "BATTMON");

            KernelInstance.Bind<IBatteryCommunicator>()
                .To<BatteryCommunicator>()
                .InSingletonScope();

            KernelInstance.Bind<IWin32BatteryManagementObjectSearcher>()
                .To<Win32BatteryManagementObjectSearcher>()
                .InSingletonScope()
                .WithConstructorArgument("query", "SELECT * FROM Win32_Battery");

            KernelInstance.Bind<ILog>().ToMethod(context =>
                LogManager.GetLogger(context.Request.Target.Member.ReflectedType));

        }
    }
}
