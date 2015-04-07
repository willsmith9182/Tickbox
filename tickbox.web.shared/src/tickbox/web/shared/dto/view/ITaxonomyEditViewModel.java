


	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.IJsArray;


public interface ITaxonomyEditViewModel {
	IJsArray<ISpecialismCheckBoxViewModel> getAvailableSpecialisms();
	ITaxonomyEditViewModel setAvailableSpecialisms(Iterable<ISpecialismCheckBoxViewModel> val);
	ITaxonomyEditViewModel setAvailableSpecialisms(IJsArray<ISpecialismCheckBoxViewModel> val);
	int getTaxonomyId();
	ITaxonomyEditViewModel setTaxonomyId(int val);
	int getTemplateId();
	ITaxonomyEditViewModel setTemplateId(int val);
	String getTitle();
	ITaxonomyEditViewModel setTitle(String val);
	boolean getIsScaffold();
	ITaxonomyEditViewModel setIsScaffold(boolean val);
}