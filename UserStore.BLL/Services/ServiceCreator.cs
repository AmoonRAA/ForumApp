using Forum_Marchuk.BLL.Interfaces;
using Forum_Marchuk.DAL.Repositories;

namespace Forum_Marchuk.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IReplyService CreateReplyService(string connection)
        {
            return new ReplyServise(new IdentityUnitOfWork(connection));
        }
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
        public IQuestionService CreateQuestionService(string connection)
        {
            return new QuestionService(new IdentityUnitOfWork(connection));
        }
        public IThemeService CreateThemeService(string connection)
        {
            return new ThemeService(new IdentityUnitOfWork(connection));
        }

        
    }
}
