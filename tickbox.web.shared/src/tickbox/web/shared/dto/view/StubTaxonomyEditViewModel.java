



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.stubs.StubJsArray;
import tickbox.web.shared.util.IJsArray;

	// ---- this is a generated file, please do not edit directly -------
public class StubTaxonomyEditViewModel implements ITaxonomyEditViewModel {
	public StubTaxonomyEditViewModel() {}
	

	private StubJsArray<ISpecialismCheckBoxViewModel> _AvailableSpecialisms = new StubJsArray<ISpecialismCheckBoxViewModel>();
	@Override public StubJsArray<ISpecialismCheckBoxViewModel> getAvailableSpecialisms() { return this._AvailableSpecialisms; }
	@Override public ITaxonomyEditViewModel setAvailableSpecialisms(IJsArray<ISpecialismCheckBoxViewModel> val) { this._AvailableSpecialisms = (StubJsArray<ISpecialismCheckBoxViewModel>)val; return this; }
	@Override public ITaxonomyEditViewModel setAvailableSpecialisms(Iterable<ISpecialismCheckBoxViewModel> list) { _AvailableSpecialisms.setLength(0); for(ISpecialismCheckBoxViewModel i : list) { _AvailableSpecialisms.push(i); } return this;  }
	private int _TaxonomyId = 0;
	@Override public int getTaxonomyId() { return this._TaxonomyId; }
	@Override public ITaxonomyEditViewModel setTaxonomyId(int val) { this._TaxonomyId = val; return this; }
	private int _TemplateId = 0;
	@Override public int getTemplateId() { return this._TemplateId; }
	@Override public ITaxonomyEditViewModel setTemplateId(int val) { this._TemplateId = val; return this; }
	private String _Title = "";
	@Override public String getTitle() { return this._Title; }
	@Override public ITaxonomyEditViewModel setTitle(String val) { this._Title = val; return this; }
	private boolean _IsScaffold = false;
	@Override public boolean getIsScaffold() { return this._IsScaffold; }
	@Override public ITaxonomyEditViewModel setIsScaffold(boolean val) { this._IsScaffold = val; return this; }




}

