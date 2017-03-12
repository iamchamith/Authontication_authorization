﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Service.Infastucture
{
    public interface IRepositoryRead<T> where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetByID(object id);

        IEnumerable<T> Get(int skip = 0, int take = 0, string sortBy = "", bool isASC = false, string search = null);
    }

    public interface IRepositoryUpdate<T> where T : class
    {
        void Insert(T entity);
        void Delete(object id);
        void Delete(T entityToDelete);
        void Update(T entityToUpdate);
    }

    public interface IRepositoryUpdateAsync<T> where T : class
    {

        Task<int> InsertAsync(T entity);
        Task DeleteAsync(object id);
        Task UpdateAsync(T entityToUpdate);
    }
}
