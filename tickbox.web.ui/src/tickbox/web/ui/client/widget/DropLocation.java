package tickbox.web.ui.client.widget;

import com.google.gwt.user.client.ui.Label;

public class DropLocation extends Label {
	
	public DropLocation(boolean enabled, boolean isLastDrop) {
		
		this.setPixelSize(20, 20);
						
		if(enabled){	
			this.addStyleName("validDrop");
		}else{
			this.addStyleName("deadDrop");			
		}
		
		if(isLastDrop){
			this.addStyleName("final");
		}
	}
	
	
	
}
