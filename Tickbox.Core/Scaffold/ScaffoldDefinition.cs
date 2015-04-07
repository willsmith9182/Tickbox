using System;
using Mehdime.Entity;

namespace Tickbox.Core.Scaffold
{
    public abstract class ScaffoldDefinition<T> : IScaffoldDefinition
    {
        private Type _type;
        public Type ScaffoldType { get { return _type ?? (_type = typeof(T)); } }

        public void CreateScaffold<T1>(IAmbientDbContextLocator contextLocator, object newItem)
        {
            CreateScaffold(contextLocator, (T)newItem);
        }

        public abstract void CreateScaffold(IAmbientDbContextLocator contextLocator, T newItem);

    }
}