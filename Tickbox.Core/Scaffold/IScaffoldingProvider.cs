namespace Tickbox.Core.Scaffold
{
    public interface IScaffoldingProvider
    {
        void CreateScaffold<TEntity>(TEntity newItem);
    }
}
