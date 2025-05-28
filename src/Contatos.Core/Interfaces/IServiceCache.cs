namespace Contatos.Core.Interfaces
{
    public interface IServiceCache
    {
        bool TryGetValue<T>(string key, out T value);
        void Set<T>(string key, T value, TimeSpan expirationTime);
        void Remove(string key);
    }
}
