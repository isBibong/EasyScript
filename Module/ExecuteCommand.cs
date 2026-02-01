using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        string side = _parts.Length == 2 ? _parts[2] : "Left";
        switch (_action)
        {
            case "down": MouseController.Down(side); break;
            case "up": MouseController.Up(side); break;
            case "press": MouseController.Press(side); break;
            case "move":
                if (_parts.Length >= 4 && int.TryParse(_parts[2], out int x) && int.TryParse(_parts[3], out int y))
                {
                    MouseController.Move(x, y);
                }
                break;
            default: MessageBox.Show("未知動作: " + _action); break;
        }
    }

    public async Task KeyboardCommand()
    {
        if (_action.Equals("copy")) { KeyboardController.Copy(); return; }
        if (_action.Equals("cut")) { KeyboardController.Cut(); return; }
        if (_action.Equals("paste")) { KeyboardController.Paste(); return; }

        string key = _parts[2].ToLower();

        switch (_action)
        {
            case "down": KeyboardController.Down(key); break;
            case "up": KeyboardController.Up(key); break;
            case "press": KeyboardController.Press(key); break;
            case "msg": KeyboardController.TypeText(key); break;
        }
    }

    public async Task OtherCommandAsync(string arg1)
    {
        switch (_action)
        {
            case "wait":
                if (int.TryParse(arg1, out int ms)) { await Task.Delay(ms, _cancellationToken); }
                break;

            default:
                break;
        }
    }

    public bool GetCommandAndAction()
    {
        if (_parts.Length < 3)
        {
            MessageBox.Show("腳本指令長度錯誤，請檢查!");
            return false;
        }

        _command = _parts[0].ToLower();
        _action = _parts[1].ToLower();
        return true;
    }
}