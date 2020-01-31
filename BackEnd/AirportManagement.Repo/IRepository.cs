using System;
using System.Collections.Generic;
using AirportManagement.Data;

namespace AirportManagement.Repo
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}