namespace ForumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Answer
    {
        private ICollection<AnswerLike> likes;
        private ICollection<AnswerDislike> dislikes;

        public Answer()
        {
            this.likes = new HashSet<AnswerLike>();
            this.dislikes = new HashSet<AnswerDislike>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ForumPostId { get; set; }

        public virtual ForumPost ForumPost { get; set; }

        public virtual ICollection<AnswerLike> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }

        public virtual ICollection<AnswerDislike> Dislikes
        {
            get { return this.dislikes; }
            set { this.dislikes = value; }
        }
    }
}
