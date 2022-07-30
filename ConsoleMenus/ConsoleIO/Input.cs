using System.Text;

namespace ConsoleMenus.ConsoleIO;

public class Input
{
	public static int NumberValue()
    {
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var result)) return result;
            NotifyIncorrectFormat();
        }
    }

    public static int NumberValue(string prompt)
    {
        Console.Write(prompt + " ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out var result)) return result;
            NotifyIncorrectFormat();
        }
    }

    public static int NumberValueInRange(int min, int max)
    {
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out var result))
            {
                NotifyIncorrectFormat();
                continue;
            }

            if (result >= min && result <= max) return result;
            NotifyUnknownOption();
        }
    }

    public static int NumberValueInRange(string prompt, int min, int max)
    {
        Console.Write(prompt + " ");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out var result))
            {
                NotifyIncorrectFormat();
                continue;
            }

            if (result >= min && result <= max) return result;
            NotifyUnknownOption();
        }
    }

    public static bool BoolValue(string prompt)
    {
        Console.Write(prompt + " (1/0) ");
        var response = string.Empty;
        while (response != "1" && response != "0")
            response = Console.ReadLine()?.ToLower();
        return response == "1";
    }

    public static string StringValue()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public static string StringValue(string prompt)
    {
        Console.Write(prompt + " ");
        return Console.ReadLine() ?? string.Empty;
    }

    public static int EnumValue<TEnumType>(string prompt) where TEnumType : Enum
    {
        Console.WriteLine(prompt + " ");
        var enumValues = Enum.GetValues(typeof(TEnumType));
        foreach (var e in enumValues)
        {
            Console.WriteLine($"{(int)e}) {e}");
        }
        var canParse = int.TryParse(Console.ReadLine() ?? string.Empty, out var result);
        var isValid = canParse && enumValues.Cast<int>().Contains(result);
        switch (canParse)
        {
            case true when isValid:
                return result;
            case true when !isValid:
                NotifyUnknownOption();
                break;
            default:
                NotifyIncorrectFormat();
                break;
        }

        return result;
    }

    public static double DoubleValue(string prompt)
    {
        Console.Write(prompt + " ");
        return double.Parse(Console.ReadLine() ?? string.Empty);
    }

    public static void AwaitAny()
    {
        Output.Information("Press any key to continue");
        Console.ReadKey();
    }

    public static string StringMasked(string prompt, char mask = '*')
    {
        Console.Write(prompt + " ");
        var sb = new StringBuilder();
        ConsoleKeyInfo keyInfo;
        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (!char.IsControl(keyInfo.KeyChar))
            {
                sb.Append(keyInfo.KeyChar);
                Console.Write(mask);
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);

                if (Console.CursorLeft == 0)
                {
                    Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                    Console.Write(' ');
                    Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                }
                else Console.Write("\b \b");
            }
        }
        Console.WriteLine();
        return sb.ToString();
    }

    private static void NotifyIncorrectFormat()
    {
        Output.Error("Incorrect input format.");
    }

    private static void NotifyUnknownOption()
    {
        Output.Error("Unknown option.");
    }
}