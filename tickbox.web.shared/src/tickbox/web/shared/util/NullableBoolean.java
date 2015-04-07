package tickbox.web.shared.util;

public class NullableBoolean {

	private final boolean mVal;
	private final boolean mIsNull;

	private NullableBoolean() {
		mVal = false;
		mIsNull = true;
	}
	
	public static NullableBoolean getNull() {
		return new NullableBoolean();
	}
	
	public NullableBoolean(boolean i) {
		mVal = i;
		mIsNull = false;
	}
	
	public boolean isNull() {
		return mIsNull;
	}
	public boolean getValue() {
		return mVal;
	}
	
	public String tokenize() {
		if (isNull()) {
			return "n";
		} else {
			return getValue() ? "1" : "0";
		}		
	}
	
	public static NullableBoolean fromToken(String token) {
		if ("n".equals(token)) {
			return new NullableBoolean();
		}
		return new NullableBoolean(!token.equals("0"));
	}
	

	@Override
	public boolean equals(Object obj) {
		if (obj == null) {
			return false;
		}
		
		if (!(obj instanceof NullableBoolean)) {
			return false;
		}
		
		NullableBoolean typedObj = (NullableBoolean)obj;
		return mIsNull == typedObj.mIsNull && mVal == typedObj.mVal;
	}
	
	@Override
	public int hashCode() {
		return mIsNull ? 0 : mVal ? 1 : 2;
	}
	
	@Override
	public String toString() {
		return isNull() ? "" : String.valueOf(mVal);
	}

	public Boolean getValueOrDefault(Boolean def) {
		return isNull() ? def : mVal;
	}
}
