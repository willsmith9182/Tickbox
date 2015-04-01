// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseDeleteException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The database delete exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The database delete exception.
    /// </summary>
    public class DatabaseDeleteException<T> : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseDeleteException"/> class.
        /// </summary>
        /// <param name="dataType">
        /// The data type.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public DatabaseDeleteException(int id, Exception innerException)
            : base(string.Format("Unable to delete {0} [ID: {1}]", typeof(T).Name, id), innerException)
        {
        }
    }
}
