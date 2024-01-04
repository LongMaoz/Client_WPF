using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Client.UI.Extensions;

public static class ContainerExtensions
{
    public static void AddFormFactory<TForm>(this ContainerBuilder build)
        where TForm : class
    {
        build.RegisterType<TForm>().InstancePerDependency();//注册单例
        //注册委托
        build.Register<Func<TForm>>(context =>
        {
            var componentContext = context.Resolve<IComponentContext>();
            return () => componentContext.Resolve<TForm>();
        }).SingleInstance();
        //注册工厂
        build.RegisterType<AbstractFactory<TForm>>().As<IAbstractFactory<TForm>>().SingleInstance();
    }
}