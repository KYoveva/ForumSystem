namespace ForumSystem.Web.MVC.Models.Answers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using ForumSystem.Models;
    using Infrastructure.Mappings;

    public class AnswersViewModel : IMapFrom<Answer>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Avatar { get; set; }

        public string Author { get; set; }

        public string AuthorId { get; set; }

        public int ForumPostId { get; set; }

        public int LikesCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Answer, AnswersViewModel>()
               .ForMember(r => r.Avatar, opts => opts.MapFrom(x => x.Author.Avatar))
               .ForMember(r => r.Author, opts => opts.MapFrom(x => x.Author.UserName))
               .ForMember(r => r.LikesCount, opts => opts.MapFrom(x => (x.Likes.Count - x.Dislikes.Count)));
        }
    }
}