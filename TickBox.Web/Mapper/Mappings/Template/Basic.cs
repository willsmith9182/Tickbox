// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Basic.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The Template view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Template;

namespace TickBox.Web.Mapper.Mappings.Template
{
    /// <summary>
    /// The Template view model.
    /// </summary>
    public class Basic : IMappingProvider<Objects.Template, TemplateViewModel>
    {
        #region Implementation of IMappingProvider<Template,TemplateViewModel>

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Template"/>.
        /// </returns>
        public Objects.Template CreateObject(TemplateViewModel item)
        {
            return new Objects.Template
                       {
                           DocumentLink = item.DocumentLink,
                           IsScaffold = item.IsScaffold,
                           Name = item.Name,
                           TemplateId = item.TemplateId
                       };
        }

        /// <summary>
        /// The create object.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Template"/>.
        /// </returns>
        public TemplateViewModel CreateObject(Objects.Template item)
        {
            return new TemplateViewModel
                       {
                           DocumentLink = item.DocumentLink,
                           IsScaffold = item.IsScaffold,
                           Name = item.Name,
                           TemplateId = item.TemplateId
                       };
        }

        #endregion
    }
}