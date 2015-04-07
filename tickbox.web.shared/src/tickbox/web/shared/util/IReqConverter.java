package tickbox.web.shared.util;

public interface IReqConverter {

	void onError(Throwable exception);

	void onSuccess(String data);

}
