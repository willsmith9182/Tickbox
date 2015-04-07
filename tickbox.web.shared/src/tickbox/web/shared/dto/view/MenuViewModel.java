



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class MenuViewModel extends JavaScriptObject implements IMenuViewModel {
	protected MenuViewModel() {}
	

	@Override public final native boolean getHasTemplates() /*-{ return this.HasTemplates }-*/;
	@Override public final native MenuViewModel setHasTemplates(boolean val) /*-{ this.HasTemplates = val; return this; }-*/;
	@Override public final native boolean getHasSpecialisms() /*-{ return this.HasSpecialisms }-*/;
	@Override public final native MenuViewModel setHasSpecialisms(boolean val) /*-{ this.HasSpecialisms = val; return this; }-*/;
	@Override public final native boolean getHasTaxonomies() /*-{ return this.HasTaxonomies }-*/;
	@Override public final native MenuViewModel setHasTaxonomies(boolean val) /*-{ this.HasTaxonomies = val; return this; }-*/;



	
	private static final native MenuViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final MenuViewModel asObject(String json) { MenuViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<MenuViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<MenuViewModel> asArray(String json) { JsArray<MenuViewModel> l = asArrayRaw(json); for(MenuViewModel o : new JsIterable<MenuViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final MenuViewModel newObj() {
		MenuViewModel result = asObject("{d:{}}");
		result.setHasTemplates(false);
		result.setHasSpecialisms(false);
		result.setHasTaxonomies(false);
	
				
		return result;
	}

}

