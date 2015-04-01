// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnockoutModelException.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Custom Exception for Knockout Validation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace KnockoutObjects
{
    /// <summary>
    /// Custom Exception for Knockout Validation
    /// </summary>
    [Serializable]
    public class KnockoutModelException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="KnockoutModelException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public KnockoutModelException(string message)
            : base(message)
        {
        }
    }
}