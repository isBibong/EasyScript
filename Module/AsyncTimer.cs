using System;
using System.Threading;
using System.Threading.Tasks;

public class AsyncTimer
{
    private CancellationTokenSource _cts;
    private readonly Func<Task> _actionAsync;
    private readonly int _interval;

    public CancellationToken Token => _cts?.Token ?? CancellationToken.None;
    public bool IsRunning => _cts != null && !_cts.IsCancellationRequested;

    public AsyncTimer(Func<Task> action, int interval)
    {
        _actionAsync = action;
        _interval = interval;
    }

    public void Start()
    {
        if (IsRunning) return;
        _cts = new CancellationTokenSource();
        Task.Run(async () =>
        {
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    await _actionAsync.Invoke(); // 這裡要 await
                    await Task.Delay(_interval, _cts.Token);
                }
            }
            catch (OperationCanceledException) { }
        }, _cts.Token);
    }

    public void Stop()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
    }
}
