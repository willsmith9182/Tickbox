package tickbox.web.shared.util;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.util.Arrays;
import java.util.List;
import java.util.Date;
import com.google.gwt.user.datepicker.client.CalendarUtil;
import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import com.google.gwt.core.client.JsArrayInteger;
import com.google.gwt.core.client.JsArrayNumber;
import com.google.gwt.core.client.JsArrayString;
import com.google.gwt.core.client.JsDate;
import com.google.gwt.dom.client.AnchorElement;
import com.google.gwt.dom.client.Document;
import com.google.gwt.i18n.client.DateTimeFormat;
import com.google.gwt.i18n.client.NumberFormat;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.ListBox;

public class Utils {

	private static DateTimeFormat mDateTimeFmt = DateTimeFormat
			.getFormat("dd/MM/yyyy HH:mm:ss");
	private static DateTimeFormat mLosslessDateTimeFmt = DateTimeFormat
			.getFormat("yyyy-MM-dd HH:mm:ss.SSS ZZZ");
	private static DateTimeFormat mLosslessWebApiDateTimeFmt = DateTimeFormat
			.getFormat("yyyy-MM-ddTHH:mm:ss.SSSZZZ");
	private static DateTimeFormat mWebApiDateTimeFmt = DateTimeFormat
			.getFormat("yyyy-MM-ddTHH:mm:ssZZZ");	
	private static DateTimeFormat mDateFmt = DateTimeFormat
			.getFormat("dd/MM/yyyy");
	private static DateTimeFormat mDateFmt2 = DateTimeFormat
			.getFormat("yyyy-MM-dd");
	private static NumberFormat mPercentFmt2 = NumberFormat.getFormat("0.00%");

	/* Constants for the getDate() method of Date */
	public static class DayOfWeek {
		public static final int Sunday = 0;
		public static final int Monday = 1;
		public static final int Tuesday = 2;
		public static final int Wednesday = 3;
		public static final int Thursday = 4;
		public static final int Friday = 5;
		public static final int Saturday = 6;
	}
	

	public static String CapitaliseFirstWords(String s) {
		final StringBuilder result = new StringBuilder(s.length());
		String[] words = s.split("\\s");
		for (int i = 0, l = words.length; i < l; ++i) {
			if (i > 0)
				result.append(" ");
			result.append(Character.toUpperCase(words[i].charAt(0))).append(
					words[i].substring(1));

		}
		return result.toString();
	}

	public static NullableDate fromDateKey(NullableInteger dateKey){
		if(dateKey.isNull()){
			return new NullableDate();
		}
		return new NullableDate(fromDateKey(dateKey.getInt()));
	}
	
	

	public static NullableInteger toDateKey(NullableDate date){
		if(date.isNull()){
			return NullableInteger.getNull();
		}
		return new NullableInteger(toDateKey(date.getDate()));
	}
			
	public static Date fromDateKey(int dateKey) {
		if (dateKey == 0) {
			dateKey = 19000101;
		}

		String keyString = Integer.toString(dateKey);

		String year = keyString.substring(0, 4);
		String month = keyString.substring(4, 6);
		String day = keyString.substring(6, 8);

		DateTimeFormat format = DateTimeFormat.getFormat("dd/MM/yyyy");

		return format.parse(day + "/" + month + "/" + year);
	}

	public static int toDateKey(Date date) {
		@SuppressWarnings("deprecation")
		int year = date.getYear() + 1900; // Year subtracts 1900 from the year.
		@SuppressWarnings("deprecation")
		int month = date.getMonth() + 1; // Month is zero indexed....
		@SuppressWarnings("deprecation")
		int day = date.getDate();

		String yearString = Integer.toString(year);
		String monthString = new String();
		String dayString = new String();

		if (month >= 10)
			monthString = Integer.toString(month);
		else
			monthString = "0" + Integer.toString(month);

		if (day >= 10)
			dayString = Integer.toString(day);
		else
			dayString = "0" + Integer.toString(day);

		String dateString = yearString + monthString + dayString;

		return Integer.parseInt(dateString);
	}

	public static String formatDate(Date dt, DateTimeFormat fmt) {
		if (Utils.toDateKey(dt) == 19700101) {
			return "";
		}
		return fmt.format(dt);
	}

