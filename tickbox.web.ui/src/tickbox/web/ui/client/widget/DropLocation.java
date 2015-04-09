package tickbox.web.ui.client.widget;

import com.allen_sauer.gwt.dnd.client.drop.HorizontalPanelDropController;
import com.google.gwt.core.client.GWT;
import com.google.gwt.uibinder.client.UiBinder;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.Widget;

public class DropLocation extends Composite {

	private static DropLocationUiBinder uiBinder = GWT
			.create(DropLocationUiBinder.class);

	interface DropLocationUiBinder extends UiBinder<Widget, DropLocation> {
	}

	private final boolean _isDummyDrop;
	private final boolean _isRootNode;
	
	// create a new drop location that doesn't do anything. 
	public DropLocation(boolean isRootNode, boolean isLastDrop) {
		this(-1,isRootNode,isLastDrop);
	}
	
	public DropLocation(int controller, boolean isRootNode, boolean isLastDrop){
		initWidget(uiBinder.createAndBindUi(this));
		
		_isDummyDrop = controller == -1;
		_isRootNode = isRootNode;
		if(!_isDummyDrop){
			// hook up dropping
		}else{
			this.addStyleName("deadDrop");			
		}
		
		if(isLastDrop){
			this.addStyleName("final");
		}
	}

}
