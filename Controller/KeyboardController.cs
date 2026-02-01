using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

public class KeyboardController
{
    private static readonly InputSimulator _sim = new InputSimulator();

    public static readonly HashSet<VirtualKeyCode> _heldKeys = new HashSet<VirtualKeyCode>();
    public static CancellationTokenSource _holdingCts;

    static KeyboardController()
    {
        StartHoldingTask();
    }

    private static void StartHoldingTask()
    {
        _holdingCts = new CancellationTokenSource();
        Task.Run(async () =>
        {
            while (!_holdingCts.Token.IsCancellationRequested)
            {
                lock (_heldKeys)
                {
                    foreach (var key in _heldKeys)
                    {
                        _sim.Keyboard.KeyDown(key);
                    }
                }
                await Task.Delay(30);
            }
        });
    }

    public static void TypeText(string text)
    {
        _sim.Keyboard.TextEntry(text);
    }

    public static void Down(string key)
    {
        VirtualKeyCode? keyCode = GetKeyCode(key);
        if (keyCode == null) return;

        lock (_heldKeys)
        {
            if (!_heldKeys.Contains(keyCode.Value))
            {
                _heldKeys.Add(keyCode.Value);
                _sim.Keyboard.KeyDown(keyCode.Value);
            }
        }
    }

    public static void Up(string key)
    {
        VirtualKeyCode? keyCode = GetKeyCode(key);
        if (keyCode == null) return;

        lock (_heldKeys)
        {
            _heldKeys.Remove(keyCode.Value);
            _sim.Keyboard.KeyUp(keyCode.Value);
        }
    }

    public static void Press(String key)
    {
        VirtualKeyCode? keyCode = GetKeyCode(key);
        if (keyCode == null) return;

        _sim.Keyboard.KeyPress(keyCode.Value);
    }

    public static void Cut()
    {
        _sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_X);
    }
    public static void Copy()
    {
        _sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C);
    }
    public static void Paste()
    {
        _sim.Keyboard.ModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V);
    }

    public static void ReleaseAll()
    {
        lock (_heldKeys)
        {
            foreach (var key in _heldKeys)
            {
                _sim.Keyboard.KeyUp(key);
            }
            _heldKeys.Clear();
        }
    }

    public static VirtualKeyCode? GetKeyCode(string keyName)
    {
        if (keyName.Length == 1)
        {
            string vkName = "VK_" + keyName.ToUpper();
            if (Enum.TryParse<VirtualKeyCode>(vkName, true, out var vkResult))
            {
                return vkResult;
            }
        }

        if (Enum.TryParse<VirtualKeyCode>(keyName, true, out var result))
        {
            return result;
        }

        if (keyName.ToLower() == "enter") return VirtualKeyCode.RETURN;
        else if (keyName.ToLower() == "ctrl") return VirtualKeyCode.CONTROL;
        else MessageBox.Show($"找不到按鍵: {keyName}");

        return null;
    }
}
