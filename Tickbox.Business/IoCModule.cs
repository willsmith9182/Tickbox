// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoCModule.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The i o c module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Autofac;

namespace Tickbox.Business
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
            //builder.RegisterModule(new Data.IoCModule());
            //builder.RegisterType<MenuWrapper>().As<IMenuWrapper>();
            //builder.RegisterType<TemplateWrapper>().As<ITemplateWrapper>().As<IWrapper<Template>>();
            //builder.RegisterType<TaxonomyWrapper>().As<ITaxonomyWrapper>().As<IWrapper<Taxonomy>>();
            //builder.RegisterType<SpecialismWrapper>().As<ISpecialismWrapper>().As<IWrapper<Specialism>>();
            //builder.RegisterType<NodeSpecialismWrapper>().As<INodeSpecialismWrapper>().As<IWrapper<NodeSpecialism>>();
            //builder.RegisterType<NodeWrapper>().As<INodeWrapper>().As<IWrapper<Node>>();
            //builder.RegisterType<ScaffoldWrapper>().As<IScaffoldWrapper>();
        }
    }
}
