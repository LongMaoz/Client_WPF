namespace Client.UI.Extensions;

public interface IAbstractFactory<T>
{
    T Create();
}