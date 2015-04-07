package tickbox.web.shared.util;




import com.google.gwt.dom.client.Element;
import com.google.gwt.dom.client.LIElement;
import com.google.gwt.dom.client.Style.Display;
import com.google.gwt.user.client.ui.Anchor;
import com.google.gwt.user.client.ui.HTMLPanel;
import com.google.gwt.user.client.ui.ListBox;
import com.google.gwt.user.client.ui.TextBoxBase;
import com.google.gwt.user.client.ui.UIObject;

public class WidgetUtil {
	private WidgetUtil() {
	}

	private static int mIdGenerator;

	
//	public static String ensureHasIdT(IsWidget w) {
//
//		IsElement e = w.getIsElement();
//		return ensureHasIdT(e, w.getClass().getName());
//
//	}
	
	public static String ensureHasId(UIObject w) {

		Element e = w.getElement();
		return ensureHasId(e, w.getClass().getName());

	}
	

//	public static String ensureHasIdT(IsElement e, String className) {
//
//		String eleId = e.getId();
//		if ("".equals(eleId)) {
//			String name = className;
//			int lastDotPos = name.lastIndexOf('.');
//			name = name.substring(lastDotPos + 1, name.length());
//			eleId = name + "_" + String.valueOf(mIdGenerator++);
//			e.setId(eleId);
//		}
//		return eleId;
//
//	}
	
	public static String ensureHasId(Element e, String className) {

		String eleId = e.getId();
		if ("".equals(eleId)) {
			String name = className;
			int lastDotPos = name.lastIndexOf('.');
			name = name.substring(lastDotPos + 1, name.length());
			eleId = name + "_" + String.valueOf(mIdGenerator++);
			e.setId(eleId);
		}
		return eleId;

	}

	public static String ensureHasId(Element e) {

		return ensureHasId(e, "a");
	}
	
	public static void setValidField(LIElement container, boolean isValid){
		if(isValid){
			container.addClassName("formcorrect");
		} else {
			container.addClassName("formerror");
		}
	}
	
	public static boolean validateRequiredField(TextBoxBase tb, LIElement container) {
		if ("".equals(tb.getValue().trim())){
			container.addClassName("formerror");
			return false;
		}
		container.addClassName("formcorrect");
		return true;
	}

	public static boolean validateRequiredField(ListBox tb, LIElement container) {
		if (tb.getSelectedIndex() == -1 || "".equals(tb.getValue(tb.getSelectedIndex()))){
			container.addClassName("formerror");
			return false;
		}
		container.addClassName("formcorrect");
		return true;
	}
	

	public static void setLoadingCssClass(UIObject w) {
		w.removeStyleName("no-records-mode");
		w.removeStyleName("loaded-mode");	
		w.addStyleName("loading-mode");
	}
	public static void setLoadedCssClass(UIObject w) {
		w.removeStyleName("loading-mode");
		w.addStyleName("loaded-mode");
	}
	public static void setNoRecordsCssClass(HTMLPanel w) {
		w.removeStyleName("loading-mode");
		w.addStyleName("no-records-mode");
	}
	public static void clearNoRecordsCssClass(HTMLPanel w) {
		w.removeStyleName("no-records-mode");
	}
	
	public static void clearValidationCss(LIElement container){
		container.removeClassName("formerror");
		container.removeClassName("formcorrect");
	}

	public static void setLoadingButton(Anchor b) {
		b.addStyleName("loadingbutton");
		b.setEnabled(false);
	}
	public static void clearLoadingButton(Anchor b) {
		b.removeStyleName("loadingbutton");
		b.setEnabled(true);
	}

	public static NullableDouble parseNullableDouble(String val) throws NumberFormatException {
		if (val == null) {
			val = "";
		}
		String str = val.trim();
		if ("".equals(str)) {
			return NullableDouble.getNull();
		}
		return new NullableDouble(Double.parseDouble(str));
	}
	
	public static NullableDouble parseNullableDouble(String val, NullableDouble valueOnError) {
		try {
			return parseNullableDouble(val);
		} catch (NumberFormatException e) {
			return valueOnError;
		}
	}


	public static NullableInteger parseNullableInteger(String val) throws NumberFormatException {
		if (val == null) {
			val = "";
		}
		String str = val.trim();
		if ("".equals(str)) {
			return NullableInteger.getNull();
		}
		return new NullableInteger(Integer.parseInt(str));
	}
	
	public static NullableInteger parseNullableInteger(String val, NullableInteger valueOnError) {
		try {
			return parseNullableInteger(val);
		} catch (NumberFormatException e) {
			return valueOnError;
		}
	}
	
//	
//	public static String formatMoney(double val, String marketCode) {
//		
//		CurrencyData cur;
//		
//		
//		if ("DE".equals(marketCode) || "IE".equals(marketCode)) {
//			cur = new DefaultCurrencyData("EUR", "€");
//		} else if ("UK".equals(marketCode)) {
//			cur = new DefaultCurrencyData("GBP", "£");
//		} else if ("US".equals(marketCode)) {
//			cur = new DefaultCurrencyData("USD", "$");
//		} else {
//			cur = new DefaultCurrencyData("USD", "$");
//		}
//		
//		String result = NumberFormat.getCurrencyFormat(cur).format(val);
//		
//		//Window.alert("m:" + marketCode + ",v:" + result);
//		
//		return result;
//	}	
//	
//	
//	public static String formatMoney(NullableDouble amt, String currencyCode) {
//		if (amt.isNull())  {
//			return "";
//		}
//		return formatMoney(amt.getDouble(), currencyCode);
//	}
	
	public static void setVisible(Element e, boolean vis) {
		if (vis) {
			e.getStyle().clearDisplay();
		} else {
			e.getStyle().setDisplay(Display.NONE);
		}
	}
	public static boolean isVisible(Element e) {
		return !e.getStyle().getDisplay().contains(Display.NONE.getCssName());
	}
	
	
	
	
	
	
//	public static void setAnchorHref(Anchor a, CsPlace p) {
//		a.setHref(getAnchorHref(p));			
//	}
//	
//	public static String getAnchorHref(CsPlace p) {
//		String hash = PlaceLogic.getPlaceHistoryMapper().getToken(p);
//		String href = Window.Location.createUrlBuilder().setHash(hash).buildString();		
//		return href;			
//	}

	public static void setSelectedValue(ListBox listBox,
			String value) {

		if (listBox.getItemCount() == 0) {
			return;
		}
		
		int toSelect = 0;
		
		for(int i = 0; i < listBox.getItemCount(); i++) {
			if (listBox.getValue(i).equals(value)) {
				toSelect = i;
				break;
			}
		}
		
		listBox.setSelectedIndex(toSelect);		
	}
	
	

	private static int logNum = 0;
	public static void consoleLog(String msg) {
		consoleLog2(msg, String.valueOf(logNum++));
	}
	  private static native void consoleLog2( String message, String logNum) /*-{
	      console.log( logNum + message );
	  }-*/;
}