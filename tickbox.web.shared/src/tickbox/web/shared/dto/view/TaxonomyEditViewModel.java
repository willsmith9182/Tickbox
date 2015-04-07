



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;
import tickbox.web.shared.util.Utils;
import tickbox.web.shared.util.IJsArray;
import tickbox.web.shared.util.JsArrayWrapper;

	// ---- this is a generated file, please do not edit directly -------
public class TaxonomyEditViewModel extends JavaScriptObject implements ITaxonomyEditViewModel {
	protected TaxonomyEditViewModel() {}
	

	private final native JsArray<SpecialismCheckBoxViewModel> getAvailableSpecialismsRaw() /*-{ return this.AvailableSpecialisms }-*/;
	private final native void setAvailableSpecialisms(JsArray<SpecialismCheckBoxViewModel> val) /*-{ this.AvailableSpecialisms = val; }-*/;
	@Override public final IJsArray<ISpecialismCheckBoxViewModel> getAvailableSpecialisms() {  return new JsArrayWrapper<SpecialismCheckBoxViewModel, ISpecialismCheckBoxViewModel>(getAvailableSpecialismsRaw());  }
	@Override public final TaxonomyEditViewModel setAvailableSpecialisms(Iterable<ISpecialismCheckBoxViewModel> list) { getAvailableSpecialismsRaw().setLength(0); for(ISpecialismCheckBoxViewModel item : list) { getAvailableSpecialismsRaw().push((SpecialismCheckBoxViewModel)item); } return this; }
	@Override public final TaxonomyEditViewModel setAvailableSpecialisms(IJsArray<ISpecialismCheckBoxViewModel> list) { setAvailableSpecialisms(JsArrayWrapper.<SpecialismCheckBoxViewModel, ISpecialismCheckBoxViewModel>unwrap(list)); return this; }
	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native TaxonomyEditViewModel setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	@Override public final native int getTemplateId() /*-{ return this.TemplateId }-*/;
	@Override public final native TaxonomyEditViewModel setTemplateId(int val) /*-{ this.TemplateId = val; return this; }-*/;
	@Override public final native String getTitle() /*-{ return this.Title }-*/;
	@Override public final native TaxonomyEditViewModel setTitle(String val) /*-{ this.Title = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native TaxonomyEditViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native TaxonomyEditViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final TaxonomyEditViewModel asObject(String json) { TaxonomyEditViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<TaxonomyEditViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<TaxonomyEditViewModel> asArray(String json) { JsArray<TaxonomyEditViewModel> l = asArrayRaw(json); for(TaxonomyEditViewModel o : new JsIterable<TaxonomyEditViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			for(SpecialismCheckBoxViewModel o : new JsIterable<SpecialismCheckBoxViewModel>(getAvailableSpecialismsRaw())) { o.convertDates(); }
			
		
	}
	


	public static final TaxonomyEditViewModel newObj() {
		TaxonomyEditViewModel result = asObject("{d:{}}");
		result.setAvailableSpecialisms(Utils.<SpecialismCheckBoxViewModel>createArray());
		result.setTaxonomyId(0);
		result.setTemplateId(0);
		result.setTitle(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

