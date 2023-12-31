﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.RepositoryManager
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get2(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
