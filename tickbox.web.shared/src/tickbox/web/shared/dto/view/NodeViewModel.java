



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;
import tickbox.web.shared.util.NullableInteger;

	// ---- this is a generated file, please do not edit directly -------
public class NodeViewModel extends JavaScriptObject implements INodeViewModel {
	protected NodeViewModel() {}
	

	@Override public final native int getNodeId() /*-{ return this.NodeId }-*/;
	@Override public final native NodeViewModel setNodeId(int val) /*-{ this.NodeId = val; return this; }-*/;
	@Override public final native String getNodeTitle() /*-{ return this.NodeTitle }-*/;
	@Override public final native NodeViewModel setNodeTitle(String val) /*-{ this.NodeTitle = val; return this; }-*/;
	@Override public final native String getNodeDescription() /*-{ return this.NodeDescription }-*/;
	@Override public final native NodeViewModel setNodeDescription(String val) /*-{ this.NodeDescription = val; return this; }-*/;
	@Override public final native boolean getAllowMultiSelectChildren() /*-{ return this.AllowMultiSelectChildren }-*/;
	@Override public final native NodeViewModel setAllowMultiSelectChildren(boolean val) /*-{ this.AllowMultiSelectChildren = val; return this; }-*/;
	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native NodeViewModel setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	private final native int getParentIdRaw() /*-{ return this.ParentId }-*/;
	private final native void setParentIdRaw(int val) /*-{ this.ParentId = val; }-*/;
	private final native boolean getParentIdIsNull() /*-{ return this.ParentId == null; }-*/;
	private final native void setParentIdIsNull() /*-{ this.ParentId = null; }-*/;
	public final NullableInteger getParentId() { return getParentIdIsNull() ? NullableInteger.getNull() : new NullableInteger(getParentIdRaw());  }
	public final NodeViewModel setParentId(NullableInteger val) { if (val.isNull()) { setParentIdIsNull(); } else { setParentIdRaw(val.getInt()); } return this; }
	@Override public final native boolean getIsRootNode() /*-{ return this.IsRootNode }-*/;



	
	private static final native NodeViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final NodeViewModel asObject(String json) { NodeViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<NodeViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<NodeViewModel> asArray(String json) { JsArray<NodeViewModel> l = asArrayRaw(json); for(NodeViewModel o : new JsIterable<NodeViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final NodeViewModel newObj() {
		NodeViewModel result = asObject("{d:{}}");
		result.setNodeId(0);
		result.setNodeTitle(null);
		result.setNodeDescription(null);
		result.setAllowMultiSelectChildren(false);
		result.setTaxonomyId(0);
		result.setParentIdIsNull();
	
				
		return result;
	}

}

