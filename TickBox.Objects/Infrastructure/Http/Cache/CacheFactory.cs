// -----------------------------------------------------------------------
// <copyright file="CacheFactory.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Web;

namespace TickBox.Objects.Http
{
    public class CacheFactory : ICacheFactory
    {
        private readonly HttpSessionStateBase sessionStore;

        public CacheFactory(ISessionStoreBase sessionStore)
        {
            this.sessionStore = sessionStore.Session;
        }

        #region Implementation of ICacheFactory

        public ICache<T> CreateCache<T>(string sessionKey) where T : class, new()
        {
            return new Cache<T>(this.sessionStore, sessionKey);
        }

        #endregion
    }
}
