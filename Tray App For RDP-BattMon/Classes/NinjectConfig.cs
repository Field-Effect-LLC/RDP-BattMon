using log4net;
using Ninject;
using Ninject.Modules;
using System;

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
           
            KernelInstance.Bind<ILog>().ToMethod(context =>
                LogManager.GetLogger(context.Request.Target.Member.ReflectedType));

        }
    }
}
