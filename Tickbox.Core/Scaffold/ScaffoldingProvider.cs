using System;
using System.Collections.Generic;
using System.Linq;
using Mehdime.Entity;

namespace Tickbox.Core.Scaffold
{
    public class ScaffoldingProvider : IScaffoldingProvider
    {
        private readonly IAmbientDbContextLocator _contextLocator;
        private readonly Dictionary<Type, IScaffoldDefinition> _typeActions;

        public ScaffoldingProvider(IAmbientDbContextLocator contextLocator, IEnumerable<IScaffoldDefinition> definitions)
        {
            _contextLocator = contextLocator;
            _typeActions = definitions.ToDictionary(d => d.ScaffoldType, d => d);
        }

        public void CreateScaffold<TEntity>(TEntity newItem)
        {
            var entity = typeof(TEntity);
            if (_typeActions.ContainsKey(entity))
            {
                _typeActions[entity].CreateScaffold<TEntity>(_contextLocator,newItem);
            }
        }
    }
}