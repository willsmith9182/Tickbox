using System.Web;

namespace Tickbox.Core.Web.Session
{
    /// <summary>
    ///     The SessionStoreBase interface.
    /// </summary>
    public interface ISessionStoreBase
    {
        /// <summary>
        ///     Gets the session.
        /// </summary>
        HttpSessionStateBase Session { get; }
    }
}