namespace ForumSystem.Web.MVC.Models.ForumPosts
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Infrastructure.Mappings;
    using ForumSystem.Models;

    public class ForumPostDetailsViewModel : IMapFrom<ForumPost>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public string Avatar { get; set; }

        public IEnumerable<Answer> Answers { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumPost, ForumPostDetailsViewModel>()
               .ForMember(r => r.Answers, opts => opts.MapFrom(x => x.Answers))
               .ForMember(r => r.Author, opts => opts.MapFrom(x => x.Author.UserName))
               .ForMember(r => r.Avatar, opts => opts.MapFrom(x => x.Author.Photo));
        }
    }
}