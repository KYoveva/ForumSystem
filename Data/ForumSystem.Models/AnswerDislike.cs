namespace ForumSystem.Models
{
    public class AnswerDislike
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
