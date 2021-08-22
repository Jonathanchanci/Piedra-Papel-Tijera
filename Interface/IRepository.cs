using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Interface
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> Getlist();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<bool> Update(T entiry);
        Task<bool> Delete(int id);
    }
}
