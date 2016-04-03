namespace ForumSystem.Web.MVC.Areas.Private.Models.Answers
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mappings;
    using ForumSystem.Models;

    public class AnswersInputModel : IMapFrom<Answer>
    {
        [Required]
        [Display(Name = "Content")]
        [StringLength(1000, MinimumLength = 1, ErrorMessage ="Content must be between 1 and 1000 symbols!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int ForumPostId { get; set; }
    }
}