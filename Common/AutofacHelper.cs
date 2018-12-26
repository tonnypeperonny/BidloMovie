using Autofac;
using Common.AutofacModules;

namespace Common
{
    public class AutofacHelper
    {
        public static ContainerBuilder InitBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<BLModule>();
            builder.RegisterModule<DLModule>();

            return builder;
        }
    }
}

