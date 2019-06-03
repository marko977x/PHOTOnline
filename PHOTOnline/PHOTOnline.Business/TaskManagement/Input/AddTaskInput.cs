using Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.TaskManagement.Input
{
    public class AddTaskInput
    {
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public string PhotographId { get; set; }
        public EventType EventType { get; set; }
    }
}
