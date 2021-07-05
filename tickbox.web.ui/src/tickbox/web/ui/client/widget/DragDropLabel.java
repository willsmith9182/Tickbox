package tickbox.web.ui.client.widget;

/* This file is part of "DragDropTree".

"DragDropTree" is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

"DragDropTree" is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with "DragDropTree".  If not, see <http://www.gnu.org/licenses/>.
*/

import java.util.ArrayList;
import java.util.List;

import com.google.gwt.event.dom.client.DragLeaveEvent;
import com.google.gwt.event.dom.client.DragLeaveHandler;
import com.google.gwt.event.dom.client.DragOverEvent;
import com.google.gwt.event.dom.client.DragOverHandler;
import com.google.gwt.event.dom.client.DragStartEvent;
import com.google.gwt.event.dom.client.DragStartHandler;
import com.google.gwt.event.dom.client.DropEvent;
import com.google.gwt.event.dom.client.DropHandler;
import com.google.gwt.user.client.Element;
import com.google.gwt.user.client.ui.Label;
import com.google.gwt.user.client.ui.Tree;
import com.google.gwt.user.client.ui.TreeItem;
import com.google.gwt.user.client.ui.Widget;

public class DragDropLabel extends Label
{
    private static DragDropLabel dragging = null;
    
    final boolean droppable;
    public DragDropLabel(String text, boolean draggable, boolean droppable)
    {
        super(text);
        if (draggable)
        {
            initDrag();
        }
        if (droppable)
        {
            initDrop();
        }
        this.droppable = droppable;
        
        if (droppable)
        {
            addStyleName("droppable");
        }
        else if (draggable)
        {
            addStyleName("draggable");
        }
    }
    
    private void initDrag()
    {
        getElement().setDraggable(Element.DRAGGABLE_TRUE);

        addDragStartHandler(new DragStartHandler() 
        {
            @Override
            public void onDragStart(DragStartEvent event) 
            {
                // Remember what's being dragged
                dragging = DragDropLabel.this;
                // Must set for FireFox
                event.setData("text", "hi there");
                
                // Copy the label image for the drag icon
                // 10,10 indicates the pointer offset, not the image size.
                event.getDataTransfer().setDragImage(getElement(), 10, 10);
            }
        });
    }
    
    private void initDrop()
    {
        addDomHandler(new DragOverHandler() 
        {
            @Override
            public void onDragOver(DragOverEvent event) 
            {
                addStyleName("dropping");
            }
        }, DragOverEvent.getType());
        
        addDomHandler(new DragLeaveHandler() 
        {
            @Override
            public void onDragLeave(DragLeaveEvent event) 
            {
                removeStyleName("dropping");
            }
        }, DragLeaveEvent.getType());

        
        addDomHandler(new DropHandler()
        {
            @Override
            public void onDrop(DropEvent event) 
            {
                event.preventDefault();
                if (dragging != null)
                {
                    // Target treeitem is found via 'this';
                    // Dragged treeitem is found via 'dragging'.
                    
                    TreeItem dragTarget = null;
                    TreeItem dragSource = null;

                    // The parent of 'this' is not the TreeItem, as that's not a Widget.
                    // The parent is the tree containing the treeitem.
                    Tree tree = (Tree)DragDropLabel.this.getParent();
                    
                    // Visit the entire tree, searching for the drag and drop TreeItems

                    List<TreeItem> stack = new ArrayList<TreeItem>();
                    stack.add(tree.getItem(0));
                    while(!stack.isEmpty())
                    {
                        TreeItem item = stack.remove(0);
                        for(int i=0;i<item.getChildCount();i++)
                        {
                            stack.add(item.getChild(i));
                        }

                        Widget w = item.getWidget();
                        if (w != null)
                        {
                            if (w == dragging)
                            {
                                dragSource = item;
                                if (dragTarget != null)
                                {
                                    break;
                                }
                            }
                            if (w == DragDropLabel.this)
                            {
                                dragTarget = item;
                                w.removeStyleName("dropping");
                                if (dragSource != null)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    
                    // Do we have a source and a target?
                    if (dragSource != null && dragTarget != null)
                    {
                        // Make sure that target is not a child of dragSource
                        
                        TreeItem test = dragTarget;
                        while(test != null)
                        {
                            if (test == dragSource)
                            {
                                return;
                            }
                            test = test.getParentItem();
                        }
                        
                        // Move the dragged item (source) under the target.
                        dragTarget.addItem(dragSource);
                        // Make sure the the target treeitem is open.
                        dragTarget.setState(true);
                    }
                    dragging = null;
                }
            }
        }, DropEvent.getType());
    }
}
