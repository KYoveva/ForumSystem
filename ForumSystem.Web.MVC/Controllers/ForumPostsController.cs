namespace ForumSystem.Web.MVC.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.ForumPosts;
    using Models.Answers;
    using PagedList;
    using Services.Data.Contracts;

    public class ForumPostsController : Controller
    {
        private const int PageSize = 10;

        private IForumPostsService forumPostsService;
        private IAnswersService answersService;

        public ForumPostsController(IForumPostsService forumPostsService, IAnswersService answersService)
        {
            this.forumPostsService = forumPostsService;
            this.answersService = answersService;
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

        [HttpGet]
        public ActionResult _ForumPostAnswersPartial(int? page, int id)
        {
            var answersData =
                this.answersService
                .AnswersByPostId(id)
                .OrderByDescending(x => x.CreatedOn)
                .ProjectTo<AnswersViewModel>();

            int pageNumber = page ?? 1;
            
            return PartialView("_ForumPostAnswersPartial", answersData.ToPagedList(pageNumber, PageSize));
        }
    }
}