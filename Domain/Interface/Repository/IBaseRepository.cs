using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void AddTest(T obj);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T obj);
        void Remove(T obj);
        void Dispose();
    }
}
