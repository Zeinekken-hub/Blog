using BlogMvcApp.DLL.Entities;

namespace BlogMvcApp.BLL.Interfaces
{
    public interface IProfileService
    {
        void SendProfile(Questionnaire questionnaire);
    }
}
