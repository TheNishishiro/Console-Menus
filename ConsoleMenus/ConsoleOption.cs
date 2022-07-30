using ConsoleMenus.ConsoleIO;

namespace ConsoleMenus;

public class ConsoleOption
{
	public delegate void CallbackFunction();

	private readonly CallbackFunction? _callback;
	private readonly string _title;
	private readonly bool _inactive;

	public ConsoleOption(string title, CallbackFunction callback, bool inactive = false)
	{
		_callback = callback;
		_title = title;
		_inactive = inactive;
	}
	
	public ConsoleOption(string title, bool inactive = true)
	{
		_title = title;
		_inactive = inactive;
	}

	public void Execute()
	{
		_callback?.Invoke();
	}

	public void GetDisplayText(int id)
	{
		if (_inactive)
			Output.Inactive($"{id}. {_title}");
		else
			Output.WriteLine($"{id}. {_title}");
	}
}