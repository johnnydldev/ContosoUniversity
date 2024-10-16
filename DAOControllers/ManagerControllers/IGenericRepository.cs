using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAOControllers.ManagerControllers
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> getAll();
        Task<T> getById(int id);
        Task<int> create(T model);
        Task<bool> edit(T model);
        Task<bool> delete(int id);
        Task<int> getMaxId();
        Task<List<T>> getAllMatchedBy(int idModel);
        Task<List<T>> getAllMatchesWith(string name);
        Task<List<T>> getAllMatches(int idModel, string name);
    }
}
