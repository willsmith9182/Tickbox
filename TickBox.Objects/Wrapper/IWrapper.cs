// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Wrapper interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace TickBox.Objects
{
    /// <summary>
    /// The Wrapper interface.
    /// </summary>
    /// <typeparam name="TPoco">
    /// poco type the wrapper is for
    /// </typeparam>
    public interface IWrapper<TPoco> where TPoco : class, new()
    {
        IEnumerable<TPoco> GetAll();

        /// <summary>
        /// The create new.
        /// </summary>
        /// <returns>
        /// The <see cref="TPoco"/>.
        /// </returns>
        TPoco CreateNew();

        /// <summary>
        /// The get template.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TPoco"/>.
        /// </returns>
        TPoco GetItem(int id);
        
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TPoco"/>.
        /// </returns>
        TPoco Create(TPoco item, bool immediateSave);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="TPoco"/>.
        /// </returns>
        TPoco Update(TPoco item, bool immediateSave);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id, bool immediateSave);
    }
}
