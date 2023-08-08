using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immense.SimpleMessenger.Internals;
internal class HandlerRegistration<TMessageType, TChannelType> : IAsyncDisposable
    where TMessageType : class
    where TChannelType : IEquatable<TChannelType>
{
    private WeakReferenceTable? _table;
    private object? _subscriber;

    public HandlerRegistration(WeakReferenceTable table, object subscriber)
    {
        _table = table;
        _subscriber = subscriber;
    }

    public async ValueTask DisposeAsync()
    {
        if (_table is not null && _subscriber is not null)
        {
            await _table.Remove(_subscriber);
        }

        // We want to allow the subscriber to be GCed, even if something
        // still has a reference to this disposed instance.
        _subscriber = null;
        _table = null;
    }
}