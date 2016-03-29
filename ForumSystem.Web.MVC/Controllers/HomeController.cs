namespace ForumSystem.Web.MVC.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Models.ForumPostCategories;
    using Services.Data.Contracts;

    public class HomeController : Controller
    {
        private IForumPostCategoriesService forumPostCategoriesService;

        public HomeController(IForumPostCategoriesService forumPostCategoriesService)
        {
            this.forumPostCategoriesService = forumPostCategoriesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetCategoriesPartial()
        {
            var forumPostCategoriesData = this.forumPostCategoriesService
                        .AllForumPostCategories()
                        .ProjectTo<ForumPostCategoriesViewModel>()
                        .ToList(); 

            return this.PartialView("_ForumPostCategoriesPartial", forumPostCategoriesData);
        }
    }
}