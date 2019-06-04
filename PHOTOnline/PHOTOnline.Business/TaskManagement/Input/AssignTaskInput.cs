using Domain.Entities.Enums;
using System;

namespace PHOTOnline.Business.TaskManagement.Input
{
    public class AssignTaskInput
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public string PhotographId { get; set; }
        public EventType EventType { get; set; }
        public string RequestId { get; set; }
        public string Notification { get; set; }
    }
}
