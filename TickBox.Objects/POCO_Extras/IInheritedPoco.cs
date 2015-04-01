// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IInheritedPoco.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   Defines the IInheritedPoco type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TickBox.Objects
{
    /// <summary>
    /// The InheritedPoco interface. used to ensure inheritance between base and derived poco objects
    /// </summary>
    /// <typeparam name="TInheritedFrom">
    /// the base poco to tie to
    /// </typeparam>
    public interface IInheritedPoco<TInheritedFrom> where TInheritedFrom : class, IBaseEntity
    {
    }
}
