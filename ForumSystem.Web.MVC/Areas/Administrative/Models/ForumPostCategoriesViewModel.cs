namespace ForumSystem.Web.MVC.Areas.Administrative.Models
{
    using ForumSystem.Models;
    using Infrastructure.Mappings;

    public class ForumPostCategoriesViewModel: IMapFrom<ForumPostCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}