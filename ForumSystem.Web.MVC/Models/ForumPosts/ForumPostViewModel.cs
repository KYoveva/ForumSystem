namespace ForumSystem.Web.MVC.Models.ForumPosts
{
    using System;
    using AutoMapper;
    using ForumSystem.Models;
    using Infrastructure.Mappings;

    public class ForumPostViewModel : IMapFrom<ForumPost>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public int AnswersCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ForumPost, ForumPostViewModel>()
               .ForMember(r => r.AnswersCount, opts => opts.MapFrom(x => x.Answers.Count))
               .ForMember(r => r.Author, opts => opts.MapFrom(x => x.Author.UserName));
        }
    }
}