namespace EventBus.Messages.Contracts
{
    public record MessageEvent
    {
        public string Text { get; init; } = null!;
    }
}
