namespace ForumSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IForumPostCategoriesService
    {
        IQueryable<ForumPostCategory> AllForumPostCategories();

        ForumPostCategory AddCategory(ForumPostCategory toAdd);

        void Delete(ForumPostCategory toDelete);

        void SaveChanges();
    }
}
