package tickbox.web.shared.util;

import tickbox.web.shared.dto.IDtoObjFactory;


public class ObjFactory {
	private ObjFactory() {}
	
	public static IUtilObjFactory _util = new UtilObjFactoryGwt();
	public static IUtilObjFactory util() { return _util; }
	public static IDtoObjFactory _dto = new tickbox.web.shared.dto.DtoObjFactoryGwt();
	public static IDtoObjFactory dto() { return _dto; }
}
