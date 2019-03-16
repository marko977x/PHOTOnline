using PhotoLine.Domain.Entities;
using System.Threading.Tasks;

namespace PhotoLine.Services.Repositories
{
    public interface IGenericRepository<T> where T : IEntity
    {
        Task<T> FindAsync(int id);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
