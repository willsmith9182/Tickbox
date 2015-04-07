package tickbox.web.shared.util;

import com.google.gwt.json.client.JSONBoolean;
import com.google.gwt.json.client.JSONObject;
import com.google.gwt.json.client.JSONParser;
import com.google.gwt.json.client.JSONValue;

public class DBoolean {
	private DBoolean() {}
	

	  
	public static boolean toBoolean(String json) {
		JSONValue val = JSONParser.parseStrict(json);
		JSONObject obj = val.isObject();
		if (obj != null) {			
			JSONBoolean dVal = (JSONBoolean)obj.get("d");
			return dVal.booleanValue();
		} else {
			return val.isBoolean().booleanValue();
		}
	}
}
