using System.Web;
using Tickbox.Core.Cache;
using Tickbox.Core.Web.Session;

namespace Tickbox.Core.Web.Cache
{
    internal class WebCacheFactory : ICacheFactory
    {
        private readonly HttpSessionStateBase sessionStore;

        public WebCacheFactory(ISessionStoreBase sessionStore)
        {
            this.sessionStore = sessionStore.Session;
        }

        #region Implementation of ICacheFactory

        public ICache<T> CreateCache<T>(string sessionKey) where T : class, new()
        {
            return new WebCache<T>(sessionStore, sessionKey);
        }

        #endregion
    }
}