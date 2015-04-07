// --------------------------------------------------------------------------------------------------------------------
// <copyright file="sessionStoreBase.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The session store base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web;

namespace Tickbox.Core.Web.Session
{
    /// <summary>
    /// The session store base.
    /// </summary>
    internal class SessionStoreBase : ISessionStoreBase
    {
 /// <summary>
        /// The http context.
        /// </summary>
        private readonly HttpContextBase httpContext;

        /// <summary>
        /// Initialises a new instance of the <see cref="SessionStoreBase"/> class.
        /// </summary>
        /// <param name="contextBase">
        /// The context Base.
        /// </param>
        public SessionStoreBase(HttpContextBase contextBase)
        {
            this.httpContext = contextBase;
        }

        /// <summary>
        /// Gets the session.
        /// </summary>
        public HttpSessionStateBase Session
        {
            get
            {
                return this.httpContext.Session;
            }
        }
    }
}
