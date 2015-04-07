



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.request;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class CreateTaxonomyRequest extends JavaScriptObject implements ICreateTaxonomyRequest {
	protected CreateTaxonomyRequest() {}
	

	@Override public final native String getTaxonomyName() /*-{ return this.TaxonomyName }-*/;
	@Override public final native CreateTaxonomyRequest setTaxonomyName(String val) /*-{ this.TaxonomyName = val; return this; }-*/;



	
	private static final native CreateTaxonomyRequest asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final CreateTaxonomyRequest asObject(String json) { CreateTaxonomyRequest o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<CreateTaxonomyRequest> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<CreateTaxonomyRequest> asArray(String json) { JsArray<CreateTaxonomyRequest> l = asArrayRaw(json); for(CreateTaxonomyRequest o : new JsIterable<CreateTaxonomyRequest>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final CreateTaxonomyRequest newObj() {
		CreateTaxonomyRequest result = asObject("{d:{}}");
		result.setTaxonomyName(null);
	
				
		return result;
	}

}

