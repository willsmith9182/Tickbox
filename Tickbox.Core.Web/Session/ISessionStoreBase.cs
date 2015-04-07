// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISessionStoreBase.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The SessionStoreBase interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web;

namespace Tickbox.Core.Web.Session
{
    /// <summary>
    /// The SessionStoreBase interface.
    /// </summary>
    public interface ISessionStoreBase
    {
        /// <summary>
        /// Gets the session.
        /// </summary>
        HttpSessionStateBase Session { get; }
    }
}
