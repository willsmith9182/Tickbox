



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.request;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class CreateTemplate extends JavaScriptObject implements ICreateTemplate {
	protected CreateTemplate() {}
	

	@Override public final native String getTemplateName() /*-{ return this.TemplateName }-*/;
	@Override public final native CreateTemplate setTemplateName(String val) /*-{ this.TemplateName = val; return this; }-*/;
	@Override public final native String getDocumentLink() /*-{ return this.DocumentLink }-*/;
	@Override public final native CreateTemplate setDocumentLink(String val) /*-{ this.DocumentLink = val; return this; }-*/;



	
	private static final native CreateTemplate asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final CreateTemplate asObject(String json) { CreateTemplate o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<CreateTemplate> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<CreateTemplate> asArray(String json) { JsArray<CreateTemplate> l = asArrayRaw(json); for(CreateTemplate o : new JsIterable<CreateTemplate>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final CreateTemplate newObj() {
		CreateTemplate result = asObject("{d:{}}");
		result.setTemplateName(null);
		result.setDocumentLink(null);
	
				
		return result;
	}

}

