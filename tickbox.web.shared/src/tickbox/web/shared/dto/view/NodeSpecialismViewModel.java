



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class NodeSpecialismViewModel extends JavaScriptObject implements INodeSpecialismViewModel {
	protected NodeSpecialismViewModel() {}
	

	@Override public final native int getNodeSpecialismId() /*-{ return this.NodeSpecialismId }-*/;
	@Override public final native NodeSpecialismViewModel setNodeSpecialismId(int val) /*-{ this.NodeSpecialismId = val; return this; }-*/;
	@Override public final native int getNodeId() /*-{ return this.NodeId }-*/;
	@Override public final native NodeSpecialismViewModel setNodeId(int val) /*-{ this.NodeId = val; return this; }-*/;
	@Override public final native int getSpecialismId() /*-{ return this.SpecialismId }-*/;
	@Override public final native NodeSpecialismViewModel setSpecialismId(int val) /*-{ this.SpecialismId = val; return this; }-*/;
	@Override public final native int getSequenceOrder() /*-{ return this.SequenceOrder }-*/;
	@Override public final native NodeSpecialismViewModel setSequenceOrder(int val) /*-{ this.SequenceOrder = val; return this; }-*/;
	@Override public final native String getGuidelines() /*-{ return this.Guidelines }-*/;
	@Override public final native NodeSpecialismViewModel setGuidelines(String val) /*-{ this.Guidelines = val; return this; }-*/;
	@Override public final native String getDocumentLink() /*-{ return this.DocumentLink }-*/;
	@Override public final native NodeSpecialismViewModel setDocumentLink(String val) /*-{ this.DocumentLink = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native NodeSpecialismViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native NodeSpecialismViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final NodeSpecialismViewModel asObject(String json) { NodeSpecialismViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<NodeSpecialismViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<NodeSpecialismViewModel> asArray(String json) { JsArray<NodeSpecialismViewModel> l = asArrayRaw(json); for(NodeSpecialismViewModel o : new JsIterable<NodeSpecialismViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final NodeSpecialismViewModel newObj() {
		NodeSpecialismViewModel result = asObject("{d:{}}");
		result.setNodeSpecialismId(0);
		result.setNodeId(0);
		result.setSpecialismId(0);
		result.setSequenceOrder(0);
		result.setGuidelines(null);
		result.setDocumentLink(null);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

