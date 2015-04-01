// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TemplateController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The template controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using TickBox.Web.Manager;
using TickBox.Web.Models.Template;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The template controller.
    /// </summary>
    public class TemplateController : Controller
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ITemplateManager<TemplateViewModel> templateManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="TemplateController"/> class.
        /// </summary>
        /// <param name="templateManager">
        /// The template manager.
        /// </param>
        public TemplateController(ITemplateManager<TemplateViewModel> templateManager)
        {
            this.templateManager = templateManager;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.RedirectToAction("Index", "Home");
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
        [HttpGet]
        public ActionResult View(int id)
        {
            return this.View("View", this.templateManager.GetModel(id));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Create()
        {
            return this.View("Create", this.templateManager.GetModel());
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
        [HttpPost]
        public ActionResult Create(TemplateViewModel templateModel)
        {
            var newId = this.templateManager.Create(templateModel);
            return this.RedirectToAction("View", new { id = newId });
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return this.View("Edit", this.templateManager.GetModel(id));
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
        [HttpPost]
        public ActionResult Edit(TemplateViewModel templateModel)
        {
            this.templateManager.Update(templateModel);
            return this.RedirectToAction("Edit", new { id = templateModel.TemplateId });
        }
    }
}
