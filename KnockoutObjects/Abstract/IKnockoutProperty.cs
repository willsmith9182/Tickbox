// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnockoutProperty.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Provides validation support to data annotated values when using KnockoutMVC wrapper
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KnockoutObjects
{
    /// <summary>
    /// Provides validation support to data annotated values when using KnockoutMVC wrapper
    /// </summary>
    public interface IKnockoutProperty
    {
        /// <summary>
        /// Gets a value indicating whether property is valid.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// Gets a value indicating whether has changes.
        /// </summary>
        bool HasChanges { get; }

        /// <summary>
        /// Gets a value indicating whether has been changed.
        /// </summary>
        bool HasBeenSaved { get; }

        /// <summary>
        /// Gets a value indicating whether is in edit.
        /// </summary>
        bool IsInEdit { get; }

        /// <summary>
        /// The update.
        /// </summary>
        void UpdateValue();

        /// <summary>
        /// The edit property.
        /// </summary>
        void EditProperty();
        
        /// <summary>
        /// The cancel edit.
        /// </summary>
        void CancelEdit();

        /// <summary>
        /// The save value.
        /// </summary>
        void SaveValue();

        /// <summary>
        /// The reset value.
        /// </summary>
        void ResetValue();

        /// <summary>
        /// The set attributes.
        /// </summary>
        /// <param name="attributes">
        /// The attributes.
        /// </param>
        /// <param name="parentModel">
        /// The parent model.
        /// </param>
        void SetAttributes(IEnumerable<ValidationAttribute> attributes, string parentModel);
    }
}
