namespace ForumSystem.Web.MVC.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Areas.Private.Models.Answers;
    using AutoMapper;
    using ForumSystem.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;

    public class AnswerController : Controller
    {
        private IAnswersService answersService;

        public AnswerController(IAnswersService answersService)
        {
            this.answersService = answersService;
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(AnswersInputModel model)
        {
            var userId = this.User.Identity.GetUserId();

            if (model != null && ModelState.IsValid)
            {
                var answer = Mapper.Map<Answer>(model);
                answer.AuthorId = userId;
                answer.CreatedOn = DateTime.UtcNow;
                answer = this.answersService.AddAnswer(answer);

                return this.Json(new { forumPostId = model.ForumPostId });
            }

            else
            {
                throw new HttpException(400, "Invalid answer");
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var answer = this.answersService.AnswersById(id);
            if (answer != null)
            {
                this.answersService.Delete(answer);
            }

            return this.Json(new { Id = answer.ForumPostId });
        }
    }
}