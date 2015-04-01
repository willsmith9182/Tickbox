namespace TickBox.Objects.Http
{
    public interface ICache<T> where T : class
    {
        T RetrieveItem();

        bool IsDirty { get; }

        void SetItem(T item);

        void SetDirty();

        void Reset();
    }
}
