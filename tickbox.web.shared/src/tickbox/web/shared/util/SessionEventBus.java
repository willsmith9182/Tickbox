package tickbox.web.shared.util;

import java.util.Date;
import java.util.HashMap;


import tickbox.web.shared.util.WebMessageEvent.IHandler;

import com.google.gwt.core.client.Scheduler;
import com.google.gwt.core.client.Scheduler.RepeatingCommand;
import com.google.gwt.event.shared.HandlerManager;
import com.google.gwt.event.shared.HandlerRegistration;
import com.google.gwt.http.client.Request;
import com.google.gwt.json.client.JSONNumber;
import com.google.gwt.json.client.JSONObject;

public class SessionEventBus {
	private SessionEventBus() {}
	

	private static Request _webMsgRequest;
	private static DateTime _lastWebMsgRequest = new DateTime(new Date());

	public static void Init(final int sessionId, final String relativeUrl) {
		Init(sessionId,NullableInteger.getNull(), relativeUrl);
	}
	
	public static void Init(final int sessionId, final NullableInteger partnerId,final String relativeUrl) {
	
		Scheduler.get().scheduleFixedDelay(new RepeatingCommand() {
			
			@Override
			public boolean execute() {
				pollForWebMessage(sessionId,partnerId, relativeUrl);
				return true;
			}

		}, 1000 /* 1 second */);
	}


	public static HandlerRegistration addListener(String component, IHandler handler) {
		if (!mHandlers.containsKey(component)) {
			mHandlers.put(component, new HandlerManager(null));
		}
		HandlerManager handlerManager = mHandlers.get(component);
		
		HandlerRegistration reg = handlerManager.addHandler(WebMessageEvent.getType(), handler);
		
		return new SessionHandlerRegistration(reg, component);
	}
	
	private static void fireEvent(SessionMessage msg) {
		if (mHandlers.containsKey(msg.getDestinationComponent())) {
			HandlerManager handlerManager = mHandlers.get(msg.getDestinationComponent());
			handlerManager.fireEvent(new WebMessageEvent(msg.getJsonMsg()));
		}
	}
	
	
	private static void pollForWebMessage(int sessionId, NullableInteger partnerId, String relativeUrl) {
		if (_webMsgRequest == null && (
				// look for messages if we've either have a listener, or we haven't looked in a few minutes
				SessionEventBus.hasListners() 
				|| DateTime.toDate(_lastWebMsgRequest).before(DateTime.toDate((new DateTime(new Date())).addSeconds(-500)))
				)) {
		
			_webMsgRequest = ReceiveFromSession(sessionId, partnerId, relativeUrl, new IRequest<SessionMessage>() {
	
				@Override
				public void onSuccess(SessionMessage msg) {
					_webMsgRequest = null;
					_lastWebMsgRequest = new DateTime(new Date());
					if (msg != null) {
						SessionEventBus.fireEvent(msg);
					}
					
				}
	
				@Override
				public void onError(Throwable exception) {
					_webMsgRequest = null;
					// do nothing
				}
			});
		}
	}
	

	private static class SessionHandlerRegistration implements HandlerRegistration {
		private final HandlerRegistration _reg;
		private final String _component;
		
		SessionHandlerRegistration(HandlerRegistration reg, String component) {
			_reg = reg;			
			_component = component;
			if (!mHandlerCounts.containsKey(component)) {
				mHandlerCounts.put(component, new Integer(0));
			}
			mHandlerCounts.put(_component, new Integer(mHandlerCounts.get(_component).intValue() + 1));
		}
		

		@Override
		public void removeHandler() {
			_reg.removeHandler();			
			mHandlerCounts.put(_component, new Integer(mHandlerCounts.get(_component).intValue() - 1));
		} 
	}

	private static HashMap<String, HandlerManager> mHandlers = new HashMap<String, HandlerManager>();
	private static HashMap<String, Integer> mHandlerCounts = new HashMap<String, Integer>();
	


	private static boolean hasListners() {
		int sum = 0;
		for(String key : mHandlerCounts.keySet()) {
			sum += mHandlerCounts.get(key).intValue();
		}
		return sum > 0;
	}
	
	

	private static Request ReceiveFromSession(int sessionId, NullableInteger partnerId, String relativeUrl,	IRequest<SessionMessage> req) {	

		JSONObject postParams = new JSONObject();
		postParams.put("sessionId", new JSONNumber(sessionId));
		postParams.put("partnerId", new JSONNumber(partnerId.getInt()));
		
		return RemoteService.RemoteRequest(relativeUrl, postParams, new ReqConverter<SessionMessage>(req){

			@Override
			public SessionMessage convert(String data) {
				return data == null ? null : SessionMessage.asObject(data);
			}
		});
	}
}
