﻿using SinemaOtomasyon.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.Core.Concrete
{
    public abstract class EFRepositoryBase<T, TContext> : IRepository<T>
        where T : class, new()
        where TContext : DbContext
    {

        protected DbContext _dbContext;
        protected DbSet<T> _dbSet;

        public EFRepositoryBase(DbContext Context)
        {
            _dbContext = Context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Update(T model)
        {
            var entity = _dbSet.Find(model);
            _dbContext.Entry(entity).CurrentValues.SetValues(model);
            _dbContext.SaveChanges();
        }
    }
}