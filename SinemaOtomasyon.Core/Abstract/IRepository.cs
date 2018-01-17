using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.Core.Abstract
{
    public interface IRepository<T>
        where T:class,new()
    {
        void Add(T model);

        void Update(T model);

        void Delete(int id);

        List<T> GetList();

        IEnumerable<T> Where(Expression<Func<T, bool>> lambda);

        IQueryable<T> WhereByQuery(Expression<Func<T, bool>> lambda);

        T GetById(int id);

    }
}
