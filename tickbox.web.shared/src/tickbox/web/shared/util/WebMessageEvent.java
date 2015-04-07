package tickbox.web.shared.util;


import com.google.gwt.event.shared.EventHandler;
import com.google.gwt.event.shared.GwtEvent;

public class WebMessageEvent extends GwtEvent<WebMessageEvent.IHandler> {
	
	public static interface IHandler extends EventHandler {
		void onReceived (WebMessageEvent evt);
	}

	private static final GwtEvent.Type<IHandler> TYPE = new GwtEvent.Type<IHandler>();
	
	private final String mJsonMsg;
	
	public WebMessageEvent(String jsonMsg) {
		mJsonMsg = jsonMsg;
	}
	
	public String getJsonMsg() {
		return mJsonMsg;
	}
	
	public static GwtEvent.Type<IHandler> getType(){
		return TYPE;
	}
	
	@Override
	public GwtEvent.Type<IHandler> getAssociatedType() {
		return TYPE;
	}

	@Override
	protected void dispatch(IHandler handler) {
		handler.onReceived(this);		
	}
}

