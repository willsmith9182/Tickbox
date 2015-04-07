/**
 * These utils are java ONLY. They MUST not include JavaScriptObjects or refrences to gwt objects 
 * so that they can be used in non gwt unit testing
 */
package tickbox.web.shared.util;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

public class JavaOnlyUtils {

	/**
	 * @param src
	 * @param numToSkip
	 * @return
	 */
	public static <T> Iterable<T> skip(Iterable<T> src, int numToSkip) {
		List<T> result = new ArrayList<T>();
		int i = 0;
		for(T item : src) {
			if (i >= numToSkip) {
				result.add(item);
			}
			i++;
		}
		return result;
	}
	
	
	public static <T> Iterable<T> distinct(Iterable<T> src) {
		Set<T> result = new TreeSet<T>();
		for(T i : src) {
			result.add(i);
		}
		return result;
	}
	
	public static <T, U> Iterable<U> distinct(Iterable<T> src, Func<T, U> selector) {
		Set<U> result = new TreeSet<U>();
		for(T i : src) {
			result.add(selector.call(i));
		}
		return result;
	}
	
	public static <T> List<T> toList(Iterable<T> src) {
		List<T> result = new ArrayList<T>();
		for(T item : src) {
			result.add(item);
		}
		return result;
	}
	

	public static <T, S> Iterable<T> select(Iterable<S> src, final Func<S, T> projection) {
		List<T> result = new ArrayList<T>();
		for(S item : src) {
			result.add(projection.call(item));
		}
		return result;
	}
	
	
	public static <T> Iterable<T> where(Iterable<T> src, final Func<T, Boolean> select) {
		List<T> result = new ArrayList<T>();
		for(T item : src) {
			if (select.call(item)) {
				result.add(item);
			}
		}
		return result;
	}

	public static String Join(Iterable<String> selectedAbbrevs, String separator) {
		String result = "";
		for(String item : selectedAbbrevs) {
			if (result.length() != 0) {
				result += separator;
			}
			result += item;
		}
		return result;
	}

	public static <T, U> T Find(U value,
			Iterable<T> options, Func<T, U> selector) {
	
		for(T test : options) {
			if (selector.call(test).equals(value)) {
				return test;
			}
		}
		return null;
		
	}

	public static <T, S extends Comparable<? super S>> List<T> orderBy(Iterable<T> src, final Func<T, S> select) {
		List<T> result = toList(src);
		
		Collections.sort(result, new Comparator<T>() {
	
			@Override
			public int compare(T arg0, T arg1) {
				return select.call(arg0).compareTo(select.call(arg1));
			}
			
		});
		return result;
	}
	

	public static <T, S extends Comparable<? super S>> List<T> orderByDescending(Iterable<T> src, final Func<T, S> select) {
		List<T> result = toList(src);
		Collections.sort(result, Collections.reverseOrder(new Comparator<T>() {

			@Override
			public int compare(T arg0, T arg1) {
				return select.call(arg0).compareTo(select.call(arg1));
			}
			
		}));
		return result;
	}
	

	public static <T> Iterable<T> skip(List<T> src, int numToSkip) {
		List<T> result = new ArrayList<T>();
		int i = 0;
		for(T item : src) {
			if (i >= numToSkip) {
				result.add(item);
			}
			i++;
		}
		return result;
	}
	
	public static <T> int sum(Iterable<T> src, final Func<T, Integer> select) {
		int result = 0;
		for(T item : src) {
			result += select.call(item);
		}
		return result;
	}
	


	public static int max(List<Integer> ary) {
		int result = 0;
		boolean found = false;
		
		for(int i = 0; i < ary.size(); i++) {
			if (!found || result < ary.get(i)) {
				result = ary.get(i);
				found = true;
			}
		}
		return result;
	}

	public static <T> boolean Contains(T value, T[] options) {
	
		for(T test : options) {
			if (test.equals(value)) {
				return true;
			}
		}
		return false;
		
	}
	

	public static <T> boolean Contains(T value,
			List<T> options) {

		for(T test : options) {
			if (test.equals(value)) {
				return true;
			}
		}
		return false;
		
	}

	public static List<String> CastToStrings(IJsArrayInteger vals) {
		List<String> result = new ArrayList<String>(vals.length());
		for(Integer i : vals) {
			result.add(String.valueOf(i));
		}
		return result;
	}

	public static List<Integer> CastToInts(List<String> vals) {
		List<Integer> result = new ArrayList<Integer>(vals.size());
		for(String s : vals) {
			result.add(Integer.parseInt(s));
		}
		return result;
	}

	public static int[] toIntArray(List<Integer> integerList) {
		int[] intArray = new int[integerList.size()];
		for (int i = 0; i < integerList.size(); i++) {
			intArray[i] = integerList.get(i);
		}
		return intArray;
	}

	public static String[] toStringArray(List<String> items) {
		String[] arr = new String[items.size()];
		for (int i = 0; i < items.size(); i++) {
			arr[i] = items.get(i);
		}
		return arr;
	}

}
