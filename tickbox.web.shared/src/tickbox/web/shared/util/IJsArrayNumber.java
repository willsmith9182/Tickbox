package tickbox.web.shared.util;

public interface IJsArrayNumber extends Iterable<Double> {


	  /**
	   * Gets the value at a given index.
	   * 
	   * If an undefined or non-numeric value exists at the given index, a
	   * type-conversion error will occur in Development Mode and unpredictable
	   * behavior may occur in Production Mode.
	   *
	   * @param index the index to be retrieved
	   * @return the value at the given index
	   */
	  double get(int index);

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
	   * Pushes the given number onto the end of the array.
	   */
	  void push(double value);

	  /**
	   * Sets the value value at a given index.
	   * 
	   * If the index is out of bounds, the value will still be set. The array's
	   * length will be updated to encompass the bounds implied by the added value.
	   * 
	   * @param index the index to be set
	   * @param value the value to be stored
	   */
	  void set(int index, double value);

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
	  double shift();

	  /**
	   * Shifts a value onto the beginning of the array.
	   * 
	   * @param value the value to the stored
	   */
	  void unshift(double value);
}
