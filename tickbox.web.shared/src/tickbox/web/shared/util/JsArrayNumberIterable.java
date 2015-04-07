package tickbox.web.shared.util;

import java.util.Iterator;



import com.google.gwt.core.client.JsArrayNumber;
import com.google.gwt.user.client.Window;

public class JsArrayNumberIterable implements Iterable<Double> {
	private final JsArrayNumber mAry;

	public JsArrayNumberIterable(JsArrayNumber ary) {
		if (ary == null) {
			mAry = Utils.createNumberArray();
		} else {
			mAry = ary;
		}
	}

	@Override
	public Iterator<Double> iterator() {
		return new MyIterator(mAry);
	}
	
	public int length() {
		return mAry.length();
	}

	private static class MyIterator implements Iterator<Double> {
		private final JsArrayNumber mAry;
		private final int mLength;
		private int pos = 0;

		public MyIterator(JsArrayNumber ary) {
			mAry = ary;
			mLength = mAry.length();
		}

		@Override
		public boolean hasNext() {			
			return mLength > pos;
		}

		@Override
		public Double next() {
			Double e = mAry.get(pos);
			pos++;
			return e;
		}

		@Override
		public void remove() {
			Window.alert("removing not supported");
		}

	}

}
