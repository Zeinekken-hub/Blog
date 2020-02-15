using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.Models;

namespace BlogMvcApp.Infrastructure.Mapper
{
    public static class ArticleMapper
    {
        public static ArticleAdViewModel ToArticleAdVm(this Article article, int textAdLength)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleAdViewModel>()
                    .ForMember("Text", opt => opt.MapFrom(item => item.Text.Substring(0, textAdLength)))
                    .ForMember("CommentCount", opt => opt.MapFrom(item => item.Feedbacks.Count));
            }).CreateMapper().Map<Article, ArticleAdViewModel>(article);
        }

        public static IEnumerable<ArticleAdViewModel> ToArticleAdVm(this IEnumerable<Article> articles, int textAdLength)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleAdViewModel>()
                    .ForMember("Text", opt => opt.MapFrom(item => item.Text.Substring(0, textAdLength)))
                    .ForMember("CommentCount", opt => opt.MapFrom(item => item.Feedbacks.Count));
            })
                .CreateMapper()
                .Map<IEnumerable<Article>, IEnumerable<ArticleAdViewModel>>(articles);
        }

        public static ArticleViewModel ToArticleVm(this Article article)
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleViewModel>()
                    .ForMember("Feedbacks", opt => opt.MapFrom(item => item.Feedbacks.ToFeedbackVm()))
                    .ForMember("Tags", opt => opt.MapFrom(item => item.Tags.ToTagVm()));
            })
                .CreateMapper()
                .Map<Article, ArticleViewModel>(article);
        }

        public static IEnumerable<ArticleViewModel> ToArticleVm(this IEnumerable<Article> articles)
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Article, ArticleViewModel>()
                        .ForMember("Feedbacks", opt => opt.MapFrom(item => item.Feedbacks.ToFeedbackVm()))
                        .ForMember("Tags", opt => opt.MapFrom(item => item.Tags.ToTagVm()));
                })
                .CreateMapper()
                .Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(articles);
        }
    }
}