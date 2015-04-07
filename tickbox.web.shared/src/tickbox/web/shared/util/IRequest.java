package tickbox.web.shared.util;

public interface IRequest<T> {
	
	void onSuccess(T data);
	void onError(Throwable exception);
}
