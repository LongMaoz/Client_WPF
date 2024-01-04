using Autofac;
using Client.Service.Interface;
using Client.Service.Services;
using Client.UI.ViewModel;

namespace Client.UI.AutofacModule;

public class ViewModelModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ExamSettingViewModel>().InstancePerDependency();
        builder.RegisterType<MainViewModel>().InstancePerDependency();
    }
}