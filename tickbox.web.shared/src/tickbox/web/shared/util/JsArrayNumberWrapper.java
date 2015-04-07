package tickbox.web.shared.util;

import java.util.Iterator;

import com.google.gwt.core.client.JsArrayInteger;
import com.google.gwt.core.client.JsArrayNumber;

@SuppressWarnings("unused")
public class JsArrayNumberWrapper implements IJsArrayNumber {

	private final JsArrayNumber _array;
	public JsArrayNumberWrapper(JsArrayNumber array) {
		_array = array;
	}
	
	@Override
	public Iterator<Double> iterator() {
		return  new JsArrayNumberIterable(_array).iterator();
	}
	
	

	@Override
	public double get(int index) {
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
	public void push(double value) {
		_array.push(value);
	}

	@Override
	public void set(int index, double value) {
		_array.set(index, value);
	}

	@Override
	public void setLength(int newLength) {
		_array.setLength(newLength);
	}

	@Override
	public double shift() {
		return _array.shift();
	}

	@Override
	public void unshift(double value) {
		_array.unshift(value);
	}

	public JsArrayNumber unwrap() {
		return _array;
	}
	


	public static IJsArrayNumber empty() {
		return new JsArrayNumberWrapper(Utils.createNumberArray());
	}


	public static JsArrayNumber unwrap(IJsArrayNumber src) {
		JsArrayNumberWrapper realObj = (JsArrayNumberWrapper)src;
		return realObj.unwrap();
	}
	
	


	public static void copyTo(JsArrayNumber src, IJsArrayNumber dest) {
		for(double t : new JsArrayNumberIterable(src)) {
			dest.push(t);
		}
	}
	


	public static JsArrayNumber from(Iterable<Double> src) {
		JsArrayNumber result = Utils.createNumberArray();
		for(double t : src) {
			result.push(t);
		}
		return result;
	}
	
	
}
