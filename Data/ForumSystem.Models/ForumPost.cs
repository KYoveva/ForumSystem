namespace ForumSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ForumPost
    {
        private ICollection<Answer> answers;

        public ForumPost()
        {
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ForumPostCategory Category { get; set; }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }
    }
}
