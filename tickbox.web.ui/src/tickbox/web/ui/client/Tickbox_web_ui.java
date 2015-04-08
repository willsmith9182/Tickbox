package tickbox.web.ui.client;

import tickbox.web.ui.client.widget.TreeNode;

import com.allen_sauer.gwt.dnd.client.drop.FlowPanelDropController;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.user.client.ui.RootPanel;



public class Tickbox_web_ui implements EntryPoint {
		
	public void onModuleLoad() {
		
		RootPanel rp = RootPanel.get("errorLabelContainer");
		TreeNode parentNode = new TreeNode("Root Node");
		for(int i = 0; i< 10; i++){
			TreeNode parentOne = new TreeNode("Node : "+ (i+1));
			for(int j = 0; i< 3; i++){
				TreeNode parentTwo = new TreeNode("Node : "+ (i+1) + " : " + (j+1));
				for(int k = 0; i< 2; i++){
					TreeNode child = new TreeNode("Node : "+ (i+1) + " : " + (j+1) + " : " + (k+1));			
					parentTwo.AddChild(child);
				}	
				parentOne.AddChild(parentTwo);
			}	
			parentNode.AddChild(parentOne);
		}
		
		rp.add(parentNode);
	}
}
