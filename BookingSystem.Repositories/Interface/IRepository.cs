

using CrossWorkersBookingSystem.Models.Models;
using System.Linq;

namespace CrossWorkersBookingSystem.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        T GetById(int id);

        T Insert(T entity);

        void Commit();
    }
}
