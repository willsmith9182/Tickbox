package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JsArrayString;
import com.google.gwt.user.client.Window;


public class JsArrayStringIterable implements Iterable<String> {
	private final JsArrayString mAry;

	public JsArrayStringIterable(JsArrayString ary) {
		if (ary == null) {
			mAry = Utils.createStringArray();
		} else {
			mAry = ary;
		}
	}

	@Override
	public Iterator<String> iterator() {
		return new MyIterator(mAry);
	}
	
	public int length() {
		return mAry.length();
	}

	private static class MyIterator implements
			Iterator<String> {
		private final JsArrayString mAry;
		private final int mLength;
		private int pos = 0;

		public MyIterator(JsArrayString ary) {
			mAry = ary;
			mLength = mAry.length();
		}

		@Override
		public boolean hasNext() {			
			return mLength > pos;
		}

		@Override
		public String next() {
			String e = mAry.get(pos);
			pos++;
			return e;
		}

		@Override
		public void remove() {
			Window.alert("removing not supported");
		}

	}
	
	public static String join(String separator, Iterable<String> it) {
		
		StringBuilder sb = new StringBuilder();
		
		boolean isFirst = true;
		for(String s : it) {
			if (isFirst) {
				isFirst = false;
			} else {
				sb.append(separator);
			}
			sb.append(s);
		}
		
		return sb.toString();
		
	}
}