	public static class BooleanResult {
		private boolean result;

		public void setResult(boolean value) {
			result = value;
		}

		public boolean getResult() {
			return result;
		}
	}

	public static String formatDate(Date dt) {
		return formatDate(dt, mDateFmt);
	}
	
	public static String formatDate(DateTime d, DateTimeFormat format)
	{
		if (d == null) {
			return "";
		}
		return formatDate(DateTime.toDate(d), format);
	}

	public static String formatDate(DateTime d) {
		if (d == null) {
			return "";
		}
		return formatDate(DateTime.toDate(d));
	}

	/**
	 * dd/MM/yyyy
	 */
	public static String formatDate(NullableDate dt) {
		if (dt == null || dt.isNull())
			return "";
		else
			return formatDate(dt.getDate(), mDateFmt);
	}

	/**
	 * yyyy-MM-dd
	 */
	public static String formatDate2(Date dt) {
		return formatDate(dt, mDateFmt2);
	}

	/**
	 * dd/MM/yyyy HH:mm:ss
	 */
	public static String formatDateTime(Date dt) {
		return formatDate(dt, mDateTimeFmt);
	}	

	/**
	 * dd/MM/yyyy HH:mm:ss
	 */
	public static String formatDateTime(DateTime dt) {
		return formatDateTime(DateTime.toDate(dt));
	}

	public static Date parseDate(String val) {
		return parseDateTime(val, mDateFmt);
	}
	
	public static NullableDate parseDateToNullableDate(String val) {
		if (val == "")
			return new NullableDate();
		else
			return new NullableDate(parseDateTime(val, mDateFmt));
	}

	public static Date parseDateTime(String val, DateTimeFormat fmt) {
		return fmt.parseStrict(val);
	}

	public static Date parseDateTime(String val) {
		if (val.contains(":")) {
			return parseDateTime(val, mDateTimeFmt);
		}
		return parseDate(val);
	}

	public static Date addDays(Date d, int days) {
		Date d2 = CalendarUtil.copyDate(d);
		CalendarUtil.addDaysToDate(d2, days);
		return d2;
	}
	
	public static Date addMonths(Date d, int months) {
		Date d2 = CalendarUtil.copyDate(d);
		CalendarUtil.addMonthsToDate(d2, months);
		return d2;
	}
	
	public static void resetTime(Date d) {
		
		// same logic but without warnings? -Clay
//		DateTime dt = new DateTime(d);
//		dt = dt.getDate();
//		dt = dt.addHours(12);
//		
//		Date newD = dt.toDate();
//		d.setTime(newD.getTime());
		
		
		long msec = d.getTime();
	    msec = (msec / 1000) * 1000;
	    d.setTime(msec);

	    // Daylight savings time occurs at midnight in some time zones, so we reset
	    // the time to noon instead.
	    d.setHours(12);
	    d.setMinutes(0);
	    d.setSeconds(0);

	}

	// public static CsUiStatus getCsUiStatus(WLStatus whiteLabelStatus)
	// {
	// switch(whiteLabelStatus)
	// {
	// case Setup:
	// return CsUiStatus.InProgress;
	// case Live:
	// return CsUiStatus.Active;
	// case LivePaymentFailed:
	// case LivePausedAndPaymentFailed:
	// return CsUiStatus.PaymentFailed;
	// case LivePaused:
	// return CsUiStatus.Paused;
	// case EndedDeclined:
	// return CsUiStatus.PaymentFailedCancelled;
	// case EndedBlocked:
	// return CsUiStatus.Disapproved;
	// case Ended:
	// return CsUiStatus.Ended;
	// case SetupOnHold:
	// return CsUiStatus.OnHold;
	// case WonNotApproved:
	// return CsUiStatus.Won;
	// case WonApproved:
	// return CsUiStatus.Won;
	// case OpportunityDraft:
	// case ProposalSent:
	// case ProposalReceived:
	// case SalesOrderSent:
	// case SalesOrderReceived:
	// return CsUiStatus.Opportunity;
	// case OpportunityLost:
	// return CsUiStatus.OpportunityLost;
	// default:
	// return CsUiStatus.Unknown;
	// }
	// }
	//
	public static int getListBoxIndexByText(ListBox lb, String text) {
		int indexToFind = -1;
		for (int i = 0; i < lb.getItemCount(); i++) {
			if (lb.getItemText(i).equals(text)) {
				indexToFind = i;

				break;
			}
		}

		return indexToFind;
	}

