package tickbox.web.shared.util;

public class NullableDouble {

	private final Double mDouble;
	private final boolean mIsNull;

	private NullableDouble() {
		mDouble = (double)0;
		mIsNull = true;
	}
	
	public static NullableDouble getNull() {
		return new NullableDouble();
	}
	
	public NullableDouble(Double d) {
		mDouble = d;
		mIsNull = false;
	}
	
	public boolean isNull() {
		return mIsNull;
	}
	public double getDouble() {
		return mDouble;
	}
	public Double getValueOrDefault(Double def) {
		return isNull() ? def : mDouble;
	}
	
	public String tokenize() {
		if (isNull()) {
			return "n";
		} else {
			return String.valueOf(getDouble());
		}		
	}
	
	public static NullableDouble fromToken(String token) {
		if ("n".equals(token)) {
			return new NullableDouble();
		}
		return new NullableDouble(Double.parseDouble(token));
	}
	
	@Override
	public boolean equals(Object obj) {
		if (obj == null) {
			return false;
		}
		
		if (!(obj instanceof NullableDouble)) {
			return false;
		}
		
		NullableDouble typedObj = (NullableDouble)obj;
		return mIsNull == typedObj.mIsNull && mDouble == typedObj.mDouble;
	}
	
	@Override
	public int hashCode() {
		return mIsNull ? 0 : mDouble.hashCode();
	}
	
	@Override
	public String toString() {
		return isNull() ? "" : String.valueOf(getDouble());
	}
}
