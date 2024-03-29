﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);

        Task<IList<T>> GetList(Expression<Func<T, bool>> filter = null);

        Task<T> Add(T entity);

        Task Update(T entity);

        Task<bool> Delete(int id);
    }
}