


	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import tickbox.web.shared.util.NullableInteger;


public interface INodeViewModel {
	int getNodeId();
	INodeViewModel setNodeId(int val);
	String getNodeTitle();
	INodeViewModel setNodeTitle(String val);
	String getNodeDescription();
	INodeViewModel setNodeDescription(String val);
	boolean getAllowMultiSelectChildren();
	INodeViewModel setAllowMultiSelectChildren(boolean val);
	int getTaxonomyId();
	INodeViewModel setTaxonomyId(int val);
	NullableInteger getParentId();
	INodeViewModel setParentId(NullableInteger val);
	boolean getIsRootNode();
}