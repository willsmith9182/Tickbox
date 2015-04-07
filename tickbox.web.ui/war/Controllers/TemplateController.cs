// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The template controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Mvc;
using Tickbox.Web.Models.View;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    /// The template controller.
    /// </summary>
    public class TemplateController : ApiController
    {


        /// <summary>
        /// Initialises a new instance of the <see cref="TemplateController"/> class.
        /// </summary>
        /// <param name="templateManager">
        /// The template manager.
        /// </param>
        public TemplateController()
        {
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return null; //"Index", "Home");
        }

        /// <summary>
        /// The view.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult View(int id)
        {
            return null; //("View", null); //this.templateManager.GetModel(id));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
            return null; //("Create", null); //this.templateManager.GetModel());
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="templateModel">
        /// The template model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(TemplateViewModel templateModel)
        {
            //var newId = this.templateManager.Create(templateModel);
            return null; //"View", (object)null); //new { id = newId });
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            return null; //("Edit", null); //this.templateManager.GetModel(id));
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="templateModel">
        /// The template model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(TemplateViewModel templateModel)
        {
           // this.templateManager.Update(templateModel);
            return null; //"Edit", (object)null); // new { id = templateModel.TemplateId });
        }
    }
}
