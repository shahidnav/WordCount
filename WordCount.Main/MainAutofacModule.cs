using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace WordCount.Main
{
    public class MainAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces();
        }
    }
}
