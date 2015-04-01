// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoCModule.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The i o c module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Autofac;
using TickBox.Web.Manager;
using TickBox.Web.Mapper;
using TickBox.Web.Models.Template;

namespace TickBox.Web
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
            builder.RegisterModule(new Business.IoCModule());
            builder.RegisterModule(new Objects.IoCModule());
            builder.RegisterModule(new Mapper.Mappings.MappingsInjection());
            builder.RegisterType<MenuManager>().As<IMenuManager>();
            builder.RegisterType<TemplateManager>().As<ITemplateManager<TemplateViewModel>>();
            builder.RegisterType<SpecialismManager>().As<ISpecialismManager>();
            builder.RegisterType<TaxonomyManager>().As<ITaxonomyManager>();
            builder.RegisterType<TaxonomyEditManager>().As<ITaxonomyEditManager>();
            builder.RegisterType<NodeSpecialismManager>().As<INodeSpecialismManager>();
            builder.RegisterType<NodeManager>().As<INodeManager>();
            builder.RegisterType<ScaffoldManager>().As<IScaffoldManager>();
        }
    }
}