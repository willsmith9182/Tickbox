// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoAvailalbeIdsException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The no available ids exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace TickBox.Objects
{
    /// <summary>
    /// The no available ids exception.
    /// </summary>
    public class NoAvailalbeIdsException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NoAvailalbeIdsException"/> class.
        /// </summary>
        public NoAvailalbeIdsException()
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NoAvailalbeIdsException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public NoAvailalbeIdsException(string message)
            : base(message + "please increase that data type to int64.")
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NoAvailalbeIdsException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public NoAvailalbeIdsException(string message, Exception inner)
            : base(message + "please increase that data type to int64.", inner)
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NoAvailalbeIdsException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected NoAvailalbeIdsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}