



	// this is a generated file from the "Tool.GenerateJava" project in .Net, please do not edit directly

package tickbox.web.shared.dto.view;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import tickbox.web.shared.util.JsIterable;
import tickbox.web.shared.util.Utils;
import java.util.Date;

	// ---- this is a generated file, please do not edit directly -------
public class OtherMenuModel extends JavaScriptObject implements IOtherMenuModel {
	protected OtherMenuModel() {}
	

	@Override public final native int getThingy() /*-{ return this.Thingy }-*/;
	@Override public final native OtherMenuModel setThingy(int val) /*-{ this.Thingy = val; return this; }-*/;
	private final native String getThingytwoStr() /*-{ return this.Thingytwo }-*/;
	private final native void setThingytwoStr(String val) /*-{ this.Thingytwo = val; }-*/;
	public final Date getThingytwo() {  return Utils.parseLosslessDateTime(getThingytwoStr()).getDate();  }
	public final OtherMenuModel setThingytwo(Date d) { setThingytwoStr(Utils.formatLosslessDateTime(d)); return this; }



	
	private static final native OtherMenuModel asObjectRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final OtherMenuModel asObject(String json) { OtherMenuModel o = asObjectRaw(json); if (o != null) {o.convertDates();} return o; }
	private static final native JsArray<OtherMenuModel> asArrayRaw(String json) /*-{ var o = eval('(' + json + ')'); return o === null ? o : o.d === undefined ? o : o.d; }-*/;
	public static final JsArray<OtherMenuModel> asArray(String json) { JsArray<OtherMenuModel> l = asArrayRaw(json); for(OtherMenuModel o : new JsIterable<OtherMenuModel>(l)) { o.convertDates(); } return l; }

	

	public final void convertDates() {
			setThingytwoStr(Utils.formatLosslessDateTime(Utils.parseDtoDateTime(getThingytwoStr())));
			
		
	}
	


	public static final OtherMenuModel newObj() {
		OtherMenuModel result = asObject("{d:{}}");
		result.setThingy(0);
		result.setThingytwo(new Date());
	
				
		return result;
	}

}

