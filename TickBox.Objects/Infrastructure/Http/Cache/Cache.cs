
using System;
using System.Web;

namespace TickBox.Objects.Http
{
    public class Cache<T> : ICache<T> where T : class, new()
    {
        private readonly HttpSessionStateBase sessionStore;

        private readonly string key;

        private readonly SessionItem<T> myItem;

        public Cache(HttpSessionStateBase sessionStore, string itemKey)
        {
            this.sessionStore = sessionStore;
            this.key = itemKey;

            if (this.sessionStore == null)
            {
                throw new NullReferenceException("Session is null, please check HttpContext");
            }
            if (this.sessionStore[key] == null)
            {
                this.sessionStore[key] = new SessionItem<T>();
            }
            this.myItem = this.sessionStore[key] as SessionItem<T>;

            if (this.myItem.IsDirty)
            {
                this.myItem.Item = new T();
            }
        }

        public bool IsDirty
        {
            get
            {
                return this.myItem.IsDirty;
            }
        }

        #region Implementation of ICache<T>

        public T RetrieveItem()
        {
            return this.myItem.Item;
        }

        public void SetItem(T item)
        {
            this.myItem.Item = item;
        }

        public void SetDirty()
        {
            this.myItem.IsDirty = true;
        }

        public void Reset()
        {
            this.myItem.Item = new T();
            this.myItem.IsDirty = false;
        }

        #endregion
    }
}
