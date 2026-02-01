using System.Windows.Forms;
using WindowsInput;

public class MouseController
{
    private static readonly InputSimulator _sim = new InputSimulator();

    public static void Press(string button)
    {
        if (button.ToLower().Equals("left"))
        {
            _sim.Mouse.LeftButtonClick();
        }
        else if (button.ToLower().Equals("right"))
        {
            _sim.Mouse.RightButtonClick();
        }
    }

    public static void Down(string button)
    {
        if (button.ToLower().Equals("left"))
        {
            _sim.Mouse.LeftButtonDown();
        }
        else if (button.ToLower().Equals("right"))
        {
            _sim.Mouse.RightButtonDown();
        }
    }

    public static void Up(string button)
    {
        if (button.ToLower().Equals("left"))
        {
            _sim.Mouse.LeftButtonUp();
        }
        else if (button.ToLower().Equals("right"))
        {
            _sim.Mouse.RightButtonUp();
        }
    }

    public static void Move(int x, int y)
    {
        double screenWidth = Screen.PrimaryScreen.Bounds.Width;
        double screenHeight = Screen.PrimaryScreen.Bounds.Height;

        double virtualX = x * (65535.0 / screenWidth);
        double virtualY = y * (65535.0 / screenHeight);

        _sim.Mouse.MoveMouseTo(virtualX, virtualY);
    }
}

