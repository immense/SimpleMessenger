# SimpleMessenger
A simple, lightweight event messenger that uses a `ConditionalWeakTable` internally.

NuGet: https://www.nuget.org/packages/Immense.SimpleMessenger


### Usage

``` C#
// Program.cs
using Immense.SimpleMessenger;

// ...

services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
```

``` C#
// MyService.cs

public class MyService : IMyService, IAsyncDisposable
{
    private readonly IMessenger _messenger;
    private readonly Task<IAsyncDisposable> _messengerRegistration;

    public MyService(IMessenger messenger)
    {
        _messenger = messenger;

        // Registers a handler under the default channel.
        // The handler will be removed automatically if
        // this MyService instance is garbage-collected.
        // Or it can be removed manually by disposing of the return
        // value of the Register method.
        _messengerRegistration = messenger.Register<SomeMessageType>(this, MyHandler);
    }

    public async ValueTask DisposeAsync()
    {
        var disposable = await _messengerRegistration;
        await disposable.DisposeAsync();
    }

    private async Task MyHandler(SomeMessageType message)
    {
        // Handle the message.
    }
}
```