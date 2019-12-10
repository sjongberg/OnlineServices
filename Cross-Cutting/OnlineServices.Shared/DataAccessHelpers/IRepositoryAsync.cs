using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineServices.Shared.DataAccessHelpers
{
    public interface IRepositoryAsync<T,U>
        where T : class
    {
        Task<List<T>> FindAll();
        Task<T> FindById(U id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
