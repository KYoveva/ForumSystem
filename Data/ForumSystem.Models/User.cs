namespace ForumSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<ForumPost> forumPosts;
        private ICollection<Answer> answers;
        private ICollection<AnswerLike> answerLikes;
        private ICollection<AnswerDislike> answerDislike;

        public User()
        {
            this.forumPosts = new HashSet<ForumPost>();
            this.answers = new HashSet<Answer>();
            this.answerLikes = new HashSet<AnswerLike>();
            this.answerDislike = new HashSet<AnswerDislike>();
        }

        [RegularExpression(ModelConstants.ValidateUrl)]
        public string Avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
