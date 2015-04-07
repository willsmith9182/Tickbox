package tickbox.web.shared.util;

/*
 * Useful in the DataService classes that only just convert the data
 */
public abstract class ReqConverter<T> implements IReqConverter, IRequest<String> {

	private final IRequest<T> _req;
	
	public ReqConverter(IRequest<T> req) {
		_req = req;
	}
	
	public abstract T convert(String val);
	
	@Override
	public void onSuccess(String data) {
		_req.onSuccess(convert(data));
	}

	@Override
	public void onError(Throwable exception) {
		_req.onError(exception);
	}

	
}
