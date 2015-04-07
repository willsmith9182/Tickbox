package tickbox.web.shared.util;

public class NullableEnum<T extends Enum<T>> {

	private final T mVal;
	private final boolean mIsNull;
	

	public NullableEnum(T val) {
		mVal = val;		
		mIsNull = val == null;
	}
	public NullableEnum() {
		mVal = null;		
		mIsNull = true;
	}


	public static <T extends Enum<T>> NullableEnum<T> getNull() {
		return new NullableEnum<T>();
	}

	public T getValue() {
		return mVal;
	}
	public T getValueOrDefault(T def) {
		if (isNull()) {
			return def;
		}
		return mVal;
	}
	
	public boolean isNull() {
		return mIsNull;
	}
	
	
	@Override
	public boolean equals(Object obj) {
		if (obj instanceof NullableEnum<?>) {
			NullableEnum<?> objT = (NullableEnum<?>)obj;
			if (objT.isNull() && this.isNull()) {
				return true;
			}
			if (objT.isNull() || this.isNull()) {
				return false;
			}
			
			return objT.getValue().equals(this.getValue());			
		}

		if (isNull()) {
			return false;
		}
		
		return getValue().equals(obj);
	}
	
	@Override
	public int hashCode() {
		if (isNull()) {
			return 0;
		}
		return getValue().hashCode();
	}
	
	@Override
	public String toString() {
		return name();
	}
	public String name() {
		return isNull() ? "" : getValue().name();
	}
}
