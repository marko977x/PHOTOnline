namespace Domain.Entities.Enums
{
    public enum RequestStatus
    {
        Completed, Rejected, OnHold
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