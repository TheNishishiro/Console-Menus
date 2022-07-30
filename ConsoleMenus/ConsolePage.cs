using ConsoleMenus.ConsoleIO;

namespace ConsoleMenus;

public class ConsolePage
{
	private List<ConsoleOption> ConsoleOptions { get; set; }
	public string Title { get; set; }
	private ConsoleMenu? ConsoleMenu { get; set; }
	private string TextBackOption { get; set; } = "Back";
	
	public ConsolePage(string title)
	{
		ConsoleOptions = new List<ConsoleOption>();
		Title = title;
	}

	public ConsolePage AddOption(ConsoleOption consoleOption)
	{
		ConsoleOptions.Add(consoleOption);
		return this;
	}

	public void AssignToMenu(ConsoleMenu consoleMenu)
	{
		ConsoleMenu = consoleMenu;
	}

	public virtual void OnTitleDisplay()
	{
		Output.WriteLine($"\t{Title}\n");
	}

	public virtual void DisplayMenu()
	{
		OnTitleDisplay();
		var id = 1;
		foreach (var option in ConsoleOptions)
		{
			option.GetDisplayText(id);
			id++;
		}
		Output.WriteLine($"{id}. {TextBackOption}");

		HandleInput();
	}

	private void HandleInput()
	{
		var chosenOption = Input.NumberValueInRange(1, ConsoleOptions.Count + 1) - 1;
		if (chosenOption == ConsoleOptions.Count)
			ConsoleMenu?.PreviousPage();
		else
			ConsoleOptions[chosenOption].Execute();
	}
}