package tickbox.web.ui.client.widget;

import com.google.gwt.core.client.GWT;
import com.google.gwt.uibinder.client.UiBinder;
import com.google.gwt.uibinder.client.UiField;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.HTMLPanel;
import com.google.gwt.user.client.ui.Widget;

public class TreeNode extends Composite {

	private static TreeNodeUiBinder uiBinder = GWT
			.create(TreeNodeUiBinder.class);

	interface TreeNodeUiBinder extends UiBinder<Widget, TreeNode> {
	}

	@UiField	
	protected HTMLPanel _uiTitle;
	
	@UiField
	protected HTMLPanel _uiChildren;
	
	public TreeNode(String title) {
		initWidget(uiBinder.createAndBindUi(this));
		_uiTitle.getElement().setInnerHTML(title);
	}
	
	public void AddChild(TreeNode child){
		_uiChildren.add(child);
	}

}
