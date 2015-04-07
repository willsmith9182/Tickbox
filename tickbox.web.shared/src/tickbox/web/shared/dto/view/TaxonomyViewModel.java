



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class TaxonomyViewModel extends JavaScriptObject implements ITaxonomyViewModel {
	protected TaxonomyViewModel() {}
	

	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native TaxonomyViewModel setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	@Override public final native int getTemplateId() /*-{ return this.TemplateId }-*/;
	@Override public final native TaxonomyViewModel setTemplateId(int val) /*-{ this.TemplateId = val; return this; }-*/;
	@Override public final native String getTitle() /*-{ return this.Title }-*/;
	@Override public final native TaxonomyViewModel setTitle(String val) /*-{ this.Title = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native TaxonomyViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native TaxonomyViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final TaxonomyViewModel asObject(String json) { TaxonomyViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<TaxonomyViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<TaxonomyViewModel> asArray(String json) { JsArray<TaxonomyViewModel> l = asArrayRaw(json); for(TaxonomyViewModel o : new JsIterable<TaxonomyViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final TaxonomyViewModel newObj() {
		TaxonomyViewModel result = asObject("{d:{}}");
		result.setTaxonomyId(0);
		result.setTemplateId(0);
		result.setTitle(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

