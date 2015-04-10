package tickbox.web.ui.client;

import java.util.ArrayList;
import java.util.List;

import tickbox.web.ui.client.widget.DragDropLabel;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.user.client.Random;
import com.google.gwt.user.client.ui.RootPanel;
import com.google.gwt.user.client.ui.Tree;
import com.google.gwt.user.client.ui.TreeItem;



public class Tickbox_web_ui implements EntryPoint {
		
	public void onModuleLoad() {
		Tree aTree = new Tree();
		RootPanel rp = RootPanel.get("rooty");
		rp.add(aTree);
		
		// root is not draggable.
				TreeItem root = new TreeItem(new DragDropLabel("root", false, true));
				aTree.addItem(root);
				
				
				// Add some folders
				root.addItem(new DragDropLabel("folder1", true, true));
				root.addItem(new DragDropLabel("folder2", true, true));
				
				TreeItem folder3 = root.addItem(new DragDropLabel("folder3", true, true));
				folder3.addItem(new DragDropLabel("folder3-1", true, true));
				folder3.addItem(new DragDropLabel("folder3-2", true, true));

				// Add some leaves to the tree
				List<TreeItem> stack = new ArrayList<TreeItem>();
				stack.add(aTree.getItem(0));
				
				int filenum=1;
				while(!stack.isEmpty())
				{
					TreeItem item = stack.remove(0);
					for(int i=0;i<item.getChildCount();i++)
					{
						stack.add(item.getChild(i));
					}

					int files = Random.nextInt(4) + 1;
					for(int j=0;j<files;j++)
					{
						item.addItem(new TreeItem(new DragDropLabel("File " + filenum, true, false)));
						filenum++;
					}
					item.setState(true);
				}
	}


}

