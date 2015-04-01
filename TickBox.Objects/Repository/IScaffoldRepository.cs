// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScaffoldRepository.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The ScaffoldRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace TickBox.Objects
{
    /// <summary>
    /// The ScaffoldRepository interface.
    /// </summary>
    /// <typeparam name="TPoco">
    /// dummy, used to ensure that an actual repository is returned that i can use. 
    /// </typeparam>
    [Obsolete("Repositories have been replaced by unit of work.")]
    public interface IScaffoldRepository<TPoco> : IRepository<TPoco> where TPoco : class
    {
    }
}
