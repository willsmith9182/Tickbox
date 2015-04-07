package tickbox.web.shared.util;

import com.google.gwt.json.client.JSONNumber;
import com.google.gwt.json.client.JSONObject;
import com.google.gwt.json.client.JSONParser;
import com.google.gwt.json.client.JSONValue;

public class DInt {
	private DInt() {}
	

	public static int toInt(String json) {
		JSONValue val = JSONParser.parseStrict(json);
		JSONObject obj = val.isObject();
		if (obj != null) {			
			JSONNumber dVal = (JSONNumber)obj.get("d");
			return (int)dVal.doubleValue();
		} else {
			return (int)val.isNumber().doubleValue();
		}
	}
}
