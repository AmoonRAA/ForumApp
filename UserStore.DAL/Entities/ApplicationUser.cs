using Microsoft.AspNet.Identity.EntityFramework;

namespace Forum_Marchuk.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
