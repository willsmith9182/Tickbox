package tickbox.web.shared.util;

public interface  Func<T, TResult> {
	TResult call(T val);
}
