// Data/IRepository.cs
using System.Collections.Generic;

namespace ExpenseTrackerApp.Data
{
    public interface IRepository<T>
    {
        T? GetById(int id);  
        List<T> GetAll();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
