package tickbox.web.ui.client.widget;

import java.util.Iterator;
import java.util.Spliterator;
import java.util.function.Consumer;

import com.allen_sauer.gwt.dnd.client.PickupDragController;
import com.google.gwt.user.client.ui.AbsolutePanel;
import com.google.gwt.user.client.ui.ComplexPanel;
import com.google.gwt.user.client.ui.FlowPanel;
import com.google.gwt.user.client.ui.HTML;
import com.google.gwt.user.client.ui.HTMLPanel;
import com.google.gwt.user.client.ui.HorizontalPanel;
import com.google.gwt.user.client.ui.InlineLabel;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.Panel;
import com.google.gwt.user.client.ui.SimplePanel;
import com.google.gwt.user.client.ui.VerticalPanel;
import com.google.gwt.user.client.ui.Widget;

public class TreeNode extends FlowPanel {
			
	protected InlineLabel _uiTitle;
	protected HorizontalPanel _uiTitleWrap;
	protected VerticalPanel _uiChildren;	
	protected HorizontalPanel _uiDropsHolder;	
	protected HTMLPanel _uiTitleHandle;	
	private TreeNode _parentNode = null;
	
	public TreeNode(PickupDragController dragCtrl,String title){
		this(dragCtrl,title,false);
	}
	
	public void registerParent(TreeNode parent){
		_parentNode = parent;
	}
	
	public TreeNode(PickupDragController dragCtrl, String title, boolean isRootNode) {
		super();
		_uiTitle = new InlineLabel(title);		
		_uiTitle.addStyleName("titleText");
		_uiChildren = new VerticalPanel();
		_uiChildren.addStyleName("nodeContainer");
		
		_uiDropsHolder= new HorizontalPanel();
		_uiDropsHolder.addStyleName("dropsContainer");
		
		_uiTitleHandle = new HTMLPanel("X");
		_uiTitleHandle.addStyleName("nodeHandle");
		
		_uiTitleWrap = new HorizontalPanel();		
		_uiTitleWrap.addStyleName("nodeTitle");
		
		_uiTitleWrap.add(_uiTitleHandle);
		_uiTitleWrap.add(_uiTitle);
		
		this.add(_uiTitleWrap);
		this.add(_uiDropsHolder);
		this.add(_uiChildren);
		
		this.addStyleName("node");
		
		
		DropLocation siblingDrop;
		TreeNodeDropController dropCtrl;
		
		if(isRootNode){
			// creates a disabled drop location - don't add to the drag controller
			siblingDrop = new DropLocation(false,false); 
			this.addStyleName("root");
		}else{
			// create a valid drop
			siblingDrop = new DropLocation(true,false);
			// create a controller for drop. 
			dropCtrl = new TreeNodeDropController(siblingDrop, this);
			// register controller
			dragCtrl.registerDropController(dropCtrl);		
		}
		
		_uiDropsHolder.add(siblingDrop);				
		DropLocation childDrop = new DropLocation(true,true);
		TreeNodeDropController childDropCtrl = new TreeNodeDropController(childDrop,this);
		dragCtrl.registerDropController(childDropCtrl);		
		_uiDropsHolder.add(childDrop);
		
		dragCtrl.makeDraggable(_uiTitleWrap,_uiTitleHandle);
	}
	
	public void AddChild(TreeNode child){	
		child.registerParent(this);
		_uiChildren.add(child);		
	}



}
