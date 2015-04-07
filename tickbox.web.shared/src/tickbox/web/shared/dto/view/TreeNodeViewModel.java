



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;
import tickbox.web.shared.util.NullableInteger;

	// ---- this is a generated file, please do not edit directly -------
public class TreeNodeViewModel extends JavaScriptObject implements ITreeNodeViewModel {
	protected TreeNodeViewModel() {}
	

	@Override public final native boolean getIsRootNode() /*-{ return this.IsRootNode }-*/;
	@Override public final native int getTaxonomyId() /*-{ return this.TaxonomyId }-*/;
	@Override public final native TreeNodeViewModel setTaxonomyId(int val) /*-{ this.TaxonomyId = val; return this; }-*/;
	@Override public final native int getTreeNodeId() /*-{ return this.TreeNodeId }-*/;
	@Override public final native TreeNodeViewModel setTreeNodeId(int val) /*-{ this.TreeNodeId = val; return this; }-*/;
	private final native int getParentTreeNodeIdRaw() /*-{ return this.ParentTreeNodeId }-*/;
	private final native void setParentTreeNodeIdRaw(int val) /*-{ this.ParentTreeNodeId = val; }-*/;
	private final native boolean getParentTreeNodeIdIsNull() /*-{ return this.ParentTreeNodeId == null; }-*/;
	private final native void setParentTreeNodeIdIsNull() /*-{ this.ParentTreeNodeId = null; }-*/;
	public final NullableInteger getParentTreeNodeId() { return getParentTreeNodeIdIsNull() ? NullableInteger.getNull() : new NullableInteger(getParentTreeNodeIdRaw());  }
	public final TreeNodeViewModel setParentTreeNodeId(NullableInteger val) { if (val.isNull()) { setParentTreeNodeIdIsNull(); } else { setParentTreeNodeIdRaw(val.getInt()); } return this; }
	@Override public final native int getNodeId() /*-{ return this.NodeId }-*/;
	@Override public final native TreeNodeViewModel setNodeId(int val) /*-{ this.NodeId = val; return this; }-*/;
	@Override public final native boolean getIsScaffold() /*-{ return this.IsScaffold }-*/;
	@Override public final native TreeNodeViewModel setIsScaffold(boolean val) /*-{ this.IsScaffold = val; return this; }-*/;



	
	private static final native TreeNodeViewModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final TreeNodeViewModel asObject(String json) { TreeNodeViewModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<TreeNodeViewModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<TreeNodeViewModel> asArray(String json) { JsArray<TreeNodeViewModel> l = asArrayRaw(json); for(TreeNodeViewModel o : new JsIterable<TreeNodeViewModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			
		
	}
	


	public static final TreeNodeViewModel newObj() {
		TreeNodeViewModel result = asObject("{d:{}}");
		result.setTaxonomyId(0);
		result.setTreeNodeId(0);
		result.setParentTreeNodeIdIsNull();
		result.setNodeId(0);
		result.setIsScaffold(false);
	
				
		return result;
	}

}

