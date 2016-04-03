namespace ForumSystem.Services.Data.Contracts
{
    using System.Linq;
    using Models;

    public interface IAnswersService
    {
        IQueryable<Answer> AnswersByPostId(int id);

        Answer AnswersById(int id);

        Answer AddAnswer(Answer toAdd);

        void Delete(Answer toDelete);
    }
}
