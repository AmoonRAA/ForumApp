using Forum_Marchuk.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace Forum_Marchuk.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
