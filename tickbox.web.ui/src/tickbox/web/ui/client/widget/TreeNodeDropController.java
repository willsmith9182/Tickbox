package tickbox.web.ui.client.widget;

import com.allen_sauer.gwt.dnd.client.DragContext;
import com.allen_sauer.gwt.dnd.client.VetoDragException;
import com.allen_sauer.gwt.dnd.client.drop.AbstractDropController;
import com.google.gwt.user.client.ui.Widget;

public class TreeNodeDropController extends AbstractDropController {

	private final TreeNode _parentNode;
	
	public TreeNodeDropController(Widget dropTarget, TreeNode parentNode) {
		super(dropTarget);
		_parentNode = parentNode;
	}
	
	
	@Override
	public void onDrop(DragContext context) {
		// TODO Auto-generated method stub
		super.onDrop(context);
		_parentNode.removeStyleName("dropTarget");
		for(Widget w : context.selectedWidgets){
			TreeNode tn = (TreeNode)w;
			tn.removeFromParent();
			_parentNode.AddChild(tn);
		}
	}
	
	@Override
	public void onLeave(DragContext context) {
		// TODO Auto-generated method stub
		super.onLeave(context);
		_parentNode.removeStyleName("dropTarget");
	}
	
	@Override
	public void onEnter(DragContext context) {
		// TODO Auto-generated method stub
		super.onEnter(context);
		_parentNode.addStyleName("dropTarget");
	}
	
	@Override
	public void onMove(DragContext context) {
		// TODO Auto-generated method stub
		super.onMove(context);
	}
	
	@Override
	public void onPreviewDrop(DragContext context) throws VetoDragException {
		// TODO Auto-generated method stub
		
		super.onPreviewDrop(context);
	}

}
