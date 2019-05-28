using Microsoft.AspNetCore.Identity.MongoDB;
using PHOTOnline.Domain.Entities.Enums;

namespace Domain.Entities
{
    public class PHOTOnlineUser : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public UserType UserType { get; set; }
    }
}
