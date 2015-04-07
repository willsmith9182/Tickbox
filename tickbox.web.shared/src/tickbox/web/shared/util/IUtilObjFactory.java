package tickbox.web.shared.util;

public interface IUtilObjFactory {
	<T> IJsArray<T> newIJsArray();
	IJsArrayInteger newIJsArrayInteger();
	IJsArrayNumber newIJsArrayNumber();
	IJsArrayString newIJsArrayString();
}
