namespace ForumSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using ForumSystem.Data.Repositories;
    using Models;

    public class ForumPostCategoriesService : IForumPostCategoriesService
    {
        private readonly IRepository<ForumPostCategory> categories;

        public ForumPostCategoriesService(IRepository<ForumPostCategory> categories)
        {
            this.categories = categories;
        }

        public IQueryable<ForumPostCategory> AllForumPostCategories()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
