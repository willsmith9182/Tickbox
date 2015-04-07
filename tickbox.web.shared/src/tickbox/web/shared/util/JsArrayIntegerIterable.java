package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JsArrayInteger;
import com.google.gwt.user.client.Window;


public class JsArrayIntegerIterable implements Iterable<Integer> {
	private final JsArrayInteger mAry;

	public JsArrayIntegerIterable(JsArrayInteger ary) {
		if (ary == null) {
			mAry = Utils.createIntArray();
		} else {
			mAry = ary;
		}
	}

	@Override
	public Iterator<Integer> iterator() {
		return new MyIterator(mAry);
	}
	
	public int length() {
		return mAry.length();
	}

	private static class MyIterator implements
			Iterator<Integer> {
		private final JsArrayInteger mAry;
		private final int mLength;
		private int pos = 0;

		public MyIterator(JsArrayInteger ary) {
			mAry = ary;
			mLength = mAry.length();
		}

		@Override
		public boolean hasNext() {			
			return mLength > pos;
		}

		@Override
		public Integer next() {
			Integer e = mAry.get(pos);
			pos++;
			return e;
		}

		@Override
		public void remove() {
			Window.alert("removing not supported");
		}

	}
	
//	public static String join(String separator, Iterable<String> it) {
//		
//		StringBuilder sb = new StringBuilder();
//		
//		boolean isFirst = true;
//		for(String s : it) {
//			if (isFirst) {
//				isFirst = false;
//			} else {
//				sb.append(separator);
//			}
//			sb.append(s);
//		}
//		
//		return sb.toString();
//		
//	}
}