	public static JsArrayInteger toJsArray(short[] array){
		JsArrayInteger result = createIntArray();
		for (int i = 0; i < array.length; i++) {
			result.push(array[i]);
		}
		return result;
	}
	
	public static JsArrayInteger toJsArray(int[] array) {
		JsArrayInteger result = createIntArray();
		for (int i = 0; i < array.length; i++) {
			result.push(array[i]);
		}
		return result;
	};

	public static JsArrayInteger toJsArrayInteger(List<Integer> array) {
		JsArrayInteger result = createIntArray();
		for (int i : array) {
			result.push(i);
		}
		return result;
	}
	


	public static JsArrayNumber toJsArrayNumber(List<Double> array) {
		JsArrayNumber result = createNumberArray();
		for (double i : array) {
			result.push(i);
		}
		return result;
	}


	public static JsArrayString toJsArrayString(List<String> array) {
		JsArrayString result = createStringArray();
		for (String i : array) {
			result.push(i);
		}
		return result;
	}

	public static JavaScriptObject toJsArray(double[] array) {
		JavaScriptObject result = createArray();
		for (int i = 0; i < array.length; i++) {
			pushArray(result, array[i]);
		}
		return result;
	};

	public static JsArrayString toJsArray(String[] array) {
		JsArrayString result = createStringArray();
		for (int i = 0; i < array.length; i++) {
			pushArray(result, array[i]);
		}
		return result;
	};


	public static <T extends JavaScriptObject> JsArray<T> toJsArray(T[] array) {
		return toJsArray(Arrays.asList(array));
	};
	

	public static <T extends JavaScriptObject> JsArray<T> toJsArray(Iterable<T> array) {
		JsArray<T> result = createArray();
		for (T item : array) {
			pushArray(result, item);
		}
		return result;
	};

	public native static <T extends JavaScriptObject> JsArray<T> createArray() /*-{
		return new Array();
	}-*/;

	public native static JsArrayInteger createIntArray() /*-{
		return new Array();
	}-*/;

	public native static JsArrayString createStringArray() /*-{
		return new Array();
	}-*/;

	public native static JsArrayNumber createNumberArray() /*-{
		return new Array();
	}-*/;

	private native static void pushArray(JavaScriptObject array, int i) /*-{
		array.push(i);
	}-*/;

	private native static void pushArray(JavaScriptObject array, double d) /*-{
		array.push(d);
	}-*/;

	private native static void pushArray(JavaScriptObject array, Object o) /*-{
		array.push(o);
	}-*/;

	public static String stringToNull(String s) {
		if (s == null) {
			return null;
		}
		if ("".equals(s.trim())) {
			return null;
		}
		return s;
	}

	// Use Currency.formatWithSymbol instead
	// public static String formatMoney(double val, String currencyCode) {
	// //Only UK Market for csui for now
	// //CurrencyData cur = new DefaultCurrencyData("GBP", "£");
	// CurrencyData cur = CurrencyList.get().lookup(currencyCode);
	// String result = NumberFormat.getCurrencyFormat(cur).format(val);
	//
	//
	// return result;
	// }

	// Use Currency.formatWithSymbol instead
	// public static String formatMoney(NullableDouble val, String currencyCode)
	// {
	//
	// if (val.isNull()) {
	// return formatMoney(0.0, currencyCode);
	// } else {
	// return formatMoney(val.getDouble(), currencyCode);
	// }
	// }
	
	
	// Used by the DTO objects to parse them.  They can either be in the WebMethod format, /Date(2384723987)/,
	// or the WebApi format, 2014-09-23T15:01:06.6151619+01:00 
	public static NullableDate parseDtoDateTime(String val) {
		if (val == null || "".equals(val)) {
			return new NullableDate();
		}
		

		if (val.startsWith("/Date(")) {
			return deserializeUtc(val);
		} 
		if (!val.contains(" ") && val.contains("T") && val.contains(".")) {
			return new NullableDate(parseDateTime(val, mLosslessWebApiDateTimeFmt));
		}
		if(!val.contains(" ") && val.contains("T") && !val.contains(".")){
			return new NullableDate(parseDateTime(val, mWebApiDateTimeFmt));
		}
		

		Window.alert("invalid date: " + val);
		return new NullableDate();
	}


