// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKeyComparable.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The KeyComparable interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TickBox.Objects
{
    /// <summary>
    /// The KeyComparable interface.
    /// </summary>
    /// <typeparam name="TPoco">
    /// the poco type
    /// </typeparam>
    public interface IKeyComparable<in TPoco> where TPoco : class
    {
        /// <summary>
        /// The keys match.
        /// </summary>
        /// <param name="other">
        /// The other.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool KeysMatch(TPoco other);
        
        int Key { get; }
    }
}
