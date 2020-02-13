using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;

namespace BlogMvcApp.BLL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IUnitOfWork Database { get; }

        public FeedbackService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void SendFeedback(Feedback feedback)
        {
            Database.Feedbacks.Create(feedback);
            Database.Save();
        }
    }
}
