using System;
using System.Collections.Generic;
using System.Text;

namespace Business.UserManagement.Input
{
    public class UpdateCredentialsInput
    {
        public string NewEmail { get; set; }
        public string NewPassword { get; set; }
        public string NewAddress { get; set; }
        public string NewPhoneNumber { get; set; }
        public string CurrentEmail { get; set; }
    }
}
