package tickbox.web.shared.util;

import java.util.Date;

import com.google.gwt.user.datepicker.client.CalendarUtil;

public class NullableDate {

	private final Date mDate;
	private final boolean mIsNull;
	
	public NullableDate() {
		mIsNull = true;
		mDate = new Date(0);
	}

	public static NullableDate getNull() {
		return new NullableDate();
	}
	
	public NullableDate(Date d) {
		mDate = CalendarUtil.copyDate(d);
		mIsNull = false;
	}
	
	public boolean isNull() {
		return mIsNull;
	}
	public Date getDate() {
		return mDate;
	}
	

	@Override
	public boolean equals(Object obj) {
		if (obj == null) {
			return false;
		}
		
		if (!(obj instanceof NullableDate)) {
			return false;
		}
		
		NullableDate typedObj = (NullableDate)obj;
		return mIsNull == typedObj.mIsNull && mDate.equals(typedObj.mDate);
	}
	
	@Override
	public int hashCode() {
		return mIsNull ? 0 : mDate.hashCode();
	}
	
	@Override
	public String toString() {
		return isNull() ? "" : Utils.formatDate(getDate());
	}

	public Date getDateOrDefault(Date date) {
		if (isNull()) {
			return date;
		}
		return getDate();
	}
}