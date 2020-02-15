using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BlogMvcApp.DLL.Entities;
using BlogMvcApp.Models;

namespace BlogMvcApp.Infrastructure.Mapper
{
    public static class TagMapper
    {
        public static TagViewModel ToTagVm(this Tag tag)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagViewModel>())
                .CreateMapper()
                .Map<Tag, TagViewModel>(tag);
        }

        public static IEnumerable<TagViewModel> ToTagVm(this IEnumerable<Tag> tags)
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagViewModel>())
                .CreateMapper()
                .Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(tags);
        }
    }
}