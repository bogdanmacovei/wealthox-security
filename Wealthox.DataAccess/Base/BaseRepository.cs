﻿using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wealthox.DataAccess.Data;

namespace Wealthox.DataAccess.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        protected WealthoxContext Context { get; }

        public BaseRepository(WealthoxContext context)
        {
            Context = context;
            Query = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query { get; }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
