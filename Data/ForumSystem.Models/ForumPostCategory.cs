namespace ForumSystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ForumPostCategory
    {
        private ICollection<ForumPost> forumPosts;

        public ForumPostCategory()
        {
            this.forumPosts = new HashSet<ForumPost>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public ICollection<ForumPost> ForumPosts
        {
            get { return this.forumPosts; }
            set { this.forumPosts = value; }
        }
    }
}
