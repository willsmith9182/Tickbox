// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialismController.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using System.Web.Mvc;
using Tickbox.Web.Models.View;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    /// The specialism controller.
    /// </summary>
    public class SpecialismController : ApiController
    {
   

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
            return null; //((object)null); //this.specialismManager.GetModel(id));
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
            return null; //((object)null); //this.specialismManager.GetModel());
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
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(SpecialismViewModel specialismModel)
        {
            //var newId = this.specialismManager.Create(specialismModel);
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
            return null; //((object)null); //this.specialismManager.GetModel(id));
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
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(SpecialismViewModel specialismModel)
        {
            //this.specialismManager.Update(specialismModel);
            return null; //"Edit", (object)null); // new { id = specialismModel.SpecialismId });
        }
    }
}
