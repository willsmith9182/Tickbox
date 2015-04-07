package tickbox.web.shared.util;

public interface IJsArray<T> extends Iterable<T> {

	  /**
	   * Gets the object at a given index.
	   * 
	   * @param index the index to be retrieved
	   * @return the object at the given index, or <code>null</code> if none exists
	   */
	  T get(int index);

	  /**
	   * Convert each element of the array to a String and join them with a comma
	   * separator. The value returned from this method may vary between browsers
	   * based on how JavaScript values are converted into strings.
	   */
	  String join();

	  /**
	   * Convert each element of the array to a String and join them with a comma
	   * separator. The value returned from this method may vary between browsers
	   * based on how JavaScript values are converted into strings.
	   */
	  String join(String separator);

	  /**
	   * Gets the length of the array.
	   * 
	   * @return the array length
	   */
	  int length();

	  /**
	   * Pushes the given value onto the end of the array.
	   */
	  void push(T value);

	  /**
	   * Sets the object value at a given index.
	   * 
	   * If the index is out of bounds, the value will still be set. The array's
	   * length will be updated to encompass the bounds implied by the added object.
	   * 
	   * @param index the index to be set
	   * @param value the object to be stored
	   */
	  void set(int index, T value);

	  /**
	   * Reset the length of the array.
	   * 
	   * @param newLength the new length of the array
	   */
	  void setLength(int newLength);

	  /**
	   * Shifts the first value off the array.
	   * 
	   * @return the shifted value
	   */
	  T shift();

	  /**
	   * Shifts a value onto the beginning of the array.
	   * 
	   * @param value the value to the stored
	   */
	  void unshift(T value);
}
