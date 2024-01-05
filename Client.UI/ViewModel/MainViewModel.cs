using Client.UI.Message;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using HandyControl.Data;
using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Client.UI.Extensions;
using Client.UI.UserControl;
using static System.Formats.Asn1.AsnWriter;

namespace Client.UI.ViewModel;

public partial class MainViewModel: ObservableObject
{
    private readonly ILifetimeScope _scope;
    public MainViewModel(ILifetimeScope scope)
    {
        _scope = scope;
        UpdateMainContent();
    }

    [RelayCommand]
    private void SwitchItem(FunctionEventArgs<object> info)
    {
        var head = (info.Info as SideMenuItem)?.Header.ToString();
        //通知消息
        WeakReferenceMessenger.Default.Send(new SwitchItemMessage(info.Info as SideMenuItem));
    }

    [ObservableProperty]
    private object? _subContent;


    private void UpdateMainContent()
    {
        //注册Messenger
        WeakReferenceMessenger.Default.Register<MainViewModel,SwitchItemMessage>(this, (r, x) =>
        {
            if (SubContent is IDisposable disposable)
            {
                disposable.Dispose();
            }
            Type type = Type.GetType($"{typeof(MainViewModel).Assembly.GetName().Name}.UserControl.{x.Value.Name}");

            if (type == null)
            {
                return;
            }

            var factoryGenericType = typeof(IAbstractFactory<>);
            var factoryType = factoryGenericType.MakeGenericType(type);
            var service = _scope.Resolve(factoryType);
            MethodInfo createMethod = factoryType.GetMethod("Create");
            if (createMethod == null)
            {
                //没有勾子Create
                return;
            }
            SubContent = createMethod.Invoke(service, null);
        });
    }


}