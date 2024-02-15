namespace Immense.SimpleMessenger.Internals;

internal class SubscriberReference<TMessage>
{
    public SubscriberReference(object subscriber, RegistrationCallback<TMessage> handler)
    {
        Subscriber = subscriber;
        Handler = handler;
    }

    public object Subscriber { get; }
    public RegistrationCallback<TMessage> Handler { get; }
}