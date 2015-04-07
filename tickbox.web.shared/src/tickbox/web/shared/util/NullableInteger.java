package tickbox.web.shared.util;

public class NullableInteger {

	private final Integer mInt;
	private final boolean mIsNull;

	private NullableInteger() {
		mInt = 0;
		mIsNull = true;
	}
	
	public static NullableInteger getNull() {
		return new NullableInteger();
	}
	
	public NullableInteger(Integer i) {
		mInt = i;
		mIsNull = false;
	}
	
	public boolean isNull() {
		return mIsNull;
	}
	public Integer getInt() {
		return mInt;
	}
	
	public String tokenize() {
		if (isNull()) {
			return "n";
		} else {
			return String.valueOf(getInt());
		}		
	}
	
	public static NullableInteger fromToken(String token) {
		if ("n".equalsIgnoreCase(token) || "".equalsIgnoreCase(token)) {
			return new NullableInteger();
		}
		return new NullableInteger(Integer.parseInt(token));
	}
	

	@Override
	public boolean equals(Object obj) {
		if (obj == null) {
			return false;
		}
		
		if (!(obj instanceof NullableInteger)) {
			return false;
		}
		
		NullableInteger typedObj = (NullableInteger)obj;
		return mIsNull == typedObj.mIsNull && mInt == typedObj.mInt;
	}
	
	@Override
	public int hashCode() {
		return mIsNull ? 0 : mInt.hashCode();
	}
	
	@Override
	public String toString() {
		return isNull() ? "" : String.valueOf(getInt());
	}
	

	public Integer getValueOrDefault(Integer def) {
		if (isNull()) {
			return def;
		}
		return getInt();
	}
}
