package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JsArrayString;

public class JsArrayStringWrapper implements IJsArrayString {

	private final JsArrayString _array;
	public JsArrayStringWrapper(JsArrayString array) {
		_array = array;
	}
	
	@Override
	public Iterator<String> iterator() {
		return  new JsArrayStringIterable(_array).iterator();
	}
	
	

	@Override
	public String get(int index) {
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
	public void push(String value) {
		_array.push(value);
	}

	@Override
	public void set(int index, String value) {
		_array.set(index, value);
	}

	@Override
	public void setLength(int newLength) {
		_array.setLength(newLength);
	}

	@Override
	public String shift() {
		return _array.shift();
	}

	@Override
	public void unshift(String value) {
		_array.unshift(value);
	}

	public JsArrayString unwrap() {
		return _array;
	}
	


	public static IJsArrayString empty() {
		return new JsArrayStringWrapper(Utils.createStringArray());
	}

	
	public static JsArrayString unwrap(IJsArrayString src) {
		JsArrayStringWrapper realObj = (JsArrayStringWrapper)src;
		return realObj.unwrap();
	}
	

	public static void copyTo(JsArrayString src, IJsArrayString dest) {
		for(String t : new JsArrayStringIterable(src)) {
			dest.push(t);
		}
	}
	

	public static JsArrayString from(Iterable<String> src) {
		JsArrayString result = Utils.createStringArray();
		for(String t : src) {
			result.push(t);
		}
		return result;
	}
	
	
}
