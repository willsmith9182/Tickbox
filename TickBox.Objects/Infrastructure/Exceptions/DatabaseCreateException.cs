// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseCreateException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The database create exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The database create exception.
    /// </summary>
    public class DatabaseCreateException<T> : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseCreateException"/> class.
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
        public DatabaseCreateException(int id, Exception innerException)
            : base(string.Format("Unable to create {0} [Proposed ID: {1}]", typeof(T).Name, id), innerException)
        {
        }
    }
}
