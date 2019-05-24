using Microsoft.AspNetCore.Identity.MongoDB;

namespace Domain.Entities
{
    public class PHOTOnlineUser : IdentityUser, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
