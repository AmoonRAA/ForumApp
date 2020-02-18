namespace Forum_Marchuk.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
        IReplyService CreateReplyService(string connection);
        IQuestionService CreateQuestionService(string connection);
        IThemeService CreateThemeService(string connection);

    }
}
