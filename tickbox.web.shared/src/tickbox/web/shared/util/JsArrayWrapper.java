package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JavaScriptObject;
import com.google.gwt.core.client.JsArray;

public class JsArrayWrapper<AT extends JavaScriptObject, T> implements IJsArray<T> {

	private final JsArray<AT> _array;
	public JsArrayWrapper(JsArray<AT> array) {
		_array = array;
	}
	
	
	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public Iterator<T> iterator() {
		return (Iterator<T>) new JsIterable<AT>(_array).iterator();
	}
	
	

	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public T get(int index) {
		return (T) _array.get(index);
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

	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public void push(T value) {
		_array.push((AT)value);
	}

	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public void set(int index, T value) {
		_array.set(index, (AT)value);
	}

	@Override
	public void setLength(int newLength) {
		_array.setLength(newLength);
	}

	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public T shift() {
		return (T) _array.shift();
	}

	@SuppressWarnings("unchecked") // the case is compiled away with GWT
	@Override
	public void unshift(T value) {
		_array.unshift((AT)value);
	}

	public JsArray<AT> unwrap() {
		return _array;
	}
	

	@SuppressWarnings("unchecked")
	public static <AT extends JavaScriptObject, T> IJsArray<T> empty() {
		return new JsArrayWrapper<AT, T>((JsArray<AT>)Utils.createArray());
	}


	public static <AT extends JavaScriptObject, T> JsArray<AT> unwrap(IJsArray<T> src) {
		@SuppressWarnings("unchecked")
		JsArrayWrapper<AT, T> realObj = (JsArrayWrapper<AT, T>)src;
		return realObj.unwrap();
	}
	

	@SuppressWarnings("unchecked")
	public static <AT extends JavaScriptObject, T> void copyTo(JsArray<AT> src, IJsArray<T> dest) {
		for(AT t : new JsIterable<AT>(src)) {
			dest.push((T)t);
		}
	}


	@SuppressWarnings("unchecked")
	public static <AT extends JavaScriptObject, T> JsArray<AT> from(Iterable<T> src) {
		JsArray<AT> result = (JsArray<AT>) JsArray.createArray();
		for(T t : src) {
			result.push((AT)t);
		}
		return result;
	}

}
