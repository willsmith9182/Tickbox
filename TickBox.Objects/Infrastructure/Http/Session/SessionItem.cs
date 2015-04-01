
namespace TickBox.Objects.Http
{
    public class SessionItem<T> where T : class, new()
    {
        public SessionItem()
        {
            this.Item = new T();
        }

        public T Item { get; set; }

        public bool IsDirty { get; set; }
    }
}
