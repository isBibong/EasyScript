using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public interface OtherCommand : IScriptCommand
{
}

public class WaitCommand : OtherCommand
{
    private readonly int _ms;
    public WaitCommand(int ms) { _ms = ms; }

    public async Task ExecuteAsync(CancellationToken token)
    {
        await Task.Delay(_ms, token);
    }
}