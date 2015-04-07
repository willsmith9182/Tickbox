



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.request;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class CreateNodeSpecialism extends JavaScriptObject implements ICreateNodeSpecialism {
	protected CreateNodeSpecialism() {}
	

	@Override public final native int getNodeId() /*-{ return this.NodeId }-*/;
	@Override public final native CreateNodeSpecialism setNodeId(int val) /*-{ this.NodeId = val; return this; }-*/;
	@Override public final native int getSpecialismId() /*-{ return this.SpecialismId }-*/;
	@Override public final native CreateNodeSpecialism setSpecialismId(int val) /*-{ this.SpecialismId = val; return this; }-*/;
	@Override public final native String getGuidelines() /*-{ return this.Guidelines }-*/;
	@Override public final native CreateNodeSpecialism setGuidelines(String val) /*-{ this.Guidelines = val; return this; }-*/;
	@Override public final native String getDocumentLink() /*-{ return this.DocumentLink }-*/;
	@Override public final native CreateNodeSpecialism setDocumentLink(String val) /*-{ this.DocumentLink = val; return this; }-*/;



	
	private static final native CreateNodeSpecialism asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final CreateNodeSpecialism asObject(String json) { CreateNodeSpecialism o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<CreateNodeSpecialism> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<CreateNodeSpecialism> asArray(String json) { JsArray<CreateNodeSpecialism> l = asArrayRaw(json); for(CreateNodeSpecialism o : new JsIterable<CreateNodeSpecialism>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final CreateNodeSpecialism newObj() {
		CreateNodeSpecialism result = asObject("{d:{}}");
		result.setNodeId(0);
		result.setSpecialismId(0);
		result.setGuidelines(null);
		result.setDocumentLink(null);
	
				
		return result;
	}

}

