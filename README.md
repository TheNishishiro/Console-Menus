# Console Menus
A very simple library for creating neat console menus!

## Screenshots

## Usage

Using pages is pretty easy but first you need to create your pages.

Create a class for example `WelcomePage` and derive from `ConsolePage` base class.

```csharp
public class WelcomePage : ConsolePage
{
    public WelcomePage() : base("Welcome page")
    {
        AddOption(new ConsoleOption("Start", Start));
        SetBackText("Exit");
    }
    
    private void Start()
    {
        NavigateTo<GettingStartedPage>();
    }
}
```

Method `AddOption` creates a new option and adds it to the menu, option has a specified `Start` action to call upon invoke which will open the next page via `NavigateTo` call. 
Then `SetBackText` sets the text for the back option.

To Use created page we need to create an instance of `ConsoleMenu` and add pages which we want to use.

```csharp
var menu = new ConsoleMenu();
menu.AddPage<MyStartingPage>();
menu.AddPage<GettingStartedPage>();
```

Next we need to specify which page we want to start with.

```csharp
menu.MainPage<MyStartingPage>();
```

And finally we can start the menu.

```csharp
menu.Run();
```