using System;
using System.Collections.Generic;
using System.Text;

namespace PHOTOnline.Business.UserManagement.Input
{
    public class CreatePhotographInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
