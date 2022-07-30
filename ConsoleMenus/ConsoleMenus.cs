using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ConsoleMenus.Exceptions;

namespace ConsoleMenus;

public class ConsoleMenu
{
    private Dictionary<Type, ConsolePage> ConsolePages { get; set; }
    private readonly Thread _displayThread;
    private bool _shouldExit;
    private readonly Stack<ConsolePage> _history;
    private ConsolePage CurrentPage => _history.Peek();

    public ConsoleMenu()
    {
        ConsolePages = new Dictionary<Type, ConsolePage>();
        _history = new Stack<ConsolePage>();

        _displayThread = new Thread(Display);
    }

    public ConsoleMenu AddPage<T>() where T : ConsolePage, new()
    {
        if (ConsolePages.ContainsKey(typeof(T)))
            throw new PageTypeExistsException<T>();

        var page = new T();

        page.AssignToMenu(this);
        ConsolePages.Add(typeof(T), page);

        return this;
    }

    public void MainPage<T>()
    {
        if (!ConsolePages.ContainsKey(typeof(T)))
            throw new PageNotFoundException<T>();

        var mainPage = ConsolePages[typeof(T)];
        _history.Push(mainPage);
    }

    public void PreviousPage()
    {
        if (_history.Count > 1)
            _history.Pop();
        else
            _shouldExit = true;
    }

    public void NavigateTo<T>()
    {
        if (!ConsolePages.ContainsKey(typeof(T)))
            throw new PageNotFoundException<T>();

        var page = ConsolePages[typeof(T)];
        _history.Push(page);
    }

    public void Display()
    {
        while (!_shouldExit)
        {
            Console.Clear();
            DisplayPath();
            Console.WriteLine($"\n{new String('-', 80)}\n");
            CurrentPage.DisplayMenu();
        }
    }

    private void DisplayPath()
    {
        foreach (var page in _history.Reverse())
        {
            Console.Write($">{page.Title}");
        }
    }

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.White;
        _displayThread.Start();
    }
}
