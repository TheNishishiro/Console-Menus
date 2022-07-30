namespace ConsoleMenus.ConsoleIO;

public class Output
{
	public static void WriteLine(string text)
	{
		Console.WriteLine(text);
	}

	public static void WriteLine(ConsoleColor color, string text)
	{
		SetColor(color);
		Console.WriteLine(text);
		SetColor(ConsoleColor.White);
	}

	public static void Error(string text)
	{
		WriteLine(ConsoleColor.Red, text);
	}

	public static void Success(string text)
	{
		WriteLine(ConsoleColor.Green, text);
	}

	public static void Information(string text)
	{
		WriteLine(ConsoleColor.Cyan, text);
	}

	public static void Inactive(string text)
	{
		WriteLine(ConsoleColor.DarkGray, text);
	}

	public static void SetColor(ConsoleColor color)
	{
		Console.ForegroundColor = color;
	}
}