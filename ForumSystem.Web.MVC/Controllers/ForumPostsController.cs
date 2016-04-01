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
    using Areas.Private.Models.ForumPosts;
    using Microsoft.AspNet.Identity;
    using AutoMapper;
    using ForumSystem.Models;
    using System;
    using Common.Toastr;

    public class ForumPostsController : Controller
    {
        private const int PageSize = 10;

        private IForumPostsService posts;
        private IAnswersService answersService;

        public ForumPostsController(IForumPostsService posts, IAnswersService answersService)
        {
            this.posts = posts;
            this.answersService = answersService;
        }

        public ActionResult ForumPosts(int id)
        {
            var forumPosts = this.posts
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
            var forumPosts = this.posts
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

            return this.PartialView("_ForumPostAnswersPartial", answersData.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult DisplayPartial(ForumPostInputModel model)
        {
            return this.PartialView("~/Areas/Private/Views/ForumPosts/_AddForumPostPartial.cshtml", model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddForumPost(ForumPostInputModel model)
        {
            var userId = this.User.Identity.GetUserId();
            if (model != null && ModelState.IsValid)
            {
                var post = Mapper.Map<ForumPost>(model);
                post.AuthorId = userId;
                post.CreatedOn = DateTime.UtcNow;

                post = this.posts.AddForumPost(post);

                this.AddToastMessage("Success", "Your forum post was added successfully!", ToastType.Success);
            }
            else
            {
                this.AddToastMessage("Error", "Invalid forum post!", ToastType.Error);
            }
            return Redirect("/");
        }
    }
}