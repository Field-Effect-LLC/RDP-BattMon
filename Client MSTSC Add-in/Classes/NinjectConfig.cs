using FieldEffect.Interfaces;
using FieldEffect.Models;
using log4net;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using FieldEffect.VCL.Client.Interfaces;
using FieldEffect.VCL.Client;

namespace FieldEffect.Classes
{
    internal class NinjectConfig : NinjectModule
    {
        private static Lazy<IKernel> _instance = new Lazy<IKernel>(()=>
        {
            var kernel = new StandardKernel(new NinjectConfig());

            if (!kernel.HasModule(new FuncModule().Name))
            {
                kernel = new StandardKernel(new NinjectConfig(), new FuncModule());
            }

            return kernel;
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
            KernelInstance.Bind<IRdpClientVirtualChannel>()
                .To<RdpClientVirtualChannel>()
                .InSingletonScope()
                .WithConstructorArgument("channelName", "BATTMON");

            KernelInstance.Bind<IBatteryDataReporter>()
                .To<BatteryDataReporter>()
                .InSingletonScope();

            KernelInstance.Bind<IBatteryDataCollector>()
                .To<Win32BatteryManagementObjectSearcher>()
                .InSingletonScope()
                .WithConstructorArgument("query", "SELECT * FROM Win32_Battery");

            KernelInstance.Bind<IBatteryInfoFactory>()
                .ToFactory()
                .InSingletonScope();

            KernelInstance.Bind<Program>()
                .ToSelf();

            KernelInstance.Bind<ILog>().ToMethod(context =>
                LogManager.GetLogger(context.Request.Target.Member.ReflectedType));

        }
    }
}
