package tickbox.web.shared.util;

import com.google.gwt.json.client.JSONObject;
import com.google.gwt.json.client.JSONParser;
import com.google.gwt.json.client.JSONString;
import com.google.gwt.json.client.JSONValue;

public class DString {
	private DString() {}
	

	
	public static String toString(String json) {
		JSONValue val = JSONParser.parseStrict(json);
		JSONObject obj = val.isObject();
		if (obj != null) {			
			JSONValue dVal = obj.get("d");
			JSONString dStr = dVal.isString();
			if (dStr != null) {
				return dStr.stringValue();
			}
			return null;
		} else {
			JSONString dStr = val.isString();
			if (dStr != null) {
				return dStr.stringValue();
			}
			return null;
		}
	}
}
