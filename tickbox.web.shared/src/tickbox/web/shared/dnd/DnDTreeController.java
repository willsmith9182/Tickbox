package com.example.dragdrop.client.dndtree;

import java.util.HashMap;

import com.google.gwt.user.client.DOM;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.AbsolutePanel;
import com.google.gwt.user.client.ui.ClickListener;
import com.google.gwt.user.client.ui.DialogBox;
import com.google.gwt.user.client.ui.FocusPanel;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.MouseListenerAdapter;
import com.google.gwt.user.client.ui.Tree;
import com.google.gwt.user.client.ui.TreeItem;
import com.google.gwt.user.client.ui.Widget;



public class DnDTreeController{

	private HashMap treeItems;
	private Widget movingWidget;
	private long itemCount;
	private Tree leftTree;
	private Tree rightTree;
	private boolean dragging = false;
	private Widget clone;
	private AbsolutePanel boundaryPanel;

	private MouseListenerAdapter mouseListenerAdapter = new MouseListenerAdapter() {
		public void onMouseUp(Widget sender, int x, int y) {
			super.onMouseUp(sender, x, y);
			dragging = false;
			DOM.releaseCapture(movingWidget.getElement());

			DnDTreeItem dndMovingItem = (DnDTreeItem) treeItems.get(movingWidget.getTitle());

			DnDTreeItem newParent = hitTestRightTree(rightTree);
			if (newParent != null && newParent != dndMovingItem) {
				newParent.addItem(dndMovingItem);
			}
			else {
				newParent = hitTestRightTree(leftTree);
				if (newParent != null && newParent != dndMovingItem) newParent.addItem(dndMovingItem);
			}
			clone.removeFromParent();
		}

		public void onMouseDown(Widget sender, int x, int y) {
			super.onMouseDown(sender, x, y);
			movingWidget = sender;
			DnDTreeItem dndMovingItem = (DnDTreeItem) treeItems.get(movingWidget.getTitle());
			dragging = true;
			clone = new Label(((Label)dndMovingItem.getContent()).getText());
			clone.setStyleName("clone-tree-item");
			boundaryPanel.add(clone,x+movingWidget.getAbsoluteLeft()-boundaryPanel.getAbsoluteLeft(), y+movingWidget.getAbsoluteTop()-boundaryPanel.getAbsoluteTop());
			DOM.setCapture(movingWidget.getElement());
		}

		public void onMouseMove(Widget sender, int x, int y) {
			super.onMouseMove(sender, x, y);
			if (!dragging) return;
			boundaryPanel.setWidgetPosition(clone, x+movingWidget.getAbsoluteLeft()-boundaryPanel.getAbsoluteLeft(), y+movingWidget.getAbsoluteTop()-boundaryPanel.getAbsoluteTop());
		}
	};

	public DnDTreeController(){
		treeItems = new HashMap();
		itemCount = 0;
	}

	public void makeDraggable(DnDTreeItem item){
		treeItems.put(itemCount+"", item);
		item.setIndex(itemCount);
		itemCount++;
		item.addMouseListener(mouseListenerAdapter);
	}

	public void setRightTree(Tree tree) {
		this.rightTree = tree;
	}

	public void setLeftTree(Tree tree) {
		this.leftTree = tree;
	}

	public void setBoundaryPanel(AbsolutePanel boundaryPanel) {
		this.boundaryPanel = boundaryPanel;
	}

	public AbsolutePanel getBoundaryPanel() {
		return boundaryPanel;
	}

	private DnDTreeItem hitTestRightTree(Tree tree) {
		DnDTreeItem root = (DnDTreeItem) tree.getItem(0);

		DnDTreeItem result = findDropTarget(root);

		return result;
	}

	private DnDTreeItem findDropTarget(DnDTreeItem root) {
		if (root.getChildCount() == 0) {
			if (clone.getAbsoluteLeft() > root.getAbsoluteLeft()
					&& clone.getAbsoluteTop() > root.getAbsoluteTop()
					&& clone.getAbsoluteLeft()+clone.getOffsetWidth() < root.getAbsoluteLeft()+root.getAbsoluteLeft()+100
					&& clone.getAbsoluteTop()+clone.getOffsetHeight() < root.getAbsoluteTop()+root.getOffsetHeight()+30){
				return root;
			}
			else return null;
		}
		for (int i = root.getChildCount()-1; i >= 0; i--) {
			DnDTreeItem item = findDropTarget((DnDTreeItem)root.getChild(i));
			if (item != null) return item;
		}
		if (clone.getAbsoluteLeft() > root.getAbsoluteLeft()
				&& clone.getAbsoluteTop() > root.getAbsoluteTop()
				&& clone.getAbsoluteLeft()+clone.getOffsetWidth() < root.getAbsoluteLeft()+root.getAbsoluteLeft()+100
				&& clone.getAbsoluteTop()+clone.getOffsetHeight() < root.getAbsoluteTop()+root.getOffsetHeight()+30){
			return root;
		}
		return null;
	}
}