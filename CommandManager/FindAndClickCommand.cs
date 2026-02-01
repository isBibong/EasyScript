using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class FindAndClickCommand : IScriptCommand
{
    private readonly string _imgPath;
    private readonly int _timeoutMs;

    public FindAndClickCommand(string imgPath, int timeoutMs = 5000)
    {
        _imgPath = imgPath;
        _timeoutMs = timeoutMs;
    }

    public async Task ExecuteAsync(CancellationToken token)
    {
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalMilliseconds < _timeoutMs)
        {
            token.ThrowIfCancellationRequested();

            System.Drawing.Point? result = ImageSearcher.FindImage(_imgPath);
            if (result.HasValue)
            {
                MouseController.Move(result.Value.X, result.Value.Y);
                MouseController.Press("left");
                return;
            }

            await Task.Delay(500, token);
        }
        // 若超時可記錄日誌或拋出異常
    }
}

