package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JsArrayInteger;

public class JsArrayIntegerWrapper implements IJsArrayInteger {

	private final JsArrayInteger _array;
	public JsArrayIntegerWrapper(JsArrayInteger array) {
		_array = array;
	}
	
	@Override
	public Iterator<Integer> iterator() {
		return  new JsArrayIntegerIterable(_array).iterator();
	}
	
	

	@Override
	public int get(int index) {
		return _array.get(index);
	}

	@Override
	public String join() {
		return _array.join();
	}

	@Override
	public String join(String separator) {
		return _array.join(separator);
	}

	@Override
	public int length() {
		return _array.length();
	}

	@Override
	public void push(int value) {
		_array.push(value);
	}

	@Override
	public void set(int index, int value) {
		_array.set(index, value);
	}

	@Override
	public void setLength(int newLength) {
		_array.setLength(newLength);
	}

	@Override
	public int shift() {
		return _array.shift();
	}

	@Override
	public void unshift(int value) {
		_array.unshift(value);
	}

	public JsArrayInteger unwrap() {
		return _array;
	}
	

	public static IJsArrayInteger empty() {
		return new JsArrayIntegerWrapper(Utils.createIntArray());
	}


	public static JsArrayInteger unwrap(IJsArrayInteger src) {
		JsArrayIntegerWrapper realObj = (JsArrayIntegerWrapper)src;
		return realObj.unwrap();
	}
	


	public static void copyTo(JsArrayInteger src, IJsArrayInteger dest) {
		for(int t : new JsArrayIntegerIterable(src)) {
			dest.push(t);
		}
	}
	


	public static JsArrayInteger from(Iterable<Integer> src) {
		JsArrayInteger result = Utils.createIntArray();
		for(int t : src) {
			result.push(t);
		}
		return result;
	}
	
}
