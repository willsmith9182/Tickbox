using System;
using Mehdime.Entity;

namespace Tickbox.Core.Scaffold
{
    public interface IScaffoldDefinition
    {
        Type ScaffoldType { get; }
        void CreateScaffold<T>(IAmbientDbContextLocator contextLocator, object newItem);
    }
}
