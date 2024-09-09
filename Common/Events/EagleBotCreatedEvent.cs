namespace Common.Events
{
    public record EagleBotCreatedEvent
    {
        public Guid Id { get; init; } = default!;
        public string? Name { get; init; }
        public string Status { get; init; }
        public DateTime? CreatedOn { get; init; }
    }
}
