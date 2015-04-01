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
using TickBox.Objects.Http;
using TickBox.Objects.Notifications;

namespace TickBox.Objects
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
            builder.RegisterType<Notifier>()
                   .As<INotify>().InstancePerHttpRequest();
            builder.RegisterGeneric(typeof(Mapper<,>))
                    .As(typeof(IMapper<,>));
            builder.RegisterGeneric(typeof(InheritedPocoSplitter<>))
                    .As(typeof(IInheritedPocoSplitter<>));
            builder.RegisterType<CacheFactory>().As<ICacheFactory>().InstancePerHttpRequest();
            builder.RegisterType<SessionStoreBase>().As<ISessionStoreBase>().InstancePerHttpRequest();
        }
    }
}
