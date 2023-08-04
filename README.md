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

public class MyService : IMyService
{
    private readonly IMessenger _messenger;

    public MyService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    private async Task RegisterHandlers()
    {
        // Registers a handler under the default channel.
        // The handler will be removed automatically if
        // this MyService instance is garbage-collected.
        messenger.Register<SomeMessageType>(this, MyHandler);
    }

    private async Task MyHandler(SomeMessageType message)
    {
        // Handle the message.
    }
}
```