﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Interfaces
{
    public interface IRepository<TEntity> : IRepository
       where TEntity : IEntity
    {
        IQueryable<TEntity> Query { get; }
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }

    public interface IRepository
    {

    }
}
