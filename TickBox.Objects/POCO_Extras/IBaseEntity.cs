// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IBasePoco.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The BasePoco interface. used to indicate a base poco type, for use with inheritance splitter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TickBox.Objects
{
    /// <summary>
    /// The BasePoco interface. used to indicate a base poco type, for use with <see cref="InheritedPocoSplitter{TPoco}"/>.
    /// </summary>
    public interface IBaseEntity : IEntity
    {
    }
}
