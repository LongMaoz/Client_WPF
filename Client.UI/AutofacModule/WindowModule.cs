using Autofac;
using Client.UI.Extensions;
using Client.UI.UserControl;

namespace Client.UI.AutofacModule;

public class WindowModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.AddFormFactory<TestWindow>();
        builder.AddFormFactory<DataTimeControl>();
        builder.AddFormFactory<ExamSettingControl>();
        builder.RegisterType<MainWindow>().SingleInstance();
    }
}