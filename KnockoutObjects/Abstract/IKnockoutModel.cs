// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnockoutModel.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Provides base functionality and Type requirements for a Knockout View Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace KnockoutObjects
{
    /// <summary>
    /// Provides base functionality and Type requirements for a Knockout View Model
    /// </summary>
    /// <typeparam name="TModelType"> The type of the model.
    /// </typeparam>
    public interface IKnockoutModel<TModelType> : IEquatable<TModelType>, ICloneable<TModelType> where TModelType : KnockoutBaseModel, new()
    {
        /// <summary>
        /// The update model state.
        /// </summary>
        /// <param name="updateType">
        /// The update type.
        /// </param>
        void UpdateModelState(Enums.ModelUpdateType updateType);
    }
}
