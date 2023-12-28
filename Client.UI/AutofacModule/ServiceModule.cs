using Autofac;
using Client.Service.Interface;
using Client.Service.Services;

namespace Client.UI.AutofacModule;

public class ServiceModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TestService>().As<ITestService>().InstancePerDependency();
    }
}