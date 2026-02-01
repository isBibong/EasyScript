using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

public static class CommandFactory
{
    public static IScriptCommand Parse(string line)
    {
        var parts = line.Split(',');
        if (Utils.IsMissingArguments(parts, 2)) return null;

        string type = parts[0].ToLower();
        string action = parts[1].ToLower();

        if (type == "mouse")
        {
            if (Utils.IsMissingArguments(parts, 3)) return null;

            switch (action)
            {
                case "down": { return new MouseDownCommand(parts[2]); }
                case "up": { return new MouseUpCommand(parts[2]); }
                case "press": { return new MousePressCommand(parts[2]); }
                case "move": { return new MouseMoveCommand(int.Parse(parts[2]), int.Parse(parts[3])); }
            }
        }
        else if (type == "keyboard")
        {
            if (action == "cut") { return new KeyboardCutCommand(); }
            if (action == "copy") { return new KeyboardCopyCommand(); }
            if (action == "paste") { return new KeyboardPasteCommand(); }

            if (Utils.IsMissingArguments(parts, 3)) return null;

            switch (action)
            {
                case "down": { return new KeyboardDownCommand(parts[2]); }
                case "up": { return new KeyboardUpCommand(parts[2]); }
                case "press": { return new KeyboardPressCommand(parts[2]); }
                case "msg": { return new KeyboardMessageCommand(parts[2]); }
            }
        }
        else if (type == "other")
        {
            if (Utils.IsMissingArguments(parts, 3)) return null;

            switch (action)
            {
                case "wait": { return new WaitCommand(int.Parse(parts[2])); }
                case "fpt": { return new FindAndClickCommand(parts[2], Utils.IsMissingArguments(parts, 4) ? 5000 : int.Parse(parts[3])); }
            }
        }

        return null;
    }
}