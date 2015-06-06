using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using testMVC4.Models;

namespace testMVC4.Repositories
{
    public class BaseRepository<T> : IDisposable where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _objectSet;

        public BaseRepository()
        {
            _context = new hospitalDBEntities();
            _objectSet = _context.Set<T>();
        }

        public virtual void Insert(ref T model)
        {
            _objectSet.Add(model);
            _context.Entry<T>(model).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Insert(IEnumerable<T> entities)
        {
            _objectSet.AddRange(entities);
            _context.SaveChanges();
        }

        public virtual void InsertOrUpdate(T model, object id)
        {
            T entity = _objectSet.Find(id);
            if (entity != null)
                Update(model);
            else
                Insert(ref model);
        }

        public virtual void Update(T model)
        {
            _context.Entry<T>(model).State = EntityState.Modified;//EntityState.Unchanged;
            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> entities)
        {
            foreach (var model in entities)
                _context.Entry<T>(model).State = EntityState.Modified;//.Unchanged;//Modified;
            _context.SaveChanges();
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> query)
        {
            return _objectSet.FirstOrDefault(query);
        }

        public virtual T FirstOrDefault()
        {
            return _objectSet.FirstOrDefault();
        }

        public virtual IEnumerable<T> ToList()
        {
            return _objectSet.ToList();
        }

        public virtual bool Delete(T entity)
        {
            if (entity != null)
            {
                _objectSet.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            return false;
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}