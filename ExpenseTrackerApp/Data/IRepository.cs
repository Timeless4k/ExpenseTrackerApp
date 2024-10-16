using System.Collections.Generic;

namespace ExpenseTrackerApp.Data
{
    public interface IRepository<T> where T : class
    {
        // Get an entity by its ID
        T? GetById(int id);

        // Get all entities
        List<T> GetAll();

        // Add a new entity
        bool Add(T entity);

        // Update an existing entity
        bool Update(T entity);

        // Delete an entity by its ID
        bool Delete(int id);
    }
}
