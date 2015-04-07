package tickbox.web.shared.util;

import java.util.Date;




import com.google.gwt.user.datepicker.client.CalendarUtil;

import tickbox.web.shared.util.DateTime.MonthNames;


/**
 * Emulates .Net's DateTime struct -- excluding time and timezone
 * This isn't comprehensive -- it's a start with just what I need.
 * Please add methods, but make it work exactly like .Net's DateTime.
 *
 * There is one difference: this is an object (not a struct), so it can be null
 */
public class DateOnly {

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
	
	public static DateOnly today() {
		return new DateOnly(new Date());
	}

	@SuppressWarnings("deprecation")
	public DateOnly(Date d) {
		mDate = new Date(d.getYear(), d.getMonth(), d.getDate());
	}
	
//	public DateOnly(Date d) {
//		mDate = CalendarUtil.copyDate(d);
//	}
	@SuppressWarnings("deprecation")
	public DateOnly(int year, int month, int day) {
		mDate = new Date(year - 1900, month -1, day);
	}
	public static DateOnly parse(String s) {
		if (s == null) {
			return null;
		}
		return new DateOnly(Utils.parseDate(s));
	}
	
//	public static DateOnly parse(String s, DateTimeFormat format)
//	{
//		if (s == null) {
//			return null;
//		}
//		return new DateOnly(Utils.parseDateTime(s, format));
//	}

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
//	public DateTime addHours(int hours) {
//		
//		final long SECONDS = 1000;
//		final long MINUTES = 60*SECONDS;
//		final long HOURS = 60*MINUTES;
//		
//		Date d = CalendarUtil.copyDate(mDate);
//		d.setTime(d.getTime() + hours*HOURS);
//		
//		return new DateTime(d);	
//	}
//	public DateTime addSeconds(double seconds) {
//		Date d = new Date(mDate.getTime() + (long)seconds * 1000);
//		return new DateTime(d);	
//	}
//	public Date toDate() {
//		Date d = CalendarUtil.copyDate(mDate);
//		return d;
//	}
	
	// non-.Net helper methods:	
	public static Date toDate(DateOnly t) {
		if (t == null) {
			return null;
		}
		return CalendarUtil.copyDate(t.mDate);
	}
	
	public static DateOnly fromDateKey(int val) {
		return new DateOnly(Utils.fromDateKey(val));
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
	
//
//	private static enum MonthNames {
//		January(1),
//		February(2),
//		March(3),
//		April(4),
//		May(5),
//		June(6),
//		July(7),
//		August(8),
//		September(9),
//		October(10),
//		November(11),
//		December(12);
//		
//		private final int _month;
//		private MonthNames(int month) {
//			_month = month;
//		}
//		
//		public static MonthNames find(int month) {
//			for(MonthNames m : MonthNames.values()) {
//				if (m._month == month) {
//					return m;
//				}
//			}
//			
//			Window.alert("Month not found: " + String.valueOf(month));
//			return null;
//		}	
//				
//	}
	
	public static String MonthName(DateTime t) {
		return MonthNames.find(t.getMonth()).name();
	}


//	public static long getMilliseconds(DateTime t) {
//		return t.mDate.getTime();
//	}

	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean after(DateOnly d) {
		return this.mDate.after(d.mDate);
	}
	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean before(DateOnly d) {
		return this.mDate.before(d.mDate);
	}

	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean afterOrEqual(DateOnly d) {
		return after(d) || this.mDate.equals(d.mDate);
	}
	// this isn't in DateTime (.Net), but we can't use < or >
	public boolean beforeOrEqual(DateOnly d) {
		return before(d) || this.mDate.equals(d.mDate);
	}

}
