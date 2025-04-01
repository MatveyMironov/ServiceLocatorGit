public interface IServiceLocator
{
    bool TryGetService<T>(out T service);
}
