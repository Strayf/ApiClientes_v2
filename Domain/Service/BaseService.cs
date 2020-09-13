using Domain.Interface.Repository;
using Domain.Interface.Service;
using System;

namespace Domain.Service
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {

        }
    }
}