	public static NullableDate deserializeUtc(String dUtc) {
		// deserialize a Microsoft JSON date to a JavaScript date
		if (dUtc == null || "".equals(dUtc)) {
			return new NullableDate();
		}

		if (!dUtc.startsWith("/Date(")) {
			Window.alert("invalid date: " + dUtc);
			return new NullableDate();
		}

		int pos = dUtc.indexOf(")/");
		if (pos == -1) {
			Window.alert("invalid date: " + dUtc);
			return new NullableDate();
		}

		String num = dUtc.substring(6, pos);

		Date d = new Date(Long.valueOf(num));

		return new NullableDate(d);

	}

	public static String formatLosslessDateTime(NullableDate d) {
		if (d.isNull()) {
			return null;
		}
		return formatLosslessDateTime(d.getDate());
	}
	public static String formatLosslessDateTime(Date d) {
		return mLosslessDateTimeFmt.format(d);
	}
	
	public static NullableDate parseLosslessDateTime(String val) {
		if (val == null || "".equals(val.trim())) {
			return new NullableDate();
		}
		
		return new NullableDate(mLosslessDateTimeFmt.parse(val));
	}

	public static String serializeUtc(NullableDate val) {
		if (val.isNull()) {
			return null;
		}

		
		return "2014-02-03 12:12:12.234 -05:00";
		//return serializeDate(JsDate.create(val.getDate().getTime()));
	}
	
	private final static native String serializeDate(JsDate d) /*-{
		return "\\\/Date(" + d.getTime() + ")\\\/";
	}-*/;

	public static String formatPercent(NullableDouble probability) {
		if (probability.isNull()) {
			return "";
		}
		int p = (int) (probability.getDouble() * 100.0);
		return String.valueOf(p);
	}
	
	public static String formatPercent2Int(Double perc) {

		int p = (int) (perc * 100.0);
		return String.valueOf(p) + "%";
	}

	public static String formatPercent2Decimals(double d) {
		return mPercentFmt2.format(d);
	}

	public static boolean nullOrEmpty(String s) {
		if (s == null) {
			return true;
		}
		return s.length() == 0;
	}

	public static boolean isInteger(String str) {
	    try {
	        Integer.parseInt(str);
	        return true;
	    } catch (NumberFormatException nfe) {}
	    return false;
	}
	
	public static boolean nullOrWhitespace(String s) {
		if (s == null) {
			return true;
		}
		return s.trim().length() == 0;
	}

	public final static Date getDate(String keyString) {

		String year = keyString.substring(0, 4);
		String month = keyString.substring(4, 6);
		String day = keyString.substring(6, 8);

		// TODO: Make this format the date for the current locale
		DateTimeFormat format = DateTimeFormat.getFormat("dd/MM/yyyy");

		return format.parse(day + "/" + month + "/" + year);
	}

	public final static NullableDouble divide(int top, int bottom) {
		if (bottom == 0) {
			return NullableDouble.getNull();
		}

		return new NullableDouble(((double) top) / ((double) bottom));
	}

	public static NullableDouble divide(double top, int bottom) {
		if (bottom == 0) {
			return NullableDouble.getNull();
		}
		return new NullableDouble(top / ((double) bottom));
	}


	public static String getInitials(String name){
		String initials = "";	
		
		String[] splitName;
		
		if(name.contains(".")){
			splitName = name.split("\\.");
		}else{
			splitName = name.split(" ");
		}
		
		for(int i = 0; i <= splitName.length - 1; i++){
			initials += splitName[i].toUpperCase().substring(0, 1);
		}
		
		return initials;
	}	
	
