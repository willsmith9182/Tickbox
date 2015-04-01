// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Specialism;

namespace TickBox.Web.Mapper.Mappings.Specialism
{
    /// <summary>
    /// The specialism view model.
    /// </summary>
    public class Basic : IMappingProvider<Objects.Specialism, SpecialismViewModel>
    {
        #region Implementation of IMappingProvider<Specialism,SpecialismViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Specialism"/>.
        /// </returns>
        public Objects.Specialism CreateObject(SpecialismViewModel item)
        {
            return new Objects.Specialism
                       {
                           IsScaffold = item.IsScaffold,
                           SpecialismId = item.SpecialismId,
                           SpecialismTitle = item.SpecialismTitle
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Specialism"/>.
        /// </returns>
        public SpecialismViewModel CreateObject(Objects.Specialism item)
        {
            return new SpecialismViewModel
                       {
                           IsScaffold = item.IsScaffold,
                           SpecialismId = item.SpecialismId,
                           SpecialismTitle = item.SpecialismTitle
                       };
        }

        #endregion
    }
}