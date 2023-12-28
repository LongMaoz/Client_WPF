using Autofac;
using Client.UI.Extensions;

namespace Client.UI.AutofacModule;

public class WindowModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddFormFactory<TestWindow>();
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}