﻿using SinemaOtomasyon.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SinemaOtomasyon.Core.Concrete
{
    public class EFRepositoryBase<T, TContext> : IRepository<T>
        where T : class, new()
        where TContext : DbContext
    {

        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected bool _disposed = false;


        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);

        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);

        }      

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsEnumerable();
        }

        public IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda)
        {
            return _dbSet.Where(lambda).AsQueryable();
        }
    }
}
