﻿namespace ForumSystem.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using ForumSystem.Data.Common;
    using Models;

    public class ForumPostsService : IForumPostsService
    {
        private readonly IDbRepository<ForumPost, int> forumPosts;

        public ForumPostsService(IDbRepository<ForumPost, int> forumPosts)
        {
            this.forumPosts = forumPosts;
        }

        public ForumPost AddForumPost(ForumPost toAdd)
        {
            this.forumPosts.Add(toAdd);
            this.forumPosts.Save();

            return toAdd;
        }

        public IQueryable<ForumPost> ForumPostById(int id)
        {
            return this.forumPosts.All().Where(x => x.Id == id);
        }

        public IQueryable<ForumPost> ForumPostsByCategory(int id)
        {
            return this.forumPosts.All().Where(x=>x.Category.Id==id);
        }

    }
}
