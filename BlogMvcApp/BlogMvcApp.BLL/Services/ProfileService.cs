using BlogMvcApp.BLL.Interfaces;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.DLL.Interfaces;

namespace BlogMvcApp.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork Database { get; }

        public ProfileService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void SendProfile(Questionnaire questionnaire)
        {
            Database.Questionnaires.Create(questionnaire);
            Database.Save();
        }
    }
}
