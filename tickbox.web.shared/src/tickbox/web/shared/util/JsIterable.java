package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;
import com.google.gwt.user.client.Window;



public class JsIterable<E extends JavaScriptObject> implements Iterable<E> {
	private final JsArray<E> mAry;

	public JsIterable(JsArray<E> ary) {
		if (ary == null) {
			mAry = Utils.createArray();
		} else {
			mAry = ary;
		}
	}

	@Override
	public Iterator<E> iterator() {
		return new MyIterator<E>(mAry);
	}
	
	public int length() {
		return mAry.length();
	}
	

	public E first() {
		if (mAry.length() > 0) {
			return mAry.get(0);
		}
		
		return null;
	}
	
	private static class MyIterator<E extends JavaScriptObject> implements
			Iterator<E> {
		private final JsArray<E> mAry;
		private final int mLength;
		private int pos = 0;

		public MyIterator(JsArray<E> ary) {
			mAry = ary;
			mLength = mAry.length();
		}

		@Override
		public boolean hasNext() {			
			return mLength > pos;
		}

		@Override
		public E next() {
			E e = mAry.get(pos);
			pos++;
			return e;
		}

		@Override
		public void remove() {
			Window.alert("removing not supported");
		}

	}
}
