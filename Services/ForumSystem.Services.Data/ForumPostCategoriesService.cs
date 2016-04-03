namespace ForumSystem.Services.Data
{
    using System;
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

        public ForumPostCategory AddCategory(ForumPostCategory toAdd)
        {
            toAdd.CreatedOn = DateTime.UtcNow;
            this.categories.Add(toAdd);
            this.categories.Save();

            return toAdd;
        }

        public void Delete(ForumPostCategory toDelete)
        {
            this.categories.Delete(toDelete);
            this.categories.Save();
        }

        public void SaveChanges()
        {
            this.categories.Save();
        }
    }
}
