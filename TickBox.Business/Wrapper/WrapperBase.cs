// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WrapperBase.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The wrapper base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// neded when config key is used for this setting. 
using System;
using System.Web.Configuration;
using TickBox.Objects;
using TickBox.Objects.Notifications;

namespace TickBox.Business
{
    /// <summary>
    /// The wrapper base.
    /// </summary>
    public abstract class WrapperBase
    {

        /// <summary>
        /// The notifier.
        /// </summary>
        protected readonly INotify notifier;

        /// <summary>
        /// The auto create scaffolding.
        /// </summary>
        protected readonly bool AutoCreateScaffolding;

        protected readonly IDataUnitOfWork dataUnitOfWork;
        /// <summary>
        /// Initialises a new instance of the <see cref="WrapperBase"/> class.
        /// </summary>
        protected WrapperBase(IDataUnitOfWork dataUnitOfWork, INotify notifier)
        {
            this.dataUnitOfWork = dataUnitOfWork;
            this.notifier = notifier;
            this.AutoCreateScaffolding = true; // eventually: Convert.ToBoolean(WebConfigurationManager.AppSettings["AutoScaffolding"]);
        }

        internal void Save(bool immediateSave, INotification notification)
        {
            if (immediateSave)
            {
                this.dataUnitOfWork.Save();
                this.notifier.Add(notification);
            }
        }
    }
}
