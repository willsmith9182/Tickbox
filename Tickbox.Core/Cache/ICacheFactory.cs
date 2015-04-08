namespace Tickbox.Core.Cache
{
    public interface ICacheFactory
    {
        ICache<T> CreateCache<T>(string sessionKey) where T : class, new();
    }
}