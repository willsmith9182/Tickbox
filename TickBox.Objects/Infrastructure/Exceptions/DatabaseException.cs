// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The database exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The database exception.
    /// </summary>
    [Serializable]
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseException"/> class.
        /// </summary>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public DatabaseException(Exception inner)
            : base("A Database action could not be completed", inner)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public DatabaseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
