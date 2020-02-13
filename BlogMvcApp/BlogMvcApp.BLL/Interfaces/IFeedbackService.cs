using BlogMvcApp.DLL.Entities;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IFeedbackService
    {
        void SendFeedback(Feedback feedback);
    }
}
