namespace ForumSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IForumPostsService
    {
        IQueryable<ForumPost> ForumPostsByCategory(int id);

        IQueryable<ForumPost> ForumPostById(int id);
    }
}
