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
            this.CategoryId= category;
        }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000), MinLength(1)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public int CategoryId { get; set; }

    }
}