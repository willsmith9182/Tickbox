package tickbox.web.shared.util;

public class Option {

	private final String _name;
	private final String _val;
	private final String _abbrev;
	
	public Option(String name, String val, String abbrev) {
		_name = name;
		_val = val;
		_abbrev = abbrev;
	}

	public String GetName() {
		return _name;
	}
	public String GetValue() {
		return _val;
	}
	public String GetAbbrev() {
		return _abbrev;
	}
}
