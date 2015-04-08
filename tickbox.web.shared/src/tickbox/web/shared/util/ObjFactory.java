package tickbox.web.shared.util;




public class ObjFactory {
	private ObjFactory() {}
	
	public static IUtilObjFactory _util = new UtilObjFactoryGwt();
	public static IUtilObjFactory util() { return _util; }

}
