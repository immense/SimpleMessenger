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

public class MyService : IMyService, IDisposable
{
    private readonly IMessenger _messenger;
    private readonly IDisposable _messengerRegistration;

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

    public void Dispose()
    {
        _messengerRegistration.Dispose();
    }

    private async Task MyHandler(object subscriber, SomeMessageType message)
    {
        // Handle the message.
    }
}
```