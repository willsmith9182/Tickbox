



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class TemplateViewModel extends JavaScriptObject implements ITemplateViewModel {
	protected TemplateViewModel() {}
	

	@Override public final native int getTemplateId() /*-{ return this.TemplateId }-*/;
	@Override public final native TemplateViewModel setTemplateId(int val) /*-{ this.TemplateId = val; return this; }-*/;
	@Override public final native String getName() /*-{ return this.Name }-*/;
	@Override public final native TemplateViewModel setName(String val) /*-{ this.Name = val; return this; }-*/;
	@Override public final native String getDocumentLink() /*-{ return this.DocumentLink }-*/;
	@Override public final native TemplateViewModel setDocumentLink(String val) /*-{ this.DocumentLink = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native TemplateViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native TemplateViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final TemplateViewModel asObject(String json) { TemplateViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<TemplateViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<TemplateViewModel> asArray(String json) { JsArray<TemplateViewModel> l = asArrayRaw(json); for(TemplateViewModel o : new JsIterable<TemplateViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final TemplateViewModel newObj() {
		TemplateViewModel result = asObject("{d:{}}");
		result.setTemplateId(0);
		result.setName(null);
		result.setDocumentLink(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

