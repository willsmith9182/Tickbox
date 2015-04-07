


	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.ui.client.remotelogic;

import com.google.gwt.http.client.Request;
import com.google.gwt.json.client.JSONObject;
import tickbox.web.shared.dto.request.CreateNodeRequest;
import tickbox.web.shared.dto.request.ICreateNodeRequest;
import tickbox.web.shared.util.IRequestVoid;
import tickbox.web.shared.util.RemoteService;


	// ---- this is a generated file, please do not edit directly -------
public class Node implements INode {
	
	private static final String UrlPrefix = "../api/Node/";
	

    @Override
	public Request createNode(ICreateNodeRequest params, IRequestVoid req){
		return RemoteService.RemoteRequest(UrlPrefix + "CreateNode", new JSONObject((CreateNodeRequest)params), req);
	}



}