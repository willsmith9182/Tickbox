using System;
using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects
{
    public interface IDataUnitOfWork :IComitable
    {
        int GetNextId<TDataType>(Func<TDataType, int> del) where TDataType : class, IEntity;

        /// <summary>
        /// The get item.
        /// </summary>
        /// <param name="del">
        /// The expression to to identify the item.
        /// </param>
        /// <returns>
        /// The <see cref="TDataType"/>.
        /// </returns>
        TDataType GetItem<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity;

        TDataType GetItemScaffold<TDataType>(Func<TDataType, bool> del) where TDataType : class, IScaffold;

        IQueryable<TDataType> GetAllScaffold<TDataType>() where TDataType : class, IScaffold;
        IQueryable<TDataType> GetAllScaffold<TDataType>(bool tracking) where TDataType : class, IScaffold;

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable{T}"/>.
        /// </returns>
        IQueryable<TDataType> GetAll<TDataType>() where TDataType : class, IEntity;

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="tracking">
        /// The tracking.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<TDataType> GetAll<TDataType>(bool tracking) where TDataType : class, IEntity;

        /// <summary>
        /// The create, adds a given poco to the relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Create<TDataType>(TDataType item) where TDataType : class, IEntity;

        /// <summary>
        /// The create, adds an <see cref="IList{TDataType}"/> to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The pocos to create.
        /// </param>
        void Create<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;

        /// <summary>
        /// The update, adds a given poco back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Update<TDataType>(TDataType item) where TDataType : class, IEntity;

        /// <summary>
        /// The update, adds an <see cref="IList{TDataType}"/> back into context in a modified state to the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void Update<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;

        /// <summary>
        /// The delete, removes a given poco from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        void Delete<TDataType>(TDataType item) where TDataType : class, IEntity;

        /// <summary>
        /// The delete, removes an <see cref="IList{TDataType}"/> from the supplied relevant Set in the context.
        /// </summary>
        /// <param name="items">
        /// The items.
        /// </param>
        void Delete<TDataType>(IEnumerable<TDataType> items) where TDataType : class, IEntity;
        
        bool Exists<TDataType>(Func<TDataType, bool> del) where TDataType : class, IEntity;
    }
}
