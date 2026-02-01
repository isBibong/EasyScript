using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utils
{
    public static bool IsMissingArguments(string[] parts, int len)
    {
        if (parts.Length < len)
        {
            return true;
        }
        return false;
    }
}

