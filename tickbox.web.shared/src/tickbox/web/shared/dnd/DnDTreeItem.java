package com.example.dragdrop.client.dndtree;

import com.google.gwt.user.client.ui.FocusPanel;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.MouseListener;
import com.google.gwt.user.client.ui.TreeItem;
import com.google.gwt.user.client.ui.Widget;

public class DnDTreeItem extends TreeItem{

	private FocusPanel focus;
	private String type;
	private Widget content;

	public DnDTreeItem(){
		super();
	}

	public DnDTreeItem(String html){
		this(new Label(html));
		resize(html.length());
	}

	public DnDTreeItem(Widget widget) {
		this();
		content = widget;
		content.setStyleName("tree-item");
		focus = new FocusPanel(content);
		focus.setPixelSize(200, 20);
		focus.setTabIndex(-1);
		setWidget(focus);
	}

	public void setIndex(long index) {
		focus.setTitle(index+"");
	}

	public long getIndex() {
		return Long.parseLong(focus.getTitle());
	}

	public void addMouseListener(MouseListener mouseListener){
		focus.addMouseListener(mouseListener);
	}

	public void removeMouseListener(MouseListener mouseListener){
		focus.removeMouseListener(mouseListener);
	}

	public String toString(){
		String text = ((Label) content).getText();
		if (text != null) return "DnDTreeItem: "+focus.getElement().toString()+" "+text;
		else return "DnDTreeItem: "+focus.getElement().toString();
	}

	public void resize(int width){
		focus.setPixelSize(width*10, 20);
	}

	public void setType(String type) {
		this.type = type;
	}

	public String getType() {
		return type;
	}

	public Widget getContent() {
		return content;
	}
}