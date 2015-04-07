package tickbox.web.shared.util;

import java.util.Date;

import com.google.gwt.i18n.client.DateTimeFormat;
import com.google.gwt.user.datepicker.client.CalendarUtil;

/**
 * Emulates .Net's DateTime struct
 * This isn't comprehensive -- it's a start with just what I need.
 * Please add methods, but make it work exactly like .Net's DateTime.
 *
 * There is one difference: this is an object (not a struct), so it can be null
 */
public class DateTime {
	
	/**
	 * java Date's are mutable, so don't expose it (or at least make a copy of it)
	 */	
	private final Date mDate;

	/**
	 * Initialise To NOW
	 */
//	public DateTime(){
//		this(new Date());
//	}
	
	public static DateTime now() {
		return new DateTime(new Date());
	}
	
	public DateTime(Date d) {
		mDate = CalendarUtil.copyDate(d);
	}
	@SuppressWarnings("deprecation")
	public DateTime(int year, int month, int day) {
		mDate = new Date(year - 1900, month -1, day);
	}
	public static DateTime parse(String s) {
		if (s == null) {
			return null;
		}
		return new DateTime(Utils.parseDate(s));
	}
	
	public static DateTime parse(String s, DateTimeFormat format)
	{
		if (s == null) {
			return null;
		}
		return new DateTime(Utils.parseDateTime(s, format));
	}

	public DateTime addDays(int days) {
		Date d = CalendarUtil.copyDate(mDate);
		CalendarUtil.addDaysToDate(d, days);
		return new DateTime(d);
	}
	public DateTime addMonths(int months) {
		Date d = CalendarUtil.copyDate(mDate);
		CalendarUtil.addMonthsToDate(d, months);
		return new DateTime(d);
	}
	public DateTime addHours(int hours) {
		
		final long SECONDS = 1000;
		final long MINUTES = 60*SECONDS;
		final long HOURS = 60*MINUTES;
		
		Date d = CalendarUtil.copyDate(mDate);
		d.setTime(d.getTime() + hours*HOURS);
		
		return new DateTime(d);	
	}
	public DateTime addSeconds(double seconds) {
		Date d = new Date(mDate.getTime() + (long)seconds * 1000);
		return new DateTime(d);	
	}
	public Date toDate() {
		Date d = CalendarUtil.copyDate(mDate);
		return d;
	}
	
	// non-.Net helper methods:	
	public static Date toDate(DateTime t) {
		if (t == null) {
			return null;
		}
		return CalendarUtil.copyDate(t.mDate);
	}
	
	public static DateTime fromDateKey(int val) {
		return new DateTime(Utils.fromDateKey(val));
	}
	
	public int toDateKey() {
		return Utils.toDateKey(mDate);
	}

	@SuppressWarnings("deprecation")
	public int getYear() {
		return mDate.getYear() + 1900;
	}
	@SuppressWarnings("deprecation")
	public int getMonth() {
		return mDate.getMonth() + 1;
	}
	@SuppressWarnings("deprecation")
	public int getDay() {
		return mDate.getDate();
	}
	
	
//	public DateTime getMonthEnd()
//	{
//		Date d = CalendarUtil.copyDate(mDate);
//
//		CalendarUtil.setToFirstDayOfMonth(d);		
//		CalendarUtil.addMonthsToDate(d, 1);
//		CalendarUtil.addDaysToDate(d, -1);
//		
//		
//		return new DateTime(d);
//	}
	

	static enum MonthNames {
		January(1),
		February(2),
		March(3),
		April(4),
		May(5),
		June(6),
		July(7),
		August(8),
		September(9),
		October(10),
		November(11),
		December(12);
		
		private final int _month;
		private MonthNames(int month) {
			_month = month;
		}
		
		public static MonthNames find(int month) {
			for(MonthNames m : MonthNames.values()) {
				if (m._month == month) {
					return m;
				}
			}			
			
			Utils.errorAlert("Month not found: " + String.valueOf(month));
			return null;
		}	
				
	}
	
	public static String MonthName(DateTime t) {
		return MonthNames.find(t.getMonth()).name();
	}


//	public static long getMilliseconds(DateTime t) {
//		return t.mDate.getTime();
//	}

	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean after(DateTime d) {
		return this.mDate.after(d.mDate);
	}
	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean before(DateTime d) {
		return this.mDate.before(d.mDate);
	}

	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean afterOrEqual(DateTime d) {
		return after(d) || this.mDate.equals(d.mDate);
	}
	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean beforeOrEqual(DateTime d) {
		return before(d) || this.mDate.equals(d.mDate);
	}

	/**
	 * truncates to just year/month/day
	 */	
	public DateTime getDate() {
		return new DateTime(getYear(), getMonth(), getDay());
	}

}
