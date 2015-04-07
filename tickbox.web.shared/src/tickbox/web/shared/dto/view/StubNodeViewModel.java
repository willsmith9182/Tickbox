



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.NullableInteger;

	// ---- this is a generated file, please do not edit directly -------
public class StubNodeViewModel implements INodeViewModel {
	public StubNodeViewModel() {}
	

	private int _NodeId = 0;
	@Override public int getNodeId() { return this._NodeId; }
	@Override public INodeViewModel setNodeId(int val) { this._NodeId = val; return this; }
	private String _NodeTitle = "";
	@Override public String getNodeTitle() { return this._NodeTitle; }
	@Override public INodeViewModel setNodeTitle(String val) { this._NodeTitle = val; return this; }
	private String _NodeDescription = "";
	@Override public String getNodeDescription() { return this._NodeDescription; }
	@Override public INodeViewModel setNodeDescription(String val) { this._NodeDescription = val; return this; }
	private boolean _AllowMultiSelectChildren = false;
	@Override public boolean getAllowMultiSelectChildren() { return this._AllowMultiSelectChildren; }
	@Override public INodeViewModel setAllowMultiSelectChildren(boolean val) { this._AllowMultiSelectChildren = val; return this; }
	private int _TaxonomyId = 0;
	@Override public int getTaxonomyId() { return this._TaxonomyId; }
	@Override public INodeViewModel setTaxonomyId(int val) { this._TaxonomyId = val; return this; }
	private NullableInteger _ParentId = NullableInteger.getNull();
	@Override public NullableInteger getParentId() { return this._ParentId; }
	@Override public INodeViewModel setParentId(NullableInteger val) { this._ParentId = val; return this; }
	private boolean _IsRootNode = false;
	@Override public boolean getIsRootNode() { return this._IsRootNode; }
	public INodeViewModel setIsRootNode(boolean val) { this._IsRootNode = val; return this; }




}

