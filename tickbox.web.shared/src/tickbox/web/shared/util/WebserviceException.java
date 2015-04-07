package tickbox.web.shared.util;

import com.google.gwt.core.client.JavaScriptObject;

public class WebserviceException extends Exception {
	
	private static final long serialVersionUID = 5658082448049746761L;
	protected static class ImplWebserviceException extends JavaScriptObject {
		protected ImplWebserviceException() {}
		
		public final native String getServerMessage() /*-{ return this.Message; }-*/;
		public final native String getServerStackTrace() /*-{ return this.StackTrace; }-*/;
		public final native String getServerExceptionType() /*-{ return this.ExceptionType; }-*/;
		
		public static final native ImplWebserviceException fromJson(String json) /*-{ return eval('(' + json + ')'); }-*/;
	}
	
	private final ImplWebserviceException mEx; 
	
	public static WebserviceException newException(String json) {
		ImplWebserviceException ex = ImplWebserviceException.fromJson(json);
		return new WebserviceException(ex);
	}
	
	private WebserviceException(ImplWebserviceException ex) {
		super(ex.getServerMessage());	
		mEx = ex;		
	}
	
	public final String getServerMessage() { return mEx.getServerMessage(); }
	public final String getServerStackTrace() { return mEx.getServerStackTrace(); }
	public final String getServerExceptionType() { return mEx.getServerExceptionType(); }
}
