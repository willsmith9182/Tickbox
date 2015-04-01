// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuWrapper.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The menu wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using TickBox.Objects;

namespace TickBox.Business
{
    /// <summary>
    /// The menu wrapper.
    /// </summary>
    public class MenuWrapper : IMenuWrapper
    {
        /// <summary>
        /// The data unit of work.
        /// </summary>
        private readonly IDataUnitOfWork dataUnitOfWork;

        /// <summary>
        /// Initialises a new instance of the <see cref="MenuWrapper"/> class.
        /// </summary>
        /// <param name="dataUnitOfWork">
        /// The data unit of work.
        /// </param>
        public MenuWrapper(IDataUnitOfWork dataUnitOfWork)
        {
            this.dataUnitOfWork = dataUnitOfWork;
        }

        #region Implementation of IMenuWrapper

        /// <summary>
        /// The get taxonomies.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Taxonomy}"/>.
        /// </returns>
        public bool HasTaxonomies()
        {
            return this.dataUnitOfWork.GetAll<Taxonomy>().Any();
        }

        /// <summary>
        /// The get templates.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Template}"/>.
        /// </returns>
        public bool HasTemplates()
        {
            return this.dataUnitOfWork.GetAll<Template>().Any();
        }

        /// <summary>
        /// The get specialisms.
        /// </summary>
        /// <returns>
        /// The <see cref="IList{Specialism}"/>.
        /// </returns>
        public bool HasSpecialisms()
        {
            return this.dataUnitOfWork.GetAll<Specialism>().Any();
        }

        #endregion
    }
}
