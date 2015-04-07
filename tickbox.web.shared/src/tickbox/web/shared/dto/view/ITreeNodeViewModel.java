


	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.NullableInteger;


public interface ITreeNodeViewModel {
	boolean getIsRootNode();
	int getTaxonomyId();
	ITreeNodeViewModel setTaxonomyId(int val);
	int getTreeNodeId();
	ITreeNodeViewModel setTreeNodeId(int val);
	NullableInteger getParentTreeNodeId();
	ITreeNodeViewModel setParentTreeNodeId(NullableInteger val);
	int getNodeId();
	ITreeNodeViewModel setNodeId(int val);
	boolean getIsScaffold();
	ITreeNodeViewModel setIsScaffold(boolean val);
}