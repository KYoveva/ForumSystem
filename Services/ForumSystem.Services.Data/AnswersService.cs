namespace ForumSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;
    using ForumSystem.Data.Common;

    public class AnswersService : IAnswersService
    {
        private readonly IDbRepository<Answer, int> answers;

        public AnswersService(IDbRepository<Answer, int> answers)
        {
            this.answers = answers;
        }

        public Answer AddAnswer(Answer toAdd)
        {
            this.answers.Add(toAdd);
            this.answers.Save();

            return toAdd;
        }

        public Answer AnswersById(int id)
        {
            return this.answers.All()
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Answer> AnswersByPostId(int id)
        {
            return this.answers.All()
                .Where(x => x.ForumPostId == id);
        }

        public void Delete(Answer toDelete)
        {
            this.answers.Delete(toDelete);
            this.answers.Save();
        }
    }
}
