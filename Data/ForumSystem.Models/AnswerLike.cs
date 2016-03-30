namespace ForumSystem.Models
{
    using Data.Common.Models;

    public class AnswerLike : BaseModel<int>
    {
        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
