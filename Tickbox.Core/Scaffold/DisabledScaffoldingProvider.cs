namespace Tickbox.Core.Scaffold
{
    internal class DisabledScaffoldingProvider :IScaffoldingProvider
    {
        public void CreateScaffold<TEntity>(TEntity newItem)
        {
        }
    }
}
