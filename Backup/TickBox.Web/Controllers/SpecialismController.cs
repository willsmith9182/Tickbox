// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialismController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Mvc;
using TickBox.Web.Manager;
using TickBox.Web.Models.Specialism;

namespace TickBox.Web.Controllers
{
    /// <summary>
    /// The specialism controller.
    /// </summary>
    public class SpecialismController : Controller
    {
        /// <summary>
        /// The repository.
        /// </summary>
        private readonly ISpecialismManager specialismManager;

        /// <summary>
        /// Initialises a new instance of the <see cref="SpecialismController"/> class.
        /// </summary>
        /// <param name="specialismManager">
        /// The specialism manager.
        /// </param>
        public SpecialismController(ISpecialismManager specialismManager)
        {
            this.specialismManager = specialismManager;
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
            return this.View(this.specialismManager.GetModel(id));
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
            return this.View(this.specialismManager.GetModel());
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="specialismModel">
        /// The specialism model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Create(SpecialismViewModel specialismModel)
        {
            var newId = this.specialismManager.Create(specialismModel);
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
            return this.View(this.specialismManager.GetModel(id));
        }

        /// <summary>
        /// The edit.
        /// </summary>
        /// <param name="specialismModel">
        /// The specialism model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult Edit(SpecialismViewModel specialismModel)
        {
            this.specialismManager.Update(specialismModel);
            return this.RedirectToAction("Edit", new { id = specialismModel.SpecialismId });
        }
    }
}
