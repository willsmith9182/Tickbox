package tickbox.web.ui.client.widget;

import com.google.gwt.core.client.GWT;
import com.google.gwt.uibinder.client.UiBinder;
import com.google.gwt.uibinder.client.UiField;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.HTMLPanel;
import com.google.gwt.user.client.ui.InlineLabel;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.Widget;

public class TreeNode extends Composite {

	private static TreeNodeUiBinder uiBinder = GWT
			.create(TreeNodeUiBinder.class);

	interface TreeNodeUiBinder extends UiBinder<Widget, TreeNode> {
	}

	@UiField	
	protected InlineLabel _uiTitle;
	
	@UiField
	protected HTMLPanel _uiChildren;
	
	@UiField
	protected HTMLPanel _uiDropsHolder;
	
	public TreeNode(String title){
		this(title,false);
	}
	public TreeNode(String title, boolean isRootNode) {
		initWidget(uiBinder.createAndBindUi(this));
		_uiTitle.getElement().setInnerHTML(title);
		
		DropLocation siblingDrop;
		if(isRootNode){
			siblingDrop = new DropLocation(isRootNode,false); 
			this.addStyleName("root");
		}else{
			siblingDrop = new DropLocation(1,isRootNode,false);
		}
		_uiDropsHolder.add(siblingDrop);
		DropLocation childDrop = new DropLocation(1, isRootNode,true);
		_uiDropsHolder.add(childDrop);
	}
	
	public void AddChild(TreeNode child){
		_uiChildren.add(child);
	}

	public void setActive(){
		this.addStyleName("dropTarget");
	}
}
