using System.Collections.Generic;
using AutoMapper;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.Models;

namespace BlogMvcApp.Infrastructure.Mapper
{
    public static class FeedbackMapper
    {
        public static FeedbackViewModel ToFeedbackVm(this Feedback feedback)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Feedback, FeedbackViewModel>())
                .CreateMapper()
                .Map<Feedback, FeedbackViewModel>(feedback);
        }

        public static IEnumerable<FeedbackViewModel> ToFeedbackVm(this IEnumerable<Feedback> feedbacks)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Feedback, FeedbackViewModel>())
                .CreateMapper()
                .Map<IEnumerable<Feedback>, IEnumerable<FeedbackViewModel>>(feedbacks);
        }
    }
}