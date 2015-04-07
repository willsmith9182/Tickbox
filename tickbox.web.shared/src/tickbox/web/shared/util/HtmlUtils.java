package tickbox.web.shared.util;

import com.google.gwt.safehtml.shared.SafeHtmlUtils;

public class HtmlUtils {

	public static String htmlEscape(String html){
		if(html != null){
			return SafeHtmlUtils.htmlEscape(html);
		}
		return "";
	}
}
