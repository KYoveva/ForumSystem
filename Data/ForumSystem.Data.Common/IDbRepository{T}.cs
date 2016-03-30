﻿namespace ForumSystem.Data.Common
{
    using System.Linq;
    using Models;

    public interface IDbRepository<T, in TKey>
        where T : IAuditInfo, IDeletableEntity, ITKeyEntity<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();
    }
}