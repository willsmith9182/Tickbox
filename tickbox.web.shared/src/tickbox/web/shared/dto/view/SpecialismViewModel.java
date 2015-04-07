



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class SpecialismViewModel extends JavaScriptObject implements ISpecialismViewModel {
	protected SpecialismViewModel() {}
	

	@Override public final native int getSpecialismId() /*-{ return this.SpecialismId }-*/;
	@Override public final native SpecialismViewModel setSpecialismId(int val) /*-{ this.SpecialismId = val; return this; }-*/;
	@Override public final native String getSpecialismTitle() /*-{ return this.SpecialismTitle }-*/;
	@Override public final native SpecialismViewModel setSpecialismTitle(String val) /*-{ this.SpecialismTitle = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native SpecialismViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native SpecialismViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final SpecialismViewModel asObject(String json) { SpecialismViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<SpecialismViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<SpecialismViewModel> asArray(String json) { JsArray<SpecialismViewModel> l = asArrayRaw(json); for(SpecialismViewModel o : new JsIterable<SpecialismViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final SpecialismViewModel newObj() {
		SpecialismViewModel result = asObject("{d:{}}");
		result.setSpecialismId(0);
		result.setSpecialismTitle(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

