using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.BLL.Services;
using Ninject.Modules;

namespace BlogMvcApp.Util
{
    public class BlogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<IFeedbackService>().To<FeedbackService>();
            Bind<IProfileService>().To<ProfileService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}