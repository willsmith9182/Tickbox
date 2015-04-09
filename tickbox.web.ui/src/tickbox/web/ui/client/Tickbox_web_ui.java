package tickbox.web.ui.client;

import tickbox.web.ui.client.widget.TreeNode;

import com.allen_sauer.gwt.dnd.client.drop.FlowPanelDropController;
import com.allen_sauer.gwt.dnd.client.drop.GridConstrainedDropController;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.RootPanel;



public class Tickbox_web_ui implements EntryPoint {
		
	public void onModuleLoad() {
		boolean hasActive = false;
		GridConstrainedDropController t;
		//Window.alert("loaded");
		RootPanel rp = RootPanel.get("rooty");
		TreeNode parentNode = new TreeNode("Root Node",true);
		for(int i = 0; i< 5; i++){
			TreeNode parentOne = new TreeNode("Node : "+ (i+1));
			for(int j = 0; j< 3; j++){				
				TreeNode parentTwo = new TreeNode("Node : "+ (i+1) + " : " + (j+1));
				for(int k = 0; k< 2; k++){
					TreeNode child = new TreeNode("Node : "+ (i+1) + " : " + (j+1) + " : " + (k+1));			
					parentTwo.AddChild(child);
				}	
				if(!hasActive){
					hasActive=true;
					parentTwo.setActive();
				}
				parentOne.AddChild(parentTwo);
			}	
			parentNode.AddChild(parentOne);
		}
		
		rp.add(parentNode);
		//Window.alert("loaded");
		registerMouseOver();
	}
	
	private native void registerMouseOver()/*-{		
		$wnd.jQuery('.dropsContainer').mouseenter(function(){
			var that = $wnd.jQuery(this);
			$wnd.jQuery('.node.dropTarget').removeClass('dropTarget');
			that.parent().addClass('dropTarget');
			
		});
	}-*/;

}

