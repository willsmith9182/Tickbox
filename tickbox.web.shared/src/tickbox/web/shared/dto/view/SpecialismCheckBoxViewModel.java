



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class SpecialismCheckBoxViewModel extends JavaScriptObject implements ISpecialismCheckBoxViewModel {
	protected SpecialismCheckBoxViewModel() {}
	

	@Override public final native boolean getSelected() /*-{ return this.Selected }-*/;
	@Override public final native SpecialismCheckBoxViewModel setSelected(boolean val) /*-{ this.Selected = val; return this; }-*/;
	@Override public final native int getSpecialismId() /*-{ return this.SpecialismId }-*/;
	@Override public final native SpecialismCheckBoxViewModel setSpecialismId(int val) /*-{ this.SpecialismId = val; return this; }-*/;
	@Override public final native String getSpecialismTitle() /*-{ return this.SpecialismTitle }-*/;
	@Override public final native SpecialismCheckBoxViewModel setSpecialismTitle(String val) /*-{ this.SpecialismTitle = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native SpecialismCheckBoxViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native SpecialismCheckBoxViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final SpecialismCheckBoxViewModel asObject(String json) { SpecialismCheckBoxViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<SpecialismCheckBoxViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<SpecialismCheckBoxViewModel> asArray(String json) { JsArray<SpecialismCheckBoxViewModel> l = asArrayRaw(json); for(SpecialismCheckBoxViewModel o : new JsIterable<SpecialismCheckBoxViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final SpecialismCheckBoxViewModel newObj() {
		SpecialismCheckBoxViewModel result = asObject("{d:{}}");
		result.setSelected(false);
		result.setSpecialismId(0);
		result.setSpecialismTitle(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

