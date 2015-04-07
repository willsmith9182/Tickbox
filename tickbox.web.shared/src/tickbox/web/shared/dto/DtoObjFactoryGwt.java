
	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto;

import tickbox.web.shared.dto.request.RequestObjFactoryGwt;
import tickbox.web.shared.dto.request.IRequestObjFactory;
import tickbox.web.shared.dto.view.ViewObjFactoryGwt;
import tickbox.web.shared.dto.view.IViewObjFactory;


public class DtoObjFactoryGwt implements IDtoObjFactory{

	



	
	private final RequestObjFactoryGwt _request = new RequestObjFactoryGwt();
	@Override public IRequestObjFactory request() { return _request; }	
	
	private final ViewObjFactoryGwt _view = new ViewObjFactoryGwt();
	@Override public IViewObjFactory view() { return _view; }	

}
