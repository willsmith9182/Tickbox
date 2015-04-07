



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;
import tickbox.web.shared.util.NullableInteger;

	// ---- this is a generated file, please do not edit directly -------
public class TaxonomySpecialismViewModel extends JavaScriptObject implements ITaxonomySpecialismViewModel {
	protected TaxonomySpecialismViewModel() {}
	

	@Override public final native boolean getIsNew() /*-{ return this.IsNew }-*/;
	private final native int getTaxonomySpecialismIdRaw() /*-{ return this.TaxonomySpecialismId }-*/;
	private final native void setTaxonomySpecialismIdRaw(int val) /*-{ this.TaxonomySpecialismId = val; }-*/;
	private final native boolean getTaxonomySpecialismIdIsNull() /*-{ return this.TaxonomySpecialismId == null; }-*/;
	private final native void setTaxonomySpecialismIdIsNull() /*-{ this.TaxonomySpecialismId = null; }-*/;
	public final NullableInteger getTaxonomySpecialismId() { return getTaxonomySpecialismIdIsNull() ? NullableInteger.getNull() : new NullableInteger(getTaxonomySpecialismIdRaw());  }
	public final TaxonomySpecialismViewModel setTaxonomySpecialismId(NullableInteger val) { if (val.isNull()) { setTaxonomySpecialismIdIsNull(); } else { setTaxonomySpecialismIdRaw(val.getInt()); } return this; }
	@Override public final native int getSpecialismId() /*-{ return this.SpecialismId }-*/;
	@Override public final native TaxonomySpecialismViewModel setSpecialismId(int val) /*-{ this.SpecialismId = val; return this; }-*/;
	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native TaxonomySpecialismViewModel setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native TaxonomySpecialismViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native TaxonomySpecialismViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final TaxonomySpecialismViewModel asObject(String json) { TaxonomySpecialismViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<TaxonomySpecialismViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<TaxonomySpecialismViewModel> asArray(String json) { JsArray<TaxonomySpecialismViewModel> l = asArrayRaw(json); for(TaxonomySpecialismViewModel o : new JsIterable<TaxonomySpecialismViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final TaxonomySpecialismViewModel newObj() {
		TaxonomySpecialismViewModel result = asObject("{d:{}}");
		result.setTaxonomySpecialismIdIsNull();
		result.setSpecialismId(0);
		result.setTaxonomyId(0);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

