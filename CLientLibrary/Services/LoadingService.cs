using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CLientLibrary.Services;

public class LoadingService
{
    public event Action? OnChange;

    private bool _isLoading;
    public bool IsLoading => _isLoading;

    private CancellationTokenSource? _delayToken;

    private void NotifyStateChanged() => OnChange?.Invoke();

    /// <summary>
    /// Zekice loader yönetimi: işlem uzun sürerse loader gösterir ve en az 0.5sn tutar.
    /// </summary>
    public async Task LoadSmartAsync(Func<Task> asyncOperation, int delayBeforeShowing = 500, int minDisplayDuration = 500)
    {
        var cts = new CancellationTokenSource();
        var stopwatch = Stopwatch.StartNew();
        bool loaderShown = false;

        var delayTask = Task.Delay(delayBeforeShowing, cts.Token);
        var operationTask = asyncOperation();

        if (await Task.WhenAny(delayTask, operationTask) == delayTask)
        {
            // İşlem 500ms içinde tamamlanmadı, loader göster
            _isLoading = true;
            loaderShown = true;
            NotifyStateChanged();
        }
        else
        {
            // Hızlı tamamlandı, loader'a gerek yok
            cts.Cancel();
        }

        await operationTask;

        if (loaderShown)
        {
            var displayTime = stopwatch.ElapsedMilliseconds - delayBeforeShowing;
            var remainingTime = minDisplayDuration - (int)displayTime;

            if (remainingTime > 0)
            {
                await Task.Delay(remainingTime);
            }

            _isLoading = false;
            NotifyStateChanged();
        }
    }

    public void Show()
    {
        _delayToken?.Cancel();
        _isLoading = true;
        NotifyStateChanged();
    }

    public void Hide()
    {
        _delayToken?.Cancel();
        if (_isLoading)
        {
            _isLoading = false;
            NotifyStateChanged();
        }
    }
}
