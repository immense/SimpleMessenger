namespace Immense.SimpleMessenger.Internals;

internal sealed class RegistrationToken : IDisposable
{
    private readonly Action _disposalAction;
    private bool _disposedValue;

    public RegistrationToken(Action disposalAction)
    {
        _disposalAction = disposalAction;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                try
                {
                    _disposalAction();
                }
                catch
                {
                    // Ignore errors.
                }
            }
            _disposedValue = true;
        }
    }
}
