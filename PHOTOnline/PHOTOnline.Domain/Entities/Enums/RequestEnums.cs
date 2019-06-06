namespace Domain.Entities.Enums
{
    public enum RequestStatus
    {
        Approved = 1, Rejected = 2, OnHold = 3
    }

    public enum RequestType
    {
        Order = 1, Scheduling = 2
    }

    public enum EventType
    {
        Wedding = 0, Christening = 1, Engagement = 2, Birthday = 3, PhotoSession = 4, Other = 5
    }
}