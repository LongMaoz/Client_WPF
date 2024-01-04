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
    private IAbstractFactory<DataTimeControl> _dt;
    public MainViewModel(ILifetimeScope scope,IAbstractFactory<DataTimeControl> dt)
    {
        _scope = scope;
        _dt = dt;
        UpdateMainContent();
    }

    [RelayCommand]
    private void SwitchItem(FunctionEventArgs<object> info)
    {
        var head = (info.Info as SideMenuItem)?.Header.ToString();
        //通知消息
        WeakReferenceMessenger.Default.Send(new SwitchItemMessage(info.Info as SideMenuItem));
    }

    public RelayCommand<string> SelectCmd => new(Select);

    private void Select(string header) => Growl.Success(header);

    [ObservableProperty]
    private object? _subContent;


    private void UpdateMainContent()
    {
        WeakReferenceMessenger.Default.Register<SwitchItemMessage>(this, (r, x) =>
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

            // 创建 IAbstractFactory<> 的类型
            var factoryGenericType = typeof(IAbstractFactory<>);

            // 使用相应的 type 创建泛型
            var factoryType = factoryGenericType.MakeGenericType(type);

            // 使用反射调用 Autofac 的 Resolve 方法
            var service = _scope.Resolve(factoryType);

            // 获取 `Create` 方法
            MethodInfo createMethod = factoryType.GetMethod("Create");

            // 确保找到 `Create` 方法
            if (createMethod == null)
            {
                throw new Exception("Create method not found in the service.");
            }

            // 运行 `Create` 方法并将结果赋给 SubContent
            SubContent = createMethod.Invoke(service, null);
        });
    }


}