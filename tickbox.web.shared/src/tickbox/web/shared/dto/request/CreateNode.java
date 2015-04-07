



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.request;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;

	// ---- this is a generated file, please do not edit directly -------
public class CreateNode extends JavaScriptObject implements ICreateNode {
	protected CreateNode() {}
	

	@Override public final native String getNodeTitle() /*-{ return this.NodeTitle }-*/;
	@Override public final native CreateNode setNodeTitle(String val) /*-{ this.NodeTitle = val; return this; }-*/;
	@Override public final native String getNodeDesc() /*-{ return this.NodeDesc }-*/;
	@Override public final native CreateNode setNodeDesc(String val) /*-{ this.NodeDesc = val; return this; }-*/;
	@Override public final native boolean getChildrenMultiSelect() /*-{ return this.ChildrenMultiSelect }-*/;
	@Override public final native CreateNode setChildrenMultiSelect(boolean val) /*-{ this.ChildrenMultiSelect = val; return this; }-*/;
	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native CreateNode setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	@Override public final native int getParentTreeNodeId() /*-{ return this.ParentTreeNodeId }-*/;
	@Override public final native CreateNode setParentTreeNodeId(int val) /*-{ this.ParentTreeNodeId = val; return this; }-*/;



	
	private static final native CreateNode asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final CreateNode asObject(String json) { CreateNode o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<CreateNode> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<CreateNode> asArray(String json) { JsArray<CreateNode> l = asArrayRaw(json); for(CreateNode o : new JsIterable<CreateNode>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final CreateNode newObj() {
		CreateNode result = asObject("{d:{}}");
		result.setNodeTitle(null);
		result.setNodeDesc(null);
		result.setChildrenMultiSelect(false);
		result.setTaxonomyId(0);
		result.setParentTreeNodeId(0);
	
				
		return result;
	}

}

