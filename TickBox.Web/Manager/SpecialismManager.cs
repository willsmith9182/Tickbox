// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialismManager.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The specialism manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TickBox.Objects;
using TickBox.Web.Models.Specialism;

namespace TickBox.Web.Manager
{
    /// <summary>
    /// The specialism manager.
    /// </summary>
    public class SpecialismManager : ISpecialismManager
    {
        /// <summary>
        /// The specialism mapper.
        /// </summary>
        private readonly IMapper<Specialism, SpecialismViewModel> specialismMapper;

        /// <summary>
        /// The specialism wrapper.
        /// </summary>
        private readonly ISpecialismWrapper specialismWrapper;

        /// <summary>
        /// Initialises a new instance of the <see cref="SpecialismManager"/> class.
        /// </summary>
        /// <param name="specialismMapper">
        /// The specialism mapper.
        /// </param>
        /// <param name="specialismWrapper">
        /// The specialism wrapper.
        /// </param>
        public SpecialismManager(IMapper<Specialism, SpecialismViewModel> specialismMapper, ISpecialismWrapper specialismWrapper)
        {
            this.specialismMapper = specialismMapper;
            this.specialismWrapper = specialismWrapper;
        }

        #region Implementation of ISpecialismManager

        /// <summary>
        /// The get model.
        /// </summary>
        /// <returns>
        /// The <see cref="SpecialismViewModel"/>.
        /// </returns>
        public SpecialismViewModel GetModel()
        {
            return this.specialismMapper.Map(this.specialismWrapper.CreateNew());
        }

        /// <summary>
        /// The get model.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SpecialismViewModel"/>.
        /// </returns>
        public SpecialismViewModel GetModel(int id)
        {
            return this.specialismMapper.Map(this.specialismWrapper.GetItem(id));
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
        public int Create(SpecialismViewModel model)
        {
            return this.specialismWrapper.Create(this.specialismMapper.Reverse(model), true).SpecialismId;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        public void Update(SpecialismViewModel model)
        {
            this.specialismWrapper.Update(this.specialismMapper.Reverse(model), true);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
            this.specialismWrapper.Delete(id, true);
        }

        #endregion
    }
}