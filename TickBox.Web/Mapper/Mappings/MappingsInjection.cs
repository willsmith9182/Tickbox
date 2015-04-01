// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingsInjection.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The mappings injection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Autofac;
using TickBox.Objects;
using TickBox.Web.Models.Node;
using TickBox.Web.Models.NodeSpecialism;
using TickBox.Web.Models.Specialism;
using TickBox.Web.Models.Taxonomy;
using TickBox.Web.Models.Template;
using TickBox.Web.Models.TreeNode;

namespace TickBox.Web.Mapper.Mappings
{
    /// <summary>
    /// The mappings injection.
    /// </summary>
    public class MappingsInjection : Module
    {
        /// <summary>
        /// The load.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Node.Basic>().As<IMappingProvider<Objects.Node, NodeViewModel>>();
            
            builder.RegisterType<NodeSpecialism.Basic>().As<IMappingProvider<Objects.NodeSpecialism, NodeSpecialismViewModel>>();
            
            builder.RegisterType<Specialism.Basic>().As<IMappingProvider<Objects.Specialism, SpecialismViewModel>>();
            
            builder.RegisterType<Taxonomy.Basic>().As<IMappingProvider<Objects.Taxonomy, TaxonomyViewModel>>();
            builder.RegisterType<Taxonomy.Edit>().As<IMappingProvider<Objects.Taxonomy, TaxonomyEditViewModel>>();

            builder.RegisterType<Template.Basic>().As<IMappingProvider<Objects.Template, TemplateViewModel>>();
            
            builder.RegisterType<TreeNode.Basic>().As<IMappingProvider<Objects.TreeNode, TreeNodeViewModel>>();
        }
    }
}