// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomyManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The taxonomy manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using TickBox.Objects;
using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The taxonomy manager.
    /// </summary>
    public class TaxonomyManager : ITaxonomyManager
    {
        /// <summary>
        /// The taxonomy mapper.
        /// </summary>
        private readonly IMapper<Taxonomy, TaxonomyViewModel> taxonomyMapper;

        /// <summary>
        /// The taxonomy wrapper.
        /// </summary>
        private readonly ITaxonomyWrapper taxonomyWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="TaxonomyManager"/> class.
        /// </summary>
        /// <param name="taxonomyMapper">
        /// The taxonomy mapper.
        /// </param>
        /// <param name="taxonomyWrapper">
        /// The taxonomy wrapper.
        /// </param>
        public TaxonomyManager(IMapper<Taxonomy, TaxonomyViewModel> taxonomyMapper, ITaxonomyWrapper taxonomyWrapper)
        {
            this.taxonomyMapper = taxonomyMapper;
            this.taxonomyWrapper = taxonomyWrapper;
        }

        #region Implementation of ITaxonomyManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TaxonomyViewModel"/>.
        /// </returns>
        public TaxonomyViewModel GetModel()
        {
            return this.taxonomyMapper.Map(this.taxonomyWrapper.CreateNew());
        }

        public IEnumerable<TaxonomyViewModel> GetAll()
        {
            return this.taxonomyMapper.Map(this.taxonomyWrapper.GetAll().ToList());
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TaxonomyViewModel"/>.
        /// </returns>
        public TaxonomyViewModel GetModel(int id)
        {
            return this.taxonomyMapper.Map(this.taxonomyWrapper.GetItem(id));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Create(TaxonomyViewModel model)
        {
            return this.taxonomyWrapper.Create(this.taxonomyMapper.Reverse(model), true).TaxonomyId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(TaxonomyViewModel model)
        {
            this.taxonomyWrapper.Update(this.taxonomyMapper.Reverse(model), true);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.taxonomyWrapper.Delete(id, true);
        }

        #endregion
    }
}