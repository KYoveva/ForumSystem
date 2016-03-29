namespace ForumSystem.Web.MVC.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.ForumPosts;
    using Services.Data.Contracts;

    public class ForumPostsController : Controller
    {
        private IForumPostsService forumPostsService;

        public ForumPostsController(IForumPostsService forumPostsService)
        {
            this.forumPostsService = forumPostsService;
        }

        public ActionResult ForumPosts(int id)
        {
            var forumPosts = this.forumPostsService
                .ForumPostsByCategory(id)
                .ProjectTo<ForumPostViewModel>()
                .ToList();

            if (forumPosts == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(forumPosts);
        }

        public ActionResult Details(int id)
        {
            var forumPosts = this.forumPostsService
                .ForumPostById(id)
                .ProjectTo<ForumPostDetailsViewModel>()
                .ToList();

            if (forumPosts == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Item not Found");
            }

            return this.View(forumPosts);
        }
    }
}