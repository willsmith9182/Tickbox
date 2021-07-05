using System;
using System.Web;
using Tickbox.Core.Cache;
using Tickbox.Core.Web.Session;

namespace Tickbox.Core.Web.Cache
{
    internal class WebCache<T> : ICache<T> where T : class, new()
    {
        private readonly string key;
        private readonly SessionItem<T> myItem;
        private readonly HttpSessionStateBase sessionStore;

        public WebCache(HttpSessionStateBase sessionStore, string itemKey)
        {
            this.sessionStore = sessionStore;
            key = itemKey;

            if (this.sessionStore == null)
            {
                throw new NullReferenceException("Session is null, please check HttpContext");
            }
            if (this.sessionStore[key] == null)
            {
                this.sessionStore[key] = new SessionItem<T>();
            }
            myItem = this.sessionStore[key] as SessionItem<T>;

            if (myItem.IsDirty)
            {
                myItem.Item = new T();
            }
        }

        public bool IsDirty
        {
            get { return myItem.IsDirty; }
        }

        #region Implementation of ICache<T>

        public T RetrieveItem()
        {
            return myItem.Item;
        }

        public void SetItem(T item)
        {
            myItem.Item = item;
        }

        public void SetDirty()
        {
            myItem.IsDirty = true;
        }

        public void Reset()
        {
            myItem.Item = new T();
            myItem.IsDirty = false;
        }

        #endregion
    }
}