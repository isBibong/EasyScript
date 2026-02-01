using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public interface MouseCommand : IScriptCommand
{

}

public class MouseDownCommand : MouseCommand
{
    public string _LeftOrRight { get; }

    public MouseDownCommand(string leftOrRight)
    {
        _LeftOrRight = leftOrRight;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        MouseController.Down(_LeftOrRight);
    }
}
public class MouseUpCommand : MouseCommand
{
    public string _LeftOrRight { get; }

    public MouseUpCommand(string leftOrRight)
    {
        _LeftOrRight = leftOrRight;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        MouseController.Up(_LeftOrRight);
    }
}
public class MousePressCommand : MouseCommand
{
    public string _LeftOrRight { get; }

    public MousePressCommand(string leftOrRight)
    {
        _LeftOrRight = leftOrRight;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        MouseController.Press(_LeftOrRight);
    }
}
public class MouseMoveCommand : MouseCommand
{
    public int _X { get; }
    public int _Y { get; }

    public MouseMoveCommand(int x, int y)
    {
        _X = x;
        _Y = y;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        MouseController.Move(_X, _Y);
    }
}