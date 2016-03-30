namespace ForumSystem.Services.Data
{
    using System.Linq;
    using Contracts;
    using ForumSystem.Data.Common;
    using Models;

    public class ForumPostCategoriesService : IForumPostCategoriesService
    {
        private readonly IDbRepository<ForumPostCategory, int> categories;

        public ForumPostCategoriesService(IDbRepository<ForumPostCategory, int> categories)
        {
            this.categories = categories;
        }

        public IQueryable<ForumPostCategory> AllForumPostCategories()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }
    }
}
