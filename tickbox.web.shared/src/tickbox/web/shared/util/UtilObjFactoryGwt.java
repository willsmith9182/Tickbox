package tickbox.web.shared.util;

import com.google.gwt.core.client.JavaScriptObject;

public class UtilObjFactoryGwt implements IUtilObjFactory {

	@Override
	public <T> IJsArray<T> newIJsArray() {
		return new JsArrayWrapper<JavaScriptObject, T>(Utils.createArray());
	}

	@Override
	public IJsArrayInteger newIJsArrayInteger() {
		return new JsArrayIntegerWrapper(Utils.createIntArray());
	}

	@Override
	public IJsArrayNumber newIJsArrayNumber() {
		return new JsArrayNumberWrapper(Utils.createNumberArray());
	}

	@Override
	public IJsArrayString newIJsArrayString() {
		return new JsArrayStringWrapper(Utils.createStringArray());
	}

}
