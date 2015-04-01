// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoCModule.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The i o c module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Autofac;
using Autofac.Integration.Mvc;
using TickBox.Objects;

namespace TickBox.Data
{
    /// <summary>
    /// The i o c module.
    /// </summary>
    public class IoCModule : Module
    {
        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContextProvider>()
                  .As<IContextProvider>()
                  .InstancePerHttpRequest();
            builder.RegisterType<EfUnitOfWork>().As<IComitable>().As<IDataUnitOfWork>().InstancePerHttpRequest();
        }
    }
}
