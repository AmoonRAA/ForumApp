using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Forum_Marchuk.DAL.Entities;

namespace Forum_Marchuk.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base() { }
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Question> Questions { get; set; }

        public void Modified<T>(T item) => Entry(item).State = EntityState.Modified;
    }
}
