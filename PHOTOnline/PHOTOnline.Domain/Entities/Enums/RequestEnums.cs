namespace Domain.Entities.Enums
{
    public enum RequestStatus
    {
        Approved, Rejected, OnHold
    }

    public enum RequestType
    {
        Order = 1, Scheduling = 2
    }

    public enum EventType
    {
        Wedding = 1, Birthday = 2
    }
}