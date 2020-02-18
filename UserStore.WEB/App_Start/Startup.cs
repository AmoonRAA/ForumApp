using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Forum_Marchuk.BLL.Services;
using Microsoft.AspNet.Identity;
using Forum_Marchuk.BLL.Interfaces;

[assembly: OwinStartup(typeof(Forum_Marchuk.App_Start.Startup))]

namespace Forum_Marchuk.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.CreatePerOwinContext<IReplyService>(CreateReplyService);
            app.CreatePerOwinContext<IQuestionService>(CreateQuestionService);
            app.CreatePerOwinContext<IThemeService>(CreateThemeService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
        private IReplyService CreateReplyService()
        {
            return serviceCreator.CreateReplyService("DefaultConnection");
        }
        private IQuestionService CreateQuestionService()
        {
            return serviceCreator.CreateQuestionService("DefaultConnection");
        }
        private IThemeService CreateThemeService()
        {
            return serviceCreator.CreateThemeService("DefaultConnection");
        }
    }
}
