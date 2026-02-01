using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

[Obsolete("請改用 IScriptCommand 體系下的各別指令類別。")]
public class ExecuteCommand
{
    private readonly string[] _parts;
    private readonly CancellationToken _cancellationToken;

    private string _command;
    private string _action;

    public ExecuteCommand(string input, CancellationToken token)
    {
        _parts = input.Split(',');
        _cancellationToken = token;
    }

    public async Task<bool> Execute()
    {
        if (!GetCommandAndAction())
        {
            return false;
        }

        if (_command == "mouse") await MouseCommand();
        else if (_command == "keyboard") await KeyboardCommand();
        else if (_command == "other") await OtherCommandAsync(_parts[2]);
        else
        {
            MessageBox.Show("未知指令: " + _command);
            return false;
        }
        return true;
    }

    public async Task MouseCommand()
    {
        if (Utils.IsMissingArguments(_parts, 3)) return;

        string side = _parts.Length == 2 ? _parts[2] : "Left";
        switch (_action)
        {
            case "down": MouseController.Down(side); return;
            case "up": MouseController.Up(side); return;
            case "press": MouseController.Press(side); return;
            
            case "move":
                if (Utils.IsMissingArguments(_parts, 4)) return;
                if (int.TryParse(_parts[2], out int x) && int.TryParse(_parts[3], out int y))
                {
                    MouseController.Move(x, y);
                }
                return;
            
            default: MessageBox.Show("未知動作: " + _action); return;
        }
    }

    public async Task KeyboardCommand()
    {
        switch (_action.ToLower())
        {
            case "copy": KeyboardController.Copy(); return;
            case "cut": KeyboardController.Cut(); return;
            case "paste": KeyboardController.Paste(); return;
        }

        if (Utils.IsMissingArguments(_parts, 3)) return;

        string key = _parts[2].ToLower();
        switch (_action)
        {
            case "down": KeyboardController.Down(key); return;
            case "up": KeyboardController.Up(key); return;
            case "press": KeyboardController.Press(key); return;
            case "msg": KeyboardController.TypeText(key); return;
        }
    }

    public async Task OtherCommandAsync(string arg1)
    {
        if (Utils.IsMissingArguments(_parts, 3)) return;

        switch (_action)
        {
            case "wait":
                if (int.TryParse(arg1, out int ms)) { await Task.Delay(ms, _cancellationToken); }
                return;

            default:
                return;
        }
    }

    public bool GetCommandAndAction()
    {
        if (Utils.IsMissingArguments(_parts, 2)) return false;

        _command = _parts[0].ToLower();
        _action = _parts[1].ToLower();
        return true;
    }
}