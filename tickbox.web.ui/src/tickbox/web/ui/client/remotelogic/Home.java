


	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.ui.client.remotelogic;

import com.google.gwt.http.client.Request;
import com.google.gwt.json.client.JSONObject;
import tickbox.web.shared.dto.view.IMenuViewModel;
import tickbox.web.shared.dto.view.MenuViewModel;
import tickbox.web.shared.util.IJsArray;
import tickbox.web.shared.util.IRequest;
import tickbox.web.shared.util.JsArrayWrapper;
import tickbox.web.shared.util.RemoteService;
import tickbox.web.shared.util.ReqConverter;


	// ---- this is a generated file, please do not edit directly -------
public class Home implements IHome {
	
	private static final String UrlPrefix = "../api/Home/";
	

    @Override
	public Request index(IMenuViewModel params, final IRequest<IJsArray<IMenuViewModel>> req){
		return RemoteService.RemoteRequest(UrlPrefix + "Index", new JSONObject((MenuViewModel)params), new ReqConverter<IJsArray<IMenuViewModel>>(req){
			@Override
			public IJsArray<IMenuViewModel> convert(String val){
				return new JsArrayWrapper<MenuViewModel, IMenuViewModel>(MenuViewModel.asArray(val));
			}
		});
	}



}