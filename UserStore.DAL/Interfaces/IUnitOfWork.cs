using Forum_Marchuk.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace Forum_Marchuk.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IThemeManager ThemeManager { get; }
        IQuestionManager QuestionManager { get; }
        IReplyManager ReplyManager { get; }
        

        Task SaveAsync();
    }
}
