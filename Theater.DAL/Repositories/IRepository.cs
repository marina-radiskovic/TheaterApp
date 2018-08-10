using System;
using System.Collections.Generic;
using System.Text;

namespace Theater.DAL.Repositories
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IList<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}
