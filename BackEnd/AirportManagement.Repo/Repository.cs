using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AirportManagement.Data;

namespace AirportManagement.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Get(Guid id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entities");
            }

            _entities.AddRangeAsync(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentException("entities");
            }
            _entities.RemoveRange(entities);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}