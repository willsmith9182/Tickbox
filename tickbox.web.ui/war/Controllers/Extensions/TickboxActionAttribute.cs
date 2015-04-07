// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TickboxActionAttribute.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The tickbox action attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Web.Mvc;
using Tickbox.Core.Notifications.Definitions.Implementations;
using Tickbox.Core.Notifications.Notifier;

namespace Tickbox.Web.Controllers.Extensions
{
    /// <summary>
    /// The tickbox action attribute.
    /// </summary>
    public class TickboxActionAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Gets or sets the notifier.
        /// </summary>
        public INotify Notifier { get; set; }

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.Notifier != null)
            {
                filterContext.Controller.ViewData.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList().ForEach(x => this.Notifier.Add<ErrorNotification>(string.Format("Validation:{0}", x), "Error!"));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}