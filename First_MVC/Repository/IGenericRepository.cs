using System.Linq;
using System.Collections.Generic;

namespace First_MVC.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
        IQueryable<T> GetAll(); // Updated to IQueryable<T> to match the implementation
        T GetById(int id);
        void Save();
    }
}
