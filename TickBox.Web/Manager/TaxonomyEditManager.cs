// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxonomyEditManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The taxonomy manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using TickBox.Objects;
using TickBox.Web.Models.Specialism;
using TickBox.Web.Models.Taxonomy;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The taxonomy manager.
    /// </summary>
    public class TaxonomyEditManager : ITaxonomyEditManager
    {
        /// <summary>
        /// The taxonomy mapper.
        /// </summary>
        private readonly IMapper<Taxonomy, TaxonomyEditViewModel> taxonomyMapper;

        /// <summary>
        /// The taxonomy wrapper.
        /// </summary>
        private readonly ITaxonomyWrapper taxonomyWrapper;

        /// <summary>
        /// The template specialist wrapper.
        /// </summary>
        private readonly ITemplateWrapper templateWrapper;

        /// <summary>
        /// The specialism wrapper.
        /// </summary>
        private readonly ISpecialismWrapper specialismWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="TaxonomyEditManager"/> class.
        /// </summary>
        /// <param name="taxonomyMapper">
        /// The taxonomy mapper.
        /// </param>
        /// <param name="taxonomyWrapper">
        /// The taxonomy wrapper.
        /// </param>
        /// <param name="templateWrapper">
        /// The template Wrapper.
        /// </param>
        /// <param name="specialismWrapper">
        /// The specialism Wrapper.
        /// </param>
        /// <param name="taxonomySpecialismWrapper">
        /// The taxonomy Specialism Wrapper.
        /// </param>
        public TaxonomyEditManager(
            IMapper<Taxonomy, TaxonomyEditViewModel> taxonomyMapper,
            ITaxonomyWrapper taxonomyWrapper,
            ITemplateWrapper templateWrapper,
            ISpecialismWrapper specialismWrapper)
        {
            this.taxonomyMapper = taxonomyMapper;
            this.taxonomyWrapper = taxonomyWrapper;
            this.templateWrapper = templateWrapper;
            this.specialismWrapper = specialismWrapper;

        }

        #region Implementation of ITaxonomyEditManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="TaxonomyEditViewModel"/>.
        /// </returns>
        public TaxonomyEditViewModel GetModel()
        {
            var viewModel = this.taxonomyMapper.Map(this.taxonomyWrapper.CreateNew());
            viewModel.AvailableSpecialisms = this.specialismWrapper.GetAll().Where(s => !s.IsScaffold).Select(i => new SpecialismCheckBoxViewModel
                                                                                                {
                                                                                                    IsScaffold = false,
                                                                                                    SpecialismId = i.SpecialismId,
                                                                                                    SpecialismTitle = i.SpecialismTitle,
                                                                                                    Selected = true
                                                                                                }).ToList();
            viewModel.AvailableTemplates = this.templateWrapper.CreateSelectList();
            return viewModel;
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="TaxonomyEditViewModel"/>.
        /// </returns>
        public TaxonomyEditViewModel GetModel(int id)
        {
            var taxonomy = this.taxonomyWrapper.GetItem(id);
            var viewModel = this.taxonomyMapper.Map(taxonomy);
            viewModel.AvailableTemplates = this.templateWrapper.CreateSelectList();
            var specialisms = this.specialismWrapper.GetAll();
            viewModel.AvailableSpecialisms = specialisms.Select(i => new SpecialismCheckBoxViewModel
                                                                            {
                                                                                IsScaffold = viewModel.IsScaffold,
                                                                                SpecialismId = i.SpecialismId,
                                                                                SpecialismTitle = i.SpecialismTitle,
                                                                                //Selected = taxonomy.TaxonomySpecialisms.Any(s => s.SpecialismId == i.SpecialismId)
                                                                            }).ToList();

            return viewModel;
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
        public int Create(TaxonomyEditViewModel model)
        {
            return this.taxonomyWrapper.Create(this.taxonomyMapper.Reverse(model), true).TaxonomyId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(TaxonomyEditViewModel model)
        {
            //var taxonomy = this.taxonomyWrapper.GetItem(model.TaxonomyId);
            //foreach (var item in taxonomy.TaxonomySpecialisms.ToList())
            //{
            //    if (model.AvailableSpecialisms.Where(i => i.Selected).All(i => i.SpecialismId != item.SpecialismId))
            //    {
            //        taxonomy.TaxonomySpecialisms.Remove(item);
            //    }
            //}
            //foreach (var item in model.AvailableSpecialisms.Where(i => i.Selected))
            //{
            //    if (taxonomy.TaxonomySpecialisms.Any(ts => ts.SpecialismId == item.SpecialismId))
            //    {
            //        var newLink = new TaxonomySpecialism
            //            {
            //                IsScaffold = item.IsScaffold,
            //                Specialism = this.specialismWrapper.GetItem(item.SpecialismId),
            //                SpecialismId = item.SpecialismId,
            //                Taxonomy = taxonomy,
            //                TaxonomyId = taxonomy.TaxonomyId
            //            };

            //        taxonomy.TaxonomySpecialisms.Add();
            //    }

            //}

            //this.taxonomyWrapper.Update(taxonomy, true);
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