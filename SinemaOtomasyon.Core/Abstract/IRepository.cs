using System;
using System.Collections.Generic;
using System.Linq;
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

        T GetById(int id);
    }
}
