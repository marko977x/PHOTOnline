using Domain.Entities;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PhotoLine.Services.Repositories
{
    public interface IGenericRepository<T> where T : IEntity
    {
        Task<T> FindAsync(string id);
        Task<string> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
    }
}
