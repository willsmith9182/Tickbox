
	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto;

import tickbox.web.shared.dto.request.RequestObjFactoryStub;
import tickbox.web.shared.dto.request.IRequestObjFactory;
import tickbox.web.shared.dto.view.ViewObjFactoryStub;
import tickbox.web.shared.dto.view.IViewObjFactory;


public class DtoObjFactoryStub implements IDtoObjFactory {

	

	
	public IRequestObjFactory _request = new RequestObjFactoryStub();
	@Override public IRequestObjFactory request() { return _request; }
	
	public IViewObjFactory _view = new ViewObjFactoryStub();
	@Override public IViewObjFactory view() { return _view; }
	

}
