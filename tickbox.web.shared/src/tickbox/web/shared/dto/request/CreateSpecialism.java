



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.request;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class CreateSpecialism extends JavaScriptObject implements ICreateSpecialism {
	protected CreateSpecialism() {}
	

	@Override public final native String getSpecialismDesc() /*-{ return this.SpecialismDesc }-*/;
	@Override public final native CreateSpecialism setSpecialismDesc(String val) /*-{ this.SpecialismDesc = val; return this; }-*/;



	
	private static final native CreateSpecialism asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final CreateSpecialism asObject(String json) { CreateSpecialism o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<CreateSpecialism> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<CreateSpecialism> asArray(String json) { JsArray<CreateSpecialism> l = asArrayRaw(json); for(CreateSpecialism o : new JsIterable<CreateSpecialism>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final CreateSpecialism newObj() {
		CreateSpecialism result = asObject("{d:{}}");
		result.setSpecialismDesc(null);
	
				
		return result;
	}

}

