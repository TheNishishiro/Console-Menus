using ConsoleMenus.ConsoleIO;

namespace ConsoleMenus;

public class ConsoleOption
{
	public delegate void CallbackFunction();

	private readonly CallbackFunction _callback;
	private readonly string _title;
	private readonly bool _grayOut;

	public ConsoleOption(string title, CallbackFunction callback, bool grayout = false)
	{
		_callback = callback;
		_title = title;
		_grayOut = grayout;
	}

	public void Execute()
	{
		_callback();
	}

	public void GetDisplayText(int id)
	{
		if (_grayOut)
			Output.Inactive($"{id}. {_title}");
		else
			Output.WriteLine($"{id}. {_title}");
	}
}