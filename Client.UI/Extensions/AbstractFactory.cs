using System;

namespace Client.UI.Extensions;

/// <summary>
/// 抽象工厂
/// </summary>
/// <typeparam name="T"></typeparam>
public class AbstractFactory<T> : IAbstractFactory<T>
{
    private readonly Func<T> _factory;

    public AbstractFactory(Func<T> factory)
    {
        _factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}