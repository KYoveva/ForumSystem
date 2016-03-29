namespace ForumSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IForumPostCategoriesService
    {
        IQueryable<ForumPostCategory> AllForumPostCategories();
    }
}
