namespace ForumSystem.Web.MVC.Areas.Administrative.Models
{
    using ForumSystem.Models;
    using Infrastructure.Mappings;
    using System.ComponentModel.DataAnnotations;

    public class ForumPostCategoriesViewModel: IMapFrom<ForumPostCategory>
    {
        [Editable(false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}