	public static String getAvatarInitials(String name) {	
		String initials = "";					
		String[] nameParts = name.split("\\s+|\\.");
		if (nameParts.length > 0) {
			initials = String.valueOf(nameParts[0].charAt(0));
			
			if (nameParts.length > 1) {
				initials += String.valueOf(nameParts[nameParts.length - 1].charAt(0));
			}
		}
		
		return initials.toUpperCase();
	}
	
//
//	public static CsUiStatus getCsUiStatus(ContractStatuses whiteLabelStatus)
//	{
//		switch(whiteLabelStatus)
//		{
//			case Setup:
//				return CsUiStatus.InProgress;
//			case Live:
//				return CsUiStatus.Active;
//			case LivePaymentFailed:
//			case LivePausedAndPaymentFailed:
//				return CsUiStatus.PaymentFailed;
//			case LivePaused:
//				return CsUiStatus.Paused;
//			case EndedDeclined:
//				return CsUiStatus.PaymentFailedCancelled;
//			case EndedBlocked:
//				return CsUiStatus.Disapproved;
//			case Ended:
//				return CsUiStatus.Ended;
//			case SetupOnHold:
//				return CsUiStatus.OnHold;
//			default:
//				return CsUiStatus.InProgress;
//		}
//	}


	public static String getHostname(String url) {
		if (nullOrWhitespace(url)) {
			return "";
		}
		
		AnchorElement a = Document.get().createAnchorElement();
		a.setHref(url);
		String host = a.getPropertyString("host");

		a.removeFromParent();
		return host;
	}

	public static String nullToEmptyString(String nullStr)
	{
		if(nullStr == null)
			nullStr = "";
		
		return nullStr;
	}


	
	

//	public static boolean Contains(int value, JsArrayInteger options) {
//
//		for(int test : new JsArrayIntegerIterable(options)) {
//			if (test == value) {
//				return true;
//			}
//		}
//		return false;
//	}
	

//	public static <T extends JavaScriptObject, U> boolean Contains(U value,
//			JsArray<T> options, Func<T, U> selector) {
//
//		for(T test : new JsIterable<T>(options)) {
//			if (selector.call(test).equals(value)) {
//				return true;
//			}
//		}
//		return false;
//		
//	}
	

	

//	public static <T extends JavaScriptObject> List<T> toList(JsArray<T> ary) {
//		ArrayList<T> result = new ArrayList<T>();
//		for(T i : new JsIterable<T>(ary)) {
//			result.add(i);
//		}
//		return result;
//	}
	
//	public static <T> Collection<T> distinct(Iterable<T> src) {
//		Set<T> result = new TreeSet<T>();
//		for(T i : src) {
//			result.add(i);
//		}
//		return result;
//	}
	
	public static String getMonthAbbrevFromIndex(int monthIndex)
	{
		switch(monthIndex)
		{
			case 0:
				return "Jan";
			case 1:
				return "Feb";
			case 2:
				return "Mar";
			case 3:
				return "Apr";
			case 4:
				return "May";
			case 5:
				return "Jun";
			case 6:
				return "Jul";
			case 7:
				return "Aug";
			case 8:
				return "Sep";
			case 9:
				return "Oct";
			case 10:
				return "Nov";
			case 11:
				return "Dec";
			default:
				return "";
		}
	}
//	public static <T, U> Iterable<U> distinct(Iterable<T> src, Func<T, U> selector) {
//		Set<U> result = new TreeSet<U>();
//		for(T i : src) {
//			result.add(selector.call(i));
//		}
//		return result;
//	}
	

//	public static <T> List<T> toList(Iterable<T> src) {
//		return copy(src);
//	}
	
//	private static <T> List<T> copy(Iterable<T> src) {
//		List<T> result = new ArrayList<T>();
//		for(T item : src) {
//			result.add(item);
//		}
//		return result;
//	}
	

//	private static <T, S> List<T> copy(Iterable<S> src, final Func<S, T> projection) {
//		List<T> result = new ArrayList<T>();
//		for(S item : src) {
//			result.add(projection.call(item));
//		}
//		return result;
//	}
	
	
	

	
	
	public static String getMD5Hex(final String inputString) throws NoSuchAlgorithmException {

		MessageDigest md = MessageDigest.getInstance("MD5");
		md.update(inputString.getBytes());

		byte[] digest = md.digest();

		return convertByteToHex(digest);
	}

	private static String convertByteToHex(byte[] byteData) {

		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < byteData.length; i++) {
			sb.append(Integer.toString((byteData[i] & 0xff) + 0x100, 16).substring(1));
		}

		return sb.toString();
	}

	public static void errorAlert(String msg) {
		Window.alert(msg);
	}
}
