// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISpecialismManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The SpecialismManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Web.Models.Specialism;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The SpecialismManager interface.
    /// </summary>
    public interface ISpecialismManager
    {
        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="SpecialismViewModel"/>.
        /// </returns>
        SpecialismViewModel GetModel();

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SpecialismViewModel"/>.
        /// </returns>
        SpecialismViewModel GetModel(int id);

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Create(SpecialismViewModel model);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        void Update(SpecialismViewModel model);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Delete(int id);
    }
}
