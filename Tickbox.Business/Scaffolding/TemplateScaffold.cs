
using Mehdime.Entity;
using Tickbox.Core.Scaffold;
using Tickbox.Data.Repository;
using Tickbox.DatabaseApi;

namespace Tickbox.Business.Scaffolding
{
    class TemplateScaffold : ScaffoldDefinition<Template>
    {
        private readonly ITaxonomyRepo _taxonomyRepo;

        public TemplateScaffold(ITaxonomyRepo taxonomyRepo)
        {
            _taxonomyRepo = taxonomyRepo;
        }

        public override void CreateScaffold(IAmbientDbContextLocator contextLocator, Template newItem)
        {
            var scaffoldTaxonomy = new Taxonomy
            {
                IsScaffold = true,
                TemplateId = newItem.TemplateId,
                Template = newItem,
                Title = string.Format("Scaffold for {0} Template", newItem.Name)
            };
            _taxonomyRepo.Add(scaffoldTaxonomy);
        }
    }
}
