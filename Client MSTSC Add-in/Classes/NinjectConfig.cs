using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FieldEffect.Interfaces;
using FieldEffect.Models;
using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace FieldEffect.Classes
{
    internal class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            KernelInstance.Bind<IManagementObjectSearcherFactory>()
                .ToFactory()
                .InSingletonScope();

            KernelInstance.Bind<IManagementObject>()
                .To<Win32BatteryManagementObject>()
                .InSingletonScope()
                .WithConstructorArgument("path", "Win32_Battery");

            KernelInstance.Bind<IBatteryInfo>()
                .To<WmiBatteryInfo>()
                .InSingletonScope();

            KernelInstance.Bind<TsClientAddIn>()
                .ToSelf()
                .InSingletonScope();
        }
    }
}
