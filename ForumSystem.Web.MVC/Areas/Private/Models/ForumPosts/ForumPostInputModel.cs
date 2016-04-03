namespace ForumSystem.Web.MVC.Areas.Private.Models.ForumPosts
{
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Models;
    using Infrastructure.Mappings;

    public class ForumPostInputModel : IMapFrom<ForumPost>
    {
        public ForumPostInputModel()
        {
        }

        public ForumPostInputModel(string categoryId)
        {
            var category = int.Parse(categoryId);
            this.CategoryId = category;
        }

        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(150, ErrorMessage = "Maximum 150 characters exceeded")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Content")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(1000, ErrorMessage = "Content must be between 5 and 1000 symbols!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int CategoryId { get; set; }

    }
}