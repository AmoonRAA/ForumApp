using Forum_Marchuk.DAL.EF;
using Forum_Marchuk.DAL.Entities;
using Forum_Marchuk.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using Forum_Marchuk.DAL.Identity;
using System.Data.Entity.Validation;

namespace Forum_Marchuk.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;
        private IThemeManager themeManager;
        private IQuestionManager questionManager;
        private IReplyManager replyManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
            questionManager = new QuestionManager(db);
            themeManager = new ThemeManager(db);
            replyManager = new ReplyManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }
        public IQuestionManager QuestionManager
        {
            get { return questionManager; }
        }
        public IThemeManager ThemeManager
        {
            get { return themeManager; }
        }
        public IReplyManager ReplyManager
        {
            get { return replyManager; }
        }


        public async Task SaveAsync()
        {
                await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
