namespace ForumSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;
    using Data.Common.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity, ITKeyEntity<string>
    {
        private ICollection<ForumPost> forumPosts;
        private ICollection<Answer> answers;
        private ICollection<AnswerLike> answerLikes;
        private ICollection<AnswerDislike> answerDislikes;

        public User()
        {
            this.forumPosts = new HashSet<ForumPost>();
            this.answers = new HashSet<Answer>();
            this.answerLikes = new HashSet<AnswerLike>();
            this.answerDislikes = new HashSet<AnswerDislike>();
        }

        [RegularExpression(ModelConstants.ValidateUrl)]
        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<ForumPost> ForumPosts
        {
            get { return this.forumPosts; }
            set { this.forumPosts = value; }
        }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }

        public virtual ICollection<AnswerLike> AnswerLikes
        {
            get { return this.answerLikes; }
            set { this.answerLikes = value; }
        }

        public virtual ICollection<AnswerDislike> AnswerDislikes
        {
            get { return this.answerDislikes; }
            set { this.answerDislikes = value; }
        }
    }
}
