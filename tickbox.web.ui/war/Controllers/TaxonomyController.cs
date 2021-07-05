using System.Web.Http;
using System.Web.Mvc;
using Tickbox.Web.Models.View;

namespace Tickbox.Web.Controllers
{
    /// <summary>
    ///     The taxonomy controller.
    /// </summary>
    public class TaxonomyController : ApiController
    {
        ///// <summary>
        ///// The repository.
        ///// </summary>
        //private readonly ITaxonomyManager taxonomyManager;

        ///// <summary>
        ///// The taxonomy edit manager.
        ///// </summary>
        //private readonly ITaxonomyEditManager taxonomyEditManager;

        /// <summary>
        ///     The index.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Index()
        {
            return null; //((object)null); //this.taxonomyManager.GetAll());
        }

        /// <summary>
        ///     The view.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult View(int id)
        {
            return null; //((object)null); //this.taxonomyManager.GetModel(id));
        }

        /// <summary>
        ///     The create.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Create()
        {
            return null; //((object)null); //this.taxonomyEditManager.GetModel());
        }

        /// <summary>
        ///     The create.
        /// </summary>
        /// <param name="taxonomyModel">
        ///     The taxonomy model.
        /// </param>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(TaxonomyEditViewModel taxonomyModel)
        {
            //var newId = this.taxonomyEditManager.Create(taxonomyModel);
            return null; //"View", (object)null); //new { id = newId });
        }

        /// <summary>
        ///     The edit.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Edit(int id)
        {
            return null; //((object)null); //this.taxonomyEditManager.GetModel(id));
        }

        /// <summary>
        ///     The edit.
        /// </summary>
        /// <param name="taxonomyModel">
        ///     The taxonomy model.
        /// </param>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(TaxonomyEditViewModel taxonomyModel)
        {
            //this.taxonomyEditManager.Update(taxonomyModel);
            return null; //"Edit", (object)null); // new { id = taxonomyModel.TaxonomyId });
        }
    }
}