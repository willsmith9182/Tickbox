// -------------------------

using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects
{
    /// <summary>
    /// The inherited poco splitter.
    /// </summary>
    /// <typeparam name="TBasePoco">
    /// base poco from context
    /// </typeparam>
    public class InheritedPocoSplitter<TBasePoco> : IInheritedPocoSplitter<TBasePoco> where TBasePoco : class, IBaseEntity
    {
        /// <summary>
        /// The items.
        /// </summary>
        private readonly ICollection<TBasePoco> items;

        /// <summary>
        /// Initialises a new instance of the <see cref="InheritedPocoSplitter{TBasePoco}"/> class.
        /// </summary>
        /// <param name="sourceItems">
        /// The source items.
        /// </param>
        public InheritedPocoSplitter(ICollection<TBasePoco> sourceItems)
        {
            this.items = sourceItems;
        }

        /// <summary>
        /// The get derived type.
        /// </summary>
        /// <typeparam name="TPocoType">
        ///  the derived poco type to retrieve
        /// </typeparam>
        /// <returns>
        /// The <see cref="ICollection{TPocoType}"/>.
        /// </returns>
        public ICollection<TPocoType> GetDerivedType<TPocoType>() where TPocoType : class, TBasePoco, IInheritedPoco<TBasePoco>
        {
            return this.items.OfType<TPocoType>().ToList();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Remove(TBasePoco item)
        {
            this.items.Remove(item);
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="TPocoType">
        /// the derived poco type to add to list
        /// </typeparam>
        public void Add<TPocoType>(TPocoType item) where TPocoType : class, TBasePoco, IInheritedPoco<TBasePoco>
        {
            this.items.Add(item);
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="ICollection{TBasePoco}"/>.
        /// </returns>
        public ICollection<TBasePoco> GetAll()
        {
            return this.items;
        }
    }
}
