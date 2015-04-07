package tickbox.web.shared.util;



import com.google.gwt.core.client.GWT;
import com.google.gwt.http.client.Request;
import com.google.gwt.http.client.RequestBuilder;
import com.google.gwt.http.client.RequestCallback;
import com.google.gwt.http.client.Response;
import com.google.gwt.http.client.URL;
import com.google.gwt.json.client.JSONValue;

public class RemoteService {


	
	public static Request RemoteRequest(String methodUrl, JSONValue postDataObject, final IRequestVoid req){
		IRequest<String> reqInner = new IRequest<String>() {

			@Override
			public void onError(Throwable exception) {
				req.onError(exception);
			}

			@Override
			public void onSuccess(String data) {
				req.onSuccess();
			}
			
		};
		
		return RemoteRequest(methodUrl, postDataObject, new ReqConverter<String>(reqInner){

			@Override
			public String convert(String val) {
				return null;
			}
			
		});
	}
	
	public static Request RemoteRequest(String methodUrl, IReqConverter req)
	{		
		return RemoteRequest(methodUrl, "", req, true);
	}
	
	public static Request RemoteRequest(String methodUrl, JSONValue postDataObject, IReqConverter req)
	{

		String sPostDataObj = "{}";
		
		if(postDataObject != null)
		{
			sPostDataObj = postDataObject.toString();
		}
		
		return RemoteRequest(methodUrl, sPostDataObj, req, true);
	}
	
	public static Request RemoteRequest(String methodUrl, String sPostDataObj, IReqConverter req)
	{
		return RemoteRequest(methodUrl, sPostDataObj, req, false);
	}
	
	private static Request RemoteRequest(String methodUrl, String sPostDataObj, final IReqConverter req, boolean isJson)
	{
		RequestBuilder builder = new RequestBuilder(RequestBuilder.POST, URL.encode(GWT.getModuleBaseURL() + methodUrl));
		
		if(isJson)
		{
			builder.setHeader("Content-Type", "application/json; charset=utf-8");
		}
		else
		{
			builder.setHeader("Content-Type", "application/x-www-form-urlencoded");
		}
		
		try
		{
			return builder.sendRequest(sPostDataObj, new RequestCallback()
			{
				public void onError(Request request, Throwable exception) 
				{
					req.onError(exception);
				}

				public void onResponseReceived(Request request, Response response)
				{
					if (200 == response.getStatusCode() || 204 == response.getStatusCode()) {
						
						String data = response.getText();
						
						req.onSuccess(data);
					}
					else if (403 == response.getStatusCode() || 401 == response.getStatusCode()) {
						req.onError(new WebserviceAuthenticationException());
					}
					else
					{
						String json = response.getText();				
						if (json.contains("ExceptionType")) {
							WebserviceException ex = WebserviceException.newException(json);
							req.onError(ex);
						} else {
							String errMsg = (response.getText() == null ? "" : response.getText()) +
									(response.getStatusText() == null ? "" : "\r\n" + response.getStatusText()) +
									"\r\nerror code: " + response.getStatusCode();
											
							req.onError(new Throwable(errMsg));
						}
					}
				}
			});
			
		}
		catch(Exception e) 
		{
			req.onError(e);
			return null;
		}
	}
}
