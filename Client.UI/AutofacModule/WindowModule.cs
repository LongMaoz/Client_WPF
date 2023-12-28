using Autofac;

namespace Client.UI.AutofacModule;

public class WindowModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}