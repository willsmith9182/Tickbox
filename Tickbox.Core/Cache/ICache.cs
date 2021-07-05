namespace Tickbox.Core.Cache
{
    public interface ICache<T> where T : class
    {
        bool IsDirty { get; }
        T RetrieveItem();
        void SetItem(T item);
        void SetDirty();
        void Reset();
    }
}