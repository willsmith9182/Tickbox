// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomyController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The taxonomy controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using TickBox.Web.Manager;
using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The taxonomy controller.
    /// </summary>
    public class TaxonomyController : Controller
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ITaxonomyManager taxonomyManager;

        /// <summary>
        /// The taxonomy edit manager.
        /// </summary>
        private readonly ITaxonomyEditManager taxonomyEditManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="TaxonomyController"/> class.
        /// </summary>
        /// <param name="taxonomyManager">
        /// The taxonomy manager.
        /// </param>
        /// <param name="taxonomyEditManager">
        /// The taxonomy Edit Manager.
        /// </param>
        public TaxonomyController(ITaxonomyManager taxonomyManager, ITaxonomyEditManager taxonomyEditManager)
        {
            this.taxonomyManager = taxonomyManager;
            this.taxonomyEditManager = taxonomyEditManager;
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View(this.taxonomyManager.GetAll());
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
            return this.View(this.taxonomyManager.GetModel(id));
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
            return this.View(this.taxonomyEditManager.GetModel());
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="taxonomyModel">
        /// The taxonomy model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Create(TaxonomyEditViewModel taxonomyModel)
        {
            var newId = this.taxonomyEditManager.Create(taxonomyModel);
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
            return this.View(this.taxonomyEditManager.GetModel(id));
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="taxonomyModel">
        /// The taxonomy model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Edit(TaxonomyEditViewModel taxonomyModel)
        {
            this.taxonomyEditManager.Update(taxonomyModel);
            return this.RedirectToAction("Edit", new { id = taxonomyModel.TaxonomyId });
        }
    }
}