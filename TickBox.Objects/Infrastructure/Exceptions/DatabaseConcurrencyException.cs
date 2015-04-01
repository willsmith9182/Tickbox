// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DatabaseConcurrencyException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The database concurrency exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The database concurrency exception.
    /// </summary>
    public class DatabaseConcurrencyException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseConcurrencyException"/> class.
        /// </summary>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public DatabaseConcurrencyException(Exception inner)
            : base("This update conflicts with another concurrent update.", inner)
        {
        }
    }
}
