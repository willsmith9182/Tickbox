// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataNotFoundException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The data not found exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The data not found exception.
    /// </summary>
    public class DataNotFoundException<T> : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DataNotFoundException"/> class.
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
        public DataNotFoundException(int id, Exception innerException)
            : base(string.Format("Unable to locate {0} [ID: {1}]", typeof(T).Name, id), innerException)
        {
        }
    }
}
