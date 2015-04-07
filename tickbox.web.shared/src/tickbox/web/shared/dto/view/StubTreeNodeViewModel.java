



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.NullableInteger;

	// ---- this is a generated file, please do not edit directly -------
public class StubTreeNodeViewModel implements ITreeNodeViewModel {
	public StubTreeNodeViewModel() {}
	

	private boolean _IsRootNode = false;
	@Override public boolean getIsRootNode() { return this._IsRootNode; }
	public ITreeNodeViewModel setIsRootNode(boolean val) { this._IsRootNode = val; return this; }
	private int _TaxonomyId = 0;
	@Override public int getTaxonomyId() { return this._TaxonomyId; }
	@Override public ITreeNodeViewModel setTaxonomyId(int val) { this._TaxonomyId = val; return this; }
	private int _TreeNodeId = 0;
	@Override public int getTreeNodeId() { return this._TreeNodeId; }
	@Override public ITreeNodeViewModel setTreeNodeId(int val) { this._TreeNodeId = val; return this; }
	private NullableInteger _ParentTreeNodeId = NullableInteger.getNull();
	@Override public NullableInteger getParentTreeNodeId() { return this._ParentTreeNodeId; }
	@Override public ITreeNodeViewModel setParentTreeNodeId(NullableInteger val) { this._ParentTreeNodeId = val; return this; }
	private int _NodeId = 0;
	@Override public int getNodeId() { return this._NodeId; }
	@Override public ITreeNodeViewModel setNodeId(int val) { this._NodeId = val; return this; }
	private boolean _IsScaffold = false;
	@Override public boolean getIsScaffold() { return this._IsScaffold; }
	@Override public ITreeNodeViewModel setIsScaffold(boolean val) { this._IsScaffold = val; return this; }




}

