using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public interface KeyboardCommand : IScriptCommand
{

}

public class KeyboardDownCommand : IScriptCommand
{
    public string _key { get; }

    public KeyboardDownCommand(string key)
    {
        _key = key;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
       KeyboardController.Down(_key);
    }
}
public class KeyboardUpCommand : IScriptCommand
{
    public string _key { get; }

    public KeyboardUpCommand(string key)
    {
        _key = key;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.Up(_key);
    }
}
public class KeyboardPressCommand : IScriptCommand
{
    public string _key { get; }

    public KeyboardPressCommand(string key)
    {
        _key = key;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.Press(_key);
    }
}
public class KeyboardMessageCommand : IScriptCommand
{
    public string _Message { get; }

    public KeyboardMessageCommand(string message)
    {
        _Message = message;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.TypeText(_Message);
    }
}

public class KeyboardCutCommand : IScriptCommand
{
    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.Cut();
    }
}
public class KeyboardCopyCommand : IScriptCommand
{
    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.Copy();
    }
}
public class KeyboardPasteCommand : IScriptCommand
{
    public async Task ExecuteAsync(CancellationToken token)
    {
        KeyboardController.Paste();
    }
}
