// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseUpdateException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The database update exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The database update exception.
    /// </summary>
    public class DatabaseUpdateException<T> : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseUpdateException"/> class.
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
        public DatabaseUpdateException(int id, Exception innerException)
            : base(string.Format("Unable to update {0} [ID: {1}]", typeof(T).Name, id), innerException)
        {
        }
    }
}
