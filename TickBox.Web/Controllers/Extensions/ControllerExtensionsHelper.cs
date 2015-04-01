// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerExtensionsHelper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The controller extensions helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;
using System.Web.Mvc;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The controller extensions helper.
    /// </summary>
    public static class ControllerExtensionsHelper
    {
        /// <summary>
        /// The partial view to string.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string PartialViewToString(this Controller controller)
        {
            return controller.PartialViewToString(null, null);
        }

        /// <summary>
        /// The render partial view to string.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string RenderPartialViewToString(this Controller controller, string viewName)
        {
            return controller.PartialViewToString(viewName, null);
        }

        /// <summary>
        /// The render partial view to string.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string RenderPartialViewToString(this Controller controller, object model)
        {
            return controller.PartialViewToString(null, model);
        }

        /// <summary>
        /// The partial view to string.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        /// <param name="viewName">
        /// The view name.
        /// </param>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string PartialViewToString(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");
            }

            controller.ViewData.Model = model;

            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}