using Microsoft.AspNetCore.Identity;

namespace WebApp.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public long ApllicationId { get; set; }
    }
}
