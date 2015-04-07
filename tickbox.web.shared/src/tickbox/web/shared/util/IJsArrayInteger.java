package tickbox.web.shared.util;

public interface IJsArrayInteger extends Iterable<Integer> {

	  /**
	   * Gets the value at a given index.
	   * 
	   * If no value exists at the given index, a type-conversion error will occur
	   * in Development Mode and unpredictable behavior may occur in Production
	   * Mode. If the numeric value returned is non-integral, it will cause a
	   * warning in Development Mode, and may affect the results of mathematical
	   * expressions.
	   *
	   * @param index the index to be retrieved
	   * @return the value at the given index
	   */
	  int get(int index);

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
	   * Pushes the given integer onto the end of the array.
	   */
	  void push(int value);

	  /**
	   * Sets the value value at a given index.
	   * 
	   * If the index is out of bounds, the value will still be set. The array's
	   * length will be updated to encompass the bounds implied by the added value.
	   * 
	   * @param index the index to be set
	   * @param value the value to be stored
	   */
	  void set(int index, int value);

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
	  int shift();

	  /**
	   * Shifts a value onto the beginning of the array.
	   * 
	   * @param value the value to the stored
	   */
	  void unshift(int value);
}
